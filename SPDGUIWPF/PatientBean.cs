using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPD.CommonObjects;

namespace SPD.GUI.WPF {
    public class PatientBean {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Weight  { get; set; }
        public string Address  { get; set; }
        public string ResidentOfAsmara  { get; set; }
        public string Ambulant { get; set; }
        public string Finished  { get; set; }
        public string Linz { get; set; }
        public string WaitListStartDate { get; set; }
        public string NoOfOPs { get; set; }
        public string NoOfVisits { get; set; }
        public string VisitDiagnosis { get; set; }
        public string VisitProcedure { get; set; }
    }
}
