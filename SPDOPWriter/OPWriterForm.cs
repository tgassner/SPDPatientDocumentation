using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPD.BL;
using SPD.BL.Interfaces;
using SPD.GUI;
using System.IO;
using Procurios.Public;
using System.Collections;
using SPD.CommonUtilities;
using SPD.CommonObjects;

namespace SPD.GUI.OPWriter {
    public partial class OPWriterForm : Form {

        private OPControl oPControl;
        private ISPDBL patComp;

        public OPWriterForm() {
            InitializeComponent();
            try {
                patComp = new SPDBL();
            } catch (Exception) { }

            this.Text = Application.ProductName + " - " +  Application.ProductVersion; // + " - Development Version!!";
        }

        private void buttonOpenPath_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (Directory.Exists(textBoxExportPath.Text)) {
                fbd.SelectedPath = textBoxExportPath.Text;
            }
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK) {
                textBoxExportPath.Text = fbd.SelectedPath;
            }
        }

        private void OPWriterForm_Load(object sender, EventArgs e) {
            this.oPControl = new OPControl();
            this.oPControl.Enabled = true;
            this.oPControl.Location = new System.Drawing.Point(6, 55);
            this.oPControl.Name = "opControl";
            this.oPControl.ButtonSaveOperation.Text = "Export Operation";
            this.oPControl.ButtonSaveAndPrint.Text = "Export and Print OP";
            this.oPControl.LabelPatient.Hide();
            this.oPControl.hideForOpWriter();
            this.oPControl.Store += new NewOperationStoreEventHandler(oPControl_Store);
            try
            {
                this.labelDBInfo.Text = "DB Found: " + this.patComp.GetAllPatients().Count + " Patients";
            } catch (Exception) {
                this.labelDBInfo.Text = "No Db Found";
            }

            this.Controls.Add(this.oPControl);

            if (!string.IsNullOrEmpty(SPD.GUI.OPWriter.Properties.Settings.Default.exportPath)) {
                this.textBoxExportPath.Text = SPD.GUI.OPWriter.Properties.Settings.Default.exportPath;
            }
        }

        void oPControl_Store(object sender, NewOperationStoreEventArgs e) {
            if (!Directory.Exists(textBoxExportPath.Text)) {
                MessageBox.Show("The Export directory does not exist!");
                e.StoredOk = false;
                return;
            }

            long pId;
            try {
                pId = Int64.Parse(textBoxPatientId.Text);
            } catch (FormatException) {
                MessageBox.Show("PatientId is not valid!");
                e.StoredOk = false;
                return;
            }

            OperationData op = e.Operation;
            op.PatientId = Int64.Parse(textBoxPatientId.Text);

            JsonContainer jsonContainer = new JsonContainer();
            jsonContainer.addOperation(op);
            string jsonString = SpdJsonTools.GenerateJson(jsonContainer);

            try {
                TextFileHelper.WriteFile(
                    textBoxExportPath.Text + Path.DirectorySeparatorChar + "SPD.Operation." + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".json",
                    jsonString);
            } catch (Exception ex) {
                MessageBox.Show("Storing not possible:\n" + ex.Message);
                e.StoredOk = false;
                return;
            }

            PatientData pd  = null;
            try {
                pd = this.patComp.FindPatientById(op.PatientId);
            } catch (Exception) {}

            if (pd == null) {
                pd = new PatientData();
                pd.Id = op.PatientId;
                pd.Address = string.Empty;
                pd.FirstName = string.Empty;
                pd.Phone = string.Empty;
                pd.SurName = string.Empty;
            }

            this.oPControl.CurrentPatient = pd;

            e.TakeFromDB = false;

            this.oPControl.Clear();
            this.textBoxPatientId.Clear();
            SPD.GUI.OPWriter.Properties.Settings.Default.exportPath = textBoxExportPath.Text;
            SPD.GUI.OPWriter.Properties.Settings.Default.Save();
        }

        private void buttonDBSettings_Click(object sender, EventArgs e) {
            DatabaseSettingsForm dbSettings = new DatabaseSettingsForm(this.patComp);
            dbSettings.TopMost = this.TopMost;
            dbSettings.ShowDialog();
        }
    }
}
