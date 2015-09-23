using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SPD.CommonObjects;

namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public delegate void VisitChangeEventHandler(object sender,
             VisitChangeEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public partial class VisitsControl : UserControl {

        /// <summary>
        /// Gets or sets the list view visits.
        /// </summary>
        /// <value>The list view visits.</value>
        public System.Windows.Forms.ListView ListViewVisits {
            get { return listViewVisits; }
            set { listViewVisits = value; }
        }

        private IList<VisitData> visits;
        private PatientData patient;

        /// <summary>
        /// Occurs when [change].
        /// </summary>
        public event VisitChangeEventHandler Change;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitsControl"/> class.
        /// </summary>
        public VisitsControl() {
            InitializeComponent();

            listViewVisits.View = View.Details;
            listViewVisits.LabelEdit = false;
            listViewVisits.AllowColumnReorder = true;
            listViewVisits.FullRowSelect = true;

            // Create columns for the items and subitems.
            listViewVisits.Columns.Add("VID", 50);
            listViewVisits.Columns.Add("Diagnosis", 190);
            listViewVisits.Columns.Add("Procedure", 190);
            listViewVisits.Columns.Add("Cause", 100);
            listViewVisits.Columns.Add("Localis", 100);
            listViewVisits.Columns.Add("Date", 70);
        }
        
        //public IList<VisitData> Visits{
        //    set { visits = value; }
        //}

        //public PatientData Patient{
        //    set { patient = value; }
        //}

        /// <summary>
        /// Clears the specified with visits list.
        /// </summary>
        /// <param name="withVisitsList">if set to <c>true</c> [with visits list].</param>
        public void Clear(bool withVisitsList){
            if (withVisitsList)
                listViewVisits.Items.Clear();
            textBoxCause.Text = "";
            textBoxDateYear.Text = "";
            textBoxDateMonth.Text = "";
            textBoxDateDay.Text = "";
            textBoxExtraDiagnosis.Text = "";
            textBoxExtraTherapy.Text = "";
            textBoxLocalis.Text = "";
            textBoxPatientNr.Text = "";
            textBoxProcedure.Text = "";
            textBoxAnesthesiology.Text = "";
            textBoxUltrasound.Text = "";
            textBoxBlooddiagnostic.Text = "";
            textBoxTodo.Text = "";
            textBoxRadiodiagnostics.Text = "";
        }

        private void fillVisitList(){
            Clear(true);
            if (visits != null) {
                foreach (VisitData vd in visits) {
                    ListViewItem item = new ListViewItem(vd.Id.ToString());
                    item.SubItems.Add(vd.ExtraDiagnosis);
                    item.SubItems.Add(vd.Procedure);
                    item.SubItems.Add(vd.Cause);
                    item.SubItems.Add(vd.Localis);
                    item.SubItems.Add(vd.VisitDate.ToShortDateString());
                    listViewVisits.Items.Add(item);
                }
                if (listViewVisits.Items.Count > 0) {
                listViewVisits.SelectedIndices.Add(listViewVisits.Items.Count-1);
                }
            }
        }
        
        private void VisitsControl_Load(object sender, EventArgs e) {
        }

        /// <summary>
        /// Inits the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="visits">The visits.</param>
        public void Init(PatientData patient, IList<VisitData> visits) {
            this.patient = patient;
            this.visits = CommonUtilities.StaticUtilities.SortVisitsListByDate(visits);
            fillVisitList();
            labelHeadlineAndPatientData.Text = "Visits: " + patient.ToString();
            if (patient != null && patient.Id == 313) {
                this.pictureBoxEasterEgg.Visible = true;
            } else {
                this.pictureBoxEasterEgg.Visible = false;
            }

        }
        
        private void listViewVisits_SelectedIndexChanged(object sender, EventArgs e) {
            showDetailsBelow();
        }

        private void showDetailsBelow() {
            foreach (VisitData visit in visits) {
                if (listViewVisits.SelectedItems.Count > 0) {
                    if (visit.Id == Int64.Parse(listViewVisits.SelectedItems[0].Text)) {
                        textBoxCause.Text = visit.Cause;
                        textBoxDateYear.Text = visit.VisitDate.Year.ToString();
                        textBoxDateMonth.Text = visit.VisitDate.Month.ToString();
                        textBoxDateDay.Text = visit.VisitDate.Day.ToString();
                        textBoxExtraDiagnosis.Text = visit.ExtraDiagnosis;
                        textBoxExtraTherapy.Text = visit.ExtraTherapy;
                        textBoxLocalis.Text = visit.Localis;
                        textBoxPatientNr.Text = visit.PatientId.ToString();
                        textBoxProcedure.Text = visit.Procedure;
                        textBoxAnesthesiology.Text = visit.Anesthesiology;
                        textBoxUltrasound.Text = visit.Ultrasound;
                        textBoxBlooddiagnostic.Text = visit.Blooddiagnostic;
                        textBoxTodo.Text = visit.Todo;
                        textBoxRadiodiagnostics.Text = visit.Radiodiagnostics;
                    }
                }
            }
        }

        private void buttonChange_Click(object sender, EventArgs e){
            if (listViewVisits.SelectedItems.Count > 0) {
                foreach(VisitData visit in visits){
                    if (visit.Id == Int64.Parse(listViewVisits.SelectedItems[0].Text)){
                        VisitChangeEventArgs e2 = new VisitChangeEventArgs(visit);
                        Change(this, e2);
                    }                        
                }
            }
        }

        private VisitData getSelectedVisit(){
            long vId = 0;
            foreach (ListViewItem lvi in this.listViewVisits.SelectedItems) {
                vId = Int64.Parse(lvi.Text);
            }

            foreach (VisitData vd in this.visits) {
                if (vd.Id == vId) {
                    return vd;
                }
            }
            return null;
        }

        private bool isVisitSelected() {
            return (listViewVisits.SelectedItems.Count > 0);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VisitChangeEventArgs : EventArgs {
        private VisitData visit;
        /// <summary>
        /// Initializes a new instance of the <see cref="VisitChangeEventArgs"/> class.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public VisitChangeEventArgs(VisitData visit) {
            this.visit = visit;
        }
        /// <summary>
        /// Gets the visit.
        /// </summary>
        /// <value>The visit.</value>
        public VisitData Visit {
            get {
                return visit;
            }
        }
    }
}
