// RsInstrument Exemplos para Analisadores de Espectro
// Procedimentos:
// - Instalar Rohde & Schwarz VISA 5.12.3+ pelo link https://www.rohde-schwarz.com/appnote/1dc02


using System;
using MatheusProductions.keysight;
using RohdeSchwarz.RsInstrument; // Biblioteca que providencia os comandos. Procure ela no www.nuget.org
using Ivi.Visa.Interop;
using System.Threading;





namespace MatheusProductions.AutomacaoN9010A
{

    public class AutomacaoN9010A
    {
        Keysight radical;
        ResourceManager rm;
        FormattedIO488 instr;

        public bool ConectaIP(string ip)
        {
            
            radical = new Keysight();
            rm = new ResourceManager();
            instr = new FormattedIO488();


            return radical.Inicializacao(instr, rm, ip);
        }


        public void Largura_6dB(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints)
        {
            ConectaIP(ip);

            string nomePasta = @"\\A-N9010A-00151\prints\Largura 6";
      

            try 
            {
                instr.WriteString("*RST;*CLS"); 
                instr.WriteString("INIT:CONT ON"); 
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                radical.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-6");
                instr.IO.Timeout = 2000; 
                instr.WriteString("INIT");
                Thread.Sleep(5000);
                instr.WriteString("INIT:CONT OFF");
                radical.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                instr.WriteString("FETC:OBW:XDB?");
                double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                aux /= 1000;
                string val = Convert.ToString(aux);
                radical.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
                // -----------------------------------------------------------
                // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                // -----------------------------------------------------------
                //radical.SalvaPrints(instr, nomePasta, nomePrint);
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Largura_26dB(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints)
        {

            ConectaIP(ip);

            string nomePasta = @"\\A-N9010A-00151\prints\Largura 26";


            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                radical.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-26");
                instr.IO.Timeout = 5000;
                instr.WriteString("INIT");
                string nomeArquivo = "Valores do ensaio.csv";
                Thread.Sleep(5000);
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("FETC:OBW:XDB?");
                double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                aux /= 1000;
                string val = Convert.ToString(aux);
                Thread.Sleep(5000);
                radical.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                // -----------------------------------------------------------
                // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                // -----------------------------------------------------------
                radical.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void Pico_da_densidade_de_potência(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints)
        {

            ConectaIP(ip);

            // Nome da pasta que vai salvar os valores.
            string nomePasta = @"\\A-N9010A-00151\prints\Pico da densidade de potencia";

            //"TCPIP0::192.168.1.100::hislip0::INSTR";

            try // Try o bloco para capturar qualquer RsInstrumentException()
            {
                instr.WriteString("*RST;*CLS"); // Reinicialize o instrumento, limpe a fila de erros
                instr.WriteString("INIT:CONT ON"); // Desliga a varredura contínua
                instr.WriteString("DISP:ENAB ON"); // Display update ON - Desligar após a depuração              
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                radical.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "MAXH", "POS", "SAN");                
                instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                instr.WriteString("INIT"); // Comece a varredura
                //Salvando os Valores do Marker
                //Cria uma variavel com o nome do arquivo que quer criar
                string nomeArquivo = "Valores do ensaio.csv";
                instr.WriteString("INIT:CONT OFF");
                radical.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                radical.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Valor_médio_da_densidade_espectral_de_potência(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints)
        {

            ConectaIP(ip);

            string nomePasta = @"\\A-N9010A-00151\prints\Valor Medio Densidade Espectral";

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas

                double Span = int.Parse(largura_Banda) * 1.5;
                radical.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "AVER", "RMS", "SAN");
                instr.IO.Timeout = 2000;
                instr.WriteString("INIT");
                instr.WriteString("SWE:TIME?");
                double tempo = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                Thread.Sleep(15000);
                instr.WriteString("INIT:CONT OFF");
                Thread.Sleep((int)tempo * 1000);
                string nomeArquivo = "Valores do ensaio.csv";
                //Salvando os Valores do Marker
                //Cria uma variavel com o nome do arquivo que quer criar
                radical.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                // -----------------------------------------------------------
                // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                // -----------------------------------------------------------
                radical.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);

            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Potência_de_pico_máxima(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints)
        {
            ConectaIP(ip);

            string nomePasta = @"\\A-N9010A-00151\prints\Potência_de_pico_máxima";

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                // OBS: Será usado para ensaio o valor minimo permitido pela norma de acordo com o Item 9.1.8 (Opção 3) da 6506
                radical.ConfiguraInstr(instr, valFreq, "Dbm",Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "POS", "CHP", largura_Banda);
                instr.IO.Timeout = 2000;
                instr.WriteString("INIT");
                string nomeArquivo = "Valores do ensaio.csv";
                //Pega os Valores
                Thread.Sleep(5000);
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("FETC:CHP:CHP?");
                double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                aux /= 1000;
                string val = Convert.ToString(aux);
                radical.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                // -----------------------------------------------------------
                // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                // -----------------------------------------------------------
                radical.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);

            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Valor_médio_da_potência_máxima_de_saída(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints)
        {
            
            ConectaIP(ip);

            string nomePasta = @"\\A-N9010A-00151\prints\Valor Médio da Potência Máxima De Saída";

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                // OBS: Será usado para ensaio o valor minimo permitido pela norma de acordo com o Item 9.1.8 (Opção 3) da 6506
                radical.ConfiguraInstr(instr, valFreq, "Dbm",Att,RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "RMS", "CHP", largura_Banda);
                instr.IO.Timeout = 2000;
                instr.WriteString("INIT");
                string nomeArquivo = "Valores do ensaio.csv";
                //Pega os Valores
                Thread.Sleep(5000);
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("FETC:CHP:CHP?");
                double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                aux /= 1000;
                string val = Convert.ToString(aux);
                radical.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                // -----------------------------------------------------------
                // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                // -----------------------------------------------------------
                radical.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);

            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Potencia_De_Saida(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints)
        {
            ConectaIP(ip);

            string nomePasta = @"\\A-N9010A-00151\prints\Potencia de Saida";


            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                radical.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-26");
                instr.IO.Timeout = 2000;
                instr.WriteString("INIT");
                Thread.Sleep(5000);
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("FETC:OBW:XDB?");
                double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                aux /= 1000000;
                string aux1 = Convert.ToString(aux);
                radical.ConfiguraInstr(instr, valFreq, "DBM", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "CHP", aux1);
                instr.WriteString("INIT");
                Thread.Sleep(10000);
                instr.WriteString("INIT:CONT OFF");
                instr.WriteString("FETC:CHP:CHP?");
                double aux2 = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                aux2 /= 1000;
                string val = Convert.ToString(aux2);
                radical.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                radical.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
                // -----------------------------------------------------------
                // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                // -----------------------------------------------------------
                //radical.SalvaPrints(instr, nomePasta, nomePrint);
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Densidade_Espectral_de_Potencia(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints)
        {
            ConectaIP(ip);

            string nomePasta = @"\\A-N9010A-00151\prints\Densidade_Espectral_de_Potencia";


            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                radical.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "SAN");
                instr.WriteString("SWE:TIME?");
                double tempo = (double)instr.ReadNumber();
                Thread.Sleep(15000);
                instr.WriteString("INIT:CONT OFF");
                Thread.Sleep((int)tempo * 1000);
                string nomeArquivo = "Valores do ensaio.csv";
                //Salvando os Valores do Marker
                //Cria uma variavel com o nome do arquivo que quer criar
                radical.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                // -----------------------------------------------------------
                // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                // -----------------------------------------------------------
                radical.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}