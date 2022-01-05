
namespace Automacao_N9010A
{
    partial class Configurações
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
            this.LValorAtualAtt = new System.Windows.Forms.Label();
            this.LValorAtualRLevel = new System.Windows.Forms.Label();
            this.BtSalvar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LAttRLevel = new System.Windows.Forms.Label();
            this.TextBoxAtt = new System.Windows.Forms.TextBox();
            this.TextBoxRefLevel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LValorAtualAtt
            // 
            this.LValorAtualAtt.AutoSize = true;
            this.LValorAtualAtt.BackColor = System.Drawing.Color.Transparent;
            this.LValorAtualAtt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LValorAtualAtt.Location = new System.Drawing.Point(121, 168);
            this.LValorAtualAtt.Name = "LValorAtualAtt";
            this.LValorAtualAtt.Size = new System.Drawing.Size(53, 15);
            this.LValorAtualAtt.TabIndex = 16;
            this.LValorAtualAtt.Text = "Atual: 35";
            // 
            // LValorAtualRLevel
            // 
            this.LValorAtualRLevel.AutoSize = true;
            this.LValorAtualRLevel.BackColor = System.Drawing.Color.Transparent;
            this.LValorAtualRLevel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LValorAtualRLevel.Location = new System.Drawing.Point(121, 107);
            this.LValorAtualRLevel.Name = "LValorAtualRLevel";
            this.LValorAtualRLevel.Size = new System.Drawing.Size(53, 15);
            this.LValorAtualRLevel.TabIndex = 15;
            this.LValorAtualRLevel.Text = "Atual: 20";
            // 
            // BtSalvar
            // 
            this.BtSalvar.BackColor = System.Drawing.Color.Transparent;
            this.BtSalvar.ForeColor = System.Drawing.Color.Black;
            this.BtSalvar.Location = new System.Drawing.Point(227, 98);
            this.BtSalvar.Name = "BtSalvar";
            this.BtSalvar.Size = new System.Drawing.Size(98, 32);
            this.BtSalvar.TabIndex = 14;
            this.BtSalvar.Text = "Salvar";
            this.BtSalvar.UseVisualStyleBackColor = false;
            this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(19, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Attenuation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(19, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ref Level:";
            // 
            // LAttRLevel
            // 
            this.LAttRLevel.AutoSize = true;
            this.LAttRLevel.BackColor = System.Drawing.Color.Transparent;
            this.LAttRLevel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LAttRLevel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LAttRLevel.Location = new System.Drawing.Point(19, 21);
            this.LAttRLevel.Name = "LAttRLevel";
            this.LAttRLevel.Size = new System.Drawing.Size(389, 27);
            this.LAttRLevel.TabIndex = 11;
            this.LAttRLevel.Text = "Configurar o Ref Level e a Attenuation";
            // 
            // TextBoxAtt
            // 
            this.TextBoxAtt.Location = new System.Drawing.Point(95, 133);
            this.TextBoxAtt.Name = "TextBoxAtt";
            this.TextBoxAtt.Size = new System.Drawing.Size(100, 23);
            this.TextBoxAtt.TabIndex = 10;
            // 
            // TextBoxRefLevel
            // 
            this.TextBoxRefLevel.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxRefLevel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TextBoxRefLevel.Location = new System.Drawing.Point(95, 73);
            this.TextBoxRefLevel.Name = "TextBoxRefLevel";
            this.TextBoxRefLevel.Size = new System.Drawing.Size(100, 23);
            this.TextBoxRefLevel.TabIndex = 9;
            // 
            // Configurações
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(464, 202);
            this.Controls.Add(this.LValorAtualAtt);
            this.Controls.Add(this.LValorAtualRLevel);
            this.Controls.Add(this.BtSalvar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LAttRLevel);
            this.Controls.Add(this.TextBoxAtt);
            this.Controls.Add(this.TextBoxRefLevel);
            this.Name = "Configurações";
            this.Text = "Configurações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LValorAtualAtt;
        private System.Windows.Forms.Label LValorAtualRLevel;
        private System.Windows.Forms.Button BtSalvar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LAttRLevel;
        private System.Windows.Forms.TextBox TextBoxAtt;
        private System.Windows.Forms.TextBox TextBoxRefLevel;
    }
}