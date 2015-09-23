using System;
using System.Collections.Generic;
using System.Text;
using SPD.CommonObjects;
using SPD.DAL;
using SPD.BL.Interfaces;
using SPD.CommonUtilities;
using SPD.OtherObjects;

namespace SPD.BL {

    /// <summary>
    /// 
    /// </summary>
    public class SPDBL : AbstractSPDBL {

        #region Cache

        private IList<PatientData> patientBuffer;
        private IList<VisitData> visitBuffer;
        private IList<NextActionData> nextActionBuffer;
        private IList<OperationData> operationBuffer;
        private IList<ImageData> imageBuffer;
        private IDictionary<long, string> finalReportBuffer;
        private IList<DiagnoseGroupData> diagnoseGroupCache;
        private IDictionary<long, IList<long>> patientDiagnoseGroupsCache;
        private IDictionary<long, IList<long>> diagnoseGroupPatientsCache;

        #endregion Cache

        #region Varia

        /// <summary>
        /// Clears the caches.
        /// </summary>
        public override void ClearCaches() {
            this.patientBuffer = null;
            this.visitBuffer = null;
            this.nextActionBuffer = null;
            this.operationBuffer = null;
            this.imageBuffer = null;
            this.finalReportBuffer = null;
            this.diagnoseGroupCache = null;
            this.patientDiagnoseGroupsCache = null;
            this.diagnoseGroupPatientsCache = null;
        }

        #endregion Varia

        #region Patient

        /// <summary>
        /// Gets all patients.
        /// </summary>
        /// <returns></returns>
        public override IList<PatientData> GetAllPatients() {
            if (patientBuffer == null) { //if the buffer isn't filled -> fill it
                patientBuffer = base.GetAllPatients();

            }

            return (List<PatientData>)patientBuffer;
        }

