using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SPD.CommonObjects;
using SPD.BL.Interfaces;
using SPD.Print;
using SPD.GUI.Print.HTML;
using System.Threading;

namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public partial class PrintMorePatientsControl : UserControl {

        private ISPDBL patComp;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintMorePatientsControl"/> class.
        /// </summary>
        public PrintMorePatientsControl() {
            InitializeComponent();

            this.listBoxDays.Items.AddRange(new object[] {"12", "24", "36", "48", "60"});

            this.listBoxCopys.Items.AddRange(new object[] {"1", "2", "3", "4", "5"});

            this.listBoxHeadline.Items.AddRange(new object[]{"Operation", "Ambulant", "Linz", "None"});

            this.listBoxDays.SelectedIndex = 0;
            this.listBoxCopys.SelectedIndex = 1;
            this.listBoxHeadline.SelectedIndex = 0;

            listViewAllPatients.View = View.List;
            listViewAllPatients.FullRowSelect = true;
            //listViewAllPatients.

            // Create columns for the items and subitems.
            listViewAllPatients.Columns.Add("PID", 50);
            listViewAllPatients.Columns.Add("Last name", 220);
            listViewAllPatients.Columns.Add("First name", 220);
            listViewAllPatients.Columns.Add("Age", 45);
            listViewAllPatients.Columns.Add("Sex", 45);
            listViewAllPatients.Columns.Add("Address", 200);
            listViewAllPatients.Columns.Add("Weight", 50);
            listViewAllPatients.Columns.Add("Phone", 120);
        }

        /// <summary>
        /// Initts the specified pat comp.
        /// </summary>
        /// <param name="patComp">The pat comp.</param>
        internal void Init(ISPDBL patComp) {
            this.patComp = patComp;
            listViewAllPatients.Items.Clear();
            List<ListViewItem> items = new List<ListViewItem>();
            foreach(PatientData patient in this.patComp.GetAllPatients()) {
                ListViewItem item = new ListViewItem(patient.Id.ToString());
                item.SubItems.Add(patient.SurName);
                item.SubItems.Add(patient.FirstName);
                item.SubItems.Add(CommonUtilities.StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth));
                item.SubItems.Add(patient.Sex.ToString());
                item.SubItems.Add(patient.Address);
                item.SubItems.Add(patient.Weight.ToString());
                item.SubItems.Add(patient.Phone);
                //listViewAllPatients.Items.Add(item);
                items.Add(item);
            }

            Application.DoEvents();

            listViewAllPatients.Items.AddRange(items.ToArray());

            this.checkBoxVisits.Checked = true;
            this.checkBoxFurtherTreatment.Checked = true;
            this.checkBoxPhotoLinks.Checked = true;
            this.checkBoxOperations.Checked = true;

            this.textBoxTopBorder.Text = SPD.GUI.Properties.Settings.Default.TopBorder.ToString();
            this.textBoxLeftBorder.Text = SPD.GUI.Properties.Settings.Default.LeftBorder.ToString();
            this.textBoxNumberOfColumns.Text = SPD.GUI.Properties.Settings.Default.NoOfColumns.ToString();
            this.textBoxNumberOfRows.Text = SPD.GUI.Properties.Settings.Default.NoOfRows.ToString();
            this.textBoxLabelFontSize.Text = SPD.GUI.Properties.Settings.Default.LabelFontSize.ToString();
            this.textBoxStartingRow.Text = "1";

            listBoxHalfYear.Items.Clear();
            listBoxAction.Items.Clear();
            comboBoxNextActionYear.Items.Clear();

            foreach (String action in Enum.GetNames(new ActionKind().GetType())) {
                this.listBoxAction.Items.Add(action);
            }
            this.listBoxAction.SelectedIndex = 1;

            this.listBoxHalfYear.Items.Add("1");
            this.listBoxHalfYear.Items.Add("2");
            this.listBoxHalfYear.SelectedIndex = (DateTime.Now.Month <= 6) ? 1 : 0;

            for (int i = 0; i < 10; i++) {
                this.comboBoxNextActionYear.Items.Add(i + DateTime.Now.Year - 1);
            }
            this.comboBoxNextActionYear.Text = (DateTime.Now.Month <= 6) ? DateTime.Now.Year.ToString() : (DateTime.Now.Year + 1).ToString();

            listViewAllPatients.Select();
        }

        private void buttonSelectAll_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listViewAllPatients.Items) {
                item.Selected = true;
            }
            listViewAllPatients.Select();
        }

        private void buttonUnSelectAll_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listViewAllPatients.Items) {
                item.Selected = false;
            }
            listViewAllPatients.Select();
        }

        private void buttonOperationFromToSelect_Click(object sender, EventArgs e) {
            for(int i = 0; i < listViewAllPatients.Items.Count; i++) {
                long pId = Int64.Parse(listViewAllPatients.Items[i].Text);
                OperationData operation = patComp.GetLastOperationByPatientID(pId);
                if(operation != null) {
                    if(operation.Date.Date >= dateTimePickerOperationFrom.Value.Date &&
                                operation.Date.Date <= dateTimePickerOperationTo.Value.Date) {
                        listViewAllPatients.Items[i].Selected = true;
                    } else {
                        listViewAllPatients.Items[i].Selected = false;
                    }
                } else {
                    listViewAllPatients.Items[i].Selected = false;
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e) {
            IList<PatientData> toPrintPatients = getSelectedPatients();

            if(toPrintPatients.Count <= 0) {
                MessageBox.Show("No patients selected!\nPleas select one or more Patients to print");
                return;
            }

            SPD.Print.SPDPrint.PatientPrintDetails patientPrintDetails = 0;

            if(this.checkBoxVisits.Checked)
                patientPrintDetails = patientPrintDetails | SPDPrint.PatientPrintDetails.Visits;
            if(this.checkBoxFurtherTreatment.Checked)
                patientPrintDetails = patientPrintDetails | SPDPrint.PatientPrintDetails.FinalReport;
            if(this.checkBoxPhotoLinks.Checked)
                patientPrintDetails = patientPrintDetails | SPDPrint.PatientPrintDetails.Fotolinks;
            if(this.checkBoxOperations.Checked)
                patientPrintDetails = patientPrintDetails | SPDPrint.PatientPrintDetails.Operations;

            SPDPrint print = new SPDPrint(this.patComp);
            print.PrintPatients(toPrintPatients, patientPrintDetails);
        }

        private void printA3TemperaturCurves(int weeks, int copies) {
            IList<PatientData> toPrintPatients = getSelectedPatients();

            if (toPrintPatients.Count <= 0) {
                MessageBox.Show("No patients selected!\nPlease select one or more Patients to print");
                return;
            }

            SPDPrint print = new SPDPrint(this.patComp);
            print.PrintA3TemperaturCurve(toPrintPatients, weeks, copies, SPDPrint.PrintFormat.A3, null);
        }

        private void buttonPrintLabels_Click(object sender, EventArgs e) { 
            IList<PatientData> toPrintPatients = new List<PatientData>();

            int topBorder;
            int leftBorder;
            int noOfColumns;
            int noOfRows;
            int startingRow;
            int labelFontSize;

            try {
                topBorder = Int32.Parse(textBoxTopBorder.Text);
            } catch(FormatException) {
                MessageBox.Show("TopBorder has a wrong Format!");
                return;
            }

            try {
                leftBorder = Int32.Parse(textBoxLeftBorder.Text);
            } catch(FormatException) {
                MessageBox.Show("LeftBorder has a wrong Format!");
                return;
            }

            try {
                noOfColumns = Int32.Parse(textBoxNumberOfColumns.Text);
            } catch(FormatException) {
                MessageBox.Show("Number Of Columns has a wrong Format!");
                return;
            }

            try {
                noOfRows = Int32.Parse(textBoxNumberOfRows.Text);
            } catch(FormatException) {
                MessageBox.Show("Number Of Rows has a wrong Format!");
                return;
            }

            try {
                startingRow = Int32.Parse(textBoxStartingRow.Text);
            } catch(FormatException) {
                MessageBox.Show("Starting Row has a wrong Format!");
                return;
            }

            try {
                labelFontSize = Int32.Parse(textBoxLabelFontSize.Text);
            } catch(FormatException) {
                MessageBox.Show("Label Font Size has a wrong Format!");
                return;
            }

            if(topBorder < 0) {
                MessageBox.Show("Top Border has to be positive");
                return;
            }

            if(leftBorder < 0) {
                MessageBox.Show("Left Border has to be positive");
                return;
            }

            if(noOfColumns < 1 || noOfColumns > 8) {
                MessageBox.Show("The number of Columns has to be between 1 and 8");
                return;
            }

            if(noOfRows < 1 || noOfColumns > 30) {
                MessageBox.Show("The number of Rows has to be between 1 and 30");
                return;
            }

            if(startingRow < 1 || startingRow >= noOfRows) {
                MessageBox.Show("The Starting Row has to be between 1 and the number of Rows -1");
                return;
            }

            if(labelFontSize < 4 || labelFontSize > 30) {
                MessageBox.Show("The Label Font Size has to be between 4 and 30");
                return;
            }

            List<long> pIds = new List<long>();

            foreach(ListViewItem item in listViewAllPatients.SelectedItems) {
                pIds.Add(Int64.Parse(item.Text));
            }

            toPrintPatients = this.patComp.FindPatientByIds(pIds);

            if(toPrintPatients.Count <= 0) {
                MessageBox.Show("No patients selected!\nPlease select one or more Patients to print");
                return;
            }

            SPD.GUI.Properties.Settings.Default.TopBorder = topBorder;
            SPD.GUI.Properties.Settings.Default.LeftBorder = leftBorder;
            SPD.GUI.Properties.Settings.Default.NoOfColumns = noOfColumns;
            SPD.GUI.Properties.Settings.Default.NoOfRows = noOfRows;
            SPD.GUI.Properties.Settings.Default.LabelFontSize = labelFontSize;
            SPD.GUI.Properties.Settings.Default.Save();

            SPDPrint print = new SPDPrint(this.patComp);
            print.PrintLabels(topBorder, leftBorder, noOfColumns, noOfRows, startingRow, labelFontSize, toPrintPatients);
                                                                            
        }

        private void buttonPrintNextActionList_Click(object sender, EventArgs e) { 
            SPDPrint print = new SPDPrint(this.patComp);
            long year;
            try {
                year = Int64.Parse(this.comboBoxNextActionYear.Text);
            } catch (Exception) {
                MessageBox.Show("The Year of the Next Action is not defined.");
                return;
            }
            long halfYear = Int64.Parse(this.listBoxHalfYear.Text);
            ActionKind actionKind = (ActionKind)Enum.Parse(new ActionKind().GetType(), this.listBoxAction.SelectedItem.ToString());
            print.PrintNextActionList(this.patComp.FindPatientsWithNextAction(year, halfYear, actionKind), year, halfYear, actionKind); 
        }

        private void buttonNextActionFaxList_Click(object sender, EventArgs e) {
            SPDPrint print = new SPDPrint(this.patComp);
            long year;
            try {
                year = Int64.Parse(this.comboBoxNextActionYear.Text);
            } catch (Exception) {
                MessageBox.Show("The Year of the Next Action is not defined.");
                return;
            }
            long halfYear = Int64.Parse(this.listBoxHalfYear.Text);
            ActionKind actionKind = (ActionKind)Enum.Parse(new ActionKind().GetType(), this.listBoxAction.SelectedItem.ToString());
            print.PrintNextActionFaxlist(this.patComp.FindPatientsWithNextAction(year, halfYear, actionKind), year, halfYear, actionKind);
        }

        private void buttonPrintNextActionListHtml_Click(object sender, EventArgs e) {  
            long year;
            try {
                year = Int64.Parse(this.comboBoxNextActionYear.Text);
            } catch (Exception) {
                MessageBox.Show("The Year of the Next Action is not defined.");
                return;
            }
            long halfYear = Int64.Parse(this.listBoxHalfYear.Text);
            ActionKind actionKind = (ActionKind)Enum.Parse(new ActionKind().GetType(), this.listBoxAction.SelectedItem.ToString());

            PrintHtml printHtml = new PrintHtml();
            printHtml.PrintWebBrowser.DocumentText = PrintNextActionHtml.getFullHtml(patComp, year, halfYear, actionKind);
            printHtml.ShowDialog();  
        }

        private IList<PatientData> getSelectedPatients() {
            IList<long> pIds = new List<long>();

            foreach (ListViewItem item in listViewAllPatients.SelectedItems) {
                pIds.Add(Int64.Parse(item.Text));
            }

            return this.patComp.FindPatientByIds(pIds);
        }

        private void buttonPrintA3TemperaturCurve_Click(object sender, EventArgs e) {
            int weeks = Int32.Parse(listBoxDays.SelectedItem.ToString()) / 12;
            int copys = Int32.Parse(listBoxCopys.SelectedItem.ToString());
            printA3TemperaturCurves(weeks, copys);
        }

        private void buttonListList_Click(object sender, EventArgs e) {
            this.listViewAllPatients.View = View.List;
        }

        private void buttonListDetails_Click(object sender, EventArgs e) {
            this.listViewAllPatients.View = View.Details;
        }

        private void buttonListTitle_Click(object sender, EventArgs e) {
            this.listViewAllPatients.View = View.Tile;
        }

        private void buttonSelectPatientId_Click(object sender, EventArgs e) {
            try
            {

            
            string pIds = textBoxPatientenIds.Text;
            pIds = pIds.Replace(" ", string.Empty);
            pIds = pIds.Replace("\t", string.Empty);
            pIds = pIds.Replace(";", ",");
            string[] splittedPIds = pIds.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            List<long> pIdsLong = new List<long>();
            foreach (var splittedPId in splittedPIds)
            {
                if (splittedPId.Contains("-")) {
                    string[] range = splittedPId.Split(new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                    if (range.Length != 2) {
                        throw new FormatException();
                    }
                    for(long i = Int64.Parse(range[0]); i <= Int64.Parse(range[1]); i++) {
                        pIdsLong.Add(i);
                    }
                } else {
                    pIdsLong.Add(Int64.Parse(splittedPId));
                }
            }
        

            foreach (ListViewItem item in listViewAllPatients.Items) {
                if (pIdsLong.Contains(Int64.Parse(item.Text))) {
                    item.Selected = true;
                } else {
                    item.Selected = false;
                }
            }

            listViewAllPatients.Select();

            } catch (FormatException)
            {
                MessageBox.Show("\"" + textBoxPatientenIds.Text + "\" is not Valid!");
            }
        }

        private void buttonSelectLinzPatients_Click(object sender, EventArgs e) {
            IList<PatientData> linzPatients = this.patComp.FindPatientByLinz(Linz.planned);
            ISet<long> linzPatientIds = new HashSet<long>();
            foreach (PatientData linzPatient in linzPatients)
            {
                linzPatientIds.Add(linzPatient.Id);
            }

            foreach (ListViewItem item in listViewAllPatients.Items) {
                if (linzPatientIds.Contains(Int64.Parse(item.Text))) {
                    item.Selected = true;
                } else {
                    item.Selected = false;
                }
            }

            listViewAllPatients.Select();
        }

        private void buttonSelectAmbulantPatients_Click(object sender, EventArgs e) {
            IList<PatientData> ambulantPatients = this.patComp.FindPatientByAmbulant(Ambulant.ambulant);
            ISet<long> ambulantPatientIds = new HashSet<long>();
            foreach (PatientData ambulantPatient in ambulantPatients) {
                ambulantPatientIds.Add(ambulantPatient.Id);
            }

            foreach (ListViewItem item in listViewAllPatients.Items) {
                if (ambulantPatientIds.Contains(Int64.Parse(item.Text))) {
                    item.Selected = true;
                } else {
                    item.Selected = false;
                }
            }

            listViewAllPatients.Select();
        }

        private void buttonPrintPatientList_Click(object sender, EventArgs e) {
            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> selectedPatients = getSelectedPatients();

            if (selectedPatients.Count == 0) {
                MessageBox.Show("No Patients Selected!");
                return;
            }

            print.PrintPatientList(selectedPatients, determineHeadline(listBoxHeadline.SelectedIndex), checkBoxUseOPDataIfAvailable.Checked); 
        }

        private void buttonPrintPatientListHTML_Click(object sender, EventArgs e) {
            IList<PatientData> selectedPatients = getSelectedPatients();

            if (selectedPatients.Count == 0) {
                MessageBox.Show("No Patients Selected!");
                return;
            }

            PrintHtml printHtml = new PrintHtml();
            printHtml.PrintWebBrowser.DocumentText = PrintPatientListHtml.getFullHtml(patComp, selectedPatients, determineHeadline(listBoxHeadline.SelectedIndex), checkBoxUseOPDataIfAvailable.Checked);
            printHtml.ShowDialog();
        }
        

        private string determineHeadline(int selectedIndex) {
            switch(selectedIndex)
            {
                case 0:
                    return "Operation";
                case 1:
                    return "Ambulant";
                case 2:
                    return "Linz";
                default:
                    return string.Empty;
            }
        }

        private void buttonPrintWaitList_Click(object sender, EventArgs e) {
            SPDPrint print = new SPDPrint(this.patComp);
            print.PrintWaitList(patComp.FindPatientByWaitList()); 
        }

        private void buttonPrintWaitListHTML_Click(object sender, EventArgs e) {
            IList<PatientData> selectedPatients = patComp.FindPatientByWaitList();

            if (selectedPatients.Count == 0) {
                MessageBox.Show("No Patients on Wait List!");
                return;
            }

            PrintHtml printHtml = new PrintHtml();
            printHtml.PrintWebBrowser.DocumentText = PrintWaitingListHtml.getFullHtml(patComp, selectedPatients, determineHeadline(listBoxHeadline.SelectedIndex));
            printHtml.ShowDialog();
        }
    }
}
