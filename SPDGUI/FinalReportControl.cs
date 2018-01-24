using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SPD.CommonObjects;
using SPD.Print;
using SPD.BL.Interfaces;

namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public delegate void NewFinalReportStoreEventHandler(object sender,
             NewFinalReportStoreEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class FinalReportControl : UserControl {
        private PatientData currentPatient;
        private string finalReport;
        private ISPDBL patComp;

        /// <summary>
        /// Gets or sets the text box final report.
        /// </summary>
        /// <value>The text box final report.</value>
        public System.Windows.Forms.TextBox TextBoxFinalReport {
            set { textBoxFinalReport = value; }
            get { return textBoxFinalReport; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinalReportControl"/> class.
        /// </summary>
        public FinalReportControl() {
            InitializeComponent();

        }

        /// <summary>
        /// Gets or sets the current patient.
        /// </summary>
        /// <value>The current patient.</value>
        public PatientData CurrentPatient {
            get { return currentPatient; }
            set { currentPatient = value; }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear() {
            textBoxFinalReport.Text = "";
        }

        /// <summary>
        /// Inits the specified final report.
        /// </summary>
        /// <param name="finalReport">The final report.</param>
        /// <param name="patComp">The pat comp.</param>
        public void Init(string finalReport, ISPDBL patComp) {
            this.finalReport = finalReport;
            this.patComp = patComp;
            Clear();
            if (this.finalReport != null) {
                if (finalReport.Equals("")) {
                    textBoxFinalReport.Text = finalReport +
                        new System.Globalization.DateTimeFormatInfo().GetDayName(DateTime.Now.DayOfWeek) + ", " + new System.Globalization.DateTimeFormatInfo().GetMonthName(DateTime.Now.Month) + " " + DateTime.Now.Day.ToString() + ". " + DateTime.Now.Year.ToString() + 
                        "\r\n";
                } else {
                    textBoxFinalReport.Text = finalReport + 
                        "\r\n" +
                        new System.Globalization.DateTimeFormatInfo().GetDayName(DateTime.Now.DayOfWeek) + ", " + new System.Globalization.DateTimeFormatInfo().GetMonthName(DateTime.Now.Month) + " " + DateTime.Now.Day.ToString() + ". " + DateTime.Now.Year.ToString() + 
                        "\r\n";
                }
            }
            if (currentPatient != null) {
                this.labelCurrentPatient.Text = currentPatient.Id.ToString() + " " + currentPatient.FirstName + " " + currentPatient.SurName;
            }

            if (SPD.GUI.Properties.Settings.Default.FinalReportTextElements != null && SPD.GUI.Properties.Settings.Default.FinalReportTextElements.Count != 0) {
                foreach (string textElement in SPD.GUI.Properties.Settings.Default.FinalReportTextElements) {
                    listBoxFinalReportTextElements.Items.Add(textElement);
                }
            }
        }

        /// <summary>
        /// Occurs when [store].
        /// </summary>
        public event NewFinalReportStoreEventHandler Store;

        private void buttonStore_Click(object sender, EventArgs e)
        {
            store();
        }

        private void store()
        {
            NewFinalReportStoreEventArgs e2 = new NewFinalReportStoreEventArgs(
                textBoxFinalReport.Text);
            Store(this, e2);
        }

        private void buttonStoreAndPrintFinalReport_Click(object sender, EventArgs e) {
            store();
            if (patComp.GetLastOperationByPatientID(currentPatient.Id) == null) {
                MessageBox.Show("This Patient hasn't got a Operation\r\nNo Final Report can be printed!");
                return;
            }
            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> patients = new List<PatientData>();
            patients.Add(currentPatient);
            print.PrintFinalReport(patients);
        }

        private void monthCalendarFinalReport_DateSelected(object sender, DateRangeEventArgs e) {
            string insertString = monthCalendarFinalReport.SelectionStart.DayOfWeek.ToString() + ", " + new System.Globalization.DateTimeFormatInfo().GetMonthName(monthCalendarFinalReport.SelectionStart.Month) + " " + monthCalendarFinalReport.SelectionStart.Day.ToString() + ". " + monthCalendarFinalReport.SelectionStart.Year.ToString();
            int cursorPos = textBoxFinalReport.SelectionStart;
            textBoxFinalReport.Text = textBoxFinalReport.Text.Insert(textBoxFinalReport.SelectionStart, insertString);
            this.textBoxFinalReport.Select(cursorPos + insertString.Length, 0);
            this.textBoxFinalReport.Focus();
        }

        private void listBoxFinalReportTextElements_SelectedValueChanged(object sender, EventArgs e) {
            if (listBoxFinalReportTextElements.SelectedItems.Count >= 1) {
                string insertString = listBoxFinalReportTextElements.SelectedItem.ToString() + " ";
                int cursorPos = textBoxFinalReport.SelectionStart;
                textBoxFinalReport.Text = textBoxFinalReport.Text.Insert(textBoxFinalReport.SelectionStart, insertString);
                this.textBoxFinalReport.Select(cursorPos + insertString.Length, 0);

                listBoxFinalReportTextElements.SelectedItems.Clear();
                this.textBoxFinalReport.Focus();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NewFinalReportStoreEventArgs : EventArgs {
        private string finalReport;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewFinalReportStoreEventArgs"/> class.
        /// </summary>
        /// <param name="finalReport">The final report.</param>
        public NewFinalReportStoreEventArgs(string finalReport) {
            this.finalReport = finalReport;
        }

        /// <summary>
        /// Gets the final report.
        /// </summary>
        /// <value>The final report.</value>
        public string FinalReport {
            get { return finalReport; }
        }
    }
}
