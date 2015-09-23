using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Procurios.Public;
using SPD.CommonObjects;
using System.Globalization;
using SPD.Exceptions;

namespace SPD.CommonUtilities {
    /// <summary>
    /// 
    /// </summary>
    public class SpdJsonTools {

        /// <summary>
        /// 
        /// </summary>
        public static string patients = "patients";
        /// <summary>
        /// The operations
        /// </summary>
        public static string operations = "operations";
        /// <summary>
        /// The visits
        /// </summary>
        public static string visits = "visits";
        /// <summary>
        /// The diagnose groups
        /// </summary>
        public static string diagnoseGroups = "diagnoseGroups";
        /// <summary>
        /// The next actions
        /// </summary>
        public static string nextActions = "nextActions";
        /// <summary>
        /// The patient diagnose groups
        /// </summary>
        public static string patientDiagnoseGroups = "patientDiagnoseGroups";
        /// <summary>
        /// The photos
        /// </summary>
        public static string photos = "photos";
        /// <summary>
        /// The operation_operation id
        /// </summary>
        public const string operation_operationId = "operationID";
        /// <summary>
        /// The operation_ date
        /// </summary>
        public const string operation_Date = "operationdate";
        /// <summary>
        /// The operation_ team
        /// </summary>
        public const string operation_Team = "team";
        /// <summary>
        /// The operation_process
        /// </summary>
        public const string operation_process = "process";
        /// <summary>
        /// The operation_diagnoses
        /// </summary>
        public const string operation_diagnoses = "diagnoses";
        /// <summary>
        /// The operation_performed
        /// </summary>
        public const string operation_performed = "performed";
        /// <summary>
        /// The operation_patient id
        /// </summary>
        public const string operation_patientId = "patientID";
        /// <summary>
        /// The operation_add info
        /// </summary>
        public const string operation_addInfo = "additionalinformation";
        /// <summary>
        /// The operation_medication
        /// </summary>
        public const string operation_medication = "medication";
        /// <summary>
        /// The operation_int diagnoses
        /// </summary>
        public const string operation_intDiagnoses = "intdiagnoses";
        /// <summary>
        /// The operation_ppps
        /// </summary>
        public const string operation_ppps = "ppps";
        /// <summary>
        /// The operation_result
        /// </summary>
        public const string operation_result = "result";
        /// <summary>
        /// The operation_kath days
        /// </summary>
        public const string operation_kathDays = "kathDays";
        /// <summary>
        /// The operation_organ
        /// </summary>
        public const string operation_organ = "organ";
        /// <summary>
        /// The operation_op result
        /// </summary>
        public const string operation_opResult = "opResult";

        /// <summary>
        /// The patient_patient ID
        /// </summary>
        public const string patient_patientID = "patientID";
        /// <summary>
        /// The patient_firstname
        /// </summary>
        public const string patient_firstname = "firstname";
        /// <summary>
        /// The patient_surname
        /// </summary>
        public const string patient_surname = "surname";
        /// <summary>
        /// The patient_birthdate
        /// </summary>
        public const string patient_birthdate = "birthdate";
        /// <summary>
        /// The patient_sex
        /// </summary>
        public const string patient_sex = "sex";
        /// <summary>
        /// The patient_phone
        /// </summary>
        public const string patient_phone = "phone";
        /// <summary>
        /// The patient_furthertreatment
        /// </summary>
        public const string patient_furthertreatment = "furthertreatment";
        /// <summary>
        /// The patient_weight
        /// </summary>
        public const string patient_weight = "weight";
        /// <summary>
        /// The patient_address
        /// </summary>
        public const string patient_address = "address";
        /// <summary>
        /// The patient_resident of asmara
        /// </summary>
        public const string patient_residentOfAsmara = "residentOfAsmara";
        /// <summary>
        /// The patient_finished
        /// </summary>
        public const string patient_finished = "finished";
        /// <summary>
        /// The patient_ambulant
        /// </summary>
        public const string patient_ambulant = "ambulant";
        /// <summary>
        /// The patient_linz
        /// </summary>
        public const string patient_linz = "linz";
        /// <summary>
        /// The patient_wait list start date
        /// </summary>
        public const string patient_waitListStartDate = "waitListStartDate";

