using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automacao_N9010A
{
    public partial class Configurações : Form
    {
        Principal pr;
        public string RefLevel, Att, marca, freqInicial, freqFinal, canalInicial, canalFinal, freqInicialNCS, freqMeioNCS, freqFinalNCS;
        public Configurações()
        {
            InitializeComponent();
            pr = new Principal();
            RefLevel = pr.CarregaRefLevel();
            Att = pr.CarregaAtt();
            if (pr.CarregaTipo() == 0)
            {
                freqInicial = pr.CarregaFreqEspuriosWifi(0);
                canalInicial = pr.CarregaFreqEspuriosWifi(1);
                canalFinal= pr.CarregaFreqEspuriosWifi(2);
                freqFinal = pr.CarregaFreqEspuriosWifi(3);
            }
            else
            {
                freqInicial = pr.CarregaFreqEspuriosBt(0);
                canalInicial = pr.CarregaFreqEspuriosBt(1);
                canalFinal = pr.CarregaFreqEspuriosBt(2);
                freqFinal = pr.CarregaFreqEspuriosBt(3);
            }
            if (pr.CarregaMarca() == "Agilent")
            {
                CBModelos.SelectedItem = "N9010A";
                marca = pr.CarregaMarca();
            }
            else
            {
                CBModelos.SelectedItem = "ESR";
                marca = pr.CarregaMarca();
            }
            freqInicialNCS = pr.CarregaFreqNCS(0);
            freqMeioNCS = pr.CarregaFreqNCS(1);
            freqFinalNCS = pr.CarregaFreqNCS(2);
            CBPrints.Checked = pr.CarregaAPrints();
            LValorAtualRLevel.Text = "Atual:" + RefLevel;
            LValorAtualAtt.Text = "Atual:" + Att; ;
            LFreqFinal.Text = "Atual:" + freqFinal;
            LCanalFinal.Text = "Atual:" + canalFinal;
            LCanalInicial.Text = "Atual:" + canalInicial;
            LFreqInicial.Text = "Atual:" + freqInicial;
            LFreqInicialNCS.Text = "Atual:" + freqInicialNCS;
            LFreqMeioNCS.Text = "Atual:" + freqMeioNCS;
            LFreqFinalNCS.Text = "Atual:" + freqFinalNCS;

            TextBoxAtt.Text = "";
            TextBoxRefLevel.Text = "";
            TbFreqFinalEspurios.Text = "";
            TbCanalInicialEspurios.Text = "";
            TbFreqFinalEspurios.Text = "";
            TbCanalFinalEspurios.Text = "";
            TbFreqInicialNCS.Text = "";
            TbFreqMeioNCS.Text = "";
            TbFreqFinalNCS.Text = "";
        }


        private void BtSalvar_Click(object sender, EventArgs e)
        {
            pr = new Principal();
            if (TextBoxRefLevel.Text == "" & TextBoxAtt.Text == "" & CBModelos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor insira valores válidos");
            }
            else
            {
                if (TextBoxRefLevel.Text != "" & TextBoxAtt.Text == "" & CBModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Salvando novo valor para o Reference Level");
                    RefLevel = TextBoxRefLevel.Text;
                    LValorAtualRLevel.Text = "Atual:" + TextBoxRefLevel.Text;
                    TextBoxAtt.Text = "";
                    TextBoxRefLevel.Text = "";
                    pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
                }
                else
                {
                    if (TextBoxRefLevel.Text == "" & TextBoxAtt.Text != "" & CBModelos.SelectedIndex == -1)
                    {
                        MessageBox.Show("Salvando novo valor para a Attenuation");
                        Att = TextBoxAtt.Text;
                        LValorAtualAtt.Text = "Atual:" + TextBoxAtt.Text;
                        TextBoxAtt.Text = "";
                        TextBoxRefLevel.Text = "";
                        pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
                    }
                    else
                    {
                        if (TextBoxRefLevel.Text != "" & TextBoxAtt.Text != "" & CBModelos.SelectedIndex == -1)
                        {
                            MessageBox.Show("Salvando os novos valores para o Reference Level e a Attenuation");
                            RefLevel = TextBoxRefLevel.Text;
                            Att = TextBoxAtt.Text;
                            LValorAtualRLevel.Text = "Atual:" + TextBoxRefLevel.Text;
                            LValorAtualAtt.Text = "Atual:" + TextBoxAtt.Text;
                            TextBoxAtt.Text = "";
                            TextBoxRefLevel.Text = "";
                            pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
                        }
                        else
                        {
                            if (TextBoxRefLevel.Text != "" & TextBoxAtt.Text == "" & CBModelos.SelectedIndex != -1)
                            {
                                MessageBox.Show("Salvando novo valor para o Reference Level e alterando Modelo");
                                RefLevel = TextBoxRefLevel.Text;
                                marca = GetMarca();
                                LValorAtualRLevel.Text = "Atual:" + TextBoxRefLevel.Text;
                                TextBoxAtt.Text = "";
                                TextBoxRefLevel.Text = "";
                                pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
                            }
                            else
                            {
                                if(TextBoxRefLevel.Text == "" & TextBoxAtt.Text != "" & CBModelos.SelectedIndex != -1)
                                {
                                    MessageBox.Show("Salvando novo valor para a Attenuation e alterando Modelo");
                                    Att = TextBoxAtt.Text;
                                    marca = GetMarca();
                                    LValorAtualAtt.Text = "Atual:" + TextBoxAtt.Text;
                                    TextBoxAtt.Text = "";
                                    TextBoxRefLevel.Text = "";
                                    pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
                                }
                                else
                                {
                                    if (TextBoxRefLevel.Text == "" & TextBoxAtt.Text == "" & CBModelos.SelectedIndex != -1)
                                    {
                                        MessageBox.Show("Alterando o Modelo de Ensaio");
                                        marca = GetMarca();
                                        pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Salvando os novos valores para o Reference Level e a Attenuation, e alterando o Modelo");
                                        RefLevel = TextBoxRefLevel.Text;
                                        Att = TextBoxAtt.Text;
                                        marca = GetMarca();
                                        LValorAtualRLevel.Text = "Atual:" + TextBoxRefLevel.Text;
                                        LValorAtualAtt.Text = "Atual:" + TextBoxAtt.Text;
                                        TextBoxAtt.Text = "";
                                        TextBoxRefLevel.Text = "";
                                        pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
                                    }
                                    
                                }
                            }
                        }  
                    }
                }
            }
        }

        private void CBEspurios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBEspurios.SelectedIndex == 0)
            {
                LFreqInicial.Text = "Atual:" + pr.CarregaFreqEspuriosWifi(0);
                LCanalInicial.Text = "Atual:" + pr.CarregaFreqEspuriosWifi(1);
                LCanalFinal.Text = "Atual:" + pr.CarregaFreqEspuriosWifi(2);
                LFreqFinal.Text = "Atual:" + pr.CarregaFreqEspuriosWifi(3);
            }
            else
            {
                LFreqInicial.Text = "Atual:" + pr.CarregaFreqEspuriosBt(0);
                LCanalInicial.Text = "Atual:" + pr.CarregaFreqEspuriosBt(1);
                LCanalFinal.Text = "Atual:" + pr.CarregaFreqEspuriosBt(2);
                LFreqFinal.Text = "Atual:" + pr.CarregaFreqEspuriosBt(3);
            }
        }

        private void BtSalvarFreqNumeroDeCanaisDeSalto_Click(object sender, EventArgs e)
        {
            if (TbFreqInicialNCS.Text == "" & TbFreqMeioNCS.Text == "" & TbFreqFinalNCS.Text == "")
            {
                MessageBox.Show("Por favor insira valores válidos");
            }
            else
            {
                if (TbFreqInicialNCS.Text != "" & TbFreqMeioNCS.Text == "" & TbFreqFinalNCS.Text == "")
                {
                    MessageBox.Show("Salvando novo valor para a frequencia inicial");
                    freqInicialNCS = TbFreqInicialNCS.Text;
                    LFreqInicialNCS.Text = "Atual:" + TbFreqInicialNCS.Text;
                    TbFreqInicialNCS.Text = "";
                    TbFreqMeioNCS.Text = "";
                    TbFreqFinalNCS.Text = "";
                    pr.SalvaConfigNCS(freqInicialNCS, freqMeioNCS, freqFinalNCS);
                }
                else
                {
                    if (TbFreqInicialNCS.Text == "" & TbFreqMeioNCS.Text != "" & TbFreqFinalNCS.Text == "")
                    {
                        MessageBox.Show("Salvando novo valor para a frequencia central");
                        freqMeioNCS = TbFreqMeioNCS.Text;
                        LFreqMeioNCS.Text = "Atual:" + TbFreqMeioNCS.Text;
                        TbFreqInicialNCS.Text = "";
                        TbFreqMeioNCS.Text = "";
                        TbFreqFinalNCS.Text = "";
                        pr.SalvaConfigNCS(freqInicialNCS, freqMeioNCS, freqFinalNCS);
                    }
                    else
                    {
                        if (TbFreqInicialNCS.Text == "" & TbFreqMeioNCS.Text == "" & TbFreqFinalNCS.Text != "")
                        {
                            MessageBox.Show("Salvando novo valor para a frequencia final");
                            freqFinalNCS = TbFreqFinalNCS.Text;
                            LFreqFinalNCS.Text = "Atual:" + TbFreqFinalNCS.Text;
                            TbFreqInicialNCS.Text = "";
                            TbFreqMeioNCS.Text = "";
                            TbFreqFinalNCS.Text = "";
                            pr.SalvaConfigNCS(freqInicialNCS, freqMeioNCS, freqFinalNCS);
                        }
                        else
                        {
                            if (TbFreqInicialNCS.Text != "" & TbFreqMeioNCS.Text != "" & TbFreqFinalNCS.Text == "")
                            {
                                MessageBox.Show("Salvando novo valor para a frequencia inicial e central");
                                freqMeioNCS = TbFreqMeioNCS.Text;
                                LFreqMeioNCS.Text = "Atual:" + TbFreqMeioNCS.Text;
                                freqInicialNCS = TbFreqInicialNCS.Text;
                                LFreqInicialNCS.Text = "Atual:" + TbFreqInicialNCS.Text;
                                TbFreqInicialNCS.Text = "";
                                TbFreqMeioNCS.Text = "";
                                TbFreqFinalNCS.Text = "";
                                pr.SalvaConfigNCS(freqInicialNCS, freqMeioNCS, freqFinalNCS);
                            }
                            else
                            {
                                if (TbFreqInicialNCS.Text != "" & TbFreqMeioNCS.Text == "" & TbFreqFinalNCS.Text != "")
                                {
                                    MessageBox.Show("Salvando novo valor para a frequencia incial e final");
                                    freqFinalNCS = TbFreqFinalNCS.Text;
                                    LFreqFinalNCS.Text = "Atual:" + TbFreqFinalNCS.Text;
                                    freqInicialNCS = TbFreqInicialNCS.Text;
                                    LFreqInicialNCS.Text = "Atual:" + TbFreqInicialNCS.Text;
                                    TbFreqInicialNCS.Text = "";
                                    TbFreqMeioNCS.Text = "";
                                    TbFreqFinalNCS.Text = "";
                                    pr.SalvaConfigNCS(freqInicialNCS, freqMeioNCS, freqFinalNCS);
                                }
                                else
                                {
                                    if (TbFreqInicialNCS.Text == "" & TbFreqMeioNCS.Text != "" & TbFreqFinalNCS.Text != "")
                                    {
                                        MessageBox.Show("Salvando novo valor para a frequencia central e final");
                                        freqFinalNCS = TbFreqFinalNCS.Text;
                                        LFreqFinalNCS.Text = "Atual:" + TbFreqFinalNCS.Text;
                                        freqMeioNCS = TbFreqMeioNCS.Text;
                                        LFreqMeioNCS.Text = "Atual:" + TbFreqMeioNCS.Text;
                                        TbFreqInicialNCS.Text = "";
                                        TbFreqMeioNCS.Text = "";
                                        TbFreqFinalNCS.Text = "";
                                        pr.SalvaConfigNCS(freqInicialNCS, freqMeioNCS, freqFinalNCS);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Salvando novo valor para a frequencia central e final");
                                        freqFinalNCS = TbFreqFinalNCS.Text;
                                        LFreqFinalNCS.Text = "Atual:" + TbFreqFinalNCS.Text;
                                        freqMeioNCS = TbFreqMeioNCS.Text;
                                        LFreqMeioNCS.Text = "Atual:" + TbFreqMeioNCS.Text;
                                        freqInicialNCS = TbFreqInicialNCS.Text;
                                        LFreqInicialNCS.Text = "Atual:" + TbFreqInicialNCS.Text;
                                        TbFreqInicialNCS.Text = "";
                                        TbFreqMeioNCS.Text = "";
                                        TbFreqFinalNCS.Text = "";
                                        pr.SalvaConfigNCS(freqInicialNCS, freqMeioNCS, freqFinalNCS);
                                    }

                                }
                            }
                        }
                    }
                }
            }

        }

        public string GetRef()
        {
            return RefLevel;
        }

        public bool GetTPrints()
        {
            return CBPrints.Checked;
        }

        private void CBPrints_MouseClick(object sender, MouseEventArgs e)
        {
            pr = new Principal();
            if (CBPrints.Checked)
            {
                MessageBox.Show("Prints Ativados");
                pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
            }
            else
            {
                MessageBox.Show("Prints Desativados");
                pr.SalvaConfig(RefLevel, Att, CBPrints.Checked, marca);
            }
        }

        private void BtSalvarEspurios_Click(object sender, EventArgs e)
        {
            if (CBEspurios.SelectedItem.Equals("BlueTooth"))
            {
                if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text == "")
                {
                    MessageBox.Show("Por favor insira algum valor válido");
                }
                else
                {
                    if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text == "")
                    {
                        MessageBox.Show("Salvando novo valor para a frequencia inicial");
                        freqInicial = TbFreqInicialEspurios.Text;
                        LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                        TbFreqInicialEspurios.Text = "";
                        TbCanalInicialEspurios.Text = "";
                        TbFreqFinalEspurios.Text = "";
                        TbCanalFinalEspurios.Text = "";
                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                    }
                    else
                    {
                        if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text == "")
                        {
                            MessageBox.Show("Salvando novo valor para o canal inicial");
                            canalInicial = TbCanalInicialEspurios.Text;
                            LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                            TbFreqInicialEspurios.Text = "";
                            TbCanalInicialEspurios.Text = "";
                            TbFreqFinalEspurios.Text = "";
                            TbCanalFinalEspurios.Text = "";
                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                        }
                        else
                        {
                            if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                            {
                                MessageBox.Show("Salvando novo valor para a frequencia final");
                                freqFinal = TbFreqFinalEspurios.Text;
                                LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                TbFreqInicialEspurios.Text = "";
                                TbCanalInicialEspurios.Text = "";
                                TbFreqFinalEspurios.Text = "";
                                TbCanalFinalEspurios.Text = "";
                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                            }
                            else
                            {
                                if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text != "")
                                {
                                    MessageBox.Show("Salvando novo valor para o canal final");
                                    canalFinal = TbCanalFinalEspurios.Text;
                                    LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                    TbFreqInicialEspurios.Text = "";
                                    TbCanalInicialEspurios.Text = "";
                                    TbFreqFinalEspurios.Text = "";
                                    TbCanalFinalEspurios.Text = "";
                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                }
                                else
                                {
                                    if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text == "")
                                    {
                                        MessageBox.Show("Salvando novo valor para a frequencia inicial e o canal inicial");
                                        canalInicial = TbCanalInicialEspurios.Text;
                                        LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                        freqInicial = TbFreqInicialEspurios.Text;
                                        LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                        TbFreqInicialEspurios.Text = "";
                                        TbCanalInicialEspurios.Text = "";
                                        TbFreqFinalEspurios.Text = "";
                                        TbCanalFinalEspurios.Text = "";
                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                    }
                                    else
                                    {
                                        if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                                        {
                                            MessageBox.Show("Salvando novo valor para a frequencia inicial e frequencia final");
                                            freqFinal = TbFreqFinalEspurios.Text;
                                            LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                            freqInicial = TbFreqInicialEspurios.Text;
                                            LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                            TbFreqInicialEspurios.Text = "";
                                            TbCanalInicialEspurios.Text = "";
                                            TbFreqFinalEspurios.Text = "";
                                            TbCanalFinalEspurios.Text = "";
                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                        }
                                        else
                                        {
                                            if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text != "")
                                            {
                                                MessageBox.Show("Salvando novo valor para a frequencia inicial e o canal final");
                                                canalFinal = TbCanalFinalEspurios.Text;
                                                LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                freqInicial = TbFreqInicialEspurios.Text;
                                                LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                TbFreqInicialEspurios.Text = "";
                                                TbCanalInicialEspurios.Text = "";
                                                TbFreqFinalEspurios.Text = "";
                                                TbCanalFinalEspurios.Text = "";
                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                            }
                                            else
                                            {
                                                if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                                                {
                                                    MessageBox.Show("Salvando novo valor para o canal inicial e a frequencia final");
                                                    freqFinal = TbFreqFinalEspurios.Text;
                                                    LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                    canalInicial = TbCanalInicialEspurios.Text;
                                                    LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                    TbFreqInicialEspurios.Text = "";
                                                    TbCanalInicialEspurios.Text = "";
                                                    TbFreqFinalEspurios.Text = "";
                                                    TbCanalFinalEspurios.Text = "";
                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                }
                                                else
                                                {
                                                    if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text != "")
                                                    {
                                                        MessageBox.Show("Salvando novo valor para o canal inicial e o canal final");
                                                        canalFinal = TbCanalFinalEspurios.Text;
                                                        LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                        canalInicial = TbCanalInicialEspurios.Text;
                                                        LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                        TbFreqInicialEspurios.Text = "";
                                                        TbCanalInicialEspurios.Text = "";
                                                        TbFreqFinalEspurios.Text = "";
                                                        TbCanalFinalEspurios.Text = "";
                                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                    }
                                                    else
                                                    {
                                                        if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text != "")
                                                        {
                                                            MessageBox.Show("Salvando novo valor para a frequencia final e o canal final");
                                                            canalFinal = TbCanalFinalEspurios.Text;
                                                            LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                            freqFinal = TbFreqFinalEspurios.Text;
                                                            LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                            TbFreqInicialEspurios.Text = "";
                                                            TbCanalInicialEspurios.Text = "";
                                                            TbFreqFinalEspurios.Text = "";
                                                            TbCanalFinalEspurios.Text = "";
                                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                        }
                                                        else
                                                        {
                                                            if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                                                            {
                                                                MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e frequencia final");
                                                                freqFinal = TbFreqFinalEspurios.Text;
                                                                LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                canalInicial = TbCanalInicialEspurios.Text;
                                                                LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                TbFreqInicialEspurios.Text = "";
                                                                TbCanalInicialEspurios.Text = "";
                                                                TbFreqFinalEspurios.Text = "";
                                                                TbCanalFinalEspurios.Text = "";
                                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                            }
                                                            else
                                                            {
                                                                if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                                                                {
                                                                    MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e frequencia final");
                                                                    freqInicial = TbFreqInicialEspurios.Text;
                                                                    LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                                    canalInicial = TbCanalInicialEspurios.Text;
                                                                    LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                    freqFinal = TbFreqFinalEspurios.Text;
                                                                    LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                    TbFreqInicialEspurios.Text = "";
                                                                    TbCanalInicialEspurios.Text = "";
                                                                    TbFreqFinalEspurios.Text = "";
                                                                    TbCanalFinalEspurios.Text = "";
                                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                                }
                                                                else
                                                                {
                                                                    if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text != "")
                                                                    {
                                                                        MessageBox.Show("Salvando novo valor para o canal inicial, frequencia final e o canal final");
                                                                        canalFinal = TbCanalFinalEspurios.Text;
                                                                        LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                                        canalInicial = TbCanalInicialEspurios.Text;
                                                                        LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                        freqFinal = TbFreqFinalEspurios.Text;
                                                                        LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                        TbFreqInicialEspurios.Text = "";
                                                                        TbCanalInicialEspurios.Text = "";
                                                                        TbFreqFinalEspurios.Text = "";
                                                                        TbCanalFinalEspurios.Text = "";
                                                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text != "")
                                                                        {
                                                                            MessageBox.Show("Salvando novo valor para a frequencia inicial, frequencia final e canal final");
                                                                            freqInicial = TbFreqInicialEspurios.Text;
                                                                            LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                                            canalFinal = TbCanalFinalEspurios.Text;
                                                                            LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                                            freqFinal = TbFreqFinalEspurios.Text;
                                                                            LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                            TbFreqInicialEspurios.Text = "";
                                                                            TbCanalInicialEspurios.Text = "";
                                                                            TbFreqFinalEspurios.Text = "";
                                                                            TbCanalFinalEspurios.Text = "";
                                                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text != "")
                                                                            {
                                                                                MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e canal final");
                                                                                freqInicial = TbFreqInicialEspurios.Text;
                                                                                LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                                                canalFinal = TbCanalFinalEspurios.Text;
                                                                                LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                                                canalInicial = TbCanalInicialEspurios.Text;
                                                                                LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                                TbFreqInicialEspurios.Text = "";
                                                                                TbCanalInicialEspurios.Text = "";
                                                                                TbFreqFinalEspurios.Text = "";
                                                                                TbCanalFinalEspurios.Text = "";
                                                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text != "")
                                                                                {
                                                                                    MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial, frequencia final e para o canal final");
                                                                                    canalInicial = TbCanalInicialEspurios.Text;
                                                                                    LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                                    freqInicial = TbFreqInicialEspurios.Text;
                                                                                    LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                                                    canalFinal = TbCanalFinalEspurios.Text;
                                                                                    LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                                                    freqFinal = TbFreqFinalEspurios.Text;
                                                                                    LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                                    TbFreqInicialEspurios.Text = "";
                                                                                    TbCanalInicialEspurios.Text = "";
                                                                                    TbFreqFinalEspurios.Text = "";
                                                                                    TbCanalFinalEspurios.Text = "";
                                                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text == "")
                {
                    MessageBox.Show("Por favor insira algum valor válido");
                }
                else
                {
                    if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text == "")
                    {
                        MessageBox.Show("Salvando novo valor para a frequencia inicial");
                        freqInicial = TbFreqInicialEspurios.Text;
                        LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                        TbFreqInicialEspurios.Text = "";
                        TbCanalInicialEspurios.Text = "";
                        TbFreqFinalEspurios.Text = "";
                        TbCanalFinalEspurios.Text = "";
                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                    }
                    else
                    {
                        if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text == "")
                        {
                            MessageBox.Show("Salvando novo valor para o canal inicial");
                            canalInicial = TbCanalInicialEspurios.Text;
                            LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                            TbFreqInicialEspurios.Text = "";
                            TbCanalInicialEspurios.Text = "";
                            TbFreqFinalEspurios.Text = "";
                            TbCanalFinalEspurios.Text = "";
                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                        }
                        else
                        {
                            if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                            {
                                MessageBox.Show("Salvando novo valor para a frequencia final");
                                freqFinal = TbFreqFinalEspurios.Text;
                                LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                TbFreqInicialEspurios.Text = "";
                                TbCanalInicialEspurios.Text = "";
                                TbFreqFinalEspurios.Text = "";
                                TbCanalFinalEspurios.Text = "";
                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                            }
                            else
                            {
                                if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text != "")
                                {
                                    MessageBox.Show("Salvando novo valor para o canal final");
                                    canalFinal = TbCanalFinalEspurios.Text;
                                    LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                    TbFreqInicialEspurios.Text = "";
                                    TbCanalInicialEspurios.Text = "";
                                    TbFreqFinalEspurios.Text = "";
                                    TbCanalFinalEspurios.Text = "";
                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                }
                                else
                                {
                                    if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text == "")
                                    {
                                        MessageBox.Show("Salvando novo valor para a frequencia inicial e o canal inicial");
                                        canalInicial = TbCanalInicialEspurios.Text;
                                        LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                        freqInicial = TbFreqInicialEspurios.Text;
                                        LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                        TbFreqInicialEspurios.Text = "";
                                        TbCanalInicialEspurios.Text = "";
                                        TbFreqFinalEspurios.Text = "";
                                        TbCanalFinalEspurios.Text = "";
                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                    }
                                    else
                                    {
                                        if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                                        {
                                            MessageBox.Show("Salvando novo valor para a frequencia inicial e frequencia final");
                                            freqFinal = TbFreqFinalEspurios.Text;
                                            LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                            freqInicial = TbFreqInicialEspurios.Text;
                                            LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                            TbFreqInicialEspurios.Text = "";
                                            TbCanalInicialEspurios.Text = "";
                                            TbFreqFinalEspurios.Text = "";
                                            TbCanalFinalEspurios.Text = "";
                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                        }
                                        else
                                        {
                                            if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text != "")
                                            {
                                                MessageBox.Show("Salvando novo valor para a frequencia inicial e o canal final");
                                                canalFinal = TbCanalFinalEspurios.Text;
                                                LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                freqInicial = TbFreqInicialEspurios.Text;
                                                LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                TbFreqInicialEspurios.Text = "";
                                                TbCanalInicialEspurios.Text = "";
                                                TbFreqFinalEspurios.Text = "";
                                                TbCanalFinalEspurios.Text = "";
                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                            }
                                            else
                                            {
                                                if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                                                {
                                                    MessageBox.Show("Salvando novo valor para o canal inicial e a frequencia final");
                                                    freqFinal = TbFreqFinalEspurios.Text;
                                                    LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                    canalInicial = TbCanalInicialEspurios.Text;
                                                    LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                    TbFreqInicialEspurios.Text = "";
                                                    TbCanalInicialEspurios.Text = "";
                                                    TbFreqFinalEspurios.Text = "";
                                                    TbCanalFinalEspurios.Text = "";
                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                }
                                                else
                                                {
                                                    if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text != "")
                                                    {
                                                        MessageBox.Show("Salvando novo valor para o canal inicial e o canal final");
                                                        canalFinal = TbCanalFinalEspurios.Text;
                                                        LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                        canalInicial = TbCanalInicialEspurios.Text;
                                                        LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                        TbFreqInicialEspurios.Text = "";
                                                        TbCanalInicialEspurios.Text = "";
                                                        TbFreqFinalEspurios.Text = "";
                                                        TbCanalFinalEspurios.Text = "";
                                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                    }
                                                    else
                                                    {
                                                        if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text != "")
                                                        {
                                                            MessageBox.Show("Salvando novo valor para a frequencia final e o canal final");
                                                            canalFinal = TbCanalFinalEspurios.Text;
                                                            LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                            freqFinal = TbFreqFinalEspurios.Text;
                                                            LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                            TbFreqInicialEspurios.Text = "";
                                                            TbCanalInicialEspurios.Text = "";
                                                            TbFreqFinalEspurios.Text = "";
                                                            TbCanalFinalEspurios.Text = "";
                                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                        }
                                                        else
                                                        {
                                                            if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                                                            {
                                                                MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e frequencia final");
                                                                freqFinal = TbFreqFinalEspurios.Text;
                                                                LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                canalInicial = TbCanalInicialEspurios.Text;
                                                                LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                TbFreqInicialEspurios.Text = "";
                                                                TbCanalInicialEspurios.Text = "";
                                                                TbFreqFinalEspurios.Text = "";
                                                                TbCanalFinalEspurios.Text = "";
                                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                            }
                                                            else
                                                            {
                                                                if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text == "")
                                                                {
                                                                    MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e frequencia final");
                                                                    freqInicial = TbFreqInicialEspurios.Text;
                                                                    LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                                    canalInicial = TbCanalInicialEspurios.Text;
                                                                    LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                    freqFinal = TbFreqFinalEspurios.Text;
                                                                    LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                    TbFreqInicialEspurios.Text = "";
                                                                    TbCanalInicialEspurios.Text = "";
                                                                    TbFreqFinalEspurios.Text = "";
                                                                    TbCanalFinalEspurios.Text = "";
                                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                                }
                                                                else
                                                                {
                                                                    if (TbFreqInicialEspurios.Text == "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text != "")
                                                                    {
                                                                        MessageBox.Show("Salvando novo valor para o canal inicial, frequencia final e o canal final");
                                                                        canalFinal = TbCanalFinalEspurios.Text;
                                                                        LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                                        canalInicial = TbCanalInicialEspurios.Text;
                                                                        LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                        freqFinal = TbFreqFinalEspurios.Text;
                                                                        LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                        TbFreqInicialEspurios.Text = "";
                                                                        TbCanalInicialEspurios.Text = "";
                                                                        TbFreqFinalEspurios.Text = "";
                                                                        TbCanalFinalEspurios.Text = "";
                                                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text == "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text != "")
                                                                        {
                                                                            MessageBox.Show("Salvando novo valor para a frequencia inicial, frequencia final e canal final");
                                                                            freqInicial = TbFreqInicialEspurios.Text;
                                                                            LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                                            canalFinal = TbCanalFinalEspurios.Text;
                                                                            LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                                            freqFinal = TbFreqFinalEspurios.Text;
                                                                            LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                            TbFreqInicialEspurios.Text = "";
                                                                            TbCanalInicialEspurios.Text = "";
                                                                            TbFreqFinalEspurios.Text = "";
                                                                            TbCanalFinalEspurios.Text = "";
                                                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text == "" & TbCanalFinalEspurios.Text != "")
                                                                            {
                                                                                MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e canal final");
                                                                                freqInicial = TbFreqInicialEspurios.Text;
                                                                                LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                                                canalFinal = TbCanalFinalEspurios.Text;
                                                                                LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                                                canalInicial = TbCanalInicialEspurios.Text;
                                                                                LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                                TbFreqInicialEspurios.Text = "";
                                                                                TbCanalInicialEspurios.Text = "";
                                                                                TbFreqFinalEspurios.Text = "";
                                                                                TbCanalFinalEspurios.Text = "";
                                                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (TbFreqInicialEspurios.Text != "" & TbCanalInicialEspurios.Text != "" & TbFreqFinalEspurios.Text != "" & TbCanalFinalEspurios.Text != "")
                                                                                {
                                                                                    MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial, frequencia final e para o canal final");
                                                                                    canalInicial = TbCanalInicialEspurios.Text;
                                                                                    LCanalInicial.Text = "Atual:" + TbCanalInicialEspurios.Text;
                                                                                    freqInicial = TbFreqInicialEspurios.Text;
                                                                                    LFreqInicial.Text = "Atual:" + TbFreqInicialEspurios.Text;
                                                                                    canalFinal = TbCanalFinalEspurios.Text;
                                                                                    LCanalFinal.Text = "Atual:" + TbCanalFinalEspurios.Text;
                                                                                    freqFinal = TbFreqFinalEspurios.Text;
                                                                                    LFreqFinal.Text = "Atual:" + TbFreqFinalEspurios.Text;
                                                                                    TbFreqInicialEspurios.Text = "";
                                                                                    TbCanalInicialEspurios.Text = "";
                                                                                    TbFreqFinalEspurios.Text = "";
                                                                                    TbCanalFinalEspurios.Text = "";
                                                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public string GetMarca()
        {
            switch (CBModelos.SelectedItem.ToString())
            {
                case "N9010A":
                    return "Agilent";
                case "ESR":
                    return  "Rodhe";
                default:
                    return "NA";
            }
        }

        public string GetAtt()
        {
            return Att;
        }


        
        
    }
}
