using System;
using System.Collections.Generic;
using System.Text;
using SPD.CommonObjects;
using SPD.CommonUtilities;
using SPD.DAL;
using SPD.BL.Interfaces;
using System.Windows.Forms;
using SPD.OtherObjects;

namespace SPD.BL {
    /// <summary>
    /// Abstact Klass implementing the business Logic Implementation can overwrite methods for Buffering etc.
    /// </summary>
    public abstract class AbstractSPDBL : ISPDBL {

        #region Varia

        /// <summary>
        /// Clears the caches.
        /// </summary>
        public virtual void ClearCaches() {
        }

        #endregion Varia

        #region Patient

        /// <summary>
        /// Gets all patients.
        /// </summary>
        /// <returns></returns>
        public virtual IList<PatientData> GetAllPatients() {
            IPatient patientDB = Database.CreatePatient();
            return patientDB.FindAll();

        }

        /// <summary>
        /// Inserts the patient.
        /// </summary>
        /// <param name="patientData">The patient data.</param>
        /// <returns></returns>
        public virtual PatientData InsertPatient(PatientData patientData) {
            IPatient patientDB = Database.CreatePatient();
            long id = patientDB.Insert(patientData);
            if (id != 0) {
                PatientData newPatient = new PatientData(id, patientData.FirstName, patientData.SurName,
                    patientData.DateOfBirth, patientData.Sex,
                    patientData.Phone, patientData.Weight,
                     patientData.Address, patientData.ResidentOfAsmara, patientData.Ambulant, 
                     patientData.Finished, patientData.Linz, patientData.WaitListStartDate);
                return newPatient;
            } else {
                return null;
            }

        }

        /// <summary>
        /// Updates the patient.
        /// </summary>
        /// <param name="patientData">The patient data.</param>
        /// <returns></returns>
        public virtual bool UpdatePatient(PatientData patientData) {
            IPatient patientDB = Database.CreatePatient();
            bool ok = patientDB.Update(patientData);
            return ok;
        }

        /// <summary>
        /// Deletes the patient.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public virtual bool DeletePatient(long pID) {
            IPatient patientDB = Database.CreatePatient();
            bool ok = patientDB.Delete(pID);
            return ok;
        }

