namespace SPD.GUI
{
    /// <summary>
    /// 
    /// </summary>
    partial class OPControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPatient = new System.Windows.Forms.Label();
            this.labelPatientData = new System.Windows.Forms.Label();
            this.labelOPDate = new System.Windows.Forms.Label();
            this.labelOPTeam = new System.Windows.Forms.Label();
            this.labelOPProcess = new System.Windows.Forms.Label();
            this.textBoxOPDate = new System.Windows.Forms.TextBox();
            this.textBoxOPTeam = new System.Windows.Forms.TextBox();
            this.textBoxOPProcess = new System.Windows.Forms.TextBox();
            this.textBoxOPDiagnoses = new System.Windows.Forms.TextBox();
            this.labelOPDiagnoses = new System.Windows.Forms.Label();
            this.labelPerformedOP = new System.Windows.Forms.Label();
            this.textBoxPerformedOP = new System.Windows.Forms.TextBox();
            this.labelOperationHeadline = new System.Windows.Forms.Label();
            this.buttonSaveOperation = new System.Windows.Forms.Button();
            this.buttonClearData = new System.Windows.Forms.Button();
            this.buttonToday = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAdditionalInformation = new System.Windows.Forms.TextBox();
            this.textBoxMedication = new System.Windows.Forms.TextBox();
            this.labelIntDiagnoses = new System.Windows.Forms.Label();
            this.textBoxIntdiagnoses = new System.Windows.Forms.TextBox();
            this.comboBoxPPPS = new System.Windows.Forms.ComboBox();
            this.comboBoxResult = new System.Windows.Forms.ComboBox();
            this.labelPPPS = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxKathDays = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxOrgan = new System.Windows.Forms.ComboBox();
            this.buttonSaveAndPrint = new System.Windows.Forms.Button();
            this.listBoxDays = new System.Windows.Forms.ListBox();
            this.labelDays = new System.Windows.Forms.Label();
            this.labelSheets = new System.Windows.Forms.Label();
            this.listBoxCopys = new System.Windows.Forms.ListBox();
            this.labelOpResult = new System.Windows.Forms.Label();
            this.textBoxOpResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelPatient
            // 
            this.labelPatient.AutoSize = true;
            this.labelPatient.Location = new System.Drawing.Point(183, 14);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(43, 13);
            this.labelPatient.TabIndex = 0;
            this.labelPatient.Text = "Patient:";
            // 
            // labelPatientData
            // 
            this.labelPatientData.AutoSize = true;
            this.labelPatientData.Location = new System.Drawing.Point(229, 14);
            this.labelPatientData.Name = "labelPatientData";
            this.labelPatientData.Size = new System.Drawing.Size(40, 13);
            this.labelPatientData.TabIndex = 0;
            this.labelPatientData.Text = "Patient";
            // 
            // labelOPDate
            // 
            this.labelOPDate.AutoSize = true;
            this.labelOPDate.Location = new System.Drawing.Point(36, 32);
            this.labelOPDate.Name = "labelOPDate";
            this.labelOPDate.Size = new System.Drawing.Size(51, 13);
            this.labelOPDate.TabIndex = 0;
            this.labelOPDate.Text = "OP Date:";
            // 
            // labelOPTeam
            // 
            this.labelOPTeam.AutoSize = true;
            this.labelOPTeam.Location = new System.Drawing.Point(32, 52);
            this.labelOPTeam.Name = "labelOPTeam";
            this.labelOPTeam.Size = new System.Drawing.Size(55, 13);
            this.labelOPTeam.TabIndex = 0;
            this.labelOPTeam.Text = "OP Team:";
            // 
            // labelOPProcess
            // 
            this.labelOPProcess.AutoSize = true;
            this.labelOPProcess.Location = new System.Drawing.Point(21, 80);
            this.labelOPProcess.Name = "labelOPProcess";
            this.labelOPProcess.Size = new System.Drawing.Size(66, 13);
            this.labelOPProcess.TabIndex = 0;
            this.labelOPProcess.Text = "OP Process:";
            // 
            // textBoxOPDate
            // 
            this.textBoxOPDate.Location = new System.Drawing.Point(93, 29);
            this.textBoxOPDate.MaxLength = 255;
            this.textBoxOPDate.Name = "textBoxOPDate";
            this.textBoxOPDate.Size = new System.Drawing.Size(224, 20);
            this.textBoxOPDate.TabIndex = 0;
            // 
            // textBoxOPTeam
            // 
            this.textBoxOPTeam.Location = new System.Drawing.Point(93, 49);
            this.textBoxOPTeam.MaxLength = 255;
            this.textBoxOPTeam.Multiline = true;
            this.textBoxOPTeam.Name = "textBoxOPTeam";
            this.textBoxOPTeam.Size = new System.Drawing.Size(883, 28);
            this.textBoxOPTeam.TabIndex = 2;
            // 
            // textBoxOPProcess
            // 
            this.textBoxOPProcess.Location = new System.Drawing.Point(93, 77);
            this.textBoxOPProcess.Multiline = true;
            this.textBoxOPProcess.Name = "textBoxOPProcess";
            this.textBoxOPProcess.Size = new System.Drawing.Size(883, 50);
            this.textBoxOPProcess.TabIndex = 3;
            // 
            // textBoxOPDiagnoses
            // 
            this.textBoxOPDiagnoses.Location = new System.Drawing.Point(93, 126);
            this.textBoxOPDiagnoses.MaxLength = 255;
            this.textBoxOPDiagnoses.Multiline = true;
            this.textBoxOPDiagnoses.Name = "textBoxOPDiagnoses";
            this.textBoxOPDiagnoses.Size = new System.Drawing.Size(883, 34);
            this.textBoxOPDiagnoses.TabIndex = 4;
            // 
            // labelOPDiagnoses
            // 
            this.labelOPDiagnoses.AutoSize = true;
            this.labelOPDiagnoses.Location = new System.Drawing.Point(13, 129);
            this.labelOPDiagnoses.Name = "labelOPDiagnoses";
            this.labelOPDiagnoses.Size = new System.Drawing.Size(74, 13);
            this.labelOPDiagnoses.TabIndex = 0;
            this.labelOPDiagnoses.Text = "OP Diagnosis:";
            // 
            // labelPerformedOP
            // 
            this.labelPerformedOP.AutoSize = true;
            this.labelPerformedOP.Location = new System.Drawing.Point(11, 163);
            this.labelPerformedOP.Name = "labelPerformedOP";
            this.labelPerformedOP.Size = new System.Drawing.Size(76, 13);
            this.labelPerformedOP.TabIndex = 0;
            this.labelPerformedOP.Text = "Performed OP:";
            // 
            // textBoxPerformedOP
            // 
            this.textBoxPerformedOP.Location = new System.Drawing.Point(93, 160);
            this.textBoxPerformedOP.MaxLength = 255;
            this.textBoxPerformedOP.Multiline = true;
            this.textBoxPerformedOP.Name = "textBoxPerformedOP";
            this.textBoxPerformedOP.Size = new System.Drawing.Size(372, 40);
            this.textBoxPerformedOP.TabIndex = 5;
            // 
            // labelOperationHeadline
            // 
            this.labelOperationHeadline.AutoSize = true;
            this.labelOperationHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperationHeadline.Location = new System.Drawing.Point(89, 9);
            this.labelOperationHeadline.Name = "labelOperationHeadline";
            this.labelOperationHeadline.Size = new System.Drawing.Size(88, 20);
            this.labelOperationHeadline.TabIndex = 2;
            this.labelOperationHeadline.Text = "Operation";
            // 
            // buttonSaveOperation
            // 
            this.buttonSaveOperation.Location = new System.Drawing.Point(73, 281);
            this.buttonSaveOperation.Name = "buttonSaveOperation";
            this.buttonSaveOperation.Size = new System.Drawing.Size(98, 23);
            this.buttonSaveOperation.TabIndex = 12;
            this.buttonSaveOperation.Text = "Save and Close";
            this.buttonSaveOperation.UseVisualStyleBackColor = true;
            this.buttonSaveOperation.Click += new System.EventHandler(this.buttonSaveOperation_Click);
            // 
            // buttonClearData
            // 
            this.buttonClearData.Location = new System.Drawing.Point(177, 281);
            this.buttonClearData.Name = "buttonClearData";
            this.buttonClearData.Size = new System.Drawing.Size(70, 23);
            this.buttonClearData.TabIndex = 16;
            this.buttonClearData.Text = "Clear Data";
            this.buttonClearData.UseVisualStyleBackColor = true;
            this.buttonClearData.Click += new System.EventHandler(this.buttonClearData_Click);
            // 
            // buttonToday
            // 
            this.buttonToday.Location = new System.Drawing.Point(323, 28);
            this.buttonToday.Name = "buttonToday";
            this.buttonToday.Size = new System.Drawing.Size(76, 21);
            this.buttonToday.TabIndex = 1;
            this.buttonToday.Text = "today";
            this.buttonToday.UseVisualStyleBackColor = true;
            this.buttonToday.Click += new System.EventHandler(this.buttonToday_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Add. Information:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Medication:";
            // 
            // textBoxAdditionalInformation
            // 
            this.textBoxAdditionalInformation.Location = new System.Drawing.Point(93, 199);
            this.textBoxAdditionalInformation.Multiline = true;
            this.textBoxAdditionalInformation.Name = "textBoxAdditionalInformation";
            this.textBoxAdditionalInformation.Size = new System.Drawing.Size(372, 50);
            this.textBoxAdditionalInformation.TabIndex = 6;
            // 
            // textBoxMedication
            // 
            this.textBoxMedication.Location = new System.Drawing.Point(542, 160);
            this.textBoxMedication.Multiline = true;
            this.textBoxMedication.Name = "textBoxMedication";
            this.textBoxMedication.Size = new System.Drawing.Size(434, 40);
            this.textBoxMedication.TabIndex = 7;
            // 
            // labelIntDiagnoses
            // 
            this.labelIntDiagnoses.AutoSize = true;
            this.labelIntDiagnoses.Location = new System.Drawing.Point(357, 258);
            this.labelIntDiagnoses.Name = "labelIntDiagnoses";
            this.labelIntDiagnoses.Size = new System.Drawing.Size(70, 13);
            this.labelIntDiagnoses.TabIndex = 9;
            this.labelIntDiagnoses.Text = "Intdiagnoses:";
            // 
            // textBoxIntdiagnoses
            // 
            this.textBoxIntdiagnoses.Location = new System.Drawing.Point(433, 256);
            this.textBoxIntdiagnoses.Name = "textBoxIntdiagnoses";
            this.textBoxIntdiagnoses.Size = new System.Drawing.Size(70, 20);
            this.textBoxIntdiagnoses.TabIndex = 9;
            // 
            // comboBoxPPPS
            // 
            this.comboBoxPPPS.FormattingEnabled = true;
            this.comboBoxPPPS.Location = new System.Drawing.Point(577, 255);
            this.comboBoxPPPS.Name = "comboBoxPPPS";
            this.comboBoxPPPS.Size = new System.Drawing.Size(91, 21);
            this.comboBoxPPPS.TabIndex = 10;
            // 
            // comboBoxResult
            // 
            this.comboBoxResult.FormattingEnabled = true;
            this.comboBoxResult.Location = new System.Drawing.Point(711, 255);
            this.comboBoxResult.Name = "comboBoxResult";
            this.comboBoxResult.Size = new System.Drawing.Size(106, 21);
            this.comboBoxResult.TabIndex = 11;
            // 
            // labelPPPS
            // 
            this.labelPPPS.AutoSize = true;
            this.labelPPPS.Location = new System.Drawing.Point(518, 258);
            this.labelPPPS.Name = "labelPPPS";
            this.labelPPPS.Size = new System.Drawing.Size(53, 13);
            this.labelPPPS.TabIndex = 14;
            this.labelPPPS.Text = "PP or PS:";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(671, 258);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(40, 13);
            this.labelResult.TabIndex = 15;
            this.labelResult.Text = "Result:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Kath Days:";
            // 
            // comboBoxKathDays
            // 
            this.comboBoxKathDays.FormattingEnabled = true;
            this.comboBoxKathDays.Location = new System.Drawing.Point(93, 255);
            this.comboBoxKathDays.Name = "comboBoxKathDays";
            this.comboBoxKathDays.Size = new System.Drawing.Size(80, 21);
            this.comboBoxKathDays.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Organ:";
            // 
            // comboBoxOrgan
            // 
            this.comboBoxOrgan.FormattingEnabled = true;
            this.comboBoxOrgan.Location = new System.Drawing.Point(219, 255);
            this.comboBoxOrgan.Name = "comboBoxOrgan";
            this.comboBoxOrgan.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOrgan.TabIndex = 24;
            // 
            // buttonSaveAndPrint
            // 
            this.buttonSaveAndPrint.Location = new System.Drawing.Point(254, 281);
            this.buttonSaveAndPrint.Name = "buttonSaveAndPrint";
            this.buttonSaveAndPrint.Size = new System.Drawing.Size(183, 23);
            this.buttonSaveAndPrint.TabIndex = 25;
            this.buttonSaveAndPrint.Text = "Save and Print Temperatur Curve";
            this.buttonSaveAndPrint.UseVisualStyleBackColor = true;
            this.buttonSaveAndPrint.Click += new System.EventHandler(this.buttonSaveAndPrint_Click_1);
            // 
            // listBoxDays
            // 
            this.listBoxDays.FormattingEnabled = true;
            this.listBoxDays.Location = new System.Drawing.Point(483, 281);
            this.listBoxDays.Name = "listBoxDays";
            this.listBoxDays.Size = new System.Drawing.Size(49, 30);
            this.listBoxDays.TabIndex = 26;
            // 
            // labelDays
            // 
            this.labelDays.AutoSize = true;
            this.labelDays.Location = new System.Drawing.Point(443, 286);
            this.labelDays.Name = "labelDays";
            this.labelDays.Size = new System.Drawing.Size(34, 13);
            this.labelDays.TabIndex = 27;
            this.labelDays.Text = "Days:";
            // 
            // labelSheets
            // 
            this.labelSheets.AutoSize = true;
            this.labelSheets.Location = new System.Drawing.Point(553, 286);
            this.labelSheets.Name = "labelSheets";
            this.labelSheets.Size = new System.Drawing.Size(34, 13);
            this.labelSheets.TabIndex = 28;
            this.labelSheets.Text = "Copy:";
            // 
            // listBoxCopys
            // 
            this.listBoxCopys.FormattingEnabled = true;
            this.listBoxCopys.Location = new System.Drawing.Point(593, 281);
            this.listBoxCopys.Name = "listBoxCopys";
            this.listBoxCopys.Size = new System.Drawing.Size(40, 30);
            this.listBoxCopys.TabIndex = 29;
            // 
            // labelOpResult
            // 
            this.labelOpResult.AutoSize = true;
            this.labelOpResult.Location = new System.Drawing.Point(480, 205);
            this.labelOpResult.Name = "labelOpResult";
            this.labelOpResult.Size = new System.Drawing.Size(58, 13);
            this.labelOpResult.TabIndex = 30;
            this.labelOpResult.Text = "OP Result:";
            // 
            // textBoxOpResult
            // 
            this.textBoxOpResult.Location = new System.Drawing.Point(542, 202);
            this.textBoxOpResult.Multiline = true;
            this.textBoxOpResult.Name = "textBoxOpResult";
            this.textBoxOpResult.Size = new System.Drawing.Size(434, 47);
            this.textBoxOpResult.TabIndex = 31;
            // 
            // OPControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxOpResult);
            this.Controls.Add(this.labelOpResult);
            this.Controls.Add(this.listBoxCopys);
            this.Controls.Add(this.labelSheets);
            this.Controls.Add(this.labelDays);
            this.Controls.Add(this.listBoxDays);
            this.Controls.Add(this.buttonSaveAndPrint);
            this.Controls.Add(this.comboBoxOrgan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxKathDays);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelPPPS);
            this.Controls.Add(this.comboBoxResult);
            this.Controls.Add(this.comboBoxPPPS);
            this.Controls.Add(this.textBoxIntdiagnoses);
            this.Controls.Add(this.textBoxMedication);
            this.Controls.Add(this.textBoxAdditionalInformation);
            this.Controls.Add(this.labelIntDiagnoses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonToday);
            this.Controls.Add(this.buttonClearData);
            this.Controls.Add(this.buttonSaveOperation);
            this.Controls.Add(this.labelOperationHeadline);
            this.Controls.Add(this.textBoxPerformedOP);
            this.Controls.Add(this.textBoxOPDiagnoses);
            this.Controls.Add(this.textBoxOPTeam);
            this.Controls.Add(this.textBoxOPProcess);
            this.Controls.Add(this.labelPerformedOP);
            this.Controls.Add(this.textBoxOPDate);
            this.Controls.Add(this.labelOPDiagnoses);
            this.Controls.Add(this.labelOPProcess);
            this.Controls.Add(this.labelOPTeam);
            this.Controls.Add(this.labelOPDate);
            this.Controls.Add(this.labelPatientData);
            this.Controls.Add(this.labelPatient);
            this.Name = "OPControl";
            this.Size = new System.Drawing.Size(985, 319);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPatient;
        private System.Windows.Forms.Label labelPatientData;
        private System.Windows.Forms.Label labelOPDate;
        private System.Windows.Forms.Label labelOPTeam;
        private System.Windows.Forms.Label labelOPProcess;
        private System.Windows.Forms.TextBox textBoxOPDate;
        private System.Windows.Forms.TextBox textBoxOPTeam;
        private System.Windows.Forms.TextBox textBoxOPProcess;
        private System.Windows.Forms.TextBox textBoxOPDiagnoses;
        private System.Windows.Forms.Label labelOPDiagnoses;
        private System.Windows.Forms.Label labelPerformedOP;
        private System.Windows.Forms.TextBox textBoxPerformedOP;
        private System.Windows.Forms.Label labelOperationHeadline;
        private System.Windows.Forms.Button buttonSaveOperation;
        private System.Windows.Forms.Button buttonClearData;
        private System.Windows.Forms.Button buttonToday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAdditionalInformation;
        private System.Windows.Forms.TextBox textBoxMedication;
        private System.Windows.Forms.Label labelIntDiagnoses;
        private System.Windows.Forms.TextBox textBoxIntdiagnoses;
        private System.Windows.Forms.ComboBox comboBoxPPPS;
        private System.Windows.Forms.ComboBox comboBoxResult;
        private System.Windows.Forms.Label labelPPPS;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxKathDays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxOrgan;
        private System.Windows.Forms.Button buttonSaveAndPrint;
        private System.Windows.Forms.ListBox listBoxDays;
        private System.Windows.Forms.Label labelDays;
        private System.Windows.Forms.Label labelSheets;
        private System.Windows.Forms.ListBox listBoxCopys;
        private System.Windows.Forms.Label labelOpResult;
        private System.Windows.Forms.TextBox textBoxOpResult;
    }
}
