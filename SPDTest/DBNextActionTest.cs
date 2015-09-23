using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPD.DAL;
using SPD.CommonObjects;

namespace SPDTest {
    /*
    IList<NextActionData> FindAll();
    OK NextActionData FindById(long nextActionId);
    IList<NextActionData> FindByPatientId(long patientId);
    OK long Insert(NextActionData nadata);
    OK bool Delete(long nextActionId);
    bool Update(NextActionData nadata);
    IList<long> FindPatientIdsByYearHalfYearAndActionKind(long year, long halfYear, ActionKind actionKind);
    IList<long> GetAllNextActionYears();
    */

    /// <summary>
    /// Zusammenfassungsbeschreibung für DBNextActionTest
    /// </summary>
    [TestClass]
    public class DBNextActionTest {

        private long pID;

        public DBNextActionTest() {
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
        public void NextActionInsertTest() {
             INextAction nextActionDB = Database.CreateNextAction();
             NextActionData nextAction = new NextActionData(0, pID, ActionKind.control, 1981, 5, "todotodo");
             long naID = nextActionDB.Insert(nextAction);
             NextActionData nextActionID = new NextActionData(naID, pID, nextAction.ActionKind, nextAction.ActionYear, nextAction.ActionhalfYear, nextAction.Todo);

             nextAction = nextActionDB.FindById(naID);

             Assert.AreEqual(nextAction.ActionhalfYear, nextActionID.ActionhalfYear);
             Assert.AreEqual(nextAction.ActionKind, nextActionID.ActionKind);
             Assert.AreEqual(nextAction.ActionYear, nextActionID.ActionYear);
             Assert.AreEqual(nextAction.NextActionID, nextActionID.NextActionID);
             Assert.AreEqual(nextAction.PatientID, nextActionID.PatientID);
             Assert.AreEqual(nextAction.Todo, nextActionID.Todo);

             Assert.IsTrue(nextActionDB.Delete(naID));

             Assert.IsNull(nextActionDB.FindById(naID));
        }
    }
}
