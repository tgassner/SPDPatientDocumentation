using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SPD.CommonObjects;
using SPD.BL.Interfaces;

namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    public partial class NextActionControl : UserControl {

        private PatientData currentPatient;
        private ISPDBL patComp;

        /// <summary>
        /// Initializes a new instance of the <see cref="NextActionControl"/> class.
        /// </summary>
        public NextActionControl(ISPDBL patComp) {
            InitializeComponent();

            this.patComp = patComp;

            foreach(String action in Enum.GetNames(new ActionKind().GetType())) {
                this.listBoxAction.Items.Add(action);
            }

            this.listBoxHalfYear.Items.Add("1");
            this.listBoxHalfYear.Items.Add("2");

            for(int i = 0; i < 10; i++) {
                this.listBoxYear.Items.Add((i + DateTime.Now.Year).ToString());
            }


        }

        /// <summary>
        /// Handles the Click event of the buttonAddActiontoPatient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonAddActiontoPatient_Click(object sender, EventArgs e) {
            if(listBoxYear.SelectedItems.Count != 1) {
                MessageBox.Show("Please select a Year!");
                return;
            }

            if(listBoxHalfYear.SelectedItems.Count != 1) {
                MessageBox.Show("Please select a Half Year!");
                return;
            }

            if(listBoxAction.SelectedItems.Count != 1) {
                MessageBox.Show("Please select a Action!");
                return;
            }

            long year = Int64.Parse(this.listBoxYear.Text);
            long halfyear = Int64.Parse(this.listBoxHalfYear.Text);

            ActionKind actionkind = (ActionKind)Enum.Parse(new ActionKind().GetType(), this.listBoxAction.Text);

            IList<NextActionData> nextActions = patComp.GetNextActionsByPatientID(currentPatient.Id);
            foreach (NextActionData nextAction in nextActions) {
                if (nextAction.ActionYear == year &&
                    nextAction.ActionhalfYear == halfyear &&
                    nextAction.ActionKind == actionkind) {
                    MessageBox.Show("For year:" + year + " and halfyear:" + halfyear + " and Actionkind:" + actionkind.ToString() + "\r\n and Patient:" + currentPatient.Id + " is already a ToDo defined!");
                    return;
                }
            }

            patComp.InsertNextAction(new NextActionData(0,currentPatient.Id,actionkind,year,halfyear, textBoxToDo.Text.Trim()));
            refresh();
        }

        /// <summary>
        /// Handles the Click event of the buttonDeleteActionfromPatient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonDeleteActionfromPatient_Click(object sender, EventArgs e) {
            if(listBoxStoredActions.SelectedItems.Count != 1) {
                MessageBox.Show("Please select a Stored Action!");
                return;
            }
            patComp.DeleteNextAction((NextActionData)listBoxStoredActions.SelectedItem);
            this.refresh();
        }

        internal void init(PatientData currentPatient) {
            this.currentPatient = currentPatient;
            
            this.labelPatient.Text = this.currentPatient.FirstName + " " + this.currentPatient.SurName;
            this.textBoxToDo.Clear();
            refresh();
        }

        private void refresh() {
            this.listBoxStoredActions.Items.Clear();
            foreach(NextActionData nad in this.patComp.GetNextActionsByPatientID(this.currentPatient.Id)) {
                this.listBoxStoredActions.Items.Add(nad);
            }

            this.listBoxYear.SelectedItem = (DateTime.Now.Month <= 6) ? DateTime.Now.Year.ToString() : (DateTime.Now.Year + 1).ToString();

            this.listBoxHalfYear.SelectedItem = (DateTime.Now.Month <= 6) ? "2" : "1";

            this.listBoxAction.SelectedIndex = 1;
        }

        private void listBoxStoredActions_SelectedIndexChanged(object sender, EventArgs e) {
            
        }
    }
}
