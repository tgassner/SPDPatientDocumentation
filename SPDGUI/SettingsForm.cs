using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPD.CommonUtilities;
using System.Collections.Specialized;

namespace SPD.GUI {
    /// <summary>
    /// Settings Form
    /// </summary>
    public partial class SettingsForm : Form {
        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsForm() {
            InitializeComponent();
            this.listBoxPrintBarcodes.Items.Add(Boolean.TrueString);
            this.listBoxPrintBarcodes.Items.Add(Boolean.FalseString);
            if (SPD.GUI.Properties.Settings.Default.Barcode) {
                listBoxPrintBarcodes.SelectedIndex = 0;
            } else {
                listBoxPrintBarcodes.SelectedIndex = 1;
            }

            if (StaticUtilities.IsFontInstalled("Free 3 of 9 Extended")) {
                this.labelBarcodeFontInstalled.Text = "Font \"Free 3 of 9 Extended\" is installed";
            } else {
                this.labelBarcodeFontInstalled.Text = "Warning: Font \"Free 3 of 9 Extended\" is NOT installed!!!";
            }

            StringBuilder sb = new StringBuilder();
            foreach (String us in SPD.GUI.Properties.Settings.Default.UltraSound) {
                if (!string.IsNullOrEmpty(us)) {
                    sb.Append(us).Append(Environment.NewLine);
                }
            }
            textBoxUltraSoundTemplate.Text = sb.ToString();

            textBoxLocation.Text = SPD.GUI.Properties.Settings.Default.Location;

            StringBuilder sb2 = new StringBuilder();
            foreach(string finalReportText in SPD.GUI.Properties.Settings.Default.FinalReportTextElements)
            {
                sb2.Append(finalReportText).Append(Environment.NewLine);
            }

            textBoxFinalReportTextElements.Text = sb2.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            StringCollection ultraSountTemplate = new StringCollection();
            string[] ustemplateelements = textBoxUltraSoundTemplate.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string uselement in ustemplateelements) {
                if (!string.IsNullOrEmpty(uselement)) {
                    ultraSountTemplate.Add(uselement);
                }
            }

            StringCollection finalReportTextElements = new StringCollection();
            string[] fRTextElements = textBoxFinalReportTextElements.Text.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string fRTextElement in fRTextElements) {
                if (!string.IsNullOrEmpty(fRTextElement)) {
                    finalReportTextElements.Add(fRTextElement);
                }
            }

            SPD.GUI.Properties.Settings.Default.UltraSound = ultraSountTemplate;
            SPD.GUI.Properties.Settings.Default.FinalReportTextElements = finalReportTextElements;
            SPD.GUI.Properties.Settings.Default.Barcode = listBoxPrintBarcodes.SelectedIndex == 0;
            SPD.GUI.Properties.Settings.Default.Location = textBoxLocation.Text;
            SPD.GUI.Properties.Settings.Default.Save();
            this.Close();
        }


    }
}
