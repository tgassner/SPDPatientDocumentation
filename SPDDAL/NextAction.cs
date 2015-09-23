using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SPD.CommonObjects;
using System.Globalization;
using SPD.DAL;
using MySql.Data.MySqlClient;

namespace SPD.DAL {
    class NextAction : INextAction {

        const string SQL_FIND_BY_ID = "SELECT * FROM nextAction WHERE nextActionID = @nextActionID";
        const string SQL_FIND_BY_PATIENT_ID = "SELECT * FROM nextAction WHERE PatientID = @PatientID";
        const string SQL_FIND_ALL = "SELECT * FROM nextAction";
        readonly string SQL_UPDATE_BY_ID = "UPDATE nextAction SET PatientID = @PatientID, actionkind = @actionkind, actionyear = @actionyear, actionhalfyear = @actionhalfyear, todo = @todo WHERE nextActionID = @nextActionID";
        readonly string SQL_INSERT_BY_ID = "INSERT INTO nextAction (PatientID, actionkind, actionyear, actionhalfyear, todo) VALUES(@PatientID, @actionkind, @actionyear, @actionhalfyear, @todo)";
        readonly string SQL_DELETE_BY_ID = "DELETE FROM nextAction WHERE nextActionID = @nextActionID";
        readonly string SQL_FIND_PATIENTID_BY_YEAR_HALFYEAR_ACTIONKIND = "SELECT PatientID FROM nextAction where actionyear = @actionyear AND actionhalfyear = @actionhalfyear AND actionkind = @actionkind";
        static IDbCommand findByIdCmd;
        static IDbCommand findAllCmd;
        static IDbCommand findByPatientIdCmd;
        static IDbCommand updateByIdCmd;
        static IDbCommand insertByIdCmd;
        static IDbCommand deleteByIdCmd;
        static IDbCommand lastInsertedRowCmd = null;
        static IDbCommand findPatientIdByYearHalfYearActionDataCmd;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private NextActionData fillNextAction(IDataReader rdr) {
            NextActionData nextAction = new NextActionData();

            nextAction.NextActionID = Convert.ToInt64(rdr["nextActionID"]);
            nextAction.PatientID = Convert.ToInt64(rdr["PatientID"]);
            nextAction.ActionKind = (ActionKind)Convert.ToInt64(rdr["actionkind"]);                                             
            nextAction.ActionYear = Convert.ToInt64(rdr["actionyear"]);
            nextAction.ActionhalfYear = Convert.ToInt64(rdr["actionhalfyear"]);
            nextAction.Todo = Convert.ToString(rdr["todo"]);
                            
            return nextAction;
        }

        public IList<NextActionData> FindAll() {
            try {
                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findAllCmd == null) {
                    findAllCmd = DbUtil.CreateCommand(SQL_FIND_ALL, DbUtil.CurrentConnection);
                }

                using (IDataReader rdr = findAllCmd.ExecuteReader()) {
                    IList<NextActionData> nextActionList = new List<NextActionData>();
                    while (rdr.Read()) {
                        nextActionList.Add(fillNextAction(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Get all next actions: " + nextActionList.Count + " " + ((tend - tstart) / 10000) + "ms");
                    return nextActionList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }
        
        public NextActionData FindById(long id) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByIdCmd == null) {
                    findByIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_ID, DbUtil.CurrentConnection);
                    findByIdCmd.Parameters.Add(DbUtil.CreateParameter("@nextActionID", DbType.Int64));
                }

                ((IDataParameter)findByIdCmd.Parameters["@nextActionID"]).Value = id;
                
                using (IDataReader rdr = findByIdCmd.ExecuteReader()) {
                    IList<PatientData> patientList = new List<PatientData>();
                    if (rdr.Read()) {
                        long tend = DateTime.Now.Ticks;
                        log.Info("Find NextAction by Id OK: " + id + " " + ((tend - tstart) / 10000) + "ms");
                        return fillNextAction(rdr);
                    }
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
            log.Info("Find NextAction by Id NOT FOUND: " + id);
            return null;
        }

        public long Insert(NextActionData nextAction) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (insertByIdCmd == null) {
                    insertByIdCmd = DbUtil.CreateCommand(SQL_INSERT_BY_ID + DbUtil.GetAppendix("nextActionID"), DbUtil.CurrentConnection);
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@PatientID", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@actionkind", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@actionyear", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@actionhalfyear", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@todo", DbType.String));
                }

                ((IDataParameter)insertByIdCmd.Parameters["@PatientID"]).Value = nextAction.PatientID;
                ((IDataParameter)insertByIdCmd.Parameters["@actionkind"]).Value = (long)nextAction.ActionKind;
                ((IDataParameter)insertByIdCmd.Parameters["@actionyear"]).Value = nextAction.ActionYear;
                ((IDataParameter)insertByIdCmd.Parameters["@actionhalfyear"]).Value = nextAction.ActionhalfYear;
                ((IDataParameter)insertByIdCmd.Parameters["@todo"]).Value = nextAction.Todo;

                //bool ok = insertByIdCmd.ExecuteNonQuery() == 1;
                Object insertRet = insertByIdCmd.ExecuteScalar();

                long tend = DateTime.Now.Ticks;
                log.Info("Insert next action: Patient: " + insertRet + " " + ((tend - tstart) / 10000) + "ms");

                return DbUtil.getGeneratedId((IDbCommand)insertByIdCmd, lastInsertedRowCmd, insertRet);
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool Update(NextActionData nextAction) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (updateByIdCmd == null) {
                    updateByIdCmd = DbUtil.CreateCommand(SQL_UPDATE_BY_ID, DbUtil.CurrentConnection);

                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@PatientID", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@actionkind", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@actionyear", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@actionhalfyear", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@todo", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@nextActionID", DbType.Int64));
                }

