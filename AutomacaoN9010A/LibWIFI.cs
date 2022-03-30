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


        ResourceManager rm;
        FormattedIO488 instr;

        public bool ConectaIP(string ip)
        {
            
            rm = new ResourceManager();
            instr = new FormattedIO488();
            return Keysight.Inicializacao(instr, rm, "TCPIP0::" + ip + "::hislip0::INSTR");
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-6");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                    instr.WriteString("FETC:OBW:XDB?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Keysight.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Largura 6";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "6");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Rodhe.PegaMarker(instr);
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                    instr.WriteString("CALC:MARK1:FUNC:NDBD:RES?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Rodhe.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "30", "100", "ON", "MAXH", "POS", "OBW", "99", "-20");
                    instr.IO.Timeout = 5000;
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:OBW:XDB?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                    Keysight.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Largura 20";
                    string nomeArquivo = "Valores do ensaio.csv";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "30", "100", "ON", "MAXH", "POS", "OBW", "99", "20");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Rodhe.PegaMarker(instr);
                    instr.WriteString("CALC:MARK1:FUNC:NDBD:RES?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                    Rodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                }
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool Separação_Entre_Canais_de_Salto(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, int numMarkers, string marca)
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(20000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    instr.WriteString("INIT:CONT OFF");
                    if (Keysight.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome, numMarkers))
                    {
                        Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Separação Entre Canais de Salto";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "SAN");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(20000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    instr.WriteString("INIT:CONT OFF");
                    if (Rodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, nome, numMarkers))
                    {
                        Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                

            }
            catch (RsInstrumentException e)
            {
                
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /*
        public void TempoDeOcupacao(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {

            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                double span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Numero De Frequencia de Salto";
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, span.ToString(), "1000", "1000", "ON", "WRIT", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    string nomeArquivo = "Valores do ensaio.csv";
                    double potenciaMarker = 0;
                    while (potenciaMarker < -10 )
                    {
                        instr.WriteString("CALC:MARK:AOFF");
                        instr.WriteString("INIT:CONT ON");
                        Thread.Sleep(1000);
                        instr.WriteString("INIT:OFF");
                        potenciaMarker = Keysight.MedeMarker(instr);
                    }
                    Keysight.Pega_Salva_MarkerTempodeOcupação(instr, nomeArquivo, nomePasta, valFreq, nome );
                    Thread.Sleep(15000);
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Numero De Frequencia de Salto";
                    Keysight.ConfiguraInstrSalto(instr, valFreqI, valFreqM, "Dbm", Att, RefLevel, "100", "100", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints, "WMF");
                    Rodhe.ConfiguraInstrSalto(instr, valFreqM, valFreqF, "Dbm", Att, RefLevel, "100", "100", "ON", "MAXH", "POS", "SAN");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints, "WMF");
                }
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        */


        public void TiraPrint(string valFreq, string ip,string nome, bool tPrints, string marca)
        {
            ConectaIP(ip);
            if (marca == "Agilent")
            {
                Keysight.SalvaPrints(instr, @"\\A-N9010A-00151\prints\Separação Entre Canais de Salto", nome + " " + valFreq, tPrints);
            }
            else
            {
                Rodhe.SalvaPrints(instr, @"\\A-N9010A-00151\prints\Separação Entre Canais de Salto", nome + " " + valFreq, tPrints, "WMF");
            }
            
        }

        public bool Separação_Entre_Canais_de_SaltoPIe8(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, int numMarkers, string marca)
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "50", "50", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(20000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    instr.WriteString("INIT:CONT OFF");
                    if (Keysight.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome, numMarkers))
                    {
                        Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Separação Entre Canais de Salto";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "50", "50", "ON", "MAXH", "POS", "SAN");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(20000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    instr.WriteString("INIT:CONT OFF");
                    if (Rodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, nome, numMarkers))
                    {
                        Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }


            }
            catch 
            {
                return false;
            }
        }

        public void Numero_De_Frequencia_de_Salto(string valFreqI, string valFreqM, string valFreqF,  string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {

            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                // Seta as configurções basicas
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Numero De Frequencia de Salto";
                    Keysight.ConfiguraInstrSalto(instr, valFreqI, valFreqM, "Dbm", Att, RefLevel, "100", "100", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints);
                    Keysight.ConfiguraInstrSalto(instr, valFreqM, valFreqF, "Dbm", Att, RefLevel, "100", "100", "ON", "MAXH", "POS", "SAN");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Numero De Frequencia de Salto";
                    Keysight.ConfiguraInstrSalto(instr, valFreqI, valFreqM, "Dbm", Att, RefLevel,  "100", "100", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints, "WMF");
                    Rodhe.ConfiguraInstrSalto(instr, valFreqM, valFreqF, "Dbm", Att, RefLevel,  "100", "100", "ON", "MAXH", "POS", "SAN");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreqI + " " + valFreqF, tPrints, "WMF");
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-26");
                    instr.IO.Timeout = 5000;
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:OBW:XDB?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Rodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Largura 26";
                    string nomeArquivo = "Valores do ensaio.csv";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "26");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 5000;
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    Rodhe.PegaMarker(instr);
                    instr.WriteString("CALC:MARK1:FUNC:NDBD:RES?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                    Rodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);

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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    Thread.Sleep(15000);
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Keysight.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Pico da densidade de potencia";
                    string nomeArquivo = "Valores do ensaio.csv";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "MAXH", "POS", "SAN");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    Thread.Sleep(15000);
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Rodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void NumeroDeOcupacoes(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
        {
            int numMarkers = 0;
            ConectaIP(ip);

            //"TCPIP0::192.168.1.100::hislip0::INSTR";

            try // Try o bloco para capturar qualquer RsInstrumentException()
            {
                instr.WriteString("*RST;*CLS"); // Reinicialize o instrumento, limpe a fila de erros
                instr.WriteString("INIT:CONT ON"); // Desliga a varredura contínua
                instr.WriteString("DISP:ENAB ON"); // Display update ON - Desligar após a depuração              
                double Span = int.Parse(largura_Banda) * 1.5;
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\A-N9010A-00151\prints\Pico da densidade de potencia";
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "300", "300", "ON", "MAXH", "POS", "SAN");
                    instr.WriteString("SWE:TIME 1");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    while (numMarkers <= 4 & numMarkers >= 3)
                    {
                        instr.WriteString("INIT:CONT ON");
                        Thread.Sleep(1000);
                        instr.WriteString("INIT:OFF");
                        numMarkers = Keysight.ContaMarker(instr);
                    }
                    instr.WriteString("INIT:CONT OFF");
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Numero de Ocupacoes";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, "0", "300", "300", "ON", "WRIT", "POS", "SAN");
                    instr.WriteString("SWE:TIME 1");
                    instr.WriteString("*OPC?");
                    Thread.Sleep(2000);
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    while (!(numMarkers <= 4 & numMarkers >= 3))
                    {
                        instr.WriteString("CALC:MARK:AOFF");
                        instr.WriteString("INIT:CONT ON");
                        Thread.Sleep(1500);
                        instr.WriteString("INIT:CONT OFF");
                        numMarkers = Keysight.ContaMarker(instr);
                    }
                    instr.WriteString("INIT:CONT OFF");
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints,"WMF");
                }
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Potência_de_pico_máximaBT(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
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
                    string nomePasta = @"\\A-N9010A-00151\prints\Potencia de Pico Maxima";
                    string nomeArquivo = "Valores do ensaio.csv";
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    instr.WriteString("INIT:CONT OFF");
                    Keysight.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Potencia de pico Maxima";
                    string nomeArquivo = "Valores do ensaio.csv";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "POS", "SAN");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Rodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "AVER", "RMS", "SAN");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    instr.WriteString("SWE:TIME?");
                    double tempo = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    Thread.Sleep(10000);
                    Thread.Sleep((int)tempo * 1000);
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Keysight.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Valor Medio Densidade Espectral";
                    string nomeArquivo = "Valores do ensaio.csv";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "3", "10", "ON", "AVER", "RMS", "SAN");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    instr.WriteString("SWE:TIME?");
                    double tempo = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    Thread.Sleep(15000);
                    Thread.Sleep((int)tempo * 1000);
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Rodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "POS", "CHP", largura_Banda);
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Pega os Valores
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:CHP:CHP?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    string val = Convert.ToString(aux);
                    Keysight.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Potência_de_pico_máxima";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "POS", "ACP", largura_Banda);
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Pega os Valores
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK:FUNC:POW:RES? ACP");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Rodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "RMS", "CHP", largura_Banda);
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Pega os Valores
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:CHP:CHP?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Keysight.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Valor Médio da Potência Máxima De Saída";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "RMS", "CHP", largura_Banda);
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Pega os Valores
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK:FUNC:POW:RES? ACP");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000;
                    string val = Convert.ToString(aux);
                    Rodhe.SalvaValores(nomeArquivo, nomePasta, val, valFreq, nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                // OBS: Será usado para ensaio o valor minimo permitido pela norma de acordo com o Item 9.1.8 (Opção 3) da 6506
                

            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Valor_médio_da_potência_máxima_de_saídaLE(string valFreq, string ip, string nome, string largura_Banda, string RefLevel, string Att, bool tPrints, string marca)
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "RMS", "CHP", largura_Banda);
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Pega os Valores
                    Thread.Sleep(15000);
                    Keysight.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Valor Médio da Potência Máxima De Saída";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "MAXH", "RMS", "SAN");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Pega os Valores
                    Thread.Sleep(15000);
                    Rodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "MAXH", nome);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-26");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:OBW:XDB?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000000;
                    string aux1 = Convert.ToString(aux);
                    Keysight.ConfiguraInstr(instr, valFreq, "DBM", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "CHP", aux1);
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("FETC:CHP:CHP?");
                    double aux2 = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux2 /= 1000;
                    string val = Convert.ToString(aux2);
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                    Keysight.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Potencia de Saida";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "100", "300", "ON", "MAXH", "POS", "OBW", "99", "-26");
                    instr.WriteString("*OPC?");
                    instr.IO.Timeout = 2000;
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK1:FUNC:NDBD:RES?");
                    double aux = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux /= 1000000;
                    string aux1 = Convert.ToString(aux);
                    Rodhe.ConfiguraInstr(instr, valFreq, "DBM", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "CHP", aux1);
                    instr.WriteString("INIT");
                    Thread.Sleep(15000);
                    instr.WriteString("INIT:CONT OFF");
                    instr.WriteString("CALC:MARK:FUNC:POW:RES?");
                    double aux2 = (double)instr.ReadNumber(IEEEASCIIType.ASCIIType_R8, true);
                    aux2 /= 1000;
                    string val = Convert.ToString(aux2);
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                    Rodhe.SalvaValores("Valores do ensaio.csv", nomePasta, val, valFreq, nome);
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
                    Keysight.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "SAN");
                    instr.WriteString("SWE:TIME?");
                    double tempo = (double)instr.ReadNumber();
                    Thread.Sleep(15000);
                    Thread.Sleep((int)tempo * 1000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    //Salvando os Valores do Marker
                    //Cria uma variavel com o nome do arquivo que quer criar
                    Keysight.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Densidade_Espectral_de_Potencia";
                    Rodhe.ConfiguraInstr(instr, valFreq, "Dbm", Att, RefLevel, Span.ToString(), "1000", "3000", "ON", "AVER", "RMS", "SAN");
                    instr.WriteString("*OPC?");
                    instr.WriteString("SWE:TIME?");
                    double tempo = (double)instr.ReadNumber();
                    Thread.Sleep(15000);
                    Thread.Sleep((int)tempo * 1000);
                    string nomeArquivo = "Valores do ensaio.csv";
                    Rodhe.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, valFreq, "AVER", nome);
                    // -----------------------------------------------------------
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    // -----------------------------------------------------------
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + valFreq, tPrints, "WMF");
                }
                
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Espurios(string freqI, string freqF, string ip, string nome, string RefLevel, string Att, bool tPrints, string marca,string largura, string configFreq )
        {
            ConectaIP(ip);

            try
            {
                instr.WriteString("*RST;*CLS");
                instr.WriteString("INIT:CONT ON");
                instr.WriteString("DISP:ENAB ON");
                Thread.Sleep(2000);
                // Seta as configurções basicas
                if (marca == "Agilent")
                {
                    string nomePasta = @"\\ESR26-101761\prints\Espurios";
                    string nomeArquivo = "Valores do ensaio.csv";
                    Keysight.ConfiguraInstrSalto(instr, freqI, freqF, "Dbm", Att, RefLevel, "100", "300", "ON","MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    Thread.Sleep(5000);
                    Keysight.Pega_Salva_Marker(instr, nomeArquivo, nomePasta, freqI, "MAXH", nome, 2);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    Keysight.SalvaPrints(instr, nomePasta, nome + " " + freqI, tPrints);
                }
                else
                {
                    string nomePasta = @"\\ESR26-101761\prints\Espurios";
                    string nomeArquivo = "Valores do ensaio.csv";
                    Rodhe.ConfiguraInstrSalto(instr, freqI, freqF, "Dbm", Att, RefLevel, "100", "300", "ON", "MAXH", "POS", "SAN");
                    instr.IO.Timeout = 2000; // tempo limite de varredura - defina ele mais alto do que o tempo de aquisição do instrumento
                    instr.WriteString("INIT"); // Comece a varredura
                    Thread.Sleep(5000);
                    Rodhe.Pega_Salva_Marker_Espurios(instr, configFreq, nomeArquivo, nomePasta, freqI, freqF, largura, nome, 2);
                    // Fazendo uma captura de tela do instrumento e transferindo o arquivo para o PC
                    Rodhe.SalvaPrints(instr, nomePasta, nome + " " + freqI + " " + freqF, tPrints, "WMF");
                    
                }
            }
            catch (RsInstrumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}