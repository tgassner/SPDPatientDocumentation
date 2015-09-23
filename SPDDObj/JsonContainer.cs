using System;
using System.Collections.Generic;
using System.Text;

namespace SPD.CommonObjects {
    /// <summary>
    /// 
    /// </summary>
    public class JsonContainer {
        IList<PatientData> patients;
        IList<OperationData> operations;
        IList<VisitData> visits;
        IList<ImageData> images;
        IList<NextActionData> nextActions;
        IList<DiagnoseGroupData> diagnoseGroups;
        IList<ImageData> photos;
        IList<PatientDiagnoseGroupData> patientDiagnoseGroups;
        IDictionary<long, String> furtherTreatments;

        /// <summary>
        /// Gets or sets the patients.
        /// </summary>
        /// <value>The patients.</value>
        public IList<PatientData> Patients {
            get {
                if (patients == null) {
                    patients = new List<PatientData>();
                }
                return patients;
            }
            set { patients = value; }
        }

        /// <summary>
        /// Adds the patient.
        /// </summary>
        /// <param name="p">The p.</param>
        public void addPatient(PatientData p) {
            if (patients == null) {
                patients = new List<PatientData>();
            }
            patients.Add(p);
        }

        /// <summary>
        /// Adds the operations.
        /// </summary>
        /// <param name="ps">The ps.</param>
        public void addPatients(ICollection<PatientData> ps) {
            if (patients == null) {
                patients = new List<PatientData>();
            }
            foreach (PatientData p in ps) {
                patients.Add(p);
            }
        }

        /// <summary>
        /// Gets or sets the operations.
        /// </summary>
        /// <value>The operations.</value>
        public IList<OperationData> Operations {
            get {
                if (operations == null) {
                    operations = new List<OperationData>();
                }
                return operations;
            }
            set { operations = value; }
        }

        /// <summary>
        /// Adds the operation.
        /// </summary>
        /// <param name="op">The op.</param>
        public void addOperation(OperationData op) {
            if (operations == null) {
                operations = new List<OperationData>();
            }
            operations.Add(op);
        }

        /// <summary>
        /// Adds the operations.
        /// </summary>
        /// <param name="ops">The ops.</param>
        public void addOperations(ICollection<OperationData> ops) {
            if (operations == null) {
                operations = new List<OperationData>();
            }
            foreach(OperationData op in ops) {
                operations.Add(op);
            }
        }

        /// <summary>
        /// Gets or sets the visits.
        /// </summary>
        /// <value>The visits.</value>
        public IList<VisitData> Visits {
            get {
                if (visits == null) {
                    visits = new List<VisitData>();
                }
                return visits;
            }
            set { visits = value; }
        }

        /// <summary>
        /// Adds the visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public void addVisit(VisitData visit) {
            if (visits == null) {
                visits = new List<VisitData>();
            }
            visits.Add(visit);
        }

        /// <summary>
        /// Adds the visits.
        /// </summary>
        /// <param name="vis">The vis.</param>
        public void addVisits(ICollection<VisitData> vis) {
            if (visits == null) {
                visits = new List<VisitData>();
            }
            foreach (VisitData v in vis) {
                visits.Add(v);
            }
        }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public IList<ImageData> Images {
            get {
                if (images == null) {
                    images = new List<ImageData>();
                }
                return images;
            }
            set { images = value; }
        }

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="img">The img.</param>
        public void addImage(ImageData img) {
            if (images == null) {
                images = new List<ImageData>();
            }
            images.Add(img);
        }

        /// <summary>
        /// Adds the images.
        /// </summary>
        /// <param name="imgs">The imgs.</param>
        public void addImages(ICollection<ImageData> imgs) {
            if (images == null) {
                images = new List<ImageData>();
            }
            foreach (ImageData img in imgs) {
                images.Add(img);
            }
        }

        /// <summary>
        /// Gets or sets the next actions.
        /// </summary>
        /// <value>The next actions.</value>
        public IList<NextActionData> NextActions {
            get {
                if (nextActions == null) {
                    nextActions = new List<NextActionData>();
                }
                return nextActions;
            }
            set { nextActions = value; }
        }

        /// <summary>
        /// Gets or sets the diagnose Groups
        /// </summary>
        /// <value>The Diagnose Groups.</value>
        public IList<DiagnoseGroupData> DiagnoseGroups
        {
            get
            {
                if (diagnoseGroups == null)
                {
                    diagnoseGroups = new List<DiagnoseGroupData>();
                }
                return diagnoseGroups;
            }
            set { diagnoseGroups = value; }
        }

        /// <summary>
        /// Gets or sets the photos
        /// </summary>
        /// <value>The photos.</value>
        public IList<PatientDiagnoseGroupData> PatientDiagnoseGroups
        {
            get
            {
                if (patientDiagnoseGroups == null)
                {
                    patientDiagnoseGroups = new List<PatientDiagnoseGroupData>();
                }
                return patientDiagnoseGroups;
            }
            set { patientDiagnoseGroups = value; }
        }

        /// <summary>
        /// Gets or sets the photos
        /// </summary>
        /// <value>The photos.</value>
        public IList<ImageData> Photos
        {
            get
            {
                if (photos == null)
                {
                    photos = new List<ImageData>();
                }
                return photos;
            }
            set { photos = value; }
        }

        /// <summary>
        /// Adds the next action.
        /// </summary>
        /// <param name="nad">The nad.</param>
        public void addNextAction(NextActionData nad) {
            if (nextActions == null) {
                nextActions = new List<NextActionData>();
            }
            nextActions.Add(nad);
        }

        /// <summary>
        /// Adds the next actions.
        /// </summary>
        /// <param name="nads">The nads.</param>
        public void addNextActions(ICollection<NextActionData> nads) {
            if (nextActions == null) {
                nextActions = new List<NextActionData>();
            }
            foreach (NextActionData na in nads) {
                nextActions.Add(na);
            }
        }

        /// <summary>
        /// Gets or sets the further treatments.
        /// </summary>
        /// <value>
        /// The further treatments.
        /// </value>
        public IDictionary<long, String> FurtherTreatments
        {
            get
            {
                if (furtherTreatments == null)
                {
                    furtherTreatments = new Dictionary<long, String>();
                }
                return furtherTreatments;
            }
            set { furtherTreatments = value; }
        }
    }

}
