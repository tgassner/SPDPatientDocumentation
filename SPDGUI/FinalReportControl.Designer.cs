namespace SPD.GUI {
    partial class FinalReportControl {
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
            this.labelFurtherTreatment = new System.Windows.Forms.Label();
            this.textBoxFinalReport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentPatient = new System.Windows.Forms.Label();
            this.buttonStore = new System.Windows.Forms.Button();
            this.monthCalendarFinalReport = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPrintFurtherTreatment = new System.Windows.Forms.Button();
            this.listBoxFinalReportTextElements = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFurtherTreatment
            // 
            this.labelFurtherTreatment.AutoSize = true;
            this.labelFurtherTreatment.Location = new System.Drawing.Point(141, 37);
            this.labelFurtherTreatment.Name = "labelFurtherTreatment";
            this.labelFurtherTreatment.Size = new System.Drawing.Size(67, 13);
            this.labelFurtherTreatment.TabIndex = 0;
            this.labelFurtherTreatment.Text = "Final Report:";
            // 
            // textBoxFinalReport
            // 
            this.textBoxFinalReport.Location = new System.Drawing.Point(214, 34);
            this.textBoxFinalReport.Multiline = true;
            this.textBoxFinalReport.Name = "textBoxFinalReport";
            this.textBoxFinalReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFinalReport.Size = new System.Drawing.Size(458, 406);
            this.textBoxFinalReport.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Patient: ";
            // 
            // labelCurrentPatient
            // 
            this.labelCurrentPatient.AutoSize = true;
            this.labelCurrentPatient.Location = new System.Drawing.Point(211, 12);
            this.labelCurrentPatient.Name = "labelCurrentPatient";
            this.labelCurrentPatient.Size = new System.Drawing.Size(35, 13);
            this.labelCurrentPatient.TabIndex = 3;
            this.labelCurrentPatient.Text = "label3";
            // 
            // buttonStore
            // 
            this.buttonStore.Location = new System.Drawing.Point(178, 446);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(106, 23);
            this.buttonStore.TabIndex = 1;
            this.buttonStore.Text = "Store";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            // 
            // monthCalendarFinalReport
            // 
            this.monthCalendarFinalReport.Location = new System.Drawing.Point(9, 59);
            this.monthCalendarFinalReport.Name = "monthCalendarFinalReport";
            this.monthCalendarFinalReport.TabIndex = 3;
            this.monthCalendarFinalReport.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarFinalReport_DateSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Inserts a date into the current";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "position into the Final Report.";
            // 
            // buttonPrintFurtherTreatment
            // 
            this.buttonPrintFurtherTreatment.Location = new System.Drawing.Point(290, 446);
            this.buttonPrintFurtherTreatment.Name = "buttonPrintFurtherTreatment";
            this.buttonPrintFurtherTreatment.Size = new System.Drawing.Size(124, 23);
            this.buttonPrintFurtherTreatment.TabIndex = 2;
            this.buttonPrintFurtherTreatment.Text = "Print Final Report";
            this.buttonPrintFurtherTreatment.UseVisualStyleBackColor = true;
            this.buttonPrintFurtherTreatment.Click += new System.EventHandler(this.buttonPrintFinalReport_Click);
            // 
            // listBoxFinalReportTextElements
            // 
            this.listBoxFinalReportTextElements.FormattingEnabled = true;
            this.listBoxFinalReportTextElements.Location = new System.Drawing.Point(9, 293);
            this.listBoxFinalReportTextElements.Name = "listBoxFinalReportTextElements";
            this.listBoxFinalReportTextElements.Size = new System.Drawing.Size(164, 147);
            this.listBoxFinalReportTextElements.TabIndex = 6;
            this.listBoxFinalReportTextElements.SelectedValueChanged += new System.EventHandler(this.listBoxFinalReportTextElements_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Default Textelements:";
            // 
            // FinalReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxFinalReportTextElements);
            this.Controls.Add(this.buttonPrintFurtherTreatment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendarFinalReport);
            this.Controls.Add(this.buttonStore);
            this.Controls.Add(this.labelCurrentPatient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFinalReport);
            this.Controls.Add(this.labelFurtherTreatment);
            this.Name = "FinalReportControl";
            this.Size = new System.Drawing.Size(687, 476);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFurtherTreatment;
        private System.Windows.Forms.TextBox textBoxFinalReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentPatient;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.MonthCalendar monthCalendarFinalReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPrintFurtherTreatment;
        private System.Windows.Forms.ListBox listBoxFinalReportTextElements;
        private System.Windows.Forms.Label label4;
    }
}
