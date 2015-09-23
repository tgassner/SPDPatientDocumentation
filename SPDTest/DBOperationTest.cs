using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPD.DAL;
using SPD.CommonObjects;

namespace SPDTest {
    /*
    IList<OperationData> FindAll();
    IList<OperationData> FindByPatientId(long patientId);
    OK OperationData FindByOperationId(long operationId);
    OK long Insert(OperationData odata);
    OK bool Delete(long operationId);
    OK bool Update(OperationData operation);
    */

    /// <summary>
    /// Zusammenfassungsbeschreibung für DBTestVS
    /// </summary>
    [TestClass]
    public class DBOperationTest {

        private long pID;

        public DBOperationTest() {
            //
            // TODO: Konstruktorlogik hier hinzufügen
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Textkontext mit Informationen über
        ///den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        //
        // Sie können beim Schreiben der Tests folgende zusätzliche Attribute verwenden:
        //
        // Verwenden Sie ClassInitialize, um vor Ausführung des ersten Tests in der Klasse Code auszuführen.
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Verwenden Sie ClassCleanup, um nach Ausführung aller Tests in einer Klasse Code auszuführen.
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen. 
        [TestInitialize()]
        public void MyTestInitialize() {
            IPatient patientDB = Database.CreatePatient();
            DateTime date = new DateTime(2006, 12, 24);
            PatientData patient = new PatientData(0, "first", "sure", date, Sex.male, "0123456789", 29, "address", ResidentOfAsmara.no, Ambulant.ambulant, Finished.finished, Linz.finished);
            pID = patientDB.Insert(patient);
        }

        //
        // Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        [TestCleanup()]
        public void MyTestCleanup() {
            IPatient patientDB = Database.CreatePatient();
            patientDB.Delete(pID);

        }

        #endregion

        /// <summary>
        /// Insert Test
        /// </summary>
        [TestMethod]
        public void OperationInsertTest() {
            IOperation operationDB = Database.CreateOperation();
            OperationData operation = new OperationData(0, DateTime.Now, "Tolles Team", "Toller Proccess", "diagnosissss", "alles performed", pID, "add Info", "Med1, Med2", 35, PPPS.pp, Result.nok, 5, Organ.penis);
            long oID = operationDB.Insert(operation);
            OperationData operationWithID = new OperationData(oID, operation.Date, operation.Team, operation.Process, operation.Diagnoses, operation.Performed, pID, operation.Additionalinformation, operation.Medication, operation.IntDiagnoses, operation.Ppps, operation.Result, operation.KathDays, operation.Organ);

            operation = operationDB.FindByOperationId(oID);

            Assert.AreEqual(operation.Date.ToShortDateString(), operationWithID.Date.ToShortDateString());
            Assert.AreEqual(operation.Date.ToShortTimeString(), operationWithID.Date.ToShortTimeString());
            Assert.AreEqual(operation.Diagnoses, operationWithID.Diagnoses);
            Assert.AreEqual(operation.OperationId, operationWithID.OperationId);
            Assert.AreEqual(operation.PatientId, operationWithID.PatientId);
            Assert.AreEqual(operation.Performed, operationWithID.Performed);
            Assert.AreEqual(operation.Process, operationWithID.Process);
            Assert.AreEqual(operation.Team, operationWithID.Team);
            Assert.AreEqual(operation.Additionalinformation, operationWithID.Additionalinformation);
            Assert.AreEqual(operation.Medication, operationWithID.Medication);
            Assert.AreEqual(operation.IntDiagnoses, operationWithID.IntDiagnoses);
            Assert.AreEqual(operation.Ppps, operationWithID.Ppps);
            Assert.AreEqual(operation.Result, operationWithID.Result);
            Assert.AreEqual(operation.KathDays, operationWithID.KathDays);

            Assert.IsTrue(operationDB.Delete(oID));

            Assert.IsNull(operationDB.FindByOperationId(oID));
        }

        /// <summary>
        /// Tests Update Operation
        /// </summary>
        [TestMethod]
        public void OperationUpdateTest() {
            IOperation operationDB = Database.CreateOperation();
            OperationData operation = new OperationData(0, DateTime.Now, "Tolles Team", "Toller Proccess", "diagnosissss", "alles performed", pID, "add Info", "Med1, Med2", 35, PPPS.pp, Result.nok, 5, Organ.renal);
            long oID = operationDB.Insert(operation);
            OperationData operationWithID = new OperationData(oID, operation.Date, operation.Team, operation.Process, operation.Diagnoses, operation.Performed, pID, operation.Additionalinformation, operation.Medication, operation.IntDiagnoses, operation.Ppps, operation.Result, operation.KathDays, operation.Organ);

            operation = operationDB.FindByOperationId(oID);

            Assert.AreEqual(operation.Date.ToShortDateString(), operationWithID.Date.ToShortDateString());
            Assert.AreEqual(operation.Date.ToShortTimeString(), operationWithID.Date.ToShortTimeString());
            Assert.AreEqual(operation.Diagnoses, operationWithID.Diagnoses);
            Assert.AreEqual(operation.OperationId, operationWithID.OperationId);
            Assert.AreEqual(operation.PatientId, operationWithID.PatientId);
            Assert.AreEqual(operation.Performed, operationWithID.Performed);
            Assert.AreEqual(operation.Process, operationWithID.Process);
            Assert.AreEqual(operation.Team, operationWithID.Team);
            Assert.AreEqual(operation.Additionalinformation, operationWithID.Additionalinformation);
            Assert.AreEqual(operation.Medication, operationWithID.Medication);
            Assert.AreEqual(operation.IntDiagnoses, operationWithID.IntDiagnoses);
            Assert.AreEqual(operation.Ppps, operationWithID.Ppps);
            Assert.AreEqual(operation.Result, operationWithID.Result);
            Assert.AreEqual(operation.KathDays, operationWithID.KathDays);

            operation.Date = DateTime.MaxValue;
            operation.Team = "New Team";
            operation.Process = "new process";
            operation.Diagnoses = "New Diagnoses";
            operation.Performed = "new performed";
            operation.Additionalinformation = "new addinfo";
            operation.Medication = "new medicatino";
            operation.IntDiagnoses = 17;
            operation.Ppps = PPPS.notDefined;
            operation.Result = Result.notDefined;
            operation.KathDays = 17;

            operationDB.Update(operation);
            OperationData operationchanged = operationDB.FindByOperationId(oID);

            Assert.AreEqual(operation.Date.ToShortDateString(), operationchanged.Date.ToShortDateString());
            Assert.AreEqual(operation.Date.ToShortTimeString(), operationchanged.Date.ToShortTimeString());
            Assert.AreEqual(operation.Diagnoses, operationchanged.Diagnoses);
            Assert.AreEqual(operation.OperationId, operationchanged.OperationId);
            Assert.AreEqual(operation.PatientId, operationchanged.PatientId);
            Assert.AreEqual(operation.Performed, operationchanged.Performed);
            Assert.AreEqual(operation.Process, operationchanged.Process);
            Assert.AreEqual(operation.Team, operationchanged.Team);
            Assert.AreEqual(operation.Additionalinformation, operationchanged.Additionalinformation);
            Assert.AreEqual(operation.Medication, operationchanged.Medication);
            Assert.AreEqual(operation.IntDiagnoses, operationchanged.IntDiagnoses);
            Assert.AreEqual(operation.Ppps, operationchanged.Ppps);
            Assert.AreEqual(operation.Result, operationchanged.Result);
            Assert.AreEqual(operation.KathDays, operationchanged.KathDays);

            Assert.IsTrue(operationDB.Delete(oID));

            Assert.IsNull(operationDB.FindByOperationId(oID));

        }
    }
}
