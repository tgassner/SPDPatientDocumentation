namespace SPD.GUI {
    partial class VisitsControl {
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
            this.listViewVisits = new System.Windows.Forms.ListView();
            this.pictureBoxEasterEgg = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCause = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLocalis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxExtraDiagnosis = new System.Windows.Forms.TextBox();
            this.textBoxProcedure = new System.Windows.Forms.TextBox();
            this.textBoxExtraTherapy = new System.Windows.Forms.TextBox();
            this.textBoxDateYear = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelHeadlineAndPatientData = new System.Windows.Forms.Label();
            this.textBoxDateDay = new System.Windows.Forms.TextBox();
            this.textBoxDateMonth = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPatientNr = new System.Windows.Forms.TextBox();
            this.buttonChange = new System.Windows.Forms.Button();
            this.textBoxUltrasound = new System.Windows.Forms.TextBox();
            this.textBoxBlooddiagnostic = new System.Windows.Forms.TextBox();
            this.textBoxAnesthesiology = new System.Windows.Forms.TextBox();
            this.labelAnesthesiology = new System.Windows.Forms.Label();
            this.labelUltrasound = new System.Windows.Forms.Label();
            this.labelBlooddiagnostic = new System.Windows.Forms.Label();
            this.textBoxTodo = new System.Windows.Forms.TextBox();
            this.labelTodo = new System.Windows.Forms.Label();
            this.textBoxRadiodiagnostics = new System.Windows.Forms.TextBox();
            this.labelRadiodiagnostics = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEasterEgg)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewVisits
            // 
            this.listViewVisits.HideSelection = false;
            this.listViewVisits.Location = new System.Drawing.Point(3, 25);
            this.listViewVisits.Name = "listViewVisits";
            this.listViewVisits.Size = new System.Drawing.Size(980, 199);
            this.listViewVisits.TabIndex = 0;
            this.listViewVisits.UseCompatibleStateImageBehavior = false;
            this.listViewVisits.SelectedIndexChanged += new System.EventHandler(this.listViewVisits_SelectedIndexChanged);
            // 
            // pictureBoxEasterEgg
            // 
            this.pictureBoxEasterEgg.Image = global::SPD.GUI.Properties.Resources._313;
            this.pictureBoxEasterEgg.InitialImage = null;
            this.pictureBoxEasterEgg.Location = new System.Drawing.Point(269, 282);
            this.pictureBoxEasterEgg.Name = "pictureBoxEasterEgg";
            this.pictureBoxEasterEgg.Size = new System.Drawing.Size(179, 174);
            this.pictureBoxEasterEgg.TabIndex = 1;
            this.pictureBoxEasterEgg.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Cause:";
            // 
            // textBoxCause
            // 
            this.textBoxCause.Location = new System.Drawing.Point(62, 231);
            this.textBoxCause.MaxLength = 255;
            this.textBoxCause.Multiline = true;
            this.textBoxCause.Name = "textBoxCause";
            this.textBoxCause.ReadOnly = true;
            this.textBoxCause.Size = new System.Drawing.Size(255, 64);
            this.textBoxCause.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Localis:";
            // 
            // textBoxLocalis
            // 
            this.textBoxLocalis.Location = new System.Drawing.Point(419, 362);
            this.textBoxLocalis.MaxLength = 255;
            this.textBoxLocalis.Multiline = true;
            this.textBoxLocalis.Name = "textBoxLocalis";
            this.textBoxLocalis.ReadOnly = true;
            this.textBoxLocalis.Size = new System.Drawing.Size(246, 81);
            this.textBoxLocalis.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Diagnosis:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "procedure:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Therapy:";
            // 
            // textBoxExtraDiagnosis
            // 
            this.textBoxExtraDiagnosis.Location = new System.Drawing.Point(62, 305);
            this.textBoxExtraDiagnosis.MaxLength = 255;
            this.textBoxExtraDiagnosis.Multiline = true;
            this.textBoxExtraDiagnosis.Name = "textBoxExtraDiagnosis";
            this.textBoxExtraDiagnosis.ReadOnly = true;
            this.textBoxExtraDiagnosis.Size = new System.Drawing.Size(255, 62);
            this.textBoxExtraDiagnosis.TabIndex = 2;
            // 
            // textBoxProcedure
            // 
            this.textBoxProcedure.Location = new System.Drawing.Point(744, 230);
            this.textBoxProcedure.MaxLength = 255;
            this.textBoxProcedure.Multiline = true;
            this.textBoxProcedure.Name = "textBoxProcedure";
            this.textBoxProcedure.ReadOnly = true;
            this.textBoxProcedure.Size = new System.Drawing.Size(239, 105);
            this.textBoxProcedure.TabIndex = 13;
            // 
            // textBoxExtraTherapy
            // 
            this.textBoxExtraTherapy.Location = new System.Drawing.Point(62, 376);
            this.textBoxExtraTherapy.MaxLength = 255;
            this.textBoxExtraTherapy.Multiline = true;
            this.textBoxExtraTherapy.Name = "textBoxExtraTherapy";
            this.textBoxExtraTherapy.ReadOnly = true;
            this.textBoxExtraTherapy.Size = new System.Drawing.Size(255, 66);
            this.textBoxExtraTherapy.TabIndex = 3;
            // 
            // textBoxDateYear
            // 
            this.textBoxDateYear.Location = new System.Drawing.Point(420, 336);
            this.textBoxDateYear.Name = "textBoxDateYear";
            this.textBoxDateYear.ReadOnly = true;
            this.textBoxDateYear.Size = new System.Drawing.Size(62, 20);
            this.textBoxDateYear.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Date:";
            // 
            // labelHeadlineAndPatientData
            // 
            this.labelHeadlineAndPatientData.AutoSize = true;
            this.labelHeadlineAndPatientData.Location = new System.Drawing.Point(6, 9);
            this.labelHeadlineAndPatientData.Name = "labelHeadlineAndPatientData";
            this.labelHeadlineAndPatientData.Size = new System.Drawing.Size(34, 13);
            this.labelHeadlineAndPatientData.TabIndex = 14;
            this.labelHeadlineAndPatientData.Text = "Visits:";
            // 
            // textBoxDateDay
            // 
            this.textBoxDateDay.Location = new System.Drawing.Point(530, 336);
            this.textBoxDateDay.Name = "textBoxDateDay";
            this.textBoxDateDay.ReadOnly = true;
            this.textBoxDateDay.Size = new System.Drawing.Size(36, 20);
            this.textBoxDateDay.TabIndex = 10;
            // 
            // textBoxDateMonth
            // 
            this.textBoxDateMonth.Location = new System.Drawing.Point(488, 336);
            this.textBoxDateMonth.Name = "textBoxDateMonth";
            this.textBoxDateMonth.ReadOnly = true;
            this.textBoxDateMonth.Size = new System.Drawing.Size(36, 20);
            this.textBoxDateMonth.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(572, 339);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Pat Nr:";
            // 
            // textBoxPatientNr
            // 
            this.textBoxPatientNr.Location = new System.Drawing.Point(618, 336);
            this.textBoxPatientNr.Name = "textBoxPatientNr";
            this.textBoxPatientNr.ReadOnly = true;
            this.textBoxPatientNr.Size = new System.Drawing.Size(47, 20);
            this.textBoxPatientNr.TabIndex = 11;
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(3, 446);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(980, 28);
            this.buttonChange.TabIndex = 15;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // textBoxUltrasound
            // 
            this.textBoxUltrasound.Location = new System.Drawing.Point(744, 339);
            this.textBoxUltrasound.Multiline = true;
            this.textBoxUltrasound.Name = "textBoxUltrasound";
            this.textBoxUltrasound.ReadOnly = true;
            this.textBoxUltrasound.Size = new System.Drawing.Size(239, 103);
            this.textBoxUltrasound.TabIndex = 14;
            // 
            // textBoxBlooddiagnostic
            // 
            this.textBoxBlooddiagnostic.Location = new System.Drawing.Point(419, 256);
            this.textBoxBlooddiagnostic.Name = "textBoxBlooddiagnostic";
            this.textBoxBlooddiagnostic.ReadOnly = true;
            this.textBoxBlooddiagnostic.Size = new System.Drawing.Size(246, 20);
            this.textBoxBlooddiagnostic.TabIndex = 5;
            // 
            // textBoxAnesthesiology
            // 
            this.textBoxAnesthesiology.Location = new System.Drawing.Point(419, 230);
            this.textBoxAnesthesiology.Name = "textBoxAnesthesiology";
            this.textBoxAnesthesiology.ReadOnly = true;
            this.textBoxAnesthesiology.Size = new System.Drawing.Size(246, 20);
            this.textBoxAnesthesiology.TabIndex = 4;
            // 
            // labelAnesthesiology
            // 
            this.labelAnesthesiology.AutoSize = true;
            this.labelAnesthesiology.Location = new System.Drawing.Point(332, 233);
            this.labelAnesthesiology.Name = "labelAnesthesiology";
            this.labelAnesthesiology.Size = new System.Drawing.Size(81, 13);
            this.labelAnesthesiology.TabIndex = 20;
            this.labelAnesthesiology.Text = "Anesthesiology:";
            // 
            // labelUltrasound
            // 
            this.labelUltrasound.AutoSize = true;
            this.labelUltrasound.Location = new System.Drawing.Point(677, 341);
            this.labelUltrasound.Name = "labelUltrasound";
            this.labelUltrasound.Size = new System.Drawing.Size(61, 13);
            this.labelUltrasound.TabIndex = 21;
            this.labelUltrasound.Text = "Ultrasound:";
            // 
            // labelBlooddiagnostic
            // 
            this.labelBlooddiagnostic.AutoSize = true;
            this.labelBlooddiagnostic.Location = new System.Drawing.Point(328, 259);
            this.labelBlooddiagnostic.Name = "labelBlooddiagnostic";
            this.labelBlooddiagnostic.Size = new System.Drawing.Size(85, 13);
            this.labelBlooddiagnostic.TabIndex = 22;
            this.labelBlooddiagnostic.Text = "Blooddiagnostic:";
            // 
            // textBoxTodo
            // 
            this.textBoxTodo.Location = new System.Drawing.Point(419, 308);
            this.textBoxTodo.Name = "textBoxTodo";
            this.textBoxTodo.ReadOnly = true;
            this.textBoxTodo.Size = new System.Drawing.Size(246, 20);
            this.textBoxTodo.TabIndex = 7;
            // 
            // labelTodo
            // 
            this.labelTodo.AutoSize = true;
            this.labelTodo.Location = new System.Drawing.Point(378, 311);
            this.labelTodo.Name = "labelTodo";
            this.labelTodo.Size = new System.Drawing.Size(35, 13);
            this.labelTodo.TabIndex = 22;
            this.labelTodo.Text = "Todo:";
            // 
            // textBoxRadiodiagnostics
            // 
            this.textBoxRadiodiagnostics.Location = new System.Drawing.Point(419, 282);
            this.textBoxRadiodiagnostics.Name = "textBoxRadiodiagnostics";
            this.textBoxRadiodiagnostics.ReadOnly = true;
            this.textBoxRadiodiagnostics.Size = new System.Drawing.Size(246, 20);
            this.textBoxRadiodiagnostics.TabIndex = 6;
            // 
            // labelRadiodiagnostics
            // 
            this.labelRadiodiagnostics.AutoSize = true;
            this.labelRadiodiagnostics.Location = new System.Drawing.Point(322, 285);
            this.labelRadiodiagnostics.Name = "labelRadiodiagnostics";
            this.labelRadiodiagnostics.Size = new System.Drawing.Size(91, 13);
            this.labelRadiodiagnostics.TabIndex = 22;
            this.labelRadiodiagnostics.Text = "Radiodiagnostics:";
            // 
            // VisitsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelRadiodiagnostics);
            this.Controls.Add(this.labelTodo);
            this.Controls.Add(this.labelBlooddiagnostic);
            this.Controls.Add(this.labelUltrasound);
            this.Controls.Add(this.labelAnesthesiology);
            this.Controls.Add(this.textBoxAnesthesiology);
            this.Controls.Add(this.textBoxRadiodiagnostics);
            this.Controls.Add(this.textBoxTodo);
            this.Controls.Add(this.textBoxBlooddiagnostic);
            this.Controls.Add(this.textBoxUltrasound);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxPatientNr);
            this.Controls.Add(this.textBoxDateMonth);
            this.Controls.Add(this.textBoxDateDay);
            this.Controls.Add(this.labelHeadlineAndPatientData);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxProcedure);
            this.Controls.Add(this.textBoxExtraTherapy);
            this.Controls.Add(this.textBoxExtraDiagnosis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLocalis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDateYear);
            this.Controls.Add(this.textBoxCause);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewVisits);
            this.Controls.Add(this.pictureBoxEasterEgg);
            this.Name = "VisitsControl";
            this.Size = new System.Drawing.Size(998, 476);
            this.Load += new System.EventHandler(this.VisitsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEasterEgg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewVisits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCause;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLocalis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxExtraDiagnosis;
        private System.Windows.Forms.TextBox textBoxProcedure;
        private System.Windows.Forms.TextBox textBoxExtraTherapy;
        private System.Windows.Forms.TextBox textBoxDateYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelHeadlineAndPatientData;
        private System.Windows.Forms.TextBox textBoxDateDay;
        private System.Windows.Forms.TextBox textBoxDateMonth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPatientNr;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.TextBox textBoxUltrasound;
        private System.Windows.Forms.TextBox textBoxBlooddiagnostic;
        private System.Windows.Forms.TextBox textBoxAnesthesiology;
        private System.Windows.Forms.Label labelAnesthesiology;
        private System.Windows.Forms.Label labelUltrasound;
        private System.Windows.Forms.Label labelBlooddiagnostic;
        private System.Windows.Forms.TextBox textBoxTodo;
        private System.Windows.Forms.Label labelTodo;
        private System.Windows.Forms.TextBox textBoxRadiodiagnostics;
        private System.Windows.Forms.Label labelRadiodiagnostics;
        private System.Windows.Forms.PictureBox pictureBoxEasterEgg;
    }
}
