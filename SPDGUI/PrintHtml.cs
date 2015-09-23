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
    public partial class PrintHtml : Form {
        
        /// <summary>
        /// 
        /// </summary>
        public PrintHtml() {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public WebBrowser PrintWebBrowser {
            get { return this.webBrowser1; }
        }

        private void buttonPrint_Click(object sender, EventArgs e) {
            this.webBrowser1.ShowPrintDialog();
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void PrintHtml_Resize(object sender, EventArgs e) {
            this.webBrowser1.Width = this.Width - 12;
            this.webBrowser1.Height = this.Height - 70;
            this.buttonPrint.Location = new System.Drawing.Point(0, this.Height - 62);
            this.buttonClose.Location = new System.Drawing.Point(82, this.Height - 62);
        }

        private void PrintHtml_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x1b) {
                this.Close();
            }
        }
    }
}
