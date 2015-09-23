using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPD.DAL;
using SPD.CommonObjects;

namespace SPDTest {

    [TestClass]
    public class GenerateDummyDB {

        private Random rand = new Random();

        public GenerateDummyDB() {
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
         }
        
         //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
         [TestCleanup()]
         public void MyTestCleanup() {
         }
        
        #endregion

        [TestMethod]
        public void GenerateDummyDBTest() {
            IPatient patientDB = Database.CreatePatient();
            IVisit visitDB = Database.CreateVisit();
            IOperation operationDB = Database.CreateOperation();
            IDiagnoseGroup diagnosegroupDB = Database.CreateDiagnoseGroup();
            INextAction nextActionDB = Database.CreateNextAction();

            IList<long> diagnoseGroupIds = new List<long>();
            for (int dg = 0; dg < 20; dg++ ) {
                DiagnoseGroupData diagnoseGroup = new DiagnoseGroupData();
                diagnoseGroup.ShortName = getRandomString(5, 8, false);
                diagnoseGroup.LongName = getRandomString(10, 20, true);
                diagnoseGroupIds.Add(diagnosegroupDB.Insert(diagnoseGroup));
            }

            for(int i = 0 ; i < 1000; i++)
            {
                PatientData patient = createRandomPatient();

                long pId = patientDB.Insert(patient);

                for (int j = 0; j < rand.Next(1, 4); j++ ) {
                    operationDB.Insert(createRandomOperation(pId));
                }

                for (int j = 0; j < rand.Next(1, 4); j++) {
                    visitDB.Insert(createRandomVisit(pId));
                }

                for (int j = 0; j < rand.Next(0, 2); j++) {
                    nextActionDB.Insert(createRandomNextAction(pId));
                }

                int index = rand.Next(0, diagnoseGroupIds.Count);
                diagnosegroupDB.AssignPatientToDiagnoseGroup(pId, diagnoseGroupIds[index]);
            }
        }

        private PatientData createRandomPatient() {
            PatientData patient = new PatientData();
            patient.FirstName = getRandomString(5, 20, false);
            patient.SurName = getRandomString(5, 20, false);
            patient.Address = getRandomString(5, 20, true);
            patient.Phone = getRandomString(5, 20, true);
            patient.Weight = (int)(rand.NextDouble() * 15);

            switch (rand.Next(0,2))
            {
                case 0:
                    patient.Ambulant = Ambulant.ambulant;
                    break;
                case 1:
                    patient.Ambulant = Ambulant.notAmbulant;
                    break;
            }

            switch (rand.Next(0, 3))
            {
                case 0:
                    patient.Finished = Finished.finished;
                    break;
                case 1:
                    patient.Finished = Finished.notFinished;
                    break;
                case 2:
                    patient.Finished = Finished.undefined;
                    break;
            }

            switch (rand.Next(0, 2))
            {
                case 0:
                    patient.Sex = Sex.female;
                    break;
                case 1:
                    patient.Sex = Sex.male;
                    break;
            }

            switch (rand.Next(0, 5))
            {
                case 0:
                    patient.Linz = Linz.undefined;
                    break;
                case 1:
                    patient.Linz = Linz.finished;
                    break;
                case 2:
                    patient.Linz = Linz.notPlanned;
                    break;
                case 3:
                    patient.Linz = Linz.planned;
                    break;
                case 4:
                    patient.Linz = Linz.running;
                    break;
            }

            switch (rand.Next(0, 3)) {
                case 0:
                    patient.ResidentOfAsmara = ResidentOfAsmara.no;
                    break;
                case 1:
                    patient.ResidentOfAsmara = ResidentOfAsmara.undefined;
                    break;
                case 2:
                    patient.ResidentOfAsmara = ResidentOfAsmara.yes;
                    break;
            }

            patient.DateOfBirth = new DateTime(
                DateTime.Now.Year - rand.Next(1,20),
                rand.Next(1,13), rand.Next(1,29));
            
            return patient;
        }

