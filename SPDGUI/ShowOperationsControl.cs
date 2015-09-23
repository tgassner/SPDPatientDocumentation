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

namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public delegate void ChangeOPEventHandler(object sender,
             ChangeOPEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class ShowOperationsControl : UserControl {
        private PatientData currentPatient;
        private IList<OperationData> operationsList;
        private OPControl opControl;
        private ISPDBL patComp;

        /// <summary>
        /// Gets or sets the list view operations.
        /// </summary>
        /// <value>The list view operations.</value>
        public System.Windows.Forms.ListView ListViewOperations {
            get { return listViewOperations; }
            set { listViewOperations = value; }
        }

        /// <summary>
        /// Occurs when [change OP].
        /// </summary>
        public event ChangeOPEventHandler ChangeOP;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowOperationsControl"/> class.
        /// </summary>
        public ShowOperationsControl() {
            InitializeComponent();
            listViewOperations.View = View.Details;
            listViewOperations.LabelEdit = false;
            listViewOperations.AllowColumnReorder = true;
            listViewOperations.FullRowSelect = true;

            // Create columns for the items and subitems.
            listViewOperations.Columns.Add("OID", 50);
            listViewOperations.Columns.Add("Date", 100);
            listViewOperations.Columns.Add("Team", 110);
            listViewOperations.Columns.Add("Process", 155);
            listViewOperations.Columns.Add("Diagnosis", 155);
            listViewOperations.Columns.Add("Performed", 155);
            listViewOperations.Columns.Add("Add. Info.", 100);
            listViewOperations.Columns.Add("Medication", 130);
            opControl = new OPControl(this.patComp);
            opControl.ButtonClearData.Visible = false;
            opControl.ButtonSaveOperation.Visible = false;
            opControl.ButtonToday.Visible = false;
            opControl.ButtonSaveAndPrint.Visible = false;

            opControl.TextBoxOPTeam.ReadOnly = true;
            opControl.TextBoxOPDate.ReadOnly = true;
            opControl.TextBoxOPDiagnoses.ReadOnly = true;
            opControl.TextBoxOPProcess.ReadOnly = true;
            opControl.TextBoxPerformedOP.ReadOnly = true;
            opControl.TextBoxAdditionalInformation.ReadOnly = true;
            opControl.TextBoxMedication.ReadOnly = true;
            opControl.TextBoxIntdiagnoses.ReadOnly = true;
            opControl.ComboBoxPPPS.Enabled = false;
            opControl.ComboBoxResult.Enabled = false;
            opControl.ComboBoxKathDays.Enabled = false;
            opControl.ComboBoxOrgan.Enabled = false;
            opControl.TextBoxOpResult.Enabled = false;
            opControl.Location = new Point(10, 220);
            this.Controls.Add(opControl);

            this.listBoxDays.Items.AddRange(new object[] {
            "12",
            "24",
            "36"});

            this.listBoxCopys.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});

            this.listBoxDays.SelectedIndex = 0;
            this.listBoxCopys.SelectedIndex = 1;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        internal void Clear() {
            this.listViewOperations.Items.Clear();
            this.labelPatientData.Text = "";
            opControl.Clear();
        }

        private void fillOperationList() {
            if (this.operationsList != null) {
                foreach (OperationData op in operationsList) {
                    ListViewItem item1 = new ListViewItem(op.OperationId.ToString(), 0);
                    item1.SubItems.Add(op.Date.ToShortDateString());
                    item1.SubItems.Add(op.Team);
                    item1.SubItems.Add(op.Process);
                    item1.SubItems.Add(op.Diagnoses);
                    item1.SubItems.Add(op.Performed);
                    item1.SubItems.Add(op.Additionalinformation.Replace("\r\n"," "));
                    item1.SubItems.Add(op.Medication.Replace("\r\n", " "));
                    listViewOperations.Items.Add(item1);
                }
                if (listViewOperations.Items.Count > 0) {
                    listViewOperations.SelectedIndices.Add(listViewOperations.Items.Count - 1);
                }
            }
        }

        /// <summary>
        /// Inits the specified current patient.
        /// </summary>
        /// <param name="currentPatient">The current patient.</param>
        /// <param name="patComp">The pat comp.</param>
        internal void Init(PatientData currentPatient, ISPDBL patComp) {
            this.currentPatient = currentPatient;
            this.operationsList = patComp.GetOperationsByPatientID(currentPatient.Id);
            this.patComp = patComp;
            Clear();
            fillOperationList();
            if (currentPatient != null) {
                this.labelPatientData.Text = currentPatient.Id.ToString() + " " + currentPatient.FirstName + " " + currentPatient.SurName;
            }
        }

        private OperationData getSelectedOperation() {
            long opID = 0;
            try{
                foreach (ListViewItem lvi in listViewOperations.SelectedItems) {
                    opID = Int64.Parse(lvi.Text);
                }
            }catch(Exception){
                return null;
            }

            foreach (OperationData op in operationsList) {
                if (op.OperationId == opID) {
                    return op;
                }
            }
            return null;
        }

        private void listViewOperations_SelectedIndexChanged(object sender, EventArgs e) {
            showDetailsBelow();
        }

        private void showDetailsBelow() {
            OperationData opData = getSelectedOperation();
            if (opData == null) {
                return;
            }
            opControl.Init(opData, currentPatient);
        }

        private void buttonChangeOP_Click(object sender, EventArgs e) {
            if (getSelectedOperation() == null) {
                MessageBox.Show("No operation selected!");
                return;
            }
            this.ChangeOP(this, new ChangeOPEventArgs(this.getSelectedOperation(), this.currentPatient));
        }

        private void buttonprintA3TemperatureCurve_Click(object sender, EventArgs e) {
            int weeks = Int32.Parse(listBoxDays.SelectedItem.ToString()) / 12;
            int copies = Int32.Parse(listBoxCopys.SelectedItem.ToString());
            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> patients = new List<PatientData>();
            patients.Add(currentPatient);
            print.PrintA3TemperaturCurve(patients, weeks, copies, SPDPrint.PrintFormat.A3, null);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ChangeOPEventArgs : EventArgs {
        private OperationData operation;
        private PatientData patient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeOPEventArgs"/> class.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="patient">The patient.</param>
        public ChangeOPEventArgs(OperationData operation, PatientData patient) {
            this.operation = operation;
            this.patient = patient;
        }

        /// <summary>
        /// Gets the operation.
        /// </summary>
        /// <value>The operation.</value>
        public OperationData Operation {
            get { return operation; }
        }

        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public PatientData Patient {
            get { return patient; }
        }
    }
}
