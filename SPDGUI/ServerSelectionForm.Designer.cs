namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    partial class ServerSelectionForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonConnect = new System.Windows.Forms.Button();
            this.radioButtonLocal = new System.Windows.Forms.RadioButton();
            this.labelServiceHost = new System.Windows.Forms.Label();
            this.radioButtonWCF = new System.Windows.Forms.RadioButton();
            this.textBoxServiceHost = new System.Windows.Forms.TextBox();
            this.radioButtonHTTP = new System.Windows.Forms.RadioButton();
            this.radioButtonTCP = new System.Windows.Forms.RadioButton();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonNamesPipes = new System.Windows.Forms.RadioButton();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 203);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(123, 23);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Save and Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // radioButtonLocal
            // 
            this.radioButtonLocal.AutoSize = true;
            this.radioButtonLocal.Location = new System.Drawing.Point(12, 12);
            this.radioButtonLocal.Name = "radioButtonLocal";
            this.radioButtonLocal.Size = new System.Drawing.Size(100, 17);
            this.radioButtonLocal.TabIndex = 0;
            this.radioButtonLocal.TabStop = true;
            this.radioButtonLocal.Text = "Local Database";
            this.radioButtonLocal.UseVisualStyleBackColor = true;
            // 
            // labelServiceHost
            // 
            this.labelServiceHost.AutoSize = true;
            this.labelServiceHost.Location = new System.Drawing.Point(36, 73);
            this.labelServiceHost.Name = "labelServiceHost";
            this.labelServiceHost.Size = new System.Drawing.Size(71, 13);
            this.labelServiceHost.TabIndex = 2;
            this.labelServiceHost.Text = "Service Host:";
            // 
            // radioButtonWCF
            // 
            this.radioButtonWCF.AutoSize = true;
            this.radioButtonWCF.Location = new System.Drawing.Point(12, 47);
            this.radioButtonWCF.Name = "radioButtonWCF";
            this.radioButtonWCF.Size = new System.Drawing.Size(89, 17);
            this.radioButtonWCF.TabIndex = 1;
            this.radioButtonWCF.TabStop = true;
            this.radioButtonWCF.Text = "WCF Remote";
            this.radioButtonWCF.UseVisualStyleBackColor = true;
            // 
            // textBoxServiceHost
            // 
            this.textBoxServiceHost.Location = new System.Drawing.Point(113, 70);
            this.textBoxServiceHost.Name = "textBoxServiceHost";
            this.textBoxServiceHost.Size = new System.Drawing.Size(242, 20);
            this.textBoxServiceHost.TabIndex = 3;
            // 
            // radioButtonHTTP
            // 
            this.radioButtonHTTP.AutoSize = true;
            this.radioButtonHTTP.Location = new System.Drawing.Point(13, 15);
            this.radioButtonHTTP.Name = "radioButtonHTTP";
            this.radioButtonHTTP.Size = new System.Drawing.Size(96, 17);
            this.radioButtonHTTP.TabIndex = 0;
            this.radioButtonHTTP.TabStop = true;
            this.radioButtonHTTP.Text = "HTTP Protocol";
            this.radioButtonHTTP.UseVisualStyleBackColor = true;
            // 
            // radioButtonTCP
            // 
            this.radioButtonTCP.AutoSize = true;
            this.radioButtonTCP.Location = new System.Drawing.Point(13, 38);
            this.radioButtonTCP.Name = "radioButtonTCP";
            this.radioButtonTCP.Size = new System.Drawing.Size(88, 17);
            this.radioButtonTCP.TabIndex = 1;
            this.radioButtonTCP.TabStop = true;
            this.radioButtonTCP.Text = "TCP Protocol";
            this.radioButtonTCP.UseVisualStyleBackColor = true;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(187, 99);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(222, 96);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(133, 20);
            this.textBoxPort.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonHTTP);
            this.groupBox1.Controls.Add(this.radioButtonNamesPipes);
            this.groupBox1.Controls.Add(this.radioButtonTCP);
            this.groupBox1.Location = new System.Drawing.Point(39, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 98);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Protokolls";
            // 
            // radioButtonNamesPipes
            // 
            this.radioButtonNamesPipes.AutoSize = true;
            this.radioButtonNamesPipes.Location = new System.Drawing.Point(13, 61);
            this.radioButtonNamesPipes.Name = "radioButtonNamesPipes";
            this.radioButtonNamesPipes.Size = new System.Drawing.Size(88, 30);
            this.radioButtonNamesPipes.TabIndex = 2;
            this.radioButtonNamesPipes.TabStop = true;
            this.radioButtonNamesPipes.Text = "Named Pipes\r\nonly local";
            this.radioButtonNamesPipes.UseVisualStyleBackColor = true;
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(141, 203);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(75, 23);
            this.buttonUndo.TabIndex = 6;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // ServerSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 231);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.textBoxServiceHost);
            this.Controls.Add(this.labelServiceHost);
            this.Controls.Add(this.radioButtonWCF);
            this.Controls.Add(this.radioButtonLocal);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.buttonConnect);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(369, 258);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(369, 258);
            this.Name = "ServerSelectionForm";
            this.Text = "ServerSelectionForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.RadioButton radioButtonLocal;
        private System.Windows.Forms.Label labelServiceHost;
        private System.Windows.Forms.RadioButton radioButtonWCF;
        private System.Windows.Forms.TextBox textBoxServiceHost;
        private System.Windows.Forms.RadioButton radioButtonHTTP;
        private System.Windows.Forms.RadioButton radioButtonTCP;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonNamesPipes;
        private System.Windows.Forms.Button buttonUndo;
    }
}