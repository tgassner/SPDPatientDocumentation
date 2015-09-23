using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using SPD.Print;

namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public delegate void NewVisitStoreEventHandler(object sender,
             NewVisitStoreEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class NewVisit : UserControl {

        /// <summary>
        /// Gets or sets the text box cause of visit.
        /// </summary>
        /// <value>The text box cause of visit.</value>
        public System.Windows.Forms.TextBox TextBoxCauseOfVisit {
            set { textBoxCauseOfVisit = value; }
            get { return textBoxCauseOfVisit;}
        }

        /// <summary>
        /// Gets or sets the text box Diagnoses.
        /// </summary>
        /// <value>The text box Diagnoses of visit.</value>
        public TextBox TextBoxDiagnosis {
            set { textBoxDiagnosis = value; }
            get { return textBoxDiagnosis; }
        }

        /// <summary>
        /// Occurs when [store].
        /// </summary>
        public event NewVisitStoreEventHandler Store;

        private ISPDBL patComp;
        private PatientData currentPatient = null;
        private VisitData visit;

        /// <summary>
        /// Gets or sets the current patient.
        /// </summary>
        /// <value>The current patient.</value>
        public PatientData CurrentPatient
        {
            get { return currentPatient; }
            set { currentPatient = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewVisit"/> class.
        /// </summary>
        public NewVisit(ISPDBL patComp) {
            this.patComp = patComp;
            InitializeComponent();
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear(){
            this.textBoxCauseOfVisit.Text = "";
            this.textBoxDiagnosis.Text = "";
            this.textBoxProcedure.Text = "";
            this.textBoxStatusLocalis.Text = "";
            this.textBoxTherapy.Text = "";
            this.textBoxAnesthesiology.Text = "";
            StringBuilder sb = new StringBuilder();
            foreach(String us in SPD.GUI.Properties.Settings.Default.UltraSound) {
                if (!string.IsNullOrEmpty(us)) {
                    sb.Append(us).Append(Environment.NewLine);
                }
            }
            this.textBoxUltrasound.Text = sb.ToString();
            this.textBoxBlooddiagnostic.Text = "";
            this.textBoxTodo.Text = "";
            this.textBoxRadiodiagnostics.Text = "";
        }
        
        private void buttonClearData_Click(object sender, EventArgs e) {
            Clear();
        }

        private void buttonStoreVisit_Click(object sender, EventArgs e) {
            doStoreVisit(NextScreen.Undefined);
        }

        private void buttonStoreVisitAndAddNextAction_Click(object sender, EventArgs e) {
            doStoreVisit(NextScreen.NextAction);
        }


        private void buttonStoreVisitPlanOPGoToNextAction_Click(object sender, EventArgs e) {
            doStoreVisit(NextScreen.NextActionAndPlanOP);
        }

        private void buttonStoreVisitAndAddOperation_Click(object sender, EventArgs e) {
            doStoreVisit(NextScreen.planOperation);
        }

        private void buttonStoreVisitGoToChangePatient_Click(object sender, EventArgs e) {
            doStoreVisit(NextScreen.ChagePatient);
        }

        private void buttonStoreVisitAndAddToWaitingList_Click(object sender, EventArgs e) {
            doStoreVisit(NextScreen.AddWaitingList);
        }

        private void NewVisit_Load(object sender, EventArgs e) {
        }

        private void doStoreVisit(NextScreen nextScreen) {

            long visitID = 0;
            if (visit != null){
                visitID = visit.Id;
            }
            
            NewVisitStoreEventArgs e2 = new NewVisitStoreEventArgs(
                new VisitData(visitID,textBoxCauseOfVisit.Text, textBoxStatusLocalis.Text, textBoxDiagnosis.Text,
                textBoxProcedure.Text,textBoxTherapy.Text,this.currentPatient.Id,DateTime.Now,
                textBoxAnesthesiology.Text, textBoxUltrasound.Text, textBoxBlooddiagnostic.Text,
                textBoxTodo.Text, textBoxRadiodiagnostics.Text), nextScreen);
            Store(this, e2);
            Clear();
        }

        /// <summary>
        /// Initts the specified visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public void Init(VisitData visit){
            this.visit = visit;
            this.Clear();
            if ((visit != null) && (currentPatient != null)){
                if (currentPatient.Id != visit.PatientId){
                    MessageBox.Show("Fehler im Programm bitte Gassi melden!!");
                }
            }
            if (currentPatient != null) {
                labelPatientInfo.Text = currentPatient.Id + " " +
                                        currentPatient.FirstName + " " +
                                        currentPatient.SurName;
            } else {
                labelPatientInfo.Text = "";
            }       
            if (visit != null){
                textBoxCauseOfVisit.Text = visit.Cause;
                textBoxDiagnosis.Text = visit.ExtraDiagnosis;
                textBoxTherapy.Text = visit.ExtraTherapy;
                textBoxStatusLocalis.Text = visit.Localis;
                textBoxProcedure.Text = visit.Procedure;
                textBoxAnesthesiology.Text = visit.Anesthesiology;
                textBoxUltrasound.Text = visit.Ultrasound;
                textBoxBlooddiagnostic.Text = visit.Blooddiagnostic;
                textBoxTodo.Text = visit.Todo;
                textBoxRadiodiagnostics.Text = visit.Radiodiagnostics;
            }else{
            }
        }

        private void buttonPrintIdCard_Click(object sender, EventArgs e) {
            if (currentPatient == null) {
                return;
            }

            SPDPrint print = new SPDPrint(this.patComp);
            IList<PatientData> patients = new List<PatientData>();
            patients.Add(currentPatient);
            print.PrintIdCard(patients); 
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class NewVisitStoreEventArgs : EventArgs {
        private VisitData visit;
        private NextScreen nextScreen;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visit"> the visit</param>
        /// <param name="nextScreen">next screen</param>
        public NewVisitStoreEventArgs(VisitData visit, NextScreen nextScreen) {
            this.visit = visit;
            this.nextScreen = nextScreen;
        }
        /// <summary>
        /// Gets the visit.
        /// </summary>
        /// <value>The visit.</value>
        public VisitData Visit {
            get { return visit; }
        }
        /// <summary>
        /// Gets the if add next action after storing.
        /// </summary>
        /// <value>The visit.</value>
        public NextScreen NextScreen {
            get { return nextScreen; }
        }


    }
}
