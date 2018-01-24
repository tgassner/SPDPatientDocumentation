namespace SPD.GUI
{
    partial class StoneReportControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelStoneReport = new System.Windows.Forms.Label();
            this.textBoxStoneReport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentPatient = new System.Windows.Forms.Label();
            this.buttonStore = new System.Windows.Forms.Button();
            this.monthCalendarStoneReport = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPrintStoneReport = new System.Windows.Forms.Button();
            this.listBoxStoneReportTextElements = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxStoneReportOperations = new System.Windows.Forms.CheckBox();
            this.checkBoxStoneReportVisits = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelStoneReport
            // 
            this.labelStoneReport.AutoSize = true;
            this.labelStoneReport.Location = new System.Drawing.Point(141, 37);
            this.labelStoneReport.Name = "labelStoneReport";
            this.labelStoneReport.Size = new System.Drawing.Size(73, 13);
            this.labelStoneReport.TabIndex = 0;
            this.labelStoneReport.Text = "Stone Report:";
            // 
            // textBoxStoneReport
            // 
            this.textBoxStoneReport.Location = new System.Drawing.Point(214, 34);
            this.textBoxStoneReport.Multiline = true;
            this.textBoxStoneReport.Name = "textBoxStoneReport";
            this.textBoxStoneReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStoneReport.Size = new System.Drawing.Size(458, 406);
            this.textBoxStoneReport.TabIndex = 0;
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
            // monthCalendarStoneReport
            // 
            this.monthCalendarStoneReport.Location = new System.Drawing.Point(9, 59);
            this.monthCalendarStoneReport.Name = "monthCalendarStoneReport";
            this.monthCalendarStoneReport.TabIndex = 3;
            this.monthCalendarStoneReport.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarStoneReport_DateSelected);
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
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "position into the Stone Report.";
            // 
            // buttonPrintStoneReport
            // 
            this.buttonPrintStoneReport.Location = new System.Drawing.Point(290, 446);
            this.buttonPrintStoneReport.Name = "buttonPrintStoneReport";
            this.buttonPrintStoneReport.Size = new System.Drawing.Size(124, 23);
            this.buttonPrintStoneReport.TabIndex = 2;
            this.buttonPrintStoneReport.Text = "Print Stone Report";
            this.buttonPrintStoneReport.UseVisualStyleBackColor = true;
            this.buttonPrintStoneReport.Click += new System.EventHandler(this.buttonPrintStoneReport_Click);
            // 
            // listBoxStoneReportTextElements
            // 
            this.listBoxStoneReportTextElements.FormattingEnabled = true;
            this.listBoxStoneReportTextElements.Location = new System.Drawing.Point(9, 293);
            this.listBoxStoneReportTextElements.Name = "listBoxStoneReportTextElements";
            this.listBoxStoneReportTextElements.Size = new System.Drawing.Size(164, 147);
            this.listBoxStoneReportTextElements.TabIndex = 6;
            this.listBoxStoneReportTextElements.SelectedValueChanged += new System.EventHandler(this.listBoxStoneReportTextElements_SelectedValueChanged);
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
            // checkBoxStoneReportOperations
            // 
            this.checkBoxStoneReportOperations.AutoSize = true;
            this.checkBoxStoneReportOperations.Location = new System.Drawing.Point(678, 36);
            this.checkBoxStoneReportOperations.Name = "checkBoxStoneReportOperations";
            this.checkBoxStoneReportOperations.Size = new System.Drawing.Size(101, 17);
            this.checkBoxStoneReportOperations.TabIndex = 8;
            this.checkBoxStoneReportOperations.Text = "Print Operations";
            this.checkBoxStoneReportOperations.UseVisualStyleBackColor = true;
            // 
            // checkBoxStoneReportVisits
            // 
            this.checkBoxStoneReportVisits.AutoSize = true;
            this.checkBoxStoneReportVisits.Location = new System.Drawing.Point(678, 60);
            this.checkBoxStoneReportVisits.Name = "checkBoxStoneReportVisits";
            this.checkBoxStoneReportVisits.Size = new System.Drawing.Size(74, 17);
            this.checkBoxStoneReportVisits.TabIndex = 9;
            this.checkBoxStoneReportVisits.Text = "Print Visits";
            this.checkBoxStoneReportVisits.UseVisualStyleBackColor = true;
            // 
            // StoneReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxStoneReportVisits);
            this.Controls.Add(this.checkBoxStoneReportOperations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxStoneReportTextElements);
            this.Controls.Add(this.buttonPrintStoneReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendarStoneReport);
            this.Controls.Add(this.buttonStore);
            this.Controls.Add(this.labelCurrentPatient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxStoneReport);
            this.Controls.Add(this.labelStoneReport);
            this.Name = "StoneReportControl";
            this.Size = new System.Drawing.Size(925, 476);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStoneReport;
        private System.Windows.Forms.TextBox textBoxStoneReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentPatient;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.MonthCalendar monthCalendarStoneReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPrintStoneReport;
        private System.Windows.Forms.ListBox listBoxStoneReportTextElements;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxStoneReportOperations;
        private System.Windows.Forms.CheckBox checkBoxStoneReportVisits;
    }
}
