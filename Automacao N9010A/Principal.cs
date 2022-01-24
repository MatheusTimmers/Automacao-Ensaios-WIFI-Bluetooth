using MatheusProductions.AutomacaoN9010A;
using System;
using System.Windows.Forms;

namespace Automacao_N9010A
{
    public partial class Principal : Form
    {
        string RefLevel;
        string Att;
        

        public Principal()
        {
            InitializeComponent();
            
        }

        public void Ensaio_Largura_de_faixa_a_6_dB(string valFreq, string ip)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();

            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            for (int i = 0; i < ListaTecnologias.CheckedItems.Count; i++)
            {
                switch (ListaTecnologias.CheckedItems[i])
                {
                    case "802.11a":
                        MessageBox.Show("Iniciando o Ensaio do 802.11a, configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11b":
                        MessageBox.Show("Iniciando o Ensaio do 802.11b, configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (20), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (40), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11n (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (80), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ac (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (20), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ac (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (40), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ac (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (80), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (20), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ax (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (40), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ax (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (80), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (160)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (160), configure o aparelho");
                        radical.Largura_6dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "160", RefLevel, Att);
                        continue;
                }
            }
        }


        
        public void Ensaio_Largura_de_faixa_a_26_dB(string valFreq, string ip)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            for (int i = 0; i < ListaTecnologias.CheckedItems.Count; i++)
            {
                switch (ListaTecnologias.CheckedItems[i])
                {
                    case "802.11a":
                        MessageBox.Show("Iniciando o Ensaio do 802.11a, configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11b":
                        MessageBox.Show("Iniciando o Ensaio do 802.11b, configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (20), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (40), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11n (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (80), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ac (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (20), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ac (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (40), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ac (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (80), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (20), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ax (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (40), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue; ;
                    case "802.11ax (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (80), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (160)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (160), configure o aparelho");
                        radical.Largura_26dB(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "160", RefLevel, Att);
                        continue;
                }
            }
        }

        public void Ensaio_pico_da_densidade_de_potência(string valFreq, string ip)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            for (int i = 0; i < ListaTecnologias.CheckedItems.Count; i++)
            {
                switch (ListaTecnologias.CheckedItems[i])
                {
                    case "802.11a":
                        MessageBox.Show("Iniciando o Ensaio do 802.11a, configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11b":
                        MessageBox.Show("Iniciando o Ensaio do 802.11b, configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (20), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (40), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11n (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (80), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ac (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (20), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ac (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (40), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ac (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (80), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (20), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ax (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (40), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ax (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (80), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (160)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (160), configure o aparelho");
                        radical.Pico_da_densidade_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "160", RefLevel, Att);
                        continue;
                }
            }
        }

        public void Ensaio_Valor_Medio_Densidade_Espectral(string valFreq, string ip)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            for (int i = 0; i < ListaTecnologias.CheckedItems.Count; i++)
            {
                switch (ListaTecnologias.CheckedItems[i])
                {
                    case "802.11a":
                        MessageBox.Show("Iniciando o Ensaio do 802.11a, configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11b":
                        MessageBox.Show("Iniciando o Ensaio do 802.11b, configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (20), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (40), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11n (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (80), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ac (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (20), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ac (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (40), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ac (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (80), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (20), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ax (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (40), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ax (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (80), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (160)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (160), configure o aparelho");
                        radical.Valor_médio_da_densidade_espectral_de_potência(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "160", RefLevel, Att);
                        continue;
                }
            }

        }

        public void Ensaio_Potencia_de_Pico_Maxima(string valFreq, string ip)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();


            for (int i = 0; i < ListaTecnologias.CheckedItems.Count; i++)
            {
                switch (ListaTecnologias.CheckedItems[i])
                {
                    case "802.11a":
                        MessageBox.Show("Iniciando o Ensaio do 802.11a, configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11b":
                        MessageBox.Show("Iniciando o Ensaio do 802.11b, configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (20), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (40), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11n (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (80), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ac (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (20), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ac (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (40), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ac (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (80), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (20), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ax (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (40), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ax (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (80), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (160)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (160), configure o aparelho");
                        radical.Potência_de_pico_máxima(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "160", RefLevel, Att);
                        continue;
                }
            }

        }

        public void Ensaio_Valor_médio_da_potência_máxima_de_saída(string valFreq, string ip)
        {
            AutomacaoN9010A radical;
            radical = new AutomacaoN9010A();
            Configurações config;
            config = new Configurações();

            Att = config.GetAtt();
            RefLevel = config.GetRef();

            for (int i = 0; i < ListaTecnologias.CheckedItems.Count; i++)
            {
                switch (ListaTecnologias.CheckedItems[i])
                {
                    case "802.11a":
                        MessageBox.Show("Iniciando o Ensaio do 802.11a, configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11b":
                        MessageBox.Show("Iniciando o Ensaio do 802.11b, configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (20), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11n (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (40), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11n (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11n (80), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ac (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (20), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ac (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (40), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ac (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ac (80), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (20)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (20), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "20", RefLevel, Att);
                        continue;
                    case "802.11ax (40)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (40), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "40", RefLevel, Att);
                        continue;
                    case "802.11ax (80)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (80), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "80", RefLevel, Att);
                        continue;
                    case "802.11ax (160)":
                        MessageBox.Show("Iniciando o Ensaio do 802.11ax (160), configure o aparelho");
                        radical.Valor_médio_da_potência_máxima_de_saída(valFreq, ip, ListaTecnologias.CheckedItems[i] + valFreq, "160", RefLevel, Att);
                        continue;
                }
            }

        }


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
    }
}