                ((IDataParameter)updateByIdCmd.Parameters["@PatientID"]).Value = nextAction.PatientID;
                ((IDataParameter)updateByIdCmd.Parameters["@actionkind"]).Value = (long)nextAction.ActionKind;
                ((IDataParameter)updateByIdCmd.Parameters["@actionyear"]).Value = nextAction.ActionYear;
                ((IDataParameter)updateByIdCmd.Parameters["@actionhalfyear"]).Value = nextAction.ActionhalfYear;
                ((IDataParameter)updateByIdCmd.Parameters["@todo"]).Value = nextAction.Todo;
                ((IDataParameter)updateByIdCmd.Parameters["@nextActionID"]).Value = nextAction.NextActionID;

                bool ok = updateByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Update next Action: " + nextAction.NextActionID + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool Delete(long id) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (deleteByIdCmd == null) {
                    deleteByIdCmd = DbUtil.CreateCommand(SQL_DELETE_BY_ID, DbUtil.CurrentConnection);
                    deleteByIdCmd.Parameters.Add(DbUtil.CreateParameter("@nextActionID", DbType.Int64));
                }

                ((IDataParameter)deleteByIdCmd.Parameters["@nextActionID"]).Value = id;

                bool ok = deleteByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Delete Next Action: " + id + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public IList<NextActionData> FindByPatientId(long patientId)
        {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByPatientIdCmd == null) {
                    findByPatientIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_PATIENT_ID, DbUtil.CurrentConnection);
                    findByPatientIdCmd.Parameters.Add(DbUtil.CreateParameter("@PatientID", DbType.Int64));
                }

                ((IDataParameter)findByPatientIdCmd.Parameters["@PatientID"]).Value = patientId;

                using (IDataReader rdr = findByPatientIdCmd.ExecuteReader()) {
                    IList<NextActionData> nextActionList = new List<NextActionData>();
                    while (rdr.Read()) {
                        nextActionList.Add(fillNextAction(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Find Next Action by PatientID: " + patientId + " Count: " + nextActionList.Count + " " + ((tend - tstart) / 10000) + "ms");
                    return nextActionList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally
            {
                DbUtil.CloseConnection();
            }
        }

        public IList<long> FindPatientIdsByYearHalfYearAndActionKind(long year, long halfYear, ActionKind actionKind) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findPatientIdByYearHalfYearActionDataCmd == null) {
                    findPatientIdByYearHalfYearActionDataCmd = DbUtil.CreateCommand(SQL_FIND_PATIENTID_BY_YEAR_HALFYEAR_ACTIONKIND, DbUtil.CurrentConnection);
                    findPatientIdByYearHalfYearActionDataCmd.Parameters.Add(DbUtil.CreateParameter("@actionyear", DbType.Int64));
                    findPatientIdByYearHalfYearActionDataCmd.Parameters.Add(DbUtil.CreateParameter("@actionhalfyear", DbType.Int64));
                    findPatientIdByYearHalfYearActionDataCmd.Parameters.Add(DbUtil.CreateParameter("@actionkind", DbType.Int64));
                }

                ((IDataParameter)findPatientIdByYearHalfYearActionDataCmd.Parameters["@actionyear"]).Value = year;
                ((IDataParameter)findPatientIdByYearHalfYearActionDataCmd.Parameters["@actionhalfyear"]).Value = halfYear;
                ((IDataParameter)findPatientIdByYearHalfYearActionDataCmd.Parameters["@actionkind"]).Value = (long)actionKind;

                using (IDataReader rdr = findPatientIdByYearHalfYearActionDataCmd.ExecuteReader()) {
                    IList<long> patientIds = new List<long>();
                    while (rdr.Read()) {
                        patientIds.Add((long)(int)rdr["PatientID"]);
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Find PatientIds By Year HalfYear And ActionKind Year: " + year + " HalfYear: " + halfYear + " ActionKind: " + actionKind.ToString() + " Count: " + patientIds.Count + " " + ((tend - tstart) / 10000) + "ms");
                    return patientIds;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public IList<long> GetAllNextActionYears() {

            long tstart = DateTime.Now.Ticks;

            List<long> years = new List<long>();

            IList<NextActionData> allNextActions = this.FindAll();

            foreach (NextActionData nextAction in allNextActions) {
                if (!years.Contains(nextAction.ActionYear)) {
                    years.Add(nextAction.ActionYear);
                }
            }

            years.Sort();

            long tend = DateTime.Now.Ticks;

            log.Info("Get NExt Action Years: " + years + " " + ((tend - tstart) / 10000) + "ms");

            return years;
        }
    }
}