        /// <summary>
        /// Inserts the patient.
        /// </summary>
        /// <param name="patientData">The patient data.</param>
        /// <returns></returns>
        public override PatientData InsertPatient(PatientData patientData) {
            PatientData patient = base.InsertPatient(patientData);
            if (patient != null) {
                if (patientBuffer != null) {
                    patientBuffer.Add(patient); // Add new Patient also to buffer
                }
                return patient;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Updates the patient.
        /// </summary>
        /// <param name="patientData">The patient data.</param>
        /// <returns></returns>
        public override bool UpdatePatient(PatientData patientData) {
            bool ok = base.UpdatePatient(patientData);
            if (ok && patientBuffer != null) { // update in buffer as well
                patientBuffer.Remove(patientData);
                patientBuffer.Add(patientData);
            }
            return ok;
        }

        /// <summary>
        /// Deletes the patient.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public override bool DeletePatient(long pID) {
            bool ok = base.DeletePatient(pID);
            if (ok && patientBuffer != null) { // delete in buffer as well
                patientBuffer.Remove(new PatientData(pID, "", "", DateTime.Now, Sex.male, "", 0, "", ResidentOfAsmara.no, Ambulant.notAmbulant, Finished.undefined, Linz.undefined, DateTime.Now));
            }
            return ok;
        }

        /// <summary>
        /// Finds the diagnose.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public override IList<PatientData> FindDiagnose(string searchString) {
            if (visitBuffer == null) {
                visitBuffer = base.getallVisits();
            }
            IList<PatientData> patients = new List<PatientData>();
            string query = searchString.Trim().ToLower();
            string[] patterns = query.Split(new char[] {' '} , StringSplitOptions.RemoveEmptyEntries);
            foreach(VisitData visit in this.visitBuffer) {
                string diagnosesLower = visit.ExtraDiagnosis.ToLower();
                bool found = true;
                foreach (string pattern in patterns) {
                    if (!String.IsNullOrEmpty(pattern) && !diagnosesLower.Contains(pattern)) {
                        found = false;
                    }
                }
                if (found) {
                    PatientData patient = this.FindPatientById(visit.PatientId);
                    if (!patients.Contains(patient)){
                        patients.Add(patient);
                    }
                }
            }
            foreach (OperationData operation in this.operationBuffer) {
                string diagnosesLower = operation.Diagnoses.ToLower();
                bool found = true;
                foreach (string pattern in patterns) {
                    if (!diagnosesLower.Contains(pattern)) {
                        found = false;
                    }
                }
                if (found) {
                    PatientData patient = this.FindPatientById(operation.PatientId);
                    if (!patients.Contains(patient)) {
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }

        /// <summary>
        /// Finds the procedure.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public override IList<PatientData> FindProcedure(string searchString) {
            if (visitBuffer == null) {
                visitBuffer = base.getallVisits();
            }
            IList<PatientData> patients = new List<PatientData>();
            string query = searchString.Trim().ToLower();
            string[] patterns = query.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (VisitData visit in this.visitBuffer) {
                string prodecureLower = visit.Procedure.ToLower();
                bool found = true;
                foreach (string pattern in patterns) {
                    if (!prodecureLower.Contains(pattern)) {
                        found = false;
                    }
                }
                if (found) {
                    PatientData patient = this.FindPatientById(visit.PatientId);
                    if (!patients.Contains(patient)) {
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }

        /// <summary>
        /// Finds the therapy.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public override IList<PatientData> FindTherapy(string searchString) {
            if (visitBuffer == null) {
                visitBuffer = base.getallVisits();
            }
            IList<PatientData> patients = new List<PatientData>();
            string query = searchString.Trim().ToLower();
            string[] patterns = query.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (VisitData visit in this.visitBuffer) {
                string therapyLower = visit.ExtraTherapy.ToLower();
                bool found = true;
                foreach (string pattern in patterns) {
                    if (!therapyLower.Contains(pattern)) {
                        found = false;
                    }
                }
                if (found) {
                    PatientData patient = this.FindPatientById(visit.PatientId);
                    if (!patients.Contains(patient)) {
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }


        /// <summary>
        /// Gets the final report by patient id.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public override string GetFinalReportByPatientId(long pID) {
            if (finalReportBuffer == null) {
                IPatient patientDB = Database.CreatePatient();
                finalReportBuffer = patientDB.GetAllFinalReports();
            }

            if (finalReportBuffer.ContainsKey(pID)) {
                return finalReportBuffer[pID];
            }

            return String.Empty;
        }

        /// <summary>
        /// Inserts the final report.
        /// </summary>
        /// <param name="finalReport">The ft.</param>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public override bool InsertFinalReport(string finalReport, long pID) {
            bool ok = base.InsertFinalReport(finalReport, pID);

            if (ok && finalReportBuffer != null) {
                if (finalReportBuffer.ContainsKey(pID)) {
                    finalReportBuffer[pID] = finalReport;
                } else {
                    finalReportBuffer.Add(pID, finalReport);
                }
            }
            
            IPatient patientDB = Database.CreatePatient();
            return patientDB.InsertFinalReport(finalReport, pID);
        }

        /// <summary>
        /// Number the of patients.
        /// </summary>
        /// <returns></returns>
        public override long NumberOfPatients() {
            if (patientBuffer == null) {
                return base.NumberOfPatients();

            } else {
                return patientBuffer.Count;
            }
        }

        /// <summary>
        /// Finds the patient by id.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <returns></returns>
        public override PatientData FindPatientById(long patientId) {
            if (patientBuffer == null) {
                patientBuffer = base.GetAllPatients();
            }

            foreach(PatientData patient in patientBuffer) {
                if (patient.Id == patientId) {
                    return patient;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the highes patient id.
        /// </summary>
        /// <returns>th Highest Patient Id or -1 if no Patient Ids are in DB</returns>
        public override long getHighesPatientId() {
            if (patientBuffer == null) {
                patientBuffer = base.GetAllPatients();
            }

            long maxPId = 0;

            foreach (PatientData patient in patientBuffer)
            {
                maxPId = Math.Max(maxPId, patient.Id);
            }
            return maxPId;
        }

        /// <summary>
        /// Finds the patient by linz.
        /// </summary>
        /// <param name="linz">The linz.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByLinz(Linz linz) {
            IList<PatientData> patients = new List<PatientData>();
            foreach(PatientData patient in this.GetAllPatients()) {
                if (patient.Linz == linz) {
                    patients.Add(patient);
                }
            }
            return patients;
        }

        /// <summary>
        /// Finds the patient by asmara.
        /// </summary>
        /// <param name="asmara">The asmara.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByAsmara(ResidentOfAsmara asmara) {
            IList<PatientData> patients = new List<PatientData>();
            foreach (PatientData patient in this.GetAllPatients()) {
                if (patient.ResidentOfAsmara == asmara) {
                    patients.Add(patient);
                }
            }
            return patients;
        }

        /// <summary>
        /// Finds the patient by ambulant.
        /// </summary>
        /// <param name="ambulant">The ambulant.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByAmbulant(Ambulant ambulant) {
            IList<PatientData> patients = new List<PatientData>();
            foreach (PatientData patient in this.GetAllPatients()) {
                if (patient.Ambulant == ambulant) {
                    patients.Add(patient);
                }
            }
            return patients;
        }

        /// <summary>
        /// Finds the patient by wait list.
        /// </summary>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByWaitList() {
            List<PatientData> patients = new List<PatientData>();
            foreach (PatientData patient in this.GetAllPatients()) {
                if (patient.WaitListStartDate != null) {
                    patients.Add(patient);
                }
            }
            patients.Sort(StaticUtilities.comparePatientsByWaitList);
            return patients;
        }

        /// <summary>
        /// Finds the patient by finished.
        /// </summary>
        /// <param name="finished">The finished.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByFinished(Finished finished) {
            IList<PatientData> patients = new List<PatientData>();
            foreach (PatientData patient in this.GetAllPatients()) {
                if (patient.Finished == finished) {
                    patients.Add(patient);
                }
            }
            return patients;
        }


        /// <summary>
        /// Finds the patient by diagnose group id.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByDiagnoseGroupId(long dgId) {
            IList<PatientData> patients = new List<PatientData>();
            IList<long> pIds = FindPatientIdsByDiagnoseGroupId(dgId);
            foreach (PatientData patient in this.GetAllPatients()) {
                if (pIds.Contains(patient.Id)) {
                    patients.Add(patient);
                }
            }
            return patients;
        }

        /// <summary>
        /// Finds the patient by operation date.
        /// </summary>
        /// <param name="halfyear">The halfyear.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByOperationDate(int halfyear, int year) {

            if (halfyear != 1 && halfyear != 2) {
                throw new ArgumentException("halfhear is not 1 and not 2!!");
            }

            DateTime from = new DateTime(year, (halfyear == 1) ? 1 :  7, 1);
            DateTime to = new DateTime(year, (halfyear == 1) ? 6 : 12, (halfyear == 1) ? 30 : 31, 23, 59, 59);

            IList<long> pIds = new List<long>();

            foreach (OperationData op in operationBuffer)
            {
                if (DateTime.Compare(from, op.Date) < 0 && DateTime.Compare(op.Date, to) < 0) {
                    if (!pIds.Contains(op.PatientId)) {
                        pIds.Add(op.PatientId);
                    }
                }
            }

            return FindPatientByIds(pIds);
        }

        /// <summary>
        /// Finds the name of the patient by id and all.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByIdAndAllName(string pattern) {
            List<PatientData> list = new List<PatientData>();

            list.AddRange(FindPatientByAllName(pattern));

            long idpattern;
            if (Int64.TryParse(pattern, out idpattern )) {
                PatientData pd = FindPatientById(idpattern);
                if (pd != null && !list.Contains(pd)) {
                    list.Add(pd);
                }
            }

            return list;
        }

