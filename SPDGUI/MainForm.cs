using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using SPD.BL;
using SPD.CommonObjects;
using System.Threading;
using SPD.CommonUtilities;
using SPD.BL.Interfaces;
using SPD.GUI.BLFactory;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Reflection;

namespace SPD.GUI {

    /// <summary>
    /// Defined the Next Screen
    /// </summary>
    public enum NextScreen {
        /// <summary>
        /// Undefiend
        /// </summary>
        Undefined,
        /// <summary>
        /// NExt Action
        /// </summary>
        NextAction,
        /// <summary>
        /// Operation
        /// </summary>
        Operation,
        /// <summary>
        /// Visit
        /// </summary>
        Visit,
        /// <summary>
        /// Plan Operation
        /// </summary>
        planOperation,
        /// <summary>
        /// Next Action and Plan OP
        /// </summary>
        NextActionAndPlanOP,
        /// <summary>
        /// Change Patient
        /// </summary>
        ChagePatient,
        /// <summary>
        /// AddWaitingList
        /// </summary>
        AddWaitingList
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form {
        
        #region members
        private NewPatientControl newPatientControl;
        private NewVisit newVisit;
        private PatientSearchControl patientSearchControl;
        private ISPDBL patComp;
        private VisitsControl visitsControl;
        private PatientData currentPatient;
        private OPControl newOperation;
        private FinalReportControl furtherTreatmentControl;
        private ShowOperationsControl showOperationsControl;
        private ImagesControl imagesControl;
        private PrintMorePatientsControl printMorePatientsControl;
        private BarDiagram barDiagramm;
        private BackupForm backupForm;
        private NextActionControl nextActionControl;
        private NextActionOverviewControl nextActionOverviewControl;
        private ImportControl importControl;
        private OverviewControl overviewControl;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //protected internal System.Timers.Timer tmrFade;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm() {
            //this.tmrFade = new System.Timers.Timer();
            //((System.ComponentModel.ISupportInitialize)(this.tmrFade)).BeginInit();
            InitializeComponent();
            //((System.ComponentModel.ISupportInitialize)(this.tmrFade)).EndInit();

            ////Shows Dialog for BL selection
            //ServerSelectionForm serverSelectionForm = new ServerSelectionForm();
            //serverSelectionForm.TopMost = true;
            //serverSelectionForm.ShowDialog();
            ////Generate the Selected BusinessLogic
            //patComp = SPDLFactory.GetBussinessLogicObject(ServerSelectionForm.GetEndPointData());//new SPDBL();

            patComp = new SPDBL();

            this.newOperation = new OPControl(this.patComp);
            this.newOperation.Store += new NewOperationStoreEventHandler(newOperation_Store);
            this.newPatientControl = new NewPatientControl(this.patComp);
            this.newPatientControl.Store += new NewPatientStoreEventHandler(this.patientStore);
            this.patientSearchControl = new PatientSearchControl();
            this.patientSearchControl.AddVisit += new AddVisitEventHandler(patientSearchControl_AddVisit);
            this.patientSearchControl.ChangePatientData += new ChangePatientDataEventHandler(patientSearchControl_ChangePatientData);
            this.patientSearchControl.ShowPatientData += new ShowPatientDataEventHandler(patientSearchControl_ShowPatientData);
            this.patientSearchControl.ShowVisits += new ShowVisitsEventHandler(patientSearchControl_ShowVisits);
            this.patientSearchControl.AddOperation += new AddOperationEventHandler(patientSearchControl_AddOperation);
            this.patientSearchControl.AddFurtherTreatment += new AddFurtherTreatmentEventHandler(patientSearchControl_AddFurtherTreatment);
            this.patientSearchControl.ShowOperations += new ShowOperationsEventHandler(patientSearchControl_ShowOperations);
            this.patientSearchControl.AddImages += new ImagesEventHandler(patientSearchControl_AddImages);
            this.patientSearchControl.SelectionChange += new SelectionChangeEventHandler(patientSearchControl_SelectionChange);
            this.patientSearchControl.PlanOP += new PlanOPEventHandler(patientSearchControl_PlanOP);
            this.patientSearchControl.NextAction += new NextActionEventHandler(patientSearchControl_NextAction);
            this.imagesControl = new ImagesControl();
            this.imagesControl.Store += new PhotoStoreEventHandler(imagesControl_Store);
            this.imagesControl.Delete += new DeleteImageEventHandler(imagesControl_Delete);
            this.showOperationsControl = new ShowOperationsControl();
            this.showOperationsControl.ChangeOP += new ChangeOPEventHandler(showOperationsControl_ChangeOP);
            this.newVisit = new NewVisit(this.patComp);
            this.visitsControl = new VisitsControl();
            this.visitsControl.Change += new VisitChangeEventHandler(visitControl_VisitChange);
            this.newVisit.Store +=new NewVisitStoreEventHandler(this.visitStore);
            this.furtherTreatmentControl = new FinalReportControl();
            this.furtherTreatmentControl.Store += new NewFinalReportStoreEventHandler(furtherTreatmentControl_Store);
            this.printMorePatientsControl = new PrintMorePatientsControl();
            this.barDiagramm = new BarDiagram();
            this.backupForm = new BackupForm();
            this.nextActionControl = new NextActionControl(this.patComp);
            this.nextActionOverviewControl = new NextActionOverviewControl(this.patComp);
            this.importControl = new ImportControl(this.patComp);
            this.overviewControl = new OverviewControl(this.patComp);

            Bitmap img;
            img = SPD.GUI.Properties.Resources.logogross;

            PictureBox picBox = new PictureBox();
            picBox.Image = img;
            picBox.Size = new Size(591, 383);
            picBox.Location = new System.Drawing.Point(200, 10);
            this.Controls.Add(picBox);

            img = SPD.GUI.Properties.Resources.KinderurologieLogo;
            picBox = new PictureBox();
            picBox.Image = img;
            picBox.Size = new Size(482, 323);
            picBox.Location = new System.Drawing.Point(259, 435);
            this.Controls.Add(picBox);

            // 
            // tmrFade
            // 
            //this.tmrFade.Interval = 10;
            //this.tmrFade.SynchronizingObject = this;
            //this.tmrFade.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrFade_Elapsed);

            //this.Opacity = 0;
            //this.Show();
            //tmrFade.Enabled = true;

            this.Text = Application.ProductName + " - " + Application.ProductVersion; // + " - Development Version!!";

            this.menuStrip.Items["backupToolStripMenuItem"].Enabled = patComp.SupportsBackup();
            ((ToolStripMenuItem)this.menuStrip.Items["settingsToolStripMenuItem"]).DropDownItems["databaseSettingsToolStripMenuItem"].Enabled = patComp.SupportDatabaseManagement();
        }
        #endregion

