using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPD.Exceptions;

namespace SPD.GUI {
    /// <summary>
    /// Error Form
    /// </summary>
    public partial class ShowErrorForm : Form {

        private SPDException spdException;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowErrorForm" /> class.
        /// </summary>
        /// <param name="spdException">The SPD exception.</param>
        public ShowErrorForm(SPDException spdException) {
            InitializeComponent();
            this.spdException = spdException;
            this.textBoxShortInfo.Text = spdException.GetShortInfo();
            this.textBoxDetails.Text = spdException.GetDetailInfo();
        }

        private void buttonExitSPD_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e) {
            Clipboard.SetText(this.spdException.GetDetailInfo());
        }

        
    }
}
