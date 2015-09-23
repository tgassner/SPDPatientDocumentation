using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPD.DAL;
using SPD.CommonObjects;

namespace SPDTest {
    /*
    OK IList<PatientData> FindAll();
    OK PatientData FindByID(long id);
    OK long Insert(PatientData patient);
    OK bool Update(PatientData patient);
    OK bool Delete(long id);
    OK long NumberOfPatients();
    IList<PatientData> FindDiagnose(string searchString);
    IList<PatientData> FindProcedure(string searchString);
    IList<PatientData> FindTreatment(string searchString);
    OK bool InsertFurtherTreatment(string ft,long pID);
    OK string GetFurtherTreatmentByPatentID(long pID);
    OK IDictionary<long, string> GetAllFurtherTreatments();
    */

    /// <summary>
    /// Zusammenfassungsbeschreibung für DBPatientTest
    /// </summary>
    [TestClass]
    public class DBPatientTest {

        private Random rand = new Random();

        public DBPatientTest() {
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
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        /// <summary>
        /// Inserts the test.
        /// </summary>
        [TestMethod]
        public void PatientInsertTest() {
            IPatient patientDB = Database.CreatePatient();
            DateTime date = new DateTime(2006, 12, 24);
            PatientData patient = new PatientData(0, "first", "sure", date, Sex.male, "0123456789", 29, "address", ResidentOfAsmara.no, Ambulant.ambulant, Finished.finished, Linz.finished);
            long pID = patientDB.Insert(patient);
            PatientData pdataWithID = new PatientData(pID,
                patient.FirstName, patient.SurName, patient.DateOfBirth,
                patient.Sex, patient.Phone, patient.Weight, patient.Address, patient.ResidentOfAsmara, patient.Ambulant, patient.Finished, patient.Linz);

            patient = patientDB.FindByID(pdataWithID.Id);

            Assert.AreEqual(patient.Id, pdataWithID.Id);
            Assert.AreEqual(patient.FirstName, pdataWithID.FirstName);
            Assert.AreEqual(patient.SurName, pdataWithID.SurName);
            Assert.AreEqual(patient.Phone, pdataWithID.Phone);
            Assert.AreEqual(patient.DateOfBirth, pdataWithID.DateOfBirth);
            Assert.AreEqual(patient.Sex, pdataWithID.Sex);
            Assert.AreEqual(patient.Weight, pdataWithID.Weight);
            Assert.AreEqual(patient.Address, pdataWithID.Address);

            Assert.IsTrue(patientDB.Delete(pID));
            Assert.IsNull(patientDB.FindByID(pID));
        }

        /// <summary>
        /// Patients the final report test.
        /// </summary>
        [TestMethod]
        public void PatientFinalReportTest() {
            IPatient patientDB = Database.CreatePatient();
            DateTime date = new DateTime(2006, 12, 24);
            PatientData patient = new PatientData(0, "first", "sure", date, Sex.male, "0123456789", 29, "address", ResidentOfAsmara.no, Ambulant.ambulant, Finished.finished, Linz.finished);
            long pID = patientDB.Insert(patient);
            PatientData pdataWithID = new PatientData(pID,
                patient.FirstName, patient.SurName, patient.DateOfBirth,
                patient.Sex, patient.Phone, patient.Weight, patient.Address, patient.ResidentOfAsmara, patient.Ambulant, patient.Finished, patient.Linz);

            patientDB.InsertFinalReport("Trallala Final Report", pID);
            Assert.AreEqual("Trallala Final Report", patientDB.GetFinalReportByPatentID(pID));

            patientDB.InsertFinalReport("Döner", pID);
            Assert.AreEqual("Döner", patientDB.GetFinalReportByPatentID(pID));

            Assert.IsTrue(patientDB.Delete(pID));

            Assert.IsNull(patientDB.FindByID(pID));
        }

        /// <summary>
        /// Updates the test.
        /// </summary>
        [TestMethod]
        public void PatientUpdateTest() {
            IPatient patientDB = Database.CreatePatient();
            DateTime date = new DateTime(2006, 12, 24);
            PatientData patient = new PatientData(0, "first", "sure", date, Sex.male, "0123456789", 29, "address", ResidentOfAsmara.no, Ambulant.ambulant, Finished.finished, Linz.finished);
            long pID = patientDB.Insert(patient);
            PatientData pdataWithID = new PatientData(pID,
                patient.FirstName, patient.SurName, patient.DateOfBirth,
                patient.Sex, patient.Phone, patient.Weight, patient.Address, patient.ResidentOfAsmara, patient.Ambulant, patient.Finished, patient.Linz);

            pdataWithID.Address = "Trallala";
            pdataWithID.DateOfBirth = new DateTime(2007, 05, 06);
            pdataWithID.FirstName = "asdf";
            pdataWithID.Phone = "0815";
            pdataWithID.Sex = Sex.female;
            pdataWithID.SurName = "asdasfd";
            pdataWithID.Weight = 35;

            patientDB.Update(pdataWithID);

            patient = patientDB.FindByID(pID);

            Assert.AreEqual(patient.Id, pdataWithID.Id);
            Assert.AreEqual(patient.FirstName, pdataWithID.FirstName);
            Assert.AreEqual(patient.Phone, pdataWithID.Phone);
            Assert.AreEqual(patient.SurName, pdataWithID.SurName);
            Assert.AreEqual(patient.DateOfBirth, pdataWithID.DateOfBirth);
            Assert.AreEqual(patient.Sex, pdataWithID.Sex);
            Assert.AreEqual(patient.Weight, pdataWithID.Weight);
            Assert.AreEqual(patient.Address, pdataWithID.Address);

            Assert.IsTrue(patientDB.Delete(pID));
            Assert.IsNull(patientDB.FindByID(pID));
        }

        /// <summary>
        /// Finds all test.
        /// </summary>
        [TestMethod]
        public void PatientFindAllTest() {
            IPatient patientDB = Database.CreatePatient();
            IList<PatientData> patients;
            patients = patientDB.FindAll();
            int originalCountOfPatients = patients.Count;
            DateTime date = new DateTime(2006, 12, 24);
            PatientData patient = new PatientData(0, "first", "sure", date, Sex.male, "0123456789", 29, "address", ResidentOfAsmara.no, Ambulant.ambulant, Finished.finished, Linz.finished);
            long pID = patientDB.Insert(patient);
            PatientData pdataWithID = new PatientData(pID,
                patient.FirstName, patient.SurName, patient.DateOfBirth,
                patient.Sex, patient.Phone, patient.Weight, patient.Address, patient.ResidentOfAsmara, patient.Ambulant, patient.Finished, patient.Linz);

            patients = patientDB.FindAll();

            Assert.AreEqual(originalCountOfPatients + 1, patients.Count);

            bool exists = false;
            long maxPID = 0;
            int newCountOfPatients = patients.Count;

            foreach (PatientData patientlocal1 in patients) {
                if (patientlocal1.Id == pID) {
                    exists = true;
                }
                if (patientlocal1.Id > maxPID) {
                    maxPID = patientlocal1.Id;
                }
            }
            Assert.IsTrue(exists);

            IList<PatientData> patients2 = new List<PatientData>();
            for (int i = 0; i < (maxPID + 1); i++) {
                PatientData patientlocal2 = patientDB.FindByID(i);
                if (patientlocal2 != null) {
                    patients2.Add(patientlocal2);
                }
            }

            Assert.AreEqual(patients2.Count, patients.Count);

            Assert.IsTrue(patientDB.Delete(pID));
            Assert.IsNull(patientDB.FindByID(pID));

            patients = patientDB.FindAll();

            Assert.AreEqual(originalCountOfPatients, patients.Count);
            Assert.AreEqual(patients.Count + 1, newCountOfPatients);

        }

        /// <summary>
        /// Gets the random string.
        /// </summary>
        /// <returns></returns>
        private string getRandomString() {
            StringBuilder sb = new StringBuilder();
            int count = rand.Next() % 20 + 1;
            for (int i = 0; i < count; i++) {
                char ch = (char)((rand.Next() % ('z' - 'a')) + 'a');
                sb.Append(ch);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Tests number of patient
        /// </summary>
        [TestMethod]
        public void PatientGetNumberOfPatientTest() {
            IPatient patientDB = Database.CreatePatient();
            IList<PatientData> patients = patientDB.FindAll();
            long number = patientDB.NumberOfPatients();
            Assert.AreEqual(patients.Count, number);
        }

        private ResidentOfAsmara getRandomResidentOfAsmara() {
            return (ResidentOfAsmara)Enum.Parse(new ResidentOfAsmara().GetType(), Convert.ToString(rand.Next(0,3)));
        }

        private Linz getRandomLinz() {
            return (Linz)Enum.Parse(new Linz().GetType(), Convert.ToString(rand.Next(0, 5)));
        }

        private Ambulant getRandomAmbulant() {
            return (Ambulant)Enum.Parse(new Ambulant().GetType(), Convert.ToString(rand.Next(1, 3)));
        }

        private Finished getRandomFinished() {
            return (Finished)Enum.Parse(new Finished().GetType(), Convert.ToString(rand.Next(0, 3)));
        }

        /// <summary>
        /// Fills the patient.
        /// </summary>
        [Ignore]
        [TestMethod]
        public void PatientFillPatient() {
            Random rand = new Random();
            IPatient patientDB = Database.CreatePatient();
            Sex sex;
            IList<long> pIds = new List<long>();
            for (int i = 0; i < 5000; i++) {
                if ((rand.Next() % 2) == 0) {
                    sex = Sex.female;
                } else {
                    sex = Sex.male;
                }
                pIds.Add(patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), sex, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz())));
                if (i % 50 == 0)
                    Console.WriteLine(i.ToString());
            }
            foreach(long pid in pIds) {
                patientDB.Delete(pid);
            }
        }

