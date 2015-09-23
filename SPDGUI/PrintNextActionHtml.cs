using System;
using System.Collections.Generic;
using System.Text;
using SPD.CommonObjects;
using SPD.BL.Interfaces;
using System.Windows.Forms;

namespace SPD.GUI.Print.HTML {
    class PrintNextActionHtml {

        private static String firstLine(PatientData patient) {
            return "<tr><td class='what'>ID: </td><td>" + patient.Id + "</td><td class='what'>Sex: </td><td>" + patient.Sex + "</td><td class='what'>Phone: </td><td>" + patient.Phone + "</td><td class='what'>Birthdate: </td><td>" + patient.DateOfBirth.ToShortDateString() + "</td></tr>" + Environment.NewLine;
        }

        private static String name(PatientData patient) {
            return "<tr><td class='what'>Name: </td><td colspan='7'>" + patient.FirstName + " " + patient.SurName + "</td></tr>" + Environment.NewLine;
        }

        private static String opDiagnoses(OperationData operation) {
            if (operation == null || String.IsNullOrEmpty(operation.Diagnoses)) {
                return String.Empty;
            }
            return "<tr><td class='what' valign='top'><nobr>OP-Diagnoses: </nobr></td><td colspan='7'>" + operation.Diagnoses + "</td></tr>" + Environment.NewLine;
        }

        private static String visitDiagnoses(VisitData visit) {
            if (visit == null || String.IsNullOrEmpty(visit.ExtraDiagnosis)) {
                return String.Empty;
            }
            return "<tr><td class='what' valign='top'><nobr>Visit-Diagnoses: </nobr></td><td colspan='7'>" + visit.ExtraDiagnosis + "</td></tr>" + Environment.NewLine;
        }

        private static String visitTherapy(VisitData visit) {
            if (visit == null || String.IsNullOrEmpty(visit.ExtraTherapy)) {
                return String.Empty;
            }
            return "<tr><td class='what' valign='top'><nobr>Visit-Therapy: </nobr></td><td colspan='7'>" + visit.ExtraTherapy + "</td></tr>" + Environment.NewLine;
        }

        private static String toDo(String toDo) {
            if (String.IsNullOrEmpty(toDo)) {
                return String.Empty;
            }
            return "<tr><td class='what' valign='top'><nobr>ToDo: </nobr></td><td colspan='7'>" + toDo + "</td></tr>" + Environment.NewLine;
        }

        private static String seperator() {
            return "<tr><td style='border-top:2px solid #000000;' colspan='8'><span style='font-size:1px;'>&nbsp;<span></td></tr>" + Environment.NewLine;
        }

        private static String onePatient(PatientData patient, ISPDBL patComp, long year, long halfyear, ActionKind actionKind) {
            StringBuilder sb = new StringBuilder();
            OperationData operation = patComp.GetLastOperationByPatientID(patient.Id);
            VisitData visit = patComp.GetLastVisitByPatientID(patient.Id);
            StringBuilder toDoSB = new StringBuilder();
            foreach (NextActionData nextAction in patComp.GetNextActionsByPatientID(patient.Id)) {
                if (nextAction.ActionYear == year &&
                    nextAction.ActionhalfYear == halfyear &&
                    nextAction.ActionKind == actionKind &&
                    !String.IsNullOrEmpty(nextAction.Todo)) {
                    toDoSB.Append(nextAction.Todo);
                }
            }

            sb.Append(firstLine(patient));
            sb.Append(name(patient));
            sb.Append(opDiagnoses(operation));
            sb.Append(visitDiagnoses(visit));
            sb.Append(visitTherapy(visit));
            sb.Append(toDo(toDoSB.ToString()));
            sb.Append(seperator());
            return sb.ToString();
        }

        private static String allPatients(ISPDBL patComp, IList<PatientData> patients, long year, long halfyear, ActionKind actionKind) {
            StringBuilder sb = new StringBuilder();
            foreach(PatientData patient in patients) {
                sb.Append(onePatient(patient, patComp, year, halfyear, actionKind));
            }
            return sb.ToString();
        }

        private static String css() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<style type='text/css'>" + Environment.NewLine);
            sb.Append(".what {font-weight:bold; text-align: right;}" + Environment.NewLine);
            sb.Append("</style>" + Environment.NewLine);
            return sb.ToString();
            ;

        }

        private static string headline(long year, long halfyear, ActionKind actionKind, int patients) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<big><big>SPD - NextAction</big></big> " + actionKind.ToString() + " " + year + " - " + halfyear + " " + patients + " Patients " + DateTime.Now.ToShortDateString() + Environment.NewLine);
            sb.Append("<br><br>" + Environment.NewLine);
            return sb.ToString();
        }

        public static string getFullHtml(ISPDBL patComp, long year, long halfyear, ActionKind actionKind) {
            StringBuilder sb = new StringBuilder();
            IList<PatientData> patients = patComp.FindPatientsWithNextAction(year, halfyear, actionKind);
            sb.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\"" + Environment.NewLine);
            sb.Append("\"http://www.w3.org/TR/html4/loose.dtd\">" + Environment.NewLine);
            sb.Append("<html><head><title>SPD-NextAction</title>" + Environment.NewLine);
            sb.Append(css());
            sb.Append("</head>" + Environment.NewLine + "<body>" + Environment.NewLine);
            sb.Append("<table style='width:100%'>");
            sb.Append(headline(year, halfyear, actionKind, patients.Count));
            sb.Append(allPatients(patComp, patients, year, halfyear, actionKind));
            sb.Append("</table>" + Environment.NewLine);
            sb.Append("</body>" + Environment.NewLine + "</html>");
            return sb.ToString();
        }

    }
}