        /// <summary>
        /// Finds the patient by ids.
        /// </summary>
        /// <param name="pIds">The p ids.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientByIds(IList<long> pIds) {
            IList<PatientData> pList = new List<PatientData>();
            foreach (long pId in pIds) {
                pList.Add(FindPatientById(pId));
            }
            return pList;
        }

        #endregion Patient

        #region Visit

        /// <summary>
        /// Getalls the visits.
        /// </summary>
        /// <returns></returns>
        public override IList<VisitData> getallVisits() {
            if (visitBuffer == null) {
                visitBuffer= base.getallVisits();
            }

            return visitBuffer;
        }

        /// <summary>
        /// Updates the visit.
        /// </summary>
        /// <param name="visitData">The visit data.</param>
        /// <returns></returns>
        public override bool UpdateVisit(VisitData visitData) {
            bool ok = base.UpdateVisit(visitData);
            if (ok && visitBuffer != null) { // update in buffer as well
                visitBuffer.Remove(visitData);
                visitBuffer.Add(visitData);
            }
            return ok;
        }

        /// <summary>
        /// Inserts the visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns></returns>
        public override VisitData InsertVisit(VisitData visit) {
            VisitData visitLocal = base.InsertVisit(visit);

            if (visitLocal != null) {
                if (visitBuffer != null) {
                    visitBuffer.Add(visitLocal); // Add new visit also to buffer
                }
                return visitLocal;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Gets the visits by patient ID.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <returns></returns>
        public override IList<VisitData> GetVisitsByPatientID(long patientID) {
            if (visitBuffer == null) {
                visitBuffer= base.getallVisits();
            }
            IList<VisitData> visits = new List<VisitData>();

            foreach (VisitData visit in this.visitBuffer) {
                if (visit.PatientId == patientID) {
                    visits.Add(visit);
                }
            }

            visits = StaticUtilities.SortVisitsListByDate(visits);

            return visits;
        }

        /// <summary>
        /// Gets the diagnose by patient of last visit.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public override string GetDiagnoseByPatientOfLastVisit(long pID) {
            VisitData newestVisit = this.GetLastVisitByPatientID(pID);
            
            if (newestVisit == null) {
                return "";
            } else {
                return newestVisit.ExtraDiagnosis;
            }
        }

        #endregion Visit

        #region Operation

        /// <summary>
        /// Getalls the operations.
        /// </summary>
        /// <returns></returns>
        public override IList<OperationData> getallOperations() {
            if (operationBuffer == null) {
                operationBuffer = base.getallOperations();
            }

            return operationBuffer;
        }

        /// <summary>
        /// Gets the operations by patient ID.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public override IList<OperationData> GetOperationsByPatientID(long p) {
            if (operationBuffer == null) {
                operationBuffer = this.getallOperations();
            }

            IList<OperationData> operations = new List<OperationData>();

            foreach (OperationData operation in operationBuffer) {
                if (operation.PatientId == p) {
                    operations.Add(operation);
                }
            }

            operations = StaticUtilities.SortOperationListByDate(operations);

            return operations;
        }