        #region handler
        //private void tmrFade_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
        //    this.Opacity += 0.05;
        //    if (this.Opacity >= .95) {
        //        this.Opacity = 1;
        //        tmrFade.Enabled = false;
        //    }
        //}
  
        /////////// Find Patient Sub Events BEGIN
        void imagesControl_Store(object sender, PhotoStoreEventArgs e) {
            ImageData idata = e.Image;

            if (idata.PhotoID == 0) {   // new Image
                idata.PatientID = currentPatient.Id;
                patComp.InsertImage(e.Image);
            } else { // change Image
                //patComp.UpdateImage(e.Image);
            }
            IList<ImageData> imageList = patComp.GetImagesByPatientID(currentPatient.Id);
            this.imagesControl.Initt(imageList);
        }

        void furtherTreatmentControl_Store(object sender, NewFinalReportStoreEventArgs e) {
            string ft = e.FinalReport;
            patComp.InsertFinalReport(ft,currentPatient.Id);
            //this.Controls.Remove(furtherTreatmentControl);
        }

        void imagesControl_Delete(object sender, DeleteImageEventArgs e) {
            ImageData idata = e.Image;

            patComp.DeleteImage(e.Image);

            IList<ImageData> imageList = patComp.GetImagesByPatientID(currentPatient.Id);
            this.imagesControl.Initt(imageList);
        }

