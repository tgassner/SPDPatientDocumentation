namespace SPD.GUI {
    partial class BackupForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBackupPath = new System.Windows.Forms.TextBox();
            this.buttonFindBackupDirectory = new System.Windows.Forms.Button();
            this.buttonBackupNow = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Destination:";
            // 
            // textBoxBackupPath
            // 
            this.textBoxBackupPath.Location = new System.Drawing.Point(121, 6);
            this.textBoxBackupPath.Name = "textBoxBackupPath";
            this.textBoxBackupPath.Size = new System.Drawing.Size(583, 20);
            this.textBoxBackupPath.TabIndex = 1;
            this.textBoxBackupPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BackupForm_KeyPress);
            // 
            // buttonFindBackupDirectory
            // 
            this.buttonFindBackupDirectory.Location = new System.Drawing.Point(121, 32);
            this.buttonFindBackupDirectory.Name = "buttonFindBackupDirectory";
            this.buttonFindBackupDirectory.Size = new System.Drawing.Size(75, 23);
            this.buttonFindBackupDirectory.TabIndex = 2;
            this.buttonFindBackupDirectory.Text = "Find";
            this.buttonFindBackupDirectory.UseVisualStyleBackColor = true;
            this.buttonFindBackupDirectory.Click += new System.EventHandler(this.buttonFindBackupDirectory_Click);
            this.buttonFindBackupDirectory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BackupForm_KeyPress);
            // 
            // buttonBackupNow
            // 
            this.buttonBackupNow.Location = new System.Drawing.Point(12, 73);
            this.buttonBackupNow.Name = "buttonBackupNow";
            this.buttonBackupNow.Size = new System.Drawing.Size(103, 23);
            this.buttonBackupNow.TabIndex = 3;
            this.buttonBackupNow.Text = "Backup NOW";
            this.buttonBackupNow.UseVisualStyleBackColor = true;
            this.buttonBackupNow.Click += new System.EventHandler(this.buttonBackupNow_Click);
            this.buttonBackupNow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BackupForm_KeyPress);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(121, 73);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BackupForm_KeyPress);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Enabled = false;
            this.textBoxInfo.Location = new System.Drawing.Point(12, 102);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(692, 284);
            this.textBoxInfo.TabIndex = 5;
            this.textBoxInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BackupForm_KeyPress);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(629, 73);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(75, 23);
            this.buttonRestore.TabIndex = 6;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 398);
            this.ControlBox = false;
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonBackupNow);
            this.Controls.Add(this.buttonFindBackupDirectory);
            this.Controls.Add(this.textBoxBackupPath);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(724, 425);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(724, 425);
            this.Name = "BackupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BackupForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBackupPath;
        private System.Windows.Forms.Button buttonFindBackupDirectory;
        private System.Windows.Forms.Button buttonBackupNow;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonRestore;
    }
}