
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
            this.ListaTecnologiasWifi = new System.Windows.Forms.CheckedListBox();
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
            this.ListaTecnologiasBT = new System.Windows.Forms.CheckedListBox();
            this.BtSelTodos = new System.Windows.Forms.Button();
            this.GrupoDasNormas = new System.Windows.Forms.GroupBox();
            this.BtConectado = new System.Windows.Forms.Button();
            this.LConecta = new System.Windows.Forms.Label();
            this.LSelTipo = new System.Windows.Forms.Label();
            this.CBSelTipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoLabelo)).BeginInit();
            this.TextBoxTecnologias.SuspendLayout();
            this.GrupoDasNormas.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaTecnologiasWifi
            // 
            this.ListaTecnologiasWifi.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListaTecnologiasWifi.FormattingEnabled = true;
            this.ListaTecnologiasWifi.Items.AddRange(new object[] {
            "Bluetooth Low Energy",
            "802.11a",
            "802.11b",
            "802.11g",
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
            this.ListaTecnologiasWifi.Location = new System.Drawing.Point(12, 26);
            this.ListaTecnologiasWifi.Name = "ListaTecnologiasWifi";
            this.ListaTecnologiasWifi.Size = new System.Drawing.Size(361, 174);
            this.ListaTecnologiasWifi.TabIndex = 0;
            // 
            // BtConfirmar
            // 
            this.BtConfirmar.BackColor = System.Drawing.SystemColors.Control;
            this.BtConfirmar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtConfirmar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtConfirmar.Location = new System.Drawing.Point(277, 556);
            this.BtConfirmar.Name = "BtConfirmar";
            this.BtConfirmar.Size = new System.Drawing.Size(108, 33);
            this.BtConfirmar.TabIndex = 6;
            this.BtConfirmar.Text = "Confirmar";
            this.BtConfirmar.UseVisualStyleBackColor = false;
            this.BtConfirmar.Click += new System.EventHandler(this.BtConfirmar_Click);
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
            this.BtConfig.Location = new System.Drawing.Point(138, 211);
            this.BtConfig.Name = "BtConfig";
            this.BtConfig.Size = new System.Drawing.Size(108, 29);
            this.BtConfig.TabIndex = 15;
            this.BtConfig.Text = "Configurações";
            this.BtConfig.UseVisualStyleBackColor = false;
            this.BtConfig.Click += new System.EventHandler(this.BtConfig_Click);
            // 
            // LogoLabelo
            // 
            this.LogoLabelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LogoLabelo.Image = ((System.Drawing.Image)(resources.GetObject("LogoLabelo.Image")));
            this.LogoLabelo.Location = new System.Drawing.Point(35, -31);
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
            this.BtLimpar.Location = new System.Drawing.Point(265, 211);
            this.BtLimpar.Name = "BtLimpar";
            this.BtLimpar.Size = new System.Drawing.Size(108, 29);
            this.BtLimpar.TabIndex = 17;
            this.BtLimpar.Text = "Limpar";
            this.BtLimpar.UseVisualStyleBackColor = false;
            this.BtLimpar.Click += new System.EventHandler(this.BtLimpar_Click);
            // 
            // BtItem10
            // 
            this.BtItem10.BackColor = System.Drawing.SystemColors.Control;
            this.BtItem10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtItem10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtItem10.Location = new System.Drawing.Point(12, 26);
            this.BtItem10.Name = "BtItem10";
            this.BtItem10.Size = new System.Drawing.Size(108, 29);
            this.BtItem10.TabIndex = 18;
            this.BtItem10.Text = "Item 10";
            this.BtItem10.UseVisualStyleBackColor = false;
            this.BtItem10.Click += new System.EventHandler(this.BtItem10_Click);
            // 
            // BtItem11
            // 
            this.BtItem11.BackColor = System.Drawing.SystemColors.Control;
            this.BtItem11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtItem11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtItem11.Location = new System.Drawing.Point(138, 26);
            this.BtItem11.Name = "BtItem11";
            this.BtItem11.Size = new System.Drawing.Size(108, 29);
            this.BtItem11.TabIndex = 19;
            this.BtItem11.Text = "Item 11";
            this.BtItem11.UseVisualStyleBackColor = false;
            this.BtItem11.Click += new System.EventHandler(this.BtItem11_Click);
            // 
            // BtItem12
            // 
            this.BtItem12.BackColor = System.Drawing.SystemColors.Control;
            this.BtItem12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtItem12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtItem12.Location = new System.Drawing.Point(265, 26);
            this.BtItem12.Name = "BtItem12";
            this.BtItem12.Size = new System.Drawing.Size(108, 29);
            this.BtItem12.TabIndex = 20;
            this.BtItem12.Text = "Item 12";
            this.BtItem12.UseVisualStyleBackColor = false;
            this.BtItem12.Click += new System.EventHandler(this.BtItem12_Click);
            // 
            // TextBoxTecnologias
            // 
            this.TextBoxTecnologias.Controls.Add(this.ListaTecnologiasBT);
            this.TextBoxTecnologias.Controls.Add(this.BtSelTodos);
            this.TextBoxTecnologias.Controls.Add(this.BtConfig);
            this.TextBoxTecnologias.Controls.Add(this.BtLimpar);
            this.TextBoxTecnologias.Controls.Add(this.ListaTecnologiasWifi);
            this.TextBoxTecnologias.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBoxTecnologias.Location = new System.Drawing.Point(12, 218);
            this.TextBoxTecnologias.Name = "TextBoxTecnologias";
            this.TextBoxTecnologias.Size = new System.Drawing.Size(379, 248);
            this.TextBoxTecnologias.TabIndex = 21;
            this.TextBoxTecnologias.TabStop = false;
            this.TextBoxTecnologias.Text = "Tecnologias para ensaio";
            // 
            // ListaTecnologiasBT
            // 
            this.ListaTecnologiasBT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListaTecnologiasBT.FormattingEnabled = true;
            this.ListaTecnologiasBT.Items.AddRange(new object[] {
            "GFSK",
            "PI/4 DQPSK",
            "8DPSK"});
            this.ListaTecnologiasBT.Location = new System.Drawing.Point(12, 26);
            this.ListaTecnologiasBT.Name = "ListaTecnologiasBT";
            this.ListaTecnologiasBT.Size = new System.Drawing.Size(361, 174);
            this.ListaTecnologiasBT.TabIndex = 28;
            // 
            // BtSelTodos
            // 
            this.BtSelTodos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtSelTodos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtSelTodos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtSelTodos.Location = new System.Drawing.Point(12, 211);
            this.BtSelTodos.Name = "BtSelTodos";
            this.BtSelTodos.Size = new System.Drawing.Size(108, 29);
            this.BtSelTodos.TabIndex = 18;
            this.BtSelTodos.Text = "Sel. Todos";
            this.BtSelTodos.UseVisualStyleBackColor = false;
            this.BtSelTodos.Click += new System.EventHandler(this.BtSelTodos_Click);
            // 
            // GrupoDasNormas
            // 
            this.GrupoDasNormas.Controls.Add(this.BtItem12);
            this.GrupoDasNormas.Controls.Add(this.BtItem10);
            this.GrupoDasNormas.Controls.Add(this.BtItem11);
            this.GrupoDasNormas.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GrupoDasNormas.Location = new System.Drawing.Point(12, 479);
            this.GrupoDasNormas.Name = "GrupoDasNormas";
            this.GrupoDasNormas.Size = new System.Drawing.Size(379, 65);
            this.GrupoDasNormas.TabIndex = 22;
            this.GrupoDasNormas.TabStop = false;
            this.GrupoDasNormas.Text = "Ensaios da Norma 6506";
            // 
            // BtConectado
            // 
            this.BtConectado.BackColor = System.Drawing.SystemColors.Control;
            this.BtConectado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtConectado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtConectado.Location = new System.Drawing.Point(160, 130);
            this.BtConectado.Name = "BtConectado";
            this.BtConectado.Size = new System.Drawing.Size(117, 29);
            this.BtConectado.TabIndex = 23;
            this.BtConectado.Text = "Conectar";
            this.BtConectado.UseVisualStyleBackColor = false;
            this.BtConectado.Click += new System.EventHandler(this.BtConectado_Click);
            // 
            // LConecta
            // 
            this.LConecta.AutoSize = true;
            this.LConecta.BackColor = System.Drawing.Color.Transparent;
            this.LConecta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LConecta.ForeColor = System.Drawing.Color.Red;
            this.LConecta.Location = new System.Drawing.Point(283, 105);
            this.LConecta.Name = "LConecta";
            this.LConecta.Size = new System.Drawing.Size(93, 13);
            this.LConecta.TabIndex = 24;
            this.LConecta.Text = "SEM CONEXÃO";
            // 
            // LSelTipo
            // 
            this.LSelTipo.AutoSize = true;
            this.LSelTipo.BackColor = System.Drawing.Color.Transparent;
            this.LSelTipo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LSelTipo.ForeColor = System.Drawing.Color.Black;
            this.LSelTipo.Location = new System.Drawing.Point(21, 174);
            this.LSelTipo.Name = "LSelTipo";
            this.LSelTipo.Size = new System.Drawing.Size(165, 13);
            this.LSelTipo.TabIndex = 26;
            this.LSelTipo.Text = "Selecione o Tipo de Ensaio:";
            // 
            // CBSelTipo
            // 
            this.CBSelTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSelTipo.FormattingEnabled = true;
            this.CBSelTipo.Items.AddRange(new object[] {
            "Wifi",
            "Bluetooth"});
            this.CBSelTipo.Location = new System.Drawing.Point(21, 190);
            this.CBSelTipo.Name = "CBSelTipo";
            this.CBSelTipo.Size = new System.Drawing.Size(364, 22);
            this.CBSelTipo.TabIndex = 27;
            this.CBSelTipo.SelectedIndexChanged += new System.EventHandler(this.CBSelTipo_SelectedIndexChanged);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(403, 598);
            this.Controls.Add(this.CBSelTipo);
            this.Controls.Add(this.LSelTipo);
            this.Controls.Add(this.LConecta);
            this.Controls.Add(this.BtConectado);
            this.Controls.Add(this.BtConfirmar);
            this.Controls.Add(this.GrupoDasNormas);
            this.Controls.Add(this.LIP);
            this.Controls.Add(this.TextBoxIP);
            this.Controls.Add(this.LUnidade);
            this.Controls.Add(this.TextBoxFreqC);
            this.Controls.Add(this.LFreq);
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
            ((System.ComponentModel.ISupportInitialize)(this.LogoLabelo)).EndInit();
            this.TextBoxTecnologias.ResumeLayout(false);
            this.GrupoDasNormas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.CheckedListBox ListaTecnologiasWifi;
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
        private System.Windows.Forms.Button BtSelTodos;
        private System.Windows.Forms.GroupBox GrupoDasNormas;
        private System.Windows.Forms.Button BtConectado;
        private System.Windows.Forms.Label LConecta;
        private System.Windows.Forms.Label LSelTipo;
        private System.Windows.Forms.ComboBox CBSelTipo;
        private System.Windows.Forms.CheckedListBox ListaTecnologiasBT;
    }
}

