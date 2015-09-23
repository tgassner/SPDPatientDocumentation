namespace SPD.WCFService.Host {
    partial class MainForm {
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
            this.buttonStartStopServer = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAddresses = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStartStopServer
            // 
            this.buttonStartStopServer.Location = new System.Drawing.Point(12, 12);
            this.buttonStartStopServer.Name = "buttonStartStopServer";
            this.buttonStartStopServer.Size = new System.Drawing.Size(153, 23);
            this.buttonStartStopServer.TabIndex = 0;
            this.buttonStartStopServer.Text = "Start Server";
            this.buttonStartStopServer.UseVisualStyleBackColor = true;
            this.buttonStartStopServer.Click += new System.EventHandler(this.buttonStartStopServer_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(171, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(153, 23);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxState
            // 
            this.textBoxState.Location = new System.Drawing.Point(13, 179);
            this.textBoxState.Multiline = true;
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.Size = new System.Drawing.Size(311, 173);
            this.textBoxState.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "State:";
            // 
            // textBoxAddresses
            // 
            this.textBoxAddresses.Location = new System.Drawing.Point(13, 57);
            this.textBoxAddresses.Multiline = true;
            this.textBoxAddresses.Name = "textBoxAddresses";
            this.textBoxAddresses.ReadOnly = true;
            this.textBoxAddresses.Size = new System.Drawing.Size(311, 103);
            this.textBoxAddresses.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 390);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAddresses);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStartStopServer);
            this.Name = "MainForm";
            this.Text = "Simple Patient Documentation WCF Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartStopServer;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAddresses;
        private System.Windows.Forms.Label label2;
    }
}

