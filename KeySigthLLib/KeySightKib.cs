using System;
using System.Threading;
using System.IO;
using Ivi.Visa.Interop;
using System.Runtime.InteropServices;
using System.ComponentModel;


namespace MatheusProductions.KeysightLib
{

    public class Keysight
    {
        public static void SalvaPrints(FormattedIO488 instr, string nomePasta, string nomePrint, bool tPrints)
        {

            if (tPrints)
            {
                nomePasta = nomePasta + @"\" + nomePrint;
                instr.WriteString(@$"MMEM:STOR:SCR '{nomePasta}.PNG'"); // Faça a captura de tela
            }

        }

        public static void CriaPasta(string nomePasta, string nomeSubPasta = "")
        {
            //---------------------------------------------------------------
            //Cria Uma pasta para salvar os valores
            //---------------------------------------------------------------

            // 
            // Adicionando o nome Valores do Marker dentro da variavel Nome Pasta
            using (NetworkShareAccesser.Access("A-N9010A-00151", "Administrator", "agilent4u"))
            {
                nomePasta = System.IO.Path.Combine(nomePasta, nomeSubPasta);

                //Cria pasta
                System.IO.Directory.CreateDirectory(nomePasta);
            }


            // Verifica o Caminho
        }

        public static FileStream CriaArquivo(string nomeArquivo, string nomePasta = "")
        {
            using (NetworkShareAccesser.Access("A-N9010A-00151", "Administrator", "agilent4u"))
            {
                nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);
            }

            return File.Create(nomePasta);
        }


