// RsInstrument Exemplos para Analisadores de Espectro
// Procedimentos:
// - Instalar Rohde & Schwarz VISA 5.12.3+ pelo link https://www.rohde-schwarz.com/appnote/1dc02


using System;
using MatheusProductions.KeysightLib;
using MatheusProductions.RodheLib;
using RohdeSchwarz.RsInstrument; // Biblioteca que providencia os comandos. Procure ela no www.nuget.org
using Ivi.Visa.Interop;
using System.Threading;





namespace MatheusProductions.AutomacaoN9010A
{

    public class AutomacaoN9010A
    {
        Keysight radicalKeysigth;
        Rodhe radicalRodhe;
        ResourceManager rm;
        FormattedIO488 instr;

        public bool ConectaIP(string ip)
        {
            
            radicalKeysigth = new Keysight();
            radicalRodhe = new Rodhe();
            rm = new ResourceManager();
            instr = new FormattedIO488();


            return radicalKeysigth.Inicializacao(instr, rm, ip);
        }

        public void Largura_6dB(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {
            ConectaIP(ip);

            
      

            try 
            {
                instr.WriteString("*RST;*CLS"); 
                instr.WriteString("INIT:CONT ON"); 
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Largura 6";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-6");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                    instr.WriteString("FETC:OBW:XDB?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    radicalKeysigth.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Largura 6";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "6");
                    radicalRodhe.pegaMarker(instr);
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                    instr.WriteString("CALC:MARK1:FUNC:NDBD:RES?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    radicalRodhe.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
                }
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Largura_20dB(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {

            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Largura 20";
                    string nomeArquivo = "Valores do ensaio.csv";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "30", "100", "ON", "MAXH", "POS", "OBW", "99", "-20");
                    instr.IO.Timeout = 5000;
                    instr.WriteString("INIT");
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:OBW:XDB?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Thread.Sleep(5000);
                    radicalKeysigth.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Largura 20";
                    string nomeArquivo = "Valores do ensaio.csv";
                    radicalRodhe.pegaMarker(instr);
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "30", "100", "ON", "MAXH", "POS", "OBW", "99", "20");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                    instr.WriteString("CALC:MARK1:FUNC:NDBD:RES?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Thread.Sleep(5000);
                    radicalRodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                }
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Separação_Entre_Canais_de_Salto(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, int numMarkers, string marca)
        {

            ConectaIP(ip);

            try
            {   
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Separação Entre Canais de Salto";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(15000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    instr.WriteString("INIT:CONT OFF");
                    radicalKeysigth.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome, numMarkers);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Separação Entre Canais de Salto";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "SAN", marca);
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(15000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    instr.WriteString("INIT:CONT OFF");
                    radicalRodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome, numMarkers);
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                

            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Numero_De_Frequencia_de_Salto(string valFreqI, string valFreqF, string valFreqI2, string valFreqF2, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, int numMarkers, string marca)
        {

            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Numero De Frequencia de Salto";
                    radicalKeysigth.ConfiguraInstrSalto(instr, valFreqI, valFreqF, "Dbm", Att, RefLevel, Span.ToString(), "100", "100", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints);
                    radicalKeysigth.ConfiguraInstrSalto(instr, valFreqI2, valFreqF2, "Dbm", Att, RefLevel, Span.ToString(), "100", "100", "ON", "MAXH", "POS", "SAN");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Numero De Frequencia de Salto";
                    radicalKeysigth.ConfiguraInstrSalto(instr, valFreqI, valFreqF, "Dbm", Att, RefLevel, Span.ToString(), "100", "100", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints, "WMF");
                    radicalRodhe.ConfiguraInstrSalto(instr, valFreqI2, valFreqF2, "Dbm", Att, RefLevel, Span.ToString(), "100", "100", "ON", "MAXH", "POS", "SAN");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints, "WMF");
                }
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Largura_26dB(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {

            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Largura 26";
                    string nomeArquivo = "Valores do ensaio.csv";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-26");
                    instr.IO.Timeout = 5000;
                    instr.WriteString("INIT");
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:OBW:XDB?");
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Largura 26";
                    string nomeArquivo = "Valores do ensaio.csv";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "26");
                    radicalRodhe.pegaMarker(instr);
                    instr.IO.Timeout = 5000;
                    instr.WriteString("INIT");
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK1:FUNC:NDBD:RES?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                    radicalRodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);

                }


            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Tempo_de_Ocupação(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {

            ConectaIP(ip);

            // Nome da pasta que vai salvar os valores.
            

            //"TCPIP0::192.168.1.100::hislip0::INSTR";

            try // Try o bloco para capturar qualquer RsInstrumentException()
            {
                instr.WriteString("*RST;*CLS"); // Reinicialize o instrumento, limpe a fila de erros
                instr.WriteString("INIT:CONT ON"); // Desliga a varredura contínua
                instr.WriteString("DISP:ENAB ON"); // Display update ON - Desligar após a depuração              
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Tempo de Ocupação";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "1000", "ON", "MAXH", "POS", "SAN", marca);
                    instr.WriteString("FREQ:SPAN 0");
                    radicalKeysigth.AchaSinalZeroSpan(instr);
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    string nomeArquivo = "Valores do ensaio.csv";
                    instr.WriteString("INIT:CONT OFF");
                    radicalKeysigth.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Tempo de Ocupação";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "1000", "ON", "MAXH", "POS", "SAN", marca);
                    instr.WriteString("FREQ:SPAN 0");
                    radicalKeysigth.AchaSinalZeroSpan(instr);
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    string nomeArquivo = "Valores do ensaio.csv";
                    instr.WriteString("INIT:CONT OFF");
                    radicalRodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Pico_da_densidade_de_potência(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {

            ConectaIP(ip);
           
            //"TCPIP0::192.168.1.100::hislip0::INSTR";

            try // Try o bloco para capturar qualquer RsInstrumentException()
            {
                instr.WriteString("*RST;*CLS"); // Reinicialize o instrumento, limpe a fila de erros
                instr.WriteString("INIT:CONT ON"); // Desliga a varredura contínua
                instr.WriteString("DISP:ENAB ON"); // Display update ON - Desligar após a depuração              
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Pico da densidade de potencia";
                    string nomeArquivo = "Valores do ensaio.csv";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "MAXH", "POS", "SAN", marca);
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    instr.WriteString("INIT:CONT OFF");
                    radicalKeysigth.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Pico da densidade de potencia";
                    string nomeArquivo = "Valores do ensaio.csv";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "MAXH", "POS", "SAN", marca);
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    instr.WriteString("INIT:CONT OFF");
                    radicalRodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Valor_médio_da_densidade_espectral_de_potência(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {

            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas

                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Valor Medio Densidade Espectral";
                    string nomeArquivo = "Valores do ensaio.csv";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "AVER", "RMS", "SAN", marca);
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    instr.WriteString("SWE:TIME?");
                    double tempo = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Thread.Sleep((int)tempo * 1000);
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    radicalKeysigth.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Valor Medio Densidade Espectral";
                    string nomeArquivo = "Valores do ensaio.csv";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "AVER", "RMS", "SAN", marca);
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    instr.WriteString("SWE:TIME?");
                    double tempo = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Thread.Sleep((int)tempo * 1000);
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    radicalRodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                

            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Potência_de_pico_máxima(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {
            ConectaIP(ip);

            

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Potência_de_pico_máxima";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "POS", "CHP", largura_Banda);
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
                    radicalKeysigth.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Potência_de_pico_máxima";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "POS", "CHP", largura_Banda);
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Pega os Valores
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK:FUNC:POW:RES? ACP");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    radicalRodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                // OBS: Será usado para ensaio o valor minimo permitido pela norma de acordo com o Item 9.1.8 (Opção 3) da 6506
                

            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Valor_médio_da_potência_máxima_de_saída(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {
            
            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Valor Médio da Potência Máxima De Saída";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "RMS", "CHP", largura_Banda);
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
                    radicalKeysigth.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Valor Médio da Potência Máxima De Saída";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "RMS", "CHP", largura_Banda);
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Pega os Valores
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK:FUNC:POW:RES? ACP");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    radicalRodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                // OBS: Será usado para ensaio o valor minimo permitido pela norma de acordo com o Item 9.1.8 (Opção 3) da 6506
                

            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Potencia_De_Saida(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {
            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Potencia de Saida";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-26");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:OBW:XDB?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000000;
                    string aux1 = Convert.ToString(aux);
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "DBM", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "CHP", aux1);
                    instr.WriteString("INIT");
                    Thread.Sleep(10000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:CHP:CHP?");
                    double aux2 = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux2 /= 1000;
                    string val = Convert.ToString(aux2);
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                    radicalKeysigth.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Potencia de Saida";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-26");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(5000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK1:FUNC:NDBD:RES?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000000;
                    string aux1 = Convert.ToString(aux);
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "DBM", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "CHP", aux1);
                    instr.WriteString("INIT");
                    Thread.Sleep(10000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK:FUNC:POW:RES?");
                    double aux2 = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux2 /= 1000;
                    string val = Convert.ToString(aux2);
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                    radicalRodhe.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
                }
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Densidade_Espectral_de_Potencia(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {
            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Densidade_Espectral_de_Potencia";
                    radicalKeysigth.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "SAN");
                    instr.WriteString("SWE:TIME?");
                    double tempo = (double)instr.ReadNumber();
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Thread.Sleep((int)tempo * 1000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    radicalKeysigth.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    radicalKeysigth.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Densidade_Espectral_de_Potencia";
                    radicalRodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "SAN");
                    instr.WriteString("SWE:TIME?");
                    double tempo = (double)instr.ReadNumber();
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Thread.Sleep((int)tempo * 1000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    radicalRodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    radicalRodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}