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
    public partial class PrintSelectionForm : Form {
        private bool operations;
        private bool visits;
        private bool furtherTreatment;
        private bool photoLinks;
        private bool ok;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintSelectionForm"/> class.
        /// </summary>
        public PrintSelectionForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PrintSelectionForm"/> is operations.
        /// </summary>
        /// <value><c>true</c> if operations; otherwise, <c>false</c>.</value>
        public bool Operations {
            get { return this.operations; }
            protected set { this.operations = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PrintSelectionForm"/> is visits.
        /// </summary>
        /// <value><c>true</c> if visits; otherwise, <c>false</c>.</value>
        public bool Visits {
            get { return this.visits; }
            protected set { this.visits = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [further treatment].
        /// </summary>
        /// <value><c>true</c> if [further treatment]; otherwise, <c>false</c>.</value>
        public bool FurtherTreatment {
            get { return this.furtherTreatment; }
            protected set { this.furtherTreatment = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [photo links].
        /// </summary>
        /// <value><c>true</c> if [photo links]; otherwise, <c>false</c>.</value>
        public bool PhotoLinks {
            get { return this.photoLinks; }
            protected set { this.photoLinks = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PrintSelectionForm"/> is ok.
        /// </summary>
        /// <value><c>true</c> if ok; otherwise, <c>false</c>.</value>
        public bool Ok {
            get { return ok; }
            protected set { ok = value; }
        }

        /// <summary>
        /// Handles the Click event of the buttonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonCancel_Click(object sender, EventArgs e) {
            ok = false;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the buttonOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonOK_Click(object sender, EventArgs e) {
            ok = true;
            this.operations = checkBoxOperations.Checked;
            this.visits = checkBoxVisits.Checked;
            this.furtherTreatment = checkBoxFurtherTreatment.Checked;
            this.photoLinks = checkBoxPhotoLinks.Checked;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the buttonAllDataOfPatient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonAllDataOfPatient_Click(object sender, EventArgs e) {
            ok = true;
            operations = true;
            visits = true;
            furtherTreatment = true;
            photoLinks = true;
            this.Close();
        }

        private void PrintSelectionForm_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x1b) {
                this.Close();
            }
        }
    }
}