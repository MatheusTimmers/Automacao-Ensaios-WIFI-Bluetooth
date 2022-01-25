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
    public partial class Item_12 : Form
    {
        bool[] ensaiosSalvos = new bool[3];

        public Item_12()
        {
            InitializeComponent();

            for (int i = 0; i < ListaEnsaiosItem12.Items.Count; i++)
            {
                ListaEnsaiosItem12.SetItemChecked(i, ensaiosSalvos[i]);
            }

        }

        private void BtSelTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaEnsaiosItem12.Items.Count; i++)
            {
                ListaEnsaiosItem12.SetItemChecked(i, true);
            }
            
        }

        public int GetQuantidadeEnsaios()
        {
            return ListaEnsaiosItem12.CheckedItems.Count;
        }

        public object GetEnsaios(int i)
        {
            return ListaEnsaiosItem12.CheckedItems[i];
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaEnsaiosItem12.Items.Count; i++)
            {
                ListaEnsaiosItem12.SetItemChecked(i, false);
            }
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaEnsaiosItem12.Items.Count; i++)
            {

                ensaiosSalvos[i] = ListaEnsaiosItem12.GetItemChecked(i);
            }
            MessageBox.Show("Valores salvos");
        }
    }
}
