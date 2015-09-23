using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPD.DAL;
using SPD.CommonObjects;

namespace SPDTest {
    /*
    IList<ImageData> FindAll();
    IList<ImageData> FindByPatientId(long patientId);
    OK ImageData FindByPhotoId(long photoID);
    OK long Insert(ImageData idata);
    OK bool Delete(long photoId);
    bool Update(ImageData photo);
    */

    /// <summary>
    /// Zusammenfassungsbeschreibung für DBPhotoTest
    /// </summary>
    [TestClass]
    public class DBPhotoTest {


        private long pID;

        public DBPhotoTest() {
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
        
        // Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
         [TestCleanup()]
         public void MyTestCleanup() { 
            IPatient patientDB = Database.CreatePatient();
            patientDB.Delete(pID);
         }
      
        #endregion

        [TestMethod]
        public void PhotoInsertTest() {
            IPhoto photoDB = Database.CreatePhoto();
            ImageData photo = new ImageData(0, pID, "c:\\image.jpg", "Gutes Foto");
            long iID = photoDB.Insert(photo);
            ImageData photoWithID = new ImageData(iID, photo.PatientID, photo.Link, photo.Kommentar);

            photo = photoDB.FindByPhotoId(iID);

            Assert.AreEqual(photo.Link, photoWithID.Link);
            Assert.AreEqual(photo.Kommentar, photoWithID.Kommentar);
            Assert.AreEqual(photo.PhotoID, photoWithID.PhotoID);
            Assert.AreEqual(photo.Link, photoWithID.Link);

            Assert.IsTrue(photoDB.Delete(iID));

            Assert.IsNull(photoDB.FindByPhotoId(iID));
        }
    }
}