        /// <summary>
        /// Patients the get all final reports.
        /// </summary>
        [TestMethod]
        public void PatientGetAllFinalReports() {
            Random rand = new Random();
            IPatient patientDB = Database.CreatePatient();
            long pid1 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid2 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid3 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid4 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid5 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));

            patientDB.InsertFinalReport("aaa bbb ccc ddd", pid1);
            patientDB.InsertFinalReport("ccc ddd eee fff", pid2);
            patientDB.InsertFinalReport("eee fff ggg hhh", pid3);
            patientDB.InsertFinalReport("fff ggg hhh iii", pid4);
            patientDB.InsertFinalReport("ggg hhh iii jjj", pid5);

            IDictionary<long, string> finalReport = patientDB.GetAllFinalReports();

            Assert.AreEqual(finalReport[pid1], "aaa bbb ccc ddd");
            Assert.AreEqual(finalReport[pid2], "ccc ddd eee fff");
            Assert.AreEqual(finalReport[pid3], "eee fff ggg hhh");
            Assert.AreEqual(finalReport[pid4], "fff ggg hhh iii");
            Assert.AreEqual(finalReport[pid5], "ggg hhh iii jjj");

            patientDB.Delete(pid1);
            patientDB.Delete(pid2);
            patientDB.Delete(pid3);
            patientDB.Delete(pid4);
            patientDB.Delete(pid5);
        }

        /// <summary>
        /// Patients the find diagnose.
        /// </summary>
        [Ignore]
        [TestMethod]
        public void PatientFindDiagnose() {
            Random rand = new Random();
            IPatient patientDB = Database.CreatePatient();
            long pid1 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid2 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid3 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid4 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid5 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));

          

            patientDB.Delete(pid1);
            patientDB.Delete(pid2);
            patientDB.Delete(pid3);
            patientDB.Delete(pid4);
            patientDB.Delete(pid5);
        }

        /// <summary>
        /// Patients the find procedure.
        /// </summary>
        [TestMethod]
        [Ignore]
        public void PatientFindProcedure() {
            Random rand = new Random();
            IPatient patientDB = Database.CreatePatient();
            long pid1 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid2 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid3 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid4 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid5 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));

         

            patientDB.Delete(pid1);
            patientDB.Delete(pid2);
            patientDB.Delete(pid3);
            patientDB.Delete(pid4);
            patientDB.Delete(pid5);
        }

        [TestMethod]
        [Ignore]
        public void PatientFindTreatment() {
            Random rand = new Random();
            IPatient patientDB = Database.CreatePatient();
            long pid1 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid2 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid3 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid4 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));
            long pid5 = patientDB.Insert(new PatientData(0, getRandomString(), getRandomString(), new DateTime(rand.Next() % 10 + 1995, rand.Next() % 12 + 1, rand.Next() % 28 + 1), Sex.male, getRandomString(), rand.Next() % 99, getRandomString(), getRandomResidentOfAsmara(), getRandomAmbulant(), getRandomFinished(), getRandomLinz()));

       
            patientDB.Delete(pid1);
            patientDB.Delete(pid2);
            patientDB.Delete(pid3);
            patientDB.Delete(pid4);
            patientDB.Delete(pid5);
        }
    }
}