        public static void Pega_Salva_MarkerTempodeOcupação(FormattedIO488 instr, string nomeArquivo, string nomePasta, string freqC, string nome)
        {
            // Inicia as variaveis do marker, com valores padrao para entrar no While
            double New_markerX = 0;
            double New_markerY = 0;
            //Criar um while que define
            //o o marker para o Peak search e pegando o X e Y
            //E testa se esses valores não mudaram em 10 segundos
            // -----------------------------------------------------------
            
            instr.WriteString("CALC1:MARK2:MAX"); //  Definindo o marker para o Peak search

            instr.WriteString("CALC1:MARK2:X?");
            New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
            instr.WriteString("CALC1:MARK2:Y?");
            New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);

            
            SalvaMarkers(nomeArquivo, nomePasta, New_markerX, New_markerY, freqC, nome);
        }

        /*
        public static bool TestaSeTaNaBeira(FormattedIO488 instr ,int i,double posicaoMarkerAntigo, double potenciaMarkerAntigo)
        {
            double aux = 0;
            instr.WriteString($"CALC1:MARK1:X {posicaoMarkerAntigo - 10}");
            aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
            if (potenciaMarkerAntigo - )
            return true;
        }
        */
        public static FileStream CriaArquivoSemSenha(string nomeArquivo, string nomePasta = "")
        {
            nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);
            return File.Create(nomePasta);
        }

        public static bool Inicializacao(FormattedIO488 instr, ResourceManager rm, string ip)
        {
            try // Criar um Try-catch separado para inicialização impede o acesso a objetos não inicializados
            {
                //-----------------------------------------------------------
                // Inicialização:
                //-----------------------------------------------------------
                // Ajuste a string de recursos VISA para se adequar ao seu instrumento 
                instr.IO = (IMessage)rm.Open(ip);
                instr.IO.Timeout = 3000; // Tempo limite para operações de leitura VISA
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static void Pega_Salva_MarkersSCS(FormattedIO488 instr, string nomeArquivo, string nomePasta, string valFreq,string nome, int numMarkers)
        {
            for (int i = 1; i <= numMarkers; i++)
            {
                instr.WriteString($"CALC1:MARK{i}:MODE?");
                string isDelta = instr.ReadString();
                if (isDelta == "DELT\n")
                {
                    double New_markerX;
                    double New_markerY;
                    instr.WriteString($"CALC1:MARK{i}:X?");
                    New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    instr.WriteString($"CALC1:MARK{i}:Y?");
                    New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    Thread.Sleep(10000);
                    SalvaMarkers(nomeArquivo, nomePasta, New_markerX / 1000, New_markerY, valFreq, nome);
                }
            }

        }

        public static int ContaMarker(FormattedIO488 instr)
        {
            int cont = 0;
            bool aux = true;
            instr.WriteString($"CALC:MARK:AOFF");
            while (aux)
            {
                cont++;
                if (cont == 12)
                {
                    return cont;
                }
                if (cont == 1)
                {
                    instr.WriteString($"CALC1:MARK{cont}:MAX");
                }
                else
                {
                    instr.WriteString($"CALC1:MARK{cont}:MAX");
                    instr.WriteString($"CALC1:MARK{cont}:REF 1");
                    while (MesmaPosicao(instr, cont))
                    {
                        instr.WriteString($"CALC:MARK{cont}:MAX:NEXT");
                    }
                    if (!MesmaAltura(instr, cont))
                    {
                        instr.WriteString($"CALC1:MARK{cont}:MODE OFF");
                        aux = false;
                    }

                }
            }
            return cont - 1;
        }


        public static double MedeMarker(FormattedIO488 instr)
        {
            instr.WriteString($"CALC1:MARK1:MODE POS");
            instr.WriteString($"CALC1:MARK1:MAX");
            instr.WriteString($"CALC1:MARK1:Y?");
            return (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
        }

        public static bool MesmaAltura(FormattedIO488 instr, int cont)
        {
            double aux;
            instr.WriteString($"CALC1:MARK{cont}:Y?");
            aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
            if (aux >= -1 && aux <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo)
        {
            instr.WriteString($"CONF:{modo}"); // Seleciona o modo
            instr.WriteString($"UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
            instr.WriteString($"SENS:POW:RF:ATT {att} dB"); //Configura o ATT
            instr.WriteString($"DISP:WIND:TRAC:Y:SCAL:RLEV {refL} dbm"); // Configura o Reference Level
            instr.WriteString($"FREQ:CENT {freqC} Mhz"); // Configura a Frequencia Central
            instr.WriteString($"FREQ:SPAN {span} MHz"); // Configura o span
            instr.WriteString($"BAND {rbw} kHz"); // Configura o RBW
            instr.WriteString($"BAND:VID {vbw} kHz"); // Configura o VBW
            instr.WriteString($"SWE:TIME:AUTO {sweepAuto}"); // Configura o sweep points
            instr.WriteString($"TRAC:TYPE {trace}"); //Configura o Trace
            instr.WriteString($"SENS:DET:TRAC {detector}"); //Configura o Trace
        }

        public static void ConfiguraInstrZeroSpan(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo)
        {
            instr.WriteString($"CONF:{modo}"); // Seleciona o modo
            instr.WriteString($"UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
            instr.WriteString($"SENS:POW:RF:ATT {att} dB"); //Configura o ATT
            instr.WriteString($"DISP:WIND:TRAC:Y:SCAL:RLEV {refL} dbm"); // Configura o Reference Level
            instr.WriteString($"FREQ:CENT {freqC} Mhz"); // Configura a Frequencia Central
            instr.WriteString($"FREQ:SPAN {span} MHz"); // Configura o span
            instr.WriteString($"BAND {rbw} kHz"); // Configura o RBW
            instr.WriteString($"BAND:VID {vbw} kHz"); // Configura o VBW
            instr.WriteString($"SWE:TIME {sweepAuto}"); // Configura o sweep points
            instr.WriteString($"TRAC:TYPE {trace}"); //Configura o Trace
            instr.WriteString($"SENS:DET:TRAC {detector}"); //Configura o Trace
        }

        public static void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo, string integBW)
        {
            //Channel Power
            instr.WriteString($"CONF:{modo}"); // Seleciona o modo
            instr.WriteString($"CHP:BAND:INT {integBW} Mhz"); // Configura a largura de banda
            instr.WriteString($"UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
            instr.WriteString($"SENS:POW:RF:ATT {att} dB"); //Configura o ATT
            instr.WriteString($"DISP:CHP:VIEW:WIND:TRAC:Y:RLEV {refL} dbmw"); // Configura o Reference Level
            instr.WriteString($"FREQ:CENT {freqC} Mhz"); // Configura a Frequencia Central
            instr.WriteString($"CHP:FREQ:SPAN {span} Mhz"); // Configura o span
            instr.WriteString($"CHP:BWID:RES {rbw} kHz"); // Configura o RBW
            instr.WriteString($"CHP:BWID:VID {vbw} kHz"); // Configura o VBW
            instr.WriteString($"CHP:SWE:TIME:AUTO {sweepAuto}"); // Configura o sweep points
            instr.WriteString($"TRAC:CHP:TYPE {trace}"); //Configura o Trace
            instr.WriteString($"CHP:DET {detector}"); //Configura o Trace
        }

        public static void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo, string porc_Ocu, string qDbs)
        {
            instr.WriteString($"CONF:{modo}"); // Seleciona o modo
            instr.WriteString($"SENS:OBW:PERC {porc_Ocu}"); // Seleciona a porcentagem de Occupied Bandwidth Measurement
            instr.WriteString($"SENS:OBW:XDB {qDbs} DB"); // Seleciona a distancia (6/26) db de Occupied Bandwidth Measurement
            instr.WriteString($"UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
            instr.WriteString($"SENS:POW:RF:ATT {att} dB"); //Configura o ATT
            instr.WriteString($"DISP:OBW:VIEW:WIND:TRAC:Y:RLEV {refL} dbmw"); // Configura o Reference Level
            instr.WriteString($"FREQ:CENT {freqC} Mhz"); // Configura a Frequencia Central
            instr.WriteString($"OBW:FREQ:SPAN {span} Mhz"); // Configura o span
            instr.WriteString($"OBW:BWID:RES {rbw} kHz"); // Configura o RBW
            instr.WriteString($"OBW:BWID:VID {vbw} kHz"); // Configura o VBW
            instr.WriteString($"OBW:SWE:TIME:AUTO {sweepAuto}"); // Configura o sweep points
            instr.WriteString($"TRAC:OBW:TYPE {trace}"); //Configura o Trace
            instr.WriteString($"OBW:DET {detector}"); //Configura o Trace
        }

        public static void ConfiguraInstrSalto(FormattedIO488 instr, string freqI, string freqF, string unidadeY, string att, string refL, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo)
        {
            instr.WriteString($"CONF:{modo}"); // Seleciona o modo
            instr.WriteString($"UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
            instr.WriteString($"SENS:POW:RF:ATT {att} dB"); //Configura o ATT
            instr.WriteString($"DISP:WIND:TRAC:Y:SCAL:RLEV {refL} dbm"); // Configura o Reference Level
            instr.WriteString($"FREQ:STAR {freqI} Mhz"); // Configura a Frequencia Inicial
            instr.WriteString($"FREQ:STOP {freqF} Mhz"); // Configura a Frequencia Final
            instr.WriteString($"BAND {rbw} kHz"); // Configura o RBW
            instr.WriteString($"BAND:VID {vbw} kHz"); // Configura o VBW
            instr.WriteString($"SWE:TIME:AUTO {sweepAuto}"); // Configura o sweep points
            instr.WriteString($"TRAC:TYPE {trace}"); //Configura o Trace
            instr.WriteString($"SENS:DET:TRAC {detector}"); //Configura o Trace
        }

        public static void SalvaMarkers(string nomeArquivo, string nomePasta, double markerX, double markerY, string freqC, string nome)
        {
            using (NetworkShareAccesser.Access("A-N9010A-00151", "Administrator", "agilent4u"))
            {
                if (!System.IO.File.Exists(nomePasta + @"\" + nomeArquivo))
                {
                    // Combina o nome do arquivo ao caminho onde ta os prints
                    CriaPasta(nomePasta);
                    //Criando o arquivo e adicionando os Valores
                    System.IO.FileStream fs = CriaArquivo(nomeArquivo, nomePasta);
                    fs.Close();

                    nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);
                    File.AppendAllText(nomePasta, nome.ToString() + ";");
                    File.AppendAllText(nomePasta, freqC.ToString() + ";");
                    File.AppendAllText(nomePasta, markerX.ToString() + ";");
                    File.AppendAllText(nomePasta, markerY.ToString() + "\n");


                }
                else
                {
                    nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);
                    File.AppendAllText(nomePasta, nome.ToString() + ";");
                    File.AppendAllText(nomePasta, freqC.ToString() + ";");
                    File.AppendAllText(nomePasta, markerX.ToString() + ";");
                    File.AppendAllText(nomePasta, markerY.ToString() + "\n");
                }
            }
        }

        public static void SalvaValores(string nomeArquivo, string nomePasta, string valor, string freqC, string nome)
        {
            using (NetworkShareAccesser.Access("A-N9010A-00151", "Administrator", "agilent4u"))
            {
                if (!System.IO.File.Exists(nomePasta + @"\" + nomeArquivo))
                {
                    // Combina o nome do arquivo ao caminho onde ta os prints
                    CriaPasta(nomePasta);
                    //Criando o arquivo e adicionando os Valores
                    System.IO.FileStream fs = CriaArquivo(nomeArquivo, nomePasta);
                    fs.Close();

                    nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);

                    File.AppendAllText(nomePasta, nome.ToString() + ";");
                    File.AppendAllText(nomePasta, freqC.ToString() + ";");
                    File.AppendAllText(nomePasta, valor.ToString() + "\n");

                }
                else
                {
                    nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);
                    File.AppendAllText(nomePasta, nome.ToString() + ";");
                    File.AppendAllText(nomePasta, freqC.ToString() + ";");
                    File.AppendAllText(nomePasta, valor.ToString() + "\n");
                }
            }
        }

        public static void SalvaValores(string nomeArquivo, string nomePasta, double valor, double valor2, string freqC, string nome)
        {
            using (NetworkShareAccesser.Access("A-N9010A-00151", "Administrator", "agilent4u"))
            {
                if (!System.IO.File.Exists(nomePasta + @"\" + nomeArquivo))
                {
                    CriaPasta(nomePasta);
                    //Criando o arquivo e adicionando os Valores
                    System.IO.FileStream fs = CriaArquivo(nomeArquivo, nomePasta);
                    fs.Close();

                    nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);

                    File.AppendAllText(nomePasta, nome.ToString() + ";");
                    File.AppendAllText(nomePasta, freqC.ToString() + ";");
                    File.AppendAllText(nomePasta, valor.ToString() + ";");
                    File.AppendAllText(nomePasta, valor2.ToString() + "\n");

                }
                else
                {
                    File.AppendAllText(nomePasta, nome.ToString() + ";");
                    nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);
                    File.AppendAllText(nomePasta, freqC.ToString() + ";");
                    File.AppendAllText(nomePasta, valor.ToString() + ";");
                    File.AppendAllText(nomePasta, valor2.ToString() + "\n");
                }
            }
        }

        public static void Pega_Salva_Marker(FormattedIO488 instr, string nomeArquivo, string nomePasta, string freqC, string trace, string nome)
        {
            // Inicia as variaveis do marker, com valores padrao para entrar no While
            double markerX = 1;
            double markerY = 1;
            double New_markerX = 0;
            double New_markerY = 0;
            //Criar um while que define
            //o o marker para o Peak search e pegando o X e Y
            //E testa se esses valores não mudaram em 10 segundos
            // -----------------------------------------------------------
            if (trace == "MAXH")
            {
                while (markerY != New_markerY && markerX != New_markerX)
                {
                    markerX = New_markerX;
                    markerY = New_markerY;
                    instr.WriteString("CALC1:MARK1:MAX"); //  Definindo o marker para o Peak search
                    instr.WriteString("CALC1:MARK1:X?");
                    New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    instr.WriteString("CALC1:MARK1:Y?");
                    New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    Thread.Sleep(10000);
                }

            }
            else
            {
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("CALC1:MARK1:MAX"); //  Definindo o marker para o Peak search
                instr.WriteString("CALC1:MARK1:X?");
                New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                instr.WriteString("CALC1:MARK1:Y?");
                New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
            }
            SalvaMarkers(nomeArquivo, nomePasta, New_markerX, New_markerY, freqC, nome);
        }

        public static void AchaSinalZeroSpan(FormattedIO488 instr)
        {
            double markerY = 0;
            while (markerY < -10)
            {
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("CALC1:MARK1:MAX"); //  Definindo o marker para o Peak search
                instr.WriteString("CALC1:MARK1:Y?");
                markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                Thread.Sleep(500);
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("*WAI");
            }

        }
        /*
        public static void Pega_Salva_Marker_Espurios(FormattedIO488 instr, string configFreq, string nomeArquivo, string nomePasta, string freqI, string freqF, string span, string nome, int numMarkers)
        {
            for (int i = 1; i <= numMarkers; i++)
            {
                double markerX = 1;
                double oldY = 1;
                double markerY = 1;
                double New_markerX = 0;
                double New_markerY = 0;
                while (markerY != New_markerY && markerX != New_markerX)
                {
                    markerX = New_markerX;
                    markerY = New_markerY;
                    if (i == 1)
                    {
                        instr.WriteString($"CALC1:MARK{i}:MAX"); //  Definindo o marker para o Peak search
                        instr.WriteString($"CALC1:MARK{i}:X?");
                        New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        instr.WriteString($"CALC1:MARK{i}:Y?");
                        New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    }
                    else
                    {
                        oldY = New_markerY;
                        instr.WriteString($"CALC:MARK{i}:MODE DELT");
                        instr.WriteString($"CALC:MARK{i}:REF 1");
                        instr.WriteString($"CALC1:MARK{i}:MAX:NEXT");
                        instr.WriteString($"CALC1:MARK{i}:X?");
                        New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        instr.WriteString($"CALC1:MARK{i}:Y?");
                        New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    }
                    
                }
                if (MesmaPosicao(instr, i))
                {
                    SalvaMarkers(nomeArquivo, nomePasta, New_markerX, New_markerY, freqI, nome);

                }
                else
                {
                    while (markerY != New_markerY && markerX != New_markerX)
                    {
                        markerX = New_markerX;
                        markerY = New_markerY;
                        instr.WriteString($"CALC{i}:MARK{i}:MAX"); //  Definindo o marker para o Peak search
                        instr.WriteString($"CALC1:MARK{i}:X?");
                        New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        instr.WriteString($"CALC1:MARK{i}:Y?");
                        New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        Thread.Sleep(10000);
                    }
                    if (Convert.ToUInt32(freqI) < Convert.ToUInt32(configFreq))
                    {
                        New_markerX -= (Convert.ToUInt32(span) * 1000000);
                    }
                    else
                    {
                        New_markerX += (Convert.ToUInt32(span) * 1000000);
                    }
                    SalvaMarkers(nomeArquivo, nomePasta, New_markerX, New_markerY, freqI, nome);

                }
            }


        }
        */
        public static bool MesmaPosicao(FormattedIO488 instr, int i)
        {
            double markerx1, markery1;
            double ultimaPosX;

            instr.WriteString($"CALC1:MARK{i}:X?");
            markerx1 = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
            instr.WriteString($"CALC1:MARK{i}:Y?");
            markery1 = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
            for (int j = 1; j < i; j++)
            {
                if (j == 1)
                {
                    ultimaPosX = 0;
                }
                else
                {
                    instr.WriteString($"CALC1:MARK{j}:X?");
                    ultimaPosX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                }
                
                if (ultimaPosX == markerx1)
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool Pega_Salva_Marker(FormattedIO488 instr, string nomeArquivo, string nomePasta, string freqC, string trace, string nome, int numMarkers)
        {
            for (int i = 1; i <= numMarkers; i++)
            {
                double markerX = 1;
                double markerY = 1;
                double New_markerX = 0;
                double New_markerY = 0;
                if (i == 1)
                {
                    while (markerY != New_markerY && markerX != New_markerX)
                    {
                        markerX = New_markerX;
                        markerY = New_markerY;
                        instr.WriteString($"CALC{i}:MARK{i}:MAX"); //  Definindo o marker para o Peak search
                        instr.WriteString($"CALC1:MARK{i}:X?");
                        New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        instr.WriteString($"CALC1:MARK{i}:Y?");
                        New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        Thread.Sleep(10000);
                    }
                    SalvaMarkers(nomeArquivo, nomePasta, New_markerX / 1000, New_markerY, freqC, nome);
                }
                else
                {
                    while (markerY != New_markerY && markerX != New_markerX)
                    {
                        markerX = New_markerX;
                        markerY = New_markerY;
                        instr.WriteString($"CALC{i}:MARK{i} ON");
                        instr.WriteString($"CALC{i}:MARK{i}:REF 1");
                        instr.WriteString($"CALC1:MARK{i}:X?");
                        New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        instr.WriteString($"CALC1:MARK{i}:Y?");
                        New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        Thread.Sleep(10000);
                    }
                    //if (!MesmaPosicao(instr, i, 0 ,0))
                 //  {
                      //  SalvaMarkers(nomeArquivo, nomePasta, New_markerX, New_markerY, freqC, nome);
                      //  return true;
                   // }
                   // else
                   // {
                        return false;
                   // }
                }

            }
            return true;


        }

        public class NetworkShareAccesser : IDisposable
        {
            private string _remoteUncName;
            private string _remoteComputerName;

            public string RemoteComputerName
            {
                get
                {
                    return this._remoteComputerName;
                }
                set
                {
                    this._remoteComputerName = value;
                    this._remoteUncName = @"\\" + this._remoteComputerName;
                }
            }

            public string UserName
            {
                get;
                set;
            }
            public string Password
            {
                get;
                set;
            }

            #region Consts

            private const int RESOURCE_CONNECTED = 0x00000001;
            private const int RESOURCE_GLOBALNET = 0x00000002;
            private const int RESOURCE_REMEMBERED = 0x00000003;

            private const int RESOURCETYPE_ANY = 0x00000000;
            private const int RESOURCETYPE_DISK = 0x00000001;
            private const int RESOURCETYPE_PRINT = 0x00000002;

            private const int RESOURCEDISPLAYTYPE_GENERIC = 0x00000000;
            private const int RESOURCEDISPLAYTYPE_DOMAIN = 0x00000001;
            private const int RESOURCEDISPLAYTYPE_SERVER = 0x00000002;
            private const int RESOURCEDISPLAYTYPE_SHARE = 0x00000003;
            private const int RESOURCEDISPLAYTYPE_FILE = 0x00000004;
            private const int RESOURCEDISPLAYTYPE_GROUP = 0x00000005;

            private const int RESOURCEUSAGE_CONNECTABLE = 0x00000001;
            private const int RESOURCEUSAGE_CONTAINER = 0x00000002;


            private const int CONNECT_INTERACTIVE = 0x00000008;
            private const int CONNECT_PROMPT = 0x00000010;
            private const int CONNECT_REDIRECT = 0x00000080;
            private const int CONNECT_UPDATE_PROFILE = 0x00000001;
            private const int CONNECT_COMMANDLINE = 0x00000800;
            private const int CONNECT_CMD_SAVECRED = 0x00001000;

            private const int CONNECT_LOCALDRIVE = 0x00000100;

            #endregion

            #region Errors

            private const int NO_ERROR = 0;

            private const int ERROR_ACCESS_DENIED = 5;
            private const int ERROR_ALREADY_ASSIGNED = 85;
            private const int ERROR_BAD_DEVICE = 1200;
            private const int ERROR_BAD_NET_NAME = 67;
            private const int ERROR_BAD_PROVIDER = 1204;
            private const int ERROR_CANCELLED = 1223;
            private const int ERROR_EXTENDED_ERROR = 1208;
            private const int ERROR_INVALID_ADDRESS = 487;
            private const int ERROR_INVALID_PARAMETER = 87;
            private const int ERROR_INVALID_PASSWORD = 1216;
            private const int ERROR_MORE_DATA = 234;
            private const int ERROR_NO_MORE_ITEMS = 259;
            private const int ERROR_NO_NET_OR_BAD_PATH = 1203;
            private const int ERROR_NO_NETWORK = 1222;

            private const int ERROR_BAD_PROFILE = 1206;
            private const int ERROR_CANNOT_OPEN_PROFILE = 1205;
            private const int ERROR_DEVICE_IN_USE = 2404;
            private const int ERROR_NOT_CONNECTED = 2250;
            private const int ERROR_OPEN_FILES = 2401;

            #endregion

            #region PInvoke Signatures

            [DllImport("Mpr.dll")]
            private static extern int WNetUseConnection(
                IntPtr hwndOwner,
                NETRESOURCE lpNetResource,
                string lpPassword,
                string lpUserID,
                int dwFlags,
                string lpAccessName,
                string lpBufferSize,
                string lpResult
                );

            [DllImport("Mpr.dll")]
            private static extern int WNetCancelConnection2(
                string lpName,
                int dwFlags,
                bool fForce
                );

            [StructLayout(LayoutKind.Sequential)]
            private class NETRESOURCE
            {
                public int dwScope = 0;
                public int dwType = 0;
                public int dwDisplayType = 0;
                public int dwUsage = 0;
                public string lpLocalName = "";
                public string lpRemoteName = "";
                public string lpComment = "";
                public string lpProvider = "";
            }

            #endregion

            /// <summary>
            /// Creates a NetworkShareAccesser for the given computer name. The user will be promted to enter credentials
            /// </summary>
            /// <param name="remoteComputerName"></param>
            /// <returns></returns>
            public static NetworkShareAccesser Access(string remoteComputerName)
            {
                return new NetworkShareAccesser(remoteComputerName);
            }

            /// <summary>
            /// Creates a NetworkShareAccesser for the given computer name using the given domain/computer name, username and password
            /// </summary>
            /// <param name="remoteComputerName"></param>
            /// <param name="domainOrComuterName"></param>
            /// <param name="userName"></param>
            /// <param name="password"></param>
            public static NetworkShareAccesser Access(string remoteComputerName, string domainOrComuterName, string userName, string password)
            {
                return new NetworkShareAccesser(remoteComputerName,
                                                domainOrComuterName + @"\" + userName,
                                                password);
            }

            /// <summary>
            /// Creates a NetworkShareAccesser for the given computer name using the given username (format: domainOrComputername\Username) and password
            /// </summary>
            /// <param name="remoteComputerName"></param>
            /// <param name="userName"></param>
            /// <param name="password"></param>
            public static NetworkShareAccesser Access(string remoteComputerName, string userName, string password)
            {
                return new NetworkShareAccesser(remoteComputerName,
                                                userName,
                                                password);
            }

            private NetworkShareAccesser(string remoteComputerName)
            {
                RemoteComputerName = remoteComputerName;

                this.ConnectToShare(this._remoteUncName, null, null, true);
            }

            private NetworkShareAccesser(string remoteComputerName, string userName, string password)
            {
                RemoteComputerName = remoteComputerName;
                UserName = userName;
                Password = password;

                this.ConnectToShare(this._remoteUncName, this.UserName, this.Password, false);
            }

            private void ConnectToShare(string remoteUnc, string username, string password, bool promptUser)
            {
                NETRESOURCE nr = new NETRESOURCE
                {
                    dwType = RESOURCETYPE_DISK,
                    lpRemoteName = remoteUnc
                };

                int result;
                if (promptUser)
                {
                    result = WNetUseConnection(IntPtr.Zero, nr, "", "", CONNECT_INTERACTIVE | CONNECT_PROMPT, null, null, null);
                }
                else
                {
                    result = WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null);
                }
                if (result != 1219)
                {
                    if (result != NO_ERROR)
                    {
                        throw new Win32Exception(result);
                    }
                }
            }

            private void DisconnectFromShare(string remoteUnc)
            {
                int result = WNetCancelConnection2(remoteUnc, CONNECT_UPDATE_PROFILE, false);
                if (result != NO_ERROR && result != 2250)
                {
                    throw new Win32Exception(result);
                }
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            /// <filterpriority>2</filterpriority>
            public void Dispose()
            {
                this.DisconnectFromShare(this._remoteUncName);
            }
        }
    }
}
