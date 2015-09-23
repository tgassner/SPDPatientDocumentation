namespace SPD.GUI {
    partial class OverviewControl {
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
            this.listViewOverview = new System.Windows.Forms.ListView();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewOverview
            // 
            this.listViewOverview.Location = new System.Drawing.Point(3, 26);
            this.listViewOverview.Name = "listViewOverview";
            this.listViewOverview.ShowItemToolTips = true;
            this.listViewOverview.Size = new System.Drawing.Size(983, 698);
            this.listViewOverview.TabIndex = 0;
            this.listViewOverview.UseCompatibleStateImageBehavior = false;
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Location = new System.Drawing.Point(911, 0);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(75, 23);
            this.buttonExportCSV.TabIndex = 1;
            this.buttonExportCSV.Text = "Export CSV";
            this.buttonExportCSV.UseVisualStyleBackColor = true;
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);
            // 
            // OverviewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonExportCSV);
            this.Controls.Add(this.listViewOverview);
            this.Name = "OverviewControl";
            this.Size = new System.Drawing.Size(989, 727);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewOverview;
        private System.Windows.Forms.Button buttonExportCSV;
    }
}
