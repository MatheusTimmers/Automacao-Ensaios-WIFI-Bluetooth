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
    public partial class Item_11 : Form
    {
        public Item_11()
        {
            InitializeComponent();
        }

        public int GetQuantidadeEnsaios()
        {
            return ListaEnsaiosItem11.CheckedItems.Count;
        }

        public object GetEnsaios(int i)
        {
            return ListaEnsaiosItem11.CheckedItems[i];
        }

        

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaEnsaiosItem11.Items.Count; i++)
            {
                ListaEnsaiosItem11.SetItemChecked(i, false);
            }
        }

        private void BtSelTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaEnsaiosItem11.Items.Count; i++)
            {
                ListaEnsaiosItem11.SetItemChecked(i, true);
            }
        }
    }
}
