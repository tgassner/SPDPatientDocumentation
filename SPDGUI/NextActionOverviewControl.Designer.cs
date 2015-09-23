namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    partial class NextActionOverviewControl {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.listBoxYear = new System.Windows.Forms.ListBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelAction = new System.Windows.Forms.Label();
            this.labelHalfYear = new System.Windows.Forms.Label();
            this.listBoxAction = new System.Windows.Forms.ListBox();
            this.listBoxHalfYear = new System.Windows.Forms.ListBox();
            this.listViewNextActions = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listBoxYear
            // 
            this.listBoxYear.FormattingEnabled = true;
            this.listBoxYear.Location = new System.Drawing.Point(41, 9);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.Size = new System.Drawing.Size(122, 121);
            this.listBoxYear.TabIndex = 1;
            this.listBoxYear.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(3, 9);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(32, 13);
            this.labelYear.TabIndex = 2;
            this.labelYear.Text = "Year:";
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Location = new System.Drawing.Point(375, 9);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(43, 13);
            this.labelAction.TabIndex = 10;
            this.labelAction.Text = "Action: ";
            // 
            // labelHalfYear
            // 
            this.labelHalfYear.AutoSize = true;
            this.labelHalfYear.Location = new System.Drawing.Point(169, 9);
            this.labelHalfYear.Name = "labelHalfYear";
            this.labelHalfYear.Size = new System.Drawing.Size(52, 13);
            this.labelHalfYear.TabIndex = 9;
            this.labelHalfYear.Text = "Halfyear: ";
            // 
            // listBoxAction
            // 
            this.listBoxAction.FormattingEnabled = true;
            this.listBoxAction.Location = new System.Drawing.Point(424, 9);
            this.listBoxAction.Name = "listBoxAction";
            this.listBoxAction.Size = new System.Drawing.Size(142, 30);
            this.listBoxAction.TabIndex = 7;
            this.listBoxAction.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // listBoxHalfYear
            // 
            this.listBoxHalfYear.FormattingEnabled = true;
            this.listBoxHalfYear.Location = new System.Drawing.Point(227, 9);
            this.listBoxHalfYear.Name = "listBoxHalfYear";
            this.listBoxHalfYear.Size = new System.Drawing.Size(142, 30);
            this.listBoxHalfYear.TabIndex = 8;
            this.listBoxHalfYear.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // listViewNextActions
            // 
            this.listViewNextActions.Location = new System.Drawing.Point(6, 156);
            this.listViewNextActions.Name = "listViewNextActions";
            this.listViewNextActions.Size = new System.Drawing.Size(981, 506);
            this.listViewNextActions.TabIndex = 11;
            this.listViewNextActions.UseCompatibleStateImageBehavior = false;
            // 
            // NextActionOverviewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewNextActions);
            this.Controls.Add(this.labelAction);
            this.Controls.Add(this.labelHalfYear);
            this.Controls.Add(this.listBoxAction);
            this.Controls.Add(this.listBoxHalfYear);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.listBoxYear);
            this.Name = "NextActionOverviewControl";
            this.Size = new System.Drawing.Size(990, 665);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxYear;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Label labelHalfYear;
        private System.Windows.Forms.ListBox listBoxAction;
        private System.Windows.Forms.ListBox listBoxHalfYear;
        private System.Windows.Forms.ListView listViewNextActions;
    }
}