        private void visitControl_VisitChange(object sender, VisitChangeEventArgs e) {
            this.Clear(patientSearchControl);
            this.activatePatientSearchControl(currentPatient);
            this.newVisit.Location = getPatientSearchSubMaskLocation();
            this.newVisit.CurrentPatient = currentPatient;
            this.newVisit.Init(e.Visit);
            this.Controls.Add(this.newVisit);
        }

        void showOperationsControl_ChangeOP(object sender, ChangeOPEventArgs e) {
            this.Clear(patientSearchControl);
            this.activatePatientSearchControl(e.Patient);
            currentPatient = e.Patient;
            this.newOperation.Enabled = true;
            this.newOperation.Location = getPatientSearchSubMaskLocation();
            this.newOperation.Init(e.Operation, currentPatient);
            this.Controls.Add(this.newOperation);
            this.newOperation.TextBoxOPTeam.Focus();
        }
        /////////// Find Patient Sub Events END


        void newOperation_Store(object sender, NewOperationStoreEventArgs e) {
            OperationData odata = e.Operation;

            if (odata.OperationId == 0) {   // new Operation
                odata.PatientId = currentPatient.Id;
                patComp.InsertOperation(e.Operation);
            } else { // change Visit
                patComp.UpdateOperation(e.Operation);
            }
            this.Controls.Remove(newOperation);
            putPatientSearchControl(currentPatient);
            this.patientSearchControl.ListViewPatients.Focus();
        } 

        private void putPatientSearchControl(PatientData currentPatient){
            this.patientSearchControl.Location = getTopMaskLocation();

            bool containsPatiensSearchControl = false;
            foreach (Control control in this.Controls) {
                if (control.GetType().Equals(patientSearchControl.GetType())) {
                    containsPatiensSearchControl = true;
                }
            }
            if (!containsPatiensSearchControl) {
                this.Controls.Add(patientSearchControl); 
            }

            activatePatientSearchControl(currentPatient);
        }

        private void activatePatientSearchControl(PatientData currentPatient) {
            this.currentPatient = currentPatient;
            this.patientSearchControl.Init(currentPatient, this.patComp);
            this.patientSearchControl.TextBoxFindName.Focus();
        }

        ///////// newPatientControl Handler BEGIN
        
        ///////// newPatientControl Handler END

        /////////// patientSearchContro Events BEGIN
        void patientSearchControl_SelectionChange(object sender, SelectionChangeEventArgs e) {
            this.Clear(patientSearchControl);
        }

        void patientSearchControl_AddVisit(object sender, AddVisitEventArgs e) {
            preparePatientSearchSubControlChange(e.Patient);
            this.newVisit.Clear();
            this.newVisit.Enabled = true;
            this.newVisit.Location = getPatientSearchSubMaskLocation();
            this.newVisit.CurrentPatient = currentPatient;
            this.newVisit.Init(null);
            this.Controls.Add(this.newVisit);
            VisitData lastVisit = patComp.GetLastVisitByPatientID(currentPatient.Id);
            if (lastVisit != null) {
                this.newVisit.TextBoxDiagnosis.Text = lastVisit.ExtraDiagnosis;
            }
            this.newVisit.TextBoxCauseOfVisit.Focus();
        }

        void patientSearchControl_ShowVisits(object sender, ShowVisitsEventArgs e) {
            this.preparePatientSearchSubControlChange(e.Patient);
            this.visitsControl.Clear(true);
            this.visitsControl.Location = getPatientSearchSubMaskLocation();
            this.visitsControl.Init(currentPatient, patComp.GetVisitsByPatientID(currentPatient.Id));
            this.Controls.Add(this.visitsControl);
            this.visitsControl.ListViewVisits.Focus();
        }

        void patientSearchControl_AddOperation(object sender, AddOperationEventArgs e) {
            this.preparePatientSearchSubControlChange(e.Patient);
            this.newOperation.Clear();
            this.newOperation.Enabled = true;
            this.newOperation.Location = getPatientSearchSubMaskLocation();
            this.newOperation.Init(null, currentPatient);
            this.Controls.Add(this.newOperation);
            this.newOperation.TextBoxOPTeam.Focus();
        }

