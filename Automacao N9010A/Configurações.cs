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
        public string RefLevel, Att, marca;
        public Configurações()
        {
            InitializeComponent();
            pr = new Principal();
            RefLevel = pr.CarregaRefLevel();
            Att = pr.CarregaAtt();
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
            TextBoxAtt.Text = "";
            TextBoxRefLevel.Text = "";
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