        /// <summary>
        /// The visit_ visit ID
        /// </summary>
        public const string visit_VisitID = "VisitID";
        /// <summary>
        /// The visit_cause
        /// </summary>
        public const string visit_cause = "cause";
        /// <summary>
        /// The visit_localis
        /// </summary>
        public const string visit_localis = "localis";
        /// <summary>
        /// The visit_extradiagnosis
        /// </summary>
        public const string visit_extradiagnosis = "extradiagnosis";
        /// <summary>
        /// The visit_prozedure
        /// </summary>
        public const string visit_prozedure = "prozedure";
        /// <summary>
        /// The visit_extratherapy
        /// </summary>
        public const string visit_extratherapy = "extratherapy";
        /// <summary>
        /// The visit_patientid
        /// </summary>
        public const string visit_patientid = "patientid";
        /// <summary>
        /// The visit_visitdate
        /// </summary>
        public const string visit_visitdate = "visitdate";
        /// <summary>
        /// The visit_anesthesiology
        /// </summary>
        public const string visit_anesthesiology = "anesthesiology";
        /// <summary>
        /// The visit_ultrasound
        /// </summary>
        public const string visit_ultrasound = "ultrasound";
        /// <summary>
        /// The visit_blooddiagnostic
        /// </summary>
        public const string visit_blooddiagnostic = "blooddiagnostic";
        /// <summary>
        /// The visit_radiodiagnostics
        /// </summary>
        public const string visit_radiodiagnostics = "radiodiagnostics";

        /// <summary>
        /// The next action_next action ID
        /// </summary>
        public const string nextAction_nextActionID = "nextActionID";
        /// <summary>
        /// The next action_ patient ID
        /// </summary>
        public const string nextAction_PatientID = "PatientID";
        /// <summary>
        /// The next action_actionkind
        /// </summary>
        public const string nextAction_actionkind = "actionkind";
        /// <summary>
        /// The next action_actionyear
        /// </summary>
        public const string nextAction_actionyear = "actionyear";
        /// <summary>
        /// The next action_actionhalfyear
        /// </summary>
        public const string nextAction_actionhalfyear = "actionhalfyear";
        /// <summary>
        /// The next action_todo
        /// </summary>
        public const string nextAction_todo = "todo";

        /// <summary>
        /// The diagnose group_diagnose group ID
        /// </summary>
        public const string diagnoseGroup_diagnoseGroupID = "diagnoseGroupID";
        /// <summary>
        /// The diagnose group_short descr
        /// </summary>
        public const string diagnoseGroup_shortDescr = "shortDescr";
        /// <summary>
        /// The diagnose group_long descr
        /// </summary>
        public const string diagnoseGroup_longDescr = "longDescr";

        /// <summary>
        /// The patient diagnose group_patient ID
        /// </summary>
        public const string patientDiagnoseGroup_patientID = "patientID";
        /// <summary>
        /// The patient diagnose group_diagnose group ID
        /// </summary>
        public const string patientDiagnoseGroup_diagnoseGroupID = "diagnoseGroupID";

        /// <summary>
        /// The photo_ photo ID
        /// </summary>
        public const string photo_PhotoID = "PhotoID";
        /// <summary>
        /// The photo_ patient ID
        /// </summary>
        public const string photo_PatientID = "PatientID";
        /// <summary>
        /// The photo_ link
        /// </summary>
        public const string photo_Link = "Link";
        /// <summary>
        /// The photo_ kommentar
        /// </summary>
        public const string photo_Kommentar = "Kommentar";

