using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using SPD.CommonUtilities;
using ElencySolutions.CsvHelper;

namespace SPD.GUI {
    /// <summary>
    /// Overview Control
    /// </summary>
    public partial class OverviewControl : UserControl {
        private ISPDBL patComp;

        /// <summary>
        /// Initializes a new instance of the <see cref="OverviewControl" /> class.
        /// </summary>
        /// <param name="patComp">The pat comp.</param>
        public OverviewControl(BL.Interfaces.ISPDBL patComp) {
            InitializeComponent();

            this.patComp = patComp;

            listViewOverview.View = View.Details;
            listViewOverview.LabelEdit = false;
            listViewOverview.AllowColumnReorder = true;
            listViewOverview.FullRowSelect = true;

            // Create columns for the items and subitems.
            listViewOverview.Columns.Add("PID", 30);
            listViewOverview.Columns.Add("Last name", 60);
            listViewOverview.Columns.Add("First name", 60);

            listViewOverview.Columns.Add("#visits", 45);
            listViewOverview.Columns.Add("#ops", 40);
            listViewOverview.Columns.Add("fist visit", 70);
            listViewOverview.Columns.Add("last visit", 70);
            listViewOverview.Columns.Add("first op", 70);
            listViewOverview.Columns.Add("last op", 70);
            listViewOverview.Columns.Add("diagnose group", 70);
            listViewOverview.Columns.Add("finished", 50);
            listViewOverview.Columns.Add("first visit diagnose", 120);
            listViewOverview.Columns.Add("performed first op", 120);
            listViewOverview.Columns.Add("performed last op", 120);
        }

        internal void Init() {
            listViewOverview.Items.Clear();
            IList<PatientData> allPatients = this.patComp.GetAllPatients();
            IList<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (var pd in allPatients)
            {
                IList<VisitData> visits = this.patComp.GetVisitsByPatientID(pd.Id);
                IList<OperationData> ops = this.patComp.GetOperationsByPatientID(pd.Id);
                IList<DiagnoseGroupData> gds = this.patComp.FindDiagnoseGroupIdByPatientId(pd.Id);
                VisitData firstVisit = StaticUtilities.GetnThVisit(visits, 1);
                VisitData lastVisit = StaticUtilities.GetnThVisit(visits, -1);
                OperationData firstOp = StaticUtilities.OldestOP(ops);
                OperationData lastOp = StaticUtilities.NewestOP(ops);
                StringBuilder sb = new StringBuilder();
                foreach (DiagnoseGroupData dbgd in gds) {
                    sb.Append(dbgd.ShortName).Append(", ");
                }
                if (sb.Length >= 2) {
                    sb.Remove(sb.Length - 2, 2);
                }
                string diagnoseGroup = sb.ToString();
                StringBuilder toolTipSB = new StringBuilder();

                string firstVisitStr = (firstVisit == null) ? String.Empty : firstVisit.VisitDate.ToShortDateString();
                string lastVisitStr = (lastVisit == null) ? String.Empty : lastVisit.VisitDate.ToShortDateString();
                string firstOpStr = (firstOp == null) ? String.Empty : firstOp.Date.ToShortDateString();
                string lastOpStr = (lastOp == null) ? String.Empty : lastOp.Date.ToShortDateString();
                string firstVisitDiagnoses = (firstVisit == null) ? string.Empty : firstVisit.ExtraDiagnosis;
                string performedFirstOP = (firstOp == null) ? string.Empty : firstOp.Performed;
                string performedLastOP = (lastOp == null) ? string.Empty : lastOp.Performed;

                ListViewItem item = new ListViewItem(pd.Id.ToString());
                toolTipSB.Append("ID: ").Append(pd.Id.ToString()).Append(Environment.NewLine);
                item.SubItems.Add(pd.SurName);
                toolTipSB.Append("Firstname: ").Append(pd.FirstName).Append(Environment.NewLine);
                item.SubItems.Add(pd.FirstName);
                toolTipSB.Append("Surname: ").Append(pd.SurName).Append(Environment.NewLine);
                //# Visits
                item.SubItems.Add(visits.Count.ToString());
                toolTipSB.Append("Number of Visits: ").Append(visits.Count.ToString()).Append(Environment.NewLine);
                //#OPs
                item.SubItems.Add(ops.Count.ToString());
                toolTipSB.Append("Number of OPs: ").Append(ops.Count.ToString()).Append(Environment.NewLine);
                //First Visit
                item.SubItems.Add(firstVisitStr);
                toolTipSB.Append("First Visit: ").Append(firstVisitStr).Append(Environment.NewLine);
                //last Visit
                item.SubItems.Add(lastVisitStr);
                toolTipSB.Append("Last Visit: ").Append(lastVisitStr).Append(Environment.NewLine);
                //first OP
                item.SubItems.Add(firstOpStr);
                toolTipSB.Append("First OP: ").Append(firstOpStr).Append(Environment.NewLine);
                //last OP
                item.SubItems.Add(lastOpStr);
                toolTipSB.Append("Last OP: ").Append(lastOpStr).Append(Environment.NewLine);
                //diagnose Group
                item.SubItems.Add(diagnoseGroup);
                toolTipSB.Append("Diagnose Groups: ").Append(diagnoseGroup).Append(Environment.NewLine);
                //finished
                item.SubItems.Add(pd.Finished.ToString());
                toolTipSB.Append("Finished: ").Append(pd.Finished.ToString()).Append(Environment.NewLine);
                //first Visit Diagnoses
                item.SubItems.Add(firstVisitDiagnoses);
                toolTipSB.Append("First Visit Diagnoses: ").Append(firstVisitDiagnoses).Append(Environment.NewLine);
                //performed first OP
                item.SubItems.Add(performedFirstOP);
                toolTipSB.Append("Performed first OP: ").Append(performedFirstOP).Append(Environment.NewLine);
                //performed last OP
                item.SubItems.Add(performedLastOP);
                toolTipSB.Append("Performed last OP: ").Append(performedLastOP).Append(Environment.NewLine);

                item.ToolTipText = toolTipSB.ToString();
                listViewItems.Add(item);
            }

            listViewOverview.Items.AddRange(listViewItems.ToArray());

            if (listViewOverview.Items.Count > 0) {
                listViewOverview.SelectedIndices.Add(0);
            }


        }

