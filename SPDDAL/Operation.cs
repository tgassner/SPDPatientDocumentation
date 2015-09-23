using System;
using System.Collections.Generic;
using System.Text;
using SPD.DAL;
using System.Data;
using SPD.CommonObjects;
using System.Globalization;

namespace SPD.DAL {
    class Operation : IOperation {
        const string SQL_FIND_BY_ID = "SELECT * FROM operation WHERE operationID = @operationID";
        const string SQL_FIND_BY_PATIENT_ID = "SELECT * FROM operation WHERE patientID = @patientID";
        const string SQL_FIND_ALL = "SELECT * FROM operation";
        const string SQL_LAST_INSERTED_ROW = "SELECT @@Identity";
        readonly string SQL_UPDATE_BY_ID = "UPDATE operation SET operationdate = @operationdate, team = @team, process = @process, diagnoses = @diagnoses, performed = @performed, additionalinformation = @additionalinformation, medication = @medication, intdiagnoses = @intdiagnoses, ppps = @ppps, result = @result, kathDays = @kathDays, organ = @organ, opResult = @opResult WHERE operationID = @operationID";
        readonly string SQL_INSERT_BY_ID = "INSERT INTO operation (operationdate, team, process, diagnoses, performed, patientid, additionalinformation, medication, intdiagnoses, ppps, result, kathDays, organ, opResult) VALUES(@operationdate, @team, @process, @diagnoses, @performed, @patientid, @additionalinformation, @medication, @intdiagnoses, @ppps, @result, @kathDays, @organ, @opResult)";
        readonly string SQL_DELETE_BY_ID = "DELETE FROM operation WHERE operationID = @operationID";
        static IDbCommand findByIdCmd;
        static IDbCommand findByPatientIdCmd;
        static IDbCommand findAllCmd;
        static IDbCommand updateByIdCmd;
        static IDbCommand insertByIdCmd;
        static IDbCommand deleteByIdCmd;
        static IDbCommand lastInsertedRowCmd = null;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private OperationData fillOperation(IDataReader rdr) {
            OperationData operation = new OperationData();
            operation.OperationId = Convert.ToInt64(rdr["operationID"]);
            operation.Date = DateTime.Parse(Convert.ToString(rdr["operationdate"]), DateTimeFormatInfo.InvariantInfo);
            operation.Team = Convert.ToString(rdr["team"]);
            operation.Process = Convert.ToString(rdr["process"]);
            operation.Diagnoses = Convert.ToString(rdr["diagnoses"]);
            operation.Performed = Convert.ToString(rdr["performed"]);
            operation.PatientId = Convert.ToInt64(rdr["patientid"]);
            operation.Additionalinformation = Convert.ToString(rdr["additionalinformation"]);
            operation.Medication = Convert.ToString(rdr["medication"]);
            operation.IntDiagnoses = Convert.ToInt64(rdr["intdiagnoses"]);
            operation.Ppps = (PPPS)Convert.ToInt64(rdr["ppps"]);
            operation.Result = (Result)Convert.ToInt64(rdr["result"]);
            operation.KathDays = Convert.ToInt64(rdr["kathDays"]);
            operation.Organ = (Organ)Convert.ToInt64(rdr["organ"]);
            operation.OpResult = Convert.ToString(rdr["opResult"]);
            return operation;
        }

        public IList<OperationData> FindAll() {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findAllCmd == null) {
                    findAllCmd = DbUtil.CreateCommand(SQL_FIND_ALL, DbUtil.CurrentConnection);
                }

                using (IDataReader rdr = findAllCmd.ExecuteReader()) {
                    IList<OperationData> operationList = new List<OperationData>();
                    while (rdr.Read()) {
                        operationList.Add(fillOperation(rdr));
                    }
                    long tend = DateTime.Now.Ticks;
                    log.Info("Find All Operations: " + operationList.Count + " " + ((tend - tstart) / 10000) + "ms");
                    return operationList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public IList<OperationData> FindByPatientId(long patientId) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByPatientIdCmd == null) {
                    findByPatientIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_PATIENT_ID, DbUtil.CurrentConnection);
                    findByPatientIdCmd.Parameters.Add(DbUtil.CreateParameter("@patientId", DbType.Int64));
                }

                ((IDataParameter)findByPatientIdCmd.Parameters["@patientid"]).Value = patientId;

