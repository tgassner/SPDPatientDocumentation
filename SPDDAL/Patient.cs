using System;
using System.Collections.Generic;
using System.Data;
using SPD.CommonObjects;
using System.Globalization;
using log4net.Repository.Hierarchy;

namespace SPD.DAL {
    class Patient : IPatient {

        const string SQL_FIND_BY_ID = "SELECT patientID, firstname, surname, birthdate, sex, phone, furthertreatment, weight, address, residentOfAsmara, finished, ambulant, linz, waitListStartDate FROM patient WHERE patientID = @patientID";
        const string SQL_FIND_ALL = "SELECT patientID, firstname, surname, birthdate, sex, phone, furthertreatment, weight, address, residentOfAsmara, finished, ambulant, linz, waitListStartDate FROM patient";
        const string SQL_FIND_DIAGNOSIS = "SELECT DISTINCT p.* FROM patient p, visit v where p.patientID = v.patientid and v.extradiagnosis like @extradiagnosis";
        const string SQL_FIND_PROCEDURE = "SELECT DISTINCT p.* where p.patientID = v.patientid and v.prozedure like @prozedure";
        const string SQL_FIND_FINAL_REPORT = "SELECT * FROM patient where furthertreatment like @furthertreatment";
        const string SQL_GET_FINAL_REPORT_BY_ID = "SELECT furthertreatment from patient WHERE patientID = @patientID";
        
        readonly string SQL_UPDATE_BY_ID = 
            " UPDATE patient SET                       \n" +
            "   firstname = @firstname,                \n" +
            "   surname = @surname,                    \n" +
            "   birthdate = @birthdate,                \n" +
            "   sex = @sex,                            \n" +
            "   phone = @phone,                        \n" +
            "   weight = @weight,                      \n" +
            "   address =  @address,                   \n" +
            "   residentOfAsmara =  @residentOfAsmara, \n" +
            "   finished =  @finished,                 \n" +
            "   ambulant =  @ambulant,                 \n" +
            "   linz =  @linz,                         \n" +
            "   waitListStartDate = @waitListStartDate \n" +
            " WHERE                                    \n" +
            "   patientID = @patientID                 \n";
        
        readonly string SQL_INSERT_BY_ID = 
            "INSERT INTO patient " +
            "  (firstname, surname, birthdate, sex, phone, furthertreatment, weight, address, residentOfAsmara, finished, ambulant, linz, waitListStartDate) " +
            " VALUES(@firstname, @surname, @birthdate, @sex, @phone, @furthertreatment, @weight, @address, @residentOfAsmara, @finished, @ambulant, @linz, @waitListStartDate)";

        readonly string SQL_DELETE_BY_ID = "DELETE FROM patient WHERE patientID = @patientID";
        readonly string SQL_INSERT_FINAL_REPORT_BY_ID = "UPDATE patient SET furthertreatment = @furthertreatment where patientID = @patientID";
        readonly string SQL_GET_ALL_FINAL_REPORT = "SELECT patientID, furthertreatment from patient";
        readonly string SQL_NUMBEROFPATIENTS = "SELECT count(*) AS numberOfPatients FROM patient";
        static IDbCommand findByIdCmd;
        static IDbCommand findAllCmd;
        static IDbCommand findDiagnosisCmd;
        static IDbCommand findProcedureCmd;
        static IDbCommand findFinalReportCmd;
        static IDbCommand updateByIdCmd;
        static IDbCommand insertByIdCmd;
        static IDbCommand deleteByIdCmd;
        static IDbCommand lastInsertedRowCmd = null;
        static IDbCommand insertFinalReportCmd;
        static IDbCommand getFinalReportCmd;
        static IDbCommand getAllFinalReportCmd;
        static IDbCommand numberOfPatientsCmd;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private PatientData fillPatientObject(IDataReader rdr) {
            PatientData patient = new PatientData();

            String sexStr = Convert.ToString(rdr["sex"]);
            String residentOfAsmaraStr = Convert.ToString(rdr["residentOfAsmara"]);
            String finishedStr = Convert.ToString(rdr["finished"]);
            String ambulantStr = Convert.ToString(rdr["ambulant"]);
            String linzStr = Convert.ToString(rdr["linz"]);

            Sex sex = Sex.male;
            ResidentOfAsmara residentOfAsmara = ResidentOfAsmara.undefined;
            Finished finished = Finished.undefined;
            Ambulant ambulant = Ambulant.notAmbulant;
            Linz linz = Linz.undefined;

            if (!string.IsNullOrEmpty(sexStr)) {
                 sex = (Sex)Enum.Parse(new Sex().GetType(), sexStr);
            }

            if (!string.IsNullOrEmpty(residentOfAsmaraStr)) {
                residentOfAsmara = (ResidentOfAsmara)Enum.Parse(new ResidentOfAsmara().GetType(), residentOfAsmaraStr);
            }

            if (!string.IsNullOrEmpty(finishedStr)) {
                finished = (Finished)Enum.Parse(new Finished().GetType(), finishedStr);
            }

            if (!string.IsNullOrEmpty(ambulantStr)) {
                ambulant = (Ambulant)Enum.Parse(new Ambulant().GetType(), ambulantStr);
            }

            if (!string.IsNullOrEmpty(linzStr)) {
                linz = (Linz)Enum.Parse(new Linz().GetType(), linzStr);
            }

            patient.Sex = sex;
            patient.ResidentOfAsmara = residentOfAsmara;
            patient.Finished = finished;
            patient.Ambulant = ambulant;
            patient.Linz = linz;

            patient.Id = Convert.ToInt64(rdr["patientID"]);
            patient.FirstName = Convert.ToString(rdr["firstname"]);
            patient.SurName = Convert.ToString(rdr["surname"]);
            patient.DateOfBirth = DateTime.Parse((string)rdr["birthdate"], DateTimeFormatInfo.InvariantInfo);
            patient.Sex = sex;
            patient.Phone = Convert.ToString(rdr["phone"]);
            patient.Weight = Convert.ToInt32(rdr["weight"]);
            patient.Address = Convert.ToString(rdr["address"]);

            if (rdr.IsDBNull(rdr.GetOrdinal("waitListStartDate")) || string.IsNullOrEmpty(Convert.ToString(rdr["waitListStartDate"]))) {
                patient.WaitListStartDate = null;
            } else {
                patient.WaitListStartDate = DateTime.Parse((string)rdr["waitListStartDate"], DateTimeFormatInfo.InvariantInfo);
            }

            return patient;
        }

