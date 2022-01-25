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
            Principal pr;
            pr = new Principal();
            for (int i = 0; i < ListaEnsaiosItem11.Items.Count; i++)
            {
                if (pr.CarregaEnsaios11(i) == 1)
                {
                    ListaEnsaiosItem11.SetItemChecked(i, true);
                }
                else
                {
                    ListaEnsaiosItem11.SetItemChecked(i, false);
                }
            }
        }


        public int GetQuantidadeEnsaios()
        {
            return ListaEnsaiosItem11.CheckedItems.Count;
        }

        public object GetEnsaios(int i)
        {
            return ListaEnsaiosItem11.CheckedItems[i];
        }

        public int GetEstadoEnsaios(int i)
        {
            if (ListaEnsaiosItem11.GetItemChecked(i))
            {
                return 1;
            }
            else
            {
                return 0;
            }
                
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

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            
            Principal pr;
            pr = new Principal();
            pr.SalvaEnsaios11();
            MessageBox.Show("Valores salvos");
            
         

        }
    }
}
