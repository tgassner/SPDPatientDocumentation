namespace SPD.GUI {
    partial class NewPatientControl {
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
            this.buttonPrintIdCard = new System.Windows.Forms.Button();
            this.listBoxAssignedDiagnoseGroups = new System.Windows.Forms.ListBox();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.buttonUnassign = new System.Windows.Forms.Button();
            this.labelAssignedDiagnoseGroups = new System.Windows.Forms.Label();
            this.labelAvailableDiagnoseGroups = new System.Windows.Forms.Label();
            this.listBoxAvailableDiagnoseGroups = new System.Windows.Forms.ListBox();
            this.groupBoxDiagnoseGroups = new System.Windows.Forms.GroupBox();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelFirstname = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.labelBirthDate = new System.Windows.Forms.Label();
            this.textBoxBirthDay = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.buttonCalendar = new System.Windows.Forms.Button();
            this.buttonClearData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBirthMonth = new System.Windows.Forms.TextBox();
            this.textBoxBirthYear = new System.Windows.Forms.TextBox();
            this.monthCalendarBirth = new System.Windows.Forms.MonthCalendar();
            this.buttonSubmitCalendar = new System.Windows.Forms.Button();
            this.buttonNoCalender = new System.Windows.Forms.Button();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelAge = new System.Windows.Forms.Label();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.labelWeight = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.listBoxSex = new System.Windows.Forms.ListBox();
            this.listBoxAmbulant = new System.Windows.Forms.ListBox();
            this.labelAmbulant = new System.Windows.Forms.Label();
            this.labelResidentofAsmara = new System.Windows.Forms.Label();
            this.listBoxResidentOfAsmara = new System.Windows.Forms.ListBox();
            this.labelFinished = new System.Windows.Forms.Label();
            this.listBoxFinished = new System.Windows.Forms.ListBox();
            this.listBoxLinz = new System.Windows.Forms.ListBox();
            this.labelLinz = new System.Windows.Forms.Label();
            this.labelLastHighestPiD = new System.Windows.Forms.Label();
            this.labelWaitListDateLabel = new System.Windows.Forms.Label();
            this.labelWaitListDateValue = new System.Windows.Forms.Label();
            this.groupBoxDiagnoseGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPrintIdCard
            // 
            this.buttonPrintIdCard.Location = new System.Drawing.Point(330, 12);
            this.buttonPrintIdCard.Name = "buttonPrintIdCard";
            this.buttonPrintIdCard.Size = new System.Drawing.Size(81, 23);
            this.buttonPrintIdCard.TabIndex = 41;
            this.buttonPrintIdCard.Text = "Print Id Card";
            this.buttonPrintIdCard.UseVisualStyleBackColor = true;
            this.buttonPrintIdCard.Click += new System.EventHandler(this.buttonPrintIdCard_Click);
            // 
            // listBoxAssignedDiagnoseGroups
            // 
            this.listBoxAssignedDiagnoseGroups.FormattingEnabled = true;
            this.listBoxAssignedDiagnoseGroups.Location = new System.Drawing.Point(17, 41);
            this.listBoxAssignedDiagnoseGroups.Name = "listBoxAssignedDiagnoseGroups";
            this.listBoxAssignedDiagnoseGroups.Size = new System.Drawing.Size(140, 251);
            this.listBoxAssignedDiagnoseGroups.TabIndex = 33;
            this.listBoxAssignedDiagnoseGroups.DoubleClick += new System.EventHandler(this.listBoxAssignedDiagnoseGroups_DoubleClick);
            // 
            // buttonAssign
            // 
            this.buttonAssign.Location = new System.Drawing.Point(163, 41);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(75, 23);
            this.buttonAssign.TabIndex = 34;
            this.buttonAssign.Text = "<-- Assign";
            this.buttonAssign.UseVisualStyleBackColor = true;
            this.buttonAssign.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // buttonUnassign
            // 
            this.buttonUnassign.Location = new System.Drawing.Point(163, 70);
            this.buttonUnassign.Name = "buttonUnassign";
            this.buttonUnassign.Size = new System.Drawing.Size(75, 23);
            this.buttonUnassign.TabIndex = 35;
            this.buttonUnassign.Text = "--> Unassign";
            this.buttonUnassign.UseVisualStyleBackColor = true;
            this.buttonUnassign.Click += new System.EventHandler(this.buttonUnassign_Click);
            // 
            // labelAssignedDiagnoseGroups
            // 
            this.labelAssignedDiagnoseGroups.AutoSize = true;
            this.labelAssignedDiagnoseGroups.Location = new System.Drawing.Point(14, 21);
            this.labelAssignedDiagnoseGroups.Name = "labelAssignedDiagnoseGroups";
            this.labelAssignedDiagnoseGroups.Size = new System.Drawing.Size(135, 13);
            this.labelAssignedDiagnoseGroups.TabIndex = 36;
            this.labelAssignedDiagnoseGroups.Text = "Assigned Diagnose Groups";
            // 
            // labelAvailableDiagnoseGroups
            // 
            this.labelAvailableDiagnoseGroups.AutoSize = true;
            this.labelAvailableDiagnoseGroups.Location = new System.Drawing.Point(241, 21);
            this.labelAvailableDiagnoseGroups.Name = "labelAvailableDiagnoseGroups";
            this.labelAvailableDiagnoseGroups.Size = new System.Drawing.Size(135, 13);
            this.labelAvailableDiagnoseGroups.TabIndex = 37;
            this.labelAvailableDiagnoseGroups.Text = "Available Diagnose Groups";
            // 
            // listBoxAvailableDiagnoseGroups
            // 
            this.listBoxAvailableDiagnoseGroups.FormattingEnabled = true;
            this.listBoxAvailableDiagnoseGroups.Location = new System.Drawing.Point(244, 37);
            this.listBoxAvailableDiagnoseGroups.Name = "listBoxAvailableDiagnoseGroups";
            this.listBoxAvailableDiagnoseGroups.Size = new System.Drawing.Size(140, 251);
            this.listBoxAvailableDiagnoseGroups.TabIndex = 38;
            this.listBoxAvailableDiagnoseGroups.DoubleClick += new System.EventHandler(this.listBoxAvailableDiagnoseGroups_DoubleClick);
            // 
            // groupBoxDiagnoseGroups
            // 
            this.groupBoxDiagnoseGroups.Controls.Add(this.listBoxAssignedDiagnoseGroups);
            this.groupBoxDiagnoseGroups.Controls.Add(this.listBoxAvailableDiagnoseGroups);
            this.groupBoxDiagnoseGroups.Controls.Add(this.labelAssignedDiagnoseGroups);
            this.groupBoxDiagnoseGroups.Controls.Add(this.labelAvailableDiagnoseGroups);
            this.groupBoxDiagnoseGroups.Controls.Add(this.buttonAssign);
            this.groupBoxDiagnoseGroups.Controls.Add(this.buttonUnassign);
            this.groupBoxDiagnoseGroups.Location = new System.Drawing.Point(349, 178);
            this.groupBoxDiagnoseGroups.Name = "groupBoxDiagnoseGroups";
            this.groupBoxDiagnoseGroups.Size = new System.Drawing.Size(407, 307);
            this.groupBoxDiagnoseGroups.TabIndex = 39;
            this.groupBoxDiagnoseGroups.TabStop = false;
            this.groupBoxDiagnoseGroups.Text = "Diagnose Groups";
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.Location = new System.Drawing.Point(106, 439);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(222, 20);
            this.buttonSaveData.TabIndex = 13;
            this.buttonSaveData.Text = "&Save patient data";
            this.buttonSaveData.UseVisualStyleBackColor = true;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(106, 38);
            this.textBoxFirstName.MaxLength = 255;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(222, 20);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // labelFirstname
            // 
            this.labelFirstname.AutoSize = true;
            this.labelFirstname.Location = new System.Drawing.Point(42, 41);
            this.labelFirstname.Name = "labelFirstname";
            this.labelFirstname.Size = new System.Drawing.Size(58, 13);
            this.labelFirstname.TabIndex = 1;
            this.labelFirstname.Text = "First name:";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(51, 15);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(52, 13);
            this.labelLastName.TabIndex = 5;
            this.labelLastName.Text = "Surname:";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(106, 12);
            this.textBoxSurname.MaxLength = 255;
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(222, 20);
            this.textBoxSurname.TabIndex = 0;
            // 
            // labelBirthDate
            // 
            this.labelBirthDate.AutoSize = true;
            this.labelBirthDate.Location = new System.Drawing.Point(35, 93);
            this.labelBirthDate.Name = "labelBirthDate";
            this.labelBirthDate.Size = new System.Drawing.Size(68, 13);
            this.labelBirthDate.TabIndex = 7;
            this.labelBirthDate.Text = "Date of birth:";
            // 
            // textBoxBirthDay
            // 
            this.textBoxBirthDay.Location = new System.Drawing.Point(219, 90);
            this.textBoxBirthDay.Name = "textBoxBirthDay";
            this.textBoxBirthDay.Size = new System.Drawing.Size(36, 20);
            this.textBoxBirthDay.TabIndex = 5;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(52, 181);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 9;
            this.labelAddress.Text = "Address:";
            // 
            // buttonCalendar
            // 
            this.buttonCalendar.Location = new System.Drawing.Point(261, 90);
            this.buttonCalendar.Name = "buttonCalendar";
            this.buttonCalendar.Size = new System.Drawing.Size(67, 20);
            this.buttonCalendar.TabIndex = 15;
            this.buttonCalendar.Text = "&Calendar";
            this.buttonCalendar.UseVisualStyleBackColor = true;
            this.buttonCalendar.Click += new System.EventHandler(this.buttonCalendar_Click);
            // 
            // buttonClearData
            // 
            this.buttonClearData.Location = new System.Drawing.Point(106, 465);
            this.buttonClearData.Name = "buttonClearData";
            this.buttonClearData.Size = new System.Drawing.Size(222, 20);
            this.buttonClearData.TabIndex = 14;
            this.buttonClearData.Text = "Cancel";
            this.buttonClearData.UseVisualStyleBackColor = true;
            this.buttonClearData.Click += new System.EventHandler(this.buttonClearData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Sex:";
            // 
            // textBoxBirthMonth
            // 
            this.textBoxBirthMonth.Location = new System.Drawing.Point(178, 90);
            this.textBoxBirthMonth.Name = "textBoxBirthMonth";
            this.textBoxBirthMonth.Size = new System.Drawing.Size(35, 20);
            this.textBoxBirthMonth.TabIndex = 4;
            // 
            // textBoxBirthYear
            // 
            this.textBoxBirthYear.Location = new System.Drawing.Point(106, 90);
            this.textBoxBirthYear.Name = "textBoxBirthYear";
            this.textBoxBirthYear.Size = new System.Drawing.Size(66, 20);
            this.textBoxBirthYear.TabIndex = 3;
            // 
            // monthCalendarBirth
            // 
            this.monthCalendarBirth.Location = new System.Drawing.Point(330, 12);
            this.monthCalendarBirth.Name = "monthCalendarBirth";
            this.monthCalendarBirth.TabIndex = 16;
            // 
            // buttonSubmitCalendar
            // 
            this.buttonSubmitCalendar.Location = new System.Drawing.Point(541, 12);
            this.buttonSubmitCalendar.Name = "buttonSubmitCalendar";
            this.buttonSubmitCalendar.Size = new System.Drawing.Size(81, 23);
            this.buttonSubmitCalendar.TabIndex = 17;
            this.buttonSubmitCalendar.Text = "&Commit date";
            this.buttonSubmitCalendar.UseVisualStyleBackColor = true;
            this.buttonSubmitCalendar.Click += new System.EventHandler(this.buttonSubmitCalendar_Click);
            // 
            // buttonNoCalender
            // 
            this.buttonNoCalender.Location = new System.Drawing.Point(541, 41);
            this.buttonNoCalender.Name = "buttonNoCalender";
            this.buttonNoCalender.Size = new System.Drawing.Size(81, 23);
            this.buttonNoCalender.TabIndex = 18;
            this.buttonNoCalender.Text = "&Escape";
            this.buttonNoCalender.UseVisualStyleBackColor = true;
            this.buttonNoCalender.Click += new System.EventHandler(this.buttonNoCalender_Click);
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(59, 155);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(41, 13);
            this.labelPhone.TabIndex = 24;
            this.labelPhone.Text = "Phone:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(106, 152);
            this.textBoxPhone.MaxLength = 255;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(222, 20);
            this.textBoxPhone.TabIndex = 7;
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(35, 67);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(65, 13);
            this.labelAge.TabIndex = 1;
            this.labelAge.Text = "Age (Years):";
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(106, 64);
            this.textBoxAge.MaxLength = 255;
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(222, 20);
            this.textBoxAge.TabIndex = 2;
            this.textBoxAge.Leave += new System.EventHandler(this.textBoxAge_Leave);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Location = new System.Drawing.Point(334, 67);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(298, 13);
            this.labelWarning.TabIndex = 1;
            this.labelWarning.Text = "Warning: Only the Date of birth will be stored in the Database!";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(106, 253);
            this.textBoxWeight.MaxLength = 255;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(222, 20);
            this.textBoxWeight.TabIndex = 10;
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(56, 256);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(44, 13);
            this.labelWeight.TabIndex = 11;
            this.labelWeight.Text = "Weight:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(106, 178);
            this.textBoxAddress.MaxLength = 255;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(222, 20);
            this.textBoxAddress.TabIndex = 8;
            // 
            // listBoxSex
            // 
            this.listBoxSex.FormattingEnabled = true;
            this.listBoxSex.Location = new System.Drawing.Point(106, 116);
            this.listBoxSex.Name = "listBoxSex";
            this.listBoxSex.Size = new System.Drawing.Size(222, 30);
            this.listBoxSex.TabIndex = 6;
            // 
            // listBoxAmbulant
            // 
            this.listBoxAmbulant.FormattingEnabled = true;
            this.listBoxAmbulant.Location = new System.Drawing.Point(106, 279);
            this.listBoxAmbulant.Name = "listBoxAmbulant";
            this.listBoxAmbulant.Size = new System.Drawing.Size(222, 30);
            this.listBoxAmbulant.TabIndex = 11;
            // 
            // labelAmbulant
            // 
            this.labelAmbulant.AutoSize = true;
            this.labelAmbulant.Location = new System.Drawing.Point(46, 279);
            this.labelAmbulant.Name = "labelAmbulant";
            this.labelAmbulant.Size = new System.Drawing.Size(54, 13);
            this.labelAmbulant.TabIndex = 26;
            this.labelAmbulant.Text = "Ambulant:";
            // 
            // labelResidentofAsmara
            // 
            this.labelResidentofAsmara.AutoSize = true;
            this.labelResidentofAsmara.Location = new System.Drawing.Point(-2, 205);
            this.labelResidentofAsmara.Name = "labelResidentofAsmara";
            this.labelResidentofAsmara.Size = new System.Drawing.Size(102, 13);
            this.labelResidentofAsmara.TabIndex = 28;
            this.labelResidentofAsmara.Text = "Resident of Asmara:";
            // 
            // listBoxResidentOfAsmara
            // 
            this.listBoxResidentOfAsmara.FormattingEnabled = true;
            this.listBoxResidentOfAsmara.Location = new System.Drawing.Point(106, 204);
            this.listBoxResidentOfAsmara.Name = "listBoxResidentOfAsmara";
            this.listBoxResidentOfAsmara.Size = new System.Drawing.Size(222, 43);
            this.listBoxResidentOfAsmara.TabIndex = 9;
            // 
            // labelFinished
            // 
            this.labelFinished.AutoSize = true;
            this.labelFinished.Location = new System.Drawing.Point(51, 318);
            this.labelFinished.Name = "labelFinished";
            this.labelFinished.Size = new System.Drawing.Size(49, 13);
            this.labelFinished.TabIndex = 30;
            this.labelFinished.Text = "Finished:";
            // 
            // listBoxFinished
            // 
            this.listBoxFinished.FormattingEnabled = true;
            this.listBoxFinished.Location = new System.Drawing.Point(106, 315);
            this.listBoxFinished.Name = "listBoxFinished";
            this.listBoxFinished.Size = new System.Drawing.Size(222, 43);
            this.listBoxFinished.TabIndex = 12;
            // 
            // listBoxLinz
            // 
            this.listBoxLinz.FormattingEnabled = true;
            this.listBoxLinz.Location = new System.Drawing.Point(106, 364);
            this.listBoxLinz.Name = "listBoxLinz";
            this.listBoxLinz.Size = new System.Drawing.Size(222, 69);
            this.listBoxLinz.TabIndex = 31;
            // 
            // labelLinz
            // 
            this.labelLinz.AutoSize = true;
            this.labelLinz.Location = new System.Drawing.Point(71, 364);
            this.labelLinz.Name = "labelLinz";
            this.labelLinz.Size = new System.Drawing.Size(29, 13);
            this.labelLinz.TabIndex = 32;
            this.labelLinz.Text = "Linz:";
            // 
            // labelLastHighestPiD
            // 
            this.labelLastHighestPiD.AutoSize = true;
            this.labelLastHighestPiD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastHighestPiD.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelLastHighestPiD.Location = new System.Drawing.Point(731, 0);
            this.labelLastHighestPiD.Name = "labelLastHighestPiD";
            this.labelLastHighestPiD.Size = new System.Drawing.Size(102, 13);
            this.labelLastHighestPiD.TabIndex = 40;
            this.labelLastHighestPiD.Text = "labelLastHighestPiD";
            // 
            // labelWaitListDateLabel
            // 
            this.labelWaitListDateLabel.AutoSize = true;
            this.labelWaitListDateLabel.Location = new System.Drawing.Point(346, 152);
            this.labelWaitListDateLabel.Name = "labelWaitListDateLabel";
            this.labelWaitListDateLabel.Size = new System.Drawing.Size(77, 13);
            this.labelWaitListDateLabel.TabIndex = 42;
            this.labelWaitListDateLabel.Text = "Wait List Date:";
            // 
            // labelWaitListDateValue
            // 
            this.labelWaitListDateValue.AutoSize = true;
            this.labelWaitListDateValue.Location = new System.Drawing.Point(435, 152);
            this.labelWaitListDateValue.Name = "labelWaitListDateValue";
            this.labelWaitListDateValue.Size = new System.Drawing.Size(0, 13);
            this.labelWaitListDateValue.TabIndex = 43;
            // 
            // NewPatientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelLastHighestPiD);
            this.Controls.Add(this.groupBoxDiagnoseGroups);
            this.Controls.Add(this.labelLinz);
            this.Controls.Add(this.listBoxLinz);
            this.Controls.Add(this.listBoxFinished);
            this.Controls.Add(this.labelFinished);
            this.Controls.Add(this.listBoxResidentOfAsmara);
            this.Controls.Add(this.labelResidentofAsmara);
            this.Controls.Add(this.labelAmbulant);
            this.Controls.Add(this.listBoxAmbulant);
            this.Controls.Add(this.listBoxSex);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.buttonNoCalender);
            this.Controls.Add(this.buttonSubmitCalendar);
            this.Controls.Add(this.monthCalendarBirth);
            this.Controls.Add(this.textBoxBirthYear);
            this.Controls.Add(this.textBoxBirthMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonClearData);
            this.Controls.Add(this.buttonCalendar);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelBirthDate);
            this.Controls.Add(this.textBoxBirthDay);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelFirstname);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.buttonPrintIdCard);
            this.Controls.Add(this.labelWaitListDateValue);
            this.Controls.Add(this.labelWaitListDateLabel);
            this.Name = "NewPatientControl";
            this.Size = new System.Drawing.Size(812, 507);
            this.Load += new System.EventHandler(this.NewPatientControl_Load);
            this.groupBoxDiagnoseGroups.ResumeLayout(false);
            this.groupBoxDiagnoseGroups.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAssignedDiagnoseGroups;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.Button buttonUnassign;
        private System.Windows.Forms.Label labelAssignedDiagnoseGroups;
        private System.Windows.Forms.Label labelAvailableDiagnoseGroups;
        private System.Windows.Forms.ListBox listBoxAvailableDiagnoseGroups;
        private System.Windows.Forms.GroupBox groupBoxDiagnoseGroups;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelFirstname;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelBirthDate;
        private System.Windows.Forms.TextBox textBoxBirthDay;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Button buttonCalendar;
        private System.Windows.Forms.Button buttonClearData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBirthMonth;
        private System.Windows.Forms.TextBox textBoxBirthYear;
        private System.Windows.Forms.MonthCalendar monthCalendarBirth;
        private System.Windows.Forms.Button buttonSubmitCalendar;
        private System.Windows.Forms.Button buttonNoCalender;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.ListBox listBoxSex;
        private System.Windows.Forms.ListBox listBoxAmbulant;
        private System.Windows.Forms.Label labelAmbulant;
        private System.Windows.Forms.Label labelResidentofAsmara;
        private System.Windows.Forms.ListBox listBoxResidentOfAsmara;
        private System.Windows.Forms.Label labelFinished;
        private System.Windows.Forms.ListBox listBoxFinished;
        private System.Windows.Forms.ListBox listBoxLinz;
        private System.Windows.Forms.Label labelLinz;
        private System.Windows.Forms.Label labelLastHighestPiD;
        private System.Windows.Forms.Button buttonPrintIdCard;
        private System.Windows.Forms.Label labelWaitListDateLabel;
        private System.Windows.Forms.Label labelWaitListDateValue;
    }
}
