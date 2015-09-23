using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using System.IO;
using SPD.CommonUtilities;

namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    public partial class ImportControl : UserControl {
        private ISPDBL patComp;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportControl"/> class.
        /// </summary>
        /// <param name="patComp">The pat comp.</param>
        public ImportControl(ISPDBL patComp) {
            InitializeComponent();

            this.patComp = patComp;
        }

        private JsonContainer mergedJsonContainer = null;

        /// <summary>
        /// Inits this instance.
        /// </summary>
        public void Init() {
            textBoxStatus.Text = string.Empty;
        }

        private void buttonbuttonOpenFileOpenDialog_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "SPD JSON Files (*.json)|*.json|All files (*.*)|*.*";
            DialogResult dr = ofd.ShowDialog();

            if (dr != DialogResult.OK) {
                return;
            }

            if (ofd.SafeFileNames == null || ofd.SafeFileNames.Length < 1) {
                return;
            }

            IDictionary<string, string> fileContents = new Dictionary<string, string>(); 

            foreach (string filename in ofd.FileNames) {
                if (File.Exists(filename)) {
                    try {
                        fileContents.Add(filename, TextFileHelper.ReadFile(filename));
                    } catch (Exception ex) {
                        MessageBox.Show("Cannot read File: " + filename + "\nBecause" + ex.Message);
                    }
                }
            }

            IList<JsonContainer> jsonContainers = new List<JsonContainer>();

            foreach (string filename in fileContents.Keys) {
                JsonContainer json = SpdJsonTools.ParseJson(fileContents[filename]);
                if (json == null) {
                    MessageBox.Show("ERROR in File: " + filename + "\nThis file cannot be parsed!");
                } else {
                    jsonContainers.Add(json);
                }
            }

            mergedJsonContainer = SpdJsonTools.MergeJsonContainers(jsonContainers);

            foreach (OperationData op in mergedJsonContainer.Operations) {
                PatientData pd = this.patComp.FindPatientById(op.PatientId);
                if (pd == null) {
                    checkedListBoxImportOperations.Items.Add("Operation: ERROR!!! Patient with ID:" + op.PatientId + " not found!", false);
                } else {
                    checkedListBoxImportOperations.Items.Add("Operation: PatientId:" + op.PatientId + " Name:" + pd.FirstName + " " + pd.SurName + " Diagnoses:" + op.Diagnoses + " Performed: " + op.Performed, true);
                }
            }

            //TODO: patient, next Action, Visits, images, Group,...
        }

        private void buttonImport_Click(object sender, EventArgs e) {
            if (checkedListBoxImportOperations.CheckedItems.Count == 0 || mergedJsonContainer == null) {
                MessageBox.Show("No operations are available / selected to import!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            int successCounter = 0;
            int errorCounter = 0;
            foreach(int checkedIndex in checkedListBoxImportOperations.CheckedIndices) {
                if (mergedJsonContainer.Operations.Count >= checkedIndex) {
                    OperationData op = mergedJsonContainer.Operations[checkedIndex];
                    PatientData patient = this.patComp.FindPatientById(op.PatientId);
                    OperationData inserted = this.patComp.InsertOperation(mergedJsonContainer.Operations[checkedIndex]);
                    if (inserted == null) {
                        sb.Append("ERROR: ");
                        errorCounter++;
                    } else {
                        sb.Append("SUCCESS: ");
                        successCounter++;
                    }
                    sb.Append("PatientId: " + op.PatientId + " Name: " + patient.FirstName + " " + patient.SurName + " Diagnoses" + op.Diagnoses + "\r\n");
                }
            }

            //TODO: patient, next Action, Visits, images, Group,...

            string message = "Operation(s):" + Environment.NewLine + "Successfull importet:" + successCounter + Environment.NewLine + "Errorfull importet:" + errorCounter + Environment.NewLine  + sb.ToString();

            log.Info(message);

            textBoxStatus.Text = message;
            checkedListBoxImportOperations.Items.Clear();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            checkedListBoxImportOperations.Items.Clear();
        }

    }
}
