namespace SPD.GUI {

    /// <summary>
    /// NextAppointmentForm
    /// </summary>
    partial class NextAppointmentForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPrint1NextAppointment = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxDiagnoses = new System.Windows.Forms.TextBox();
            this.labelDiagnoses = new System.Windows.Forms.Label();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxTodo = new System.Windows.Forms.TextBox();
            this.labelTODO = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBoxPlace = new System.Windows.Forms.TextBox();
            this.labelPlace = new System.Windows.Forms.Label();
            this.buttonPrint2NextAppointment = new System.Windows.Forms.Button();
            this.monthCalendarDate = new System.Windows.Forms.MonthCalendar();
            this.listBoxTimePicker = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(89, 488);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(245, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // buttonPrint1NextAppointment
            // 
            this.buttonPrint1NextAppointment.Location = new System.Drawing.Point(89, 430);
            this.buttonPrint1NextAppointment.Name = "buttonPrint1NextAppointment";
            this.buttonPrint1NextAppointment.Size = new System.Drawing.Size(245, 23);
            this.buttonPrint1NextAppointment.TabIndex = 4;
            this.buttonPrint1NextAppointment.Text = "Print 1 Next Appointment Sheet and Close";
            this.buttonPrint1NextAppointment.UseVisualStyleBackColor = true;
            this.buttonPrint1NextAppointment.Click += new System.EventHandler(this.buttonPrint1NextAppointment_Click);
            this.buttonPrint1NextAppointment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(65, 11);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 2;
            this.labelID.Text = "ID";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(89, 8);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(208, 20);
            this.textBoxId.TabIndex = 3;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(89, 34);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(208, 20);
            this.textBoxName.TabIndex = 5;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(48, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name";
            // 
            // textBoxDiagnoses
            // 
            this.textBoxDiagnoses.Location = new System.Drawing.Point(89, 276);
            this.textBoxDiagnoses.Multiline = true;
            this.textBoxDiagnoses.Name = "textBoxDiagnoses";
            this.textBoxDiagnoses.Size = new System.Drawing.Size(527, 71);
            this.textBoxDiagnoses.TabIndex = 2;
            this.textBoxDiagnoses.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // labelDiagnoses
            // 
            this.labelDiagnoses.AutoSize = true;
            this.labelDiagnoses.Location = new System.Drawing.Point(26, 279);
            this.labelDiagnoses.Name = "labelDiagnoses";
            this.labelDiagnoses.Size = new System.Drawing.Size(57, 13);
            this.labelDiagnoses.TabIndex = 6;
            this.labelDiagnoses.Text = "Diagnoses";
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(89, 60);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(208, 20);
            this.textBoxDate.TabIndex = 0;
            this.textBoxDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(53, 63);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(30, 13);
            this.labelDate.TabIndex = 8;
            this.labelDate.Text = "Date";
            // 
            // textBoxTodo
            // 
            this.textBoxTodo.Location = new System.Drawing.Point(89, 353);
            this.textBoxTodo.Multiline = true;
            this.textBoxTodo.Name = "textBoxTodo";
            this.textBoxTodo.Size = new System.Drawing.Size(527, 71);
            this.textBoxTodo.TabIndex = 3;
            this.textBoxTodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // labelTODO
            // 
            this.labelTODO.AutoSize = true;
            this.labelTODO.Location = new System.Drawing.Point(45, 356);
            this.labelTODO.Name = "labelTODO";
            this.labelTODO.Size = new System.Drawing.Size(38, 13);
            this.labelTODO.TabIndex = 10;
            this.labelTODO.Text = "TODO";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(89, 86);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(208, 20);
            this.textBoxTime.TabIndex = 1;
            this.textBoxTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(53, 89);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 12;
            this.labelTime.Text = "Time";
            // 
            // textBoxPlace
            // 
            this.textBoxPlace.Location = new System.Drawing.Point(89, 112);
            this.textBoxPlace.Name = "textBoxPlace";
            this.textBoxPlace.ReadOnly = true;
            this.textBoxPlace.Size = new System.Drawing.Size(208, 20);
            this.textBoxPlace.TabIndex = 15;
            this.textBoxPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(48, 115);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(34, 13);
            this.labelPlace.TabIndex = 14;
            this.labelPlace.Text = "Place";
            // 
            // buttonPrint2NextAppointment
            // 
            this.buttonPrint2NextAppointment.Location = new System.Drawing.Point(89, 459);
            this.buttonPrint2NextAppointment.Name = "buttonPrint2NextAppointment";
            this.buttonPrint2NextAppointment.Size = new System.Drawing.Size(245, 23);
            this.buttonPrint2NextAppointment.TabIndex = 5;
            this.buttonPrint2NextAppointment.Text = "Print 2 Next Appointment Sheets and Close";
            this.buttonPrint2NextAppointment.UseVisualStyleBackColor = true;
            this.buttonPrint2NextAppointment.Click += new System.EventHandler(this.buttonPrint2NextAppointment_Click);
            this.buttonPrint2NextAppointment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // monthCalendarDate
            // 
            this.monthCalendarDate.Location = new System.Drawing.Point(428, 8);
            this.monthCalendarDate.Name = "monthCalendarDate";
            this.monthCalendarDate.TabIndex = 16;
            this.monthCalendarDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDate_DateSelected);
            this.monthCalendarDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // listBoxTimePicker
            // 
            this.listBoxTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTimePicker.FormattingEnabled = true;
            this.listBoxTimePicker.ItemHeight = 12;
            this.listBoxTimePicker.Location = new System.Drawing.Point(303, 7);
            this.listBoxTimePicker.Name = "listBoxTimePicker";
            this.listBoxTimePicker.Size = new System.Drawing.Size(113, 256);
            this.listBoxTimePicker.TabIndex = 17;
            this.listBoxTimePicker.SelectedIndexChanged += new System.EventHandler(this.listBoxTimePicker_SelectedIndexChanged);
            this.listBoxTimePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            // 
            // NextAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 521);
            this.ControlBox = false;
            this.Controls.Add(this.listBoxTimePicker);
            this.Controls.Add(this.monthCalendarDate);
            this.Controls.Add(this.buttonPrint2NextAppointment);
            this.Controls.Add(this.textBoxPlace);
            this.Controls.Add(this.labelPlace);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.textBoxTodo);
            this.Controls.Add(this.labelTODO);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.textBoxDiagnoses);
            this.Controls.Add(this.labelDiagnoses);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.buttonPrint1NextAppointment);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NextAppointmentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Print Next Appointment";
            this.Load += new System.EventHandler(this.NextAppointmentForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextAppointmentForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPrint1NextAppointment;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxDiagnoses;
        private System.Windows.Forms.Label labelDiagnoses;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxTodo;
        private System.Windows.Forms.Label labelTODO;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox textBoxPlace;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.Button buttonPrint2NextAppointment;
        private System.Windows.Forms.MonthCalendar monthCalendarDate;
        private System.Windows.Forms.ListBox listBoxTimePicker;
    }
}