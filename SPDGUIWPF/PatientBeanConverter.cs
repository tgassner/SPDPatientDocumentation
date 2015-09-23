using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using SPD.CommonUtilities;

namespace SPD.GUI.WPF {
    public class PatientBeanConverter {
        public static PatientBean convert(PatientData patientData, ISPDBL patComp) {
            PatientBean patientBean = new PatientBean();
            patientBean.ID = patientData.Id;
            patientBean.FirstName = patientData.FirstName;
            patientBean.SurName = patientData.SurName;
            patientBean.Age = StaticUtilities.getAgeFromBirthDate(patientData.DateOfBirth);
            patientBean.Phone = patientData.Phone;
            patientBean.Sex = patientData.Sex.ToString();
            patientBean.Weight = patientData.Weight.ToString();
            patientBean.Address = patientData.Address;

            switch (patientData.ResidentOfAsmara) {
                case ResidentOfAsmara.yes :
                    patientBean.ResidentOfAsmara = "yes";
                    break;
                case ResidentOfAsmara.no :
                    patientBean.ResidentOfAsmara = "no";
                    break;
                case ResidentOfAsmara.undefined:
                    patientBean.ResidentOfAsmara = string.Empty;
                    break;
                default:
                    throw new InvalidOperationException(patientData.ResidentOfAsmara + "not supportet!!");
            }

            switch (patientData.Ambulant) {
                case Ambulant.ambulant:
                    patientBean.Ambulant = "yes";
                    break;
                case Ambulant.notAmbulant:
                    patientBean.Ambulant = "no";
                    break;
                default:
                    throw new InvalidOperationException(patientData.Ambulant + "not supportet!!");
            }

            switch (patientData.Finished) {
                case Finished.finished:
                    patientBean.Finished = "yes";
                    break;
                case Finished.notFinished:
                    patientBean.Finished = "no";
                    break;
                case Finished.undefined:
                    patientBean.Finished = string.Empty;
                    break;
                default:
                    throw new InvalidOperationException(patientData.Finished + "not supportet!!");
            }

            switch (patientData.Linz) {
                case Linz.finished:
                    patientBean.Linz = "finished";
                    break;
                case Linz.notPlanned:
                    patientBean.Linz = string.Empty;
                    break;
                case Linz.undefined:
                    patientBean.Linz = string.Empty;
                    break;
                case Linz.running:
                    patientBean.Linz = "running";
                    break;
                case Linz.planned:
                    patientBean.Linz = "planed";
                    break;
                default:
                    throw new InvalidOperationException(patientData.Linz + "not supportet!!");
            }

            patientBean.WaitListStartDate = patientData.WaitListStartDate == null ? string.Empty : ((DateTime)patientData.WaitListStartDate).ToShortDateString();

            patientBean.NoOfOPs = patComp.GetOperationsByPatientID(patientData.Id).Count.ToString();
            patientBean.NoOfVisits = patComp.GetVisitsByPatientID(patientData.Id).Count.ToString();

            VisitData lastVisit = patComp.GetLastVisitByPatientID(patientData.Id);

            if (lastVisit == null) {
                patientBean.VisitDiagnosis = string.Empty;
                patientBean.VisitProcedure = string.Empty;
            } else {
                patientBean.VisitDiagnosis = lastVisit.ExtraDiagnosis;
                patientBean.VisitProcedure = lastVisit.Procedure;
            }

            
   

            return patientBean;
        }
    }
}