        private VisitData createRandomVisit(long pId) {
            VisitData visit = new VisitData();
            visit.PatientId = pId;
            visit.Anesthesiology = getRandomString(10, 50, true);
            visit.Blooddiagnostic = getRandomString(5, 40, true);
            visit.Cause = getRandomString(10, 45, true);
            visit.ExtraDiagnosis = getRandomString(15, 60, true);
            visit.ExtraTherapy = getRandomString(15, 60, true);
            visit.Localis = getRandomString(5, 30, true);
            visit.Procedure = getRandomString(3, 45, true);
            visit.Radiodiagnostics = getRandomString(10, 40, true);
            visit.Todo = getRandomString(0, 50, true);
            visit.Ultrasound = getRandomString(10, 20, true);
            visit.VisitDate = new DateTime(DateTime.Now.Year - 8 + rand.Next(0,9), rand.Next(1, 13), rand.Next(1, 28));
            return visit;
        }

        private OperationData createRandomOperation(long pId) {
            OperationData operation = new OperationData();
            operation.PatientId = pId;
            operation.Additionalinformation = getRandomString(10, 50, true);
            operation.Date = new DateTime(DateTime.Now.Year - 8 + rand.Next(0, 9), rand.Next(1, 13), rand.Next(1, 28));
            operation.Diagnoses = getRandomString(10, 30, true);
            operation.IntDiagnoses = rand.Next(0, 11);
            operation.KathDays = rand.Next(0, 10);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rand.Next(0, 3); i++ )
            {
                sb.Append(getRandomString(5, 10, true)).Append(rand.Next(0, 10)).Append(Environment.NewLine);
            }

            operation.Medication = sb.ToString();  

            switch (rand.Next(0, 4))
            {
                case 0:
                    operation.Organ = Organ.penis;
                    break;
                case 1:
                    operation.Organ = Organ.renal;
                    break;
                case 2:
                    operation.Organ = Organ.testicle;
                    break;
                case 3:
                    operation.Organ = Organ.undefined;
                    break;
            }
            operation.Performed = getRandomString(1, 30, true);

            switch (rand.Next(0,3))
            {
                case 0:
                    operation.Ppps = PPPS.notDefined;
                    break;
                case 1:
                    operation.Ppps = PPPS.pp;
                    break;
                case 2:
                    operation.Ppps = PPPS.ps;
                    break;

            }

            operation.Process = getRandomString(10, 30, true);
            switch (rand.Next(0, 3))
            {
                case 0:
                    operation.Result = Result.nok;
                    break;
                case 1:
                    operation.Result = Result.notDefined;
                    break;
                case 3:
                    operation.Result = Result.ok;
                    break;
            }
            operation.Team = getRandomString(10, 60, true);


            return operation;
        }

        private NextActionData createRandomNextAction(long pId) {
            NextActionData nextAction = new NextActionData();
            nextAction.PatientID = pId;
            nextAction.ActionhalfYear = rand.Next(0, 2);
            nextAction.ActionYear = DateTime.Now.Year - 2 + rand.Next(0, 7);
            nextAction.Todo = getRandomString(10, 50, true);
            switch (rand.Next(0,2))
            {
                case 0:
                    nextAction.ActionKind = ActionKind.control;
                    break;
                case 1:
                    nextAction.ActionKind = ActionKind.operation;
                    break;
            }
            return nextAction;
        }

        /// <summary>
        /// Gets the random string.
        /// </summary>
        /// <returns></returns>
        private string getRandomString(int min, int max, bool blanks) {
            StringBuilder sb = new StringBuilder();
            int count = rand.Next(min, max + 1);
            string allowedchar = "abcdefghijklmnopqrstuvwxyz";
            if (blanks)
            {
                allowedchar += "    ";
            }
            for (int i = 0; i < count; i++) {
                //char ch = (char)((rand.Next() % ('z' - 'a')) + 'a');
                sb.Append(allowedchar[rand.Next(0, allowedchar.Length)]);
            }
            return sb.ToString();
        }
    }
}
