using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPD.OtherObjects;
using SPD.BL.Interfaces;
using SPD.DAL;

namespace SPD.GUI {

    /// <summary>
    /// For for DB Settings
    /// </summary>
    public partial class DatabaseSettingsForm : Form {

        private ISPDBL patComp;

        /// <summary>
        /// Constructor
        /// </summary>
        public DatabaseSettingsForm(ISPDBL patComp) {
            InitializeComponent();

            this.patComp = patComp;
            DatabaseSettings databaseSettings = this.patComp.GetDatabaseSettings();
            if (databaseSettings == null) {
                this.Enabled = false;
                this.buttonCancel.Enabled = true;
                return;
            }

            foreach (String database in Enum.GetNames(new Databases().GetType())) {
                if (!Databases.Undefined.ToString().Equals(database)) {
                    this.listBoxDatabases.Items.Add(database);
                }
            }

            if (databaseSettings.Database != Databases.Undefined) {
                this.listBoxDatabases.SelectedItem = databaseSettings.Database.ToString();
            }

            this.textBoxAccessFile.Text         = databaseSettings.AccessFile;
            this.textBoxAccess2007File.Text     = databaseSettings.Access2007File;
            this.textBoxMySQLDatabase.Text      = databaseSettings.MySQLDatabase;
            this.textBoxMySQLHostIP.Text        = databaseSettings.MySQLServer;
            this.textBoxMySQLPassword.Text      = databaseSettings.MySQLPassword;
            this.textBoxMySQLPort.Text          = databaseSettings.MySQLPort;
            this.textBoxMySQLUser.Text          = databaseSettings.MySQLUser;
            this.textBoxPostgreSQLDatabase.Text = databaseSettings.PostgreSQLDatabase;
            this.textBoxPostgreSQLHostIP.Text   = databaseSettings.PostgreSQLServer;
            this.textBoxPostgreSQLPassword.Text = databaseSettings.PostgreSQLPassword;
            this.textBoxPostgreSQLPort.Text     = databaseSettings.PostgreSQLPort;
            this.textBoxPostgreSQLUser.Text     = databaseSettings.PostgreSQLUser;
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonSaveAndCloseSPD_Click(object sender, EventArgs e) {
            if (this.listBoxDatabases.SelectedItems.Count < 1) {
                MessageBox.Show("Please select one Database");
            }

            DatabaseSettings databaseSettings = new DatabaseSettings();

            databaseSettings.AccessFile = this.textBoxAccessFile.Text;
            databaseSettings.Access2007File = this.textBoxAccess2007File.Text;
            databaseSettings.MySQLDatabase = this.textBoxMySQLDatabase.Text;
            databaseSettings.MySQLServer = this.textBoxMySQLHostIP.Text;
            databaseSettings.MySQLPassword = this.textBoxMySQLPassword.Text;
            databaseSettings.MySQLPort = this.textBoxMySQLPort.Text;
            databaseSettings.MySQLUser = this.textBoxMySQLUser.Text;
            databaseSettings.PostgreSQLDatabase = this.textBoxPostgreSQLDatabase.Text;
            databaseSettings.PostgreSQLServer = this.textBoxPostgreSQLHostIP.Text;
            databaseSettings.PostgreSQLPassword = this.textBoxPostgreSQLPassword.Text;
            databaseSettings.PostgreSQLPort = this.textBoxPostgreSQLPort.Text;
            databaseSettings.PostgreSQLUser = this.textBoxPostgreSQLUser.Text;

            databaseSettings.Database = (Databases)Enum.Parse(new Databases().GetType(), this.listBoxDatabases.SelectedItem.ToString());

            this.patComp.SetDatabaseSettings(databaseSettings);

            Application.Exit();
        }

        private void DatabaseSettingsForm_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x1b) {
                this.Close();
            }
        }
    }
}