        /// <summary>
        /// Parses the json.
        /// </summary>
        /// <param name="jsonString">The json string.</param>
        /// <returns>the JsonContainer od null if an Error occured!!</returns>
        public static JsonContainer ParseJson(string jsonString) {
            try {
                JsonContainer jsonContainer = new JsonContainer();
                Hashtable elements = (Hashtable)JSON.JsonDecode(jsonString);

                if (elements.ContainsKey(patients)) {
                    jsonContainer.Patients = parsePatients((ArrayList)elements[patients]);
                    jsonContainer.FurtherTreatments = parseFurtherTreatments((ArrayList)elements[patients]);
                }
                if (elements.ContainsKey(operations)) {
                    jsonContainer.Operations = parseOperations((ArrayList)elements[operations]);
                }
                if (elements.ContainsKey(visits)) {
                    jsonContainer.Visits = parseVisits((ArrayList)elements[visits]);
                }
                if (elements.ContainsKey(diagnoseGroups)) {
                    jsonContainer.DiagnoseGroups = parseDiagnoseGroups((ArrayList)elements[diagnoseGroups]);
                }
                if (elements.ContainsKey(nextActions)) {
                    jsonContainer.NextActions = parseNextActions((ArrayList)elements[nextActions]);
                }
                if (elements.ContainsKey(patientDiagnoseGroups)) {
                    jsonContainer.PatientDiagnoseGroups = parsePatientDiagnoseGroups((ArrayList)elements[patientDiagnoseGroups]);
                }
                if (elements.ContainsKey(photos)) {
                    jsonContainer.Photos = parsePhotos((ArrayList)elements[photos]);
                }

                return jsonContainer;
            } catch (Exception) {
                return null;
            }
        }

        /// <summary>
        /// Parses the further Treatments.
        /// </summary>
        /// <param name="jsonPatients">The json further Treatments.</param>
        /// <returns></returns>
        private static IDictionary<long, string> parseFurtherTreatments(ArrayList jsonPatients) {
            IDictionary<long, string> furtherTreatmenttMap = new Dictionary<long, string>();

            foreach (Hashtable htpat in jsonPatients) {
                if (htpat.ContainsKey(patient_furthertreatment) && htpat.ContainsKey(patient_patientID)) {
                    furtherTreatmenttMap[Convert.ToInt64(htpat[patient_patientID])] = Convert.ToString(htpat[patient_furthertreatment]);
                }
            }

            return furtherTreatmenttMap;
        }

        /// <summary>
        /// Parses the Photos.
        /// </summary>
        /// <param name="jsonFotos">The json Photos.</param>
        /// <returns></returns>
        private static IList<ImageData> parsePhotos(ArrayList jsonFotos) {
            IList<ImageData> photoList = new List<ImageData>();

            foreach (Hashtable htnexAct in jsonFotos) {
                ImageData photo = new ImageData();

                if (htnexAct.ContainsKey(photo_PatientID)) {
                    photo.PatientID = Convert.ToInt64(htnexAct[photo_PatientID]);
                }

                if (htnexAct.ContainsKey(nextAction_PatientID)) {
                    photo.PatientID = Convert.ToInt64(htnexAct[nextAction_PatientID]);
                }

                if (htnexAct.ContainsKey(photo_Link)) {
                    photo.Link = Convert.ToString(htnexAct[photo_Link]);
                }

                if (htnexAct.ContainsKey(photo_Kommentar)) {
                    photo.Kommentar = Convert.ToString(htnexAct[photo_Kommentar]);
                }

                photoList.Add(photo);
            }

            return photoList;
        }

        /// <summary>
        /// Parses the patient Diagnose Groups.
        /// </summary>
        /// <param name="jsonPatientDiagnoseGroup">The json patient Diagnose Groups.</param>
        /// <returns></returns>
        private static IList<PatientDiagnoseGroupData> parsePatientDiagnoseGroups(ArrayList jsonPatientDiagnoseGroup) {
            IList<PatientDiagnoseGroupData> patientDiagnoseGroupDataList = new List<PatientDiagnoseGroupData>();

            foreach (Hashtable htnexAct in jsonPatientDiagnoseGroup) {
                PatientDiagnoseGroupData patientDiagnoseGroup = new PatientDiagnoseGroupData();

                if (htnexAct.ContainsKey(patientDiagnoseGroup_diagnoseGroupID)) {
                    patientDiagnoseGroup.DiagnoseGroupDataID = Convert.ToInt64(htnexAct[patientDiagnoseGroup_diagnoseGroupID]);
                }

                if (htnexAct.ContainsKey(patientDiagnoseGroup_patientID)) {
                    patientDiagnoseGroup.PatientID = Convert.ToInt64(htnexAct[patientDiagnoseGroup_patientID]);
                }



                patientDiagnoseGroupDataList.Add(patientDiagnoseGroup);
            }

            return patientDiagnoseGroupDataList;
        }