        private void buttonExportCSV_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (Comma Seperated Values) (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.FileName = string.Format("SPD Datenauswertung {0}.{1}.{2}.csv", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK) {
                exportCsv(sfd.FileName);
            }
        }

        private void exportCsv(string file) {
            CsvFile csvFile = new CsvFile();
            
            IList<PatientData> allPatients = this.patComp.GetAllPatients();

            //Haader
            CsvRecord header = new CsvRecord();
            header.Fields.Add("ID");
            header.Fields.Add("Nachname");
            header.Fields.Add("Vorname");
            header.Fields.Add("m/w");
            header.Fields.Add("Geburtsdatum");
            header.Fields.Add("Telefon");
            header.Fields.Add("Datum Erstkontakt");
            header.Fields.Add("Diagnosegruppe");
            header.Fields.Add("Diagnose1");
            header.Fields.Add("Diagnose2");
            header.Fields.Add("Diagnose3");
            header.Fields.Add("VorOP vor Erstkontakt");
            header.Fields.Add("bisherige Therapie OP/Konservativ");
            header.Fields.Add("Datum Erst-OP");
            header.Fields.Add("Art Erst-OP");
            header.Fields.Add("Anzahl weitere OP");
            header.Fields.Add("op-pfl. Rezidiv nach (Erst)-OP ja/nein");
            header.Fields.Add("Anzahl OP insgesamt");
            header.Fields.Add("Datum Letzt-OP");
            header.Fields.Add("Anzahl Visits insgesamt");
            header.Fields.Add("Datum letzter Visit");
            header.Fields.Add("Abgeschlossen");
            header.Fields.Add("Besonderes");
            
            csvFile.Records.Add(header);

            foreach (var pd in allPatients) {

                IList<VisitData> visits = this.patComp.GetVisitsByPatientID(pd.Id);
                IList<OperationData> ops = this.patComp.GetOperationsByPatientID(pd.Id);
                IList<DiagnoseGroupData> gds = this.patComp.FindDiagnoseGroupIdByPatientId(pd.Id);
                VisitData firstVisit = StaticUtilities.GetnThVisit(visits, 1);
                VisitData secondVisit = StaticUtilities.GetnThVisit(visits, 2);
                VisitData thirdVisit = StaticUtilities.GetnThVisit(visits, 3);
                VisitData lastVisit = StaticUtilities.GetnThVisit(visits, -1);
                OperationData firstOp = StaticUtilities.OldestOP(ops);
                OperationData lastOp = StaticUtilities.NewestOP(ops);
                StringBuilder sb = new StringBuilder();
                foreach (DiagnoseGroupData dbgd in gds) {
                    sb.Append(dbgd.ShortName).Append(", ");
                }
                if (sb.Length >= 2) {
                    sb.Remove(sb.Length - 2, 2);
                }
                string diagnoseGroup = sb.ToString();
                StringBuilder toolTipSB = new StringBuilder();

                string firstVisitDateStr = (firstVisit == null) ? String.Empty : firstVisit.VisitDate.ToShortDateString();
                string lastVisitDateStr = (lastVisit == null) ? String.Empty : lastVisit.VisitDate.ToShortDateString();
                string firstOpDateStr = (firstOp == null) ? String.Empty : firstOp.Date.ToShortDateString();
                string lastOpDateStr = (lastOp == null) ? String.Empty : lastOp.Date.ToShortDateString();
                string firstVisitDiagnoses = (firstVisit == null) ? string.Empty : firstVisit.ExtraDiagnosis;
                string secondVisitDiagnoses = (secondVisit == null) ? string.Empty : secondVisit.ExtraDiagnosis;
                string thirdVisitDiagnoses = (thirdVisit == null) ? string.Empty : thirdVisit.ExtraDiagnosis;
                string performedFirstOP = (firstOp == null) ? string.Empty : firstOp.Performed;
                string performedLastOP = (lastOp == null) ? string.Empty : lastOp.Performed;

                CsvRecord dataLine = new CsvRecord();
                
                dataLine.Fields.Add(pd.Id.ToString());
                dataLine.Fields.Add(pd.FirstName);
                dataLine.Fields.Add(pd.SurName);
                dataLine.Fields.Add(pd.Sex.ToString());
                dataLine.Fields.Add(pd.DateOfBirth.ToShortDateString());
                dataLine.Fields.Add(pd.Phone);
                dataLine.Fields.Add(firstVisitDateStr);
                dataLine.Fields.Add(diagnoseGroup);
                dataLine.Fields.Add(firstVisitDiagnoses);
                dataLine.Fields.Add(secondVisitDiagnoses);
                dataLine.Fields.Add(thirdVisitDiagnoses);
                dataLine.Fields.Add("TODO");
                dataLine.Fields.Add("TODO");
                dataLine.Fields.Add(firstOpDateStr);
                dataLine.Fields.Add(performedFirstOP);
                dataLine.Fields.Add((ops.Count > 0) ? (ops.Count - 1).ToString() : ops.Count.ToString());
                dataLine.Fields.Add("TODO");
                dataLine.Fields.Add(ops.Count.ToString());
                dataLine.Fields.Add(lastOpDateStr);
                dataLine.Fields.Add(visits.Count.ToString());
                dataLine.Fields.Add(lastVisitDateStr);
                dataLine.Fields.Add(pd.Finished.ToString());
                dataLine.Fields.Add("TODO");

                csvFile.Records.Add(dataLine);
            }

            using (CsvWriter writer = new CsvWriter()) {
                writer.QuotesAlways = true;
                writer.Seperator = ";";
                try
                {
                    writer.WriteCsv(csvFile, file);
                }
                catch (Exception e)
                {

                    MessageBox.Show("Could not write CSV File because:" + Environment.NewLine + e.Message);
                }
                
            }
        }
    }
}