        void patientSearchControl_ShowOperations(object sender, ShowOperationsEventArgs e) {
            this.preparePatientSearchSubControlChange(e.Patient);
            this.showOperationsControl.Clear();
            this.showOperationsControl.Enabled = true;
            this.showOperationsControl.Location = getPatientSearchSubMaskLocation();
            this.showOperationsControl.Init(currentPatient, this.patComp);
            this.Controls.Add(this.showOperationsControl);
            this.showOperationsControl.ListViewOperations.Focus();
        }

        void patientSearchControl_PlanOP(object sender, PlanOPEventArgs e) {
            doPlanOperation(e.Patient);
        }

        private void doPlanOperation(PatientData patient) {
            Plan_OP planOP = new Plan_OP();
            planOP.init(patient, patComp.GetDiagnoseByPatientOfLastVisit(patient.Id), patComp.GetLastVisitByPatientID(patient.Id).ExtraTherapy);
            planOP.TopMost = this.TopMost;
            planOP.ShowDialog();
        }

        void patientSearchControl_ShowPatientData(object sender, ShowPatientDataEventArgs e) {
            this.preparePatientSearchSubControlChange(e.Patient);
            this.newPatientControl.Enabled = false;
            this.newPatientControl.Location = getPatientSearchSubMaskLocation();
            this.newPatientControl.Init(currentPatient);
            this.Controls.Add(this.newPatientControl);
        }

        void patientSearchControl_ChangePatientData(object sender, ChangePatientDataEventArgs e) {
            this.preparePatientSearchSubControlChange(e.Patient);
            this.newPatientControl.Enabled = true;
            this.newPatientControl.Location = getPatientSearchSubMaskLocation();
            this.newPatientControl.Init(currentPatient);
            this.Controls.Add(this.newPatientControl);
            this.newPatientControl.TextBoxSurname.Focus();
            this.newPatientControl.TextBoxSurname.Select(0, 0);
        }

        void patientSearchControl_AddFurtherTreatment(object sender, AddFurtherTreatmentEventArgs e) {
            this.preparePatientSearchSubControlChange(e.Patient);
            this.furtherTreatmentControl.Clear();
            string ft = patComp.GetFinalReportByPatientId(currentPatient.Id);
            this.furtherTreatmentControl.Enabled = true;
            this.furtherTreatmentControl.Location = getPatientSearchSubMaskLocation();
            this.furtherTreatmentControl.CurrentPatient = currentPatient;
            this.furtherTreatmentControl.Init(ft, this.patComp);
            this.Controls.Add(this.furtherTreatmentControl);
            this.furtherTreatmentControl.TextBoxFinalReport.Focus();
            this.furtherTreatmentControl.TextBoxFinalReport.Select(50000, 0);
        }

        void patientSearchControl_AddImages(object sender, ImagesEventArgs e) {
            this.preparePatientSearchSubControlChange(e.Patient);
            this.imagesControl.Clear();
            this.imagesControl.Enabled = true;
            this.imagesControl.Location = getPatientSearchSubMaskLocation();
            this.imagesControl.CurrentPatient = currentPatient;
            IList<ImageData> imageList = patComp.GetImagesByPatientID(currentPatient.Id);
            this.imagesControl.Initt(imageList);
            this.Controls.Add(this.imagesControl);
            this.imagesControl.ListViewImages.Focus();
        }

        void patientSearchControl_NextAction(object sender, NextActionEventArgs e) {
            this.preparePatientSearchSubControlChange(e.Patient);
            this.nextActionControl.Location = getPatientSearchSubMaskLocation();
            this.Controls.Add(this.nextActionControl);
            this.nextActionControl.init(e.Patient);
        }

        /////////// patientSearchContro Events END

        /////////// menu Events BEGIN
        private void newPatientToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.currentPatient = null;
            this.newPatientControl.Enabled = true;
            this.newPatientControl.Location = getTopMaskLocation();
            this.newPatientControl.Init(null);
            this.newPatientControl.ButtonPrintIdCard.Enabled = false;
            this.Controls.Add(this.newPatientControl);
            this.newPatientControl.TextBoxSurname.Focus();
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.currentPatient = null;
            this.overviewControl.Enabled = true;
            this.overviewControl.Location = getTopMaskLocation();
            this.overviewControl.Init();
            this.Controls.Add(this.overviewControl);
        }

