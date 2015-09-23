using System;
using System.Collections.Generic;
using System.Text;
using SPD.CommonObjects;
using System.Data;
using System.Globalization;
using SPD.DAL;

namespace SPD.DAL {
    
    class Visit : IVisit {

        const string SQL_FIND_BY_ID = "SELECT * FROM visit WHERE VisitID = @VisitID";
        const string SQL_FIND_BY_PATIENT_ID = "SELECT * FROM visit WHERE patientid = @patientid";
        const string SQL_FIND_ALL = "SELECT * FROM visit";
        readonly string SQL_UPDATE_BY_ID = "UPDATE visit SET cause = @cause, localis = @localis, extradiagnosis = @extradiagnosis, prozedure = @prozedure, extratherapy = @extratherapy, anesthesiology = @anesthesiology, ultrasound = @ultrasound, blooddiagnostic = @blooddiagnostic, todo = @todo, radiodiagnostics = @radiodiagnostics WHERE VisitID = @VisitID";
        readonly string SQL_INSERT_BY_ID = "INSERT INTO visit (cause, localis, extradiagnosis, prozedure, extratherapy, patientid, visitdate, anesthesiology, ultrasound, blooddiagnostic, todo, radiodiagnostics) VALUES(@cause, @localis, @extradiagnosis, @prozedure, @extratherapy, @patientid, @visitdate, @anesthesiology, @ultrasound, @blooddiagnostic, @todo, @radiodiagnostics)";
        readonly string SQL_DELETE_BY_ID = "DELETE FROM visit WHERE VisitID = @VisitID";
        static IDbCommand findByIdCmd;
        static IDbCommand findByPatientIdCmd;
        static IDbCommand findAllCmd;
        static IDbCommand updateByIdCmd;
        static IDbCommand insertByIdCmd;
        static IDbCommand deleteByIdCmd;
        static IDbCommand lastInsertedRowCmd = null;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private VisitData fillVisitData(IDataReader rdr) {
            VisitData visit = new VisitData();

            visit.Id = Convert.ToInt64(rdr["VisitID"]);
            visit.Cause = Convert.ToString(rdr["cause"]);
            visit.Localis = Convert.ToString(rdr["localis"]);
            visit.ExtraDiagnosis = Convert.ToString(rdr["extradiagnosis"]);
            visit.Procedure = Convert.ToString(rdr["prozedure"]);
            visit.ExtraTherapy = Convert.ToString(rdr["extratherapy"]);
            visit.PatientId = Convert.ToInt64(rdr["patientid"]);
            visit.VisitDate = DateTime.Parse((string)rdr["visitdate"], DateTimeFormatInfo.InvariantInfo);
            visit.Anesthesiology = Convert.ToString(rdr["anesthesiology"]);
            visit.Ultrasound = Convert.ToString(rdr["ultrasound"]);
            visit.Blooddiagnostic = Convert.ToString(rdr["blooddiagnostic"]);
            visit.Todo = Convert.ToString(rdr["todo"]);
            visit.Radiodiagnostics = Convert.ToString(rdr["radiodiagnostics"]);

            return visit;
        }

        public IList<VisitData> FindAll() {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findAllCmd == null) {
                    findAllCmd = DbUtil.CreateCommand(SQL_FIND_ALL, DbUtil.CurrentConnection);
                }



                using (IDataReader rdr = findAllCmd.ExecuteReader()) {
                    IList<VisitData> visitList = new List<VisitData>();
                    while (rdr.Read()) {
                        visitList.Add(fillVisitData(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Find All all Visits: " + visitList.Count + " " + ((tend - tstart) / 10000) + "ms");

                    return visitList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }

        }

        public VisitData FindByID(long id) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByIdCmd == null) {
                    findByIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_ID, DbUtil.CurrentConnection);
                    findByIdCmd.Parameters.Add(DbUtil.CreateParameter("@VisitID", DbType.Int64));
                }

                ((IDataParameter)findByIdCmd.Parameters["@VisitID"]).Value = id;

                using (IDataReader rdr = findByIdCmd.ExecuteReader()) {
                    IList<VisitData> visitList = new List<VisitData>();
                    if (rdr.Read()) {
                        long tend = DateTime.Now.Ticks;
                        log.Info("Find Visit by id: " + id + " " + ((tend - tstart) / 10000) + "ms");
                        return fillVisitData(rdr);
                    }
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
            log.Info("Find Visit by ID not found: " + id);
            return null;
        }

