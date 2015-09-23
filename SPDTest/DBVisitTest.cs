using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPD.DAL;
using SPD.CommonObjects;

namespace SPDTest {

    /*
    IList<VisitData> FindAll();
    OK VisitData FindByID(long id);
    OK IList<VisitData> FindByPatientID(long id);
    OK long Insert(VisitData visit);
    Ok bool Update(VisitData visit);
    OK bool Delete(long id);
    */

    /// <summary>
    /// Zusammenfassungsbeschreibung für DBVisitTest
    /// </summary>
    [TestClass]
    public class DBVisitTest {

        private long pID;

        public DBVisitTest() {
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
        
         //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
         [TestCleanup()]
         public void MyTestCleanup() {
             IPatient patientDB = Database.CreatePatient();
             patientDB.Delete(pID);
         }
        
        #endregion

        [TestMethod]
        public void VisitInsertTest() {
             IVisit visitDB = Database.CreateVisit();
             VisitData visit = new VisitData(0, "good Cause", "lokkkalis", "extra Diagnossses", "procedurrre", "extratherapie", pID, DateTime.Now, "anest...", "ultrasound", "blooood", "ToDo", "Radiodiagnostic");
             long vID = visitDB.Insert(visit);
             VisitData visitWithID = new VisitData(vID, visit.Cause, visit.Localis, visit.ExtraDiagnosis, visit.Procedure, visit.ExtraTherapy, pID, visit.VisitDate, visit.Anesthesiology, visit.Ultrasound, visit.Blooddiagnostic, visit.Todo, visit.Radiodiagnostics);

             visit = visitDB.FindByID(vID);

             Assert.AreEqual(visit.Anesthesiology, visitWithID.Anesthesiology);
             Assert.AreEqual(visit.Blooddiagnostic, visitWithID.Blooddiagnostic);
             Assert.AreEqual(visit.Cause, visitWithID.Cause);
             Assert.AreEqual(visit.ExtraDiagnosis, visitWithID.ExtraDiagnosis);
             Assert.AreEqual(visit.ExtraTherapy, visitWithID.ExtraTherapy);
             Assert.AreEqual(visit.Id, vID);
             Assert.AreEqual(visit.Localis, visitWithID.Localis);
             Assert.AreEqual(visit.PatientId, pID);
             Assert.AreEqual(visit.Procedure, visitWithID.Procedure);
             Assert.AreEqual(visit.Ultrasound, visitWithID.Ultrasound);
             Assert.AreEqual(visit.VisitDate.ToShortDateString(), visitWithID.VisitDate.ToShortDateString());
             Assert.AreEqual(visit.VisitDate.ToShortTimeString(), visitWithID.VisitDate.ToShortTimeString());
             Assert.AreEqual(visit.Todo, visitWithID.Todo);
             Assert.AreEqual(visit.Radiodiagnostics, visitWithID.Radiodiagnostics);

             Assert.IsTrue(visitDB.Delete(vID));

             Assert.IsNull(visitDB.FindByID(vID));
        }

        [TestMethod]
        public void VisitFindByPatientTest() {
            IVisit visitDB = Database.CreateVisit();
            VisitData visit1 = new VisitData(0, "good Cause", "lokkkalis", "extra Diagnossses", "procedurrre", "extratherapie", pID, DateTime.Now, "anest...", "ultrasound", "blooood", "Todo", "Radiodiagnasdn");
            long vID1 = visitDB.Insert(visit1);
            VisitData visitWithID1 = new VisitData(vID1, visit1.Cause, visit1.Localis, visit1.ExtraDiagnosis, visit1.Procedure, visit1.ExtraTherapy, pID, visit1.VisitDate, visit1.Anesthesiology, visit1.Ultrasound, visit1.Blooddiagnostic, visit1.Todo, visit1.Radiodiagnostics);
            VisitData visit2 = new VisitData(0, "asdfg", "nkjbjhbhj", "ejhij", "aölsdfjöasj", "laksdjalksd", pID, new DateTime(2007, 12, 01), "ikouhz...", "döner", "kljhg", "asdas", "asdasfd");
            long vID2 = visitDB.Insert(visit2);
            VisitData visitWithID2 = new VisitData(vID2, visit2.Cause, visit2.Localis, visit2.ExtraDiagnosis, visit2.Procedure, visit2.ExtraTherapy, pID, visit2.VisitDate, visit2.Anesthesiology, visit2.Ultrasound, visit2.Blooddiagnostic, visit2.Todo, visit2.Radiodiagnostics);
            VisitData visit3 = new VisitData(0, "öloiu", "kjhsbdklsw", "üüpüpü", "asüdkpasüd", "+*a", pID, new DateTime(2007, 12, 02), "pooip", "saddsf", "bloooodüüü", "todoooo", "Radioooo");
            long vID3 = visitDB.Insert(visit3);
            VisitData visitWithID3 = new VisitData(vID3, visit3.Cause, visit3.Localis, visit3.ExtraDiagnosis, visit3.Procedure, visit3.ExtraTherapy, pID, visit3.VisitDate, visit3.Anesthesiology, visit3.Ultrasound, visit3.Blooddiagnostic, visit3.Todo, visit3.Radiodiagnostics);

            IList<VisitData> visits = visitDB.FindByPatientID(pID);
            Assert.AreEqual(3, visits.Count);

            foreach (VisitData visit in visits) {
                Assert.IsTrue(visitDB.Delete(visit.Id));
            }

            visits = visitDB.FindByPatientID(pID);
            Assert.AreEqual(0, visits.Count);
        }

        /// <summary>
        /// test visit update
        /// </summary>
        [TestMethod]
        public void VisitUpdateTest() {
            IVisit visitDB = Database.CreateVisit();
            VisitData visit = new VisitData(0, "good Cause", "lokkkalis", "extra Diagnossses", "procedurrre", "extratherapie", pID, DateTime.Now, "anest...", "ultrasound", "blooood", "ToDo", "Radiodiagnostic");
            long vID = visitDB.Insert(visit);
            VisitData visitWithID = new VisitData(vID, visit.Cause, visit.Localis, visit.ExtraDiagnosis, visit.Procedure, visit.ExtraTherapy, pID, visit.VisitDate, visit.Anesthesiology, visit.Ultrasound, visit.Blooddiagnostic, visit.Todo, visit.Radiodiagnostics);

            visit = visitDB.FindByID(vID);

            Assert.AreEqual(visit.Anesthesiology, visitWithID.Anesthesiology);
            Assert.AreEqual(visit.Blooddiagnostic, visitWithID.Blooddiagnostic);
            Assert.AreEqual(visit.Cause, visitWithID.Cause);
            Assert.AreEqual(visit.ExtraDiagnosis, visitWithID.ExtraDiagnosis);
            Assert.AreEqual(visit.ExtraTherapy, visitWithID.ExtraTherapy);
            Assert.AreEqual(visit.Id, vID);
            Assert.AreEqual(visit.Localis, visitWithID.Localis);
            Assert.AreEqual(visit.PatientId, pID);
            Assert.AreEqual(visit.Procedure, visitWithID.Procedure);
            Assert.AreEqual(visit.Ultrasound, visitWithID.Ultrasound);
            Assert.AreEqual(visit.VisitDate.ToShortDateString(), visitWithID.VisitDate.ToShortDateString());
            Assert.AreEqual(visit.VisitDate.ToShortTimeString(), visitWithID.VisitDate.ToShortTimeString());
            Assert.AreEqual(visit.Todo, visitWithID.Todo);
            Assert.AreEqual(visit.Radiodiagnostics, visitWithID.Radiodiagnostics);


            visit.Anesthesiology = "new ana";
            visit.Blooddiagnostic = "New Blood diag";
            visit.Cause = "new cause";
            visit.ExtraDiagnosis = "New Extra Diagnoses";
            visit.ExtraTherapy = "new Extra Therapy";
            visit.Localis = "new localis";
            visit.Procedure = "new procedure";
            visit.Radiodiagnostics = "new Radiodiagnostics";
            visit.Todo = "new TODO";
            visit.Ultrasound = "new Ultrasound";
            visit.VisitDate = DateTime.MaxValue;

            visitDB.Update(visit);
            VisitData visitchanged = visitDB.FindByID(vID);

            Assert.AreEqual(visit.Anesthesiology, visitchanged.Anesthesiology);
            Assert.AreEqual(visit.Blooddiagnostic, visitchanged.Blooddiagnostic);
            Assert.AreEqual(visit.Cause, visitchanged.Cause);
            Assert.AreEqual(visit.ExtraDiagnosis, visitchanged.ExtraDiagnosis);
            Assert.AreEqual(visit.ExtraTherapy, visitchanged.ExtraTherapy);
            Assert.AreEqual(visit.Id, vID);
            Assert.AreEqual(visit.Localis, visitchanged.Localis);
            Assert.AreEqual(visit.PatientId, pID);
            Assert.AreEqual(visit.Procedure, visitchanged.Procedure);
            Assert.AreEqual(visit.Ultrasound, visitchanged.Ultrasound);
            //Visit Date cannot be updated!!
            //Assert.AreEqual(visit.VisitDate.ToShortDateString(), visitchanged.VisitDate.ToShortDateString());
            //Assert.AreEqual(visit.VisitDate.ToShortTimeString(), visitchanged.VisitDate.ToShortTimeString());
            Assert.AreEqual(visit.Todo, visitchanged.Todo);
            Assert.AreEqual(visit.Radiodiagnostics, visitchanged.Radiodiagnostics);

            Assert.IsTrue(visitDB.Delete(vID));

            Assert.IsNull(visitDB.FindByID(vID));
        }
    }
}
