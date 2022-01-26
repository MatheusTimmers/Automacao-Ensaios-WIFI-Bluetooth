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

        public string  RefLevel, Att;
        public Configurações()
        {
            InitializeComponent();
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
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
                    }
                }
            }
        }

        public string GetRef()
        {
            return RefLevel;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public string GetAtt()
        {
            return Att;
        }


        
        
    }
}
