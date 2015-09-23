using System;
using System.Collections.Generic;
using System.Text;
using SPD.BL.Interfaces;
using SPD.WCFClient;
using SPD.CommonObjects;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SPD.OtherObjects;
using System.Windows.Forms;


namespace SPD.WCFClient {
    /// <summary>
    /// WCF Implementation of the Businesslogic Interface 
    /// </summary>
    public class SPDWCFBL : ISPDBL {

        private EndpointAddress endpointAddress;
        private System.ServiceModel.Channels.Binding binding;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPDWCFBL"/> class.
        /// </summary>
        /// <param name="endPointData">The end point data.</param>
        public SPDWCFBL(EndpointData endPointData) {
            string protocol;
            string uri;

            string host = endPointData.Host;
            string port = endPointData.port.ToString();

            switch (endPointData.Protocol) {
                case WCFProtocol.http:
                    protocol = "http";
                    binding = new WSHttpBinding();
                    uri = protocol + "://" + host + ":" + port + "/SPDService";
                    break;
                case WCFProtocol.tcp:
                    protocol = "net.tcp";
                    binding = new NetTcpBinding();
                    uri = protocol + "://" + host + ":" + port + "/SPDService";
                    break;
                case WCFProtocol.namedPipe:
                    protocol = "net.pipe";
                    binding = new NetNamedPipeBinding();
                    uri = protocol + "://" + host + "/SPDService";
                    break;
                default:
                    protocol = "";
                    uri = "";
                    break;
            }

            endpointAddress = new EndpointAddress(uri);

            try {
                this.SupportsBackup();
            } catch (Exception) {
                MessageBox.Show("The connection to the server could not be established\r\nPlease be sure that the Server runs, restart SPD\r\nand be sure to have the right parameters");
                Environment.Exit(1);
            }
            
        }

