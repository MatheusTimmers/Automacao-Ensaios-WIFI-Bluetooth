
namespace Automacao_N9010A
{
    partial class TelaLoading
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
            this.PbEnsaioEmAndamento = new System.Windows.Forms.ProgressBar();
            this.LLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PbEnsaioEmAndamento
            // 
            this.PbEnsaioEmAndamento.Location = new System.Drawing.Point(54, 69);
            this.PbEnsaioEmAndamento.Name = "PbEnsaioEmAndamento";
            this.PbEnsaioEmAndamento.Size = new System.Drawing.Size(208, 34);
            this.PbEnsaioEmAndamento.TabIndex = 0;
            // 
            // LLoading
            // 
            this.LLoading.AutoSize = true;
            this.LLoading.BackColor = System.Drawing.Color.Transparent;
            this.LLoading.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LLoading.ForeColor = System.Drawing.Color.Black;
            this.LLoading.Location = new System.Drawing.Point(77, 36);
            this.LLoading.Name = "LLoading";
            this.LLoading.Size = new System.Drawing.Size(154, 19);
            this.LLoading.TabIndex = 10;
            this.LLoading.Text = "Ensaio em Andamento";
            // 
            // TelaLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(322, 159);
            this.Controls.Add(this.LLoading);
            this.Controls.Add(this.PbEnsaioEmAndamento);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaLoading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PbEnsaioEmAndamento;
        private System.Windows.Forms.Label LLoading;
    }
}