                using (IDataReader rdr = findByPatientIdCmd.ExecuteReader()) {
                    IList<OperationData> operationList = new List<OperationData>();
                    while (rdr.Read()) {
                        operationList.Add(fillOperation(rdr));
                    }
                    long tend = DateTime.Now.Ticks;
                    log.Info("Find Operations By PatientId: " + patientId + " Numbers:" + operationList.Count + " " + ((tend - tstart) / 10000) + "ms");
                    return operationList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public OperationData FindByOperationId(long operationId) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByIdCmd == null) {
                    findByIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_ID, DbUtil.CurrentConnection);
                    findByIdCmd.Parameters.Add(DbUtil.CreateParameter("@operationID", DbType.Int64));
                }

                ((IDataParameter)findByIdCmd.Parameters["@operationID"]).Value = operationId;

                using (IDataReader rdr = findByIdCmd.ExecuteReader()) {
                    if (rdr.Read()) {
                        long tend = DateTime.Now.Ticks;
                        log.Info("Find Operation By Id: " + operationId + " " + ((tend - tstart) / 10000) + "ms");
                        return fillOperation(rdr);
                    }
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
            log.Info("Find Operation by ID not found: " + operationId);
            return null;
        }

        public long Insert(OperationData odata) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (insertByIdCmd == null) {
                    insertByIdCmd = DbUtil.CreateCommand(SQL_INSERT_BY_ID + DbUtil.GetAppendix("operationID"), DbUtil.CurrentConnection);
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@operationdate", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@team", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@process", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@diagnoses", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@performed", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@patientid", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@additionalinformation", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@medication", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@intdiagnoses", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@ppps", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@result", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@kathDays", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@organ", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@opResult", DbType.String));
                }

                string opDate = odata.Date.ToString("G", DateTimeFormatInfo.InvariantInfo);

                ((IDataParameter)insertByIdCmd.Parameters["@operationdate"]).Value = opDate;
                ((IDataParameter)insertByIdCmd.Parameters["@team"]).Value = odata.Team;
                ((IDataParameter)insertByIdCmd.Parameters["@process"]).Value = odata.Process;
                ((IDataParameter)insertByIdCmd.Parameters["@diagnoses"]).Value = odata.Diagnoses;
                ((IDataParameter)insertByIdCmd.Parameters["@performed"]).Value = odata.Performed;
                ((IDataParameter)insertByIdCmd.Parameters["@patientid"]).Value = odata.PatientId;
                ((IDataParameter)insertByIdCmd.Parameters["@additionalinformation"]).Value = odata.Additionalinformation;
                ((IDataParameter)insertByIdCmd.Parameters["@medication"]).Value = odata.Medication;
                ((IDataParameter)insertByIdCmd.Parameters["@intdiagnoses"]).Value = odata.IntDiagnoses;
                ((IDataParameter)insertByIdCmd.Parameters["@ppps"]).Value = (long)odata.Ppps;
                ((IDataParameter)insertByIdCmd.Parameters["@result"]).Value = (long)odata.Result;
                ((IDataParameter)insertByIdCmd.Parameters["@kathDays"]).Value = (long)odata.KathDays;
                ((IDataParameter)insertByIdCmd.Parameters["@organ"]).Value = (long)odata.Organ;
                ((IDataParameter)insertByIdCmd.Parameters["@opResult"]).Value = odata.OpResult;

                Object insertRet = insertByIdCmd.ExecuteScalar();

                long tend = DateTime.Now.Ticks;
                log.Info("Insert Operation: " + " " + ((tend - tstart) / 10000) + "ms");

                return DbUtil.getGeneratedId((IDbCommand)insertByIdCmd, lastInsertedRowCmd, insertRet);
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool Delete(long operationId) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (deleteByIdCmd == null) {
                    deleteByIdCmd = DbUtil.CreateCommand(SQL_DELETE_BY_ID, DbUtil.CurrentConnection);
                    deleteByIdCmd.Parameters.Add(DbUtil.CreateParameter("@operationID", DbType.Int64));
                }

                ((IDataParameter)deleteByIdCmd.Parameters["@operationID"]).Value = operationId;


                bool ok = deleteByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Delete Operation: " + operationId + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool Update(OperationData operation) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (updateByIdCmd == null) {
                    updateByIdCmd = DbUtil.CreateCommand(SQL_UPDATE_BY_ID, DbUtil.CurrentConnection);

                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@operationdate", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@team", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@process", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@diagnoses", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@performed", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@additionalinformation", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@medication", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@intdiagnoses", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@ppps", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@result", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@kathDays", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@organ", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@opResult", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@operationID", DbType.Int64));
                }

                ((IDataParameter)updateByIdCmd.Parameters["@operationdate"]).Value = operation.Date;
                ((IDataParameter)updateByIdCmd.Parameters["@team"]).Value = operation.Team;
                ((IDataParameter)updateByIdCmd.Parameters["@process"]).Value = operation.Process;
                ((IDataParameter)updateByIdCmd.Parameters["@diagnoses"]).Value = operation.Diagnoses;
                ((IDataParameter)updateByIdCmd.Parameters["@performed"]).Value = operation.Performed;
                ((IDataParameter)updateByIdCmd.Parameters["@additionalinformation"]).Value = operation.Additionalinformation;
                ((IDataParameter)updateByIdCmd.Parameters["@medication"]).Value = operation.Medication;
                ((IDataParameter)updateByIdCmd.Parameters["@intdiagnoses"]).Value = operation.IntDiagnoses;
                ((IDataParameter)updateByIdCmd.Parameters["@ppps"]).Value = (long)operation.Ppps;
                ((IDataParameter)updateByIdCmd.Parameters["@result"]).Value = (long)operation.Result;
                ((IDataParameter)updateByIdCmd.Parameters["@kathDays"]).Value = operation.KathDays;
                ((IDataParameter)updateByIdCmd.Parameters["@organ"]).Value = (long)operation.Organ;
                ((IDataParameter)updateByIdCmd.Parameters["@opResult"]).Value = operation.OpResult;
                ((IDataParameter)updateByIdCmd.Parameters["@operationID"]).Value = operation.OperationId;

                bool ok = updateByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Update Operation: " + operation.OperationId + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

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
