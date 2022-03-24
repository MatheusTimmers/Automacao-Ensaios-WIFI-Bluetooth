
namespace Automacao_N9010A
{
    partial class Item_10
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtSalvar = new System.Windows.Forms.Button();
            this.BtLimpar = new System.Windows.Forms.Button();
            this.BtSelTodos = new System.Windows.Forms.Button();
            this.ListaEnsaiosItem10 = new System.Windows.Forms.CheckedListBox();
            this.LEnsaiosItem10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtSalvar
            // 
            this.BtSalvar.Location = new System.Drawing.Point(276, 191);
            this.BtSalvar.Name = "BtSalvar";
            this.BtSalvar.Size = new System.Drawing.Size(120, 40);
            this.BtSalvar.TabIndex = 15;
            this.BtSalvar.Text = "Salvar";
            this.BtSalvar.UseVisualStyleBackColor = true;
            this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // BtLimpar
            // 
            this.BtLimpar.Location = new System.Drawing.Point(144, 191);
            this.BtLimpar.Name = "BtLimpar";
            this.BtLimpar.Size = new System.Drawing.Size(120, 40);
            this.BtLimpar.TabIndex = 14;
            this.BtLimpar.Text = "Limpar";
            this.BtLimpar.UseVisualStyleBackColor = true;
            this.BtLimpar.Click += new System.EventHandler(this.BtLimpar_Click);
            // 
            // BtSelTodos
            // 
            this.BtSelTodos.Location = new System.Drawing.Point(13, 191);
            this.BtSelTodos.Name = "BtSelTodos";
            this.BtSelTodos.Size = new System.Drawing.Size(120, 40);
            this.BtSelTodos.TabIndex = 13;
            this.BtSelTodos.Text = "Selecionar Todos";
            this.BtSelTodos.UseVisualStyleBackColor = true;
            this.BtSelTodos.Click += new System.EventHandler(this.BtSelTodos_Click);
            // 
            // ListaEnsaiosItem10
            // 
            this.ListaEnsaiosItem10.FormattingEnabled = true;
            this.ListaEnsaiosItem10.Items.AddRange(new object[] {
            "Largura de Faixa a 20 dB",
            "Potência de pico máxima",
            "Emissão Fora de Faixa",
            "Separação de Canais de Salto",
            "Numero de Frequencia de Salto",
            "Numero de Ocupações",
            "Tempo de Ocupação"});
            this.ListaEnsaiosItem10.Location = new System.Drawing.Point(13, 55);
            this.ListaEnsaiosItem10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ListaEnsaiosItem10.Name = "ListaEnsaiosItem10";
            this.ListaEnsaiosItem10.Size = new System.Drawing.Size(383, 130);
            this.ListaEnsaiosItem10.TabIndex = 12;
            // 
            // LEnsaiosItem10
            // 
            this.LEnsaiosItem10.AutoSize = true;
            this.LEnsaiosItem10.BackColor = System.Drawing.Color.Transparent;
            this.LEnsaiosItem10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LEnsaiosItem10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LEnsaiosItem10.Location = new System.Drawing.Point(13, 9);
            this.LEnsaiosItem10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LEnsaiosItem10.Name = "LEnsaiosItem10";
            this.LEnsaiosItem10.Size = new System.Drawing.Size(383, 32);
            this.LEnsaiosItem10.TabIndex = 11;
            this.LEnsaiosItem10.Text = "Ensaios para Equipamentos com Salto em Frequência (FHSS).\r\nItem 10 da norma 237.";
            // 
            // Item_10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(405, 237);
            this.Controls.Add(this.BtSalvar);
            this.Controls.Add(this.BtLimpar);
            this.Controls.Add(this.BtSelTodos);
            this.Controls.Add(this.ListaEnsaiosItem10);
            this.Controls.Add(this.LEnsaiosItem10);
            this.MaximizeBox = false;
            this.Name = "Item_10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_10";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtSalvar;
        private System.Windows.Forms.Button BtLimpar;
        private System.Windows.Forms.Button BtSelTodos;
        private System.Windows.Forms.CheckedListBox ListaEnsaiosItem10;
        private System.Windows.Forms.Label LEnsaiosItem10;
    }
}