        /// <summary>
        /// Parses the Next Actions.
        /// </summary>
        /// <param name="jsonNextActions">The json Next Actions.</param>
        /// <returns></returns>
        private static IList<NextActionData> parseNextActions(ArrayList jsonNextActions) {
            IList<NextActionData> nextActionList = new List<NextActionData>();

            foreach (Hashtable htnexAct in jsonNextActions) {
                NextActionData nextAction = new NextActionData();

                if (htnexAct.ContainsKey(nextAction_nextActionID)) {
                    nextAction.NextActionID = Convert.ToInt64(htnexAct[nextAction_nextActionID]);
                }

                if (htnexAct.ContainsKey(nextAction_PatientID)) {
                    nextAction.PatientID = Convert.ToInt64(htnexAct[nextAction_PatientID]);
                }

                if (htnexAct.ContainsKey(nextAction_actionkind)) {
                    nextAction.ActionKind = (ActionKind)Convert.ToInt64(htnexAct[nextAction_actionkind]);
                } else {
                    throw new SPDJsonParseException(null, "Json Next Action Action Type not set.", null);
                }

                if (htnexAct.ContainsKey(nextAction_actionyear)) {
                    nextAction.ActionhalfYear = Convert.ToInt64(htnexAct[nextAction_actionyear]);
                }

                if (htnexAct.ContainsKey(nextAction_actionhalfyear)) {
                    nextAction.ActionhalfYear = Convert.ToInt64(htnexAct[nextAction_actionhalfyear]);
                }

                if (htnexAct.ContainsKey(nextAction_todo)) {
                    nextAction.Todo = Convert.ToString(htnexAct[nextAction_todo]);
                }

                nextActionList.Add(nextAction);
            }

            return nextActionList;
        }

        /// <summary>
        /// Parses the Diagnose Groups.
        /// </summary>
        /// <param name="jsonDiagnoseGroup">The json Diagnose Groups.</param>
        /// <returns></returns>
        private static IList<DiagnoseGroupData> parseDiagnoseGroups(ArrayList jsonDiagnoseGroup) {
            IList<DiagnoseGroupData> diagnoseGroupList = new List<DiagnoseGroupData>();

            foreach (Hashtable htdiagGrou in jsonDiagnoseGroup) {
                DiagnoseGroupData diagnoseGroup = new DiagnoseGroupData();

                if (htdiagGrou.ContainsKey(diagnoseGroup_diagnoseGroupID)) {
                    diagnoseGroup.DiagnoseGroupDataID = Convert.ToInt64(htdiagGrou[diagnoseGroup_diagnoseGroupID]);
                }

                if (htdiagGrou.ContainsKey(diagnoseGroup_shortDescr)) {
                    diagnoseGroup.ShortName = Convert.ToString(htdiagGrou[diagnoseGroup_shortDescr]);
                }

                if (htdiagGrou.ContainsKey(diagnoseGroup_longDescr)) {
                    diagnoseGroup.LongName = Convert.ToString(htdiagGrou[diagnoseGroup_longDescr]);
                }

                 diagnoseGroupList.Add(diagnoseGroup);
            }

            return diagnoseGroupList;
        }

