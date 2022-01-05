﻿    using System;
    using System.Threading;
    using System.IO;
    using RohdeSchwarz.RsInstrument; // Biblioteca que providencia os comandos. Procure ela no www.nuget.org
    using Ivi.Visa.Interop;


    namespace MatheusProductions.keysight
    {

    public class Keysight
    {
        public void SalvaPrints(FormattedIO488 instr, string nomePasta, string nomePrint)
        {
            nomePasta = nomePasta + @"\" + nomePrint;
            instr.WriteString(@$"MMEM:STOR:SCR '{nomePasta}.PNG'"); // Faça a captura de tela
        }

        public void CriaPasta(string Na, string Np)
        {
            //---------------------------------------------------------------
            //Cria Uma pasta para salvar os valores
            //---------------------------------------------------------------

            // Cria uma subPasta na pasta teste Automação
            // Adicionando o nome Valores do Marker dentro da variavel Nome Pasta
            Np = System.IO.Path.Combine(Na, Np);

            //Cria pasta
            System.IO.Directory.CreateDirectory(Np);

            // Verifica o Caminho
        }

        public void Inicializacao(FormattedIO488 instr, ResourceManager rm, string ip)
        {
            try // Criar um Try-catch separado para inicialização impede o acesso a objetos não inicializados
            {
                //-----------------------------------------------------------
                // Inicialização:
                //-----------------------------------------------------------
                // Ajuste a string de recursos VISA para se adequar ao seu instrumento 
                instr.IO = (IMessage)rm.Open(ip);
                instr.IO.Timeout = 3000; // Tempo limite para operações de leitura VISA
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine($"Erro ao inicializar a sessão do instrumento:\n{e.Message}");
                Console.WriteLine("Pressione qualquer tecla para sair.");
                Console.ReadKey();
                return;
            }
        }

        public void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo)
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

        public void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo, string integBW)
        {
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



        public void ConfiguraInstr(FormattedIO488 instr, string freqC, string unidadeY, string att, string refL, string span, string rbw, string vbw, string sweepAuto, string trace, string detector, string modo, string porc_Ocu, string qDbs)
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

        public void SalvaMarkers(string nomeArquivo, string nomePasta, double markerX, double markerY, string freqC)
        {

            if (!System.IO.File.Exists(nomePasta))
            {
                // Combina o nome do arquivo ao caminho onde ta os prints
                CriaPasta(nomeArquivo, nomePasta);
                nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);
                //Criando o arquivo e adicionando os Valores
                Console.WriteLine("Criando o arquivo \"{0}\" e adicionando os valores", nomeArquivo);
                using (System.IO.FileStream fs = System.IO.File.Create(nomePasta))
                { }
                File.AppendAllText(nomePasta, freqC.ToString() + ";");
                File.AppendAllText(nomePasta, markerX.ToString() + ";");
                File.AppendAllText(nomePasta, markerY.ToString() + "\n");
            }
            else
            {
                Console.WriteLine("O arquivo \"{0}\" Ja existe. Apenas inserindo os valores", nomeArquivo);
                File.AppendAllText(nomePasta, freqC.ToString() + ";");
                File.AppendAllText(nomePasta, markerX.ToString() + ";");
                File.AppendAllText(nomePasta, markerY.ToString() + "\n");
            }
        }

        public void SalvaValores(string nomeArquivo, string nomePasta, string valor, string freqC)
        {
            if (!System.IO.File.Exists(nomePasta))
            {
                // Combina o nome do arquivo ao caminho onde ta os prints
                CriaPasta(nomeArquivo, nomePasta);
                nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);


                //Criando o arquivo e adicionando os Valores
                Console.WriteLine("Criando o arquivo \"{0}\" e adicionando os valores", nomeArquivo);
                using (System.IO.FileStream fs = System.IO.File.Create(nomePasta))
                { }
                File.AppendAllText(nomePasta, freqC.ToString() + ";");
                File.AppendAllText(nomePasta, valor.ToString() + ";");
            }
            else
            {
                Console.WriteLine("O arquivo \"{0}\" Ja existe. Apenas inserindo os valores", nomeArquivo);
                File.AppendAllText(nomePasta, freqC.ToString() + ";");
                File.AppendAllText(nomePasta, valor.ToString() + ";");
            }
        }

        public void SalvaValores(string nomeArquivo, string nomePasta, double valor, double valor2, string freqC)
        {
            if (!System.IO.File.Exists(nomePasta))
            {
                // Combina o nome do arquivo ao caminho onde ta os prints
                CriaPasta(nomeArquivo, nomePasta);
                nomePasta = System.IO.Path.Combine(nomePasta, nomeArquivo);
                //Criando o arquivo e adicionando os Valores
                Console.WriteLine("Criando o arquivo \"{0}\" e adicionando os valores", nomeArquivo);
                using (System.IO.FileStream fs = System.IO.File.Create(nomePasta))
                { }
                File.AppendAllText(nomePasta, freqC.ToString() + ";");
                File.AppendAllText(nomePasta, valor.ToString() + ";");
                File.AppendAllText(nomePasta, valor2.ToString() + ";");
            }
            else
            {
                Console.WriteLine("O arquivo \"{0}\" Ja existe. Apenas inserindo os valores", nomeArquivo);
                File.AppendAllText(nomePasta, freqC.ToString() + ";");
                File.AppendAllText(nomePasta, valor.ToString() + ";");
                File.AppendAllText(nomePasta, valor2.ToString() + ";");
            }
        }

        public void Pega_Salva_Marker(FormattedIO488 instr, string nomeArquivo, string nomePasta, string freqC, string trace)
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
                    New_markerX = (double)instr.ReadNumber();
                    instr.WriteString("CALC1:MARK1:Y?");
                    New_markerY = (double)instr.ReadNumber();
                    Console.WriteLine("Espere 10 segundos.");
                    Thread.Sleep(10000);
                    Console.WriteLine($"Frequencia do Marker  {New_markerX:F3} Hz, Level {New_markerY:F2} dBm");
                }

            }
            else
            {
                instr.WriteString("AVER:COUN?");
                string aux = instr.ReadString();
                Thread.Sleep(3000);
                instr.WriteString("AVER:COUN?");
                aux = instr.ReadString();
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("CALC1:MARK1:MAX"); //  Definindo o marker para o Peak search
                instr.WriteString("CALC1:MARK1:X?");
                New_markerX = (double)instr.ReadNumber();
                instr.WriteString("CALC1:MARK1:Y?");
                New_markerY = (double)instr.ReadNumber();
            }
            SalvaMarkers(nomeArquivo, nomePasta, New_markerX, New_markerY, freqC);
        }
    }
}
