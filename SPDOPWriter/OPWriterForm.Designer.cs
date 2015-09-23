namespace SPD.GUI.OPWriter {
    partial class OPWriterForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OPWriterForm));
            this.buttonOpenPath = new System.Windows.Forms.Button();
            this.textBoxExportPath = new System.Windows.Forms.TextBox();
            this.labelExportPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPatientId = new System.Windows.Forms.TextBox();
            this.buttonDBSettings = new System.Windows.Forms.Button();
            this.labelDBInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOpenPath
            // 
            this.buttonOpenPath.Location = new System.Drawing.Point(912, 10);
            this.buttonOpenPath.Name = "buttonOpenPath";
            this.buttonOpenPath.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenPath.TabIndex = 2;
            this.buttonOpenPath.Text = "open Path";
            this.buttonOpenPath.UseVisualStyleBackColor = true;
            this.buttonOpenPath.Click += new System.EventHandler(this.buttonOpenPath_Click);
            // 
            // textBoxExportPath
            // 
            this.textBoxExportPath.Location = new System.Drawing.Point(98, 12);
            this.textBoxExportPath.Name = "textBoxExportPath";
            this.textBoxExportPath.Size = new System.Drawing.Size(808, 20);
            this.textBoxExportPath.TabIndex = 3;
            // 
            // labelExportPath
            // 
            this.labelExportPath.AutoSize = true;
            this.labelExportPath.Location = new System.Drawing.Point(12, 15);
            this.labelExportPath.Name = "labelExportPath";
            this.labelExportPath.Size = new System.Drawing.Size(80, 13);
            this.labelExportPath.TabIndex = 4;
            this.labelExportPath.Text = "OP Export Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PatientId:";
            // 
            // textBoxPatientId
            // 
            this.textBoxPatientId.Location = new System.Drawing.Point(98, 41);
            this.textBoxPatientId.Name = "textBoxPatientId";
            this.textBoxPatientId.Size = new System.Drawing.Size(100, 20);
            this.textBoxPatientId.TabIndex = 6;
            // 
            // buttonDBSettings
            // 
            this.buttonDBSettings.Location = new System.Drawing.Point(912, 43);
            this.buttonDBSettings.Name = "buttonDBSettings";
            this.buttonDBSettings.Size = new System.Drawing.Size(74, 23);
            this.buttonDBSettings.TabIndex = 7;
            this.buttonDBSettings.Text = "DB Settings";
            this.buttonDBSettings.UseVisualStyleBackColor = true;
            this.buttonDBSettings.Click += new System.EventHandler(this.buttonDBSettings_Click);
            // 
            // labelDBInfo
            // 
            this.labelDBInfo.AutoSize = true;
            this.labelDBInfo.Location = new System.Drawing.Point(780, 44);
            this.labelDBInfo.Name = "labelDBInfo";
            this.labelDBInfo.Size = new System.Drawing.Size(35, 13);
            this.labelDBInfo.TabIndex = 8;
            this.labelDBInfo.Text = "label2";
            // 
            // OPWriterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 390);
            this.Controls.Add(this.labelDBInfo);
            this.Controls.Add(this.buttonDBSettings);
            this.Controls.Add(this.textBoxPatientId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelExportPath);
            this.Controls.Add(this.textBoxExportPath);
            this.Controls.Add(this.buttonOpenPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OPWriterForm";
            this.Text = "SPD OP Writer";
            this.Load += new System.EventHandler(this.OPWriterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenPath;
        private System.Windows.Forms.TextBox textBoxExportPath;
        private System.Windows.Forms.Label labelExportPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPatientId;
        private System.Windows.Forms.Button buttonDBSettings;
        private System.Windows.Forms.Label labelDBInfo;
    }
}

