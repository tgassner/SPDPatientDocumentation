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
            this.buttonStoreAndPrintOPs = new System.Windows.Forms.Button();
            this.listBoxStoneReportTextElements = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStoreAndPrintVisits = new System.Windows.Forms.Button();
            this.buttonStoreAndPrintOPsAndVisits = new System.Windows.Forms.Button();
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
            this.textBoxStoneReport.Size = new System.Drawing.Size(509, 406);
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
            this.buttonStore.Location = new System.Drawing.Point(214, 446);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(68, 23);
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
            // buttonStoreAndPrintOPs
            // 
            this.buttonStoreAndPrintOPs.Location = new System.Drawing.Point(288, 446);
            this.buttonStoreAndPrintOPs.Name = "buttonStoreAndPrintOPs";
            this.buttonStoreAndPrintOPs.Size = new System.Drawing.Size(143, 23);
            this.buttonStoreAndPrintOPs.TabIndex = 2;
            this.buttonStoreAndPrintOPs.Text = "Store and print OPs";
            this.buttonStoreAndPrintOPs.UseVisualStyleBackColor = true;
            this.buttonStoreAndPrintOPs.Click += new System.EventHandler(this.buttonStoreAndPrintOPs_Click);
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
            // buttonStoreAndPrintVisits
            // 
            this.buttonStoreAndPrintVisits.Location = new System.Drawing.Point(437, 447);
            this.buttonStoreAndPrintVisits.Name = "buttonStoreAndPrintVisits";
            this.buttonStoreAndPrintVisits.Size = new System.Drawing.Size(119, 23);
            this.buttonStoreAndPrintVisits.TabIndex = 10;
            this.buttonStoreAndPrintVisits.Text = "Store and print Visits";
            this.buttonStoreAndPrintVisits.UseVisualStyleBackColor = true;
            this.buttonStoreAndPrintVisits.Click += new System.EventHandler(this.buttonStoreAndPrintVisits_Click);
            // 
            // buttonStoreAndPrintOPsAndVisits
            // 
            this.buttonStoreAndPrintOPsAndVisits.Location = new System.Drawing.Point(562, 447);
            this.buttonStoreAndPrintOPsAndVisits.Name = "buttonStoreAndPrintOPsAndVisits";
            this.buttonStoreAndPrintOPsAndVisits.Size = new System.Drawing.Size(161, 23);
            this.buttonStoreAndPrintOPsAndVisits.TabIndex = 11;
            this.buttonStoreAndPrintOPsAndVisits.Text = "Store and print OPs and Visits";
            this.buttonStoreAndPrintOPsAndVisits.UseVisualStyleBackColor = true;
            this.buttonStoreAndPrintOPsAndVisits.Click += new System.EventHandler(this.buttonStoreAndPrintOPsAndVisits_Click);
            // 
            // StoneReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonStoreAndPrintOPsAndVisits);
            this.Controls.Add(this.buttonStoreAndPrintVisits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxStoneReportTextElements);
            this.Controls.Add(this.buttonStoreAndPrintOPs);
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
        private System.Windows.Forms.Button buttonStoreAndPrintOPs;
        private System.Windows.Forms.ListBox listBoxStoneReportTextElements;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStoreAndPrintVisits;
        private System.Windows.Forms.Button buttonStoreAndPrintOPsAndVisits;
    }
}