        /// <summary>
        /// Updates the operation.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        public override bool UpdateOperation(OperationData operationData) {
            bool ok = base.UpdateOperation(operationData);
            if (ok && operationBuffer != null) { // update in buffer as well
                operationBuffer.Remove(operationData);
                operationBuffer.Add(operationData);
            }
            return ok;
        }

        /// <summary>
        /// Inserts the operation.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        public override OperationData InsertOperation(OperationData operationData) {
            OperationData operation = base.InsertOperation(operationData);

            if (operation != null) {
                if (operationBuffer != null) {
                    operationBuffer.Add(operation); // Add new operation also to buffer
                }
                return operation;
            } else {
                return null;
            }
        }

        #endregion Operation

        #region Image

        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <param name="imageData">The image data.</param>
        /// <returns></returns>
        public override bool DeleteImage(ImageData imageData) {
            bool ok = base.DeleteImage(imageData);
            if (ok && imageBuffer != null) { // delete in buffer as well
                imageBuffer.Remove(imageData);
            }
            return ok;
        }

        /// <summary>
        /// Inserts the image.
        /// </summary>
        /// <param name="imageData">The image data.</param>
        /// <returns></returns>
        public override ImageData InsertImage(ImageData imageData) {
            ImageData image = base.InsertImage(imageData);
            if (image != null) {
                if (imageBuffer != null) {
                    imageBuffer.Add(imageData); // Add new Image also to buffer
                }
                return image;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Gets the images by patient ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public override IList<ImageData> GetImagesByPatientID(long pID) {
            if (imageBuffer == null) {
                IPhoto photoDB = Database.CreatePhoto();
                imageBuffer = photoDB.FindAll();
            }

            IList<ImageData> images = new List<ImageData>();

            foreach (ImageData image in imageBuffer) {
                if (image.PatientID == pID) {
                    images.Add(image);
                }
            }

            return images;
        }

        #endregion Image

        #region NextAction

        /// <summary>
        /// Gets all next actions.
        /// </summary>
        /// <returns></returns>
        public override IList<NextActionData> GetAllNextActions() {
            if (nextActionBuffer == null) {
                nextActionBuffer = base.GetAllNextActions();
            }

            return nextActionBuffer;
        }

        /// <summary>
        /// Deletes the Action.
        /// </summary>
        /// <param name="nextActionData">The Next Action data.</param>
        /// <returns></returns>
        public override bool DeleteNextAction(NextActionData nextActionData) {
            bool ok = base.DeleteNextAction(nextActionData);
            if (ok && nextActionBuffer != null) { // delete in buffer as well
                nextActionBuffer.Remove(nextActionData);
            }
            return ok;
        }

        /// <summary>
        /// Inserts the next action.
        /// </summary>
        /// <param name="nextActionData">The next action data.</param>
        /// <returns></returns>
        public override NextActionData InsertNextAction(NextActionData nextActionData) {
            NextActionData nextAction = base.InsertNextAction(nextActionData);

            if (nextAction != null) {
                if (nextActionBuffer != null) {
                    nextActionBuffer.Add(nextAction); // Add new next Action also to buffer
                }
                return nextAction;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Gets the Next Actions by patient ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public override IList<NextActionData> GetNextActionsByPatientID(long pID) {
            if (nextActionBuffer == null) {
                nextActionBuffer = base.GetAllNextActions();
            }

            IList<NextActionData> nextActions = new List<NextActionData>();
            foreach(NextActionData nextAction in nextActionBuffer) {
                if (nextAction.PatientID == pID) {
                    nextActions.Add(nextAction);
                }
            }
            return nextActions;
        }

        /// <summary>
        /// Finds the patients with next action.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="halfYear">The half year.</param>
        /// <param name="actionKind">Kind of the action.</param>
        /// <returns></returns>
        public override IList<PatientData> FindPatientsWithNextAction(long year, long halfYear, ActionKind actionKind) {
            if (nextActionBuffer == null) {
                nextActionBuffer = base.GetAllNextActions();
            }
            
            IList<PatientData> patientList = new List<PatientData>();
            List<long> patientIdsList = new List<long>();

            foreach (NextActionData nextAction in nextActionBuffer) {
                if (nextAction.ActionYear == year && nextAction.ActionhalfYear == halfYear && nextAction.ActionKind == actionKind) {
                    patientIdsList.Add(nextAction.PatientID);
                }
            }

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
        public override IList<long> GetAllNextActionYears() {
            if (nextActionBuffer == null) {
                nextActionBuffer = base.GetAllNextActions();
            }

            List<long> years = new List<long>();
            foreach (NextActionData nextAction in nextActionBuffer) {
                if (!years.Contains(nextAction.ActionYear)) {
                    years.Add(nextAction.ActionYear);
                }
            }
            years.Sort();
            return years;
        }

        #endregion NextAction

        #region DiadnoseGroup

        /// <summary>
        /// Finds all diagnose groups.
        /// </summary>
        /// <returns></returns>
        public override IList<DiagnoseGroupData> FindAllDiagnoseGroups() {
            if (diagnoseGroupCache == null) {
                diagnoseGroupCache = new List<DiagnoseGroupData>();
                IList<DiagnoseGroupData> allDiagnoseGroups = base.FindAllDiagnoseGroups();
                foreach (DiagnoseGroupData diagnosegroup in allDiagnoseGroups) {
                    diagnoseGroupCache.Add(diagnosegroup);
                }
            }
            return diagnoseGroupCache;
        }

        /// <summary>
        /// Finds the diagnose group by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override DiagnoseGroupData FindDiagnoseGroupById(long id) {
            foreach (DiagnoseGroupData diagnosegroup in FindAllDiagnoseGroups()) {
                if (diagnosegroup.DiagnoseGroupDataID == id) {
                    return diagnosegroup;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the diagnose groups by ids.
        /// </summary>
        /// <param name="dgIds">The dg ids.</param>
        /// <returns></returns>
        public override IList<DiagnoseGroupData> FindDiagnoseGroupsByIds(IList<long> dgIds) {
            IList<DiagnoseGroupData> diagnosegroups = new List<DiagnoseGroupData>();
            fillPatientDiagnoseGroupCachesIfEmpty();
            foreach(DiagnoseGroupData dgd in FindAllDiagnoseGroups()) {
                if (dgIds.Contains(dgd.DiagnoseGroupDataID)) {
                    diagnosegroups.Add(dgd);
                }
            }
            return diagnosegroups;
        }

        /// <summary>
        /// Inserts the diagnose group.
        /// </summary>
        /// <param name="diagnoseGroup">The diagnose group.</param>
        /// <returns></returns>
        public override DiagnoseGroupData InsertDiagnoseGroup(DiagnoseGroupData diagnoseGroup) {
            DiagnoseGroupData diagnoseGroupRet = base.InsertDiagnoseGroup(diagnoseGroup);
            diagnoseGroupCache = null;
            return diagnoseGroupRet;
        }

        /// <summary>
        /// Updates the diagnose group.
        /// </summary>
        /// <param name="diagnoseGroupData">The diagnose group data.</param>
        /// <returns></returns>
        public override bool UpdateDiagnoseGroup(DiagnoseGroupData diagnoseGroupData) {
            bool ok = base.UpdateDiagnoseGroup(diagnoseGroupData);
            diagnoseGroupCache = null;
            return ok;
        }

        /// <summary>
        /// Deletes the diagnose group.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public override bool DeleteDiagnoseGroup(long dgId) {
            bool ok = base.DeleteDiagnoseGroup(dgId);
            diagnoseGroupCache = null;
            return ok;
        }

        /// <summary>
        /// Assigns the patient to diagnose group.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public override bool AssignPatientToDiagnoseGroup(long pId, long dgId) {
            bool ok = base.AssignPatientToDiagnoseGroup(pId, dgId);
            patientDiagnoseGroupsCache = null;
            diagnoseGroupPatientsCache = null;
            return ok;
        }

        /// <summary>
        /// Removes the patient from diagnose group.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public override bool RemovePatientFromDiagnoseGroup(long pId, long dgId) {
            bool ok = base.RemovePatientFromDiagnoseGroup(pId, dgId);
            patientDiagnoseGroupsCache = null;
            diagnoseGroupPatientsCache = null;
            return ok;
        }

        /// <summary>
        /// Fills the patient diagnose group caches if empty.
        /// </summary>
        private void fillPatientDiagnoseGroupCachesIfEmpty() {
            if (patientDiagnoseGroupsCache == null || diagnoseGroupPatientsCache == null) {
                patientDiagnoseGroupsCache = new Dictionary<long, IList<long>>();
                diagnoseGroupPatientsCache = new Dictionary<long, IList<long>>();
                IDiagnoseGroup diagnoseGroupDB = Database.CreateDiagnoseGroup();
                IList<Pair<long, long>> pdg = diagnoseGroupDB.GetAllPatientDiagnoseGroup();
                foreach(Pair<long, long> pair in pdg) {
                    if (patientDiagnoseGroupsCache.ContainsKey(pair.First)) {
                        patientDiagnoseGroupsCache[pair.First].Add(pair.Second);
                    } else {
                        IList<long> dgIds = new List<long>();
                        dgIds.Add(pair.Second);
                        patientDiagnoseGroupsCache.Add(pair.First, dgIds);
                    }

                    if (diagnoseGroupPatientsCache.ContainsKey(pair.Second)) {
                        diagnoseGroupPatientsCache[pair.Second].Add(pair.First);
                    } else {
                        IList<long> pIdsIds = new List<long>();
                        pIdsIds.Add(pair.First);
                        diagnoseGroupPatientsCache.Add(pair.Second, pIdsIds);
                    }
                }
            }
        }

        /// <summary>
        /// Finds the diagnose group ids by patient id.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public override IList<long> FindDiagnoseGroupIdsByPatientId(long pId) {
            fillPatientDiagnoseGroupCachesIfEmpty();
            if (patientDiagnoseGroupsCache.ContainsKey(pId)) {
                IList<long> diagnoseGroupIds = patientDiagnoseGroupsCache[pId];
                return diagnoseGroupIds;
            } else {
                return new List<long>();
            }
        }

        /// <summary>
        /// Finds the diagnose group id by patient id.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public override IList<DiagnoseGroupData> FindDiagnoseGroupIdByPatientId(long pId) {
            IList<DiagnoseGroupData> diagnoseGroups = FindDiagnoseGroupsByIds(FindDiagnoseGroupIdsByPatientId(pId));
            return diagnoseGroups;
        }

        /// <summary>
        /// Finds the patient ids by diagnose group id.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public override IList<long> FindPatientIdsByDiagnoseGroupId(long dgId) {
            fillPatientDiagnoseGroupCachesIfEmpty();
            if (diagnoseGroupPatientsCache.ContainsKey(dgId)) {
                return diagnoseGroupPatientsCache[dgId];
            } else {
                return new List<long>();
            }
        }

        /// <summary>
        /// Finds all diagnose groups that are not assigned by patient.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public override IList<DiagnoseGroupData> FindAllDiagnoseGroupsThatAreNotAssignedByPatient(long pId) {
            IList<DiagnoseGroupData> notAssignedPGIds = new List<DiagnoseGroupData>();
            fillPatientDiagnoseGroupCachesIfEmpty();
            IList<long> assignedIds;
            if (patientDiagnoseGroupsCache.ContainsKey(pId)) {
                assignedIds = patientDiagnoseGroupsCache[pId];
            } else {
                assignedIds = new List<long>();
            }
            foreach(DiagnoseGroupData dgd in FindAllDiagnoseGroups()) {
                if (!assignedIds.Contains(dgd.DiagnoseGroupDataID)) {
                    notAssignedPGIds.Add(dgd);
                }
            }
            return notAssignedPGIds;
        }

        #endregion

        #region Backup

        /// <summary>
        /// Supportses the backup.
        /// </summary>
        /// <returns></returns>
        public override bool SupportsBackup() {
            return DBTools.SupportsBackup();
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
            return true;
        }

        /// <summary>
        /// Sets the DB Settings
        /// </summary>
        /// <param name="databaseSettings"></param>
        public override bool SetDatabaseSettings(DatabaseSettings databaseSettings) {
            return DBTools.SetDatabaseSettings(databaseSettings);
        }

        /// <summary>
        /// Gets the Database Settings
        /// </summary>
        /// <returns></returns>
        public override DatabaseSettings GetDatabaseSettings() {
            return DBTools.GetDatabaseSettings();
        }

        #endregion

    }
}