        /// <summary>
        /// Parses the Visits.
        /// </summary>
        /// <param name="jsonVisits">The json visits.</param>
        /// <returns></returns>
        private static IList<VisitData> parseVisits(ArrayList jsonVisits) {
            IList<VisitData> visitList = new List<VisitData>();

            foreach (Hashtable htvisit in jsonVisits) {
                VisitData visit = new VisitData();

                if (htvisit.ContainsKey(visit_VisitID)) {
                    visit.Id = Convert.ToInt64(htvisit[visit_VisitID]);
                }

                if (htvisit.ContainsKey(visit_cause)) {
                    visit.Cause = Convert.ToString(htvisit[visit_cause]);
                }

                if (htvisit.ContainsKey(visit_localis)) {
                    visit.Localis = Convert.ToString(htvisit[visit_localis]);
                }

                if (htvisit.ContainsKey(visit_extradiagnosis)) {
                    visit.ExtraDiagnosis = Convert.ToString(htvisit[visit_extradiagnosis]);
                }

                if (htvisit.ContainsKey(visit_prozedure)) {
                    visit.Procedure = Convert.ToString(htvisit[visit_prozedure]);
                }

                if (htvisit.ContainsKey(visit_extratherapy)) {
                    visit.ExtraTherapy = Convert.ToString(htvisit[visit_extratherapy]);
                }

                if (htvisit.ContainsKey(visit_patientid)) {
                    visit.PatientId = Convert.ToInt64(htvisit[visit_patientid]);
                }

                if (htvisit.ContainsKey(visit_visitdate)) {
                    visit.VisitDate = DateTime.Parse(Convert.ToString(htvisit[visit_visitdate]), DateTimeFormatInfo.InvariantInfo);
                }

                if (htvisit.ContainsKey(visit_anesthesiology)) {
                    visit.Anesthesiology = Convert.ToString(htvisit[visit_anesthesiology]);
                }

                if (htvisit.ContainsKey(visit_ultrasound)) {
                    visit.Ultrasound = Convert.ToString(htvisit[visit_ultrasound]);
                }

                if (htvisit.ContainsKey(visit_blooddiagnostic)) {
                    visit.Blooddiagnostic = Convert.ToString(htvisit[visit_blooddiagnostic]);
                }

                if (htvisit.ContainsKey(visit_radiodiagnostics)) {
                    visit.Radiodiagnostics = Convert.ToString(htvisit[visit_radiodiagnostics]);
                }

                visitList.Add(visit);
            }

            return visitList;
        }

        /// <summary>
        /// Parses the patients.
        /// </summary>
        /// <param name="jsonPatients">The json patients.</param>
        /// <returns></returns>
        private static IList<PatientData> parsePatients(ArrayList jsonPatients)  {
            IList<PatientData> patientList = new List<PatientData>();

            foreach (Hashtable htpat in jsonPatients) {
                PatientData patient = new PatientData();

                if (htpat.ContainsKey(patient_patientID)) {
                    patient.Id = Convert.ToInt64(htpat[patient_patientID]);
                }

                if (htpat.ContainsKey(patient_firstname)) {
                    patient.FirstName = Convert.ToString(htpat[patient_firstname]);
                }

                if (htpat.ContainsKey(patient_surname)) {
                    patient.SurName = Convert.ToString(htpat[patient_surname]);
                }

                if (htpat.ContainsKey(patient_birthdate)) {
                    patient.DateOfBirth = DateTime.Parse(Convert.ToString(htpat[patient_birthdate]), DateTimeFormatInfo.InvariantInfo);
                }

                if (htpat.ContainsKey(patient_sex)) {
                    patient.Sex = (Sex)Convert.ToInt64(htpat[patient_sex]);
                } else {
                    throw new SPDJsonParseException(null, "Json Patient Sex not set.", null);
                }

                if (htpat.ContainsKey(patient_phone)) {
                    patient.Phone = Convert.ToString(htpat[patient_phone]);
                }

                if (htpat.ContainsKey(patient_weight)) {
                    patient.Weight = Convert.ToInt32(htpat[patient_weight]);
                }

                if (htpat.ContainsKey(patient_residentOfAsmara)) {
                    patient.ResidentOfAsmara = (ResidentOfAsmara)Convert.ToInt64(htpat[patient_residentOfAsmara]);
                } else {
                    patient.ResidentOfAsmara = ResidentOfAsmara.undefined;
                }

                if (htpat.ContainsKey(patient_finished)) {
                    patient.Finished = (Finished)Convert.ToInt64(htpat[patient_finished]);
                } else {
                    patient.Finished = Finished.undefined;
                }

                if (htpat.ContainsKey(patient_ambulant)) {
                    patient.Ambulant = (Ambulant)Convert.ToInt64(htpat[patient_ambulant]);
                } else {
                    patient.Ambulant = Ambulant.notAmbulant;
                }

                if (htpat.ContainsKey(patient_linz)) {
                    patient.Linz = (Linz)Convert.ToInt64(htpat[patient_linz]);
                } else {
                    patient.Linz = Linz.undefined;
                }

                if (htpat.ContainsKey(patient_waitListStartDate)) {
                    patient.WaitListStartDate = DateTime.Parse(Convert.ToString(htpat[patient_waitListStartDate]), DateTimeFormatInfo.InvariantInfo);
                }

                patientList.Add(patient);
            }

            return patientList;
        }

