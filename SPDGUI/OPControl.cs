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

namespace SPD.GUI{

    /// <summary>
    /// 
    /// </summary>
    public delegate void NewOperationStoreEventHandler(object sender,
             NewOperationStoreEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class OPControl : UserControl{

        /// <summary>
        /// Gets or sets the text box OP team.
        /// </summary>
        /// <value>The text box OP team.</value>
        public TextBox TextBoxOPTeam {
            set { textBoxOPTeam = value; }
            get { return textBoxOPTeam; }
        }

        /// <summary>
        /// Gets or sets the text box OP date.
        /// </summary>
        /// <value>The text box OP date.</value>
        public TextBox TextBoxOPDate {
            set { textBoxOPDate = value; }
            get { return textBoxOPDate; }
        }

        /// <summary>
        /// Gets or sets the text box OP diagnoses.
        /// </summary>
        /// <value>The text box OP diagnoses.</value>
        public TextBox TextBoxOPDiagnoses {
            set { textBoxOPDiagnoses = value; }
            get { return textBoxOPDiagnoses; }
        }

        /// <summary>
        /// Gets or sets the text box OP process.
        /// </summary>
        /// <value>The text box OP process.</value>
        public TextBox TextBoxOPProcess {
            set { textBoxOPProcess = value; }
            get { return textBoxOPProcess; }
        }

        /// <summary>
        /// Gets or sets the text box op result.
        /// </summary>
        /// <value>The text box op result.</value>
        public TextBox TextBoxOpResult {
            set { textBoxOpResult = value; }
            get { return textBoxOpResult; }
        }

        /// <summary>
        /// Gets or sets the text box performed OP.
        /// </summary>
        /// <value>The text box performed OP.</value>
        public TextBox TextBoxPerformedOP {
            set { textBoxPerformedOP = value; }
            get { return textBoxPerformedOP; }
        }

        /// <summary>
        /// Gets or sets the text box additional information.
        /// </summary>
        /// <value>The text box additional information.</value>
        public TextBox TextBoxAdditionalInformation {
            set { textBoxAdditionalInformation = value; }
            get { return textBoxAdditionalInformation; }
        }

        /// <summary>
        /// Gets or sets the text box medication.
        /// </summary>
        /// <value>The text box medication.</value>
        public TextBox TextBoxMedication {
            set { textBoxMedication = value; }
            get { return textBoxMedication; }
        }

        /// <summary>
        /// Gets or sets the intdiagnoses.
        /// </summary>
        /// <value>The text box medication.</value>
        public TextBox TextBoxIntdiagnoses {
            set {
                textBoxIntdiagnoses = value;
            }
            get {
                return textBoxIntdiagnoses;
            }
        }

        /// <summary>
        /// Gets or sets the PPPS.
        /// </summary>
        /// <value>The combo box PPPS.</value>
        public ComboBox ComboBoxPPPS {
            set {
                comboBoxPPPS = value;
            }
            get {
                return comboBoxPPPS;
            }
        }

        /// <summary>
        /// Gets or sets the Result.
        /// </summary>
        /// <value>The combo box Result.</value>
        public ComboBox ComboBoxResult {
            set {
                comboBoxResult = value;
            }
            get {
                return comboBoxResult;
            }
        }

        /// <summary>
        /// Gets or sets the kathDays.
        /// </summary>
        /// <value>The combo box kath Days.</value>
        public ComboBox ComboBoxKathDays {
            set {
                comboBoxKathDays = value;
            }
            get {
                return comboBoxKathDays;
            }
        }

        /// <summary>
        /// Gets or sets the combo box organ.
        /// </summary>
        /// <value>The combo box organ.</value>
        public ComboBox ComboBoxOrgan {
            set {
                comboBoxOrgan = value;
            }
            get {
                return comboBoxOrgan;
            }
        }

        private PatientData currentPatient;
        private OperationData operation;
        private ISPDBL patComp;

        /// <summary>
        /// Gets or sets the current patient.
        /// </summary>
        /// <value>The current patient.</value>
        public PatientData CurrentPatient {
            get { return this.currentPatient; }
            set { this.currentPatient = value; }
        }

        /// <summary>
        /// Occurs when [store].
        /// </summary>
        public event NewOperationStoreEventHandler Store;

        /// <summary>
        /// Initializes a new instance of the <see cref="OPControl"/> class.
        /// </summary>
        public OPControl() {
            constructor(null);
        }

        private void constructor(ISPDBL patComp) {
            this.patComp = patComp;
            InitializeComponent();

            foreach(String s in Enum.GetNames(new PPPS().GetType())) {
                this.comboBoxPPPS.Items.Add(s);
            }

            foreach(String s in Enum.GetNames(new Organ().GetType())) {
                this.comboBoxOrgan.Items.Add(s);
            }

            foreach (String s in Enum.GetNames(new Result().GetType()))
            {
                this.comboBoxResult.Items.Add(s);
            }

            for (int i = 0; i < 20; i++) {
                comboBoxKathDays.Items.Add(i);
            }

            this.listBoxDays.Items.AddRange(new object[] {"12", "24"});

            this.listBoxCopys.Items.AddRange(new object[] {"1", "2"});

            this.listBoxDays.SelectedIndex = 0;
            this.listBoxCopys.SelectedIndex = 1;

            Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OPControl"/> class.
        /// </summary>
        public OPControl(ISPDBL patComp) {
            constructor(patComp);
        }

        /// <summary>
        /// Gets or sets the button clear data.
        /// </summary>
        /// <value>The button clear data.</value>
        public Button ButtonClearData {
            get { return this.buttonClearData; }
            set { this.buttonClearData = value; }
        }

        /// <summary>
        /// Gets or sets the button save operation.
        /// </summary>
        /// <value>The button save operation.</value>
        public Button ButtonSaveOperation {
            get { return this.buttonSaveOperation; }
            set { this.buttonSaveOperation = value; }
        }

        /// <summary>
        /// Gets or sets the button save and print.
        /// </summary>
        /// <value>The button save and print.</value>
        public Button ButtonSaveAndPrint {
            get { return this.buttonSaveAndPrint; }
            set { this.buttonSaveAndPrint = value; }
        }

        /// <summary>
        /// Gets or sets the button save operation.
        /// </summary>
        /// <value>The button save operation.</value>
        public Label LabelPatient {
            get {
                return this.labelPatient;
            }
            set {
                this.labelPatient = value;
            }
        }

        /// <summary>
        /// Gets or sets the button today.
        /// </summary>
        /// <value>The button today.</value>
        public Button ButtonToday {
            get { return this.buttonToday; }
            set { this.buttonToday = value; }
        }

        /// <summary>
        /// Inits the specified opdata.
        /// </summary>
        /// <param name="opdata">The opdata.</param>
        /// <param name="currentPatient">The current patient</param>
        public void Init(OperationData opdata, PatientData currentPatient) {
            this.operation = opdata;
            this.currentPatient = currentPatient;
            Clear();
            textBoxOPDate.Text = DateTime.Now.ToShortDateString();
            if (currentPatient != null){
                this.labelPatientData.Text = currentPatient.Id.ToString() + " " + currentPatient.FirstName + " " + currentPatient.SurName;   
            }
            if (opdata != null) {
                textBoxOPDate.Text = operation.Date.ToShortDateString();
                textBoxOPDiagnoses.Text = operation.Diagnoses;
                textBoxOPProcess.Text = operation.Process;
                textBoxOPTeam.Text = operation.Team;
                textBoxPerformedOP.Text = operation.Performed;
                textBoxAdditionalInformation.Text = operation.Additionalinformation;
                textBoxMedication.Text = operation.Medication;
                textBoxIntdiagnoses.Text = operation.IntDiagnoses.ToString();
                comboBoxPPPS.Text = operation.Ppps.ToString();
                comboBoxResult.Text = operation.Result.ToString();
                comboBoxKathDays.Text = operation.KathDays.ToString();
                comboBoxOrgan.Text = operation.Organ.ToString();
                textBoxOpResult.Text = operation.OpResult;
            }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear() {
            this.textBoxOPDate.Text = string.Empty;
            this.textBoxOPDiagnoses.Text = string.Empty;
            this.textBoxOPProcess.Text = string.Empty;
            this.textBoxOPTeam.Text = string.Empty;
            this.textBoxPerformedOP.Text = string.Empty;
            this.textBoxAdditionalInformation.Text = string.Empty;
            this.textBoxMedication.Text = string.Empty;
            this.textBoxIntdiagnoses.Text = "0";
            this.labelPatientData.Text = string.Empty;
            this.comboBoxPPPS.Text = PPPS.notDefined.ToString();
            this.comboBoxResult.Text = Result.notDefined.ToString();
            this.comboBoxOrgan.Text = Organ.undefined.ToString();
            this.comboBoxKathDays.Text = "0";
            this.textBoxOpResult.Text = string.Empty;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        private NewOperationStoreEventArgs save() {
            NewOperationStoreEventArgs ret = new NewOperationStoreEventArgs();
            ret.StoredOk = false;
            ret.TakeFromDB = false;
            long intdiagnoses = 0;
            try {
                intdiagnoses = Int64.Parse(this.textBoxIntdiagnoses.Text);
            }catch(Exception){
                MessageBox.Show("Format of the Intdiagnoses is not correct");
                return ret;
            }


            if(!new List<String>(Enum.GetNames(new PPPS().GetType())).Contains(this.comboBoxPPPS.Text)) {
                MessageBox.Show("PP PS has an incorrect Value");
                return ret;
            }

            if(!new List<String>(Enum.GetNames(new Result().GetType())).Contains(this.comboBoxResult.Text)) {
                MessageBox.Show("Result has an incorrect Value");
                return ret;
            }

            if (!new List<String>(Enum.GetNames(new Organ().GetType())).Contains(this.comboBoxOrgan.Text)) {
                MessageBox.Show("Organ has an incorrect Value");
                return ret;
            }

            long operationID = 0;
            if (operation != null) {
                operationID = operation.OperationId;
            }

            DateTime date;
            try {
                date = DateTime.Parse(textBoxOPDate.Text);
            } catch (Exception) {
                MessageBox.Show("Format of the Date is not correct!");
                return ret;
            }

            long kathDays = 0;

            try {
                kathDays = Convert.ToInt64(comboBoxKathDays.Text.Trim());
            } catch (Exception) {}

            NewOperationStoreEventArgs e2;

            long currentPatientId;
 
            if (currentPatient == null) {
                currentPatientId = -1;
            } else {
                currentPatientId = currentPatient.Id;
            }

            PPPS ppps = (PPPS)Enum.Parse(new PPPS().GetType(), this.comboBoxPPPS.Text);
            Result result = (Result)Enum.Parse(new Result().GetType(), this.comboBoxResult.Text);
            Organ organ = (Organ)Enum.Parse(new Organ().GetType(), this.comboBoxOrgan.Text);

            e2 = new NewOperationStoreEventArgs(
            new OperationData(operationID, date, textBoxOPTeam.Text, textBoxOPProcess.Text,
                    textBoxOPDiagnoses.Text, textBoxPerformedOP.Text, currentPatientId,
                    textBoxAdditionalInformation.Text, textBoxMedication.Text,
                    intdiagnoses, ppps, result, kathDays, organ, textBoxOpResult.Text));
            e2.StoredOk = true;
            e2.TakeFromDB = false;
            Store(this, e2);
            
            return e2;
        }

        private void buttonSaveOperation_Click(object sender, EventArgs e){
            NewOperationStoreEventArgs saveVal = this.save();
            if (saveVal.StoredOk && currentPatient != null) { //the 2nd condition is only for SPD OP Writer
                Clear();
            }
        }

        private void buttonClearData_Click(object sender, EventArgs e){
            Clear();
        }

        private void saveAndPrintA3(int weeks, int copies) {
            NewOperationStoreEventArgs saveVal = this.save();
            if (saveVal.StoredOk) {
                SPDPrint print = new SPDPrint(this.patComp);
                IList<PatientData> patients = new List<PatientData>();
                patients.Add(currentPatient);
                if (saveVal.TakeFromDB)
                {
                    print.PrintA3TemperaturCurve(patients, weeks, copies, SPDPrint.PrintFormat.A3, null);
                }
                else
                {
                    print.PrintA3TemperaturCurve(patients, weeks, copies, SPDPrint.PrintFormat.A3, saveVal.Operation);
                }
            }
        }

        private void buttonToday_Click(object sender, EventArgs e) {
            textBoxOPDate.Text = DateTime.Now.ToShortDateString();
        }

        private void buttonSaveAndPrint_Click_1(object sender, EventArgs e)
        {
            int weeks = Int32.Parse(listBoxDays.SelectedItem.ToString()) / 12;
            int copys = Int32.Parse(listBoxCopys.SelectedItem.ToString());
            saveAndPrintA3(weeks, copys);
        }

        /// <summary>
        /// Hides for op writer.
        /// </summary>
        public void hideForOpWriter() {
            this.labelIntDiagnoses.Visible = false;
            this.labelPPPS.Visible = false;
            this.labelResult.Visible = false;
            this.labelOpResult.Visible = false;

            this.textBoxIntdiagnoses.Visible = false;
            this.comboBoxPPPS.Visible = false;
            this.comboBoxResult.Visible = false;
            this.textBoxOpResult.Visible = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NewOperationStoreEventArgs : EventArgs {
        private OperationData operation;
        private bool storedOk;
        private bool takeFromDB;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewOperationStoreEventArgs"/> class.
        /// </summary>
        public NewOperationStoreEventArgs() {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="NewOperationStoreEventArgs"/> class.
        /// </summary>
        /// <param name="operation">The operation.</param>
        public NewOperationStoreEventArgs(OperationData operation) {
            this.operation = operation;
        }
        /// <summary>
        /// Gets the operation.
        /// </summary>
        /// <value>The operation.</value>
        public OperationData Operation {
            get { return operation; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [stored ok].
        /// </summary>
        /// <value><c>true</c> if [stored ok]; otherwise, <c>false</c>.</value>
        public bool StoredOk {
            get { return storedOk; }
            set { storedOk = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [take from DB].
        /// </summary>
        /// <value><c>true</c> if [take from DB]; otherwise, <c>false</c>.</value>
        public bool TakeFromDB {
            get { return takeFromDB; }
            set { takeFromDB = value; }
        }
    }
}
