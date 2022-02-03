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
    public partial class Item_10 : Form
    {
        Principal pr;
        public Item_10()
        {
            InitializeComponent();
            pr = new Principal();
            for (int i = 0; i < ListaEnsaiosItem10.Items.Count; i++)
            {
                ListaEnsaiosItem10.SetItemChecked(i, pr.CarregaEnsaios10(i));
            }
        }

        private void BtSelTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaEnsaiosItem10.Items.Count; i++)
            {
                ListaEnsaiosItem10.SetItemChecked(i, true);
            }
        }
        public int GetQuantidadeEnsaios()
        {
            return ListaEnsaiosItem10.CheckedItems.Count;
        }

        public object GetEnsaios(int i)
        {
            return ListaEnsaiosItem10.CheckedItems[i];
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaEnsaiosItem10.Items.Count; i++)
            {
                ListaEnsaiosItem10.SetItemChecked(i, false);
            }
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            Principal pr;
            pr = new Principal();
            for (int i = 0; i < ListaEnsaiosItem10.Items.Count; i++)
            {
                pr.SalvaEnsaios10(ListaEnsaiosItem10.GetItemChecked(i), i);
            }
            MessageBox.Show("Valores salvos");
        }
    }
}
