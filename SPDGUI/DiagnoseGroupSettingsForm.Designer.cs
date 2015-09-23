namespace SPD.GUI {
    partial class DiagnoseGroupSettingsForm {
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonStore = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.listBoxDiagnoseGroups = new System.Windows.Forms.ListBox();
            this.textBoxShortDGName = new System.Windows.Forms.TextBox();
            this.textBoxLongDGName = new System.Windows.Forms.TextBox();
            this.labelDiagnoseGroups = new System.Windows.Forms.Label();
            this.labelShortDGName = new System.Windows.Forms.Label();
            this.labelLongDGName = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(430, 318);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(95, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(322, 156);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            // 
            // buttonStore
            // 
            this.buttonStore.Location = new System.Drawing.Point(322, 127);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(95, 23);
            this.buttonStore.TabIndex = 3;
            this.buttonStore.Text = "Store New";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            this.buttonStore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(319, 318);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(95, 23);
            this.buttonEdit.TabIndex = 6;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            this.buttonEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            // 
            // listBoxDiagnoseGroups
            // 
            this.listBoxDiagnoseGroups.FormattingEnabled = true;
            this.listBoxDiagnoseGroups.Location = new System.Drawing.Point(12, 25);
            this.listBoxDiagnoseGroups.Name = "listBoxDiagnoseGroups";
            this.listBoxDiagnoseGroups.Size = new System.Drawing.Size(304, 316);
            this.listBoxDiagnoseGroups.TabIndex = 0;
            this.listBoxDiagnoseGroups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            // 
            // textBoxShortDGName
            // 
            this.textBoxShortDGName.Location = new System.Drawing.Point(319, 41);
            this.textBoxShortDGName.Name = "textBoxShortDGName";
            this.textBoxShortDGName.Size = new System.Drawing.Size(206, 20);
            this.textBoxShortDGName.TabIndex = 1;
            this.textBoxShortDGName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            // 
            // textBoxLongDGName
            // 
            this.textBoxLongDGName.Location = new System.Drawing.Point(319, 94);
            this.textBoxLongDGName.Name = "textBoxLongDGName";
            this.textBoxLongDGName.Size = new System.Drawing.Size(206, 20);
            this.textBoxLongDGName.TabIndex = 2;
            this.textBoxLongDGName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            // 
            // labelDiagnoseGroups
            // 
            this.labelDiagnoseGroups.AutoSize = true;
            this.labelDiagnoseGroups.Location = new System.Drawing.Point(12, 9);
            this.labelDiagnoseGroups.Name = "labelDiagnoseGroups";
            this.labelDiagnoseGroups.Size = new System.Drawing.Size(92, 13);
            this.labelDiagnoseGroups.TabIndex = 7;
            this.labelDiagnoseGroups.Text = "Diagnose Groups:";
            // 
            // labelShortDGName
            // 
            this.labelShortDGName.AutoSize = true;
            this.labelShortDGName.Location = new System.Drawing.Point(319, 25);
            this.labelShortDGName.Name = "labelShortDGName";
            this.labelShortDGName.Size = new System.Drawing.Size(85, 13);
            this.labelShortDGName.TabIndex = 8;
            this.labelShortDGName.Text = "Short DG Name:";
            // 
            // labelLongDGName
            // 
            this.labelLongDGName.AutoSize = true;
            this.labelLongDGName.Location = new System.Drawing.Point(319, 78);
            this.labelLongDGName.Name = "labelLongDGName";
            this.labelLongDGName.Size = new System.Drawing.Size(84, 13);
            this.labelLongDGName.TabIndex = 9;
            this.labelLongDGName.Text = "Long DG Name:";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(319, 289);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(95, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            // 
            // DiagnoseGroupSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 351);
            this.ControlBox = false;
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelLongDGName);
            this.Controls.Add(this.labelShortDGName);
            this.Controls.Add(this.labelDiagnoseGroups);
            this.Controls.Add(this.textBoxLongDGName);
            this.Controls.Add(this.textBoxShortDGName);
            this.Controls.Add(this.listBoxDiagnoseGroups);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonStore);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiagnoseGroupSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DiagnoseGroupSettingsForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiagnoseGroupSettingsForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ListBox listBoxDiagnoseGroups;
        private System.Windows.Forms.TextBox textBoxShortDGName;
        private System.Windows.Forms.TextBox textBoxLongDGName;
        private System.Windows.Forms.Label labelDiagnoseGroups;
        private System.Windows.Forms.Label labelShortDGName;
        private System.Windows.Forms.Label labelLongDGName;
        private System.Windows.Forms.Button buttonDelete;
    }
}