        public IList<PatientData> FindAll() {
            try {
                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findAllCmd == null) {
                    findAllCmd = DbUtil.CreateCommand(SQL_FIND_ALL, DbUtil.CurrentConnection);
                }

                using (IDataReader rdr = findAllCmd.ExecuteReader()) {
                    IList<PatientData> patientList = new List<PatientData>();
                    
                    while (rdr.Read()) {
                        patientList.Add(fillPatientObject(rdr));
                    }

                    long tend = DateTime.Now.Ticks;

                    log.Info("Get All Patients: " + patientList.Count + " " + ((tend - tstart) / 10000) + "ms");

                    return patientList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public PatientData FindByID(long id) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByIdCmd == null) {
                    findByIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_ID, DbUtil.CurrentConnection);
                    findByIdCmd.Parameters.Add(DbUtil.CreateParameter("@patientID", DbType.Int64));
                }

                ((IDataParameter)findByIdCmd.Parameters["@patientID"]).Value = id;
                
                using (IDataReader rdr = findByIdCmd.ExecuteReader()) {
                    IList<PatientData> patientList = new List<PatientData>();
                    if (rdr.Read()) {

                        long tend = DateTime.Now.Ticks;
                        log.Info("Find Patient by Id: " + id + " " + ((tend - tstart) / 10000) + "ms");
                        return fillPatientObject(rdr);
                    }
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
            log.Info("Find Patient By Id - Not Found: " + id);
            return null;
        }

        public long Insert(PatientData patient) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (insertByIdCmd == null) {
                    insertByIdCmd = DbUtil.CreateCommand(SQL_INSERT_BY_ID + DbUtil.GetAppendix("patientID"), DbUtil.CurrentConnection);
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@firstname", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@surname", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@birthdate", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@sex", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@phone", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@furthertreatment", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@weight", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@address", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@residentOfAsmara", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@finished", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@ambulant", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@linz", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@waitListStartDate", DbType.String));
                }

                ((IDataParameter)insertByIdCmd.Parameters["@firstname"]).Value = patient.FirstName;
                ((IDataParameter)insertByIdCmd.Parameters["@surname"]).Value = patient.SurName;
                ((IDataParameter)insertByIdCmd.Parameters["@birthdate"]).Value = patient.DateOfBirth.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
                ((IDataParameter)insertByIdCmd.Parameters["@sex"]).Value = patient.Sex.ToString();
                ((IDataParameter)insertByIdCmd.Parameters["@phone"]).Value = patient.Phone;
                ((IDataParameter)insertByIdCmd.Parameters["@furthertreatment"]).Value = "";
                ((IDataParameter)insertByIdCmd.Parameters["@weight"]).Value = patient.Weight;
                ((IDataParameter)insertByIdCmd.Parameters["@address"]).Value = patient.Address;
                ((IDataParameter)insertByIdCmd.Parameters["@residentOfAsmara"]).Value = patient.ResidentOfAsmara;
                ((IDataParameter)insertByIdCmd.Parameters["@finished"]).Value = patient.Finished;
                ((IDataParameter)insertByIdCmd.Parameters["@ambulant"]).Value = patient.Ambulant;
                ((IDataParameter)insertByIdCmd.Parameters["@linz"]).Value = patient.Linz;
                if (patient.WaitListStartDate == null) {
                    ((IDataParameter) insertByIdCmd.Parameters["@waitListStartDate"]).Value = DBNull.Value;
                } else {
                    ((IDataParameter)insertByIdCmd.Parameters["@waitListStartDate"]).Value = ((DateTime)patient.WaitListStartDate).ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);    
                }
                

