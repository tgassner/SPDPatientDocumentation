using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SPD.DAL;
using SPD.CommonObjects;
using SPD.BL.Interfaces;
using System.Windows.Forms;
using SPD.OtherObjects;

namespace SPD.BL.WCF {
    /// <summary>
    /// 
    /// </summary>
    public class SPDService : AbstractSPDBL {

        #region Backup

        /// <summary>
        /// Supportses the backup.
        /// </summary>
        /// <returns></returns>
        public override bool SupportsBackup() {
            return true;
        }

        /// <summary>
        /// Backups the path.
        /// </summary>
        /// <returns></returns>
        public override string BackupPath() {
            return DBTools.GetBackupPath();
        }

        /// <summary>
        /// Does the backup.
        /// </summary>
        /// <param name="backupPath">The backup path.</param>
        /// <returns></returns>
        public override string DoBackup(string backupPath) {
            return DBTools.Backup(backupPath);
        }

        #endregion Backup

        #region DatabaseManagement

        /// <summary>
        /// Supports DB Managemant
        /// </summary>
        /// <returns></returns>
        public override bool SupportDatabaseManagement() {
            return false;
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="databaseSettings"></param>
        public override bool SetDatabaseSettings(DatabaseSettings databaseSettings) {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not Supported
        /// </summary>
        /// <returns></returns>
        public override DatabaseSettings GetDatabaseSettings() {
            throw new NotSupportedException();
        }

        #endregion

    }
}
