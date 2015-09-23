namespace SPD.GUI {
    partial class DatabaseSettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveAndCloseSPD = new System.Windows.Forms.Button();
            this.labelDatabases = new System.Windows.Forms.Label();
            this.listBoxDatabases = new System.Windows.Forms.ListBox();
            this.groupBoxAccess = new System.Windows.Forms.GroupBox();
            this.textBoxAccessFile = new System.Windows.Forms.TextBox();
            this.labelAccessFile = new System.Windows.Forms.Label();
            this.groupBoxPostgreSQL = new System.Windows.Forms.GroupBox();
            this.labelPostgreSQLPort = new System.Windows.Forms.Label();
            this.labelPostgreSQLHostIP = new System.Windows.Forms.Label();
            this.textBoxPostgreSQLDatabase = new System.Windows.Forms.TextBox();
            this.textBoxPostgreSQLUser = new System.Windows.Forms.TextBox();
            this.textBoxPostgreSQLPort = new System.Windows.Forms.TextBox();
            this.textBoxPostgreSQLPassword = new System.Windows.Forms.TextBox();
            this.textBoxPostgreSQLHostIP = new System.Windows.Forms.TextBox();
            this.labelPostgreSQLDatabase = new System.Windows.Forms.Label();
            this.labelPostgreSQLUser = new System.Windows.Forms.Label();
            this.labelPostgreSQLPassword = new System.Windows.Forms.Label();
            this.groupBoxAccess2007 = new System.Windows.Forms.GroupBox();
            this.labelAccess2007File = new System.Windows.Forms.Label();
            this.textBoxAccess2007File = new System.Windows.Forms.TextBox();
            this.groupBoxMySql = new System.Windows.Forms.GroupBox();
            this.textBoxMySQLDatabase = new System.Windows.Forms.TextBox();
            this.labelMySQLDatabase = new System.Windows.Forms.Label();
            this.labelMySQLUser = new System.Windows.Forms.Label();
            this.textBoxMySQLUser = new System.Windows.Forms.TextBox();
            this.textBoxMySQLPassword = new System.Windows.Forms.TextBox();
            this.textBoxMySQLHostIP = new System.Windows.Forms.TextBox();
            this.textBoxMySQLPort = new System.Windows.Forms.TextBox();
            this.labelMySQLPassword = new System.Windows.Forms.Label();
            this.labelMySQLHostIP = new System.Windows.Forms.Label();
            this.labelMySQLPort = new System.Windows.Forms.Label();
            this.groupBoxAccess.SuspendLayout();
            this.groupBoxPostgreSQL.SuspendLayout();
            this.groupBoxAccess2007.SuspendLayout();
            this.groupBoxMySql.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(188, 565);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // buttonSaveAndCloseSPD
            // 
            this.buttonSaveAndCloseSPD.Location = new System.Drawing.Point(59, 565);
            this.buttonSaveAndCloseSPD.Name = "buttonSaveAndCloseSPD";
            this.buttonSaveAndCloseSPD.Size = new System.Drawing.Size(123, 23);
            this.buttonSaveAndCloseSPD.TabIndex = 1;
            this.buttonSaveAndCloseSPD.Text = "Save and Close SPD";
            this.buttonSaveAndCloseSPD.UseVisualStyleBackColor = true;
            this.buttonSaveAndCloseSPD.Click += new System.EventHandler(this.buttonSaveAndCloseSPD_Click);
            this.buttonSaveAndCloseSPD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // labelDatabases
            // 
            this.labelDatabases.AutoSize = true;
            this.labelDatabases.Location = new System.Drawing.Point(51, 13);
            this.labelDatabases.Name = "labelDatabases";
            this.labelDatabases.Size = new System.Drawing.Size(61, 13);
            this.labelDatabases.TabIndex = 2;
            this.labelDatabases.Text = "Databases:";
            // 
            // listBoxDatabases
            // 
            this.listBoxDatabases.FormattingEnabled = true;
            this.listBoxDatabases.Location = new System.Drawing.Point(54, 34);
            this.listBoxDatabases.Name = "listBoxDatabases";
            this.listBoxDatabases.Size = new System.Drawing.Size(370, 95);
            this.listBoxDatabases.TabIndex = 3;
            this.listBoxDatabases.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // groupBoxAccess
            // 
            this.groupBoxAccess.Controls.Add(this.textBoxAccessFile);
            this.groupBoxAccess.Controls.Add(this.labelAccessFile);
            this.groupBoxAccess.Location = new System.Drawing.Point(54, 135);
            this.groupBoxAccess.Name = "groupBoxAccess";
            this.groupBoxAccess.Size = new System.Drawing.Size(370, 49);
            this.groupBoxAccess.TabIndex = 4;
            this.groupBoxAccess.TabStop = false;
            this.groupBoxAccess.Text = "Access";
            // 
            // textBoxAccessFile
            // 
            this.textBoxAccessFile.Location = new System.Drawing.Point(134, 17);
            this.textBoxAccessFile.Name = "textBoxAccessFile";
            this.textBoxAccessFile.Size = new System.Drawing.Size(230, 20);
            this.textBoxAccessFile.TabIndex = 1;
            this.textBoxAccessFile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // labelAccessFile
            // 
            this.labelAccessFile.AutoSize = true;
            this.labelAccessFile.Location = new System.Drawing.Point(64, 20);
            this.labelAccessFile.Name = "labelAccessFile";
            this.labelAccessFile.Size = new System.Drawing.Size(64, 13);
            this.labelAccessFile.TabIndex = 0;
            this.labelAccessFile.Text = "Access File:";
            // 
            // groupBoxPostgreSQL
            // 
            this.groupBoxPostgreSQL.Controls.Add(this.labelPostgreSQLPort);
            this.groupBoxPostgreSQL.Controls.Add(this.labelPostgreSQLHostIP);
            this.groupBoxPostgreSQL.Controls.Add(this.textBoxPostgreSQLDatabase);
            this.groupBoxPostgreSQL.Controls.Add(this.textBoxPostgreSQLUser);
            this.groupBoxPostgreSQL.Controls.Add(this.textBoxPostgreSQLPort);
            this.groupBoxPostgreSQL.Controls.Add(this.textBoxPostgreSQLPassword);
            this.groupBoxPostgreSQL.Controls.Add(this.textBoxPostgreSQLHostIP);
            this.groupBoxPostgreSQL.Controls.Add(this.labelPostgreSQLDatabase);
            this.groupBoxPostgreSQL.Controls.Add(this.labelPostgreSQLUser);
            this.groupBoxPostgreSQL.Controls.Add(this.labelPostgreSQLPassword);
            this.groupBoxPostgreSQL.Location = new System.Drawing.Point(54, 402);
            this.groupBoxPostgreSQL.Name = "groupBoxPostgreSQL";
            this.groupBoxPostgreSQL.Size = new System.Drawing.Size(370, 157);
            this.groupBoxPostgreSQL.TabIndex = 5;
            this.groupBoxPostgreSQL.TabStop = false;
            this.groupBoxPostgreSQL.Text = "PostgreSQL  (Experimental)";
            // 
            // labelPostgreSQLPort
            // 
            this.labelPostgreSQLPort.AutoSize = true;
            this.labelPostgreSQLPort.Location = new System.Drawing.Point(39, 126);
            this.labelPostgreSQLPort.Name = "labelPostgreSQLPort";
            this.labelPostgreSQLPort.Size = new System.Drawing.Size(89, 13);
            this.labelPostgreSQLPort.TabIndex = 20;
            this.labelPostgreSQLPort.Text = "PostgreSQL Port:";
            // 
            // labelPostgreSQLHostIP
            // 
            this.labelPostgreSQLHostIP.AutoSize = true;
            this.labelPostgreSQLHostIP.Location = new System.Drawing.Point(15, 100);
            this.labelPostgreSQLHostIP.Name = "labelPostgreSQLHostIP";
            this.labelPostgreSQLHostIP.Size = new System.Drawing.Size(113, 13);
            this.labelPostgreSQLHostIP.TabIndex = 21;
            this.labelPostgreSQLHostIP.Text = "PostgreSQL Host / IP:";
            // 
            // textBoxPostgreSQLDatabase
            // 
            this.textBoxPostgreSQLDatabase.Location = new System.Drawing.Point(134, 19);
            this.textBoxPostgreSQLDatabase.Name = "textBoxPostgreSQLDatabase";
            this.textBoxPostgreSQLDatabase.Size = new System.Drawing.Size(230, 20);
            this.textBoxPostgreSQLDatabase.TabIndex = 26;
            this.textBoxPostgreSQLDatabase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // textBoxPostgreSQLUser
            // 
            this.textBoxPostgreSQLUser.Location = new System.Drawing.Point(134, 45);
            this.textBoxPostgreSQLUser.Name = "textBoxPostgreSQLUser";
            this.textBoxPostgreSQLUser.Size = new System.Drawing.Size(230, 20);
            this.textBoxPostgreSQLUser.TabIndex = 27;
            this.textBoxPostgreSQLUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // textBoxPostgreSQLPort
            // 
            this.textBoxPostgreSQLPort.Location = new System.Drawing.Point(134, 123);
            this.textBoxPostgreSQLPort.Name = "textBoxPostgreSQLPort";
            this.textBoxPostgreSQLPort.Size = new System.Drawing.Size(230, 20);
            this.textBoxPostgreSQLPort.TabIndex = 30;
            this.textBoxPostgreSQLPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // textBoxPostgreSQLPassword
            // 
            this.textBoxPostgreSQLPassword.Location = new System.Drawing.Point(134, 71);
            this.textBoxPostgreSQLPassword.Name = "textBoxPostgreSQLPassword";
            this.textBoxPostgreSQLPassword.Size = new System.Drawing.Size(230, 20);
            this.textBoxPostgreSQLPassword.TabIndex = 28;
            this.textBoxPostgreSQLPassword.UseSystemPasswordChar = true;
            this.textBoxPostgreSQLPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // textBoxPostgreSQLHostIP
            // 
            this.textBoxPostgreSQLHostIP.Location = new System.Drawing.Point(134, 97);
            this.textBoxPostgreSQLHostIP.Name = "textBoxPostgreSQLHostIP";
            this.textBoxPostgreSQLHostIP.Size = new System.Drawing.Size(230, 20);
            this.textBoxPostgreSQLHostIP.TabIndex = 29;
            this.textBoxPostgreSQLHostIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // labelPostgreSQLDatabase
            // 
            this.labelPostgreSQLDatabase.AutoSize = true;
            this.labelPostgreSQLDatabase.Location = new System.Drawing.Point(12, 22);
            this.labelPostgreSQLDatabase.Name = "labelPostgreSQLDatabase";
            this.labelPostgreSQLDatabase.Size = new System.Drawing.Size(116, 13);
            this.labelPostgreSQLDatabase.TabIndex = 13;
            this.labelPostgreSQLDatabase.Text = "PostgreSQL Database:";
            // 
            // labelPostgreSQLUser
            // 
            this.labelPostgreSQLUser.AutoSize = true;
            this.labelPostgreSQLUser.Location = new System.Drawing.Point(36, 48);
            this.labelPostgreSQLUser.Name = "labelPostgreSQLUser";
            this.labelPostgreSQLUser.Size = new System.Drawing.Size(92, 13);
            this.labelPostgreSQLUser.TabIndex = 12;
            this.labelPostgreSQLUser.Text = "PostgreSQL User:";
            // 
            // labelPostgreSQLPassword
            // 
            this.labelPostgreSQLPassword.AutoSize = true;
            this.labelPostgreSQLPassword.Location = new System.Drawing.Point(12, 74);
            this.labelPostgreSQLPassword.Name = "labelPostgreSQLPassword";
            this.labelPostgreSQLPassword.Size = new System.Drawing.Size(116, 13);
            this.labelPostgreSQLPassword.TabIndex = 11;
            this.labelPostgreSQLPassword.Text = "PostgreSQL Password:";
            // 
            // groupBoxAccess2007
            // 
            this.groupBoxAccess2007.Controls.Add(this.labelAccess2007File);
            this.groupBoxAccess2007.Controls.Add(this.textBoxAccess2007File);
            this.groupBoxAccess2007.Location = new System.Drawing.Point(54, 190);
            this.groupBoxAccess2007.Name = "groupBoxAccess2007";
            this.groupBoxAccess2007.Size = new System.Drawing.Size(370, 52);
            this.groupBoxAccess2007.TabIndex = 6;
            this.groupBoxAccess2007.TabStop = false;
            this.groupBoxAccess2007.Text = "Access 2007";
            // 
            // labelAccess2007File
            // 
            this.labelAccess2007File.AutoSize = true;
            this.labelAccess2007File.Location = new System.Drawing.Point(37, 22);
            this.labelAccess2007File.Name = "labelAccess2007File";
            this.labelAccess2007File.Size = new System.Drawing.Size(91, 13);
            this.labelAccess2007File.TabIndex = 8;
            this.labelAccess2007File.Text = "Access 2007 File:";
            // 
            // textBoxAccess2007File
            // 
            this.textBoxAccess2007File.Location = new System.Drawing.Point(134, 19);
            this.textBoxAccess2007File.Name = "textBoxAccess2007File";
            this.textBoxAccess2007File.Size = new System.Drawing.Size(230, 20);
            this.textBoxAccess2007File.TabIndex = 9;
            this.textBoxAccess2007File.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // groupBoxMySql
            // 
            this.groupBoxMySql.Controls.Add(this.textBoxMySQLDatabase);
            this.groupBoxMySql.Controls.Add(this.labelMySQLDatabase);
            this.groupBoxMySql.Controls.Add(this.labelMySQLUser);
            this.groupBoxMySql.Controls.Add(this.textBoxMySQLUser);
            this.groupBoxMySql.Controls.Add(this.textBoxMySQLPassword);
            this.groupBoxMySql.Controls.Add(this.textBoxMySQLHostIP);
            this.groupBoxMySql.Controls.Add(this.textBoxMySQLPort);
            this.groupBoxMySql.Controls.Add(this.labelMySQLPassword);
            this.groupBoxMySql.Controls.Add(this.labelMySQLHostIP);
            this.groupBoxMySql.Controls.Add(this.labelMySQLPort);
            this.groupBoxMySql.Location = new System.Drawing.Point(54, 248);
            this.groupBoxMySql.Name = "groupBoxMySql";
            this.groupBoxMySql.Size = new System.Drawing.Size(370, 148);
            this.groupBoxMySql.TabIndex = 7;
            this.groupBoxMySql.TabStop = false;
            this.groupBoxMySql.Text = "MySql (Experimental)";
            // 
            // textBoxMySQLDatabase
            // 
            this.textBoxMySQLDatabase.Location = new System.Drawing.Point(134, 12);
            this.textBoxMySQLDatabase.Name = "textBoxMySQLDatabase";
            this.textBoxMySQLDatabase.Size = new System.Drawing.Size(230, 20);
            this.textBoxMySQLDatabase.TabIndex = 1;
            this.textBoxMySQLDatabase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // labelMySQLDatabase
            // 
            this.labelMySQLDatabase.AutoSize = true;
            this.labelMySQLDatabase.Location = new System.Drawing.Point(34, 15);
            this.labelMySQLDatabase.Name = "labelMySQLDatabase";
            this.labelMySQLDatabase.Size = new System.Drawing.Size(94, 13);
            this.labelMySQLDatabase.TabIndex = 0;
            this.labelMySQLDatabase.Text = "MySQL Database:";
            // 
            // labelMySQLUser
            // 
            this.labelMySQLUser.AutoSize = true;
            this.labelMySQLUser.Location = new System.Drawing.Point(58, 41);
            this.labelMySQLUser.Name = "labelMySQLUser";
            this.labelMySQLUser.Size = new System.Drawing.Size(70, 13);
            this.labelMySQLUser.TabIndex = 8;
            this.labelMySQLUser.Text = "MySQL User:";
            // 
            // textBoxMySQLUser
            // 
            this.textBoxMySQLUser.Location = new System.Drawing.Point(134, 38);
            this.textBoxMySQLUser.Name = "textBoxMySQLUser";
            this.textBoxMySQLUser.Size = new System.Drawing.Size(230, 20);
            this.textBoxMySQLUser.TabIndex = 22;
            this.textBoxMySQLUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // textBoxMySQLPassword
            // 
            this.textBoxMySQLPassword.Location = new System.Drawing.Point(134, 64);
            this.textBoxMySQLPassword.Name = "textBoxMySQLPassword";
            this.textBoxMySQLPassword.Size = new System.Drawing.Size(230, 20);
            this.textBoxMySQLPassword.TabIndex = 23;
            this.textBoxMySQLPassword.UseSystemPasswordChar = true;
            this.textBoxMySQLPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // textBoxMySQLHostIP
            // 
            this.textBoxMySQLHostIP.Location = new System.Drawing.Point(134, 90);
            this.textBoxMySQLHostIP.Name = "textBoxMySQLHostIP";
            this.textBoxMySQLHostIP.Size = new System.Drawing.Size(230, 20);
            this.textBoxMySQLHostIP.TabIndex = 24;
            this.textBoxMySQLHostIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // textBoxMySQLPort
            // 
            this.textBoxMySQLPort.Location = new System.Drawing.Point(134, 116);
            this.textBoxMySQLPort.Name = "textBoxMySQLPort";
            this.textBoxMySQLPort.Size = new System.Drawing.Size(230, 20);
            this.textBoxMySQLPort.TabIndex = 25;
            this.textBoxMySQLPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            // 
            // labelMySQLPassword
            // 
            this.labelMySQLPassword.AutoSize = true;
            this.labelMySQLPassword.Location = new System.Drawing.Point(34, 67);
            this.labelMySQLPassword.Name = "labelMySQLPassword";
            this.labelMySQLPassword.Size = new System.Drawing.Size(94, 13);
            this.labelMySQLPassword.TabIndex = 9;
            this.labelMySQLPassword.Text = "MySQL Password:";
            // 
            // labelMySQLHostIP
            // 
            this.labelMySQLHostIP.AutoSize = true;
            this.labelMySQLHostIP.Location = new System.Drawing.Point(37, 93);
            this.labelMySQLHostIP.Name = "labelMySQLHostIP";
            this.labelMySQLHostIP.Size = new System.Drawing.Size(91, 13);
            this.labelMySQLHostIP.TabIndex = 10;
            this.labelMySQLHostIP.Text = "MySQL Host / IP:";
            // 
            // labelMySQLPort
            // 
            this.labelMySQLPort.AutoSize = true;
            this.labelMySQLPort.Location = new System.Drawing.Point(61, 119);
            this.labelMySQLPort.Name = "labelMySQLPort";
            this.labelMySQLPort.Size = new System.Drawing.Size(67, 13);
            this.labelMySQLPort.TabIndex = 14;
            this.labelMySQLPort.Text = "MySQL Port:";
            // 
            // DatabaseSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 600);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxMySql);
            this.Controls.Add(this.groupBoxAccess2007);
            this.Controls.Add(this.groupBoxPostgreSQL);
            this.Controls.Add(this.groupBoxAccess);
            this.Controls.Add(this.listBoxDatabases);
            this.Controls.Add(this.labelDatabases);
            this.Controls.Add(this.buttonSaveAndCloseSPD);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DatabaseSettings";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseSettingsForm_KeyPress);
            this.groupBoxAccess.ResumeLayout(false);
            this.groupBoxAccess.PerformLayout();
            this.groupBoxPostgreSQL.ResumeLayout(false);
            this.groupBoxPostgreSQL.PerformLayout();
            this.groupBoxAccess2007.ResumeLayout(false);
            this.groupBoxAccess2007.PerformLayout();
            this.groupBoxMySql.ResumeLayout(false);
            this.groupBoxMySql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveAndCloseSPD;
        private System.Windows.Forms.Label labelDatabases;
        private System.Windows.Forms.ListBox listBoxDatabases;
        private System.Windows.Forms.GroupBox groupBoxAccess;
        private System.Windows.Forms.GroupBox groupBoxPostgreSQL;
        private System.Windows.Forms.GroupBox groupBoxAccess2007;
        private System.Windows.Forms.GroupBox groupBoxMySql;
        private System.Windows.Forms.TextBox textBoxAccessFile;
        private System.Windows.Forms.Label labelAccessFile;
        private System.Windows.Forms.Label labelAccess2007File;
        private System.Windows.Forms.TextBox textBoxAccess2007File;
        private System.Windows.Forms.Label labelMySQLDatabase;
        private System.Windows.Forms.TextBox textBoxMySQLDatabase;
        private System.Windows.Forms.Label labelMySQLUser;
        private System.Windows.Forms.Label labelMySQLPassword;
        private System.Windows.Forms.Label labelMySQLHostIP;
        private System.Windows.Forms.Label labelPostgreSQLPassword;
        private System.Windows.Forms.Label labelPostgreSQLUser;
        private System.Windows.Forms.Label labelPostgreSQLDatabase;
        private System.Windows.Forms.Label labelMySQLPort;
        private System.Windows.Forms.Label labelPostgreSQLPort;
        private System.Windows.Forms.Label labelPostgreSQLHostIP;
        private System.Windows.Forms.TextBox textBoxMySQLUser;
        private System.Windows.Forms.TextBox textBoxMySQLPassword;
        private System.Windows.Forms.TextBox textBoxMySQLHostIP;
        private System.Windows.Forms.TextBox textBoxMySQLPort;
        private System.Windows.Forms.TextBox textBoxPostgreSQLDatabase;
        private System.Windows.Forms.TextBox textBoxPostgreSQLUser;
        private System.Windows.Forms.TextBox textBoxPostgreSQLPassword;
        private System.Windows.Forms.TextBox textBoxPostgreSQLHostIP;
        private System.Windows.Forms.TextBox textBoxPostgreSQLPort;
    }
}