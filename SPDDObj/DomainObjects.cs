using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;
using Procurios.Public;

namespace SPD.CommonObjects {


    /// <summary>
    /// differences between male and female
    /// </summary>
    [DataContract(Name = "Sex")]
    public enum Sex {
        /// <summary>
        /// {35A90EBF-F421-44A3-BE3A-47C72AFE47FE}
        /// </summary>
        [EnumMember]
        male,
        /// <summary>
        /// {35A90EBF-F421-44A3-BE3A-47C72AFE47FE}
        /// </summary>
        [EnumMember]
        female
    }

    /// <summary>
    /// Defines if an operation has hield pp or ps
    /// </summary>
    [DataContract(Name = "PPPS")]
    public enum PPPS {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        notDefined = 0,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        pp = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        ps = 2,
    }

    /// <summary>
    /// Defines if the healing of an Operation is ok or not ok
    /// This is not pp and ps
    /// </summary>
    [DataContract(Name = "Result")]
    public enum Result {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        notDefined = 0,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        ok = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        nok = 2
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum ActionKind {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        control = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        operation = 2
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum ResidentOfAsmara {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        undefined = 0,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        yes = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        no = 2
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum Ambulant {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        ambulant = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        notAmbulant = 2
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum Finished {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        finished = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        notFinished = 2,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        undefined = 0
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum Linz {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        undefined = 0,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        notPlanned = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        planned = 2,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        running = 3,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        finished = 4
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum Organ {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        undefined = 0,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        testicle = 1,  //Hoden
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        renal = 2, //Nieren
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        penis = 3
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class PatientData {
        private long id = -1;
        private string firstName;
        private string surName;
        private DateTime dateOfBirth;
        private Sex sex;
        private string phone;
        private int weight = -1;
        private string address;
        private ResidentOfAsmara residentOfAsmara = ResidentOfAsmara.undefined;
        private Ambulant ambulant = Ambulant.notAmbulant;
        private Finished finished = Finished.undefined;
        private Linz linz = Linz.undefined;
        private DateTime? waitListStartDate = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientData"/> class.
        /// </summary>
        public PatientData() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientData"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="firstname">The firstname.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="sex">The sex.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="address">The address.</param>
        /// <param name="residentOfAsmara">The resident of asmara.</param>
        /// <param name="ambulant">The ambulant.</param>
        /// <param name="finished">The finished.</param>
        /// <param name="linz">The linz.</param>
        /// <param name="waitListStartDate">The wait List Start Date.</param>
        public PatientData(long id, string firstname, string surname, DateTime dateOfBirth,
            Sex sex, /*string city, string street,*/ string phone, int weight, string address,
            ResidentOfAsmara residentOfAsmara, Ambulant ambulant, Finished finished, Linz linz, DateTime? waitListStartDate) {
            this.id = id;
            this.firstName = firstname;
            this.surName = surname;
            this.dateOfBirth = dateOfBirth;
            this.sex = sex;
            this.phone = phone;
            this.weight = weight;
            this.address = address;
            this.residentOfAsmara = residentOfAsmara;
            this.ambulant = ambulant;
            this.finished = finished;
            this.Linz = linz;
            this.waitListStartDate = waitListStartDate;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [DataMember]
        public long Id {
            get {
                return id;
            }
            set {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [DataMember]
        public string FirstName {
            get {
                return firstName;
            }
            set {
                firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the sur.
        /// </summary>
        /// <value>The name of the sur.</value>
        [DataMember]
        public string SurName {
            get {
                return surName;
            }
            set {
                surName = value;
            }
        }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        [DataMember]
        public DateTime DateOfBirth {
            get {
                return dateOfBirth;
            }
            set {
                dateOfBirth = value;
            }
        }

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        [DataMember]
        public Sex Sex {
            get {
                return sex;
            }
            set {
                sex = value;
            }
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [DataMember]
        public string Phone {
            get {
                return phone;
            }
            set {
                phone = value;
            }
        }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        [DataMember]
        public int Weight {
            get {
                return weight;
            }
            set {
                weight = value;
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        [DataMember]
        public string Address {
            get {
                return address;
            }
            set {
                address = value;
            }
        }

        /// <summary>
        /// Gets or sets the residentOfAsmara.
        /// </summary>
        /// <value>The address.</value>
        [DataMember]
        public ResidentOfAsmara ResidentOfAsmara {
            get {
                return residentOfAsmara;
            }
            set {
                residentOfAsmara = value;
            }
        }


        /// <summary>
        /// Gets or sets the ambulant.
        /// </summary>
        /// <value>The address.</value>
        [DataMember]
        public Ambulant Ambulant {
            get {
                return ambulant;
            }
            set {
                ambulant = value;
            }
        }

        /// <summary>
        /// Gets or sets the finished.
        /// </summary>
        /// <value>The address.</value>
        [DataMember]
        public Finished Finished {
            get {
                return finished;
            }
            set {
                finished = value;
            }
        }

        /// <summary>
        /// Gets or sets the finished.
        /// </summary>
        /// <value>The address.</value>
        [DataMember]
        public Linz Linz {
            get {
                return linz;
            }
            set {
                linz = value;
            }
        }

        /// <summary>
        /// Gets or Sets Wait List Start Time
        /// </summary>
        /// <value>The Date.</value>
        [DataMember]
        public DateTime? WaitListStartDate {
            get { return waitListStartDate; }
            set { waitListStartDate = value; }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return id.ToString() + " " + firstName + " " + surName + " " +
                dateOfBirth.ToShortDateString() + " " + sex.ToString() + " " +
                //city + " " + street;
                address + " " + weight + "kg ";
        }

        /// <summary>
        /// Toes the line breaked string.
        /// </summary>
        /// <returns></returns>
        public string ToLineBreakedString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: ").Append(this.id).Append(Environment.NewLine);
            sb.Append("Fist Name: ").Append(this.firstName).Append(Environment.NewLine);
            sb.Append("Sur Name: ").Append(this.surName).Append(Environment.NewLine);
            sb.Append("Address: ").Append(this.address).Append(Environment.NewLine);
            sb.Append("Date Of Birth: ").Append(this.dateOfBirth).Append(Environment.NewLine);
            sb.Append("Phone: ").Append(this.phone).Append(Environment.NewLine);
            sb.Append("Sex: ").Append(this.sex).Append(Environment.NewLine);
            sb.Append("Weight: ").Append(this.weight).Append(Environment.NewLine);
            sb.Append("Ambuland: ").Append(this.ambulant).Append(Environment.NewLine);
            sb.Append("Finished: ").Append(this.finished).Append(Environment.NewLine);
            sb.Append("Linz: ").Append(this.linz).Append(Environment.NewLine);
            sb.Append("Resident Of Asmara: ").Append(this.residentOfAsmara);
            return sb.ToString();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj) {
            PatientData pd = obj as PatientData;
            if (pd == null)
                return false;
            return pd.Id == this.id;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class VisitData {
        private long visitId = -1;
        private string cause;
        private string localis;
        private string extradiagnosis;
        private string procedure;
        private string extratherapy;
        private long patientid;
        private DateTime visitDate;
        private string anesthesiology;
        private string ultrasound;
        private string blooddiagnostic;
        private string todo;
        private string radiodiagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitData"/> class.
        /// </summary>
        public VisitData() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitData"/> class.
        /// </summary>
        /// <param name="visitId">The visit id.</param>
        /// <param name="cause">The cause.</param>
        /// <param name="localis">The localis.</param>
        /// <param name="extradiagnosis">The extradiagnosis.</param>
        /// <param name="procedure">The procedure.</param>
        /// <param name="extratherapy">The extratherapy.</param>
        /// <param name="patientid">The patientid.</param>
        /// <param name="visitDate">The visit date.</param>
        /// <param name="anesthesiology">The anesthesiology.</param>
        /// <param name="ultrasound">The ultrasound.</param>
        /// <param name="blooddiagnostic">The blooddiagnostic.</param>
        /// <param name="todo">The todo.</param>
        /// <param name="radiodiagnostics">The radiodiagnostics.</param>
        public VisitData(long visitId, string cause, string localis, string extradiagnosis,
                            string procedure, string extratherapy, long patientid, DateTime visitDate,
                            string anesthesiology, string ultrasound, string blooddiagnostic,
                            string todo, string radiodiagnostics) {
            this.visitId = visitId;
            this.cause = cause;
            this.localis = localis;
            this.extradiagnosis = extradiagnosis;
            this.procedure = procedure;
            this.extratherapy = extratherapy;
            this.patientid = patientid;
            this.visitDate = visitDate;
            this.anesthesiology = anesthesiology;
            this.ultrasound = ultrasound;
            this.blooddiagnostic = blooddiagnostic;
            this.todo = todo;
            this.radiodiagnostics = radiodiagnostics;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [DataMember]
        public long Id {
            get {
                return visitId;
            }
            set {
                this.visitId = value;
            }
        }

        /// <summary>
        /// Gets or sets the cause.
        /// </summary>
        /// <value>The cause.</value>
        [DataMember]
        public string Cause {
            get {
                return cause;
            }
            set {
                cause = value;
            }
        }

        /// <summary>
        /// Gets or sets the localis.
        /// </summary>
        /// <value>The localis.</value>
        [DataMember]
        public string Localis {
            get {
                return localis;
            }
            set {
                localis = value;
            }
        }

        /// <summary>
        /// Gets or sets the extra diagnosis.
        /// </summary>
        /// <value>The extra diagnosis.</value>
        [DataMember]
        public string ExtraDiagnosis {
            get {
                return extradiagnosis;
            }
            set {
                extradiagnosis = value;
            }
        }

        /// <summary>
        /// Gets or sets the procedure.
        /// </summary>
        /// <value>The procedure.</value>
        [DataMember]
        public string Procedure {
            get {
                return procedure;
            }
            set {
                procedure = value;
            }
        }

        /// <summary>
        /// Gets or sets the extra therapy.
        /// </summary>
        /// <value>The extra therapy.</value>
        [DataMember]
        public string ExtraTherapy {
            get {
                return extratherapy;
            }
            set {
                extratherapy = value;
            }
        }

        /// <summary>
        /// Gets or sets the patient id.
        /// </summary>
        /// <value>The patient id.</value>
        [DataMember]
        public long PatientId {
            get {
                return patientid;
            }
            set {
                patientid = value;
            }
        }

        /// <summary>
        /// Gets or sets the visit date.
        /// </summary>
        /// <value>The visit date.</value>
        [DataMember]
        public DateTime VisitDate {
            get {
                return visitDate;
            }
            set {
                visitDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the anesthesiology.
        /// </summary>
        /// <value>The anesthesiology.</value>
        [DataMember]
        public string Anesthesiology {
            get {
                return anesthesiology;
            }
            set {
                anesthesiology = value;
            }
        }

        /// <summary>
        /// Gets or sets the ultrasound.
        /// </summary>
        /// <value>The ultrasound.</value>
        [DataMember]
        public string Ultrasound {
            get {
                return ultrasound;
            }
            set {
                ultrasound = value;
            }
        }

        /// <summary>
        /// Gets or sets the blooddiagnostic.
        /// </summary>
        /// <value>The blooddiagnostic.</value>
        [DataMember]
        public string Blooddiagnostic {
            get {
                return blooddiagnostic;
            }
            set {
                blooddiagnostic = value;
            }
        }

        /// <summary>
        /// Gets or sets the todo.
        /// </summary>
        /// <value>The todo.</value>
        [DataMember]
        public string Todo {
            get {
                return this.todo;
            }
            set {
                this.todo = value;
            }
        }

        /// <summary>
        /// Gets or sets the radiodiagnostics.
        /// </summary>
        /// <value>The radiodiagnostics.</value>
        [DataMember]
        public string Radiodiagnostics {
            get {
                return this.radiodiagnostics;
            }
            set {
                this.radiodiagnostics = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return this.visitId.ToString();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj) {
            VisitData vd = obj as VisitData;
            if (vd == null)
                return false;
            return vd.Id == this.visitId;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Operation Data
    /// </summary>
    [DataContract]
    public class OperationData {
        private long operationId = -1;
        private DateTime date;
        private string team;
        private string process;
        private string diagnoses;
        private string performed;
        private long patientId;
        private string additionalinformation;
        private string medication;
        private long intdiagnoses;
        private PPPS ppps = PPPS.notDefined;
        private Result result = Result.notDefined;
        private long kathDays = - 1;
        private Organ organ = Organ.undefined;
        private string opResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationData"/> class.
        /// </summary>
        public OperationData() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationData"/> class.
        /// </summary>
        /// <param name="operationId">The operation id.</param>
        /// <param name="date">The date.</param>
        /// <param name="team">The team.</param>
        /// <param name="process">The process.</param>
        /// <param name="diagnoses">The diagnoses.</param>
        /// <param name="performed">The performed.</param>
        /// <param name="patientId">The patient id.</param>
        /// <param name="additionalinformation">The additionalinformation.</param>
        /// <param name="medication">The medication.</param>
        /// <param name="intdiagnoses">The intdiagnoses.</param>
        /// <param name="ppps">The PPPS.</param>
        /// <param name="result">The result.</param>
        /// <param name="kathDays">Kathetar Days.</param>
        /// <param name="organ">Organ.</param>
        /// <param name="opResult">opResult.</param>
        public OperationData(long operationId, DateTime date, string team, string process,
                    string diagnoses, string performed, long patientId,
                    string additionalinformation, string medication, long intdiagnoses,
                    PPPS ppps, Result result, long kathDays, Organ organ, string opResult) {
            this.operationId = operationId;
            this.date = date;
            this.team = team;
            this.process = process;
            this.diagnoses = diagnoses;
            this.performed = performed;
            this.patientId = patientId;
            this.additionalinformation = additionalinformation;
            this.medication = medication;
            this.intdiagnoses = intdiagnoses;
            this.ppps = ppps;
            this.result = result;
            this.kathDays = kathDays;
            this.organ = organ;
            this.opResult = opResult;
        }

        /// <summary>
        /// Gets or sets the operation id.
        /// </summary>
        /// <value>The operation id.</value>
        [DataMember]
        public long OperationId {
            get {
                return this.operationId;
            }
            set {
                this.operationId = value;
            }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        [DataMember]
        public DateTime Date {
            get {
                return this.date;
            }
            set {
                this.date = value;
            }
        }

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>The team.</value>
        [DataMember]
        public string Team {
            get {
                return this.team;
            }
            set {
                this.team = value;
            }
        }

        /// <summary>
        /// Gets or sets the process.
        /// </summary>
        /// <value>The process.</value>
        [DataMember]
        public string Process {
            get {
                return this.process;
            }
            set {
                this.process = value;
            }
        }

        /// <summary>
        /// Gets or sets the diagnoses.
        /// </summary>
        /// <value>The diagnoses.</value>
        [DataMember]
        public string Diagnoses {
            get {
                return this.diagnoses;
            }
            set {
                this.diagnoses = value;
            }
        }

        /// <summary>
        /// Gets or sets the performed.
        /// </summary>
        /// <value>The performed.</value>
        [DataMember]
        public string Performed {
            get {
                return this.performed;
            }
            set {
                this.performed = value;
            }
        }

        /// <summary>
        /// Gets or sets the patient id.
        /// </summary>
        /// <value>The patient id.</value>
        [DataMember]
        public long PatientId {
            get {
                return this.patientId;
            }
            set {
                this.patientId = value;
            }
        }

        /// <summary>
        /// Gets or sets the additionalinformation.
        /// </summary>
        /// <value>The additionalinformation.</value>
        [DataMember]
        public string Additionalinformation {
            get {
                return this.additionalinformation;
            }
            set {
                this.additionalinformation = value;
            }
        }

        /// <summary>
        /// Gets or sets the medication.
        /// </summary>
        /// <value>The medication.</value>
        [DataMember]
        public string Medication {
            get {
                return this.medication;
            }
            set {
                this.medication = value;
            }
        }

        /// <summary>
        /// Gets or sets the int diagnoses.
        /// </summary>
        /// <value>The int diagnoses.</value>
        [DataMember]
        public long IntDiagnoses {
            get {
                return this.intdiagnoses;
            }
            set {
                this.intdiagnoses = value;
            }
        }

        /// <summary>
        /// Gets or sets the PPPS.
        /// </summary>
        /// <value>The PPPS.</value>
        [DataMember]
        public PPPS Ppps {
            get {
                return this.ppps;
            }
            set {
                this.ppps = value;
            }
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [DataMember]
        public Result Result {
            get {
                return this.result;
            }
            set {
                this.result = value;
            }
        }

        /// <summary>
        /// Gets or sets the katheder days.
        /// </summary>
        /// <value>The katheder days.</value>
        [DataMember]
        public long KathDays {
            get {
                return this.kathDays;
            }
            set {
                this.kathDays = value;
            }
        }

        /// <summary>
        /// Gets or sets the organ.
        /// </summary>
        /// <value>The organ.</value>
        [DataMember]
        public Organ Organ {
            get {
                return this.organ;
            }
            set {
                this.organ = value;
            }
        }

        /// <summary>
        /// Gets or sets the op result.
        /// </summary>
        /// <value>The op result.</value>
        [DataMember]
        public string OpResult {
            get {
                return this.opResult;
            }
            set {
                this.opResult = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return this.operationId.ToString();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj) {
            OperationData od = obj as OperationData;
            if (od == null)
                return false;
            return od.OperationId == this.operationId;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ImageData {
        private long photoID;
        private long patientID;
        private string link;
        private string kommentar;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageData"/> class.
        /// </summary>
        public ImageData() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageData"/> class.
        /// </summary>
        /// <param name="photoID">The photo ID.</param>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="link">The link.</param>
        /// <param name="kommentar">The kommentar.</param>
        public ImageData(long photoID, long patientID, string link, string kommentar) {
            this.photoID = photoID;
            this.patientID = patientID;
            this.link = link;
            this.kommentar = kommentar;
        }

        /// <summary>
        /// Gets or sets the photo ID.
        /// </summary>
        /// <value>The photo ID.</value>
        [DataMember]
        public long PhotoID {
            get {
                return photoID;
            }
            set {
                this.photoID = value;
            }
        }

        /// <summary>
        /// Gets or sets the patient ID.
        /// </summary>
        /// <value>The patient ID.</value>
        [DataMember]
        public long PatientID {
            get {
                return patientID;
            }
            set {
                patientID = value;
            }
        }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        [DataMember]
        public string Link {
            get {
                return link;
            }
            set {
                link = value;
            }
        }

        /// <summary>
        /// Gets or sets the kommentar.
        /// </summary>
        /// <value>The kommentar.</value>
        [DataMember]
        public string Kommentar {
            get {
                return kommentar;
            }
            set {
                kommentar = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return "ID:" + this.photoID.ToString() + " PID: " + this.patientID.ToString() + " Link: " + this.link + " Kommentar: " + this.kommentar;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj) {
            ImageData id = obj as ImageData;
            if (id == null)
                return false;
            return id.PhotoID == this.photoID;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }


    /// <summary>
    /// Defines the next action for a patient e.g a patient has to have a control checkup 1/2009
    /// </summary>
    [DataContract]
    public class NextActionData {
        private long nextActionID = -1;
        private long patientID;
        private ActionKind actionKind;
        private long actionYear;
        private long actionhalfYear;
        private string todo;

        /// <summary>
        /// Initializes a new instance of the <see cref="NextActionData"/> class.
        /// </summary>
        public NextActionData() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NextActionData"/> class.
        /// </summary>
        /// <param name="nextActionID">The next action ID.</param>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="actionKind">Kind of the action.</param>
        /// <param name="actionYear">The action year.</param>
        /// <param name="actionhalfYear">The actionhalf year.</param>
        /// <param name="todo">ToDo.</param>
        public NextActionData(long nextActionID, long patientID, ActionKind actionKind,
                        long actionYear, long actionhalfYear, string todo) {
            this.nextActionID = nextActionID;
            this.patientID = patientID;
            this.actionKind = actionKind;
            this.actionYear = actionYear;
            this.actionhalfYear = actionhalfYear;
            this.todo = todo;
        }

        /// <summary>
        /// Gets or sets the next action ID.
        /// </summary>
        /// <value>The next action ID.</value>
        [DataMember]
        public long NextActionID {
            get {
                return this.nextActionID;
            }
            set {
                this.nextActionID = value;
            }
        }

        /// <summary>
        /// Gets or sets the patient ID.
        /// </summary>
        /// <value>The patient ID.</value>
        [DataMember]
        public long PatientID {
            get {
                return this.patientID;
            }
            set {
                this.patientID = value;
            }
        }

        /// <summary>
        /// Gets or sets the kind of the action.
        /// </summary>
        /// <value>The kind of the action.</value>
        [DataMember]
        public ActionKind ActionKind {
            get {
                return this.actionKind;
            }
            set {
                this.actionKind = value;
            }
        }

        /// <summary>
        /// Gets or sets the action year.
        /// </summary>
        /// <value>The action year.</value>
        [DataMember]
        public long ActionYear {
            get {
                return this.actionYear;
            }
            set {
                this.actionYear = value;
            }
        }

        /// <summary>
        /// Gets or sets the actionhalf year.
        /// </summary>
        /// <value>The actionhalf year.</value>
        [DataMember]
        public long ActionhalfYear {
            get {
                return this.actionhalfYear;
            }
            set {
                this.actionhalfYear = value;
            }
        }

        /// <summary>
        /// Gets or sets the actionhalf year.
        /// </summary>
        /// <value>The actionhalf year.</value>
        [DataMember]
        public string Todo {
            get {
                return this.todo;
            }
            set {
                this.todo = value;
            }
        }

        /// <summary>
        /// Overrides the ToString() Method
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return
                this.actionhalfYear.ToString() + "/" +
                    this.actionYear.ToString() + " " +
                    this.actionKind.ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class PatientDiagnoseGroupData {
        private long diagnoseGroupDataID;
        private long patientID;

        /// <summary>
        /// Constructor
        /// </summary>
        public PatientDiagnoseGroupData() {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="patientID">patient Id</param>
        /// <param name="diagnoseGroupDataID"> Diagnose Group Id </param>
        public PatientDiagnoseGroupData(long patientID, long diagnoseGroupDataID) {
            this.patientID = patientID;
            this.diagnoseGroupDataID = diagnoseGroupDataID;
        }

        /// <summary>
        /// Gets or sets the diagnose group data ID.
        /// </summary>
        /// <value>The diagnose group data ID.</value>
        [DataMember]
        public long DiagnoseGroupDataID {
            get {
                return this.diagnoseGroupDataID;
            }
            set {
                this.diagnoseGroupDataID = value;
            }
        }

        /// <summary>
        /// Gets or sets the patient ID.
        /// </summary>
        /// <value>The patient ID.</value>
        [DataMember]
        public long PatientID {
            get {
                return this.patientID;
            }
            set {
                this.patientID = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class DiagnoseGroupData {
        private long diagnoseGroupDataID;
        private string shortName;
        private string longName;

        /// <summary>
        /// Gets or sets the diagnose group data ID.
        /// </summary>
        /// <value>The diagnose group data ID.</value>
        [DataMember]
        public long DiagnoseGroupDataID {
            get {
                return this.diagnoseGroupDataID;
            }
            set {
                this.diagnoseGroupDataID = value;
            }
        }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        [DataMember]
        public string ShortName {
            get {
                return this.shortName;
            }
            set {
                this.shortName = value;
            }
        }

        /// <summary>
        /// Gets or sets the long name.
        /// </summary>
        /// <value>The long name.</value>
        [DataMember]
        public string LongName {
            get {
                return this.longName;
            }
            set {
                this.longName = value;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj) {
            DiagnoseGroupData dgd = obj as DiagnoseGroupData;
            if (dgd == null)
                return false;
            return dgd.diagnoseGroupDataID == this.diagnoseGroupDataID;
        }

        /// <summary>
        /// Overrides the ToString() Method
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return this.ShortName;
            //return
            //    this.diagnoseGroupDataID.ToString() + "" +
            //        this.shortName + " " +
            //        this.longName;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() {
            int prime = 31;
            int result = 1;
            result = prime * result + (int)diagnoseGroupDataID;
            result = prime * result + ((shortName == null) ? 0 : shortName.GetHashCode());
            result = prime * result + ((longName == null) ? 0 : longName.GetHashCode());
            return result;
        }

    }
}
