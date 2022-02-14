using System;
using System.Threading;
using System.IO;
using RohdeSchwarz.RsInstrument; // Biblioteca que providencia os comandos. Procure ela no www.nuget.org
using Ivi.Visa.Interop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatheusProductions.RodheLib
{
    public class Rodhe
    {

        public void SalvaPrints(FormattedIO488 instr, string nomePasta, string nomePrint, bool tPrints, string tipoImagem)
        {

            if (tPrints)
            {
                nomePasta = nomePasta + @"\" + nomePrint;
                instr.WriteString(@$"HCOP:DEV:LANG {tipoImagem}"); // Faça a captura de tela
                instr.WriteString(@$"HCOP:DEST MMEM"); // Faça a captura de tela
                instr.WriteString(@$"MMEM:NAME '{nomePasta}'"); // Faça a captura de tela
                instr.WriteString(@$"HCOP"); // Faça a captura de tela
            }

        }

        public void CriaPasta(string nomePasta, string nomeSubPasta = "")
        {
            //---------------------------------------------------------------
            //Cria Uma pasta para salvar os valores
            //---------------------------------------------------------------

            // 
            // Adicionando o nome Valores do Marker dentro da variavel Nome Pasta
            nomePasta = System.IO.Path.Combine(nomePasta, nomeSubPasta);

            //Cria pasta
            System.IO.Directory.CreateDirectory(nomePasta);

            // Verifica o Caminho
        }

        public FileStream CriaArquivo(string nomeArquivo, string nomePasta = "")
        {
            nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);

            return File.Create(nomePasta);
        }

        public bool Inicializacao(FormattedIO488 instr, ResourceManager rm, string ip)
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
            catch (RsInstrumentException e)
            {
                Console.WriteLine($"Erro ao inicializar a sessão do instrumento:\n{e.Message}");
                Console.WriteLine("Pressione qualquer tecla para sair.");
                Console.ReadKey();
                return false;
            }
        }

        public void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo)
        {
                instr.WriteString($"INST:SEL {modo}"); // Seleciona o modo
                instr.WriteString($"CALC:UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
                instr.WriteString($"INP:ATT {att} dB"); //Configura o ATT
                instr.WriteString($"DISP:TRAC:Y:RLEV {refL} dbm"); // Configura o Reference Level
                instr.WriteString($"FREQ:CENT {freqC} Mhz"); // Configura a Frequencia Central
                instr.WriteString($"FREQ:SPAN {span} MHz"); // Configura o span
                instr.WriteString($"BAND {rbw} kHz"); // Configura o RBW
                instr.WriteString($"BAND:VID {vbw} kHz"); // Configura o VBW
                instr.WriteString($"SWE:TIME:AUTO {sweepAuto}"); // Configura o sweep points
                instr.WriteString($"DISP:TRAC:MODE {trace}"); //Configura o Trace
                instr.WriteString($"DET {detector}"); //Configura o Trace
        }


        public void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string larguraDeBanda, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo, string integBW)
        {
            double aux = Convert.ToInt32(larguraDeBanda);
            double auxSpan = aux * 1.5;
            double auxCanalA = aux / 2;
            string span = Convert.ToString(auxSpan);
            string canalA = Convert.ToString(auxCanalA);
            //Channel Power
            instr.WriteString($"INST:SEL {modo}"); // Seleciona o modo
            instr.WriteString($"CALC:MARK:FUNC:POW:SEL {modo}"); // Seleciona o modo
            instr.WriteString($"CHP:BAND:INT {integBW} Mhz"); // Configura a largura de banda
            instr.WriteString($"CALC:UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
            instr.WriteString($"INP:ATT {att} dB"); //Configura o ATT
            instr.WriteString($"DISP:TRAC:Y:RLEV {refL} dbm"); // Configura o Reference Level
            instr.WriteString($"FREQ:CENT {freqC} Mhz"); // Configura a Frequencia Central
            instr.WriteString($"FREQ:SPAN {span} Mhz"); // Configura o span
            instr.WriteString($"SENS:POW:ACH:BAND {larguraDeBanda} Mhz"); // Configura o span
            instr.WriteString($"SENS:POW:ACH:BAND:ACH {canalA} Mhz"); // Configura o span
            instr.WriteString($"BAND {rbw} kHz"); // Configura o RBW
            instr.WriteString($"BAND:VID {vbw} kHz"); // Configura o VBW
            instr.WriteString($"SWE:TIME:AUTO {sweepAuto}"); // Configura o sweep points
            instr.WriteString($"DISP:TRAC:MODE {trace}"); //Configura o Trace
            instr.WriteString($"DET {detector}"); //Configura o Trace

        }



        public void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo, string porc_Ocu, string qDbs)
        {
            //OBW
            instr.WriteString($"INST:SEL {modo}"); // Seleciona o modo
            instr.WriteString($"CALC:MARK1:FUNC:NDBD:STAT ON"); // Seleciona o modo
            instr.WriteString($"CALC:MARK1:FUNC:NDBD {qDbs} DB"); // Seleciona a distancia (6/26) db de Occupied Bandwidth Measurement
            instr.WriteString($"CALC:UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
            instr.WriteString($"INP:ATT {att} dB"); //Configura o ATT
            instr.WriteString($"DISP:TRAC:Y:RLEV {refL} dbm"); // Configura o Reference Level
            instr.WriteString($"FREQ:CENT {freqC} Mhz"); // Configura a Frequencia Central
            instr.WriteString($"FREQ:SPAN {span} Mhz"); // Configura o span
            instr.WriteString($"BAND {rbw} kHz"); // Configura o RBW
            instr.WriteString($"BAND:VID {vbw} kHz"); // Configura o VBW
            instr.WriteString($"SWE:TIME:AUTO {sweepAuto}"); // Configura o sweep points
            instr.WriteString($"DISP:TRAC:MODE {trace}"); //Configura o Trace
            instr.WriteString($"DET {detector}"); //Configura o Trace
        }

        public void ConfiguraInstrSalto(FormattedIO488 instr, string freqI, string freqF, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo)
        {
            
            instr.WriteString($"INST:SEL {modo}"); // Seleciona o modo
            instr.WriteString($"CALC:UNIT:POW {unidadeY}"); //Configura a unidade do reference Level
            instr.WriteString($"INP:ATT {att} dB"); //Configura o ATT
            instr.WriteString($"DISP:TRAC:Y:RLEV {refL} dbm"); // Configura o Reference Level
            instr.WriteString($"FREQ:STAR {freqI} Mhz"); // Configura a Frequencia Inicial
            instr.WriteString($"FREQ:STOP {freqF} Mhz"); // Configura a Frequencia Final
            instr.WriteString($"FREQ:SPAN {span} MHz"); // Configura o span
            instr.WriteString($"BAND {rbw} kHz"); // Configura o RBW
            instr.WriteString($"BAND:VID {vbw} kHz"); // Configura o VBW
            instr.WriteString($"SWE:TIME:AUTO {sweepAuto}"); // Configura o sweep points
            instr.WriteString($"TRAC:MODE {trace}"); //Configura o Trace
            instr.WriteString($"DET {detector}"); //Configura o Trace

        }

        public void SalvaMarkers(string nomeArquivo, string nomePasta, double markerX, double markerY, string freqC, string nome)
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

        public void SalvaValores(string nomeArquivo, string nomePasta, string valor, string freqC, string nome)
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

        public void SalvaValores(string nomeArquivo, string nomePasta, double valor, double valor2, string freqC, string nome)
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

        public void pegaMarker(FormattedIO488 instr, string trace = "MAXH")
        {
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
                while (markerY != New_markerY)
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
        }

        public void Pega_Salva_Marker(FormattedIO488 instr, string nomeArquivo, string nomePasta, string freqC, string trace, string nome)
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
                while (markerY != New_markerY)
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
            SalvaMarkers(nomeArquivo, nomePasta, New_markerX / 1000, New_markerY / 1000, freqC, nome);

            
        }

        public void AchaSinalZeroSpan(FormattedIO488 instr)
        {
            double markerX = 0;
            double markerY = 0;
            while (markerY < -10)
            {
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("CALC1:MARK1:MAX"); //  Definindo o marker para o Peak search
                instr.WriteString("CALC1:MARK1:X?");
                markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                instr.WriteString("CALC1:MARK1:Y?");
                markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                Thread.Sleep(500);
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("*WAI");
            }

        }





        public void Pega_Salva_Marker(FormattedIO488 instr, string nomeArquivo, string nomePasta, string freqC, string trace, string nome, int numMarkers)
        {

            double markerX = 1;
            double oldY = 0;
            double markerY = 1;
            double New_markerX = 0;
            double New_markerY = 0;
            for (int i = 0; i < numMarkers; i++)
            {
                while (markerY != New_markerY)
                {
                    markerX = New_markerX;
                    markerY = New_markerY;
                    if (New_markerY != oldY)
                    {
                        instr.WriteString($"CALC1:MARK{i}:MAX"); //  Definindo o marker para o Peak search
                        instr.WriteString($"CALC1:MARK{i}:X?");
                        New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        instr.WriteString($"CALC1:MARK{i}:Y?");
                        New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    }
                    else
                    {
                        instr.WriteString($"CALC1:DELT{i}:MAX:NEXT");
                        instr.WriteString($"CALC1:DELT{i}:X?");
                        New_markerX = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                        instr.WriteString($"CALC1:DELT{i}:Y?");
                        New_markerY = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    }
                    oldY = New_markerY;
                    Thread.Sleep(10000);
                }
                SalvaMarkers(nomeArquivo, nomePasta, New_markerX / 1000, New_markerY / 1000, freqC, nome);
            }


        }

    
    }
}
