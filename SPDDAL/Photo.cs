using System;
using System.Collections.Generic;
using System.Text;
using SPD.CommonObjects;
using System.Data;

namespace SPD.DAL {
    class Photo : IPhoto{

        const string SQL_FIND_BY_ID = "SELECT * FROM photo WHERE PhotoID = @PhotoID";
        const string SQL_FIND_BY_PATIENT_ID = "SELECT * FROM photo WHERE PatientID = @PatientID";
        const string SQL_FIND_BY_PHOTO_ID = "SELECT * FROM photo WHERE PhotoID = @PhotoID";
        const string SQL_FIND_ALL = "SELECT * FROM photo";
        //readonly string SQL_UPDATE_BY_ID = "UPDATE photo SET Link = @Link, Kommentar = @Kommentar WHERE PhotoId = @PhotoId";
        readonly string SQL_INSERT_BY_ID = "INSERT INTO photo (PatientID, Link, Kommentar) VALUES(@PatientID, @Link, @Kommentar)";
        readonly string SQL_DELETE_BY_ID = "DELETE FROM photo WHERE PhotoID = @PhotoID";
        //static IDbCommand findByIdCmd;
        static IDbCommand findByPatientIdCmd;
        static IDbCommand findByPhotoIdCmd;
        static IDbCommand findAllCmd;
        //static IDbCommand updateByIdCmd;
        static IDbCommand insertByIdCmd;
        static IDbCommand deleteByIdCmd;
        static IDbCommand lastInsertedRowCmd = null;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ImageData fillPhoto(IDataReader rdr) {
            ImageData photo = new ImageData();

            photo.PhotoID = Convert.ToInt64(rdr["PhotoID"]);
            photo.PatientID = Convert.ToInt64(rdr["PatientID"]);
            photo.Link = Convert.ToString(rdr["Link"]);
            photo.Kommentar = Convert.ToString(rdr["Kommentar"]);

            return photo;
        }

        public IList<ImageData> FindAll() {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findAllCmd == null) {
                    findAllCmd = DbUtil.CreateCommand(SQL_FIND_ALL, DbUtil.CurrentConnection);
                }

                using (IDataReader rdr = findAllCmd.ExecuteReader()) {
                    IList<ImageData> imageList = new List<ImageData>();
                    while (rdr.Read()) {
                        imageList.Add(fillPhoto(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Find All Fotos - Count: " + imageList.Count + " " + ((tend - tstart) / 10000) + "ms");

                    return imageList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public IList<ImageData> FindByPatientId(long patientId) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByPatientIdCmd == null) {
                    findByPatientIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_PATIENT_ID, DbUtil.CurrentConnection);
                    findByPatientIdCmd.Parameters.Add(DbUtil.CreateParameter("@PatientID", DbType.Int64));
                }

                ((IDataParameter)findByPatientIdCmd.Parameters["@PatientID"]).Value = patientId;

                using (IDataReader rdr = findByPatientIdCmd.ExecuteReader()) {
                    IList<ImageData> imageList = new List<ImageData>();
                    while (rdr.Read()) {
                        imageList.Add(fillPhoto(rdr));
                    }

                    long tend = DateTime.Now.Ticks;
                    log.Info("Find Fotos by PatientId: " + patientId + " Count: " + imageList.Count + " " + ((tend - tstart) / 10000) + "ms");

                    return imageList;
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public ImageData FindByPhotoId(long photoID) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (findByPhotoIdCmd == null) {
                    findByPhotoIdCmd = DbUtil.CreateCommand(SQL_FIND_BY_PHOTO_ID, DbUtil.CurrentConnection);
                    findByPhotoIdCmd.Parameters.Add(DbUtil.CreateParameter("@PhotoID", DbType.Int64));
                }

                ((IDataParameter)findByPhotoIdCmd.Parameters["@PhotoID"]).Value = photoID;

                using (IDataReader rdr = findByPhotoIdCmd.ExecuteReader()) {
                    if (rdr.Read()) {

                        long tend = DateTime.Now.Ticks;
                        log.Info("Find Photo by Id: " + photoID + " " + ((tend - tstart) / 10000) + "ms");
                        return fillPhoto(rdr);
                    }
                }
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
            log.Info("Find Photo by Id NOT FOUND: " + photoID);
            return null;
        }

        public long Insert(ImageData idata) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (insertByIdCmd == null) {
                    insertByIdCmd = DbUtil.CreateCommand(SQL_INSERT_BY_ID + DbUtil.GetAppendix("PhotoID"), DbUtil.CurrentConnection);
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@PatientID", DbType.Int64));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@Link", DbType.String));
                    insertByIdCmd.Parameters.Add(DbUtil.CreateParameter("@Kommentar", DbType.String));
                }

                ((IDataParameter)insertByIdCmd.Parameters["@PatientID"]).Value = idata.PatientID;
                ((IDataParameter)insertByIdCmd.Parameters["@Link"]).Value = idata.Link;
                ((IDataParameter)insertByIdCmd.Parameters["@Kommentar"]).Value = idata.Kommentar;

                //bool ok = insertByIdCmd.ExecuteNonQuery() == 1;
                Object insertRet = insertByIdCmd.ExecuteScalar();

                long tend = DateTime.Now.Ticks;
                log.Info("Insert Foto: " + insertRet + " " + ((tend - tstart) / 10000) + "ms");

                return DbUtil.getGeneratedId((IDbCommand)insertByIdCmd, lastInsertedRowCmd, insertRet);
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool Delete(long photoId) {
            try {

                long tstart = DateTime.Now.Ticks;

                DbUtil.OpenConnection();

                if (deleteByIdCmd == null) {
                    deleteByIdCmd = DbUtil.CreateCommand(SQL_DELETE_BY_ID, DbUtil.CurrentConnection);
                    deleteByIdCmd.Parameters.Add(DbUtil.CreateParameter("@PhotoID", DbType.Int64));
                }

                ((IDataParameter)deleteByIdCmd.Parameters["@PhotoID"]).Value = photoId;

                bool ok = deleteByIdCmd.ExecuteNonQuery() == 1;

                long tend = DateTime.Now.Ticks;
                log.Info("Delete Foto: " + photoId + " " + ok + " " + ((tend - tstart) / 10000) + "ms");

                return ok;
            } catch (Exception e) {
                log.Error(e.Message);
                throw e;
            } finally {
                DbUtil.CloseConnection();
            }
        }

        public bool Update(ImageData photo) {
            log.Error("Update Foto not implemented");
            throw new Exception("The method or operation is not implemented.");
        }

    }
}