        /// <summary>
        /// Parses the operations.
        /// </summary>
        /// <param name="jsonOperations">The json operations.</param>
        /// <returns></returns>
        private static IList<OperationData> parseOperations(ArrayList jsonOperations) {
            IList<OperationData> opList = new List<OperationData>();

            foreach (Hashtable htop in jsonOperations) {
                OperationData op = new OperationData();

                if (htop.ContainsKey(operation_operationId)) {
                    op.OperationId = Convert.ToInt64(htop[operation_operationId]);
                }

                if (htop.ContainsKey(operation_Date)) {
                    op.Date = DateTime.Parse(Convert.ToString(htop[operation_Date]), DateTimeFormatInfo.InvariantInfo);
                }

                if (htop.ContainsKey(operation_Team)) {
                    op.Team = Convert.ToString(htop[operation_Team]);
                }

                if (htop.ContainsKey(operation_process)) {
                    op.Process = Convert.ToString(htop[operation_process]);
                }

                if (htop.ContainsKey(operation_diagnoses)) {
                    op.Diagnoses = Convert.ToString(htop[operation_diagnoses]);
                }

                if (htop.ContainsKey(operation_performed)) {
                    op.Performed = Convert.ToString(htop[operation_performed]);
                }

                if (htop.ContainsKey(operation_patientId)) {
                    op.PatientId = Convert.ToInt64(htop[operation_patientId]);
                }

                if (htop.ContainsKey(operation_addInfo)) {
                    op.Additionalinformation = Convert.ToString(htop[operation_addInfo]);
                }

                if (htop.ContainsKey(operation_medication)) {
                    op.Medication = Convert.ToString(htop[operation_medication]);
                }

                if (htop.ContainsKey(operation_intDiagnoses)) {
                    op.IntDiagnoses = Convert.ToInt64(htop[operation_intDiagnoses]);
                }

                if (htop.ContainsKey(operation_ppps)) {
                    op.Ppps = (PPPS)Convert.ToInt64(htop[operation_ppps]);
                } else {
                    op.Ppps = PPPS.notDefined;
                }

                if (htop.ContainsKey(operation_result)) {
                    op.Result = (Result)Convert.ToInt64(htop[operation_result]);
                } else {
                    op.Result = Result.notDefined;
                }

                if (htop.ContainsKey(operation_kathDays)) {
                    op.KathDays = Convert.ToInt64(htop[operation_kathDays]);
                }

                if (htop.ContainsKey(operation_organ)) {
                    op.Organ = (Organ)Convert.ToInt64(htop[operation_organ]);
                } else {
                    op.Organ = Organ.undefined;
                }

                if (htop.ContainsKey(operation_opResult)) {
                    op.OpResult = Convert.ToString(htop[operation_opResult]);
                }

                opList.Add(op);
            }

            return opList;
        }

