using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using SPD.CommonObjects;
using SPD.BL.Interfaces;
using SPD.Print;


namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public delegate void NewPatientStoreEventHandler(object sender,
             NewPatientStoreEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class NewPatientControl : UserControl {
        private PatientData currentPatient;
        private ISPDBL patComp;

        /// <summary>
        /// Gets or sets the text box surname.
        /// </summary>
        /// <value>The text box surname.</value>
        public System.Windows.Forms.TextBox TextBoxSurname {
            set { textBoxSurname = value; }
            get { return textBoxSurname; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewPatientControl"/> class.
        /// </summary>
        public NewPatientControl(ISPDBL patComp) {
            InitializeComponent();

            this.patComp = patComp;

            foreach (String sex in Enum.GetNames(new Sex().GetType())) {
                this.listBoxSex.Items.Add(sex);
            }

            foreach (String ambulant in Enum.GetNames(new Ambulant().GetType())) {
                this.listBoxAmbulant.Items.Add(ambulant);
            }

            foreach (String resident in Enum.GetNames(new ResidentOfAsmara().GetType())) {
                this.listBoxResidentOfAsmara.Items.Add(resident);
            }

            foreach (String finished in Enum.GetNames(new Finished().GetType())) {
                this.listBoxFinished.Items.Add(finished);
            }

            foreach (String linz in Enum.GetNames(new Linz().GetType())) {
                this.listBoxLinz.Items.Add(linz);
            }

            this.labelLastHighestPiD.Text = "";
        }

        /// <summary>
        /// Gets or sets the button clear data.
        /// </summary>
        /// <value>The button clear data.</value>
        public Button ButtonClearData {
            get { return buttonClearData; }
            set { buttonClearData = value; }
        }

        /// <summary>
        /// Gets or sets the button save data.
        /// </summary>
        /// <value>The button save data.</value>
        public Button ButtonSaveData {
            get { return buttonSaveData; }
            set { buttonSaveData = value; }
        }

        /// <summary>
        /// Get or sets the button print Id Card
        /// </summary>
        public Button ButtonPrintIdCard {
            get { return buttonPrintIdCard; }
            set { buttonPrintIdCard = value; }
        }

        private void NewPatientControl_Load(object sender, EventArgs e) {
        }

        /// <summary>
        /// Initts this instance.
        /// </summary>
        public void Init(PatientData currentPatient) {
            this.currentPatient = currentPatient;
            enabler(true);
            monthCalendarBirth.Visible = false;
            buttonSubmitCalendar.Visible = false;
            buttonNoCalender.Visible = false;
            textBoxSurname.Select();
            fillTextBoxes();
            this.textBoxSurname.Focus();
            this.textBoxSurname.Select(0, 0);
            labelLastHighestPiD.Text = Convert.ToString(this.patComp.getHighesPatientId());
        }
        
        //public event System.EventHandler Store;
        /// <summary>
        /// Occurs when [store].
        /// </summary>
        public event NewPatientStoreEventHandler Store;

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear(){
            textBoxFirstName.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxBirthYear.Text = string.Empty;
            textBoxBirthMonth.Text = string.Empty;
            textBoxBirthDay.Text = string.Empty;
            textBoxWeight.Text = string.Empty;
            textBoxAge.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
            listBoxSex.SelectedItems.Clear();
            listBoxAmbulant.SelectedItems.Clear();
            listBoxAmbulant.SelectedIndex = 1;
            listBoxResidentOfAsmara.SelectedItems.Clear();
            listBoxResidentOfAsmara.SelectedIndex = 0;
            listBoxFinished.SelectedItems.Clear();
            listBoxFinished.SelectedIndex = 0;
            listBoxLinz.SelectedItems.Clear();
            listBoxLinz.SelectedIndex = 0;
            listBoxAssignedDiagnoseGroups.Items.Clear();
            listBoxAvailableDiagnoseGroups.Items.Clear();
            foreach(DiagnoseGroupData dgd in patComp.FindAllDiagnoseGroups()) {
                listBoxAvailableDiagnoseGroups.Items.Add(dgd);
            }
            labelWaitListDateValue.Text = string.Empty;
        }

        private void buttonClearData_Click(object sender, EventArgs e) {
            if (currentPatient == null) {
                Clear();
            } else {
                fillTextBoxes();
            }
        }

        private void buttonSaveData_Click(object sender, EventArgs e) {
            DateTime birthDate = new DateTime();
            if (!(textBoxBirthYear.Text.Trim().Equals("") &&
                textBoxBirthMonth.Text.Trim().Equals("") &&
                textBoxBirthDay.Text.Trim().Equals(""))) {
                try {
                    birthDate = new DateTime(Int32.Parse(textBoxBirthYear.Text.Trim()),
                                             Int32.Parse(textBoxBirthMonth.Text.Trim()),
                                             Int32.Parse(textBoxBirthDay.Text.Trim()));
                } catch (Exception exxx) {
                    MessageBox.Show("Sorry - but the date is not correct" + exxx.ToString());
                    return;
                }
            }

            DateTime? waitListDate = null;
            if (!string.IsNullOrWhiteSpace(labelWaitListDateValue.Text))
            {
                waitListDate = DateTime.Parse(labelWaitListDateValue.Text, DateTimeFormatInfo.InvariantInfo);
            }

            if (listBoxSex.SelectedItems.Count == 0) {
                MessageBox.Show("No gender is selected");
                return;
            }

            if (listBoxAmbulant.SelectedItems.Count == 0) {
                MessageBox.Show("Ambulant is not selected");
                return;
            }

            if (listBoxResidentOfAsmara.SelectedItems.Count == 0) {
                MessageBox.Show("Resident of Asmara is not selected");
                return;
            }

            if (listBoxFinished.SelectedItems.Count == 0) {
                MessageBox.Show("Finished is not selected");
                return;
            }

            if (listBoxLinz.SelectedItems.Count == 0) {
                MessageBox.Show("Linz is not selected");
                return;
            }

            Sex sex = (Sex)Enum.Parse(new Sex().GetType(), this.listBoxSex.Text);
            Ambulant ambulant = (Ambulant)Enum.Parse(new Ambulant().GetType(), this.listBoxAmbulant.Text);
            ResidentOfAsmara residentOfAsmara = (ResidentOfAsmara)Enum.Parse(new ResidentOfAsmara().GetType(), this.listBoxResidentOfAsmara.Text);
            Finished finished = (Finished)Enum.Parse(new Finished().GetType(), this.listBoxFinished.Text);
            Linz linz = (Linz)Enum.Parse(new Linz().GetType(), this.listBoxLinz.Text);

            long pId;
            if (currentPatient == null)
                pId = 0;
            else
                pId = currentPatient.Id;

            int weight;

            try {
                weight = Int32.Parse(textBoxWeight.Text.Trim());
            } catch (Exception) {
                weight = 0;
                if (textBoxWeight.Text.Trim().Equals("")){
                    weight = 0;
                }else{
                    MessageBox.Show("In the weight field has to be a integer number");
                    return;
                }
            }

            if (this.patComp.DoesPhoneExist(this.textBoxPhone.Text.Trim())) {
                IList<PatientData> patients = this.patComp.FindPatientByPhone(this.textBoxPhone.Text.Trim());
                if (!(patients.Count == 1 && currentPatient != null && patients[0].Id == currentPatient.Id)) {
                    StringBuilder sb = new StringBuilder();
                    foreach (PatientData pd in patients) {
                        sb.Append(Environment.NewLine + "-----------------------------------" + Environment.NewLine).Append(pd.ToLineBreakedString()).Append(Environment.NewLine);
                    }
                    DialogResult res = MessageBox.Show("This phone Number is already stored." + Environment.NewLine + "Do you want to add the Patient anyway?" + "Patient(s):" + sb.ToString(), "Warning!", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No) {
                        return;
                    }
                }
            }

            PatientData patient = new PatientData(pId, textBoxFirstName.Text.Trim(), textBoxSurname.Text.Trim(),
                    birthDate, sex, textBoxPhone.Text.Trim(),
                    weight, textBoxAddress.Text.Trim(), residentOfAsmara, ambulant, finished, linz, waitListDate);

            IList<DiagnoseGroupData> diagnoseGroups = new List<DiagnoseGroupData>();
            foreach (DiagnoseGroupData dg in listBoxAssignedDiagnoseGroups.Items) {
                diagnoseGroups.Add(dg);
            }

            NewPatientStoreEventArgs e2 = new NewPatientStoreEventArgs(patient, diagnoseGroups);

            Store(this, e2);
        }

        /// <summary>
        /// Enablers the specified enable.
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        public void enabler(bool enable) {
            textBoxFirstName.Enabled = enable;
            textBoxSurname.Enabled = enable;
            textBoxBirthYear.Enabled = enable;
            textBoxBirthMonth.Enabled = enable;
            textBoxBirthDay.Enabled = enable;
            textBoxPhone.Enabled = enable;
            textBoxAddress.Enabled = enable;
            textBoxAge.Enabled = enable;
            textBoxWeight.Enabled = enable;
            listBoxSex.Enabled = enable;
            listBoxResidentOfAsmara.Enabled = enable;
            listBoxAmbulant.Enabled = enable;
            listBoxFinished.Enabled = enable;
            listBoxLinz.Enabled = enable;
            buttonSaveData.Enabled = enable;
            buttonCalendar.Enabled = enable;
            buttonNoCalender.Enabled = enable;
            buttonClearData.Enabled = enable;
            buttonSubmitCalendar.Enabled = enable;
            listBoxAssignedDiagnoseGroups.Enabled = enable;
            listBoxAvailableDiagnoseGroups.Enabled = enable;
            buttonAssign.Enabled = enable;
            buttonUnassign.Enabled = enable;
            buttonPrintIdCard.Enabled = enable;
        }

        private void buttonCalendar_Click(object sender, EventArgs e) {
            enabler(false);
            monthCalendarBirth.Visible = true;
            buttonSubmitCalendar.Enabled = true;
            buttonSubmitCalendar.Visible = true;
            buttonNoCalender.Enabled = true;
            buttonNoCalender.Visible = true;
        }

        private void buttonSubmitCalendar_Click(object sender, EventArgs e) {
            enabler(true);
            monthCalendarBirth.Visible = false;
            buttonSubmitCalendar.Visible = false;
            buttonNoCalender.Visible = false;
            if (this.currentPatient == null || currentPatient.Id < 1) {
                this.buttonPrintIdCard.Enabled = false;
            }
            textBoxBirthMonth.Text = monthCalendarBirth.SelectionStart.Month.ToString();
            textBoxBirthYear.Text = monthCalendarBirth.SelectionStart.Year.ToString();
            textBoxBirthDay.Text = monthCalendarBirth.SelectionStart.Day.ToString();
        }

        private void buttonNoCalender_Click(object sender, EventArgs e) {
            enabler(true);
            monthCalendarBirth.Visible = false;
            buttonSubmitCalendar.Visible = false;
            buttonNoCalender.Visible = false;
            if (this.currentPatient == null || currentPatient.Id < 1) {
                this.buttonPrintIdCard.Enabled = false;
            }
        }

        ///// <summary>
        ///// Sets the patient.
        ///// </summary>
        ///// <value>The patient.</value>
        //public PatientData Patient {
        //    set {
        //        currentPatient = value;
        //        fillTextBoxes();
        //    }
        //}

        /// <summary>
        /// Fills the text boxes.
        /// </summary>
        private void fillTextBoxes(){
            if (currentPatient != null) {
                textBoxFirstName.Text = currentPatient.FirstName;
                textBoxSurname.Text = currentPatient.SurName;
                textBoxBirthDay.Text = currentPatient.DateOfBirth.Day.ToString();
                textBoxBirthMonth.Text = currentPatient.DateOfBirth.Month.ToString();
                textBoxBirthYear.Text = currentPatient.DateOfBirth.Year.ToString();
                textBoxPhone.Text = currentPatient.Phone;
                textBoxAge.Text = SPD.CommonUtilities.StaticUtilities.getAgeFromBirthDate(currentPatient.DateOfBirth);
                textBoxWeight.Text = currentPatient.Weight.ToString();
                textBoxAddress.Text = currentPatient.Address;
                listBoxSex.SelectedItem = currentPatient.Sex.ToString();
                listBoxResidentOfAsmara.SelectedItem = currentPatient.ResidentOfAsmara.ToString();
                listBoxAmbulant.SelectedItem = currentPatient.Ambulant.ToString();
                listBoxFinished.SelectedItem = currentPatient.Finished.ToString();
                listBoxLinz.SelectedItem = currentPatient.Linz.ToString();
                listBoxAvailableDiagnoseGroups.Items.Clear();
                listBoxAssignedDiagnoseGroups.Items.Clear();
                if (currentPatient.WaitListStartDate == null) {
                    labelWaitListDateValue.Text = string.Empty;
                } else {
                    labelWaitListDateValue.Text = ((DateTime)currentPatient.WaitListStartDate).ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);    
                }
                
                foreach(DiagnoseGroupData dgd in patComp.FindDiagnoseGroupIdByPatientId(currentPatient.Id)) {
                    listBoxAssignedDiagnoseGroups.Items.Add(dgd);
                }
                foreach(DiagnoseGroupData dgd in patComp.FindAllDiagnoseGroupsThatAreNotAssignedByPatient(currentPatient.Id)) {
                    listBoxAvailableDiagnoseGroups.Items.Add(dgd);
                }

            } else {
                Clear();
            }
        }

        /// <summary>
        /// Handles the Leave event of the textBoxAge control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void textBoxAge_Leave(object sender, EventArgs e) {
            int age;
            if (textBoxAge.Text.Equals("")) {
                return;
            }
            try {
                age = Int32.Parse(textBoxAge.Text);
            } catch {
                textBoxAge.Text = "";
                MessageBox.Show("The Age must be a natural Number");
                return;
            }
            DateTime date = CommonUtilities.StaticUtilities.getBirthDateFromAge(age);
            textBoxBirthDay.Text = date.Day.ToString();
            textBoxBirthMonth.Text = date.Month.ToString();
            textBoxBirthYear.Text = date.Year.ToString();
        }

        private void buttonAssign_Click(object sender, EventArgs e) {
            if (listBoxAvailableDiagnoseGroups.SelectedItems.Count < 1) {
                MessageBox.Show("Please select a Diagnosegroup to assign.");
                return;
            }
            listBoxAssignedDiagnoseGroups.Items.Add(listBoxAvailableDiagnoseGroups.SelectedItem);
            listBoxAvailableDiagnoseGroups.Items.Remove(listBoxAvailableDiagnoseGroups.SelectedItem);
        }

        private void buttonUnassign_Click(object sender, EventArgs e) {
            if (listBoxAssignedDiagnoseGroups.SelectedItems.Count < 1) {
                MessageBox.Show("Please select a Diagnosegroup to unassign.");
                return;
            }
            listBoxAvailableDiagnoseGroups.Items.Add(listBoxAssignedDiagnoseGroups.SelectedItem);
            listBoxAssignedDiagnoseGroups.Items.Remove(listBoxAssignedDiagnoseGroups.SelectedItem);
        }

        private void listBoxAssignedDiagnoseGroups_DoubleClick(object sender, EventArgs e) {
            if (listBoxAssignedDiagnoseGroups.SelectedItems.Count < 1) {
                MessageBox.Show("Please select a Diagnosegroup to unassign.");
                return;
            }
            listBoxAvailableDiagnoseGroups.Items.Add(listBoxAssignedDiagnoseGroups.SelectedItem);
            listBoxAssignedDiagnoseGroups.Items.Remove(listBoxAssignedDiagnoseGroups.SelectedItem);
        }

        private void listBoxAvailableDiagnoseGroups_DoubleClick(object sender, EventArgs e) {
            if (listBoxAvailableDiagnoseGroups.SelectedItems.Count < 1) {
                MessageBox.Show("Please select a Diagnosegroup to assign.");
                return;
            }
            listBoxAssignedDiagnoseGroups.Items.Add(listBoxAvailableDiagnoseGroups.SelectedItem);
            listBoxAvailableDiagnoseGroups.Items.Remove(listBoxAvailableDiagnoseGroups.SelectedItem);
        }

        private void buttonPrintIdCard_Click(object sender, EventArgs e) {
            if (currentPatient == null)
            {
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
    public class NewPatientStoreEventArgs : EventArgs {
        private PatientData patient;
        private IList<DiagnoseGroupData> diagnoseGroups;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewPatientStoreEventArgs" /> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="diagnoseGroups">The diagnose groups.</param>
        public NewPatientStoreEventArgs(PatientData patient, IList<DiagnoseGroupData> diagnoseGroups) {
            this.patient = patient;
            this.diagnoseGroups = diagnoseGroups;
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

        /// <summary>
        /// Gets the diagnose groups.
        /// </summary>
        /// <value>
        /// The diagnose groups.
        /// </value>
        public IList<DiagnoseGroupData> DiagnoseGroups {
            get {
                return diagnoseGroups;
            }
        }
    }
}
