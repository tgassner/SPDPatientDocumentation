using System;
using System.Collections.Generic;
using System.Text;
using SPD.CommonObjects;
using System.Data;
using SPD.CommonUtilities;

namespace SPD.DAL {
    /// <summary>
    /// 
    /// </summary>
    public class DiagnoseGroup : IDiagnoseGroup{

        /// <summary>
        /// Name of the Diagnose Group Table
        /// </summary>
        public const string diagnoseGroup = "diagnoseGroup";
        /// <summary>
        /// Name of the Column diagnoseGroupID in the table diagnoseGroup
        /// </summary>
        public const string diagnoseGroupID = "diagnoseGroupID";
        /// <summary>
        /// Name of the Column shortDescr in the table diagnoseGroup
        /// </summary>
        public const string shortDescr = "shortDescr";
        /// <summary>
        /// Name of the Column longDescr in the table diagnoseGroup
        /// </summary>
        public const string longDescr = "longDescr";

        /// <summary>
        /// Name of the Patient - Diagnose Group Table
        /// </summary>
        public const string patientDiagnoseGroup = "patientDiagnoseGroup";
        /// <summary>
        /// Patient Id
        /// </summary>
        public const string patientID = "patientID";


        const string SQL_FIND_BY_ID = "SELECT * FROM " + diagnoseGroup + " WHERE " + diagnoseGroupID + " = @" + diagnoseGroupID;
        const string SQL_FIND_ALL = "SELECT * FROM " + diagnoseGroup;
        const string SQL_FIND_ALL_PATIENT_DIAGNOSE_GROUP = "SELECT * FROM " + patientDiagnoseGroup;

        readonly string SQL_INSERT_BY_ID =
                    "INSERT INTO " + diagnoseGroup + " " +
                    "  (" + shortDescr + ", " + longDescr + ") " +
                    " VALUES(@" + shortDescr + ", @" + longDescr + ")";

        readonly string SQL_DELETE_BY_ID = "DELETE FROM " + diagnoseGroup + " WHERE " + diagnoseGroupID + " = @" + diagnoseGroupID + "";

        readonly string SQL_UPDATE_BY_ID =
            "UPDATE " + diagnoseGroup + " SET " +
            "  " + shortDescr + " = @" + shortDescr + ", " +
            "  " + longDescr + " = @" + longDescr + " " +
            "WHERE " +
            "  " + diagnoseGroupID + " = @" + diagnoseGroupID + "";

        readonly string SQL_ASSIGN_PATIENT_TO_DIAGNOSEGROUP = "insert into " + patientDiagnoseGroup + " (" + patientID + ", " + diagnoseGroupID + ") values(@" + patientID+ ", @" + diagnoseGroupID + ")";
        readonly string SQL_UNASSIGN_PATIENT_FROM_DIAGNOSEGROUP = "delete from " + patientDiagnoseGroup + " where " + patientID + " = @" + patientID + " and " + diagnoseGroupID + " = @" + diagnoseGroupID;

        static IDbCommand updateByIdCmd;
        static IDbCommand insertByIdCmd;
        static IDbCommand deleteByIdCmd;
        static IDbCommand lastInsertedRowCmd = null;
        //static IDbCommand findByIdCmd;
        static IDbCommand findAllCmd;
        static IDbCommand findAllPatientDiagnoseGroupCmd;
        static IDbCommand assignCmd;
        static IDbCommand unAssignCmd;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        public IList<DiagnoseGroupData> FindAll() {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findAllCmd == null) {
                    findAllCmd = DbUtil.CreateCommand(SQL_FIND_ALL, DbUtil.CurrentConnection);
                }