        /// <summary>
        /// Finds the diagnose.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindDiagnose(string searchString) {
            IPatient patientDB = Database.CreatePatient();
            return patientDB.FindDiagnose(searchString);
        }

        /// <summary>
        /// Finds the procedure.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindProcedure(string searchString) {
            IPatient patientDB = Database.CreatePatient();
            return patientDB.FindProcedure(searchString);
        }

        /// <summary>
        /// Finds the therapy.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindTherapy(string searchString) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the final report by patient id.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public virtual string GetFinalReportByPatientId(long pID) {
            IPatient patientDB = Database.CreatePatient();
            return patientDB.GetFinalReportByPatentID(pID);
        }

        /// <summary>
        /// Inserts the final report.
        /// </summary>
        /// <param name="finalReport">The ft.</param>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public virtual bool InsertFinalReport(string finalReport, long pID) {
            IPatient patientDB = Database.CreatePatient();
            return patientDB.InsertFinalReport(finalReport, pID);
        }

        /// <summary>
        /// Number the of patients.
        /// </summary>
        /// <returns></returns>
        public virtual long NumberOfPatients() {
            IPatient patientDB = Database.CreatePatient();
            return patientDB.NumberOfPatients();
        }

        /// <summary>
        /// Finds the patient by id.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <returns></returns>
        public virtual PatientData FindPatientById(long patientId) {
            IPatient patientDB = Database.CreatePatient();
            return patientDB.FindByID(patientId);
        }

        /// <summary>
        /// Finds the name of the patient by.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="surname">The surname.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByName(string firstName, string surname) {
            IList<PatientData> patientList = new List<PatientData>();

            if ((firstName.Equals("")) &&
                (surname.Equals(""))) {
                return this.GetAllPatients();
            }

            foreach (PatientData pd in this.GetAllPatients()) {
                if (((pd.FirstName.ToLower().Contains(firstName.ToLower())) &&
                    (pd.SurName.ToLower().Contains(surname.ToLower())))) {
                    patientList.Add(pd);
                }
            }

            return patientList;
        }

        /// <summary>
        /// Finds the patient by all Names.
        /// </summary>
        /// <param name="name">Name Pattern.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByAllName(string name) {
            IList<PatientData> patientList = new List<PatientData>();

            if (String.IsNullOrEmpty(name)) {
                return patientList;
            }

            name = name.ToLower();
            string[] searchpatterns = name.Split(new char[] {' ', '\t' , '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (PatientData pd in this.GetAllPatients()) {
                string fullname = pd.FirstName.ToLower() + " " + pd.SurName.ToLower();
                bool found = true;
                foreach (string searchpattern in searchpatterns) {
                    if (!fullname.Contains(searchpattern)) {
                        found = false;
                    }
                }
                if (found) {
                    patientList.Add(pd);
                }
            }

            return patientList;
        }

        /// <summary>
        /// Finds the patient by Phone Nr.
        /// </summary>
        /// <param name="phone">Phone Pattern.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByPhone(string phone) {
            IList<PatientData> patientList = new List<PatientData>();

            if (String.IsNullOrEmpty(phone)) {
                return patientList;
            }

            phone = phone.ToLower();
            string[] searchpatterns = phone.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (PatientData pd in this.GetAllPatients()) {
                bool found = true;
                foreach (string searchpattern in searchpatterns) {
                    if (!pd.Phone.ToLower().Contains(searchpattern)) {
                        found = false;
                    }
                }
                if (found) {
                    patientList.Add(pd);
                }
            }

            return patientList;
        }

        /// <summary>
        /// checks if Phone is already stored?
        /// </summary>
        /// <param name="phone">phone Pattern.</param>
        /// <returns>true if phone nr exists, false if not.</returns>
        public virtual bool DoesPhoneExist(string phone) {
            if (String.IsNullOrEmpty(phone)) {
                return false;
            }

            foreach (PatientData pd in this.GetAllPatients()) {
                if (phone.ToLower().Equals(pd.Phone.ToLower())) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Finds the patient by linz.
        /// </summary>
        /// <param name="linz">The linz.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByLinz(Linz linz) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the patient by asmara.
        /// </summary>
        /// <param name="asmara">The asmara.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByAsmara(ResidentOfAsmara asmara) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the patient by ambulant.
        /// </summary>
        /// <param name="ambulant">The ambulant.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByAmbulant(Ambulant ambulant) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the patient by wait list.
        /// </summary>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByWaitList() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the patient by finished.
        /// </summary>
        /// <param name="finished">The finished.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByFinished(Finished finished) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the patient by diagnose group id.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByDiagnoseGroupId(long dgId) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the patient by operation date.
        /// </summary>
        /// <param name="halfyear">The halfyear.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByOperationDate(int halfyear, int year) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the name of the patient by id and all.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByIdAndAllName(string pattern) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the patient by ids.
        /// </summary>
        /// <param name="pIds">The p ids.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByIds(IList<long> pIds) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the highes patient id.
        /// </summary>
        /// <returns>th Highest Patient Id or -1 if no Patient Ids are in DB</returns>
        public virtual long getHighesPatientId() {
            throw new NotImplementedException();
        }

        #endregion Patient

        #region Visit

        /// <summary>
        /// Getalls the visits.
        /// </summary>
        /// <returns></returns>
        public virtual IList<VisitData> getallVisits() {
            IVisit visitDB = Database.CreateVisit();
            return visitDB.FindAll();
        }

        /// <summary>
        /// Gets the last visit by patient ID.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public virtual VisitData GetLastVisitByPatientID(long pId) {
            IList<VisitData> visitList = this.GetVisitsByPatientID(pId);

            return StaticUtilities.GetnThVisit(visitList, -1);
        }

        /// <summary>
        /// Updates the visit.
        /// </summary>
        /// <param name="visitData">The visit data.</param>
        /// <returns></returns>
        public virtual bool UpdateVisit(VisitData visitData) {
            IVisit visitDB = Database.CreateVisit();
            return visitDB.Update(visitData);
        }

        /// <summary>
        /// Inserts the visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns></returns>
        public virtual VisitData InsertVisit(VisitData visit) {
            IVisit visitDB = Database.CreateVisit();

            long id = visitDB.Insert(visit);
            if (id != 0) {
                visit.Id = id;
                return visit;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Gets the visits by patient ID.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <returns></returns>
        public virtual IList<VisitData> GetVisitsByPatientID(long patientID) {
            IVisit visitDB = Database.CreateVisit();
            return visitDB.FindByPatientID(patientID);
        }

        /// <summary>
        /// Gets the diagnose by patient of last visit.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public virtual string GetDiagnoseByPatientOfLastVisit(long pID) {
            VisitData newestVisit = this.GetLastVisitByPatientID(pID);

            if (newestVisit == null) {
                return "";
            } else {
                return newestVisit.ExtraDiagnosis;
            }
        }

        /// <summary>
        /// Number the of visits.
        /// </summary>
        /// <returns></returns>
        public virtual long NumberOfVisits() {
            return getallVisits().Count;
        }

        #endregion Visit

        #region Operation

        /// <summary>
        /// Getalls the operations.
        /// </summary>
        /// <returns></returns>
        public virtual IList<OperationData> getallOperations() {
            IOperation operationDB = Database.CreateOperation();
            return operationDB.FindAll();
        }

        /// <summary>
        /// Gets the last operation by patient ID.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public virtual OperationData GetLastOperationByPatientID(long pId) {
            IList<OperationData> operationList = this.GetOperationsByPatientID(pId);
            return StaticUtilities.NewestOP(operationList);
        }

        /// <summary>
        /// Gets the operations by patient ID.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public virtual IList<OperationData> GetOperationsByPatientID(long p) {
            IOperation operationDB = Database.CreateOperation();
            IList<OperationData> opList = operationDB.FindByPatientId(p);
            return opList;
        }

        /// <summary>
        /// Updates the operation.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        public virtual bool UpdateOperation(OperationData operationData) {
            IOperation operationDB = Database.CreateOperation();
            return operationDB.Update(operationData);
        }

        /// <summary>
        /// Inserts the operation.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        public virtual OperationData InsertOperation(OperationData operationData) {
            IOperation operationDB = Database.CreateOperation();
            long id = operationDB.Insert(operationData);
            if (id != 0) {
                operationData.OperationId = id;
                return operationData;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Number the of operations.
        /// </summary>
        /// <returns></returns>
        public virtual long NumberOfOperations() {
            return getallOperations().Count;
        }

        #endregion Operation

        #region Image

        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <param name="imageData">The image data.</param>
        /// <returns></returns>
        public virtual bool DeleteImage(ImageData imageData) {
            IPhoto photoDB = Database.CreatePhoto();
            return photoDB.Delete(imageData.PhotoID);
        }

        /// <summary>
        /// Inserts the image.
        /// </summary>
        /// <param name="imageData">The image data.</param>
        /// <returns></returns>
        public virtual ImageData InsertImage(ImageData imageData) {
            IPhoto photoDB = Database.CreatePhoto();
            long id = photoDB.Insert(imageData);
            if (id != 0) {
                imageData.PhotoID = id;
                return imageData;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Gets the images by patient ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public virtual IList<ImageData> GetImagesByPatientID(long pID) {
            IPhoto photoDB = Database.CreatePhoto();
            return photoDB.FindByPatientId(pID);
        }

        #endregion Image

        #region NextAction

        /// <summary>
        /// Gets all next actions.
        /// </summary>
        /// <returns></returns>
        public virtual IList<NextActionData> GetAllNextActions() {
            INextAction nextActionDB = Database.CreateNextAction();
            return nextActionDB.FindAll();
        }

        /// <summary>
        /// Deletes the Action.
        /// </summary>
        /// <param name="nextActionData">The Next Action data.</param>
        /// <returns></returns>
        public virtual bool DeleteNextAction(NextActionData nextActionData) {
            INextAction nextActionDB = Database.CreateNextAction();
            return nextActionDB.Delete(nextActionData.NextActionID);
        }

        /// <summary>
        /// Inserts the next action.
        /// </summary>
        /// <param name="nextActionData">The next action data.</param>
        /// <returns></returns>
        public virtual NextActionData InsertNextAction(NextActionData nextActionData) {
            INextAction nextActionDB = Database.CreateNextAction();
            long id = nextActionDB.Insert(nextActionData);
            if (id != 0) {
                nextActionData.NextActionID = id;
                return nextActionData;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Gets the Next Actions by patient ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public virtual IList<NextActionData> GetNextActionsByPatientID(long pID) {
            INextAction nextActionDB = Database.CreateNextAction();
            return nextActionDB.FindByPatientId(pID);
        }

        /// <summary>
        /// Finds the patients with next action.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="halfYear">The half year.</param>
        /// <param name="actionKind">Kind of the action.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientsWithNextAction(long year, long halfYear, ActionKind actionKind) {
            INextAction nextActionDB = Database.CreateNextAction();
            IList<PatientData> patientList = new List<PatientData>();
            IList<long> patientIds = nextActionDB.FindPatientIdsByYearHalfYearAndActionKind(year, halfYear, actionKind);
            List<long> patientIdsList = new List<long>(patientIds);
            patientIdsList.Sort();
            foreach (long patientId in patientIdsList) {
                patientList.Add(this.FindPatientById(patientId));
            }
            return patientList;
        }

        /// <summary>
        /// Gets all years that have at least one Next Action Defined
        /// </summary>
        /// <returns></returns>
        public virtual IList<long> GetAllNextActionYears() {
            INextAction nextActionDB = Database.CreateNextAction();
            return nextActionDB.GetAllNextActionYears();
        }

        #endregion NextAction

        #region DiadnoseGroup

        /// <summary>
        /// Finds all diagnose groups.
        /// </summary>
        /// <returns></returns>
        public virtual IList<DiagnoseGroupData> FindAllDiagnoseGroups() {
            IDiagnoseGroup diagnoseGroupDB = Database.CreateDiagnoseGroup();
            return diagnoseGroupDB.FindAll();
        }

        /// <summary>
        /// Finds the diagnose group by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual DiagnoseGroupData FindDiagnoseGroupById(long id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the diagnose groups by ids.
        /// </summary>
        /// <param name="dgIds">The dg ids.</param>
        /// <returns></returns>
        public virtual IList<DiagnoseGroupData> FindDiagnoseGroupsByIds(IList<long> dgIds) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the diagnose group.
        /// </summary>
        /// <param name="diagnoseGroup">The diagnose group.</param>
        /// <returns></returns>
        public virtual DiagnoseGroupData InsertDiagnoseGroup(DiagnoseGroupData diagnoseGroup) {
            IDiagnoseGroup diagnoseGroupDB = Database.CreateDiagnoseGroup();
            long dgId = diagnoseGroupDB.Insert(diagnoseGroup);
            diagnoseGroup.DiagnoseGroupDataID = dgId;
            return diagnoseGroup;
        }

        /// <summary>
        /// Updates the diagnose group.
        /// </summary>
        /// <param name="diagnoseGroupData">The diagnose group data.</param>
        /// <returns></returns>
        public virtual bool UpdateDiagnoseGroup(DiagnoseGroupData diagnoseGroupData) {
            IDiagnoseGroup diagnoseGroupDB = Database.CreateDiagnoseGroup();
            return diagnoseGroupDB.Update(diagnoseGroupData);
        }

        /// <summary>
        /// Deletes the diagnose group.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public virtual bool DeleteDiagnoseGroup(long dgId) {
            IDiagnoseGroup diagnoseGroupDB = Database.CreateDiagnoseGroup();
            return diagnoseGroupDB.Delete(dgId);
        }

        /// <summary>
        /// Assigns the patient to diagnose group.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public virtual bool AssignPatientToDiagnoseGroup(long pid, long dgId) {
            IDiagnoseGroup diagnoseGroupDB = Database.CreateDiagnoseGroup();
            return diagnoseGroupDB.AssignPatientToDiagnoseGroup(pid, dgId);
        }

        /// <summary>
        /// Removes the patient from diagnose group.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public virtual bool RemovePatientFromDiagnoseGroup(long pid, long dgId) {
            IDiagnoseGroup diagnoseGroupDB = Database.CreateDiagnoseGroup();
            return diagnoseGroupDB.UnAssignPatientToDiagnoseGroup(pid, dgId);
        }

        /// <summary>
        /// Finds the diagnose group ids by patient id.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public virtual IList<long> FindDiagnoseGroupIdsByPatientId(long pId) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the diagnose group id by patient id.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public virtual IList<DiagnoseGroupData> FindDiagnoseGroupIdByPatientId(long pId) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the patient ids by diagnose group id.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public virtual IList<long> FindPatientIdsByDiagnoseGroupId(long dgId) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds all diagnose groups that are not assigned by patient.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public virtual IList<DiagnoseGroupData> FindAllDiagnoseGroupsThatAreNotAssignedByPatient(long pId) {
            throw new NotImplementedException();
        }

        #endregion

        #region Backup

        /// <summary>
        /// Supportses the backup.
        /// </summary>
        /// <returns></returns>
        public abstract bool SupportsBackup();

        /// <summary>
        /// Backups the path.
        /// </summary>
        /// <returns></returns>
        public abstract string BackupPath();

        /// <summary>
        /// Does the backup.
        /// </summary>
        /// <param name="backupPath">The backup path.</param>
        /// <returns></returns>
        public abstract string DoBackup(string backupPath);

        /// <summary>
        /// Gets the DB filename.
        /// </summary>
        /// <returns></returns>
        public virtual string GetDbFilename() {
            return DBTools.GetDatabaseFile();
        }

        /// <summary>
        /// Does the restore.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="message">The message.</param>
        /// <returns>
        /// true if OK, false if not
        /// </returns>
        public virtual bool DoRestore(string filename, out string message) {
            bool ok = DBTools.Restore(filename, out message);
            if (ok) {
                ClearCaches();
            }
            return ok;
        }

        /// <summary>
        /// Gets the DB file extension.
        /// </summary>
        /// <returns></returns>
        public virtual string GetDbFileExtension() {
            string dbFilename = GetDbFilename();
            if (!string.IsNullOrEmpty(dbFilename) && dbFilename.Contains(".")) {
                return dbFilename.Substring(dbFilename.LastIndexOf('.') + 1, dbFilename.Length - dbFilename.LastIndexOf('.') - 1);
            }
            return null;
        }

        #endregion Backup

        #region DatabaseManagement

        /// <summary>
        /// Supports DB Managemant
        /// </summary>
        /// <returns></returns>
        abstract public bool SupportDatabaseManagement();


        /// <summary>
        /// Sets the DB Settings
        /// </summary>
        /// <param name="databaseSettings"></param>
        public abstract bool SetDatabaseSettings(DatabaseSettings databaseSettings);

        /// <summary>
        /// Gets the Database Settings
        /// </summary>
        /// <returns></returns>
        public abstract DatabaseSettings GetDatabaseSettings();


        #endregion

    }
}
