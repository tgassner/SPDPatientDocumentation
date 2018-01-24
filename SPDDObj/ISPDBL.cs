using System;
using System.Collections.Generic;
using SPD.CommonObjects;
using System.ServiceModel;
using SPD.OtherObjects;
namespace SPD.BL.Interfaces {

    /// <summary>
    /// Interface fpr the Business Layer
    /// </summary>
    [ServiceContract(Namespace = "http://SPD.BL.Interfaces")]
    public interface ISPDBL {

        #region Varia
        
        /// <summary>
        /// Clears the caches.
        /// </summary>
        [OperationContract]
        void ClearCaches();
        
        #endregion Varia

        #region Patient
        /// <summary>
        /// Gets all patients.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> GetAllPatients();
        /// <summary>
        /// Inserts the patient.
        /// </summary>
        /// <param name="patientData">The patient data.</param>
        /// <returns></returns>
        [OperationContract]
        PatientData InsertPatient(PatientData patientData);
        /// <summary>
        /// Updates the patient.
        /// </summary>
        /// <param name="patientData">The patient data.</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdatePatient(PatientData patientData);
        /// <summary>
        /// Deletes the patient.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        [OperationContract]
        bool DeletePatient(long pID);
        /// <summary>
        /// Finds the diagnose.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindDiagnose(string searchString);
        /// <summary>
        /// Finds the procedure.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindProcedure(string searchString);
        /// <summary>
        /// Finds the therapy.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindTherapy(string searchString);
        /// <summary>
        /// Gets the final report by patient id.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        [OperationContract]
        string GetFinalReportByPatientId(long pID);
        /// <summary>
        /// Gets the stone report by patient id.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        [OperationContract]
        string GetStoneReportByPatientId(long pID);
        /// <summary>
        /// Inserts the final report.
        /// </summary>
        /// <param name="finalReport">The ft.</param>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertFinalReport(string finalReport, long pID);
        [OperationContract]
        bool InsertStoneReport(string stoneReport, long pID);
        /// <summary>
        /// Number the of patients.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        long NumberOfPatients();
        /// <summary>
        /// Finds the patient by id.
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <returns></returns>
        /// 
        [OperationContract]
        PatientData FindPatientById(long Id);
        /// <summary>
        /// Finds the name of the patient by.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="surname">The surname.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByName(string firstName, string surname);
        /// <summary>
        /// Finds the patient by all Names.
        /// </summary>
        /// <param name="name">Name Pattern.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByAllName(string name);
        /// <summary>
        /// Finds the patient by phone Nr.
        /// </summary>
        /// <param name="phone">phone Pattern.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByPhone(string phone);
        /// <summary>
        /// checks if Phone is already stored?
        /// </summary>
        /// <param name="phone">phone Pattern.</param>
        /// <returns>true if phone nr exists, false if not.</returns>
        [OperationContract]
        bool DoesPhoneExist(string phone);
        /// <summary>
        /// Finds the patient by linz.
        /// </summary>
        /// <param name="linz">The linz.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByLinz(Linz linz);
        /// <summary>
        /// Finds the patient by asmara.
        /// </summary>
        /// <param name="asmara">The asmara.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByAsmara(ResidentOfAsmara asmara);
        /// <summary>
        /// Finds the patient by ambulant.
        /// </summary>
        /// <param name="ambulant">The ambulant.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByAmbulant(Ambulant ambulant);
        /// <summary>
        /// Finds the patient by wait List.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByWaitList();
        /// <summary>
        /// Finds the patient by finished.
        /// </summary>
        /// <param name="finished">The finished.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByFinished(Finished finished);
        /// <summary>
        /// Finds the patient by diagnose group id.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByDiagnoseGroupId(long dgId);
        /// <summary>
        /// Finds the patient by operation date.
        /// </summary>
        /// <param name="halfyear">The halfyear.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByOperationDate(int halfyear, int year);
        /// <summary>
        /// Finds the name of the patient by id and all.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByIdAndAllName(string pattern);
        /// <summary>
        /// Finds the patient by ids.
        /// </summary>
        /// <param name="pIds">The p ids.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientByIds(IList<long> pIds);
        /// <summary>
        /// Gets the highes patient id.
        /// </summary>
        /// <returns>th Highest Patient Id or 0 if no Patient Ids are in DB</returns>
        [OperationContract]
        long getHighesPatientId();

        #endregion Patient

        #region Visit
        /// <summary>
        /// Getalls the visits.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<VisitData> getallVisits();
        /// <summary>
        /// Gets the last visit by patient ID.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        [OperationContract]
        VisitData GetLastVisitByPatientID(long pId);
        /// <summary>
        /// Updates the visit.
        /// </summary>
        /// <param name="visitData">The visit data.</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateVisit(VisitData visitData);
        /// <summary>
        /// Inserts the visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns></returns>
        [OperationContract]
        VisitData InsertVisit(VisitData visit);
        /// <summary>
        /// Gets the visits by patient ID.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <returns></returns>
        [OperationContract]
        IList<VisitData> GetVisitsByPatientID(long patientID);
        /// <summary>
        /// Gets the diagnose by patient of last visit.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        [OperationContract]
        string GetDiagnoseByPatientOfLastVisit(long pID);
        /// <summary>
        /// Number the of visits.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        long NumberOfVisits();
        #endregion Visit

