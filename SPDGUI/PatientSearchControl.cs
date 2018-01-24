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

    #region delegates

    /// <summary>
    /// 
    /// </summary>
    public delegate void AddVisitEventHandler(object sender,
             AddVisitEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void ShowVisitsEventHandler(object sender,
             ShowVisitsEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void ChangePatientDataEventHandler(object sender,
             ChangePatientDataEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void ShowPatientDataEventHandler(object sender,
             ShowPatientDataEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void AddOperationEventHandler(object sender,
             AddOperationEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void AddFurtherTreatmentEventHandler(object sender,
             AddFurtherTreatmentEventArgs e);

    public delegate void AddStoneReportEventHandler(object sender,
        AddStoneReportEventArgs e);
    

    /// <summary>
    /// 
    /// </summary>
    public delegate void ShowOperationsEventHandler(object sender,
             ShowOperationsEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void ImagesEventHandler(object sender,
             ImagesEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void SelectionChangeEventHandler(object sender,
             SelectionChangeEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void PlanOPEventHandler(object sender,
                 PlanOPEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void NextActionEventHandler(object sender,
                NextActionEventArgs e);

    #endregion delegates

    /// <summary>
    /// 
    /// </summary>
    public partial class PatientSearchControl : UserControl {
        
        #region private members

        private ISPDBL patComp;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion private members

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientSearchControl"/> class.
        /// </summary>
        public PatientSearchControl() {
            InitializeComponent();

            listViewPatients.View = View.Details;
            listViewPatients.LabelEdit = false;
            listViewPatients.AllowColumnReorder = true;
            listViewPatients.FullRowSelect = true;

            // Create columns for the items and subitems.
            listViewPatients.Columns.Add("PID", 35);
            listViewPatients.Columns.Add("Last name", 130);
            listViewPatients.Columns.Add("First name", 130);
            listViewPatients.Columns.Add("Age", 35);
            listViewPatients.Columns.Add("Sex", 35);
            listViewPatients.Columns.Add("Address", 100);
            listViewPatients.Columns.Add("Weight", 48);
            listViewPatients.Columns.Add("Phone", 120);
            listViewPatients.Columns.Add("Visit Diagnosis", 185);
            listViewPatients.Columns.Add("Visit Procedure", 140);

            foreach (String action in Enum.GetNames(new ActionKind().GetType())) {
                this.comboBoxActionKind.Items.Add(action);
            }

            this.comboBoxActionKind.Text = ActionKind.operation.ToString();

            this.comboBoxActionHalfYear.Items.Add("1");
            this.comboBoxActionHalfYear.Items.Add("2");
            this.comboBoxActionHalfYear.Text = (DateTime.Now.Month <= 6) ? "2" : "1";

            for (int i = 0; i < 10; i++) {
                this.comboBoxActionYear.Items.Add(i + DateTime.Now.Year - 1);
            }

            this.comboBoxActionYear.Text = (DateTime.Now.Month <= 6) ? DateTime.Now.Year.ToString() : (DateTime.Now.Year + 1).ToString();

            foreach (String asmara in Enum.GetNames(new ResidentOfAsmara().GetType())) {
                this.comboBoxAsmara.Items.Add(asmara);
            }
            
            foreach (String linz in Enum.GetNames(new Linz().GetType())) {
                this.comboBoxLinz.Items.Add(linz);
            }
            
            foreach (String finished in Enum.GetNames(new Finished().GetType())) {
                this.comboBoxFinished.Items.Add(finished);
            }
            
            this.comboBoxOPHalfYears.Items.Add("1");
            this.comboBoxOPHalfYears.Items.Add("2");

            for (int i = 0; i < 10; i++ ) {
                this.comboBoxOPYear.Items.Add(DateTime.Now.Year - i);
            }

            this.labelSizeSearchResult.Text = String.Empty;
        }

        #endregion constructor

        #region Properties

        /// <summary>
        /// Gets or sets the name of the combo box.
        /// </summary>
        /// <value>The name of the text box.</value>
        public System.Windows.Forms.TextBox TextBoxFindName {
            set {
                textBoxFindAllNameAndId = value;
            }
            get {
                return textBoxFindAllNameAndId;
            }
        }

        /// <summary>
        /// Gets or sets the list view patients.
        /// </summary>
        /// <value>The list view patients.</value>
        public System.Windows.Forms.ListView ListViewPatients {
            set {
                listViewPatients = value;
            }
            get {
                return listViewPatients;
            }
        }

        #endregion Properties

        #region public Methods

        /// <summary>
        /// Inserts the patients.
        /// </summary>
        /// <param name="patients">The patients.</param>
        /// <param name="clear">if set to <c>true</c> [clear].</param>
        public void InsertPatients(IList<PatientData> patients, bool clear) {
            if (clear) {
                Clear(true);
            }
            listViewPatients.Items.Clear();
            //TODO: Addrange
            foreach (PatientData pd in patients) {
                ListViewItem item = new ListViewItem(pd.Id.ToString());
                item.SubItems.Add(pd.SurName);
                item.SubItems.Add(pd.FirstName);
                item.SubItems.Add(CommonUtilities.StaticUtilities.getAgeFromBirthDate(pd.DateOfBirth));
                item.SubItems.Add(pd.Sex.ToString());
                item.SubItems.Add(pd.Address);
                item.SubItems.Add(pd.Weight.ToString());
                item.SubItems.Add(pd.Phone);
                VisitData visit = this.patComp.GetLastVisitByPatientID(pd.Id);
                if (visit != null) {
                    item.SubItems.Add(visit.ExtraDiagnosis);
                    item.SubItems.Add(visit.Procedure);
                }

                listViewPatients.Items.Add(item);
            }
            if (listViewPatients.Items.Count > 0) {
                listViewPatients.SelectedIndices.Add(0);
            }
            this.labelSizeSearchResult.Text = "Found: " + patients.Count;
        }

        /// <summary>
        /// Clears the specified all.
        /// </summary>
        /// <param name="all">if set to <c>true</c> [all].</param>
        public void Clear(bool all) {
            textBoxProcedureFind.Text = string.Empty;
            textBoxDiagnoseFind.Text = string.Empty;
            //textBoxFindPatientNr.Text = string.Empty;
            textBoxFindAllNameAndId.Text = string.Empty;
            textBoxNumberOfPatients.Text = this.patComp.NumberOfPatients().ToString();
            textBoxNumberOfOperations.Text = this.patComp.NumberOfOperations().ToString();
            textBoxNumberOfVisits.Text = this.patComp.NumberOfVisits().ToString();
            this.textBoxTherapyFind.Text = string.Empty;
            this.textBoxFiendPhoneNr.Text = string.Empty;
            listViewPatients.Items.Clear();

            this.comboBoxActionHalfYear.Text = (DateTime.Now.Month <= 6) ? "2" : "1";
            this.comboBoxActionYear.Text = (DateTime.Now.Month <= 6) ? DateTime.Now.Year.ToString() : (DateTime.Now.Year + 1).ToString();
            this.comboBoxActionKind.Text = ActionKind.operation.ToString();
            this.labelSizeSearchResult.Text = string.Empty;
            this.comboBoxLinz.Text = string.Empty;
            this.comboBoxAsmara.Text = string.Empty;
            this.comboBoxFinished.Text = string.Empty;
            this.comboBoxOPYear.Text = string.Empty;
            this.comboBoxOPHalfYears.Text = string.Empty;
        }

        //private delegate void fillComboBoxesDelegate();

        /// <summary>
        /// Inits the specified currend patient.
        /// </summary>
        /// <param name="currendPatient">The currend patient.</param>
        /// <param name="patComp">The pat comp.</param>
        public void Init(PatientData currendPatient, ISPDBL patComp) {
            //DateTime dt = DateTime.Now;
            //string zeit = "";
            this.patComp = patComp;
            //zeit = zeit + "\r\n" + (DateTime.Now - dt).ToString();
            if (currendPatient != null) {
                this.Clear(false);
                listViewPatients.Items.Add(createPatientListViewItem(currendPatient));
                if (listViewPatients.Items.Count > 0) {
                    listViewPatients.SelectedIndices.Add(0);
                }
                listViewPatients.Focus();
            } else {
                //zeit = zeit + "\r\n" + (DateTime.Now - dt).ToString();
                this.Clear(true);
            }
            //zeit = zeit + "\r\n" + (DateTime.Now - dt).ToString();
            //MessageBox.Show(zeit);

            comboBoxDiagnoseGroups.Items.Clear();
            foreach(DiagnoseGroupData dgd in patComp.FindAllDiagnoseGroups()) {
                comboBoxDiagnoseGroups.Items.Add(dgd);
            }
        }

        #endregion public Methods

        #region private methods

        private bool isPattersLargeEnoughtToSearch(string pattern, int numberOfNotWideSpaceChar) {
            if (String.IsNullOrEmpty(pattern)) {
                return false;
            }

            string cuttedPattern = pattern;
            cuttedPattern = cuttedPattern.Replace(" ", "");
            cuttedPattern = cuttedPattern.Replace("\t", "");
            cuttedPattern = cuttedPattern.Replace("\r", "");
            cuttedPattern = cuttedPattern.Replace("\n", "");
            bool isNumber = false;
            try {
                Int32.Parse(cuttedPattern);
                isNumber = true;
            } catch (Exception) { }
            return isNumber || cuttedPattern.Length >= numberOfNotWideSpaceChar;
        }

        private string preparePattern(string pattern) {
            string preparedPatern = pattern.Trim();
            preparedPatern = preparedPatern.Replace("\t", " ");
            preparedPatern = preparedPatern.Replace("\r", " ");
            preparedPatern = preparedPatern.Replace("\n", " ");
            int patternlength;
            do {
                patternlength = preparedPatern.Length;
                preparedPatern = preparedPatern.Replace("  ", " ");
            } while (patternlength != preparedPatern.Length);
            return preparedPatern;
        }

        private ListViewItem createPatientListViewItem(PatientData pd) {
            ListViewItem item = new ListViewItem(pd.Id.ToString());
            item.SubItems.Add(pd.SurName);
            item.SubItems.Add(pd.FirstName);
            item.SubItems.Add(CommonUtilities.StaticUtilities.getAgeFromBirthDate(pd.DateOfBirth));
            item.SubItems.Add(pd.Sex.ToString());
            item.SubItems.Add(pd.Address);
            item.SubItems.Add(pd.Weight.ToString());
            item.SubItems.Add(pd.Phone);
            return item;
        }

        private bool PatientSelected() {
            return (listViewPatients.SelectedItems.Count > 0);
        }

        private PatientData getSelectedPatient() {
            long pId = 0;
            
            foreach (ListViewItem lvi in listViewPatients.SelectedItems) {
                pId = Int64.Parse(lvi.Text);
            }

            return this.patComp.FindPatientById(pId);
        }

        #endregion private methods

        #region events

        /// <summary>
        /// Occurs when [add visit].
        /// </summary>
        public event AddVisitEventHandler AddVisit;
        /// <summary>
        /// Occurs when [show visits].
        /// </summary>
        public event ShowVisitsEventHandler ShowVisits;
        /// <summary>
        /// Occurs when [change patient data].
        /// </summary>
        public event ChangePatientDataEventHandler ChangePatientData;
        /// <summary>
        /// Occurs when [show patient data].
        /// </summary>
        public event ShowPatientDataEventHandler ShowPatientData;
        /// <summary>
        /// Occurs when [add operation].
        /// </summary>
        public event AddOperationEventHandler AddOperation;
        /// <summary>
        /// Occurs when [add further treatment].
        /// </summary>
        public event AddFurtherTreatmentEventHandler AddFurtherTreatment;

        public event AddStoneReportEventHandler AddStoneReport;

        /// <summary>
        /// Occurs when [show operations].
        /// </summary>
        public event ShowOperationsEventHandler ShowOperations;
        /// <summary>
        /// Occurs when [add images].
        /// </summary>
        public event ImagesEventHandler AddImages;
        /// <summary>
        /// Occurs when [selection change].
        /// </summary>
        public event SelectionChangeEventHandler SelectionChange;
        /// <summary>
        /// Occurs when [plan OP].
        /// </summary>
        public event PlanOPEventHandler PlanOP;
        /// <summary>
        /// Occurs when [next action].
        /// </summary>
        public event NextActionEventHandler NextAction;

        #endregion events

        #region Gui-handler

        private void textBoxSearchAllNameAndId_TextChanged(object sender, EventArgs e) {
            this.listViewPatients.Items.Clear();
            string pattern = preparePattern(textBoxFindAllNameAndId.Text);
            if (!isPattersLargeEnoughtToSearch(pattern, 2)) {
                InsertPatients(new List<PatientData>(), false);
                return;
            }
            this.InsertPatients(this.patComp.FindPatientByIdAndAllName(pattern), false);
        }

        //private void textBoxFindPatientNr_TextChanged(object sender, EventArgs e) {
        //    this.listViewPatients.Items.Clear();
        //    string pattern = textBoxFindPatientNr.Text.Trim();
        //    long patNr;
        //    try {
        //        patNr = Int64.Parse(pattern);
        //    } catch (Exception) {
        //        InsertPatients(new List<PatientData>(), false);
        //        return;
        //    }
        //    PatientData patient = this.patComp.FindPatientById(patNr);
        //    if (patient == null) {
        //        InsertPatients(new List<PatientData>(), false);
        //        return;
        //    }
        //    IList<PatientData> patients = new List<PatientData>();
        //    patients.Add(patient);
        //    this.InsertPatients(patients, false);
        //}

        private void textBoxFiendPhoneNr_TextChanged(object sender, EventArgs e) {
            this.listViewPatients.Items.Clear();
            string pattern = preparePattern(textBoxFiendPhoneNr.Text);
            if (!isPattersLargeEnoughtToSearch(pattern, 2)) {
                InsertPatients(new List<PatientData>(), false);
                return;
            }
            this.InsertPatients(this.patComp.FindPatientByPhone(pattern), false);
        }

        private void textBoxDiagnoseFind_TextChanged(object sender, EventArgs e) {
            this.listViewPatients.Items.Clear();
            string pattern = preparePattern(textBoxDiagnoseFind.Text);
            if (!isPattersLargeEnoughtToSearch(pattern, 2)) {
                InsertPatients(new List<PatientData>(), false);
                return;
            }
            this.InsertPatients(this.patComp.FindDiagnose(pattern), false);
        }

        private void textBoxProcedureFind_TextChanged(object sender, EventArgs e) {
            this.listViewPatients.Items.Clear();
            string pattern = preparePattern(textBoxProcedureFind.Text);
            if (!isPattersLargeEnoughtToSearch(pattern, 2)) {
                InsertPatients(new List<PatientData>(), false);
                return;
            }
            this.InsertPatients(this.patComp.FindProcedure(pattern), false);
        }

        private void textBoxTherapyFind_TextChanged(object sender, EventArgs e) {
            this.listViewPatients.Items.Clear();
            string pattern = preparePattern(textBoxTherapyFind.Text);
            if (!isPattersLargeEnoughtToSearch(pattern, 2)) {
                InsertPatients(new List<PatientData>(), false);
                return;
            }
            this.InsertPatients(this.patComp.FindTherapy(pattern), false);
        }

        private void buttonAddVisit_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            AddVisit(this, new AddVisitEventArgs(getSelectedPatient()));
        }

        private void buttonShowVisits_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            ShowVisits(this, new ShowVisitsEventArgs(getSelectedPatient()));
        }

        private void buttonAddOperation_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            AddOperation(this, new AddOperationEventArgs(getSelectedPatient()));
        }

        private void buttonShowOperations_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            ShowOperations(this, new ShowOperationsEventArgs(getSelectedPatient()));
        }

        private void buttonPlanOP_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            this.PlanOP(this, new PlanOPEventArgs(getSelectedPatient()));
        }

        private void buttonPatientShowData_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            ShowPatientData(this, new ShowPatientDataEventArgs(getSelectedPatient()));
        }

        private void buttonPatientDataChange_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            ChangePatientData(this, new ChangePatientDataEventArgs(getSelectedPatient()));
        }

        private void buttonFurtherTreatment_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            AddFurtherTreatment(this, new AddFurtherTreatmentEventArgs(getSelectedPatient()));
        }

        private void buttonStoneReport_Click(object sender, EventArgs e)
        {
            if (!PatientSelected())
            {
                MessageBox.Show("Please select a patient");
                return;
            }
            AddStoneReport(this, new AddStoneReportEventArgs(getSelectedPatient()));
        }

        private void buttonImages_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            AddImages(this, new ImagesEventArgs(getSelectedPatient()));
        }

        private void buttonNextAction_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            this.NextAction(this, new NextActionEventArgs(getSelectedPatient()));
        }

        private void buttonPrintNextAppointment_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            NextAppointmentForm nextAppointmentForm = new NextAppointmentForm(this.patComp, getSelectedPatient());
            nextAppointmentForm.ShowDialog();
        }

        private void buttonIdCardPrint_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }

            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> patients = new List<PatientData>();
            patients.Add(getSelectedPatient());
            print.PrintIdCard(patients); 
        }

        private void buttonPrint_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }
            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> patients = new List<PatientData>();
            patients.Add(getSelectedPatient());

            PrintSelectionForm psf = new PrintSelectionForm();
            psf.ShowDialog();

            if (!psf.Ok) {
                return;
            }

            SPD.Print.SPDPrint.PatientPrintDetails patientPrintDetails = 0;

            if (psf.Visits)
                patientPrintDetails = patientPrintDetails | SPDPrint.PatientPrintDetails.Visits;
            if (psf.FurtherTreatment)
                patientPrintDetails = patientPrintDetails | SPDPrint.PatientPrintDetails.FinalReport;
            if (psf.PhotoLinks)
                patientPrintDetails = patientPrintDetails | SPDPrint.PatientPrintDetails.Fotolinks;
            if (psf.Operations)
                patientPrintDetails = patientPrintDetails | SPDPrint.PatientPrintDetails.Operations;

            print.PrintPatients(patients, patientPrintDetails);
        }

        private void buttonAddToWaitList_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }

            PatientData currentPatient = getSelectedPatient();
            currentPatient.WaitListStartDate = DateTime.Now;
            this.patComp.UpdatePatient(currentPatient);
        }

        private void buttonRemoveFromWaitList_Click(object sender, EventArgs e) {
            if (!PatientSelected()) {
                MessageBox.Show("Please select a patient");
                return;
            }

            PatientData currentPatient = getSelectedPatient();
            currentPatient.WaitListStartDate = null;
            this.patComp.UpdatePatient(currentPatient);
        }

        private void listViewPatients_ColumnClick(object sender, ColumnClickEventArgs e) {
            listViewPatients.ListViewItemSorter = new SPD.CommonUtilities.ListViewItemComparer(e.Column);
        }

        private void listViewPatients_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectionChange(this, new SelectionChangeEventArgs());
        }

        private void buttonSearchNextAction_Click(object sender, EventArgs e) {
            doNextActionSearch();
        }

        private void nextAction_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                doNextActionSearch();
            }
        }

        private void comboBoxLinz_SelectedIndexChanged(object sender, EventArgs e) {
            Linz linz;
            try {
                linz = (Linz)Enum.Parse(new Linz().GetType(), this.comboBoxLinz.Text);
            } catch (Exception) {
                MessageBox.Show("Linz is not a valid value!");
                return;
            }
            this.InsertPatients(this.patComp.FindPatientByLinz(linz), true);
        }

        private void buttonSearchAmulant_Click(object sender, EventArgs e) {
            this.InsertPatients(this.patComp.FindPatientByAmbulant(Ambulant.ambulant), true);
        }

        private void buttonWaitList_Click(object sender, EventArgs e) {
            this.InsertPatients(this.patComp.FindPatientByWaitList(), true);
        }

        private void comboBoxAsmara_SelectedIndexChanged(object sender, EventArgs e) {
            ResidentOfAsmara asmara;
            try {
                asmara = (ResidentOfAsmara)Enum.Parse(new ResidentOfAsmara().GetType(), this.comboBoxAsmara.Text);
            } catch (Exception) {
                MessageBox.Show("Asmara is not a valid value!");
                return;
            }
            this.InsertPatients(this.patComp.FindPatientByAsmara(asmara), true);
        }

        private void comboBoxFinished_SelectedIndexChanged(object sender, EventArgs e) {
            Finished finished;
            try {
                finished = (Finished)Enum.Parse(new Finished().GetType(), this.comboBoxFinished.Text);
            } catch (Exception) {
                MessageBox.Show("Finished is not a valid value!");
                return;
            }
            this.InsertPatients(this.patComp.FindPatientByFinished(finished), true);
        }

        private void comboBoxDiagnoseGroups_SelectedIndexChanged(object sender, EventArgs e) {
            DiagnoseGroupData dgd;
            try {
                dgd = (DiagnoseGroupData)comboBoxDiagnoseGroups.SelectedItem;
            } catch (Exception) {
                MessageBox.Show("Diagnose Group Search not a valid Item.");
                return;
            }
            this.InsertPatients(this.patComp.FindPatientByDiagnoseGroupId(dgd.DiagnoseGroupDataID), true);
        }

        private void buttonOPSearch_Click(object sender, EventArgs e) {
            int opHalfYear;
            int opYear;
            
            try {
                opHalfYear = Int32.Parse(comboBoxOPHalfYears.Text);
            } catch(Exception) {
                MessageBox.Show("OP Halfyear has to be 1 oder 2.");
                return;
            }
            
            try {
                opYear = Int32.Parse(comboBoxOPYear.Text);
            } catch(Exception) {
                MessageBox.Show("OP Year has to be a number.");
                return;
            }

            if (opHalfYear != 1 && opHalfYear != 2) {
                MessageBox.Show("OP Halfyear has to be 1 oder 2.");
                return;
            }

            if (opYear < 2000 || opYear > (DateTime.Now.Year)) {
                MessageBox.Show("OP Year has to be between 2000 and " + DateTime.Now.Year + ".");
                return;
            }

            this.InsertPatients(this.patComp.FindPatientByOperationDate(opHalfYear, opYear), true);
        }

        #endregion Gui-handler

        #region doSearch

        private void doNextActionSearch() {
            long year;
            long halfYear;
            ActionKind actionKind;

            try {
                year = long.Parse(comboBoxActionYear.Text);
                if (year < 1980) {
                    MessageBox.Show("Please fill in a valid NextAction Year!");
                    return;
                }
            } catch (Exception) {
                MessageBox.Show("Please fill in a valid NextAction Year!");
                return;
            }

            try {
                halfYear = long.Parse(comboBoxActionHalfYear.Text);
                if (halfYear > 2 || halfYear < 1) {
                    MessageBox.Show("Please fill in a valid NextAction Halfyear!");
                    return;
                }
            } catch (Exception) {
                MessageBox.Show("Please fill in a valid NextAction Halfyear!");
                return;
            }

            try {
                actionKind = (ActionKind)Enum.Parse(new ActionKind().GetType(), this.comboBoxActionKind.Text);
            } catch (Exception) {
                MessageBox.Show("Next Action Kind is not valid!");
                return;
            }

            this.InsertPatients(this.patComp.FindPatientsWithNextAction(year, halfYear, actionKind), false);
        }

        #endregion doSearch       
        
    }

    #region event arguments

    /// <summary>
    /// 
    /// </summary>
    public class AddVisitEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="AddVisitEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public AddVisitEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ImagesEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImagesEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public ImagesEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ShowOperationsEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowOperationsEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public ShowOperationsEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AddFurtherTreatmentEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="AddFurtherTreatmentEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public AddFurtherTreatmentEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    public class AddStoneReportEventArgs : EventArgs
    {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="AddStoneReportEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public AddStoneReportEventArgs(PatientData patient)
        {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient
        {
            get
            {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AddOperationEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="AddOperationEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public AddOperationEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ShowVisitsEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowVisitsEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public ShowVisitsEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ChangePatientDataEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePatientDataEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public ChangePatientDataEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ShowPatientDataEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowPatientDataEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public ShowPatientDataEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SelectionChangeEventArgs : EventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionChangeEventArgs"/> class.
        /// </summary>
        public SelectionChangeEventArgs() {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PlanOPEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanOPEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public PlanOPEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NextActionEventArgs : EventArgs {
        private PatientData patient;
        /// <summary>
        /// Initializes a new instance of the <see cref="NextActionEventArgs"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public NextActionEventArgs(PatientData patient) {
            this.patient = patient;
        }
        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get {
                return patient;
            }
        }
    }

    #endregion event arguments

}
