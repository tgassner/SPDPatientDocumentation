using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using System.Collections;

namespace SPD.GUI {
    public partial class NextActionOverviewControl : UserControl {

        #region private members

        private ISPDBL patComp;
        private int selectedIndexYear = -1;
        private bool yearfilled = false;

        #endregion private members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patComp"></param>
        public NextActionOverviewControl(ISPDBL patComp) {
            InitializeComponent();

            this.patComp = patComp;

            listViewNextActions.View = View.Details;
            listViewNextActions.LabelEdit = false;
            listViewNextActions.AllowColumnReorder = true;
            listViewNextActions.FullRowSelect = true;

            listViewNextActions.Columns.Add("PID", 40);
            listViewNextActions.Columns.Add("Name", 200);
            listViewNextActions.Columns.Add("Age", 45);
            listViewNextActions.Columns.Add("Sex", 45);
            listViewNextActions.Columns.Add("Phone", 100);
            listViewNextActions.Columns.Add("ToDo", 180);
            listViewNextActions.Columns.Add("Diagnoses", 180);
            listViewNextActions.Columns.Add("Therapy", 180);

            foreach (String action in Enum.GetNames(new ActionKind().GetType())) {
                this.listBoxAction.Items.Add(action);
            }

            this.listBoxHalfYear.Items.Add(1);
            this.listBoxHalfYear.Items.Add(2);

        }

        internal void Init(SPD.BL.Interfaces.ISPDBL iSPDBL) {

            //First Tile fill the Years
            if (!yearfilled) {
                int counter = 0;
                foreach (long year in patComp.GetAllNextActionYears()) {
                    this.listBoxYear.Items.Add(year);
                    if (DateTime.Now.Year == year) {
                        this.selectedIndexYear = counter;
                    }
                    counter++;
                }
                yearfilled = true;
            }

            if (selectedIndexYear > 0) {
                this.listBoxYear.SelectedIndex = selectedIndexYear;
            } else {
                this.listBoxYear.SelectedItems.Clear();
            }

            this.listBoxAction.SelectedItems.Clear();

            this.listBoxAction.SelectedIndex = 1;

            if (DateTime.Now.Month <= 6) {
                this.listBoxHalfYear.SelectedIndex = 1;
            } else {
                this.listBoxHalfYear.SelectedIndex = 0;
            }

            this.listViewNextActions.Items.Clear();

            doSearch();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e) {
            doSearch();
        }

        private void doSearch() {
            if (listBoxYear.SelectedItems.Count == 0 || listBoxHalfYear.SelectedItems.Count == 0 || listBoxAction.SelectedItems.Count == 0) {
                return;
            }

            this.listViewNextActions.Items.Clear();

            long year = long.Parse(this.listBoxYear.SelectedItem.ToString());
            long halfYear = long.Parse(this.listBoxHalfYear.SelectedItem.ToString());
            ActionKind actionKind = (ActionKind)Enum.Parse(new ActionKind().GetType(), this.listBoxAction.SelectedItem.ToString());

            IList<PatientData> patients = this.patComp.FindPatientsWithNextAction(
                year,
                halfYear,
                actionKind);

            foreach (PatientData patient in patients) {
                ListViewItem item = new ListViewItem(patient.Id.ToString());
                item.SubItems.Add(patient.SurName + " " + patient.FirstName);
                item.SubItems.Add(CommonUtilities.StaticUtilities.getAgeFromBirthDate(patient.DateOfBirth));
                item.SubItems.Add(patient.Sex.ToString());
                item.SubItems.Add(patient.Phone);
                IList<NextActionData> nextActions = patComp.GetNextActionsByPatientID(patient.Id);
                StringBuilder todo = new StringBuilder();
                foreach (NextActionData nextAction in nextActions) {
                    if (nextAction.ActionYear == year &&
                        nextAction.ActionhalfYear == halfYear &&
                        nextAction.ActionKind == actionKind) {
                        todo.Append(nextAction.Todo);
                    }
                }
                item.SubItems.Add(todo.ToString());
                item.SubItems.Add(getDiagnoses(patient.Id));
                item.SubItems.Add(getTherapy(patient.Id));
                listViewNextActions.Items.Add(item);
            }
        }

        private String getDiagnoses(long patientId) {
            OperationData operation = this.patComp.GetLastOperationByPatientID(patientId);
            if (operation != null && !String.IsNullOrEmpty(operation.Diagnoses)) {
                return "OP: " + operation.Diagnoses;
            } else {
                VisitData visit = this.patComp.GetLastVisitByPatientID(patientId);
                if (visit != null && !String.IsNullOrEmpty(visit.ExtraDiagnosis)) {
                    return "Visit: " + visit.ExtraDiagnosis;
                }
            }
            return String.Empty;
        }

        private String getTherapy(long patientId) {
            VisitData visit = this.patComp.GetLastVisitByPatientID(patientId);
            if (visit != null && !String.IsNullOrEmpty(visit.ExtraTherapy)) {
                return visit.ExtraTherapy;
            }
            return String.Empty;
        }
    }
}