        #region Operation
        /// <summary>
        /// Getalls the operations.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<OperationData> getallOperations();
        /// <summary>
        /// Gets the last operation by patient ID.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        [OperationContract]
        OperationData GetLastOperationByPatientID(long pId);
        /// <summary>
        /// Gets the operations by patient ID.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        [OperationContract]
        IList<OperationData> GetOperationsByPatientID(long p);
        /// <summary>
        /// Updates the operation.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateOperation(OperationData operationData);
        /// <summary>
        /// Inserts the operation.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        [OperationContract]
        OperationData InsertOperation(OperationData operationData);
        /// <summary>
        /// Number the of operations.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        long NumberOfOperations();
        #endregion Operation

        #region Image
        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <param name="imageData">The image data.</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteImage(ImageData imageData);
        /// <summary>
        /// Inserts the image.
        /// </summary>
        /// <param name="imageData">The image data.</param>
        /// <returns></returns>
        [OperationContract]
        ImageData InsertImage(ImageData imageData);
        /// <summary>
        /// Gets the images by patient ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        [OperationContract]
        IList<ImageData> GetImagesByPatientID(long pID);
        #endregion Image

        #region NextAction
        /// <summary>
        /// Gets all next actions.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<NextActionData> GetAllNextActions();
        /// <summary>
        /// Deletes the Action.
        /// </summary>
        /// <param name="nextActionData">The Next Action data.</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteNextAction(NextActionData nextActionData);
        /// <summary>
        /// Inserts the Action.
        /// </summary>
        /// <param name="nextActionData">The image data.</param>
        /// <returns></returns>
        [OperationContract]
        NextActionData InsertNextAction(NextActionData nextActionData);
        /// <summary>
        /// Gets the Next Actions by patient ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        [OperationContract]
        IList<NextActionData> GetNextActionsByPatientID(long pID);
        /// <summary>
        /// Finds the patients with next action.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="halfYear">The half year.</param>
        /// <param name="actionKind">Kind of the action.</param>
        /// <returns></returns>
        [OperationContract]
        IList<PatientData> FindPatientsWithNextAction(long year, long halfYear, ActionKind actionKind);
        /// <summary>
        /// Gets all years that have at least one Next Action Defined
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<long> GetAllNextActionYears();


        #endregion NextAction

        #region DiadnoseGroup

        /// <summary>
        /// Finds all diagnose groups.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<DiagnoseGroupData> FindAllDiagnoseGroups();

        /// <summary>
        /// Finds the diagnose groups by ids.
        /// </summary>
        /// <param name="dgIds">The dg ids.</param>
        /// <returns></returns>
        [OperationContract]
        IList<DiagnoseGroupData> FindDiagnoseGroupsByIds(IList<long> dgIds);

        /// <summary>
        /// Finds the diagnose group by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [OperationContract]
        DiagnoseGroupData FindDiagnoseGroupById(long id);

        /// <summary>
        /// Inserts the diagnose group.
        /// </summary>
        /// <param name="diagnoseGroup">The diagnose group.</param>
        /// <returns></returns>
        [OperationContract]
        DiagnoseGroupData InsertDiagnoseGroup(DiagnoseGroupData diagnoseGroup);

        /// <summary>
        /// Updates the diagnose group.
        /// </summary>
        /// <param name="diagnoseGroupData">The diagnose group data.</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateDiagnoseGroup(DiagnoseGroupData diagnoseGroupData);

        /// <summary>
        /// Deletes the diagnose group.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteDiagnoseGroup(long dgId);

        /// <summary>
        /// Assigns the patient to diagnose group.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        [OperationContract]
        bool AssignPatientToDiagnoseGroup(long pid, long dgId);

        /// <summary>
        /// Removes the patient from diagnose group.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        [OperationContract]
        bool RemovePatientFromDiagnoseGroup(long pid, long dgId);

        /// <summary>
        /// Finds the diagnose group ids by patient id.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        [OperationContract]
        IList<long> FindDiagnoseGroupIdsByPatientId(long pId);

        /// <summary>
        /// Finds the diagnose group id by patient id.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        [OperationContract]
        IList<DiagnoseGroupData> FindDiagnoseGroupIdByPatientId(long pId);

        /// <summary>
        /// Finds the patient ids by diagnose group id.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        [OperationContract]
        IList<long> FindPatientIdsByDiagnoseGroupId(long dgId);

        /// <summary>
        /// Finds all diagnose groups that are not assigned by patient.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        [OperationContract]
        IList<DiagnoseGroupData> FindAllDiagnoseGroupsThatAreNotAssignedByPatient(long pId);

        #endregion

        #region Backup
        /// <summary>
        /// Supportes the backup.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool SupportsBackup();
        /// <summary>
        /// Backups the path.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string BackupPath();

        /// <summary>
        /// Does the backup.
        /// </summary>
        /// <param name="backupPath">The backup path.</param>
        /// <returns></returns>
        [OperationContract]
        string DoBackup(string backupPath);

        /// <summary>
        /// Gets the DB filename.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetDbFilename();

        /// <summary>
        /// Does the restore.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="message">The message.</param>
        /// <returns>
        /// true if OK, false if not
        /// </returns>
        [OperationContract]
        bool DoRestore(string filename, out string message);

        /// <summary>
        /// Gets the DB file extension.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetDbFileExtension();

        #endregion Backup

        #region DatabaseManagement

        /// <summary>
        /// Supports DB Managemant
        /// </summary>
        /// <returns></returns>
        bool SupportDatabaseManagement();

        /// <summary>
        /// Sets the DB Settings
        /// </summary>
        /// <param name="databaseSettings"></param>
        /// <returns></returns>
        bool SetDatabaseSettings(DatabaseSettings databaseSettings);

        /// <summary>
        /// Gets the Database Settings
        /// </summary>
        /// <returns></returns>
        DatabaseSettings GetDatabaseSettings();

        #endregion
    }
}
