using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPD.CommonObjects;

namespace SPD.GUI {
    public partial class Plan_OP : Form {
        private PatientData patient;
        private string lastDiagnosis;
        private string lastTherapy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Plan_OP"/> class.
        /// </summary>
        public Plan_OP() {
            InitializeComponent();
        }

        /// <summary>
        /// Initts the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="lastDiagnosis">The last diagnosis.</param>
        /// <param name="lastTherapy">The last therapy.</param>
        public void init(PatientData patient, string lastDiagnosis, string lastTherapy){
            this.patient = patient;
            this.lastDiagnosis = lastDiagnosis;
            this.lastTherapy = lastTherapy;
            fillTextBoxes();
        }

        /// <summary>
        /// Fills the text boxes.
        /// </summary>
        private void fillTextBoxes() {
            textBoxID.Text = patient.Id.ToString();
            textBoxName.Text = patient.SurName + " " + patient.FirstName;
            textBoxAge.Text = CommonUtilities.StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth);
            textBoxSex.Text = patient.Sex.ToString();
            textBoxWeight.Text = patient.Weight.ToString();
            textBoxIndication.Text = lastDiagnosis;
            textBoxTherapy.Text = lastTherapy;
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e) {
            string str =           textBoxID.Text + 
                            "\t" + textBoxName.Text + 
                            "\t" + textBoxAge.Text + 
                            "\t" + textBoxSex.Text + 
                            "\t" + textBoxWeight.Text + 
                            "\t" + textBoxIndication.Text +
                            "\t" + textBoxTherapy.Text;
            Clipboard.SetText(str);
        }

        private void buttonRestore_Click(object sender, EventArgs e) {
            fillTextBoxes();
        }

        private void Plan_OP_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x1b) {
                this.Close();
            }
        }

        private void buttonCopyToClipboardAndClose_Click(object sender, EventArgs e) {
            string str = textBoxID.Text +
                            "\t" + textBoxName.Text +
                            "\t" + textBoxAge.Text +
                            "\t" + textBoxSex.Text +
                            "\t" + textBoxWeight.Text +
                            "\t" + textBoxIndication.Text +
                            "\t" + textBoxTherapy.Text;
            Clipboard.SetText(str);
            this.Close();
        }
    }
}