                using (IDataReader rdr = findAllCmd.ExecuteReader()) {
                    IList<DiagnoseGroupData> diagnoseGroupList = new List<DiagnoseGroupData>();

                    while (rdr.Read()) {
                        diagnoseGroupList.Add(fillDiagnoseGroupObject(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Get All DiagnoseGroups: " + diagnoseGroupList.Count + " " + ((tend - tstart) / 10000) + "ms");
                    return diagnoseGroupList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        private DiagnoseGroupData fillDiagnoseGroupObject(IDataReader rdr) {
            DiagnoseGroupData dgd = new DiagnoseGroupData();
            dgd.DiagnoseGroupDataID = Convert.ToInt64(rdr[diagnoseGroupID]);
            dgd.ShortName = Convert.ToString(rdr[shortDescr]);
            dgd.LongName = Convert.ToString(rdr[longDescr]);
            return dgd;
        }

        /// <summary>
        /// Finds the by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public DiagnoseGroupData FindByID(long id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the specified diagnose group.
        /// </summary>
        /// <param name="diagnoseGroup">The diagnose group.</param>
        /// <returns></returns>
        public long Insert(DiagnoseGroupData diagnoseGroup) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (insertByIdCmd == null) {
                    insertByIdCmd = DbUtil.CreateCommand(SQL_INSERT_BY_ID + DbUtil.GetAppendix(diagnoseGroupID), DbUtil.CurrentConnection);
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@" + shortDescr, DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@" + longDescr, DbType.String));
                }

                ((IDataParameter)insertByIdCmd.Parameters["@" + shortDescr]).Value = diagnoseGroup.ShortName;
                ((IDataParameter)insertByIdCmd.Parameters["@" + longDescr]).Value = diagnoseGroup.LongName;

                Object insertRet = insertByIdCmd.ExecuteScalar();

                long tend = DateTime.Now.Ticks;
                log.Info("Insert DiagnoseGroup: " + insertRet + " " + ((tend - tstart) / 10000) + "ms");

                return DbUtil.getGeneratedId((IDbCommand)insertByIdCmd, lastInsertedRowCmd, insertRet);
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        /// <summary>
        /// Updates the specified diagnose group.
        /// </summary>
        /// <param name="diagnoseGroup">The diagnose group.</param>
        /// <returns></returns>
        public bool Update(DiagnoseGroupData diagnoseGroup) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (updateByIdCmd == null) {
                    updateByIdCmd = DbUtil.CreateCommand(SQL_UPDATE_BY_ID, DbUtil.CurrentConnection);

                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@" + shortDescr, DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@" + longDescr, DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@" + diagnoseGroupID, DbType.Int64));
                }

                ((IDataParameter)updateByIdCmd.Parameters["@" + shortDescr]).Value = diagnoseGroup.ShortName;
                ((IDataParameter)updateByIdCmd.Parameters["@" + longDescr]).Value = diagnoseGroup.LongName;
                ((IDataParameter)updateByIdCmd.Parameters["@" + diagnoseGroupID]).Value = diagnoseGroup.DiagnoseGroupDataID;

                bool ok = updateByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Update DiagnoseGroup: " + diagnoseGroup.DiagnoseGroupDataID + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool Delete(long id) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (deleteByIdCmd == null) {
                    deleteByIdCmd = DbUtil.CreateCommand(SQL_DELETE_BY_ID, DbUtil.CurrentConnection);
                    deleteByIdCmd.Parameters.Add(DbUtil.CreateParameter("@" + diagnoseGroupID, DbType.Int64));
                }

                ((IDataParameter)deleteByIdCmd.Parameters["@" + diagnoseGroupID]).Value = id;

                bool ok = deleteByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Delete Diagnose Group: " + id + " " + ok.ToString() + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        /// <summary>
        /// Gets all patient diagnose group.
        /// </summary>
        /// <returns></returns>
        public IList<Pair<long, long>> GetAllPatientDiagnoseGroup() {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findAllPatientDiagnoseGroupCmd == null) {
                    findAllPatientDiagnoseGroupCmd = DbUtil.CreateCommand(SQL_FIND_ALL_PATIENT_DIAGNOSE_GROUP, DbUtil.CurrentConnection);
                }

                using (IDataReader rdr = findAllPatientDiagnoseGroupCmd.ExecuteReader()) {
                    IList<Pair<long, long>> patientDiagnoseGroupList = new List<Pair<long, long>>();

                    while (rdr.Read()) {
                        Pair<long, long> pair = new Pair<long, long>();
                        pair.First = Convert.ToInt64(rdr[patientID]);;
                        pair.Second = Convert.ToInt64(rdr[diagnoseGroupID]);
                        patientDiagnoseGroupList.Add(pair);
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Get All PatientDiagnoseGroups: " + patientDiagnoseGroupList.Count + " " + ((tend - tstart) / 10000) + "ms");
                    return patientDiagnoseGroupList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        /// <summary>
        /// Assigns the P atient to diagnose group.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public bool AssignPatientToDiagnoseGroup(long pId, long dgId) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (assignCmd == null) {
                    assignCmd = DbUtil.CreateCommand(SQL_ASSIGN_PATIENT_TO_DIAGNOSEGROUP, DbUtil.CurrentConnection);
                    assignCmd.Parameters.Add(DbUtil.CreateParameter("@" + patientID, DbType.Int64));
                    assignCmd.Parameters.Add(DbUtil.CreateParameter("@" + diagnoseGroupID, DbType.Int64));
                }

                ((IDataParameter)assignCmd.Parameters["@" + patientID]).Value = pId;
                ((IDataParameter)assignCmd.Parameters["@" + diagnoseGroupID]).Value = dgId;

                bool ok = assignCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Assign Patient: " + pId + " Diagnose Group: " + dgId + " " + ok.ToString() + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        /// <summary>
        /// Uns the assign P atient to diagnose group.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public bool UnAssignPatientToDiagnoseGroup(long pId, long dgId) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (unAssignCmd == null) {
                    unAssignCmd = DbUtil.CreateCommand(SQL_UNASSIGN_PATIENT_FROM_DIAGNOSEGROUP, DbUtil.CurrentConnection);
                    unAssignCmd.Parameters.Add(DbUtil.CreateParameter("@" + patientID, DbType.Int64));
                    unAssignCmd.Parameters.Add(DbUtil.CreateParameter("@" + diagnoseGroupID, DbType.Int64));
                }

                ((IDataParameter)unAssignCmd.Parameters["@" + patientID]).Value = pId;
                ((IDataParameter)unAssignCmd.Parameters["@" + diagnoseGroupID]).Value = dgId;

                bool ok = unAssignCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Unassign Patient: " + pId + " Diagnose Group: " + dgId + " " + ok.ToString() + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

    }
}