        public IList<VisitData> FindByPatientID(long id) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByPatientIdCmd == null) {
                    findByPatientIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_PATIENT_ID, DbUtil.CurrentConnection);
                    findByPatientIdCmd.Parameters.Add(DbUtil.CreateParameter("@patientid", DbType.Int64));
                }

                ((IDataParameter)findByPatientIdCmd.Parameters["@patientid"]).Value = id;

                using (IDataReader rdr = findByPatientIdCmd.ExecuteReader()) {
                    IList<VisitData> visitList = new List<VisitData>();
                    while (rdr.Read()) {
                        visitList.Add(fillVisitData(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Find Visit By PatientId: " + id + " Count:" + visitList.Count + " " + ((tend - tstart) / 10000) + "ms");
                    return visitList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public long Insert(VisitData visit) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (insertByIdCmd == null) {
                    insertByIdCmd = DbUtil.CreateCommand(SQL_INSERT_BY_ID + DbUtil.GetAppendix("VisitID"), DbUtil.CurrentConnection);
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@cause", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@localis", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@extradiagnosis", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@prozedure", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@extratherapy", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@patientid", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@visitdate", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@anesthesiology", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@ultrasound", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@blooddiagnostic", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@todo", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@radiodiagnostics", DbType.String));
                }

                string visitDate = visit.VisitDate.ToString("G", DateTimeFormatInfo.InvariantInfo);

                ((IDataParameter)insertByIdCmd.Parameters["@cause"]).Value = visit.Cause;
                ((IDataParameter)insertByIdCmd.Parameters["@localis"]).Value = visit.Localis;
                ((IDataParameter)insertByIdCmd.Parameters["@extradiagnosis"]).Value = visit.ExtraDiagnosis;
                ((IDataParameter)insertByIdCmd.Parameters["@prozedure"]).Value = visit.Procedure;
                ((IDataParameter)insertByIdCmd.Parameters["@extratherapy"]).Value = visit.ExtraTherapy;
                ((IDataParameter)insertByIdCmd.Parameters["@patientid"]).Value = visit.PatientId;
                ((IDataParameter)insertByIdCmd.Parameters["@visitdate"]).Value = visitDate;
                ((IDataParameter)insertByIdCmd.Parameters["@anesthesiology"]).Value = visit.Anesthesiology;
                ((IDataParameter)insertByIdCmd.Parameters["@ultrasound"]).Value = visit.Ultrasound;
                ((IDataParameter)insertByIdCmd.Parameters["@blooddiagnostic"]).Value = visit.Blooddiagnostic;
                ((IDataParameter)insertByIdCmd.Parameters["@todo"]).Value = visit.Todo;
                ((IDataParameter)insertByIdCmd.Parameters["@radiodiagnostics"]).Value = visit.Radiodiagnostics;

                //bool ok = insertByIdCmd.ExecuteNonQuery() == 1;

                Object insertRet = insertByIdCmd.ExecuteScalar();

                long tend = DateTime.Now.Ticks;
                log.Info("Insert Visit: " + insertRet + " " + ((tend - tstart) / 10000) + "ms");

                return DbUtil.getGeneratedId((IDbCommand)insertByIdCmd, lastInsertedRowCmd, insertRet);
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
                    deleteByIdCmd.Parameters.Add(DbUtil.CreateParameter("@VisitID", DbType.Int64));
                }

                ((IDataParameter)deleteByIdCmd.Parameters["@VisitID"]).Value = id;

                bool ok = deleteByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Delete Visit: " + id + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool Update(VisitData visit) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (updateByIdCmd == null) {
                    updateByIdCmd = DbUtil.CreateCommand(SQL_UPDATE_BY_ID, DbUtil.CurrentConnection);
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@cause", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@localis", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@extradiagnosis", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@prozedure", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@extratherapy", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@anesthesiology", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@ultrasound", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@blooddiagnostic", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@todo", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@radiodiagnostics", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@VisitID", DbType.Int64));
                }

                ((IDataParameter)updateByIdCmd.Parameters["@cause"]).Value = visit.Cause;
                ((IDataParameter)updateByIdCmd.Parameters["@localis"]).Value = visit.Localis;
                ((IDataParameter)updateByIdCmd.Parameters["@extradiagnosis"]).Value = visit.ExtraDiagnosis;
                ((IDataParameter)updateByIdCmd.Parameters["@prozedure"]).Value = visit.Procedure;
                ((IDataParameter)updateByIdCmd.Parameters["@extratherapy"]).Value = visit.ExtraTherapy;
                ((IDataParameter)updateByIdCmd.Parameters["@anesthesiology"]).Value = visit.Anesthesiology;
                ((IDataParameter)updateByIdCmd.Parameters["@ultrasound"]).Value = visit.Ultrasound;
                ((IDataParameter)updateByIdCmd.Parameters["@blooddiagnostic"]).Value = visit.Blooddiagnostic;
                ((IDataParameter)updateByIdCmd.Parameters["@todo"]).Value = visit.Todo;
                ((IDataParameter)updateByIdCmd.Parameters["@radiodiagnostics"]).Value = visit.Radiodiagnostics;
                ((IDataParameter)updateByIdCmd.Parameters["@VisitID"]).Value = visit.Id;

                bool ok = updateByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Update Visit: " + visit.Id + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

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
