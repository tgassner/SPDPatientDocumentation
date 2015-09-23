namespace SPD.GUI {
    partial class ShowErrorForm {
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
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.buttonExitSPD = new System.Windows.Forms.Button();
            this.textBoxShortInfo = new System.Windows.Forms.TextBox();
            this.textBoxDetails = new System.Windows.Forms.TextBox();
            this.labelDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(93, 176);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(330, 23);
            this.buttonCopyToClipboard.TabIndex = 0;
            this.buttonCopyToClipboard.Text = "Copy Detail Errormessage to Clipboard for Sending it to the Author";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // buttonExitSPD
            // 
            this.buttonExitSPD.Location = new System.Drawing.Point(12, 176);
            this.buttonExitSPD.Name = "buttonExitSPD";
            this.buttonExitSPD.Size = new System.Drawing.Size(75, 23);
            this.buttonExitSPD.TabIndex = 1;
            this.buttonExitSPD.Text = "Exit SPD";
            this.buttonExitSPD.UseVisualStyleBackColor = true;
            this.buttonExitSPD.Click += new System.EventHandler(this.buttonExitSPD_Click);
            // 
            // textBoxShortInfo
            // 
            this.textBoxShortInfo.Location = new System.Drawing.Point(12, 12);
            this.textBoxShortInfo.Multiline = true;
            this.textBoxShortInfo.Name = "textBoxShortInfo";
            this.textBoxShortInfo.ReadOnly = true;
            this.textBoxShortInfo.Size = new System.Drawing.Size(967, 158);
            this.textBoxShortInfo.TabIndex = 2;
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.Location = new System.Drawing.Point(12, 225);
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.ReadOnly = true;
            this.textBoxDetails.Size = new System.Drawing.Size(967, 169);
            this.textBoxDetails.TabIndex = 3;
            // 
            // labelDetails
            // 
            this.labelDetails.AutoSize = true;
            this.labelDetails.Location = new System.Drawing.Point(12, 209);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(42, 13);
            this.labelDetails.TabIndex = 4;
            this.labelDetails.Text = "Details:";
            // 
            // ShowErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 410);
            this.ControlBox = false;
            this.Controls.Add(this.labelDetails);
            this.Controls.Add(this.textBoxDetails);
            this.Controls.Add(this.textBoxShortInfo);
            this.Controls.Add(this.buttonExitSPD);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowErrorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SPD Error!";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCopyToClipboard;
        private System.Windows.Forms.Button buttonExitSPD;
        private System.Windows.Forms.TextBox textBoxShortInfo;
        private System.Windows.Forms.TextBox textBoxDetails;
        private System.Windows.Forms.Label labelDetails;
    }
}