        /// <summary>
        /// Generates the json.
        /// </summary>
        /// <param name="jsonContainer">The json container.</param>
        /// <returns></returns>
        public static string GenerateJson(JsonContainer jsonContainer) {
            Hashtable elements = new Hashtable();

            if (jsonContainer.Patients.Count != 0) {
                elements.Add(patients, generatePatientsJson(jsonContainer.Patients, jsonContainer.FurtherTreatments));
            }

            if (jsonContainer.Operations.Count != 0) {
                elements.Add(operations, generateOpJson(jsonContainer.Operations));
            }

            if (jsonContainer.Visits.Count != 0) {
                elements.Add(visits, generateVisitsJson(jsonContainer.Visits));
            }

            if (jsonContainer.DiagnoseGroups.Count != 0) {
                elements.Add(diagnoseGroups, generateDiagnoseGroupsJson(jsonContainer.DiagnoseGroups));
            }

            if (jsonContainer.NextActions.Count != 0) {
                elements.Add(nextActions, generateNextActionsJson(jsonContainer.NextActions));
            }

            if (jsonContainer.Photos.Count != 0) {
                elements.Add(photos, generatePhotosJson(jsonContainer.Photos));
            }

            if (jsonContainer.PatientDiagnoseGroups.Count != 0) {
                elements.Add(patientDiagnoseGroups, generatePatientDiagnoseGroupsJson(jsonContainer.PatientDiagnoseGroups));
            }

            return JSON.JsonEncode(elements);
        }

        private static object generatePatientDiagnoseGroupsJson(IList<PatientDiagnoseGroupData> iList) {
            throw new NotImplementedException();
        }

        private static object generatePhotosJson(IList<ImageData> iList) {
            throw new NotImplementedException();
        }

        private static object generateNextActionsJson(IList<NextActionData> iList) {
            throw new NotImplementedException();
        }

        private static object generateDiagnoseGroupsJson(IList<DiagnoseGroupData> iList) {
            throw new NotImplementedException();
        }

        private static object generateVisitsJson(IList<VisitData> visits) {
            IList<Hashtable> visitList = new List<Hashtable>();
            foreach (VisitData visit in visits)
            {
                Hashtable ht = new Hashtable();
                ht.Add(visit_VisitID, visit.Id);

                if (!string.IsNullOrWhiteSpace(visit.Cause))
                {
                    ht.Add(visit_cause, visit.Cause);
                }

                if (!string.IsNullOrWhiteSpace(visit.Localis))
                {
                    ht.Add(visit_localis, visit.Localis);
                }

                if (!string.IsNullOrWhiteSpace(visit.ExtraDiagnosis))
                {
                    ht.Add(visit_extradiagnosis, visit.ExtraDiagnosis);
                }

                if (!string.IsNullOrWhiteSpace(visit.Procedure))
                {
                    ht.Add(visit_prozedure, visit.Procedure);
                }

                if (!string.IsNullOrWhiteSpace(visit.ExtraTherapy))
                {
                    ht.Add(visit_extratherapy, visit.ExtraTherapy);
                }

                if (visit.PatientId > 0)
                {
                    ht.Add(visit_patientid, visit.PatientId);
                }

                if (visit.VisitDate != null)
                {
                    ht.Add(visit_visitdate, visit.VisitDate.Date.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo));
                }

                if (!string.IsNullOrWhiteSpace(visit.Anesthesiology))
                {
                    ht.Add(visit_anesthesiology, visit.Anesthesiology);
                }

                if (!string.IsNullOrWhiteSpace(visit.Ultrasound))
                {
                    ht.Add(visit_ultrasound, visit.Ultrasound);
                }

                if (!string.IsNullOrWhiteSpace(visit.Blooddiagnostic))
                {
                    ht.Add(visit_blooddiagnostic, visit.Blooddiagnostic);
                }

                if (!string.IsNullOrWhiteSpace(visit.Radiodiagnostics))
                {
                    ht.Add(visit_radiodiagnostics, visit.Radiodiagnostics);
                }

                visitList.Add(ht);
            }

            return visitList;
        }

        private static object generatePatientsJson(IList<PatientData> patients, IDictionary<long, string> furtherTreatments) {
            ArrayList patientList = new ArrayList();
            foreach (PatientData patient in patients) {
                Hashtable ht = new Hashtable();
                ht.Add(patient_patientID, patient.Id);
                
                if (!string.IsNullOrWhiteSpace(patient.FirstName)) {
                    ht.Add(patient_firstname, patient.FirstName);
                }

                if (!string.IsNullOrWhiteSpace(patient.SurName)) {
                    ht.Add(patient_surname, patient.SurName);
                }

                if (patient.DateOfBirth != null) {
                    ht.Add(patient_birthdate, patient.DateOfBirth.Date.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo));
                }

