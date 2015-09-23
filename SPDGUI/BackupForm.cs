using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SPD.BL.Interfaces;

namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public partial class BackupForm : Form {

        //private string backupPath;
        private ISPDBL patComp;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackupForm"/> class.
        /// </summary>
        public BackupForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Inits the specified backup path.
        /// </summary>
        /// <param name="patComp">The pat comp.</param>
        public void Init( ISPDBL patComp) {
            this.patComp = patComp;
            textBoxBackupPath.Text = this.patComp.BackupPath();
            this.textBoxInfo.Text = "";
            this.buttonBackupNow.Enabled = true;
        }

        private void buttonBackupNow_Click(object sender, EventArgs e) {
            textBoxBackupPath.Text = textBoxBackupPath.Text.Trim();
            if (textBoxBackupPath.Text.Equals("")){
                MessageBox.Show("There must be a Path of a Directory in the Textbox\r\ne.g.: d:\\bak");
                return;
            }
            if (!Directory.Exists(textBoxBackupPath.Text)) {
                MessageBox.Show("The Directory has to exist");
                return;
            }
            buttonBackupNow.Enabled = false;
            buttonCancel.Text = "Quit";

            textBoxInfo.Text = this.patComp.DoBackup(textBoxBackupPath.Text);
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonFindBackupDirectory_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK) {
                textBoxBackupPath.Text = fbd.SelectedPath;
            }
        }

        private void BackupForm_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x1b) {
                this.Close();
            }
        }

        private void buttonRestore_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            string dbExtension = this.patComp.GetDbFileExtension();
            ofd.Filter = "SPD Database Files (*." + dbExtension + ")|*." + dbExtension;
            if (!(DialogResult.OK == ofd.ShowDialog())) {
                return;
            }

            string message;
            bool ok = this.patComp.DoRestore(ofd.FileName, out message);

            if (ok) {
                MessageBox.Show("Restoring OK - Old DB File backupped:" + Environment.NewLine + message);
                this.Close();
            } else {
                MessageBox.Show("Sorry Restore not possible:" + Environment.NewLine + message);
            }
        }
    }
}