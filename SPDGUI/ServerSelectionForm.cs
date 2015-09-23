using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPD.CommonObjects;
using SPD.OtherObjects;

namespace SPD.GUI {

    /// <summary>
    /// 
    /// </summary>
    public partial class ServerSelectionForm : Form {

        private void initForm() {
            ServiceType serviceType = (ServiceType)SPD.GUI.Properties.Settings.Default.service;
            WCFProtocol wcfProtocoll = (WCFProtocol)SPD.GUI.Properties.Settings.Default.WCFProtocol;
            textBoxPort.Text = SPD.GUI.Properties.Settings.Default.WCFPort.ToString();
            textBoxServiceHost.Text = SPD.GUI.Properties.Settings.Default.WCFHost.ToString();

            switch (serviceType) {
                case ServiceType.local:
                    radioButtonLocal.Checked = true;
                    break;
                case ServiceType.WCF:
                    radioButtonWCF.Checked = true;
                    break;
                default:
                    break;
            }

            switch (wcfProtocoll) {
                case WCFProtocol.http:
                    radioButtonHTTP.Checked = true;
                    break;
                case WCFProtocol.tcp:
                    radioButtonTCP.Checked = true;
                    break;
                case WCFProtocol.namedPipe:
                    radioButtonNamesPipes.Checked = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerSelectionForm"/> class.
        /// </summary>
        public ServerSelectionForm() {
            InitializeComponent();
            initForm();
            this.buttonConnect.Select();
        }

        private void buttonUndo_Click(object sender, EventArgs e) {
            initForm();
        }

        private void buttonConnect_Click(object sender, EventArgs e) {
            uint port;
            try {
                port = UInt32.Parse(textBoxPort.Text);
            }catch(Exception){
                MessageBox.Show("The Port has to be a unsigned number");
                return;
            }
            
            uint serviceType = 0;
            uint wcfProtocol = 0;



            if (radioButtonLocal.Checked) {
                serviceType = 0;
            }
            if (radioButtonWCF.Checked) {
                serviceType = 1;
            }

            if (radioButtonHTTP.Checked) {
                wcfProtocol = 0;
            }
            if (radioButtonTCP.Checked) {
                wcfProtocol = 1;
            }
            if (radioButtonNamesPipes.Checked) {
                wcfProtocol = 2;
            }

            SPD.GUI.Properties.Settings.Default.service = serviceType;;
            SPD.GUI.Properties.Settings.Default.WCFProtocol = wcfProtocol;
            SPD.GUI.Properties.Settings.Default.WCFPort = port;
            SPD.GUI.Properties.Settings.Default.WCFHost = textBoxServiceHost.Text;

            SPD.GUI.Properties.Settings.Default.Save();

            this.Close();

        }

        /// <summary>
        /// Gets the end point data.
        /// </summary>
        /// <returns></returns>
        public static EndpointData GetEndPointData(){
            return new EndpointData(SPD.GUI.Properties.Settings.Default.WCFHost,
                SPD.GUI.Properties.Settings.Default.WCFPort,
                (WCFProtocol)SPD.GUI.Properties.Settings.Default.WCFProtocol
                );
        }
    }
}