                Object insertRet = insertByIdCmd.ExecuteScalar();

                long tend = DateTime.Now.Ticks;
                log.Info("Insert patient: " + insertRet + " " + ((tend - tstart) / 10000) + "ms");

                return DbUtil.getGeneratedId((IDbCommand)insertByIdCmd, lastInsertedRowCmd, insertRet);
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool Update(PatientData patient) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (updateByIdCmd == null) {
                    updateByIdCmd = DbUtil.CreateCommand(SQL_UPDATE_BY_ID, DbUtil.CurrentConnection);

                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@firstname", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@surname", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@birthdate", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@sex", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@phone", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@weight", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@address", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@residentOfAsmara", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@finished", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@ambulant", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@linz", DbType.Int64));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@waitListStartDate", DbType.String));
                    updateByIdCmd.Parameters.Add(DbUtil.CreateParameter("@patientID", DbType.Int64));
                }

                ((IDataParameter)updateByIdCmd.Parameters["@firstname"]).Value = patient.FirstName;
                ((IDataParameter)updateByIdCmd.Parameters["@surname"]).Value = patient.SurName;
                ((IDataParameter)updateByIdCmd.Parameters["@birthdate"]).Value = patient.DateOfBirth.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
                ((IDataParameter)updateByIdCmd.Parameters["@sex"]).Value = patient.Sex.ToString();
                ((IDataParameter)updateByIdCmd.Parameters["@phone"]).Value = patient.Phone;
                ((IDataParameter)updateByIdCmd.Parameters["@weight"]).Value = patient.Weight;
                ((IDataParameter)updateByIdCmd.Parameters["@address"]).Value = patient.Address;
                ((IDataParameter)updateByIdCmd.Parameters["@residentOfAsmara"]).Value = patient.ResidentOfAsmara;
                ((IDataParameter)updateByIdCmd.Parameters["@finished"]).Value = patient.Finished;
                ((IDataParameter)updateByIdCmd.Parameters["@ambulant"]).Value = patient.Ambulant;
                ((IDataParameter)updateByIdCmd.Parameters["@linz"]).Value = patient.Linz;
                if (patient.WaitListStartDate == null) {
                    ((IDataParameter)updateByIdCmd.Parameters["@waitListStartDate"]).Value = DBNull.Value;
                } else {
                    ((IDataParameter)updateByIdCmd.Parameters["@waitListStartDate"]).Value = ((DateTime)patient.WaitListStartDate).ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);    
                }
                
                ((IDataParameter)updateByIdCmd.Parameters["@patientID"]).Value = patient.Id;

                bool ok = updateByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Update Patient: " + patient.Id + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

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
                    deleteByIdCmd.Parameters.Add(DbUtil.CreateParameter("@patientID", DbType.Int64));
                }

                ((IDataParameter)deleteByIdCmd.Parameters["@patientID"]).Value = id;

                bool ok = deleteByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Delete Patient: " + id + " " + ok.ToString() + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool InsertFinalReport(string ft,long pID) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (insertFinalReportCmd == null) {
                    insertFinalReportCmd = DbUtil.CreateCommand(SQL_INSERT_FINAL_REPORT_BY_ID, DbUtil.CurrentConnection);

                    insertFinalReportCmd.Parameters.Add(DbUtil.CreateParameter("@furthertreatment", DbType.String));
                    insertFinalReportCmd.Parameters.Add(DbUtil.CreateParameter("@patientID", DbType.Int64));
                }

                ((IDataParameter)insertFinalReportCmd.Parameters["@furthertreatment"]).Value = ft;
                ((IDataParameter)insertFinalReportCmd.Parameters["@patientID"]).Value = pID;

                bool ok = insertFinalReportCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Insert Final Report: " + pID + " " + ok.ToString() + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public string GetFinalReportByPatentID(long pID) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (getFinalReportCmd == null) {
                    getFinalReportCmd = DbUtil.CreateCommand(SQL_GET_FINAL_REPORT_BY_ID, DbUtil.CurrentConnection);
                    getFinalReportCmd.Parameters.Add(DbUtil.CreateParameter("@patientID", DbType.Int64));
                }

                ((IDataParameter)getFinalReportCmd.Parameters["@patientID"]).Value = pID;

                using (IDataReader rdr = getFinalReportCmd.ExecuteReader()) {
                    if (rdr.Read()) {

                        long tend = DateTime.Now.Ticks;
                        log.Info("Get Final Report OK" + " " + ((tend - tstart) / 10000) + "ms");
                        return (string)rdr["furthertreatment"];
                    }
                    log.Info("Final Report Not Found: " + pID);
                    return null;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public IDictionary<long, string> GetAllFinalReports() {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (getAllFinalReportCmd == null) {
                    getAllFinalReportCmd = DbUtil.CreateCommand(SQL_GET_ALL_FINAL_REPORT, DbUtil.CurrentConnection);
                }

                IDictionary<long, string> finalReports = new Dictionary<long, string>();

                using (IDataReader rdr = getAllFinalReportCmd.ExecuteReader()) {
                    while (rdr.Read()) {
                        finalReports.Add(Convert.ToInt64(rdr["patientID"]), (string)rdr["furthertreatment"]);
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Get All Final Reports" + finalReports.Count + " reports " + ((tend - tstart) / 10000) + "ms");
                    return finalReports;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public IList<PatientData> FindDiagnose(string searchString) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findDiagnosisCmd == null) {
                    findDiagnosisCmd = DbUtil.CreateCommand(SQL_FIND_DIAGNOSIS, DbUtil.CurrentConnection);
                    findDiagnosisCmd.Parameters.Add(DbUtil.CreateParameter("@extradiagnosis", DbType.String));
                }

                ((IDataParameter)findDiagnosisCmd.Parameters["@extradiagnosis"]).Value = "%" + searchString + "%";

                using (IDataReader rdr = findDiagnosisCmd.ExecuteReader()) {
                    IList<PatientData> patientList = new List<PatientData>();
                    while (rdr.Read()) {
                        patientList.Add(fillPatientObject(rdr));
                    }
                    long tend = DateTime.Now.Ticks;
                    log.Info("Find Diagnoses: " + searchString + " - " + patientList.Count + " Diagnoses" + " " + ((tend - tstart) / 10000) + "ms");
                    return patientList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public IList<PatientData> FindProcedure(string searchString) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findProcedureCmd == null) {
                    findProcedureCmd = DbUtil.CreateCommand(SQL_FIND_PROCEDURE, DbUtil.CurrentConnection);
                    findProcedureCmd.Parameters.Add(DbUtil.CreateParameter("@prozedure", DbType.String));
                }

                ((IDataParameter)findProcedureCmd.Parameters["@prozedure"]).Value = "%" + searchString + "%";

                using (IDataReader rdr = findProcedureCmd.ExecuteReader()) {
                    IList<PatientData> patientList = new List<PatientData>();
                    while (rdr.Read()) {
                        patientList.Add(fillPatientObject(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Find Procedure: " + searchString + " - " + patientList.Count + " Procedures" + " " + ((tend - tstart) / 10000) + "ms");
                    return patientList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public IList<PatientData> FindPatientsByFinalReport(string searchString) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findFinalReportCmd == null) {
                    findFinalReportCmd = DbUtil.CreateCommand(SQL_FIND_FINAL_REPORT, DbUtil.CurrentConnection);
                    findFinalReportCmd.Parameters.Add(DbUtil.CreateParameter("@furthertreatment", DbType.String));
                }

                ((IDataParameter)findFinalReportCmd.Parameters["@furthertreatment"]).Value = "%" + searchString + "%";

                using (IDataReader rdr = findFinalReportCmd.ExecuteReader()) {
                    IList<PatientData> patientList = new List<PatientData>();
                    while (rdr.Read()) {
                        patientList.Add(fillPatientObject(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Find Final Report: " + searchString + " - " + patientList.Count + " Reports" + " " + ((tend - tstart) / 10000) + "ms");
                    return patientList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public long NumberOfPatients() {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (numberOfPatientsCmd == null) {
                    numberOfPatientsCmd = DbUtil.CreateCommand(SQL_NUMBEROFPATIENTS, DbUtil.CurrentConnection);
                }

                long tend = DateTime.Now.Ticks;

                long numberOfPatients = Convert.ToInt64(numberOfPatientsCmd.ExecuteScalar());

                log.Info("Number Of Patients: " + numberOfPatients + " " + ((tend - tstart) / 10000) + "ms");

                return numberOfPatients;

            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }
    }
}
