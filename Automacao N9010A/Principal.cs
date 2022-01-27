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
        string caminhoJson = @"C:\Users\80400197\Documents\GitHub\Automacao-N9010A";
        Keysight ks;
        string jsonString;
        FileStream json;
        Save salva;




        public Principal()
        {
            InitializeComponent();
            ks = new Keysight();
            if (!System.IO.File.Exists(caminhoJson + @"\" + "save.json"))
            {
                json = ks.CriaArquivo(caminhoJson, "save.json");
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
                  ""RefLevel"": ""35"",
                  ""Att"": ""20"",
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






        public void Ensaio_Largura_de_faixa_a_6_dB(string valFreq, string ip, string ensaioAtual)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();

            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();
            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Largura_6dB(valFreq, ip,ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11b":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (20)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (40)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11n (80)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ac (20)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ac (40)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ac (80)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (20)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ax (40)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ax (80)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (160)":
                    radical.Largura_6dB(valFreq, ip, ensaioAtual + valFreq, "160", RefLevel, Att);
                    break;
            }
        }


        
        public void Ensaio_Largura_de_faixa_a_26_dB(string valFreq, string ip, string ensaioAtual)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11b":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (20)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (40)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11n (80)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ac (20)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ac (40)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ac (80)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (20)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ax (40)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ax (80)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (160)":
                    radical.Largura_26dB(valFreq, ip, ensaioAtual + valFreq, "160", RefLevel, Att);
                    break;
            }
        }

        public void Ensaio_pico_da_densidade_de_potência(string valFreq, string ip, string ensaioAtual)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();


            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11b":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (20)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (40)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11n (80)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ac (20)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ac (40)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ac (80)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (20)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ax (40)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ax (80)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (160)":
                    radical.Pico_da_densidade_de_potência(valFreq, ip, ensaioAtual + valFreq, "160", RefLevel, Att);
                    break;
            }
        }

        public void Ensaio_Valor_Medio_Densidade_Espectral(string valFreq, string ip, string ensaioAtual)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11b":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (20)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (40)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11n (80)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ac (20)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ac (40)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ac (80)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (20)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ax (40)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ax (80)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (160)":
                    radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ensaioAtual + valFreq, "160", RefLevel, Att);
                    break;
            }

        }

        public void Ensaio_Potencia_de_Pico_Maxima(string valFreq, string ip, string ensaioAtual)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11b":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (20)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (40)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11n (80)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ac (20)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ac (40)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ac (80)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (20)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ax (40)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ax (80)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (160)":
                    radical.Potência_de_pico_máxima(valFreq, ip, ensaioAtual + valFreq, "160", RefLevel, Att);
                    break;
            }
        }

        public void Ensaio_Valor_médio_da_potência_máxima_de_saída(string valFreq, string ip, string ensaioAtual)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            switch (ensaioAtual)
            {
                case "802.11a":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11b":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (20)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11n (40)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11n (80)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ac (20)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ac (40)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ac (80)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (20)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "20", RefLevel, Att);
                    break;
                case "802.11ax (40)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "40", RefLevel, Att);
                    break;
                case "802.11ax (80)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "80", RefLevel, Att);
                    break;
                case "802.11ax (160)":
                    radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ensaioAtual + valFreq, "160", RefLevel, Att);
                    break;
            }

        }

        /* Antigo
        private void BtConfirmar_Click(object sender, EventArgs e)
        {
            Item_11 it11;
            Item_12 it12;
            it11 = new Item_11();
            it12 = new Item_12();

            for (int i = 0; i < it11.GetQuantidadeEnsaios(); i++)
            {
                switch (it11.GetEnsaios(i))
                {
                    case "Largura de faixa a 6 dB":
                        MessageBox.Show("Iniciando o Ensaio Largura de Faixa a 6 dB");
                        Ensaio_Largura_de_faixa_a_6_dB(TextBoxFreqC.Text, TextBoxIP.Text);
                        MessageBox.Show("valores Salvos na pasta");
                        continue;
                    case "Largura de faixa a 26 dB":
                        MessageBox.Show("Iniciando o Ensaio Largura de Faixa a 26 dB");
                        Ensaio_Largura_de_faixa_a_26_dB(TextBoxFreqC.Text, TextBoxIP.Text);
                        MessageBox.Show(@"valores Salvos na Pasta");
                        continue;
                    case "Potência de pico máxima":
                        MessageBox.Show("Iniciando o Ensaio Potência de Pico Máxima, Utilizando o Método de ensaio de Integração do Item 9.1.8 da norma 6506");
                        Ensaio_Potencia_de_Pico_Maxima(TextBoxFreqC.Text, TextBoxIP.Text);
                        MessageBox.Show(@"valores Salvos na Pasta");
                        continue;
                    case "Valor médio da potência máxima de saída":
                        MessageBox.Show("Iniciando o Ensaio Valor Médio da Potência Máxima de Saída, Utilizando o Método de ensaio de Integração do Item 9.1.8 da norma 6506");
                        Ensaio_Valor_médio_da_potência_máxima_de_saída(TextBoxFreqC.Text, TextBoxIP.Text);
                        MessageBox.Show(@"valores Salvos na Pasta");
                        continue;
                    case "Pico da densidade de potência":
                        MessageBox.Show("Iniciando o Ensaio Pico da Densidade de Potência");
                        Ensaio_pico_da_densidade_de_potência(TextBoxFreqC.Text, TextBoxIP.Text);
                        MessageBox.Show(@"valores Salvos na pasta");
                        continue;
                    case "Valor médio da densidade espectral de potência":
                        MessageBox.Show("Iniciando o Ensaio Valor Médio da Densidade Espectral de Potência");
                        Ensaio_Valor_Medio_Densidade_Espectral(TextBoxFreqC.Text, TextBoxIP.Text);
                        MessageBox.Show(@"valores Salvos na pasta");
                        continue;
                    case "Emissão fora da faixa":

                        continue;
                }
            }
            for (int i = 0; i < it12.GetQuantidadeEnsaios(); i++)
            {
                switch (it12.GetEnsaios(i))
                {
                    case "Potência de saída":

                    case "Densidade espectral de potência":

                    case "Emissão fora da faixa":

                        break;
                }
            }

        }
        */

        private void ListaDeEnsaios(string ensaioAtual)
        {
            TelaLoading tl;
            tl = new TelaLoading();
            Item_11 it11;
            it11 = new Item_11();
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);
            if (salva.EnsaiosItem11[0] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Largura de Faixa a 6 dB");
                Ensaio_Largura_de_faixa_a_6_dB(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual);
                tl.setValorPB((100 / it11.GetQuantidadeEnsaios())/ListaTecnologias.CheckedItems.Count);
                MessageBox.Show("valores Salvos na pasta");
            }
            if (salva.EnsaiosItem11[1] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Largura de Faixa a 26 dB");
                Ensaio_Largura_de_faixa_a_26_dB(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual);
                tl.setValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na Pasta");
            }
            if (salva.EnsaiosItem11[2] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Potência de Pico Máxima, Utilizando o Método de ensaio de Integração do Item 9.1.8 da norma 6506");
                Ensaio_Potencia_de_Pico_Maxima(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual);
                tl.setValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na Pasta");
            }
            if (salva.EnsaiosItem11[3] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Valor Médio da Potência Máxima de Saída, Utilizando o Método de ensaio de Integração do Item 9.1.8 da norma 6506");
                Ensaio_Valor_médio_da_potência_máxima_de_saída(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual);
                tl.setValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na Pasta");
            }
            if (salva.EnsaiosItem11[4] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Pico da Densidade de Potência");
                Ensaio_pico_da_densidade_de_potência(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual);
                tl.setValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na pasta");
            }
            if (salva.EnsaiosItem11[5] == true)
            {
                MessageBox.Show("Iniciando o Ensaio Valor Médio da Densidade Espectral de Potência");
                Ensaio_Valor_Medio_Densidade_Espectral(TextBoxFreqC.Text, TextBoxIP.Text, ensaioAtual);
                tl.setValorPB((100 / it11.GetQuantidadeEnsaios()) / ListaTecnologias.CheckedItems.Count);
                MessageBox.Show(@"valores Salvos na pasta");
            }
            if (salva.EnsaiosItem11[6] == true)
            {
                //EM BREVE!!!!
            }
        }



        private void BtConfirmar_Click(object sender, EventArgs e)
        {
            TelaLoading tl;
            tl = new TelaLoading();
            tl.Show();
            for (int i = 0; i < ListaTecnologias.CheckedItems.Count; i++)
            {
                switch (ListaTecnologias.CheckedItems[i])
                {
                    case "802.11a":
                        MessageBox.Show("Iniciando o Ensaio do 802.11a, configure o aparelho");
                        ListaDeEnsaios("802.11a");
                        continue;
                    case "802.11b":
                        MessageBox.Show("Iniciando o Ensaio do 802.11b, configure o aparelho");
                        ListaDeEnsaios("802.11b");
                        continue;
                    case "802.11n (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (20), configure o aparelho");
                        ListaDeEnsaios("802.11n (20)");;
                        continue;
                    case "802.11n (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (40), configure o aparelho");
                        ListaDeEnsaios("802.11n (40)");
                        continue;
                    case "802.11n (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (80), configure o aparelho");
                        ListaDeEnsaios("802.11n (80)");
                        continue;
                    case "802.11ac (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (20), configure o aparelho");
                        ListaDeEnsaios("802.11ac (20)");
                        continue;
                    case "802.11ac (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (40), configure o aparelho");
                        ListaDeEnsaios("802.11ac (40)");
                        continue;
                    case "802.11ac (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (80), configure o aparelho");
                        ListaDeEnsaios("802.11ac (80)");
                        continue;
                    case "802.11ax (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (20), configure o aparelho");
                        ListaDeEnsaios("802.11ax (20)");
                        continue;
                    case "802.11ax (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (40), configure o aparelho");
                        ListaDeEnsaios("802.11ax (40)");
                        continue;
                    case "802.11ax (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (80), configure o aparelho");
                        ListaDeEnsaios("802.11ax (80)");
                        continue;
                    case "802.11ax (160)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (160), configure o aparelho");
                        ListaDeEnsaios("802.11ax (160)");
                        continue;
                }
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
            Item_11 it11;
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
            Item_12 it12;
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
            Configurações config;
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
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();

            if (radical.ConectaIP(TextBoxIP.Text) == true)
            {
                LConecta.Text = "CONECTADO";
                LConecta.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                MessageBox.Show("Erro ao se conectar com o aparelho");
                LConecta.Text = "SEM CONEXÃO";
                LConecta.ForeColor = System.Drawing.Color.Red;
            }

        }

        public void pega(string a)
        {
            LAPrints.Text = a;
        }



        private void Principal_Shown(object sender, EventArgs e)
        {
            jsonString = File.ReadAllText(caminhoJson);
            salva = JsonSerializer.Deserialize<Save>(jsonString);
            if (salva.AtivarPrints)
            {
                LAPrints.Text = "PRINTS ATIVADO";
                LAPrints.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LAPrints.Text = "PRINTS DESATIVADO";
                LAPrints.ForeColor = System.Drawing.Color.Red;
            }

        }
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
