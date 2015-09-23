namespace SPD.GUI {
    partial class SettingsForm {
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.listBoxPrintBarcodes = new System.Windows.Forms.ListBox();
            this.labelBarcodeFontInstalled = new System.Windows.Forms.Label();
            this.labelPrintBarcodes = new System.Windows.Forms.Label();
            this.labelUltraSoundTemplate = new System.Windows.Forms.Label();
            this.textBoxUltraSoundTemplate = new System.Windows.Forms.TextBox();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelFinalReportTextElements = new System.Windows.Forms.Label();
            this.textBoxFinalReportTextElements = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(93, 374);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 374);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // listBoxPrintBarcodes
            // 
            this.listBoxPrintBarcodes.FormattingEnabled = true;
            this.listBoxPrintBarcodes.Location = new System.Drawing.Point(155, 12);
            this.listBoxPrintBarcodes.Name = "listBoxPrintBarcodes";
            this.listBoxPrintBarcodes.Size = new System.Drawing.Size(120, 30);
            this.listBoxPrintBarcodes.TabIndex = 2;
            // 
            // labelBarcodeFontInstalled
            // 
            this.labelBarcodeFontInstalled.AutoSize = true;
            this.labelBarcodeFontInstalled.Location = new System.Drawing.Point(281, 12);
            this.labelBarcodeFontInstalled.Name = "labelBarcodeFontInstalled";
            this.labelBarcodeFontInstalled.Size = new System.Drawing.Size(35, 13);
            this.labelBarcodeFontInstalled.TabIndex = 3;
            this.labelBarcodeFontInstalled.Text = "label1";
            // 
            // labelPrintBarcodes
            // 
            this.labelPrintBarcodes.AutoSize = true;
            this.labelPrintBarcodes.Location = new System.Drawing.Point(70, 12);
            this.labelPrintBarcodes.Name = "labelPrintBarcodes";
            this.labelPrintBarcodes.Size = new System.Drawing.Size(79, 13);
            this.labelPrintBarcodes.TabIndex = 4;
            this.labelPrintBarcodes.Text = "Print Barcodes:";
            // 
            // labelUltraSoundTemplate
            // 
            this.labelUltraSoundTemplate.AutoSize = true;
            this.labelUltraSoundTemplate.Location = new System.Drawing.Point(39, 51);
            this.labelUltraSoundTemplate.Name = "labelUltraSoundTemplate";
            this.labelUltraSoundTemplate.Size = new System.Drawing.Size(110, 13);
            this.labelUltraSoundTemplate.TabIndex = 5;
            this.labelUltraSoundTemplate.Text = "UltraSound Template:";
            // 
            // textBoxUltraSoundTemplate
            // 
            this.textBoxUltraSoundTemplate.Location = new System.Drawing.Point(155, 48);
            this.textBoxUltraSoundTemplate.Multiline = true;
            this.textBoxUltraSoundTemplate.Name = "textBoxUltraSoundTemplate";
            this.textBoxUltraSoundTemplate.Size = new System.Drawing.Size(161, 117);
            this.textBoxUltraSoundTemplate.TabIndex = 6;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(155, 171);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(161, 20);
            this.textBoxLocation.TabIndex = 7;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(95, 174);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(51, 13);
            this.labelLocation.TabIndex = 8;
            this.labelLocation.Text = "Location:";
            // 
            // labelFinalReportTextElements
            // 
            this.labelFinalReportTextElements.AutoSize = true;
            this.labelFinalReportTextElements.Location = new System.Drawing.Point(12, 200);
            this.labelFinalReportTextElements.Name = "labelFinalReportTextElements";
            this.labelFinalReportTextElements.Size = new System.Drawing.Size(137, 13);
            this.labelFinalReportTextElements.TabIndex = 9;
            this.labelFinalReportTextElements.Text = "Final Report Text Elements:";
            // 
            // textBoxFinalReportTextElements
            // 
            this.textBoxFinalReportTextElements.Location = new System.Drawing.Point(155, 197);
            this.textBoxFinalReportTextElements.Multiline = true;
            this.textBoxFinalReportTextElements.Name = "textBoxFinalReportTextElements";
            this.textBoxFinalReportTextElements.Size = new System.Drawing.Size(539, 125);
            this.textBoxFinalReportTextElements.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 409);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxFinalReportTextElements);
            this.Controls.Add(this.labelFinalReportTextElements);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.textBoxUltraSoundTemplate);
            this.Controls.Add(this.labelUltraSoundTemplate);
            this.Controls.Add(this.labelPrintBarcodes);
            this.Controls.Add(this.labelBarcodeFontInstalled);
            this.Controls.Add(this.listBoxPrintBarcodes);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ListBox listBoxPrintBarcodes;
        private System.Windows.Forms.Label labelBarcodeFontInstalled;
        private System.Windows.Forms.Label labelPrintBarcodes;
        private System.Windows.Forms.Label labelUltraSoundTemplate;
        private System.Windows.Forms.TextBox textBoxUltraSoundTemplate;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelFinalReportTextElements;
        private System.Windows.Forms.TextBox textBoxFinalReportTextElements;
    }
}