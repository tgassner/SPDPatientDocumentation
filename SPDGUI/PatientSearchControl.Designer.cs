namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    partial class PatientSearchControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listViewPatients = new System.Windows.Forms.ListView();
            this.buttonPatientDataChange = new System.Windows.Forms.Button();
            this.buttonAddVisit = new System.Windows.Forms.Button();
            this.buttonShowVisits = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonAddOperation = new System.Windows.Forms.Button();
            this.buttonFinalReport = new System.Windows.Forms.Button();
            this.buttonShowOperations = new System.Windows.Forms.Button();
            this.buttonImages = new System.Windows.Forms.Button();
            this.buttonPatientShowData = new System.Windows.Forms.Button();
            this.labelDiagnose = new System.Windows.Forms.Label();
            this.labelProcedure = new System.Windows.Forms.Label();
            this.textBoxDiagnoseFind = new System.Windows.Forms.TextBox();
            this.textBoxProcedureFind = new System.Windows.Forms.TextBox();
            this.buttonPlanOP = new System.Windows.Forms.Button();
            this.labelPatientNrFind = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNextAction = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxActionYear = new System.Windows.Forms.ComboBox();
            this.comboBoxActionHalfYear = new System.Windows.Forms.ComboBox();
            this.buttonSearchNextAction = new System.Windows.Forms.Button();
            this.comboBoxActionKind = new System.Windows.Forms.ComboBox();
            this.labelSizeSearchResult = new System.Windows.Forms.Label();
            this.textBoxFiendPhoneNr = new System.Windows.Forms.TextBox();
            this.labelFindPhoneNr = new System.Windows.Forms.Label();
            this.textBoxNumberOfPatients = new System.Windows.Forms.TextBox();
            this.labelStoredOperations = new System.Windows.Forms.Label();
            this.labelStoredVisits = new System.Windows.Forms.Label();
            this.textBoxNumberOfOperations = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfVisits = new System.Windows.Forms.TextBox();
            this.textBoxTherapyFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFindAllNameAndId = new System.Windows.Forms.TextBox();
            this.buttonPrintNextAppointment = new System.Windows.Forms.Button();
            this.labelLinz = new System.Windows.Forms.Label();
            this.comboBoxLinz = new System.Windows.Forms.ComboBox();
            this.labelAsmara = new System.Windows.Forms.Label();
            this.comboBoxAsmara = new System.Windows.Forms.ComboBox();
            this.labelFinished = new System.Windows.Forms.Label();
            this.comboBoxFinished = new System.Windows.Forms.ComboBox();
            this.DiagnoseGroup = new System.Windows.Forms.Label();
            this.comboBoxDiagnoseGroups = new System.Windows.Forms.ComboBox();
            this.comboBoxOPYear = new System.Windows.Forms.ComboBox();
            this.labelOPs = new System.Windows.Forms.Label();
            this.comboBoxOPHalfYears = new System.Windows.Forms.ComboBox();
            this.buttonOPSearch = new System.Windows.Forms.Button();
            this.buttonSearchAmulant = new System.Windows.Forms.Button();
            this.buttonWaitList = new System.Windows.Forms.Button();
            this.buttonAddToWaitList = new System.Windows.Forms.Button();
            this.buttonRemoveFromWaitList = new System.Windows.Forms.Button();
            this.buttonIdCardPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewPatients
            // 
            this.listViewPatients.HideSelection = false;
            this.listViewPatients.Location = new System.Drawing.Point(6, 55);
            this.listViewPatients.MultiSelect = false;
            this.listViewPatients.Name = "listViewPatients";
            this.listViewPatients.Size = new System.Drawing.Size(981, 143);
            this.listViewPatients.TabIndex = 18;
            this.listViewPatients.UseCompatibleStateImageBehavior = false;
            this.listViewPatients.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewPatients_ColumnClick);
            this.listViewPatients.SelectedIndexChanged += new System.EventHandler(this.listViewPatients_SelectedIndexChanged);
            // 
            // buttonPatientDataChange
            // 
            this.buttonPatientDataChange.Location = new System.Drawing.Point(378, 204);
            this.buttonPatientDataChange.Name = "buttonPatientDataChange";
            this.buttonPatientDataChange.Size = new System.Drawing.Size(74, 23);
            this.buttonPatientDataChange.TabIndex = 25;
            this.buttonPatientDataChange.Text = "&Change Pat.";
            this.buttonPatientDataChange.UseVisualStyleBackColor = true;
            this.buttonPatientDataChange.Click += new System.EventHandler(this.buttonPatientDataChange_Click);
            // 
            // buttonAddVisit
            // 
            this.buttonAddVisit.Location = new System.Drawing.Point(6, 204);
            this.buttonAddVisit.Name = "buttonAddVisit";
            this.buttonAddVisit.Size = new System.Drawing.Size(55, 23);
            this.buttonAddVisit.TabIndex = 19;
            this.buttonAddVisit.Text = "&Add visit";
            this.buttonAddVisit.UseVisualStyleBackColor = true;
            this.buttonAddVisit.Click += new System.EventHandler(this.buttonAddVisit_Click);
            // 
            // buttonShowVisits
            // 
            this.buttonShowVisits.Location = new System.Drawing.Point(67, 204);
            this.buttonShowVisits.Name = "buttonShowVisits";
            this.buttonShowVisits.Size = new System.Drawing.Size(68, 23);
            this.buttonShowVisits.TabIndex = 20;
            this.buttonShowVisits.Text = "&Show visits";
            this.buttonShowVisits.UseVisualStyleBackColor = true;
            this.buttonShowVisits.Click += new System.EventHandler(this.buttonShowVisits_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(951, 204);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(36, 23);
            this.buttonPrint.TabIndex = 30;
            this.buttonPrint.Text = "Prin&t";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonAddOperation
            // 
            this.buttonAddOperation.Location = new System.Drawing.Point(141, 204);
            this.buttonAddOperation.Name = "buttonAddOperation";
            this.buttonAddOperation.Size = new System.Drawing.Size(52, 23);
            this.buttonAddOperation.TabIndex = 21;
            this.buttonAddOperation.Text = "Add &OP";
            this.buttonAddOperation.UseVisualStyleBackColor = true;
            this.buttonAddOperation.Click += new System.EventHandler(this.buttonAddOperation_Click);
            // 
            // buttonFinalReport
            // 
            this.buttonFinalReport.Location = new System.Drawing.Point(458, 204);
            this.buttonFinalReport.Name = "buttonFinalReport";
            this.buttonFinalReport.Size = new System.Drawing.Size(63, 23);
            this.buttonFinalReport.TabIndex = 26;
            this.buttonFinalReport.Text = "Final Rep.";
            this.buttonFinalReport.UseVisualStyleBackColor = true;
            this.buttonFinalReport.Click += new System.EventHandler(this.buttonFurtherTreatment_Click);
            // 
            // buttonShowOperations
            // 
            this.buttonShowOperations.Location = new System.Drawing.Point(199, 204);
            this.buttonShowOperations.Name = "buttonShowOperations";
            this.buttonShowOperations.Size = new System.Drawing.Size(65, 23);
            this.buttonShowOperations.TabIndex = 22;
            this.buttonShowOperations.Text = "Sho&w OPs";
            this.buttonShowOperations.UseVisualStyleBackColor = true;
            this.buttonShowOperations.Click += new System.EventHandler(this.buttonShowOperations_Click);
            // 
            // buttonImages
            // 
            this.buttonImages.Location = new System.Drawing.Point(793, 204);
            this.buttonImages.Name = "buttonImages";
            this.buttonImages.Size = new System.Drawing.Size(37, 23);
            this.buttonImages.TabIndex = 28;
            this.buttonImages.Text = "&Imgs.";
            this.buttonImages.UseVisualStyleBackColor = true;
            this.buttonImages.Click += new System.EventHandler(this.buttonImages_Click);
            // 
            // buttonPatientShowData
            // 
            this.buttonPatientShowData.Location = new System.Drawing.Point(330, 204);
            this.buttonPatientShowData.Name = "buttonPatientShowData";
            this.buttonPatientShowData.Size = new System.Drawing.Size(42, 23);
            this.buttonPatientShowData.TabIndex = 24;
            this.buttonPatientShowData.Text = "S&how Pat.";
            this.buttonPatientShowData.UseVisualStyleBackColor = true;
            this.buttonPatientShowData.Click += new System.EventHandler(this.buttonPatientShowData_Click);
            // 
            // labelDiagnose
            // 
            this.labelDiagnose.AutoSize = true;
            this.labelDiagnose.Location = new System.Drawing.Point(127, 5);
            this.labelDiagnose.Name = "labelDiagnose";
            this.labelDiagnose.Size = new System.Drawing.Size(44, 13);
            this.labelDiagnose.TabIndex = 29;
            this.labelDiagnose.Text = "Diagno:";
            // 
            // labelProcedure
            // 
            this.labelProcedure.AutoSize = true;
            this.labelProcedure.Location = new System.Drawing.Point(126, 32);
            this.labelProcedure.Name = "labelProcedure";
            this.labelProcedure.Size = new System.Drawing.Size(44, 13);
            this.labelProcedure.TabIndex = 30;
            this.labelProcedure.Text = "Proced:";
            // 
            // textBoxDiagnoseFind
            // 
            this.textBoxDiagnoseFind.Location = new System.Drawing.Point(169, 3);
            this.textBoxDiagnoseFind.Name = "textBoxDiagnoseFind";
            this.textBoxDiagnoseFind.Size = new System.Drawing.Size(61, 20);
            this.textBoxDiagnoseFind.TabIndex = 1;
            this.textBoxDiagnoseFind.TextChanged += new System.EventHandler(this.textBoxDiagnoseFind_TextChanged);
            // 
            // textBoxProcedureFind
            // 
            this.textBoxProcedureFind.Location = new System.Drawing.Point(169, 28);
            this.textBoxProcedureFind.Name = "textBoxProcedureFind";
            this.textBoxProcedureFind.Size = new System.Drawing.Size(61, 20);
            this.textBoxProcedureFind.TabIndex = 11;
            this.textBoxProcedureFind.TextChanged += new System.EventHandler(this.textBoxProcedureFind_TextChanged);
            // 
            // buttonPlanOP
            // 
            this.buttonPlanOP.Location = new System.Drawing.Point(270, 204);
            this.buttonPlanOP.Name = "buttonPlanOP";
            this.buttonPlanOP.Size = new System.Drawing.Size(54, 23);
            this.buttonPlanOP.TabIndex = 23;
            this.buttonPlanOP.Text = "P&lan OP";
            this.buttonPlanOP.UseVisualStyleBackColor = true;
            this.buttonPlanOP.Click += new System.EventHandler(this.buttonPlanOP_Click);
            // 
            // labelPatientNrFind
            // 
            this.labelPatientNrFind.AutoSize = true;
            this.labelPatientNrFind.Location = new System.Drawing.Point(12, 32);
            this.labelPatientNrFind.Name = "labelPatientNrFind";
            this.labelPatientNrFind.Size = new System.Drawing.Size(0, 13);
            this.labelPatientNrFind.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Name / Id:";
            // 
            // buttonNextAction
            // 
            this.buttonNextAction.Location = new System.Drawing.Point(836, 204);
            this.buttonNextAction.Name = "buttonNextAction";
            this.buttonNextAction.Size = new System.Drawing.Size(70, 23);
            this.buttonNextAction.TabIndex = 29;
            this.buttonNextAction.Text = "&Next Action";
            this.buttonNextAction.UseVisualStyleBackColor = true;
            this.buttonNextAction.Click += new System.EventHandler(this.buttonNextAction_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(875, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "patients:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Next Action:";
            // 
            // comboBoxActionYear
            // 
            this.comboBoxActionYear.FormattingEnabled = true;
            this.comboBoxActionYear.Location = new System.Drawing.Point(414, 3);
            this.comboBoxActionYear.Name = "comboBoxActionYear";
            this.comboBoxActionYear.Size = new System.Drawing.Size(48, 21);
            this.comboBoxActionYear.TabIndex = 3;
            this.comboBoxActionYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextAction_KeyDown);
            // 
            // comboBoxActionHalfYear
            // 
            this.comboBoxActionHalfYear.FormattingEnabled = true;
            this.comboBoxActionHalfYear.Location = new System.Drawing.Point(465, 3);
            this.comboBoxActionHalfYear.Name = "comboBoxActionHalfYear";
            this.comboBoxActionHalfYear.Size = new System.Drawing.Size(30, 21);
            this.comboBoxActionHalfYear.TabIndex = 4;
            this.comboBoxActionHalfYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextAction_KeyDown);
            // 
            // buttonSearchNextAction
            // 
            this.buttonSearchNextAction.Image = global::SPD.GUI.Properties.Resources.search16;
            this.buttonSearchNextAction.Location = new System.Drawing.Point(568, 1);
            this.buttonSearchNextAction.Name = "buttonSearchNextAction";
            this.buttonSearchNextAction.Size = new System.Drawing.Size(23, 23);
            this.buttonSearchNextAction.TabIndex = 6;
            this.buttonSearchNextAction.UseVisualStyleBackColor = true;
            this.buttonSearchNextAction.Click += new System.EventHandler(this.buttonSearchNextAction_Click);
            // 
            // comboBoxActionKind
            // 
            this.comboBoxActionKind.FormattingEnabled = true;
            this.comboBoxActionKind.Location = new System.Drawing.Point(499, 3);
            this.comboBoxActionKind.Name = "comboBoxActionKind";
            this.comboBoxActionKind.Size = new System.Drawing.Size(66, 21);
            this.comboBoxActionKind.TabIndex = 5;
            this.comboBoxActionKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextAction_KeyDown);
            // 
            // labelSizeSearchResult
            // 
            this.labelSizeSearchResult.AutoSize = true;
            this.labelSizeSearchResult.Location = new System.Drawing.Point(758, 33);
            this.labelSizeSearchResult.Name = "labelSizeSearchResult";
            this.labelSizeSearchResult.Size = new System.Drawing.Size(35, 13);
            this.labelSizeSearchResult.TabIndex = 37;
            this.labelSizeSearchResult.Text = "label1";
            // 
            // textBoxFiendPhoneNr
            // 
            this.textBoxFiendPhoneNr.Location = new System.Drawing.Point(60, 28);
            this.textBoxFiendPhoneNr.Name = "textBoxFiendPhoneNr";
            this.textBoxFiendPhoneNr.Size = new System.Drawing.Size(63, 20);
            this.textBoxFiendPhoneNr.TabIndex = 10;
            this.textBoxFiendPhoneNr.TextChanged += new System.EventHandler(this.textBoxFiendPhoneNr_TextChanged);
            // 
            // labelFindPhoneNr
            // 
            this.labelFindPhoneNr.AutoSize = true;
            this.labelFindPhoneNr.Location = new System.Drawing.Point(20, 32);
            this.labelFindPhoneNr.Name = "labelFindPhoneNr";
            this.labelFindPhoneNr.Size = new System.Drawing.Size(41, 13);
            this.labelFindPhoneNr.TabIndex = 40;
            this.labelFindPhoneNr.Text = "Phone:";
            // 
            // textBoxNumberOfPatients
            // 
            this.textBoxNumberOfPatients.Location = new System.Drawing.Point(920, 3);
            this.textBoxNumberOfPatients.Name = "textBoxNumberOfPatients";
            this.textBoxNumberOfPatients.ReadOnly = true;
            this.textBoxNumberOfPatients.Size = new System.Drawing.Size(60, 20);
            this.textBoxNumberOfPatients.TabIndex = 9;
            // 
            // labelStoredOperations
            // 
            this.labelStoredOperations.AutoSize = true;
            this.labelStoredOperations.Location = new System.Drawing.Point(893, 33);
            this.labelStoredOperations.Name = "labelStoredOperations";
            this.labelStoredOperations.Size = new System.Drawing.Size(27, 13);
            this.labelStoredOperations.TabIndex = 34;
            this.labelStoredOperations.Text = "ops:";
            // 
            // labelStoredVisits
            // 
            this.labelStoredVisits.AutoSize = true;
            this.labelStoredVisits.Location = new System.Drawing.Point(798, 34);
            this.labelStoredVisits.Name = "labelStoredVisits";
            this.labelStoredVisits.Size = new System.Drawing.Size(33, 13);
            this.labelStoredVisits.TabIndex = 34;
            this.labelStoredVisits.Text = "visits:";
            // 
            // textBoxNumberOfOperations
            // 
            this.textBoxNumberOfOperations.Location = new System.Drawing.Point(920, 29);
            this.textBoxNumberOfOperations.Name = "textBoxNumberOfOperations";
            this.textBoxNumberOfOperations.ReadOnly = true;
            this.textBoxNumberOfOperations.Size = new System.Drawing.Size(60, 20);
            this.textBoxNumberOfOperations.TabIndex = 19;
            // 
            // textBoxNumberOfVisits
            // 
            this.textBoxNumberOfVisits.Location = new System.Drawing.Point(829, 31);
            this.textBoxNumberOfVisits.Name = "textBoxNumberOfVisits";
            this.textBoxNumberOfVisits.ReadOnly = true;
            this.textBoxNumberOfVisits.Size = new System.Drawing.Size(60, 20);
            this.textBoxNumberOfVisits.TabIndex = 18;
            // 
            // textBoxTherapyFind
            // 
            this.textBoxTherapyFind.Location = new System.Drawing.Point(286, 3);
            this.textBoxTherapyFind.Name = "textBoxTherapyFind";
            this.textBoxTherapyFind.Size = new System.Drawing.Size(61, 20);
            this.textBoxTherapyFind.TabIndex = 2;
            this.textBoxTherapyFind.TextChanged += new System.EventHandler(this.textBoxTherapyFind_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Therapy:";
            // 
            // textBoxFindAllNameAndId
            // 
            this.textBoxFindAllNameAndId.Location = new System.Drawing.Point(60, 3);
            this.textBoxFindAllNameAndId.Name = "textBoxFindAllNameAndId";
            this.textBoxFindAllNameAndId.Size = new System.Drawing.Size(63, 20);
            this.textBoxFindAllNameAndId.TabIndex = 0;
            this.textBoxFindAllNameAndId.TextChanged += new System.EventHandler(this.textBoxSearchAllNameAndId_TextChanged);
            // 
            // buttonPrintNextAppointment
            // 
            this.buttonPrintNextAppointment.Location = new System.Drawing.Point(527, 204);
            this.buttonPrintNextAppointment.Name = "buttonPrintNextAppointment";
            this.buttonPrintNextAppointment.Size = new System.Drawing.Size(99, 23);
            this.buttonPrintNextAppointment.TabIndex = 27;
            this.buttonPrintNextAppointment.Text = "Next Appointment";
            this.buttonPrintNextAppointment.UseVisualStyleBackColor = true;
            this.buttonPrintNextAppointment.Click += new System.EventHandler(this.buttonPrintNextAppointment_Click);
            // 
            // labelLinz
            // 
            this.labelLinz.AutoSize = true;
            this.labelLinz.Location = new System.Drawing.Point(597, 6);
            this.labelLinz.Name = "labelLinz";
            this.labelLinz.Size = new System.Drawing.Size(29, 13);
            this.labelLinz.TabIndex = 43;
            this.labelLinz.Text = "Linz:";
            // 
            // comboBoxLinz
            // 
            this.comboBoxLinz.FormattingEnabled = true;
            this.comboBoxLinz.Location = new System.Drawing.Point(632, 2);
            this.comboBoxLinz.Name = "comboBoxLinz";
            this.comboBoxLinz.Size = new System.Drawing.Size(72, 21);
            this.comboBoxLinz.TabIndex = 7;
            this.comboBoxLinz.SelectedIndexChanged += new System.EventHandler(this.comboBoxLinz_SelectedIndexChanged);
            // 
            // labelAsmara
            // 
            this.labelAsmara.AutoSize = true;
            this.labelAsmara.Location = new System.Drawing.Point(495, 33);
            this.labelAsmara.Name = "labelAsmara";
            this.labelAsmara.Size = new System.Drawing.Size(45, 13);
            this.labelAsmara.TabIndex = 45;
            this.labelAsmara.Text = "Asmara:";
            // 
            // comboBoxAsmara
            // 
            this.comboBoxAsmara.FormattingEnabled = true;
            this.comboBoxAsmara.Location = new System.Drawing.Point(537, 29);
            this.comboBoxAsmara.Name = "comboBoxAsmara";
            this.comboBoxAsmara.Size = new System.Drawing.Size(56, 21);
            this.comboBoxAsmara.TabIndex = 14;
            this.comboBoxAsmara.SelectedIndexChanged += new System.EventHandler(this.comboBoxAsmara_SelectedIndexChanged);
            // 
            // labelFinished
            // 
            this.labelFinished.AutoSize = true;
            this.labelFinished.Location = new System.Drawing.Point(368, 32);
            this.labelFinished.Name = "labelFinished";
            this.labelFinished.Size = new System.Drawing.Size(49, 13);
            this.labelFinished.TabIndex = 49;
            this.labelFinished.Text = "Finished:";
            // 
            // comboBoxFinished
            // 
            this.comboBoxFinished.FormattingEnabled = true;
            this.comboBoxFinished.Location = new System.Drawing.Point(414, 27);
            this.comboBoxFinished.Name = "comboBoxFinished";
            this.comboBoxFinished.Size = new System.Drawing.Size(68, 21);
            this.comboBoxFinished.TabIndex = 13;
            this.comboBoxFinished.SelectedIndexChanged += new System.EventHandler(this.comboBoxFinished_SelectedIndexChanged);
            // 
            // DiagnoseGroup
            // 
            this.DiagnoseGroup.AutoSize = true;
            this.DiagnoseGroup.Location = new System.Drawing.Point(726, 6);
            this.DiagnoseGroup.Name = "DiagnoseGroup";
            this.DiagnoseGroup.Size = new System.Drawing.Size(55, 13);
            this.DiagnoseGroup.TabIndex = 51;
            this.DiagnoseGroup.Text = "DigGroup:";
            // 
            // comboBoxDiagnoseGroups
            // 
            this.comboBoxDiagnoseGroups.FormattingEnabled = true;
            this.comboBoxDiagnoseGroups.Location = new System.Drawing.Point(779, 3);
            this.comboBoxDiagnoseGroups.Name = "comboBoxDiagnoseGroups";
            this.comboBoxDiagnoseGroups.Size = new System.Drawing.Size(86, 21);
            this.comboBoxDiagnoseGroups.TabIndex = 8;
            this.comboBoxDiagnoseGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxDiagnoseGroups_SelectedIndexChanged);
            // 
            // comboBoxOPYear
            // 
            this.comboBoxOPYear.FormattingEnabled = true;
            this.comboBoxOPYear.Location = new System.Drawing.Point(666, 29);
            this.comboBoxOPYear.Name = "comboBoxOPYear";
            this.comboBoxOPYear.Size = new System.Drawing.Size(52, 21);
            this.comboBoxOPYear.TabIndex = 16;
            // 
            // labelOPs
            // 
            this.labelOPs.AutoSize = true;
            this.labelOPs.Location = new System.Drawing.Point(602, 32);
            this.labelOPs.Name = "labelOPs";
            this.labelOPs.Size = new System.Drawing.Size(30, 13);
            this.labelOPs.TabIndex = 54;
            this.labelOPs.Text = "OPs:";
            // 
            // comboBoxOPHalfYears
            // 
            this.comboBoxOPHalfYears.FormattingEnabled = true;
            this.comboBoxOPHalfYears.Location = new System.Drawing.Point(631, 29);
            this.comboBoxOPHalfYears.Name = "comboBoxOPHalfYears";
            this.comboBoxOPHalfYears.Size = new System.Drawing.Size(36, 21);
            this.comboBoxOPHalfYears.TabIndex = 15;
            // 
            // buttonOPSearch
            // 
            this.buttonOPSearch.Image = global::SPD.GUI.Properties.Resources.search16;
            this.buttonOPSearch.Location = new System.Drawing.Point(719, 28);
            this.buttonOPSearch.Name = "buttonOPSearch";
            this.buttonOPSearch.Size = new System.Drawing.Size(23, 23);
            this.buttonOPSearch.TabIndex = 17;
            this.buttonOPSearch.UseVisualStyleBackColor = true;
            this.buttonOPSearch.Click += new System.EventHandler(this.buttonOPSearch_Click);
            // 
            // buttonSearchAmulant
            // 
            this.buttonSearchAmulant.Location = new System.Drawing.Point(237, 27);
            this.buttonSearchAmulant.Name = "buttonSearchAmulant";
            this.buttonSearchAmulant.Size = new System.Drawing.Size(60, 23);
            this.buttonSearchAmulant.TabIndex = 12;
            this.buttonSearchAmulant.Text = "Ambulant";
            this.buttonSearchAmulant.UseVisualStyleBackColor = true;
            this.buttonSearchAmulant.Click += new System.EventHandler(this.buttonSearchAmulant_Click);
            // 
            // buttonWaitList
            // 
            this.buttonWaitList.Location = new System.Drawing.Point(300, 27);
            this.buttonWaitList.Name = "buttonWaitList";
            this.buttonWaitList.Size = new System.Drawing.Size(56, 23);
            this.buttonWaitList.TabIndex = 55;
            this.buttonWaitList.Text = "Wait List";
            this.buttonWaitList.UseVisualStyleBackColor = true;
            this.buttonWaitList.Click += new System.EventHandler(this.buttonWaitList_Click);
            // 
            // buttonAddToWaitList
            // 
            this.buttonAddToWaitList.Location = new System.Drawing.Point(633, 204);
            this.buttonAddToWaitList.Name = "buttonAddToWaitList";
            this.buttonAddToWaitList.Size = new System.Drawing.Size(71, 23);
            this.buttonAddToWaitList.TabIndex = 56;
            this.buttonAddToWaitList.Text = "Add Waitlist";
            this.buttonAddToWaitList.UseVisualStyleBackColor = true;
            this.buttonAddToWaitList.Click += new System.EventHandler(this.buttonAddToWaitList_Click);
            // 
            // buttonRemoveFromWaitList
            // 
            this.buttonRemoveFromWaitList.Location = new System.Drawing.Point(710, 204);
            this.buttonRemoveFromWaitList.Name = "buttonRemoveFromWaitList";
            this.buttonRemoveFromWaitList.Size = new System.Drawing.Size(77, 23);
            this.buttonRemoveFromWaitList.TabIndex = 57;
            this.buttonRemoveFromWaitList.Text = "Rem. Waitlist";
            this.buttonRemoveFromWaitList.UseVisualStyleBackColor = true;
            this.buttonRemoveFromWaitList.Click += new System.EventHandler(this.buttonRemoveFromWaitList_Click);
            // 
            // buttonIdCardPrint
            // 
            this.buttonIdCardPrint.Location = new System.Drawing.Point(912, 205);
            this.buttonIdCardPrint.Name = "buttonIdCardPrint";
            this.buttonIdCardPrint.Size = new System.Drawing.Size(33, 23);
            this.buttonIdCardPrint.TabIndex = 58;
            this.buttonIdCardPrint.Text = "ID";
            this.buttonIdCardPrint.UseVisualStyleBackColor = true;
            this.buttonIdCardPrint.Click += new System.EventHandler(this.buttonIdCardPrint_Click);
            // 
            // PatientSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonIdCardPrint);
            this.Controls.Add(this.buttonRemoveFromWaitList);
            this.Controls.Add(this.buttonAddToWaitList);
            this.Controls.Add(this.buttonWaitList);
            this.Controls.Add(this.buttonSearchAmulant);
            this.Controls.Add(this.comboBoxOPHalfYears);
            this.Controls.Add(this.labelOPs);
            this.Controls.Add(this.comboBoxOPYear);
            this.Controls.Add(this.comboBoxDiagnoseGroups);
            this.Controls.Add(this.DiagnoseGroup);
            this.Controls.Add(this.comboBoxFinished);
            this.Controls.Add(this.labelFinished);
            this.Controls.Add(this.comboBoxAsmara);
            this.Controls.Add(this.labelAsmara);
            this.Controls.Add(this.comboBoxLinz);
            this.Controls.Add(this.labelLinz);
            this.Controls.Add(this.buttonPrintNextAppointment);
            this.Controls.Add(this.textBoxFindAllNameAndId);
            this.Controls.Add(this.textBoxTherapyFind);
            this.Controls.Add(this.textBoxNumberOfVisits);
            this.Controls.Add(this.textBoxNumberOfOperations);
            this.Controls.Add(this.textBoxNumberOfPatients);
            this.Controls.Add(this.labelFindPhoneNr);
            this.Controls.Add(this.textBoxFiendPhoneNr);
            this.Controls.Add(this.labelSizeSearchResult);
            this.Controls.Add(this.buttonOPSearch);
            this.Controls.Add(this.buttonSearchNextAction);
            this.Controls.Add(this.comboBoxActionKind);
            this.Controls.Add(this.comboBoxActionHalfYear);
            this.Controls.Add(this.comboBoxActionYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonNextAction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPlanOP);
            this.Controls.Add(this.textBoxProcedureFind);
            this.Controls.Add(this.textBoxDiagnoseFind);
            this.Controls.Add(this.labelProcedure);
            this.Controls.Add(this.labelDiagnose);
            this.Controls.Add(this.labelPatientNrFind);
            this.Controls.Add(this.labelStoredVisits);
            this.Controls.Add(this.labelStoredOperations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonPatientShowData);
            this.Controls.Add(this.buttonImages);
            this.Controls.Add(this.buttonShowOperations);
            this.Controls.Add(this.buttonFinalReport);
            this.Controls.Add(this.buttonAddOperation);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonShowVisits);
            this.Controls.Add(this.buttonAddVisit);
            this.Controls.Add(this.buttonPatientDataChange);
            this.Controls.Add(this.listViewPatients);
            this.Name = "PatientSearchControl";
            this.Size = new System.Drawing.Size(990, 235);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewPatients;
        private System.Windows.Forms.Button buttonPatientDataChange;
        private System.Windows.Forms.Button buttonAddVisit;
        private System.Windows.Forms.Button buttonShowVisits;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonAddOperation;
        private System.Windows.Forms.Button buttonFinalReport;
        private System.Windows.Forms.Button buttonShowOperations;
        private System.Windows.Forms.Button buttonImages;
        private System.Windows.Forms.Button buttonPatientShowData;
        private System.Windows.Forms.Label labelDiagnose;
        private System.Windows.Forms.Label labelProcedure;
        private System.Windows.Forms.TextBox textBoxDiagnoseFind;
        private System.Windows.Forms.TextBox textBoxProcedureFind;
        private System.Windows.Forms.Button buttonPlanOP;
        private System.Windows.Forms.Label labelPatientNrFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonNextAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxActionYear;
        private System.Windows.Forms.ComboBox comboBoxActionHalfYear;
        private System.Windows.Forms.Button buttonSearchNextAction;
        private System.Windows.Forms.ComboBox comboBoxActionKind;
        private System.Windows.Forms.Label labelSizeSearchResult;
        private System.Windows.Forms.TextBox textBoxFiendPhoneNr;
        private System.Windows.Forms.Label labelFindPhoneNr;
        private System.Windows.Forms.TextBox textBoxNumberOfPatients;
        private System.Windows.Forms.Label labelStoredOperations;
        private System.Windows.Forms.Label labelStoredVisits;
        private System.Windows.Forms.TextBox textBoxNumberOfOperations;
        private System.Windows.Forms.TextBox textBoxNumberOfVisits;
        private System.Windows.Forms.TextBox textBoxTherapyFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFindAllNameAndId;
        private System.Windows.Forms.Button buttonPrintNextAppointment;
        private System.Windows.Forms.Label labelLinz;
        private System.Windows.Forms.ComboBox comboBoxLinz;
        private System.Windows.Forms.Label labelAsmara;
        private System.Windows.Forms.ComboBox comboBoxAsmara;
        private System.Windows.Forms.Label labelFinished;
        private System.Windows.Forms.ComboBox comboBoxFinished;
        private System.Windows.Forms.Label DiagnoseGroup;
        private System.Windows.Forms.ComboBox comboBoxDiagnoseGroups;
        private System.Windows.Forms.ComboBox comboBoxOPYear;
        private System.Windows.Forms.Label labelOPs;
        private System.Windows.Forms.ComboBox comboBoxOPHalfYears;
        private System.Windows.Forms.Button buttonOPSearch;
        private System.Windows.Forms.Button buttonSearchAmulant;
        private System.Windows.Forms.Button buttonWaitList;
        private System.Windows.Forms.Button buttonAddToWaitList;
        private System.Windows.Forms.Button buttonRemoveFromWaitList;
        private System.Windows.Forms.Button buttonIdCardPrint;
    }
}