        private void findPatientToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            putPatientSearchControl(null);
        }

        private void nextActionsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.nextActionOverviewControl.Location = getTopMaskLocation();
            this.Controls.Add(nextActionOverviewControl);
            this.nextActionOverviewControl.Init(this.patComp);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBoxSPD about = new AboutBoxSPD();
            about.TopMost = this.TopMost;
            about.ShowDialog();
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e) {
            this.TopMost = !this.TopMost;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.printMorePatientsControl.Enabled = true;
            this.printMorePatientsControl.Location = getTopMaskLocation();
            this.Controls.Add(this.printMorePatientsControl);
            this.printMorePatientsControl.Init(this.patComp);
        }

        private void shortcutsToolStripMenuItem_Click(object sender, EventArgs e) {
            ShortcutsForm scf = new ShortcutsForm();
            scf.TopMost = this.TopMost;
            scf.ShowDialog();
        }

        private void sexToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.barDiagramm.Enabled = true;
            this.barDiagramm.Location = getTopMaskLocation();
            this.barDiagramm.Width = this.Width;
            IList<BardiagramElement> barElements = new List<BardiagramElement>();
            int malecount = 0;
            int femalecount = 0;
            foreach (PatientData patient in this.patComp.GetAllPatients()) {
                if (patient.Sex == Sex.male) {
                    malecount++;
                } else {
                    femalecount++;
                }
            }
            barElements.Add(new BardiagramElement("male", malecount));
            barElements.Add(new BardiagramElement("female", femalecount));
            this.barDiagramm.Init(barElements, "Sex of patients");
            this.Controls.Add(this.barDiagramm);
        }

        private void yearOfBirthToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.barDiagramm.Enabled = true;
            this.barDiagramm.Location = getTopMaskLocation();
            this.barDiagramm.Width = this.Width;
            IList<BardiagramElement> barElements = new List<BardiagramElement>();
            IDictionary<string, int> map = new Dictionary<string, int>();
            foreach (PatientData patient in this.patComp.GetAllPatients()) {
                if (!map.ContainsKey(patient.DateOfBirth.Year.ToString())) {
                    map.Add(patient.DateOfBirth.Year.ToString(), 1);
                } else {
                    map[patient.DateOfBirth.Year.ToString()]++;
                }
            }

            foreach (KeyValuePair<string, int> kvp in map) {
                barElements.Add(new BardiagramElement(kvp.Key, kvp.Value));
            }

            barElements = BarDiagram.BarDiagrammElementsByValue(barElements);

            this.barDiagramm.Init(barElements, "Year of Birth of Patients");
            this.Controls.Add(this.barDiagramm);
        }

        private void weightToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.barDiagramm.Enabled = true;
            this.barDiagramm.Location = getTopMaskLocation();
            this.barDiagramm.Width = this.Width;
            IList<BardiagramElement> barElements = new List<BardiagramElement>();
            IDictionary<string, int> map = new Dictionary<string, int>();
            foreach (PatientData patient in this.patComp.GetAllPatients()) {
                if (!map.ContainsKey(patient.Weight.ToString("00") + "kg")) {
                    map.Add(patient.Weight.ToString("00") + "kg", 1);
                } else {
                    map[patient.Weight.ToString("00") + "kg"]++;
                }
            }

            foreach (KeyValuePair<string, int> kvp in map) {
                barElements.Add(new BardiagramElement(kvp.Key, kvp.Value));
            }

            barElements = BarDiagram.BarDiagrammElementsByValue(barElements);

            IEnumerator<BardiagramElement> iter = barElements.GetEnumerator();
            while (iter.MoveNext()) {
                BardiagramElement bde = iter.Current;
                bde.Name = iter.Current.Name + "kg";
            }

            this.barDiagramm.Init(barElements, "Weight of Patients");
            this.Controls.Add(this.barDiagramm);
        }

        private void dateOfMissionToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.barDiagramm.Enabled = true;
            this.barDiagramm.Location = getTopMaskLocation();
            this.barDiagramm.Width = this.Width;
            IList<BardiagramElement> barElements = new List<BardiagramElement>();
            IList<VisitData> visits = patComp.getallVisits();
            foreach (VisitData visit in visits) {
                BardiagramElement elementx = null;
                foreach (BardiagramElement element in barElements) {
                    if ((Int64.Parse(element.Name) > (visit.VisitDate.Ticks - (12096000000000 * 2))) &&
                        (Int64.Parse(element.Name) < (visit.VisitDate.Ticks + (12096000000000 * 2)))) {
                        elementx = element;
                    }
                }
                if (elementx == null) {
                    barElements.Add(new BardiagramElement(visit.VisitDate.Ticks.ToString(), 1));
                } else {
                    elementx.Value++;
                }
            }

            barElements = BarDiagram.BarDiagrammElementsByValue(barElements);

            foreach (BardiagramElement element in barElements) {
                DateTime date = new DateTime(Int64.Parse(element.Name));
                element.Name = new System.Globalization.DateTimeFormatInfo().GetMonthName(date.Month).Substring(0, 3) + ". " + date.Year.ToString();
            }

            this.barDiagramm.Init(barElements, "Date of Visits per Mission");
            this.Controls.Add(this.barDiagramm);
        }

        private void dateOfMissionToolStripMenuItem1_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.barDiagramm.Enabled = true;
            this.barDiagramm.Location = getTopMaskLocation();
            this.barDiagramm.Width = this.Width;
            IList<BardiagramElement> barElements = new List<BardiagramElement>();
            IList<OperationData> operations = patComp.getallOperations();
            foreach (OperationData operation in operations) {
                BardiagramElement elementx = null;
                foreach (BardiagramElement element in barElements) {
                    if ((Int64.Parse(element.Name) > (operation.Date.Ticks - (12096000000000 * 2))) &&
                        (Int64.Parse(element.Name) < (operation.Date.Ticks + (12096000000000 * 2)))) {
                        //12096000000000 are 2 Weeks in DateTime Ticks the *2 means the doubeling to 4 weeks
                        elementx = element;
                    }
                }
                if (elementx == null) {
                    barElements.Add(new BardiagramElement(operation.Date.Ticks.ToString(), 1));
                } else {
                    elementx.Value++;
                }
            }

            barElements = BarDiagram.BarDiagrammElementsByValue(barElements);

            foreach (BardiagramElement element in barElements) {
                DateTime date = new DateTime(Int64.Parse(element.Name));
                element.Name = new System.Globalization.DateTimeFormatInfo().GetMonthName(date.Month).Substring(0, 3) + ". " + date.Year.ToString();
            }

            this.barDiagramm.Init(barElements, "Date of Visits per Mission");
            this.Controls.Add(this.barDiagramm);
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e) {
            backupForm.Init(this.patComp);
            backupForm.TopMost = this.TopMost;
            backupForm.ShowDialog();
        }
        /////////// menu Events END

        /////////// Helper Methods BEGIN
        private Point getPatientSearchSubMaskLocation() {
            return new System.Drawing.Point(2, 260);
        }

        private Point getTopMaskLocation() {
            return new System.Drawing.Point(2, 28);
        }

        private void preparePatientSearchSubControlChange(PatientData patient) {
            this.Clear(patientSearchControl);
            this.activatePatientSearchControl(patient);
            this.currentPatient = patient;
        }

        private void Clear(Control exceptControl) {
            IList<Control> controlsToRemove = new List<Control>();
            foreach (Control control in this.Controls) {
                bool isMenuStrip = control is MenuStrip;
                bool isStatusStrip = control is StatusStrip;
                bool isExceptControl = (exceptControl != null && exceptControl.GetType().Equals(control.GetType()));
                if (!isMenuStrip && !isStatusStrip && !isExceptControl) {
                    controlsToRemove.Add(control);
                }
            }
            foreach (Control controlRemove in controlsToRemove) {
                this.Controls.Remove(controlRemove);
            }
        }

        private void ClearData() {
            this.currentPatient = null;
        }
        /////////// Helper Methods END

        private void patientStore(object sender, NewPatientStoreEventArgs e) {
            if (e.Patient.Id == 0) { //new Patient
                this.currentPatient = patComp.InsertPatient(e.Patient);
                Clear(null);
                this.newVisit.Location = getTopMaskLocation();
                this.newVisit.CurrentPatient = this.currentPatient;
                this.newVisit.Init(null);
                this.Controls.Add(this.newVisit);
                this.newVisit.TextBoxCauseOfVisit.Focus();
            } else { //update Patient
                currentPatient = e.Patient;
                patComp.UpdatePatient(e.Patient);
                this.newPatientControl.Enabled = false;
            }


            IList<DiagnoseGroupData> oldAssignedDiagnoseGroups = patComp.FindDiagnoseGroupIdByPatientId(currentPatient.Id);

            foreach(DiagnoseGroupData dgd in oldAssignedDiagnoseGroups) {
                if (!e.DiagnoseGroups.Contains(dgd)) {
                    patComp.RemovePatientFromDiagnoseGroup(currentPatient.Id, dgd.DiagnoseGroupDataID);
                }
            }

            foreach (DiagnoseGroupData dgd in e.DiagnoseGroups) {
                if (!oldAssignedDiagnoseGroups.Contains(dgd)) {
                    patComp.AssignPatientToDiagnoseGroup(currentPatient.Id, dgd.DiagnoseGroupDataID);
                }
            }
        }

        private void visitStore(object sender, NewVisitStoreEventArgs e) {
            VisitData vdata = e.Visit;
            if (vdata.Id == 0) {   // new Visit
                vdata.PatientId = currentPatient.Id;
                patComp.InsertVisit(e.Visit);
            } else { // change Visit
                patComp.UpdateVisit(e.Visit);
            }
            this.Controls.Remove(newVisit);
            putPatientSearchControl(currentPatient);

            switch (e.NextScreen) {
                case NextScreen.NextAction:
                    //this.preparePatientSearchSubControlChange();
                    this.nextActionControl.Location = getPatientSearchSubMaskLocation();
                    this.Controls.Add(this.nextActionControl);
                    this.nextActionControl.init(currentPatient);
                    break;
                case NextScreen.NextActionAndPlanOP:
                    this.nextActionControl.Location = getPatientSearchSubMaskLocation();
                    this.Controls.Add(this.nextActionControl);
                    this.nextActionControl.init(currentPatient);
                    doPlanOperation(currentPatient);
                    break;
                case NextScreen.ChagePatient:
                    this.newPatientControl.Enabled = true;
                    this.newPatientControl.Location = getPatientSearchSubMaskLocation();
                    this.newPatientControl.Init(currentPatient);
                    this.Controls.Add(this.newPatientControl);
                    this.newPatientControl.TextBoxSurname.Focus();
                    this.newPatientControl.TextBoxSurname.Select(0, 0);
                    break;
                case NextScreen.Undefined:
                    this.patientSearchControl.ListViewPatients.Focus();
                    break;
                case NextScreen.AddWaitingList:
                    PatientData patient = this.patComp.FindPatientById(e.Visit.PatientId);
                    patient.WaitListStartDate = DateTime.Now;
                    this.patComp.UpdatePatient(patient);
                    this.patientSearchControl.ListViewPatients.Focus();
                    break;
                default:
                    break;
            }
        }

        private void databaseSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            DatabaseSettingsForm dbSettings = new DatabaseSettingsForm(this.patComp);
            dbSettings.TopMost = this.TopMost;
            dbSettings.ShowDialog();
        }

        private void toolStripMenuItemGeneralSettings_Click(object sender, EventArgs e) {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.TopMost = this.TopMost;
            settingsForm.ShowDialog();
        }

        private void diagnoseGroupSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            DiagnoseGroupSettingsForm digGrouForm = new DiagnoseGroupSettingsForm(this.patComp);
            digGrouForm.TopMost = true;
            digGrouForm.ShowDialog();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Clear(null);
            this.currentPatient = null;
            this.importControl.Enabled = true;
            this.importControl.Location = getTopMaskLocation();
            this.importControl.Init();
            this.Controls.Add(this.importControl);
            //this.importControl.TextBoxSurname.Focus();
        }

        private void clearCachesToolStripMenuItem_Click(object sender, EventArgs e) {
            this.patComp.ClearCaches();
        }

        #endregion
    }
}