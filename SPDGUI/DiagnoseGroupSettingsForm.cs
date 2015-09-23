using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPD.BL.Interfaces;
using SPD.CommonObjects;

namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    public partial class DiagnoseGroupSettingsForm : Form {

        ISPDBL patComp;
        DiagnoseGroupData currentDiagnoseGroupData = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnoseGroupSettingsForm"/> class.
        /// </summary>
        /// <param name="patComp">The pat comp.</param>
        public DiagnoseGroupSettingsForm(ISPDBL patComp) {
            InitializeComponent();

            this.patComp = patComp;

            refreshListBox();
        }

        private void refreshListBox() {
            this.listBoxDiagnoseGroups.Items.Clear();
            foreach (DiagnoseGroupData dgd in this.patComp.FindAllDiagnoseGroups()) {
                this.listBoxDiagnoseGroups.Items.Add(dgd);
            }
            buttonStore.Text = "Store New";
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            if (listBoxDiagnoseGroups.SelectedItems.Count == 0) {
                MessageBox.Show("Please select a Diagnosegroup to edit.");
                return;
            }
            currentDiagnoseGroupData = (DiagnoseGroupData)listBoxDiagnoseGroups.SelectedItem;
            textBoxLongDGName.Text = currentDiagnoseGroupData.LongName;
            textBoxShortDGName.Text = currentDiagnoseGroupData.ShortName;
            buttonStore.Text = "Store Changes";
        }

        private void buttonStore_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBoxLongDGName.Text) || (string.IsNullOrEmpty(textBoxShortDGName.Text))) {
                MessageBox.Show("Long and Short Name must be filled out.");
                return;
            }

            DiagnoseGroupData diagnoseGroupData = new DiagnoseGroupData();
            diagnoseGroupData.LongName = textBoxLongDGName.Text;
            diagnoseGroupData.ShortName = textBoxShortDGName.Text;
            if (currentDiagnoseGroupData == null) {
                patComp.InsertDiagnoseGroup(diagnoseGroupData);
            } else {
                diagnoseGroupData.DiagnoseGroupDataID = currentDiagnoseGroupData.DiagnoseGroupDataID;
                patComp.UpdateDiagnoseGroup(diagnoseGroupData);
            }

            refreshListBox();

            textBoxLongDGName.Text = string.Empty;
            textBoxShortDGName.Text = string.Empty;
            currentDiagnoseGroupData = null;
            buttonStore.Text = "Store New";
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            currentDiagnoseGroupData = null;
            textBoxShortDGName.Text = string.Empty;
            textBoxLongDGName.Text = string.Empty;
            buttonStore.Text = "Store New";
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            if (listBoxDiagnoseGroups.SelectedItems.Count == 0) {
                MessageBox.Show("Please select a Diagnosegroup to delete.");
                return;
            }

            long dgId = ((DiagnoseGroupData)listBoxDiagnoseGroups.SelectedItem).DiagnoseGroupDataID;

            if (patComp.FindPatientIdsByDiagnoseGroupId(dgId).Count > 0) {
                MessageBox.Show("One or more patients are assignes to this DiagnoseGroup." + Environment.NewLine + 
                    "Diagnose Group can only be deleted if no patients are assigned to it.");
                return;
            }

            patComp.DeleteDiagnoseGroup(dgId);
            refreshListBox();
            buttonStore.Text = "Store New";
        }

        private void DiagnoseGroupSettingsForm_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x1b) {
                this.Close();
            }
        }      
    }
}
