using System.Windows.Forms;
namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.neuerPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearOfBirthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateOfMissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateOfMissionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGeneralSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnoseGroupSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCachesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuerPatientToolStripMenuItem,
            this.patientSuchenToolStripMenuItem,
            this.nextActionsToolStripMenuItem,
            this.overviewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.topMostToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.importToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(994, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // neuerPatientToolStripMenuItem
            // 
            this.neuerPatientToolStripMenuItem.Name = "neuerPatientToolStripMenuItem";
            this.neuerPatientToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.neuerPatientToolStripMenuItem.Text = "&New patient";
            this.neuerPatientToolStripMenuItem.Click += new System.EventHandler(this.newPatientToolStripMenuItem_Click);
            // 
            // patientSuchenToolStripMenuItem
            // 
            this.patientSuchenToolStripMenuItem.Name = "patientSuchenToolStripMenuItem";
            this.patientSuchenToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.patientSuchenToolStripMenuItem.Text = "&Find Patient";
            this.patientSuchenToolStripMenuItem.Click += new System.EventHandler(this.findPatientToolStripMenuItem_Click);
            // 
            // nextActionsToolStripMenuItem
            // 
            this.nextActionsToolStripMenuItem.Name = "nextActionsToolStripMenuItem";
            this.nextActionsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.nextActionsToolStripMenuItem.Text = "Next Actions";
            this.nextActionsToolStripMenuItem.Click += new System.EventHandler(this.nextActionsToolStripMenuItem_Click);
            // 
            // overviewToolStripMenuItem
            // 
            this.overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
            this.overviewToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.overviewToolStripMenuItem.Text = "Overview";
            this.overviewToolStripMenuItem.Click += new System.EventHandler(this.overviewToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.topMostToolStripMenuItem.Text = "Top &Most";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientsToolStripMenuItem,
            this.visitsToolStripMenuItem,
            this.operationsToolStripMenuItem});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.statisticsToolStripMenuItem.Text = "&Statistics";
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sexToolStripMenuItem,
            this.yearOfBirthToolStripMenuItem,
            this.weightToolStripMenuItem});
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.patientsToolStripMenuItem.Text = "&Patients";
            // 
            // sexToolStripMenuItem
            // 
            this.sexToolStripMenuItem.Name = "sexToolStripMenuItem";
            this.sexToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.sexToolStripMenuItem.Text = "Sex";
            this.sexToolStripMenuItem.Click += new System.EventHandler(this.sexToolStripMenuItem_Click);
            // 
            // yearOfBirthToolStripMenuItem
            // 
            this.yearOfBirthToolStripMenuItem.Name = "yearOfBirthToolStripMenuItem";
            this.yearOfBirthToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.yearOfBirthToolStripMenuItem.Text = "Year of Birth";
            this.yearOfBirthToolStripMenuItem.Click += new System.EventHandler(this.yearOfBirthToolStripMenuItem_Click);
            // 
            // weightToolStripMenuItem
            // 
            this.weightToolStripMenuItem.Name = "weightToolStripMenuItem";
            this.weightToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.weightToolStripMenuItem.Text = "Weight";
            this.weightToolStripMenuItem.Click += new System.EventHandler(this.weightToolStripMenuItem_Click);
            // 
            // visitsToolStripMenuItem
            // 
            this.visitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateOfMissionToolStripMenuItem});
            this.visitsToolStripMenuItem.Name = "visitsToolStripMenuItem";
            this.visitsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.visitsToolStripMenuItem.Text = "&Visits";
            // 
            // dateOfMissionToolStripMenuItem
            // 
            this.dateOfMissionToolStripMenuItem.Name = "dateOfMissionToolStripMenuItem";
            this.dateOfMissionToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.dateOfMissionToolStripMenuItem.Text = "Date of mission";
            this.dateOfMissionToolStripMenuItem.Click += new System.EventHandler(this.dateOfMissionToolStripMenuItem_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateOfMissionToolStripMenuItem1});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.operationsToolStripMenuItem.Text = "&Operations";
            // 
            // dateOfMissionToolStripMenuItem1
            // 
            this.dateOfMissionToolStripMenuItem1.Name = "dateOfMissionToolStripMenuItem1";
            this.dateOfMissionToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.dateOfMissionToolStripMenuItem1.Text = "Date of mission";
            this.dateOfMissionToolStripMenuItem1.Click += new System.EventHandler(this.dateOfMissionToolStripMenuItem1_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.backupToolStripMenuItem.Text = "&Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseSettingsToolStripMenuItem,
            this.toolStripMenuItemGeneralSettings,
            this.diagnoseGroupSettingsToolStripMenuItem,
            this.clearCachesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // databaseSettingsToolStripMenuItem
            // 
            this.databaseSettingsToolStripMenuItem.Name = "databaseSettingsToolStripMenuItem";
            this.databaseSettingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.databaseSettingsToolStripMenuItem.Text = "Database Settings";
            this.databaseSettingsToolStripMenuItem.Click += new System.EventHandler(this.databaseSettingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItemGeneralSettings
            // 
            this.toolStripMenuItemGeneralSettings.Name = "toolStripMenuItemGeneralSettings";
            this.toolStripMenuItemGeneralSettings.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemGeneralSettings.Text = "General Settings";
            this.toolStripMenuItemGeneralSettings.Click += new System.EventHandler(this.toolStripMenuItemGeneralSettings_Click);
            // 
            // diagnoseGroupSettingsToolStripMenuItem
            // 
            this.diagnoseGroupSettingsToolStripMenuItem.Name = "diagnoseGroupSettingsToolStripMenuItem";
            this.diagnoseGroupSettingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.diagnoseGroupSettingsToolStripMenuItem.Text = "Diagnose Group Settings";
            this.diagnoseGroupSettingsToolStripMenuItem.Click += new System.EventHandler(this.diagnoseGroupSettingsToolStripMenuItem_Click);
            // 
            // clearCachesToolStripMenuItem
            // 
            this.clearCachesToolStripMenuItem.Name = "clearCachesToolStripMenuItem";
            this.clearCachesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.clearCachesToolStripMenuItem.Text = "Clear Caches";
            this.clearCachesToolStripMenuItem.Click += new System.EventHandler(this.clearCachesToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shortcutsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.helpToolStripMenuItem.Text = "&?";
            // 
            // shortcutsToolStripMenuItem
            // 
            this.shortcutsToolStripMenuItem.Name = "shortcutsToolStripMenuItem";
            this.shortcutsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.shortcutsToolStripMenuItem.Text = "&Shortcuts";
            this.shortcutsToolStripMenuItem.Click += new System.EventHandler(this.shortcutsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(735, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 761);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "SPD Patient Documentation";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem neuerPatientToolStripMenuItem;
        private ToolStripMenuItem patientSuchenToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem topMostToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem shortcutsToolStripMenuItem;
        private ToolStripMenuItem statisticsToolStripMenuItem;
        private ToolStripMenuItem patientsToolStripMenuItem;
        private ToolStripMenuItem sexToolStripMenuItem;
        private ToolStripMenuItem yearOfBirthToolStripMenuItem;
        private ToolStripMenuItem weightToolStripMenuItem;
        private ToolStripMenuItem visitsToolStripMenuItem;
        private ToolStripMenuItem operationsToolStripMenuItem;
        private ToolStripMenuItem dateOfMissionToolStripMenuItem;
        private ToolStripMenuItem dateOfMissionToolStripMenuItem1;
        private ToolStripMenuItem backupToolStripMenuItem;
        private ToolStripMenuItem nextActionsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem databaseSettingsToolStripMenuItem;

        private System.Windows.Forms.StatusStrip statusStrip;
        private ToolStripMenuItem toolStripMenuItemGeneralSettings;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem diagnoseGroupSettingsToolStripMenuItem;
        private ToolStripMenuItem clearCachesToolStripMenuItem;
        private ToolStripMenuItem overviewToolStripMenuItem;
    }
}

