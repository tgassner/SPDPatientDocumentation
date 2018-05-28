namespace SPD.GUI {
    partial class ShowOperationsControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.labelPatientData = new System.Windows.Forms.Label();
            this.listViewOperations = new System.Windows.Forms.ListView();
            this.buttonChangeOP = new System.Windows.Forms.Button();
            this.listBoxCopys = new System.Windows.Forms.ListBox();
            this.labelSheets = new System.Windows.Forms.Label();
            this.labelDays = new System.Windows.Forms.Label();
            this.listBoxDays = new System.Windows.Forms.ListBox();
            this.buttonprintA3TemperatureCurve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient:";
            // 
            // labelPatientData
            // 
            this.labelPatientData.AutoSize = true;
            this.labelPatientData.Location = new System.Drawing.Point(57, 5);
            this.labelPatientData.Name = "labelPatientData";
            this.labelPatientData.Size = new System.Drawing.Size(35, 13);
            this.labelPatientData.TabIndex = 1;
            this.labelPatientData.Text = "label2";
            // 
            // listViewOperations
            // 
            this.listViewOperations.HideSelection = false;
            this.listViewOperations.Location = new System.Drawing.Point(19, 21);
            this.listViewOperations.Name = "listViewOperations";
            this.listViewOperations.Size = new System.Drawing.Size(968, 199);
            this.listViewOperations.TabIndex = 3;
            this.listViewOperations.UseCompatibleStateImageBehavior = false;
            this.listViewOperations.SelectedIndexChanged += new System.EventHandler(this.listViewOperations_SelectedIndexChanged);
            // 
            // buttonChangeOP
            // 
            this.buttonChangeOP.Location = new System.Drawing.Point(418, 243);
            this.buttonChangeOP.Name = "buttonChangeOP";
            this.buttonChangeOP.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeOP.TabIndex = 5;
            this.buttonChangeOP.Text = "Change OP";
            this.buttonChangeOP.UseVisualStyleBackColor = true;
            this.buttonChangeOP.Click += new System.EventHandler(this.buttonChangeOP_Click);
            // 
            // listBoxCopys
            // 
            this.listBoxCopys.FormattingEnabled = true;
            this.listBoxCopys.Location = new System.Drawing.Point(788, 236);
            this.listBoxCopys.Name = "listBoxCopys";
            this.listBoxCopys.Size = new System.Drawing.Size(40, 30);
            this.listBoxCopys.TabIndex = 33;
            // 
            // labelSheets
            // 
            this.labelSheets.AutoSize = true;
            this.labelSheets.Location = new System.Drawing.Point(748, 241);
            this.labelSheets.Name = "labelSheets";
            this.labelSheets.Size = new System.Drawing.Size(34, 13);
            this.labelSheets.TabIndex = 32;
            this.labelSheets.Text = "Copy:";
            // 
            // labelDays
            // 
            this.labelDays.AutoSize = true;
            this.labelDays.Location = new System.Drawing.Point(638, 241);
            this.labelDays.Name = "labelDays";
            this.labelDays.Size = new System.Drawing.Size(34, 13);
            this.labelDays.TabIndex = 31;
            this.labelDays.Text = "Days:";
            // 
            // listBoxDays
            // 
            this.listBoxDays.FormattingEnabled = true;
            this.listBoxDays.Location = new System.Drawing.Point(678, 236);
            this.listBoxDays.Name = "listBoxDays";
            this.listBoxDays.Size = new System.Drawing.Size(49, 30);
            this.listBoxDays.TabIndex = 30;
            // 
            // buttonprintA3TemperatureCurve
            // 
            this.buttonprintA3TemperatureCurve.Location = new System.Drawing.Point(499, 243);
            this.buttonprintA3TemperatureCurve.Name = "buttonprintA3TemperatureCurve";
            this.buttonprintA3TemperatureCurve.Size = new System.Drawing.Size(133, 23);
            this.buttonprintA3TemperatureCurve.TabIndex = 34;
            this.buttonprintA3TemperatureCurve.Text = "Print Temperature Curve";
            this.buttonprintA3TemperatureCurve.UseVisualStyleBackColor = true;
            this.buttonprintA3TemperatureCurve.Click += new System.EventHandler(this.buttonprintA3TemperatureCurve_Click);
            // 
            // ShowOperationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonprintA3TemperatureCurve);
            this.Controls.Add(this.listBoxCopys);
            this.Controls.Add(this.labelSheets);
            this.Controls.Add(this.labelDays);
            this.Controls.Add(this.listBoxDays);
            this.Controls.Add(this.buttonChangeOP);
            this.Controls.Add(this.listViewOperations);
            this.Controls.Add(this.labelPatientData);
            this.Controls.Add(this.label1);
            this.Name = "ShowOperationsControl";
            this.Size = new System.Drawing.Size(990, 511);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPatientData;
        private System.Windows.Forms.ListView listViewOperations;
        private System.Windows.Forms.Button buttonChangeOP;
        private System.Windows.Forms.ListBox listBoxCopys;
        private System.Windows.Forms.Label labelSheets;
        private System.Windows.Forms.Label labelDays;
        private System.Windows.Forms.ListBox listBoxDays;
        private System.Windows.Forms.Button buttonprintA3TemperatureCurve;
    }
}
