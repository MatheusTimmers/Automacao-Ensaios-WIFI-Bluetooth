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
        public string  RefLevel, Att;
        public Configurações()
        {
            InitializeComponent();
            pr = new Principal();
            RefLevel = pr.CarregaRefLevel();
            Att = pr.CarregaAtt();
            CBPrints.Checked = pr.CarregaAPrints();
            LValorAtualRLevel.Text = "Atual:" + RefLevel;
            LValorAtualAtt.Text = "Atual:" + Att; ;
            TextBoxAtt.Text = "";
            TextBoxRefLevel.Text = "";
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            pr = new Principal();
            if (TextBoxRefLevel.Text == "" & TextBoxAtt.Text == "")
            {
                MessageBox.Show("Por favor insira valores válidos");
            }
            else
            {
                if (TextBoxRefLevel.Text != "" & TextBoxAtt.Text == "")
                {
                    MessageBox.Show("Salvando novo valor para o Reference Level");
                    RefLevel = TextBoxRefLevel.Text;
                    LValorAtualRLevel.Text = "Atual:" + TextBoxRefLevel.Text;
                    TextBoxAtt.Text = "";
                    TextBoxRefLevel.Text = "";
                    pr.SalvaConfig(RefLevel, Att, CBPrints.Checked);
                }
                else
                {
                    if (TextBoxRefLevel.Text == "" & TextBoxAtt.Text != "")
                    {
                        MessageBox.Show("Salvando novo valor para a Attenuation");
                        Att = TextBoxAtt.Text;
                        LValorAtualAtt.Text = "Atual:" + TextBoxAtt.Text;
                        TextBoxAtt.Text = "";
                        TextBoxRefLevel.Text = "";
                        pr.SalvaConfig(RefLevel, Att, CBPrints.Checked);
                    }
                    else
                    {
                        MessageBox.Show("Salvando os novos valores!");
                        RefLevel = TextBoxRefLevel.Text;
                        Att = TextBoxAtt.Text;
                        LValorAtualRLevel.Text = "Atual:" + TextBoxRefLevel.Text;
                        LValorAtualAtt.Text = "Atual:" + TextBoxAtt.Text;
                        TextBoxAtt.Text = "";
                        TextBoxRefLevel.Text = "";
                        pr.SalvaConfig(RefLevel, Att, CBPrints.Checked);
                    }
                }
            }
        }

        public string GetRef()
        {
            return RefLevel;
        }



        private void CBPrints_MouseClick(object sender, MouseEventArgs e)
        {
            pr = new Principal();
            if (CBPrints.Checked)
            {
                MessageBox.Show("Prints Ativados");
                pr.pega("PRINTS ATIVADOS");
                pr.SalvaConfig(RefLevel, Att, CBPrints.Checked);
            }
            else
            {
                MessageBox.Show("Prints Desativados");
                pr.pega("PRINTS DESATIVADOS");
                //pr.SalvaConfig(RefLevel, Att, CBPrints.Checked);
            }
        }


        public string GetAtt()
        {
            return Att;
        }


        
        
    }
}
