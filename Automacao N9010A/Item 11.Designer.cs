
namespace Automacao_N9010A
{
    partial class Item_11
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
            this.LEnsaiosItem11 = new System.Windows.Forms.Label();
            this.ListaEnsaiosItem11 = new System.Windows.Forms.CheckedListBox();
            this.BtSelTodos = new System.Windows.Forms.Button();
            this.BtLimpar = new System.Windows.Forms.Button();
            this.BtSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LEnsaiosItem11
            // 
            this.LEnsaiosItem11.AutoSize = true;
            this.LEnsaiosItem11.BackColor = System.Drawing.Color.Transparent;
            this.LEnsaiosItem11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LEnsaiosItem11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LEnsaiosItem11.Location = new System.Drawing.Point(13, 22);
            this.LEnsaiosItem11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LEnsaiosItem11.Name = "LEnsaiosItem11";
            this.LEnsaiosItem11.Size = new System.Drawing.Size(294, 32);
            this.LEnsaiosItem11.TabIndex = 5;
            this.LEnsaiosItem11.Text = "Ensaios para 2400-2483,5MHz e 5725-5850MHz. \r\nItem 11 da norma 6506.";
            // 
            // ListaEnsaiosItem11
            // 
            this.ListaEnsaiosItem11.FormattingEnabled = true;
            this.ListaEnsaiosItem11.Items.AddRange(new object[] {
            "Largura de faixa a 6 dB",
            "Largura de faixa a 26 dB",
            "Potência de pico máxima",
            "Valor médio da potência máxima de saída",
            "Pico da densidade de potência",
            "Valor médio da densidade espectral de potência",
            "Emissão fora da faixa"});
            this.ListaEnsaiosItem11.Location = new System.Drawing.Point(13, 68);
            this.ListaEnsaiosItem11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ListaEnsaiosItem11.Name = "ListaEnsaiosItem11";
            this.ListaEnsaiosItem11.Size = new System.Drawing.Size(306, 130);
            this.ListaEnsaiosItem11.TabIndex = 4;
            // 
            // BtSelTodos
            // 
            this.BtSelTodos.Location = new System.Drawing.Point(13, 204);
            this.BtSelTodos.Name = "BtSelTodos";
            this.BtSelTodos.Size = new System.Drawing.Size(100, 40);
            this.BtSelTodos.TabIndex = 6;
            this.BtSelTodos.Text = "Selecionar Todos";
            this.BtSelTodos.UseVisualStyleBackColor = true;
            this.BtSelTodos.Click += new System.EventHandler(this.BtSelTodos_Click);
            // 
            // BtLimpar
            // 
            this.BtLimpar.Location = new System.Drawing.Point(116, 204);
            this.BtLimpar.Name = "BtLimpar";
            this.BtLimpar.Size = new System.Drawing.Size(100, 40);
            this.BtLimpar.TabIndex = 7;
            this.BtLimpar.Text = "Limpar";
            this.BtLimpar.UseVisualStyleBackColor = true;
            this.BtLimpar.Click += new System.EventHandler(this.BtLimpar_Click);
            // 
            // BtSalvar
            // 
            this.BtSalvar.Location = new System.Drawing.Point(219, 204);
            this.BtSalvar.Name = "BtSalvar";
            this.BtSalvar.Size = new System.Drawing.Size(100, 40);
            this.BtSalvar.TabIndex = 8;
            this.BtSalvar.Text = "Salvar";
            this.BtSalvar.UseVisualStyleBackColor = true;
            this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // Item_11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(339, 257);
            this.Controls.Add(this.BtSalvar);
            this.Controls.Add(this.BtLimpar);
            this.Controls.Add(this.BtSelTodos);
            this.Controls.Add(this.LEnsaiosItem11);
            this.Controls.Add(this.ListaEnsaiosItem11);
            this.Name = "Item_11";
            this.Text = "Item 11";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LEnsaiosItem11;
        private System.Windows.Forms.CheckedListBox ListaEnsaiosItem11;
        private System.Windows.Forms.Button BtSelTodos;
        private System.Windows.Forms.Button BtLimpar;
        private System.Windows.Forms.Button BtSalvar;
    }
}