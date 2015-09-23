namespace SPD.GUI {
    partial class PrintSelectionForm {
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
            this.checkBoxVisits = new System.Windows.Forms.CheckBox();
            this.checkBoxOperations = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxFurtherTreatment = new System.Windows.Forms.CheckBox();
            this.buttonAllDataOfPatient = new System.Windows.Forms.Button();
            this.checkBoxPhotoLinks = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 182);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(201, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintSelectionForm_KeyPress);
            // 
            // checkBoxVisits
            // 
            this.checkBoxVisits.AutoSize = true;
            this.checkBoxVisits.Location = new System.Drawing.Point(73, 37);
            this.checkBoxVisits.Name = "checkBoxVisits";
            this.checkBoxVisits.Size = new System.Drawing.Size(50, 17);
            this.checkBoxVisits.TabIndex = 1;
            this.checkBoxVisits.Text = "Visits";
            this.checkBoxVisits.UseVisualStyleBackColor = true;
            this.checkBoxVisits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintSelectionForm_KeyPress);
            // 
            // checkBoxOperations
            // 
            this.checkBoxOperations.AutoSize = true;
            this.checkBoxOperations.Location = new System.Drawing.Point(73, 60);
            this.checkBoxOperations.Name = "checkBoxOperations";
            this.checkBoxOperations.Size = new System.Drawing.Size(77, 17);
            this.checkBoxOperations.TabIndex = 2;
            this.checkBoxOperations.Text = "Operations";
            this.checkBoxOperations.UseVisualStyleBackColor = true;
            this.checkBoxOperations.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintSelectionForm_KeyPress);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 126);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(201, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            this.buttonOK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintSelectionForm_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "What do you want to print for this patient?";
            // 
            // checkBoxFurtherTreatment
            // 
            this.checkBoxFurtherTreatment.AutoSize = true;
            this.checkBoxFurtherTreatment.Location = new System.Drawing.Point(73, 81);
            this.checkBoxFurtherTreatment.Name = "checkBoxFurtherTreatment";
            this.checkBoxFurtherTreatment.Size = new System.Drawing.Size(110, 17);
            this.checkBoxFurtherTreatment.TabIndex = 5;
            this.checkBoxFurtherTreatment.Text = "Further Treatment";
            this.checkBoxFurtherTreatment.UseVisualStyleBackColor = true;
            this.checkBoxFurtherTreatment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintSelectionForm_KeyPress);
            // 
            // buttonAllDataOfPatient
            // 
            this.buttonAllDataOfPatient.Location = new System.Drawing.Point(12, 153);
            this.buttonAllDataOfPatient.Name = "buttonAllDataOfPatient";
            this.buttonAllDataOfPatient.Size = new System.Drawing.Size(201, 23);
            this.buttonAllDataOfPatient.TabIndex = 3;
            this.buttonAllDataOfPatient.Text = "Print all data of patient";
            this.buttonAllDataOfPatient.UseVisualStyleBackColor = true;
            this.buttonAllDataOfPatient.Click += new System.EventHandler(this.buttonAllDataOfPatient_Click);
            this.buttonAllDataOfPatient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintSelectionForm_KeyPress);
            // 
            // checkBoxPhotoLinks
            // 
            this.checkBoxPhotoLinks.AutoSize = true;
            this.checkBoxPhotoLinks.Location = new System.Drawing.Point(73, 104);
            this.checkBoxPhotoLinks.Name = "checkBoxPhotoLinks";
            this.checkBoxPhotoLinks.Size = new System.Drawing.Size(78, 17);
            this.checkBoxPhotoLinks.TabIndex = 5;
            this.checkBoxPhotoLinks.Text = "Photo links";
            this.checkBoxPhotoLinks.UseVisualStyleBackColor = true;
            this.checkBoxPhotoLinks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintSelectionForm_KeyPress);
            // 
            // PrintSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 214);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxPhotoLinks);
            this.Controls.Add(this.checkBoxFurtherTreatment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAllDataOfPatient);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxOperations);
            this.Controls.Add(this.checkBoxVisits);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(233, 241);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(233, 241);
            this.Name = "PrintSelectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintSelection";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrintSelectionForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxVisits;
        private System.Windows.Forms.CheckBox checkBoxOperations;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxFurtherTreatment;
        private System.Windows.Forms.Button buttonAllDataOfPatient;
        private System.Windows.Forms.CheckBox checkBoxPhotoLinks;
    }
}