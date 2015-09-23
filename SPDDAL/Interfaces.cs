using System;
using System.Collections.Generic;
using System.Text;
using SPD.CommonObjects;
using SPD.CommonUtilities;

namespace SPD.DAL {

    /// <summary>
    /// Interface for Patient Dataobject
    /// </summary>
    public interface IPatient {
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IList<PatientData> FindAll();
        /// <summary>
        /// Finds the by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        PatientData FindByID(long id);
        /// <summary>
        /// Inserts the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        long Insert(PatientData patient);
        /// <summary>
        /// Updates the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        bool Update(PatientData patient);
        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool Delete(long id);
        /// <summary>
        /// Numbers the of patients.
        /// </summary>
        /// <returns></returns>
        long NumberOfPatients();

        /// <summary>
        /// Finds the diagnose.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        IList<PatientData> FindDiagnose(string searchString);
        /// <summary>
        /// Finds the procedure.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        IList<PatientData> FindProcedure(string searchString);
        /// <summary>
        /// Finds the patients by final report.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        IList<PatientData> FindPatientsByFinalReport(string searchString);
        /// <summary>
        /// Inserts the final report.
        /// </summary>
        /// <param name="ft">The ft.</param>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        bool InsertFinalReport(string ft,long pID);
        /// <summary>
        /// Gets the final report by patent ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        string GetFinalReportByPatentID(long pID);
        /// <summary>
        /// Gets all final reports.
        /// </summary>
        /// <returns></returns>
        IDictionary<long, string> GetAllFinalReports();
    }

    /// <summary>
    /// Interface for Visit Dataobject
    /// </summary>
    public interface IVisit {
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IList<VisitData> FindAll();
        /// <summary>
        /// Finds the by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        VisitData FindByID(long id);
        /// <summary>
        /// Finds the by patient ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        IList<VisitData> FindByPatientID(long id);
        /// <summary>
        /// Inserts the specified visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns></returns>
        long Insert(VisitData visit);
        /// <summary>
        /// Updates the specified visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns></returns>
        bool Update(VisitData visit);
        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool Delete(long id);
    }

    /// <summary>
    /// Interface for Operation Dataobject
    /// </summary>
    public interface IOperation{
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IList<OperationData> FindAll();
        /// <summary>
        /// Finds the by patient id.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <returns></returns>
        IList<OperationData> FindByPatientId(long patientId);
        /// <summary>
        /// Finds the by operation id.
        /// </summary>
        /// <param name="operationId">The operation id.</param>
        /// <returns></returns>
        OperationData FindByOperationId(long operationId);
        /// <summary>
        /// Inserts the specified odata.
        /// </summary>
        /// <param name="odata">The odata.</param>
        /// <returns></returns>
        long Insert(OperationData odata);
        /// <summary>
        /// Deletes the specified operation id.
        /// </summary>
        /// <param name="operationId">The operation id.</param>
        /// <returns></returns>
        bool Delete(long operationId);
        /// <summary>
        /// Updates the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <returns></returns>
        bool Update(OperationData operation);
    }

    /// <summary>
    /// Interface for Photo Dataobject
    /// </summary>
    public interface IPhoto {
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IList<ImageData> FindAll();
        /// <summary>
        /// Finds the by patient id.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <returns></returns>
        IList<ImageData> FindByPatientId(long patientId);
        /// <summary>
        /// Finds the by photo id.
        /// </summary>
        /// <param name="photoID">The photo ID.</param>
        /// <returns></returns>
        ImageData FindByPhotoId(long photoID);
        /// <summary>
        /// Inserts the specified idata.
        /// </summary>
        /// <param name="idata">The idata.</param>
        /// <returns></returns>
        long Insert(ImageData idata);
        /// <summary>
        /// Deletes the specified photo id.
        /// </summary>
        /// <param name="photoId">The photo id.</param>
        /// <returns></returns>
        bool Delete(long photoId);
        /// <summary>
        /// Updates the specified photo.
        /// </summary>
        /// <param name="photo">The photo.</param>
        /// <returns></returns>
        bool Update(ImageData photo);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface INextAction {
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IList<NextActionData> FindAll();
        /// <summary>
        /// Gets the by patient id.
        /// </summary>
        /// <param name="nextActionId">The next Action id.</param>
        /// <returns></returns>
        NextActionData FindById(long nextActionId);
        /// <summary>
        /// Gets the by patient id.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <returns></returns>
        IList<NextActionData> FindByPatientId(long patientId);
        /// <summary>
        /// Inserts the specified nadata.
        /// </summary>
        /// <param name="nadata">The nadata.</param>
        /// <returns></returns>
        long Insert(NextActionData nadata);
        /// <summary>
        /// Deletes the specified next action id.
        /// </summary>
        /// <param name="nextActionId">The next action id.</param>
        /// <returns></returns>
        bool Delete(long nextActionId);
        /// <summary>
        /// Updates the specified nadata.
        /// </summary>
        /// <param name="nadata">The nadata.</param>
        /// <returns></returns>
        bool Update(NextActionData nadata);
        /// <summary>
        /// Finds the kind of the action by year half year and action.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="halfYear">The half year.</param>
        /// <param name="actionKind">Kind of the action.</param>
        /// <returns></returns>
        IList<long> FindPatientIdsByYearHalfYearAndActionKind(long year, long halfYear, ActionKind actionKind);
        /// <summary>
        /// Gets all years that have at least one Next Action Defined
        /// </summary>
        /// <returns></returns>
        IList<long> GetAllNextActionYears();
    }

    /// <summary>
    /// Interface for DiagnoseGroup Dataobject
    /// </summary>
    public interface IDiagnoseGroup {
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IList<DiagnoseGroupData> FindAll();
        /// <summary>
        /// Finds the by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        DiagnoseGroupData FindByID(long id);
        /// <summary>
        /// Inserts the specified diagnose group.
        /// </summary>
        /// <param name="diagnoseGroup">The diagnose group.</param>
        /// <returns></returns>
        long Insert(DiagnoseGroupData diagnoseGroup);
        /// <summary>
        /// Updates the specified visit.
        /// </summary>
        /// <param name="diagnoseGroup">The diagnoseGroup.</param>
        /// <returns></returns>
        bool Update(DiagnoseGroupData diagnoseGroup);
        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool Delete(long id);
        /// <summary>
        /// Gets all patient diagnose group.
        /// </summary>
        /// <returns></returns>
        IList<Pair<long, long>> GetAllPatientDiagnoseGroup();
        /// <summary>
        /// Assigns the P atient to diagnose group.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        bool AssignPatientToDiagnoseGroup(long pId, long dgId);
        /// <summary>
        /// Uns the assign P atient to diagnose group.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        bool UnAssignPatientToDiagnoseGroup(long pId, long dgId);
    }

}
