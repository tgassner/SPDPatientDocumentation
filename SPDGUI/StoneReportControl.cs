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
    public delegate void NewStoneReportStoreEventHandler(object sender,
             NewStoneReportStoreEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class StoneReportControl : UserControl {
        private PatientData currentPatient;
        private string stoneReport;
        private ISPDBL patComp;

        public System.Windows.Forms.TextBox TextBoxStoneReport
        {
            set { textBoxStoneReport = value; }
            get { return textBoxStoneReport; }
        }

        public StoneReportControl() {
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
            textBoxStoneReport.Text = "";
        }

        public void Init(string stoneReport, ISPDBL patComp) {
            this.stoneReport = stoneReport;
            this.patComp = patComp;
            Clear();
            if (this.stoneReport != null) {
                if (stoneReport.Equals("")) {
                    textBoxStoneReport.Text = stoneReport +
                        new System.Globalization.DateTimeFormatInfo().GetDayName(DateTime.Now.DayOfWeek) + ", " + new System.Globalization.DateTimeFormatInfo().GetMonthName(DateTime.Now.Month) + " " + DateTime.Now.Day.ToString() + ". " + DateTime.Now.Year.ToString() + 
                        "\r\n";
                } else {
                    textBoxStoneReport.Text = stoneReport + 
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
                    listBoxStoneReportTextElements.Items.Add(textElement);
                }
            }
        }

        /// <summary>
        /// Occurs when [store].
        /// </summary>
        public event NewStoneReportStoreEventHandler Store;

        private void buttonStore_Click(object sender, EventArgs e)
        {
            store();
        }

        private void store()
        {
            NewStoneReportStoreEventArgs e2 = new NewStoneReportStoreEventArgs(
                textBoxStoneReport.Text);
            Store(this, e2);
        }

        private void buttonStoreAndPrintOPs_Click(object sender, EventArgs e) {
            store();
            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> patients = new List<PatientData>();
            patients.Add(currentPatient);
            print.PrintStoneReport(patients, true, false);
        }

        private void buttonStoreAndPrintVisits_Click(object sender, EventArgs e) {
            store();
            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> patients = new List<PatientData>();
            patients.Add(currentPatient);
            print.PrintStoneReport(patients, false, true);
        }

        private void buttonStoreAndPrintOPsAndVisits_Click(object sender, EventArgs e) {
            store();
            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> patients = new List<PatientData>();
            patients.Add(currentPatient);
            print.PrintStoneReport(patients, true, true);
        }

        private void monthCalendarStoneReport_DateSelected(object sender, DateRangeEventArgs e) {
            string insertString = monthCalendarStoneReport.SelectionStart.DayOfWeek.ToString() + ", " + new System.Globalization.DateTimeFormatInfo().GetMonthName(monthCalendarStoneReport.SelectionStart.Month) + " " + monthCalendarStoneReport.SelectionStart.Day.ToString() + ". " + monthCalendarStoneReport.SelectionStart.Year.ToString();
            int cursorPos = textBoxStoneReport.SelectionStart;
            textBoxStoneReport.Text = textBoxStoneReport.Text.Insert(textBoxStoneReport.SelectionStart, insertString);
            this.textBoxStoneReport.Select(cursorPos + insertString.Length, 0);
            this.textBoxStoneReport.Focus();
        }

        private void listBoxStoneReportTextElements_SelectedValueChanged(object sender, EventArgs e) {
            if (listBoxStoneReportTextElements.SelectedItems.Count >= 1) {
                string insertString = listBoxStoneReportTextElements.SelectedItem.ToString() + " ";
                int cursorPos = textBoxStoneReport.SelectionStart;
                textBoxStoneReport.Text = textBoxStoneReport.Text.Insert(textBoxStoneReport.SelectionStart, insertString);
                this.textBoxStoneReport.Select(cursorPos + insertString.Length, 0);

                listBoxStoneReportTextElements.SelectedItems.Clear();
                this.textBoxStoneReport.Focus();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NewStoneReportStoreEventArgs : EventArgs {
        private string stoneReport;

        public NewStoneReportStoreEventArgs(string stoneReport) {
            this.stoneReport = stoneReport;
        }

        public string StoneReport {
            get { return stoneReport; }
        }
    }
}
