using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.IO;
using SPD.OtherObjects;
using SPD.CommonUtilities;

namespace SPD.DAL {


    /// <summary>
    /// Provides static database tools methods
    /// </summary>
    public class DBTools {
        /// <summary>
        /// Gets the database file.
        /// </summary>
        /// <returns>Filename of the Database</returns>
        public static string GetDatabaseFile() {
            switch (DbUtil.Database) {
                case Databases.Access:
                    return SPD.DAL.Properties.Settings.Default.AccessFile;
                case Databases.Access2007:
                    return SPD.DAL.Properties.Settings.Default.Access2007File;
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Gets the database full filename.
        /// </summary>
        /// <returns>Full Filename of the Database</returns>
        public static string GetDatabaseFullFilename() {
            string path = StaticUtilities.getSPDLocalChangePath() + Path.DirectorySeparatorChar + GetDatabaseFile();

            if (!File.Exists(path))
            {
                if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + GetDatabaseFile())) {
                    File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + GetDatabaseFile(), path);
                }
            }

            return path;
        }

        /// <summary>
        /// Gets the data base file extension.
        /// </summary>
        /// <returns>Fileextension of the Database File</returns>
        private static string GetDataBaseFileExtension() {
            return new FileInfo(GetDatabaseFile()).Extension;
        }


        /// <summary>
        /// Gets the data base filename without extension.
        /// </summary>
        /// <returns>Database Filename without Extension</returns>
        private static string getDataBaseFilenameWithoutExtension() {
            return GetDatabaseFile().Substring(0, GetDatabaseFile().Length - GetDataBaseFileExtension().Length);
        }

        /// <summary>
        /// Generates the backup filename.
        /// </summary>
        /// <returns></returns>
        private static string generateBackupFilename() {
            return getDataBaseFilenameWithoutExtension() + ".001." + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + GetDataBaseFileExtension();
        }

        /// <summary>
        /// Increments the backup filename.
        /// </summary>
        /// <param name="backupFilename">The backup filename.</param>
        /// <returns></returns>
        private static string incrementBackupFilename(string backupFilename) {
            string[] backupFileparts = backupFilename.Split('.');
            int number = Int32.Parse(backupFileparts[1]) + 1;
            backupFileparts[1] = number.ToString("000");
            return backupFileparts[0] + "." + backupFileparts[1] + "." + backupFileparts[2] + "." + backupFileparts[3];
        }

        /// <summary>
        /// Backups the specified backup path.
        /// </summary>
        /// <param name="backupPath">The backup path.</param>
        /// <returns></returns>
        public static string Backup(string backupPath) {
            SPD.DAL.Properties.Settings.Default.BackupPath = backupPath;
            SPD.DAL.Properties.Settings.Default.Save();
            string log = "";
            string test = generateBackupFilename();
            string[] backuppedFiles = Directory.GetFiles(GetBackupPath(), getDataBaseFilenameWithoutExtension() + ".*.*" + GetDataBaseFileExtension());

            Array.Sort(backuppedFiles);

            try {
                for (int i = backuppedFiles.Length - 1; i >= 0; i--) {
                    if (i >= 9) { //one has to be deleted
                        File.Delete(GetBackupPath() + "\\" + backuppedFiles[i]);
                        log = log + backuppedFiles[i] + " deleted\r\n";
                    } else {
                        File.Move(backuppedFiles[i], incrementBackupFilename(backuppedFiles[i]));
                        log = log + backuppedFiles[i] + " to " + incrementBackupFilename(backuppedFiles[i]) + " renamed\r\n";
                    }

                }

                File.Copy(GetDatabaseFullFilename(), GetBackupPath() + "\\" + generateBackupFilename());
                log = log + GetDatabaseFullFilename() + " to " + GetBackupPath() + "\\" + generateBackupFilename() + " copied\r\n";
            } catch (Exception e) {
                log = "Error: " + e.ToString() + log;
            }

            return log;
        }

