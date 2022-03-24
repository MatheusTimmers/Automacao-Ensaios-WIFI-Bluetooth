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
        public string RefLevel, Att, marca, freqInicial, freqFinal, canalInicial, canalFinal;
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
            CBPrints.Checked = pr.CarregaAPrints();
            LValorAtualRLevel.Text = "Atual:" + RefLevel;
            LValorAtualAtt.Text = "Atual:" + Att; ;
            LFreqFinal.Text = "Atual:" + freqFinal;
            LCanalFinal.Text = "Atual:" + canalFinal;
            LCanalInicial.Text = "Atual:" + canalInicial;
            LFreqInicial.Text = "Atual:" + freqInicial;
            TextBoxAtt.Text = "";
            TextBoxRefLevel.Text = "";
            TbFreqFinal.Text = "";
            TbCanalInicial.Text = "";
            TbFreqFinal.Text = "";
            TbCanalFinal.Text = "";
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
                        if (TextBoxRefLevel.Text == "" & TextBoxAtt.Text == "" & CBModelos.SelectedIndex == -1)
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
                if (TbFreqInicial.Text == "" & TbCanalInicial.Text == "" & TbFreqFinal.Text == "" & TbCanalFinal.Text == "")
                {
                    MessageBox.Show("Por favor insira algum valor válido");
                }
                else
                {
                    if (TbFreqInicial.Text != "" & TbCanalInicial.Text == "" & TbFreqFinal.Text == "" & TbCanalFinal.Text == "")
                    {
                        MessageBox.Show("Salvando novo valor para a frequencia inicial");
                        freqInicial = TbFreqInicial.Text;
                        LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                        TbFreqInicial.Text = "";
                        TbCanalInicial.Text = "";
                        TbFreqFinal.Text = "";
                        TbCanalFinal.Text = "";
                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                    }
                    else
                    {
                        if (TbFreqInicial.Text == "" & TbCanalInicial.Text != "" & TbFreqFinal.Text == "" & TbCanalFinal.Text == "")
                        {
                            MessageBox.Show("Salvando novo valor para o canal inicial");
                            canalInicial = TbCanalInicial.Text;
                            LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                            TbFreqInicial.Text = "";
                            TbCanalInicial.Text = "";
                            TbFreqFinal.Text = "";
                            TbCanalFinal.Text = "";
                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                        }
                        else
                        {
                            if (TbFreqInicial.Text == "" & TbCanalInicial.Text == "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                            {
                                MessageBox.Show("Salvando novo valor para a frequencia final");
                                freqFinal = TbFreqFinal.Text;
                                LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                TbFreqInicial.Text = "";
                                TbCanalInicial.Text = "";
                                TbFreqFinal.Text = "";
                                TbCanalFinal.Text = "";
                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                            }
                            else
                            {
                                if (TbFreqInicial.Text == "" & TbCanalInicial.Text == "" & TbFreqFinal.Text == "" & TbCanalFinal.Text != "")
                                {
                                    MessageBox.Show("Salvando novo valor para o canal final");
                                    canalFinal = TbCanalFinal.Text;
                                    LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                    TbFreqInicial.Text = "";
                                    TbCanalInicial.Text = "";
                                    TbFreqFinal.Text = "";
                                    TbCanalFinal.Text = "";
                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                }
                                else
                                {
                                    if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text == "" & TbCanalFinal.Text == "")
                                    {
                                        MessageBox.Show("Salvando novo valor para a frequencia inicial e o canal inicial");
                                        canalInicial = TbCanalInicial.Text;
                                        LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                        freqInicial = TbFreqInicial.Text;
                                        LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                        TbFreqInicial.Text = "";
                                        TbCanalInicial.Text = "";
                                        TbFreqFinal.Text = "";
                                        TbCanalFinal.Text = "";
                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                    }
                                    else
                                    {
                                        if (TbFreqInicial.Text != "" & TbCanalInicial.Text == "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                                        {
                                            MessageBox.Show("Salvando novo valor para a frequencia inicial e frequencia final");
                                            freqFinal = TbFreqFinal.Text;
                                            LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                            freqInicial = TbFreqInicial.Text;
                                            LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                            TbFreqInicial.Text = "";
                                            TbCanalInicial.Text = "";
                                            TbFreqFinal.Text = "";
                                            TbCanalFinal.Text = "";
                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                        }
                                        else
                                        {
                                            if (TbFreqInicial.Text != "" & TbCanalInicial.Text == "" & TbFreqFinal.Text == "" & TbCanalFinal.Text != "")
                                            {
                                                MessageBox.Show("Salvando novo valor para a frequencia inicial e o canal final");
                                                canalFinal = TbCanalFinal.Text;
                                                LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                freqInicial = TbFreqInicial.Text;
                                                LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                TbFreqInicial.Text = "";
                                                TbCanalInicial.Text = "";
                                                TbFreqFinal.Text = "";
                                                TbCanalFinal.Text = "";
                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                            }
                                            else
                                            {
                                                if (TbFreqInicial.Text == "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                                                {
                                                    MessageBox.Show("Salvando novo valor para o canal inicial e a frequencia final");
                                                    freqFinal = TbFreqFinal.Text;
                                                    LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                    canalInicial = TbCanalInicial.Text;
                                                    LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                    TbFreqInicial.Text = "";
                                                    TbCanalInicial.Text = "";
                                                    TbFreqFinal.Text = "";
                                                    TbCanalFinal.Text = "";
                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                }
                                                else
                                                {
                                                    if (TbFreqInicial.Text == "" & TbCanalInicial.Text != "" & TbFreqFinal.Text == "" & TbCanalFinal.Text != "")
                                                    {
                                                        MessageBox.Show("Salvando novo valor para o canal inicial e o canal final");
                                                        canalFinal = TbCanalFinal.Text;
                                                        LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                        canalInicial = TbCanalInicial.Text;
                                                        LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                        TbFreqInicial.Text = "";
                                                        TbCanalInicial.Text = "";
                                                        TbFreqFinal.Text = "";
                                                        TbCanalFinal.Text = "";
                                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                    }
                                                    else
                                                    {
                                                        if (TbFreqInicial.Text == "" & TbCanalInicial.Text == "" & TbFreqFinal.Text != "" & TbCanalFinal.Text != "")
                                                        {
                                                            MessageBox.Show("Salvando novo valor para a frequencia final e o canal final");
                                                            canalFinal = TbCanalFinal.Text;
                                                            LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                            freqFinal = TbFreqFinal.Text;
                                                            LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                            TbFreqInicial.Text = "";
                                                            TbCanalInicial.Text = "";
                                                            TbFreqFinal.Text = "";
                                                            TbCanalFinal.Text = "";
                                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                        }
                                                        else
                                                        {
                                                            if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                                                            {
                                                                MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e frequencia final");
                                                                freqFinal = TbFreqFinal.Text;
                                                                LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                canalInicial = TbCanalInicial.Text;
                                                                LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                TbFreqInicial.Text = "";
                                                                TbCanalInicial.Text = "";
                                                                TbFreqFinal.Text = "";
                                                                TbCanalFinal.Text = "";
                                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                            }
                                                            else
                                                            {
                                                                if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                                                                {
                                                                    MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e frequencia final");
                                                                    freqInicial = TbFreqInicial.Text;
                                                                    LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                                    canalInicial = TbCanalInicial.Text;
                                                                    LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                    freqFinal = TbFreqFinal.Text;
                                                                    LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                    TbFreqInicial.Text = "";
                                                                    TbCanalInicial.Text = "";
                                                                    TbFreqFinal.Text = "";
                                                                    TbCanalFinal.Text = "";
                                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                                }
                                                                else
                                                                {
                                                                    if (TbFreqInicial.Text == "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text != "")
                                                                    {
                                                                        MessageBox.Show("Salvando novo valor para o canal inicial, frequencia final e o canal final");
                                                                        canalFinal = TbCanalFinal.Text;
                                                                        LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                                        canalInicial = TbCanalInicial.Text;
                                                                        LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                        freqFinal = TbFreqFinal.Text;
                                                                        LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                        TbFreqInicial.Text = "";
                                                                        TbCanalInicial.Text = "";
                                                                        TbFreqFinal.Text = "";
                                                                        TbCanalFinal.Text = "";
                                                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (TbFreqInicial.Text != "" & TbCanalInicial.Text == "" & TbFreqFinal.Text != "" & TbCanalFinal.Text != "")
                                                                        {
                                                                            MessageBox.Show("Salvando novo valor para a frequencia inicial, frequencia final e canal final");
                                                                            freqInicial = TbFreqInicial.Text;
                                                                            LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                                            canalFinal = TbCanalFinal.Text;
                                                                            LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                                            freqFinal = TbFreqFinal.Text;
                                                                            LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                            TbFreqInicial.Text = "";
                                                                            TbCanalInicial.Text = "";
                                                                            TbFreqFinal.Text = "";
                                                                            TbCanalFinal.Text = "";
                                                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text == "" & TbCanalFinal.Text != "")
                                                                            {
                                                                                MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e canal final");
                                                                                freqInicial = TbFreqInicial.Text;
                                                                                LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                                                canalFinal = TbCanalFinal.Text;
                                                                                LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                                                canalInicial = TbCanalInicial.Text;
                                                                                LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                                TbFreqInicial.Text = "";
                                                                                TbCanalInicial.Text = "";
                                                                                TbFreqFinal.Text = "";
                                                                                TbCanalFinal.Text = "";
                                                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text != "")
                                                                                {
                                                                                    MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial, frequencia final e para o canal final");
                                                                                    canalInicial = TbCanalInicial.Text;
                                                                                    LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                                    freqInicial = TbFreqInicial.Text;
                                                                                    LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                                                    canalFinal = TbCanalFinal.Text;
                                                                                    LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                                                    freqFinal = TbFreqFinal.Text;
                                                                                    LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                                    TbFreqInicial.Text = "";
                                                                                    TbCanalInicial.Text = "";
                                                                                    TbFreqFinal.Text = "";
                                                                                    TbCanalFinal.Text = "";
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
                if (TbFreqInicial.Text == "" & TbCanalInicial.Text == "" & TbFreqFinal.Text == "" & TbCanalFinal.Text == "")
                {
                    MessageBox.Show("Por favor insira algum valor válido");
                }
                else
                {
                    if (TbFreqInicial.Text != "" & TbCanalInicial.Text == "" & TbFreqFinal.Text == "" & TbCanalFinal.Text == "")
                    {
                        MessageBox.Show("Salvando novo valor para a frequencia inicial");
                        freqInicial = TbFreqInicial.Text;
                        LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                        TbFreqInicial.Text = "";
                        TbCanalInicial.Text = "";
                        TbFreqFinal.Text = "";
                        TbCanalFinal.Text = "";
                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                    }
                    else
                    {
                        if (TbFreqInicial.Text == "" & TbCanalInicial.Text != "" & TbFreqFinal.Text == "" & TbCanalFinal.Text == "")
                        {
                            MessageBox.Show("Salvando novo valor para o canal inicial");
                            canalInicial = TbCanalInicial.Text;
                            LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                            TbFreqInicial.Text = "";
                            TbCanalInicial.Text = "";
                            TbFreqFinal.Text = "";
                            TbCanalFinal.Text = "";
                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                        }
                        else
                        {
                            if (TbFreqInicial.Text == "" & TbCanalInicial.Text == "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                            {
                                MessageBox.Show("Salvando novo valor para a frequencia final");
                                freqFinal = TbFreqFinal.Text;
                                LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                TbFreqInicial.Text = "";
                                TbCanalInicial.Text = "";
                                TbFreqFinal.Text = "";
                                TbCanalFinal.Text = "";
                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                            }
                            else
                            {
                                if (TbFreqInicial.Text == "" & TbCanalInicial.Text == "" & TbFreqFinal.Text == "" & TbCanalFinal.Text != "")
                                {
                                    MessageBox.Show("Salvando novo valor para o canal final");
                                    canalFinal = TbCanalFinal.Text;
                                    LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                    TbFreqInicial.Text = "";
                                    TbCanalInicial.Text = "";
                                    TbFreqFinal.Text = "";
                                    TbCanalFinal.Text = "";
                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                }
                                else
                                {
                                    if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text == "" & TbCanalFinal.Text == "")
                                    {
                                        MessageBox.Show("Salvando novo valor para a frequencia inicial e o canal inicial");
                                        canalInicial = TbCanalInicial.Text;
                                        LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                        freqInicial = TbFreqInicial.Text;
                                        LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                        TbFreqInicial.Text = "";
                                        TbCanalInicial.Text = "";
                                        TbFreqFinal.Text = "";
                                        TbCanalFinal.Text = "";
                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                    }
                                    else
                                    {
                                        if (TbFreqInicial.Text != "" & TbCanalInicial.Text == "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                                        {
                                            MessageBox.Show("Salvando novo valor para a frequencia inicial e frequencia final");
                                            freqFinal = TbFreqFinal.Text;
                                            LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                            freqInicial = TbFreqInicial.Text;
                                            LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                            TbFreqInicial.Text = "";
                                            TbCanalInicial.Text = "";
                                            TbFreqFinal.Text = "";
                                            TbCanalFinal.Text = "";
                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                        }
                                        else
                                        {
                                            if (TbFreqInicial.Text != "" & TbCanalInicial.Text == "" & TbFreqFinal.Text == "" & TbCanalFinal.Text != "")
                                            {
                                                MessageBox.Show("Salvando novo valor para a frequencia inicial e o canal final");
                                                canalFinal = TbCanalFinal.Text;
                                                LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                freqInicial = TbFreqInicial.Text;
                                                LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                TbFreqInicial.Text = "";
                                                TbCanalInicial.Text = "";
                                                TbFreqFinal.Text = "";
                                                TbCanalFinal.Text = "";
                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                            }
                                            else
                                            {
                                                if (TbFreqInicial.Text == "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                                                {
                                                    MessageBox.Show("Salvando novo valor para o canal inicial e a frequencia final");
                                                    freqFinal = TbFreqFinal.Text;
                                                    LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                    canalInicial = TbCanalInicial.Text;
                                                    LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                    TbFreqInicial.Text = "";
                                                    TbCanalInicial.Text = "";
                                                    TbFreqFinal.Text = "";
                                                    TbCanalFinal.Text = "";
                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                }
                                                else
                                                {
                                                    if (TbFreqInicial.Text == "" & TbCanalInicial.Text != "" & TbFreqFinal.Text == "" & TbCanalFinal.Text != "")
                                                    {
                                                        MessageBox.Show("Salvando novo valor para o canal inicial e o canal final");
                                                        canalFinal = TbCanalFinal.Text;
                                                        LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                        canalInicial = TbCanalInicial.Text;
                                                        LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                        TbFreqInicial.Text = "";
                                                        TbCanalInicial.Text = "";
                                                        TbFreqFinal.Text = "";
                                                        TbCanalFinal.Text = "";
                                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                    }
                                                    else
                                                    {
                                                        if (TbFreqInicial.Text == "" & TbCanalInicial.Text == "" & TbFreqFinal.Text != "" & TbCanalFinal.Text != "")
                                                        {
                                                            MessageBox.Show("Salvando novo valor para a frequencia final e o canal final");
                                                            canalFinal = TbCanalFinal.Text;
                                                            LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                            freqFinal = TbFreqFinal.Text;
                                                            LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                            TbFreqInicial.Text = "";
                                                            TbCanalInicial.Text = "";
                                                            TbFreqFinal.Text = "";
                                                            TbCanalFinal.Text = "";
                                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                        }
                                                        else
                                                        {
                                                            if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                                                            {
                                                                MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e frequencia final");
                                                                freqFinal = TbFreqFinal.Text;
                                                                LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                canalInicial = TbCanalInicial.Text;
                                                                LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                TbFreqInicial.Text = "";
                                                                TbCanalInicial.Text = "";
                                                                TbFreqFinal.Text = "";
                                                                TbCanalFinal.Text = "";
                                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                            }
                                                            else
                                                            {
                                                                if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text == "")
                                                                {
                                                                    MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e frequencia final");
                                                                    freqInicial = TbFreqInicial.Text;
                                                                    LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                                    canalInicial = TbCanalInicial.Text;
                                                                    LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                    freqFinal = TbFreqFinal.Text;
                                                                    LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                    TbFreqInicial.Text = "";
                                                                    TbCanalInicial.Text = "";
                                                                    TbFreqFinal.Text = "";
                                                                    TbCanalFinal.Text = "";
                                                                    pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);

                                                                }
                                                                else
                                                                {
                                                                    if (TbFreqInicial.Text == "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text != "")
                                                                    {
                                                                        MessageBox.Show("Salvando novo valor para o canal inicial, frequencia final e o canal final");
                                                                        canalFinal = TbCanalFinal.Text;
                                                                        LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                                        canalInicial = TbCanalInicial.Text;
                                                                        LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                        freqFinal = TbFreqFinal.Text;
                                                                        LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                        TbFreqInicial.Text = "";
                                                                        TbCanalInicial.Text = "";
                                                                        TbFreqFinal.Text = "";
                                                                        TbCanalFinal.Text = "";
                                                                        pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (TbFreqInicial.Text != "" & TbCanalInicial.Text == "" & TbFreqFinal.Text != "" & TbCanalFinal.Text != "")
                                                                        {
                                                                            MessageBox.Show("Salvando novo valor para a frequencia inicial, frequencia final e canal final");
                                                                            freqInicial = TbFreqInicial.Text;
                                                                            LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                                            canalFinal = TbCanalFinal.Text;
                                                                            LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                                            freqFinal = TbFreqFinal.Text;
                                                                            LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                            TbFreqInicial.Text = "";
                                                                            TbCanalInicial.Text = "";
                                                                            TbFreqFinal.Text = "";
                                                                            TbCanalFinal.Text = "";
                                                                            pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text == "" & TbCanalFinal.Text != "")
                                                                            {
                                                                                MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial e canal final");
                                                                                freqInicial = TbFreqInicial.Text;
                                                                                LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                                                canalFinal = TbCanalFinal.Text;
                                                                                LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                                                canalInicial = TbCanalInicial.Text;
                                                                                LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                                TbFreqInicial.Text = "";
                                                                                TbCanalInicial.Text = "";
                                                                                TbFreqFinal.Text = "";
                                                                                TbCanalFinal.Text = "";
                                                                                pr.SalvaConfigEspurios(CBEspurios.SelectedItem.ToString(), freqInicial, freqFinal, canalInicial, canalFinal);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (TbFreqInicial.Text != "" & TbCanalInicial.Text != "" & TbFreqFinal.Text != "" & TbCanalFinal.Text != "")
                                                                                {
                                                                                    MessageBox.Show("Salvando novo valor para a frequencia inicial, canal inicial, frequencia final e para o canal final");
                                                                                    canalInicial = TbCanalInicial.Text;
                                                                                    LCanalInicial.Text = "Atual:" + TbCanalInicial.Text;
                                                                                    freqInicial = TbFreqInicial.Text;
                                                                                    LFreqInicial.Text = "Atual:" + TbFreqInicial.Text;
                                                                                    canalFinal = TbCanalFinal.Text;
                                                                                    LCanalFinal.Text = "Atual:" + TbCanalFinal.Text;
                                                                                    freqFinal = TbFreqFinal.Text;
                                                                                    LFreqFinal.Text = "Atual:" + TbFreqFinal.Text;
                                                                                    TbFreqInicial.Text = "";
                                                                                    TbCanalInicial.Text = "";
                                                                                    TbFreqFinal.Text = "";
                                                                                    TbCanalFinal.Text = "";
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
