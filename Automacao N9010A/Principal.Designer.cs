
namespace Automacao_N9010A
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.ListaTecnologias = new System.Windows.Forms.CheckedListBox();
            this.BtConfirmar = new System.Windows.Forms.Button();
            this.LFreq = new System.Windows.Forms.Label();
            this.TextBoxFreqC = new System.Windows.Forms.TextBox();
            this.LUnidade = new System.Windows.Forms.Label();
            this.TextBoxIP = new System.Windows.Forms.TextBox();
            this.LIP = new System.Windows.Forms.Label();
            this.BtConfig = new System.Windows.Forms.Button();
            this.LogoLabelo = new System.Windows.Forms.PictureBox();
            this.BtLimpar = new System.Windows.Forms.Button();
            this.BtItem10 = new System.Windows.Forms.Button();
            this.BtItem11 = new System.Windows.Forms.Button();
            this.BtItem12 = new System.Windows.Forms.Button();
            this.TextBoxTecnologias = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoLabelo)).BeginInit();
            this.TextBoxTecnologias.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaTecnologias
            // 
            this.ListaTecnologias.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListaTecnologias.FormattingEnabled = true;
            this.ListaTecnologias.Items.AddRange(new object[] {
            "802.11a",
            "802.11b",
            "802.11n (20)",
            "802.11n (40)",
            "802.11n (80)",
            "802.11ac (20)",
            "802.11ac (40)",
            "802.11ac (80)",
            "802.11ax (20)",
            "802.11ax (40)",
            "802.11ax (80)",
            "802.11ax (160)"});
            this.ListaTecnologias.Location = new System.Drawing.Point(21, 161);
            this.ListaTecnologias.Name = "ListaTecnologias";
            this.ListaTecnologias.Size = new System.Drawing.Size(292, 174);
            this.ListaTecnologias.TabIndex = 0;
            // 
            // BtConfirmar
            // 
            this.BtConfirmar.BackColor = System.Drawing.SystemColors.Control;
            this.BtConfirmar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtConfirmar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtConfirmar.Location = new System.Drawing.Point(9, 246);
            this.BtConfirmar.Name = "BtConfirmar";
            this.BtConfirmar.Size = new System.Drawing.Size(91, 29);
            this.BtConfirmar.TabIndex = 6;
            this.BtConfirmar.Text = "Confirmar";
            this.BtConfirmar.UseVisualStyleBackColor = false;
            this.BtConfirmar.Click += new System.EventHandler(this.button1_Click);
            // 
            // LFreq
            // 
            this.LFreq.AutoSize = true;
            this.LFreq.BackColor = System.Drawing.Color.Transparent;
            this.LFreq.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LFreq.ForeColor = System.Drawing.Color.Black;
            this.LFreq.Location = new System.Drawing.Point(21, 77);
            this.LFreq.Name = "LFreq";
            this.LFreq.Size = new System.Drawing.Size(133, 13);
            this.LFreq.TabIndex = 9;
            this.LFreq.Text = "Frequencia de Ensaio:";
            // 
            // TextBoxFreqC
            // 
            this.TextBoxFreqC.Location = new System.Drawing.Point(160, 74);
            this.TextBoxFreqC.Name = "TextBoxFreqC";
            this.TextBoxFreqC.Size = new System.Drawing.Size(117, 22);
            this.TextBoxFreqC.TabIndex = 10;
            // 
            // LUnidade
            // 
            this.LUnidade.AutoSize = true;
            this.LUnidade.BackColor = System.Drawing.Color.Transparent;
            this.LUnidade.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LUnidade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LUnidade.Location = new System.Drawing.Point(283, 77);
            this.LUnidade.Name = "LUnidade";
            this.LUnidade.Size = new System.Drawing.Size(30, 13);
            this.LUnidade.TabIndex = 11;
            this.LUnidade.Text = "MHz";
            this.LUnidade.Click += new System.EventHandler(this.label6_Click);
            // 
            // TextBoxIP
            // 
            this.TextBoxIP.Location = new System.Drawing.Point(160, 102);
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Size = new System.Drawing.Size(117, 22);
            this.TextBoxIP.TabIndex = 12;
            // 
            // LIP
            // 
            this.LIP.AutoSize = true;
            this.LIP.BackColor = System.Drawing.Color.Transparent;
            this.LIP.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LIP.ForeColor = System.Drawing.Color.Black;
            this.LIP.Location = new System.Drawing.Point(21, 102);
            this.LIP.Name = "LIP";
            this.LIP.Size = new System.Drawing.Size(93, 13);
            this.LIP.TabIndex = 13;
            this.LIP.Text = "Ip da Maquina:";
            // 
            // BtConfig
            // 
            this.BtConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtConfig.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtConfig.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtConfig.Location = new System.Drawing.Point(109, 246);
            this.BtConfig.Name = "BtConfig";
            this.BtConfig.Size = new System.Drawing.Size(91, 29);
            this.BtConfig.TabIndex = 15;
            this.BtConfig.Text = "Configurações";
            this.BtConfig.UseVisualStyleBackColor = false;
            this.BtConfig.Click += new System.EventHandler(this.button3_Click);
            // 
            // LogoLabelo
            // 
            this.LogoLabelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LogoLabelo.Image = ((System.Drawing.Image)(resources.GetObject("LogoLabelo.Image")));
            this.LogoLabelo.Location = new System.Drawing.Point(-4, -31);
            this.LogoLabelo.Name = "LogoLabelo";
            this.LogoLabelo.Size = new System.Drawing.Size(265, 99);
            this.LogoLabelo.TabIndex = 16;
            this.LogoLabelo.TabStop = false;
            // 
            // BtLimpar
            // 
            this.BtLimpar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtLimpar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtLimpar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtLimpar.Location = new System.Drawing.Point(222, 376);
            this.BtLimpar.Name = "BtLimpar";
            this.BtLimpar.Size = new System.Drawing.Size(91, 29);
            this.BtLimpar.TabIndex = 17;
            this.BtLimpar.Text = "Limpar";
            this.BtLimpar.UseVisualStyleBackColor = false;
            // 
            // BtItem10
            // 
            this.BtItem10.BackColor = System.Drawing.SystemColors.Control;
            this.BtItem10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtItem10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtItem10.Location = new System.Drawing.Point(21, 341);
            this.BtItem10.Name = "BtItem10";
            this.BtItem10.Size = new System.Drawing.Size(91, 29);
            this.BtItem10.TabIndex = 18;
            this.BtItem10.Text = "Item 10";
            this.BtItem10.UseVisualStyleBackColor = false;
            this.BtItem10.Click += new System.EventHandler(this.button5_Click);
            // 
            // BtItem11
            // 
            this.BtItem11.BackColor = System.Drawing.SystemColors.Control;
            this.BtItem11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtItem11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtItem11.Location = new System.Drawing.Point(121, 341);
            this.BtItem11.Name = "BtItem11";
            this.BtItem11.Size = new System.Drawing.Size(91, 29);
            this.BtItem11.TabIndex = 19;
            this.BtItem11.Text = "Item 11";
            this.BtItem11.UseVisualStyleBackColor = false;
            // 
            // BtItem12
            // 
            this.BtItem12.BackColor = System.Drawing.SystemColors.Control;
            this.BtItem12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtItem12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtItem12.Location = new System.Drawing.Point(222, 341);
            this.BtItem12.Name = "BtItem12";
            this.BtItem12.Size = new System.Drawing.Size(91, 29);
            this.BtItem12.TabIndex = 20;
            this.BtItem12.Text = "Item 12";
            this.BtItem12.UseVisualStyleBackColor = false;
            // 
            // TextBoxTecnologias
            // 
            this.TextBoxTecnologias.Controls.Add(this.BtConfirmar);
            this.TextBoxTecnologias.Controls.Add(this.BtConfig);
            this.TextBoxTecnologias.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBoxTecnologias.Location = new System.Drawing.Point(12, 130);
            this.TextBoxTecnologias.Name = "TextBoxTecnologias";
            this.TextBoxTecnologias.Size = new System.Drawing.Size(313, 284);
            this.TextBoxTecnologias.TabIndex = 21;
            this.TextBoxTecnologias.TabStop = false;
            this.TextBoxTecnologias.Text = "Tecnologias para ensaio";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(342, 462);
            this.Controls.Add(this.BtItem12);
            this.Controls.Add(this.BtItem11);
            this.Controls.Add(this.BtItem10);
            this.Controls.Add(this.BtLimpar);
            this.Controls.Add(this.LIP);
            this.Controls.Add(this.TextBoxIP);
            this.Controls.Add(this.LUnidade);
            this.Controls.Add(this.TextBoxFreqC);
            this.Controls.Add(this.LFreq);
            this.Controls.Add(this.ListaTecnologias);
            this.Controls.Add(this.LogoLabelo);
            this.Controls.Add(this.TextBoxTecnologias);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ensaio Wifi Bluetooth";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoLabelo)).EndInit();
            this.TextBoxTecnologias.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.CheckedListBox ListaTecnologias;
        private System.Windows.Forms.Button BtConfirmar;
        private System.Windows.Forms.Label LFreq;
        private System.Windows.Forms.TextBox TextBoxFreqC;
        private System.Windows.Forms.Label LUnidade;
        private System.Windows.Forms.TextBox TextBoxIP;
        private System.Windows.Forms.Label LIP;
        private System.Windows.Forms.Button BtConfig;
        private System.Windows.Forms.PictureBox LogoLabelo;
        private System.Windows.Forms.Button BtLimpar;
        private System.Windows.Forms.Button BtItem10;
        private System.Windows.Forms.Button BtItem11;
        private System.Windows.Forms.Button BtItem12;
        private System.Windows.Forms.GroupBox TextBoxTecnologias;
    }
}

