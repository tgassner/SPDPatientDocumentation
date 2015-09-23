using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using SPD.BL.WCF;


namespace SPD.WCFService.Host {
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form {
        private bool serverRuns = false;
        private ServiceHost spdHost;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm() {
            InitializeComponent();
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (serverRuns) {
                MessageBox.Show("Please shutdown the server before exiting.");
                e.Cancel = true;
            }
        }

        private void doLog(ServiceHost spdHost){
            textBoxState.Text = "Service started. " + DateTime.Now + " \r\n" + textBoxState.Text;
            textBoxState.Text = "Service status: " + spdHost.State.ToString() + " " + DateTime.Now + " \r\n" + textBoxState.Text;
            textBoxState.Text = "-------------------------------------\r\n" + textBoxState.Text;
        }

        private void startServer() {
            //using(spdHost = new ServiceHost(typeof(SPDService))){
            spdHost = new ServiceHost(typeof(SPDService));
            spdHost.Open();
            if (spdHost.State == CommunicationState.Opened) {
                doLog(spdHost);
                textBoxAddresses.Text = "";
                foreach (var endpoints in spdHost.Description.Endpoints) {
                    textBoxAddresses.Text = endpoints.Address.ToString() + "\r\n" + textBoxAddresses.Text;
                }
                serverRuns = true;
            } else {
                doLog(spdHost);
            }
        }

        private void stopServer() {
            //using (spdHost) {
            spdHost.Close();
            doLog(spdHost);
            serverRuns = false;
            //}
        }

        private void buttonStartStopServer_Click(object sender, EventArgs e) {
            if (serverRuns) {
                this.stopServer();
                this.buttonExit.Enabled = true;
                serverRuns = false;
                this.buttonStartStopServer.Text = "Start Server";
                this.textBoxAddresses.Text = "";
            } else {
                this.startServer();
                if (serverRuns) {
                    this.buttonExit.Enabled = false;
                    serverRuns = true;
                    this.buttonStartStopServer.Text = "Stop Server";
                }
            }

        }

        private void buttonExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