        /// <summary>
        /// Gets all patients.
        /// </summary>
        /// <returns></returns>
        public IList<PatientData> GetAllPatients() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetAllPatients();
            }
        }

        /// <summary>
        /// Inserts the patient.
        /// </summary>
        /// <param name="patientData">The patient data.</param>
        /// <returns></returns>
        public PatientData InsertPatient(PatientData patientData) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.InsertPatient(patientData);
            }
        }

        /// <summary>
        /// Updates the patient.
        /// </summary>
        /// <param name="patientData">The patient data.</param>
        /// <returns></returns>
        public bool UpdatePatient(PatientData patientData) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.UpdatePatient(patientData);
            }
        }

        /// <summary>
        /// Deletes the patient.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public bool DeletePatient(long pID) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.DeletePatient(pID);
            }
        }

        /// <summary>
        /// Finds the diagnose.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public IList<PatientData> FindDiagnose(string searchString) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindDiagnose(searchString);
            }
        }

        /// <summary>
        /// Finds the procedure.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public IList<PatientData> FindProcedure(string searchString) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindProcedure(searchString);
            }
        }

        /// <summary>
        /// Finds the therapy.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public IList<PatientData> FindTherapy(string searchString) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindTherapy(searchString);
            }
        }

        /// <summary>
        /// Gets the further treatment by patient id.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public string GetFurtherTreatmentByPatientId(long pID) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetFurtherTreatmentByPatientId(pID);
            }
        }

        /// <summary>
        /// Inserts the further treatment.
        /// </summary>
        /// <param name="ft">The ft.</param>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public bool InsertFurtherTreatment(string ft, long pID) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.InsertFurtherTreatment(ft,pID);
            }
        }

        /// <summary>
        /// Number the of patients.
        /// </summary>
        /// <returns></returns>
        public long NumberOfPatients() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.NumberOfPatients();
            }
        }

        /// <summary>
        /// Finds the patient by id.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <returns></returns>
        public PatientData FindPatientById(long patientId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientById(patientId);
            }
        }


        /// <summary>
        /// Finds the name of the patient by.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="surname">The surname.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByName(string firstName, string surname) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByName(firstName, surname);
            }
        }

        /// <summary>
        /// Finds the patient by all Names.
        /// </summary>
        /// <param name="name">Name Pattern.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByAllName(string name) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByAllName(name);
            }
        }

        /// <summary>
        /// Finds the patient by Phone Nr.
        /// </summary>
        /// <param name="phone">Phone Pattern.</param>
        /// <returns></returns>
        public virtual IList<PatientData> FindPatientByPhone(string phone) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByPhone(phone);
            }
        }

        /// <summary>
        /// checks if Phone is already stored?
        /// </summary>
        /// <param name="phone">phone Pattern.</param>
        /// <returns>true if phone nr exists, false if not.</returns>
        public bool DoesPhoneExist(string phone) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.DoesPhoneExist(phone);
            }
        }

        /// <summary>
        /// Finds the patient by linz.
        /// </summary>
        /// <param name="linz">The linz.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByLinz(Linz linz) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByLinz(linz);
            }
        }
        /// <summary>
        /// Finds the patient by asmara.
        /// </summary>
        /// <param name="asmara">The asmara.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByAsmara(ResidentOfAsmara asmara) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByAsmara(asmara);
            }
        }

        /// <summary>
        /// Finds the patient by ambulant.
        /// </summary>
        /// <param name="ambulant">The ambulant.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByAmbulant(Ambulant ambulant) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByAmbulant(ambulant);
            }
        }
        /// <summary>
        /// Finds the patient by finished.
        /// </summary>
        /// <param name="finished">The finished.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByFinished(Finished finished) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByFinished(finished);
            }
        }

        /// <summary>
        /// Finds the patient by diagnose group id.
        /// </summary>
        /// <param name="dgId">The dg id.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByDiagnoseGroupId(long dgId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByDiagnoseGroupId(dgId);
            }
        }

        /// <summary>
        /// Finds the patient by operation date.
        /// </summary>
        /// <param name="halfyear">The halfyear.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByOperationDate(int halfyear, int year) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByOperationDate(halfyear, year);
            }
        }

        /// <summary>
        /// Finds the name of the patient by id and all.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByIdAndAllName(string pattern) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByIdAndAllName(pattern);
            }
        }

        /// <summary>
        /// Finds the patient by ids.
        /// </summary>
        /// <param name="pIds">The p ids.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientByIds(IList<long> pIds) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientByIds(pIds);
            }
        }

        /// <summary>
        /// Getalls the visits.
        /// </summary>
        /// <returns></returns>
        public IList<VisitData> getallVisits() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.getallVisits();
            }
        }

        /// <summary>
        /// Gets the last visit by patient ID.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public VisitData GetLastVisitByPatientID(long pId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetLastVisitByPatientID(pId);
            }
        }

        /// <summary>
        /// Updates the visit.
        /// </summary>
        /// <param name="visitData">The visit data.</param>
        /// <returns></returns>
        public bool UpdateVisit(VisitData visitData) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.UpdateVisit(visitData);
            }
        }

        /// <summary>
        /// Inserts the visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns></returns>
        public VisitData InsertVisit(VisitData visit) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.InsertVisit(visit);
            }
        }

        /// <summary>
        /// Gets the visits by patient ID.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <returns></returns>
        public IList<VisitData> GetVisitsByPatientID(long patientID) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetVisitsByPatientID(patientID);
            }
        }

        /// <summary>
        /// Gets the diagnose by patient of last visit.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public string GetDiagnoseByPatientOfLastVisit(long pID) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetDiagnoseByPatientOfLastVisit(pID);
            }
        }

        /// <summary>
        /// Number the of visits.
        /// </summary>
        /// <returns></returns>
        public long NumberOfVisits() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.NumberOfVisits();
            }
        }

        /// <summary>
        /// Getalls the operations.
        /// </summary>
        /// <returns></returns>
        public IList<OperationData> getallOperations() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.getallOperations();
            }
        }

        /// <summary>
        /// Gets the last operation by patient ID.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public OperationData GetLastOperationByPatientID(long pId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetLastOperationByPatientID(pId);
            }
        }

        /// <summary>
        /// Gets the operations by patient ID.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public IList<OperationData> GetOperationsByPatientID(long p) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetOperationsByPatientID(p);
            }
        }

        /// <summary>
        /// Updates the operation.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        public bool UpdateOperation(OperationData operationData) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.UpdateOperation(operationData);
            }
        }

        /// <summary>
        /// Inserts the operation.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        public OperationData InsertOperation(OperationData operationData) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.InsertOperation(operationData);
            }
        }

        /// <summary>
        /// Number the of operations.
        /// </summary>
        /// <returns></returns>
        public long NumberOfOperations() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.NumberOfOperations();
            }
        }

        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <param name="imageData">The image data.</param>
        /// <returns></returns>
        public bool DeleteImage(ImageData imageData) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.DeleteImage(imageData);
            }
        }

        /// <summary>
        /// Inserts the image.
        /// </summary>
        /// <param name="imageData">The image data.</param>
        /// <returns></returns>
        public ImageData InsertImage(ImageData imageData) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.InsertImage(imageData);
            }
        }

        /// <summary>
        /// Gets the images by patient ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public IList<ImageData> GetImagesByPatientID(long pID) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetImagesByPatientID(pID);
            }
        }

        /// <summary>
        /// Gets all next actions.
        /// </summary>
        /// <returns></returns>
        public IList<NextActionData> GetAllNextActions() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetAllNextActions();
            }
        }

        /// <summary>
        /// Deletes the Action.
        /// </summary>
        /// <param name="nextActionData">The Next Action data.</param>
        /// <returns></returns>
        public bool DeleteNextAction(NextActionData nextActionData) {
            using(ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.DeleteNextAction(nextActionData);
            }
        }

        /// <summary>
        /// Inserts the Action.
        /// </summary>
        /// <param name="nextActionData">The image data.</param>
        /// <returns></returns>
        public NextActionData InsertNextAction(NextActionData nextActionData) {
            using(ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.InsertNextAction(nextActionData);
            }
        }

        /// <summary>
        /// Gets the Next Actions by patient ID.
        /// </summary>
        /// <param name="pID">The p ID.</param>
        /// <returns></returns>
        public IList<NextActionData> GetNextActionsByPatientID(long pID) {
            using(ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetNextActionsByPatientID(pID);
            }
        }

        /// <summary>
        /// Finds the patients with next action.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="halfYear">The half year.</param>
        /// <param name="actionKind">Kind of the action.</param>
        /// <returns></returns>
        public IList<PatientData> FindPatientsWithNextAction(long year, long halfYear, ActionKind actionKind) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientsWithNextAction(year, halfYear, actionKind);
            }
        }

        /// <summary>
        /// Gets all years that have at least one Next Action Defined
        /// </summary>
        /// <returns></returns>
        public IList<long> GetAllNextActionYears() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetAllNextActionYears();
            }
        }

        #region DiadnoseGroup

        public IList<DiagnoseGroupData> FindAllDiagnoseGroups() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindAllDiagnoseGroups();
            }
        }

        public DiagnoseGroupData FindDiagnoseGroupById(long id) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindDiagnoseGroupById(id);
            }
        }

        public DiagnoseGroupData InsertDiagnoseGroup(DiagnoseGroupData diagnoseGroup) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.InsertDiagnoseGroup(diagnoseGroup);
            }
        }

        public bool UpdateDiagnoseGroup(DiagnoseGroupData diagnoseGroupData) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.UpdateDiagnoseGroup(diagnoseGroupData);
            }
        }

        public bool DeleteDiagnoseGroup(long dgId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.DeleteDiagnoseGroup(dgId);
            }
        }

        public bool AssignPatientToDiagnoseGroup(long pId, long dgId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.AssignPatientToDiagnoseGroup(pId, dgId);
            }
        }

        public bool RemovePatientFromDiagnoseGroup(long pId, long dgId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.RemovePatientFromDiagnoseGroup(pId, dgId);
            }
        }

        public IList<long> FindDiagnoseGroupIdsByPatientId(long pId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindDiagnoseGroupIdsByPatientId(pId);
            }
        }

        public IList<long> FindPatientIdsByDiagnoseGroupId(long dgId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindPatientIdsByDiagnoseGroupId(dgId);
            }
        }

        public IList<DiagnoseGroupData> FindDiagnoseGroupsByIds(IList<long> dgIds) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindDiagnoseGroupsByIds(dgIds);
            }
        }

        public IList<DiagnoseGroupData> FindDiagnoseGroupIdByPatientId(long pId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindDiagnoseGroupIdByPatientId(pId);
            }
        }

        public IList<DiagnoseGroupData> FindAllDiagnoseGroupsThatAreNotAssignedByPatient(long pId) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.FindAllDiagnoseGroupsThatAreNotAssignedByPatient(pId);
            }
        }

        #endregion

        /// <summary>
        /// Supportses the backup.
        /// </summary>
        /// <returns></returns>
        public bool SupportsBackup() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.SupportsBackup();
            }
        }

        /// <summary>
        /// Backups the path.
        /// </summary>
        /// <returns></returns>
        public string BackupPath() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.BackupPath();
            }
        }

        /// <summary>
        /// Does the backup.
        /// </summary>
        /// <param name="backupPath">The backup path.</param>
        /// <returns></returns>
        public string DoBackup(string backupPath) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding,endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.DoBackup(backupPath);
            }
        }


        #region DatabaseManagement

        /// <summary>
        /// Supports DB Managemant
        /// </summary>
        /// <returns></returns>
        public bool SupportDatabaseManagement() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.SupportDatabaseManagement();
            }
        }

        /// <summary>
        /// Sets the DB Settings
        /// </summary>
        /// <param name="databaseSettings"></param>
        public bool SetDatabaseSettings(DatabaseSettings databaseSettings) {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.SetDatabaseSettings(databaseSettings);
            }
        }

        /// <summary>
        /// Gets the Database Settings
        /// </summary>
        /// <returns></returns>
        public DatabaseSettings GetDatabaseSettings() {
            using (ChannelFactory<ISPDBL> cf = new ChannelFactory<ISPDBL>(binding, endpointAddress)) {
                ISPDBL spdBL = cf.CreateChannel();
                return spdBL.GetDatabaseSettings();
            }
        }

        #endregion

    }
}
