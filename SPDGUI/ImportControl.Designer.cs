namespace SPD.GUI {
    partial class ImportControl {
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
            this.buttonbuttonOpenFileOpenDialog = new System.Windows.Forms.Button();
            this.checkedListBoxImportOperations = new System.Windows.Forms.CheckedListBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelOP = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonbuttonOpenFileOpenDialog
            // 
            this.buttonbuttonOpenFileOpenDialog.Location = new System.Drawing.Point(3, 3);
            this.buttonbuttonOpenFileOpenDialog.Name = "buttonbuttonOpenFileOpenDialog";
            this.buttonbuttonOpenFileOpenDialog.Size = new System.Drawing.Size(75, 23);
            this.buttonbuttonOpenFileOpenDialog.TabIndex = 0;
            this.buttonbuttonOpenFileOpenDialog.Text = "Open Files";
            this.buttonbuttonOpenFileOpenDialog.UseVisualStyleBackColor = true;
            this.buttonbuttonOpenFileOpenDialog.Click += new System.EventHandler(this.buttonbuttonOpenFileOpenDialog_Click);
            // 
            // checkedListBoxImportOperations
            // 
            this.checkedListBoxImportOperations.FormattingEnabled = true;
            this.checkedListBoxImportOperations.Location = new System.Drawing.Point(3, 45);
            this.checkedListBoxImportOperations.Name = "checkedListBoxImportOperations";
            this.checkedListBoxImportOperations.Size = new System.Drawing.Size(934, 394);
            this.checkedListBoxImportOperations.TabIndex = 1;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(515, 3);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 2;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(596, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelOP
            // 
            this.labelOP.AutoSize = true;
            this.labelOP.Location = new System.Drawing.Point(3, 29);
            this.labelOP.Name = "labelOP";
            this.labelOP.Size = new System.Drawing.Size(67, 13);
            this.labelOP.TabIndex = 4;
            this.labelOP.Text = "Operation(s):";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(3, 446);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(934, 275);
            this.textBoxStatus.TabIndex = 6;
            // 
            // ImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelOP);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.checkedListBoxImportOperations);
            this.Controls.Add(this.buttonbuttonOpenFileOpenDialog);
            this.Name = "ImportControl";
            this.Size = new System.Drawing.Size(940, 724);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonbuttonOpenFileOpenDialog;
        private System.Windows.Forms.CheckedListBox checkedListBoxImportOperations;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelOP;
        private System.Windows.Forms.TextBox textBoxStatus;
    }
}