                ht.Add(patient_sex, (int)patient.Sex);

                if (!string.IsNullOrWhiteSpace(patient.Phone)) {
                    ht.Add(patient_phone, patient.Phone);
                }

                if (furtherTreatments.ContainsKey(patient.Id)) {
                    ht.Add(patient_furthertreatment, furtherTreatments[patient.Id]);
                }

                ht.Add(patient_weight, patient.Weight);

                if (!string.IsNullOrWhiteSpace(patient.Address)) {
                    ht.Add(patient_address, patient.Address);
                }

                ht.Add(patient_residentOfAsmara, (int)patient.ResidentOfAsmara);
                ht.Add(patient_finished, (int)patient.Finished);
                ht.Add(patient_ambulant, (int)patient.Ambulant);
                ht.Add(patient_linz, (int)patient.Linz);
                if (patient.WaitListStartDate != null) {
                    DateTime waitLstSt = (DateTime)patient.WaitListStartDate;
                    ht.Add(patient_waitListStartDate, waitLstSt.Date.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo));
                }
                patientList.Add(ht);
            }

            return patientList;
        }

        /// <summary>
        /// Generates the op json.
        /// </summary>
        /// <param name="ops">The ops.</param>
        /// <returns></returns>
        private static ArrayList generateOpJson(IList<OperationData> ops) {
            ArrayList opsList = new ArrayList();
            foreach (OperationData op in ops) {
                Hashtable ht = new Hashtable();
                ht.Add(operation_operationId, op.OperationId);

                if (op.Date != null) {
                    ht.Add(operation_Date, op.Date.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo));
                }

                if (!string.IsNullOrWhiteSpace(op.Team)) {
                    ht.Add(operation_Team, op.Team);
                }

                if (!string.IsNullOrWhiteSpace(op.Process)) {
                    ht.Add(operation_process, op.Process);
                }

                if (!string.IsNullOrWhiteSpace(op.Diagnoses)) {
                    ht.Add(operation_diagnoses, op.Diagnoses);
                }

                if (!string.IsNullOrWhiteSpace(op.Performed)) {
                    ht.Add(operation_performed, op.Performed);
                }

                if (op.PatientId > 0) {
                    ht.Add(operation_patientId, op.PatientId);
                }

                if (!string.IsNullOrWhiteSpace(op.Additionalinformation)) {
                    ht.Add(operation_addInfo, op.Additionalinformation);
                }

                if (!string.IsNullOrWhiteSpace(op.Medication)) {
                    ht.Add(operation_medication, op.Medication);
                }

                if (op.IntDiagnoses > 0) {
                    ht.Add(operation_intDiagnoses, op.IntDiagnoses);
                }

                ht.Add(operation_ppps, (int)op.Ppps);
                ht.Add(operation_result, (int)op.Result);

                if (op.KathDays > 0) {
                    ht.Add(operation_kathDays, op.KathDays);
                }
                ht.Add(operation_organ, (int)op.Organ);

                if (!string.IsNullOrWhiteSpace(op.OpResult)) {
                    ht.Add(operation_opResult, op.OpResult);
                }

                opsList.Add(ht);
            }

            return opsList;
        }

        /// <summary>
        /// Merges the json containers.
        /// </summary>
        /// <param name="jsonContainers">The json containers.</param>
        /// <returns></returns>
        public static JsonContainer MergeJsonContainers(IList<JsonContainer> jsonContainers) {
            JsonContainer mergedJsonContainer = new JsonContainer();

            foreach (JsonContainer jsonContainer in jsonContainers) {
                mergedJsonContainer.addOperations(jsonContainer.Operations);
                mergedJsonContainer.addImages(jsonContainer.Images);
                mergedJsonContainer.addNextActions(jsonContainer.NextActions);
                mergedJsonContainer.addPatients(jsonContainer.Patients);
                mergedJsonContainer.addVisits(jsonContainer.Visits);
            }

            return mergedJsonContainer;
        }
    }
}
