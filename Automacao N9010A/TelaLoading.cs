﻿using System;
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
    public partial class TelaLoading : Form
    {
        public TelaLoading()
        {
            InitializeComponent();
        }

        public void SetValorPB(int valor)
        {
            Application.DoEvents();
            PbEnsaioEmAndamento.Value += valor;
            Application.DoEvents();

        }

        private void TelaLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PbEnsaioEmAndamento.Value != 100)
            {
                MessageBox.Show("Ensaio em Andamento");
                e.Cancel = true;
            }
        }
    }
}
