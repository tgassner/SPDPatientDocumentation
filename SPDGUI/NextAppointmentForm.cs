using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using SPD.Print;

namespace SPD.GUI {
    public partial class NextAppointmentForm : Form {

        private ISPDBL patComp;
        private PatientData patient;

        /// <summary>
        /// Initializes a new instance of the <see cref="NextAppointmentForm"/> class.
        /// </summary>
        /// <param name="patComp">The pat comp.</param>
        /// <param name="patient">The patient.</param>
        public NextAppointmentForm(ISPDBL patComp, PatientData patient) {
            InitializeComponent();
            this.patComp = patComp;
            this.patient = patient;
        }

        private void NextAppointmentForm_Load(object sender, EventArgs e) {
            this.textBoxId.Text = this.patient.Id.ToString();
            this.textBoxName.Text = this.patient.FirstName + " " + this.patient.SurName;
            this.textBoxPlace.Text = SPD.GUI.Properties.Settings.Default.Location;
            VisitData lastVisit = this.patComp.GetLastVisitByPatientID(this.patient.Id);
            if (lastVisit != null)
            {
                this.textBoxDiagnoses.Text = lastVisit.ExtraDiagnosis;
                this.textBoxTodo.Text = lastVisit.Procedure;
            }
            listBoxTimePicker.Items.Clear();
            listBoxTimePicker.Items.Add("08:00");
            listBoxTimePicker.Items.Add("08:30");
            listBoxTimePicker.Items.Add("09:00");
            listBoxTimePicker.Items.Add("09:30");
            listBoxTimePicker.Items.Add("10:00");
            listBoxTimePicker.Items.Add("10:30");
            listBoxTimePicker.Items.Add("11:00");
            listBoxTimePicker.Items.Add("11:30");
            listBoxTimePicker.Items.Add("12:00");
            listBoxTimePicker.Items.Add("12:30");
            listBoxTimePicker.Items.Add("13:00");
            listBoxTimePicker.Items.Add("13:30");
            listBoxTimePicker.Items.Add("14:00");
            listBoxTimePicker.Items.Add("14:30");
            listBoxTimePicker.Items.Add("15:00");
            listBoxTimePicker.Items.Add("15:30");
            listBoxTimePicker.Items.Add("16:00");
            listBoxTimePicker.Items.Add("16:30");
            listBoxTimePicker.Items.Add("17:00");
            listBoxTimePicker.Items.Add("17:30");
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonPrint1NextAppointment_Click(object sender, EventArgs e) {
            SPDPrint print = new SPDPrint(this.patComp);
            print.PrintNextAppointment(patient, this.textBoxDiagnoses.Text, this.textBoxTodo.Text, this.textBoxDate.Text, this.textBoxTime.Text, 1);
            this.Close();
        }

        private void buttonPrint2NextAppointment_Click(object sender, EventArgs e) {
            SPDPrint print = new SPDPrint(this.patComp);
            print.PrintNextAppointment(patient, this.textBoxDiagnoses.Text, this.textBoxTodo.Text, this.textBoxDate.Text, this.textBoxTime.Text, 2);
            this.Close();
        }

        private void monthCalendarDate_DateSelected(object sender, DateRangeEventArgs e) {
            string insertString = monthCalendarDate.SelectionStart.DayOfWeek.ToString() + ", " + new System.Globalization.DateTimeFormatInfo().GetMonthName(monthCalendarDate.SelectionStart.Month) + " " + monthCalendarDate.SelectionStart.Day.ToString() + ". " + monthCalendarDate.SelectionStart.Year.ToString();
            this.textBoxDate.Text = insertString;
            this.textBoxDate.Focus();
        }

        private void listBoxTimePicker_SelectedIndexChanged(object sender, EventArgs e) {
            this.textBoxTime.Text = listBoxTimePicker.SelectedItem.ToString();
        }

        private void NextAppointmentForm_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x1b) {
                this.Close();
            }
        }

    }
}