        /// <summary>
        /// Does the restore.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="message">The message.</param>
        /// <returns>
        /// true if OK, false if not
        /// </returns>
        public static bool Restore(string filename, out string message) {
            try {
                string dbFullFilename = GetDatabaseFullFilename();
                string dbBackupPath = dbFullFilename + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day +
                                      DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second +
                                      DateTime.Now.Millisecond + ".bak";
                if (File.Exists(dbFullFilename)) {
                    File.Move(dbFullFilename, dbBackupPath);
                }

                File.Copy(filename, dbFullFilename);

                message = dbBackupPath;
                return true;
            } catch(Exception e) {
                message = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Gets the backup path.
        /// </summary>
        /// <returns></returns>
        public static string GetBackupPath() {
            return SPD.DAL.Properties.Settings.Default.BackupPath;
        }

        /// <summary>
        /// returns is Backup is supported with DB engine
        /// </summary>
        /// <returns></returns>
        public static bool SupportsBackup() {
            return DbUtil.SupportsBackup();
        }

        /// <summary>
        /// Gets the DB Settings from the Settings
        /// </summary>
        /// <returns></returns>
        public static DatabaseSettings GetDatabaseSettings() {
            DatabaseSettings databaseSettings = new DatabaseSettings();
            databaseSettings.Access2007File     = SPD.DAL.Properties.Settings.Default.Access2007File;
            databaseSettings.AccessFile         = SPD.DAL.Properties.Settings.Default.AccessFile;
            databaseSettings.Database           = SPD.DAL.Properties.Settings.Default.Database;
            databaseSettings.MySQLDatabase      = SPD.DAL.Properties.Settings.Default.MySQLDatabase;
            databaseSettings.MySQLPassword      = SPD.DAL.Properties.Settings.Default.MySQLPassword;
            databaseSettings.MySQLPort          = SPD.DAL.Properties.Settings.Default.MySQLPort;
            databaseSettings.MySQLServer        = SPD.DAL.Properties.Settings.Default.MySQLServer;
            databaseSettings.MySQLUser          = SPD.DAL.Properties.Settings.Default.MySQLUser;
            databaseSettings.PostgreSQLDatabase = SPD.DAL.Properties.Settings.Default.PostgreSQLDatabase;
            databaseSettings.PostgreSQLPassword = SPD.DAL.Properties.Settings.Default.PostgreSQLPassword;
            databaseSettings.PostgreSQLPort     = SPD.DAL.Properties.Settings.Default.PostgreSQLPort;
            databaseSettings.PostgreSQLServer   = SPD.DAL.Properties.Settings.Default.PostgreSQLServer;
            databaseSettings.PostgreSQLUser     = SPD.DAL.Properties.Settings.Default.PostgreSQLUser;
            return databaseSettings;
        }

        /// <summary>
        /// Sets the DB Settings from the Settings
        /// </summary>
        /// <param name="databaseSettings"></param>
        /// <returns></returns>
        public static bool SetDatabaseSettings(DatabaseSettings databaseSettings) {
            if (databaseSettings == null) {
                return false;
            }
            SPD.DAL.Properties.Settings.Default.Access2007File = databaseSettings.Access2007File;
            SPD.DAL.Properties.Settings.Default.AccessFile = databaseSettings.AccessFile;
            SPD.DAL.Properties.Settings.Default.Database = databaseSettings.Database;
            SPD.DAL.Properties.Settings.Default.MySQLDatabase = databaseSettings.MySQLDatabase;
            SPD.DAL.Properties.Settings.Default.MySQLPassword = databaseSettings.MySQLPassword;
            SPD.DAL.Properties.Settings.Default.MySQLPort = databaseSettings.MySQLPort;
            SPD.DAL.Properties.Settings.Default.MySQLServer = databaseSettings.MySQLServer;
            SPD.DAL.Properties.Settings.Default.MySQLUser = databaseSettings.MySQLUser;
            SPD.DAL.Properties.Settings.Default.PostgreSQLDatabase = databaseSettings.PostgreSQLDatabase;
            SPD.DAL.Properties.Settings.Default.PostgreSQLPassword = databaseSettings.PostgreSQLPassword;
            SPD.DAL.Properties.Settings.Default.PostgreSQLPort = databaseSettings.PostgreSQLPort;
            SPD.DAL.Properties.Settings.Default.PostgreSQLServer = databaseSettings.PostgreSQLServer;
            SPD.DAL.Properties.Settings.Default.PostgreSQLUser = databaseSettings.PostgreSQLUser;

            SPD.DAL.Properties.Settings.Default.Save();

            return true;
        }
    }
}
