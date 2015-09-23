using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPD.GUI {
    /// <summary>
    /// 
    /// </summary>
    public partial class ShortcutsForm : Form {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortcutsForm"/> class.
        /// </summary>
        public ShortcutsForm() {
            InitializeComponent();
            richTextBoxShortcuts.Text =
                "Simple Patient Documentation" + "\n" +
                "Shortcuts" + "\n" +
                "\n" +
                "[ALT] N	New Patient" + "\n" +
                "[ALT] F	Find Patient" + "\n" +
                "  [ALT] A	Add Visit" + "\n" +
                "  [ALT] S	Show Visit" + "\n" +
                "  [ALT] C	Change Patient" + "\n" +
                "  [ALT] H	Show Patient" + "\n" +
                "  [ALT] I	Images" + "\n" +
                "  [ALT] L	Plan Operation" + "\n" +
                "    [ALT] C	Copy to Clipboard" + "\n" +
                "    [ALT] L	Close" + "\n" +
                "  [ALT] O	Add Operation" + "\n" +
                "  [ALT] W	Show Operation" + "\n" +
                "  [ALT] R	Further Treatment" + "\n" +
                "  [ALT] N	Print Patient" + "\n" +
                "[ALT] T	Print" + "\n" +
                "  [ALT] A	Select All" + "\n" +
                "  [ALT] U	Unselect All" + "\n" +
                "  [ALT] S	Print Selected" + "\n" +
                "  [ALT] T	Print Temperature Curves" + "\n" +
                "[ALT] M	Top Most" + "\n" +
                "[ALT] S	Statistics" + "\n" +
                "  [ALT] P	Patients" + "\n" +
                "  [ALT] V	Visits" + "\n" +
                "  [ALT] O	Operations" + "\n" +
                "[ALT] B	Backup";

            richTextBoxShortcuts.Font = new Font("Arial", 11);
            richTextBoxShortcuts.Select(0, 28);
            richTextBoxShortcuts.SelectionFont = new Font("Arial", 13, FontStyle.Bold);
            richTextBoxShortcuts.Select(0, 6);
            richTextBoxShortcuts.SelectionColor = Color.Red;
            richTextBoxShortcuts.Select(7, 7);
            richTextBoxShortcuts.SelectionColor = Color.Green;
            richTextBoxShortcuts.Select(15, 13);
            richTextBoxShortcuts.SelectionColor = Color.Blue;

        }

        private void buttonOk_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}