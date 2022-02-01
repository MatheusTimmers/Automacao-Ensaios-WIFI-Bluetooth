using MatheusProductions.AutomacaoN9010A;
using System;
using System.Windows.Forms;
using MatheusProductions.keysight;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Automacao_N9010A
{
    

    public partial class Principal : Form
    {
        string RefLevel;
        string Att;
        string caminhoJson = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        Keysight ks;
        string jsonString;
        FileStream json;
        Save salva;
        TelaLoading tl;
        AutomacaoN9010A radical;
        Configurações config;
        Item_11 it11;
        Item_12 it12;


        public Principal()
        {
            InitializeComponent();
            ks = new Keysight();
            if (!System.IO.File.Exists(caminhoJson + @"\" + "save.json"))
            {
                json = ks.CriaArquivo("save.json", caminhoJson);
                json.Close();
                caminhoJson =  System.IO.Path.Combine(caminhoJson, "save.json");
                jsonString =
                @"{
                  ""EnsaiosItem10"": [
                    false,
                    false,
                    false,
                    false,
                    false
                    ],
                  ""EnsaiosItem11"": [
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                    ],
                  ""EnsaiosItem12"": [
                    false,
                    false,
                    false
                    ],
                  ""RefLevel"": ""10"",
                  ""Att"": ""35"",
                  ""AtivarPrints"": true
                }
                ";
                File.WriteAllText(caminhoJson, jsonString);

            }
            else
            {
                caminhoJson = System.IO.Path.Combine(caminhoJson, "save.json");
            }
            


        }

        public void SalvaEnsaios11(bool EstadoEnsaio, int i)
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva =  JsonSerializer.Deserialize<Save>(jsonString);

            salva.EnsaiosItem11[i] = EstadoEnsaio;
            string novoSave = JsonSerializer.Serialize(salva);
            File.WriteAllText(caminhoJson, novoSave);
        }

        public bool CarregaEnsaios11(int i)
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);

            return salva.EnsaiosItem11[i];
        }

        public void SalvaEnsaios12(bool EstadoEnsaio, int i)
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);

            salva.EnsaiosItem12[i] = EstadoEnsaio;
            string novoSave = JsonSerializer.Serialize(salva);
            File.WriteAllText(caminhoJson, novoSave);
        }

        public bool CarregaEnsaios12(int i)
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);

            return salva.EnsaiosItem12[i];
        }


        public void SalvaConfig(string refL, string att, bool gPrints)
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);

            salva.RefLevel = refL;
            salva.Att = att;
            salva.AtivarPrints = gPrints;
            string novoSave = JsonSerializer.Serialize(salva);
            File.WriteAllText(caminhoJson, novoSave);
        }



        public string CarregaAtt()
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);

            return salva.Att;
        }

        public string CarregaRefLevel()
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);

            return salva.RefLevel;
        }

        public bool CarregaAPrints()
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);

            return salva.AtivarPrints;
        }






        public void Ensaio_Largura_de_faixa_a_6_dB(string valFreq, string ip, string ensaioAtual, Configurações config)
        {
            radical = new AutomacaoN9010A();
            //config = new Configurações();
            Att = config.GetAtt();
            RefLevel = config.GetRef();
            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11b":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (20)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (40)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (80)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (20)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (40)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (80)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (20)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (40)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (80)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (160)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual, "160", RefLevel, Att, config.GetTPrints());
                    break;
            }
        }


        
        public void Ensaio_Largura_de_faixa_a_26_dB(string valFreq, string ip, string ensaioAtual, Configurações config)
        {
            radical = new AutomacaoN9010A();
            Att = config.GetAtt();
            RefLevel = config.GetRef();

            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11b":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (20)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (40)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (80)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (20)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (40)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (80)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (20)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (40)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (80)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (160)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual, "160", RefLevel, Att, config.GetTPrints());
                    break;
            }
        }

        public void Ensaio_pico_da_densidade_de_potência(string valFreq, string ip, string ensaioAtual, Configurações config)
        {
            radical = new AutomacaoN9010A();
            Att = config.GetAtt();
            RefLevel = config.GetRef();


            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11b":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (20)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (40)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (80)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (20)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (40)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (80)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (20)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (40)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (80)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (160)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual, "160", RefLevel, Att, config.GetTPrints());
                    break;
            }
        }

        public void Ensaio_Valor_Medio_Densidade_Espectral(string valFreq, string ip, string ensaioAtual, Configurações config)
        {
            radical = new AutomacaoN9010A();
            Att = config.GetAtt();
            RefLevel = config.GetRef();

            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11b":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (20)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (40)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (80)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (20)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (40)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (80)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (20)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (40)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (80)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (160)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual, "160", RefLevel, Att, config.GetTPrints());
                    break;
            }

        }

        public void Ensaio_Potencia_de_Pico_Maxima(string valFreq, string ip, string ensaioAtual, Configurações config)
        {
            radical = new AutomacaoN9010A();
            Att = config.GetAtt();
            RefLevel = config.GetRef();

            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11b":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (20)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (40)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (80)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (20)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (40)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (80)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (20)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (40)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (80)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (160)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual, "160", RefLevel, Att, config.GetTPrints());
                    break;
            }
        }

        public void Ensaio_Valor_médio_da_potência_máxima_de_saída(string valFreq, string ip, string ensaioAtual, Configurações config)
        {
            radical = new AutomacaoN9010A();
            Att = config.GetAtt();
            RefLevel = config.GetRef();

            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11b":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (20)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (40)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11n (80)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (20)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (40)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ac (80)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (20)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "20", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (40)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "40", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (80)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "80", RefLevel, Att, config.GetTPrints());
                    break;
                case "802.11ax (160)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual, "160", RefLevel, Att, config.GetTPrints());
                    break;
            }

        }

       

        private void ListaDeEnsaios(string ensaioAtual, TelaLoading tl, Configurações config)
        {
            it11 = new Item_11();
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);
            if (salva.EnsaiosItem11[0] == true)
            {
     
                
                MessageBox.Show("Iniciando o Ensaio Largura de Faixa a 6 dB");
                Ensaio_Largura_de_faixa_a_6_dB(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual, config);
                tl.SetValorPB((100 / it11.GetQuantidadeEnsaios())/ListaTecnologias.CheckedItems.Count);
                MessageBox.Show("valores Salvos na pasta");
            }
            if (salva.EnsaiosItem11[1] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Largura de Faixa a 26 dB");
                Ensaio_Largura_de_faixa_a_26_dB(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual, config);
                tl.SetValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na Pasta");
            }
            if (salva.EnsaiosItem11[2] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Potência de Pico Máxima, Utilizando o Método de ensaio de Integração do Item 9.1.8 da norma 6506");
                Ensaio_Potencia_de_Pico_Maxima(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual, config);
                tl.SetValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na Pasta");
            }
            if (salva.EnsaiosItem11[3] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Valor Médio da Potência Máxima de Saída, Utilizando o Método de ensaio de Integração do Item 9.1.8 da norma 6506");
                Ensaio_Valor_médio_da_potência_máxima_de_saída(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual, config);
                tl.SetValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na Pasta");
            }
            if (salva.EnsaiosItem11[4] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Pico da Densidade de Potência");
                Ensaio_pico_da_densidade_de_potência(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual, config);
                tl.SetValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na pasta");
            }
            if (salva.EnsaiosItem11[5] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Valor Médio da Densidade Espectral de Potência");
                Ensaio_Valor_Medio_Densidade_Espectral(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual, config);
                tl.SetValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na pasta");
            }
            if (salva.EnsaiosItem11[6] == true)
            {
                //EM BREVE!!!!
            }
        }



        private void BtConfirmar_Click(object sender, EventArgs e)
        {
            tl = new TelaLoading();
            config = new Configurações();
            if(ListaTecnologias.CheckedItems.Count != 0)
            {
                if (TextBoxFreqC.Text != "")
                {
                    if (LConecta.Text == "CONECTADO")
                    {
                        tl.Show();
                        for (int i = 0; i < ListaTecnologias.CheckedItems.Count; i++)
                        {
                            switch (ListaTecnologias.CheckedItems[i])
                            {
                                case "802.11a":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11a, configure o aparelho");
                                    ListaDeEnsaios("802.11a", tl, config);
                                    continue;
                                case "802.11b":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11b, configure o aparelho");
                                    ListaDeEnsaios("802.11b", tl, config);
                                    continue;
                                case "802.11n (20)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11n (20), configure o aparelho");
                                    ListaDeEnsaios("802.11n (20)", tl, config); 
                                    continue;
                                case "802.11n (40)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11n (40), configure o aparelho");
                                    ListaDeEnsaios("802.11n (40)", tl, config);
                                    continue;
                                case "802.11n (80)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11n (80), configure o aparelho");
                                    ListaDeEnsaios("802.11n (80)", tl, config);
                                    continue;
                                case "802.11ac (20)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11ac (20), configure o aparelho");
                                    ListaDeEnsaios("802.11ac (20)", tl, config);
                                    continue;
                                case "802.11ac (40)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11ac (40), configure o aparelho");
                                    ListaDeEnsaios("802.11ac (40)", tl, config);
                                    continue;
                                case "802.11ac (80)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11ac (80), configure o aparelho");
                                    ListaDeEnsaios("802.11ac (80)", tl, config);
                                    continue;
                                case "802.11ax (20)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11ax (20), configure o aparelho");
                                    ListaDeEnsaios("802.11ax (20)", tl, config);
                                    continue;
                                case "802.11ax (40)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11ax (40), configure o aparelho");
                                    ListaDeEnsaios("802.11ax (40)", tl, config);
                                    continue;
                                case "802.11ax (80)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11ax (80), configure o aparelho");
                                    ListaDeEnsaios("802.11ax (80)", tl, config);
                                    continue;
                                case "802.11ax (160)":
                                    MessageBox.Show("Iniciando o Ensaio do 802.11ax (160), configure o aparelho");
                                    ListaDeEnsaios("802.11ax (160)", tl, config);
                                    continue;
                            }
                        }
                        tl.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma Maquina Conectada");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Selecione uma Frequencia");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Tecnologia");
            }
           

        }


        private void BtSelTodos_Click(object sender, EventArgs e)
        {
             for (int i = 0; i < ListaTecnologias.Items.Count; i++)
             {
                ListaTecnologias.SetItemChecked(i, true);
             }
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaTecnologias.Items.Count; i++)
            {
                ListaTecnologias.SetItemChecked(i, false);
            }
        }

        private void BtItem10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EM BREVE!");
            //Item_10 it10;
            //it10 = new Item_10();
            //.Show();
        }

        private void BtItem11_Click(object sender, EventArgs e)
        {
            it11 = new Item_11();
            if (Application.OpenForms["Item_11"] == null)
            {
                it11.Show();
            }
            else
            {
                MessageBox.Show("Aba já está aberta");
            }
        }

        private void BtItem12_Click(object sender, EventArgs e)
        {
            it12 = new Item_12();
            if (Application.OpenForms["Item_12"] == null)
            {
                it12.Show();
            }
            else
            {
                MessageBox.Show("Aba já está aberta");
            }
            
        }

        private void BtConfig_Click(object sender, EventArgs e)
        {
            config = new Configurações();
            if (Application.OpenForms["Configurações"] == null)
            {
                config.Show();
            }
            else
            {

                MessageBox.Show("Aba já está aberta");
            }
        }

        private void BtConectado_Click(object sender, EventArgs e)
        {
            radical = new AutomacaoN9010A();
            if (LConecta.Text == "CONECTADO")
            {
                MessageBox.Show("Aparelho já conectado");
            }
            else
            {
                if (radical.ConectaIP(TextBoxIP.Text) == true)
                {       
                    LConecta.Text = "CONECTADO";
                    LConecta.ForeColor = System.Drawing.Color.Green;
                    while (LConecta.Text != "CONECTADO")
                    {
                        LConecta.Text = "CONECTANDO";
                        LConecta.ForeColor = System.Drawing.Color.Yellow;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Erro ao se conectar com o aparelho");
                    LConecta.Text = "SEM CONEXÃO";
                    LConecta.ForeColor = System.Drawing.Color.Red;
                }
            }
            

        }

        public void Pega(string valor)
        {
            LAP = valor;
        }

        public string LAP { get; set; }

        
    }
    public class Save
    {
        public bool[] EnsaiosItem10 { get; set; }
        public bool[] EnsaiosItem11 { get; set; }
        public bool[] EnsaiosItem12 { get; set; }
        public string RefLevel { get; set; }
        public string Att { get; set; }
        public bool AtivarPrints { get; set; }

        
    }
}
