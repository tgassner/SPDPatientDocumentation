namespace SPD.GUI {
    partial class NextActionControl {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPatient = new System.Windows.Forms.Label();
            this.buttonAddActiontoPatient = new System.Windows.Forms.Button();
            this.listBoxYear = new System.Windows.Forms.ListBox();
            this.listBoxHalfYear = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxAction = new System.Windows.Forms.ListBox();
            this.listBoxStoredActions = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDeleteActionfromPatient = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxToDo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NextAction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Patient: ";
            // 
            // labelPatient
            // 
            this.labelPatient.AutoSize = true;
            this.labelPatient.Location = new System.Drawing.Point(119, 9);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(35, 13);
            this.labelPatient.TabIndex = 0;
            this.labelPatient.Text = "label1";
            // 
            // buttonAddActiontoPatient
            // 
            this.buttonAddActiontoPatient.Location = new System.Drawing.Point(67, 319);
            this.buttonAddActiontoPatient.Name = "buttonAddActiontoPatient";
            this.buttonAddActiontoPatient.Size = new System.Drawing.Size(139, 23);
            this.buttonAddActiontoPatient.TabIndex = 4;
            this.buttonAddActiontoPatient.Text = "Add Action to Patient";
            this.buttonAddActiontoPatient.UseVisualStyleBackColor = true;
            this.buttonAddActiontoPatient.Click += new System.EventHandler(this.buttonAddActiontoPatient_Click);
            // 
            // listBoxYear
            // 
            this.listBoxYear.FormattingEnabled = true;
            this.listBoxYear.Location = new System.Drawing.Point(67, 25);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.Size = new System.Drawing.Size(142, 160);
            this.listBoxYear.TabIndex = 0;
            // 
            // listBoxHalfYear
            // 
            this.listBoxHalfYear.FormattingEnabled = true;
            this.listBoxHalfYear.Location = new System.Drawing.Point(67, 191);
            this.listBoxHalfYear.Name = "listBoxHalfYear";
            this.listBoxHalfYear.Size = new System.Drawing.Size(142, 30);
            this.listBoxHalfYear.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Year: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Halfyear: ";
            // 
            // listBoxAction
            // 
            this.listBoxAction.FormattingEnabled = true;
            this.listBoxAction.Location = new System.Drawing.Point(67, 227);
            this.listBoxAction.Name = "listBoxAction";
            this.listBoxAction.Size = new System.Drawing.Size(142, 30);
            this.listBoxAction.TabIndex = 2;
            // 
            // listBoxStoredActions
            // 
            this.listBoxStoredActions.FormattingEnabled = true;
            this.listBoxStoredActions.Location = new System.Drawing.Point(243, 25);
            this.listBoxStoredActions.Name = "listBoxStoredActions";
            this.listBoxStoredActions.Size = new System.Drawing.Size(142, 199);
            this.listBoxStoredActions.TabIndex = 5;
            this.listBoxStoredActions.SelectedIndexChanged += new System.EventHandler(this.listBoxStoredActions_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Action: ";
            // 
            // buttonDeleteActionfromPatient
            // 
            this.buttonDeleteActionfromPatient.Location = new System.Drawing.Point(243, 234);
            this.buttonDeleteActionfromPatient.Name = "buttonDeleteActionfromPatient";
            this.buttonDeleteActionfromPatient.Size = new System.Drawing.Size(142, 23);
            this.buttonDeleteActionfromPatient.TabIndex = 6;
            this.buttonDeleteActionfromPatient.Text = "Delete Action from Patient";
            this.buttonDeleteActionfromPatient.UseVisualStyleBackColor = true;
            this.buttonDeleteActionfromPatient.Click += new System.EventHandler(this.buttonDeleteActionfromPatient_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "ToDo:";
            // 
            // textBoxToDo
            // 
            this.textBoxToDo.Location = new System.Drawing.Point(67, 264);
            this.textBoxToDo.Multiline = true;
            this.textBoxToDo.Name = "textBoxToDo";
            this.textBoxToDo.Size = new System.Drawing.Size(318, 49);
            this.textBoxToDo.TabIndex = 3;
            // 
            // NextActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxToDo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonDeleteActionfromPatient);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxStoredActions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxAction);
            this.Controls.Add(this.listBoxHalfYear);
            this.Controls.Add(this.listBoxYear);
            this.Controls.Add(this.buttonAddActiontoPatient);
            this.Controls.Add(this.labelPatient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NextActionControl";
            this.Size = new System.Drawing.Size(493, 396);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPatient;
        private System.Windows.Forms.Button buttonAddActiontoPatient;
        private System.Windows.Forms.ListBox listBoxYear;
        private System.Windows.Forms.ListBox listBoxHalfYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxAction;
        private System.Windows.Forms.ListBox listBoxStoredActions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDeleteActionfromPatient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxToDo;
    }
}
