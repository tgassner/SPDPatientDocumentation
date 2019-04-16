using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using MySql.Data.MySqlClient;
using Npgsql;
using SPD.Exceptions;


namespace SPD.DAL {

    /// <summary>
    /// Utility to manage the database connection
    /// </summary>
    internal class DbUtil {

        const string SQL_LAST_INSERTED_ROW = "SELECT @@Identity";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static Databases database = Databases.Undefined;

        public static Databases Database {
            get {
                if (database == Databases.Undefined) {
                    database = SPD.DAL.Properties.Settings.Default.Database;
                }
                return database;
            }
        }

        /// <summary>
        /// Chached connection variable
        /// </summary>
        private static IDbConnection conn = null;

        /// <summary>
        /// Chached open connection counter 
        /// </summary>
        private static int nestedOpens = 0;
        /// <summary>
        /// Chached connection string
        /// </summary>
        private static string connString = "";

        /// <summary>
        /// Gets the cached connection.
        /// </summary>
        /// <returns></returns>
        private static IDbConnection GetCachedConnection() {
            if (conn == null) {
                if (String.IsNullOrEmpty(connString)) {
                    
                    switch (Database) {
                        case Databases.Access :
                            if (!File.Exists(DBTools.GetDatabaseFullFilename())) {
                                log.Error("GetCachedConnection: Databasefile: " + DBTools.GetDatabaseFullFilename() + "does not exist.");
                                throw new SPDException(null, "Databasefile:" + Environment.NewLine + DBTools.GetDatabaseFullFilename() + Environment.NewLine + "does not exist!", null);
                            }
                            FileAttributes fileAttributesMdb = File.GetAttributes(DBTools.GetDatabaseFullFilename());
                            if ((fileAttributesMdb & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) {
                                log.Error("GetCachedConnection: Databasefile: " + DBTools.GetDatabaseFullFilename() + " is Readonly.");
                                throw new SPDException(null, "Databasefile:" + Environment.NewLine + DBTools.GetDatabaseFullFilename() + Environment.NewLine + "is Readonly!", null);
                            }
                            connString = String.Format("Data Source={0};Provider=Microsoft.Jet.OLEDB.4.0;", DBTools.GetDatabaseFullFilename());
                            break;
                        case Databases.Access2007:
                            if (!File.Exists(DBTools.GetDatabaseFullFilename())) {
                                log.Error("GetCachedConnection: Databasefile: " + DBTools.GetDatabaseFullFilename() + "does not exist.");
                                throw new SPDException(null, "Databasefile:" + Environment.NewLine + DBTools.GetDatabaseFullFilename() + Environment.NewLine + "does not exist!", null);
                            }
                            FileAttributes fileAttributesAccb = File.GetAttributes(DBTools.GetDatabaseFullFilename());
                            if ((fileAttributesAccb & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) {
                                log.Error("GetCachedConnection: Databasefile: " + DBTools.GetDatabaseFullFilename() + " is Readonly.");
                                throw new SPDException(null, "Databasefile:" + Environment.NewLine + DBTools.GetDatabaseFullFilename() + Environment.NewLine + "is Readonly!", null);
                            }
                            connString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", DBTools.GetDatabaseFullFilename());
                            break;
                        case Databases.MySql :
                            connString = String.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};Port={4}",
                                                        SPD.DAL.Properties.Settings.Default.MySQLServer,
                                                        SPD.DAL.Properties.Settings.Default.MySQLDatabase,
                                                        SPD.DAL.Properties.Settings.Default.MySQLUser,
                                                        SPD.DAL.Properties.Settings.Default.MySQLPassword,
                                                        SPD.DAL.Properties.Settings.Default.MySQLPort);

                            break;
                        case Databases.PostgreSQL:
                            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                        SPD.DAL.Properties.Settings.Default.PostgreSQLServer,
                                                        SPD.DAL.Properties.Settings.Default.PostgreSQLPort,
                                                        SPD.DAL.Properties.Settings.Default.PostgreSQLUser,
                                                        SPD.DAL.Properties.Settings.Default.PostgreSQLPassword,
                                                        SPD.DAL.Properties.Settings.Default.PostgreSQLDatabase);
                            break;
                        default :
                            break;
                    }
                }
                switch (Database) {
                    case Databases.Access :
                    case Databases.Access2007:
                        conn = new OleDbConnection(connString);
                        break;
                    case Databases.MySql :
                        conn = new MySqlConnection(connString);
                        break;
                    case Databases.PostgreSQL:
                        conn = new NpgsqlConnection(connString);
                        break;
                    default:
                        break;
                }
            }

            log.Debug("GetCachedConnection: " + connString);

            return conn;
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        /// <returns></returns>
        public static IDbConnection OpenConnection() {
            IDbConnection conn = GetCachedConnection();
            if (conn.State != ConnectionState.Open) {
                try {
                    conn.Open();
                } catch (InvalidOperationException e)
                {
                    if (Database == Databases.Access2007)
                    {
                        throw new SPDException(e, "Error while opening Database Connection. Download and install the 32 bit Version of",
                                               @"https://www.microsoft.com/en-us/download/details.aspx?id=54920");
                    } else {
                        throw new SPDException(e, "Error while opening Database Connection.", null);
                    }


                }
                nestedOpens = 0;
            }

            nestedOpens++;

            log.Debug("OpenConnection - nestedOpens: " + nestedOpens);

            return conn;
        }

        /// <summary>
        /// Gets the current cached connection.
        /// </summary>
        /// <value>The current chached connection.</value>
        public static IDbConnection CurrentConnection {
            get {
                return conn;
            }
        }

        /// <summary>
        /// Decrements the connection Counter if no one is left close the connection.
        /// </summary>
        public static void CloseConnection() {
            if (--nestedOpens == 0) {
                conn.Close();
            }
            log.Debug("CloseConnection - nestedOpens: " + nestedOpens);
        }

        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="sqlStr">The SQL STR.</param>
        /// <param name="conn">The conn.</param>
        /// <returns></returns>
        public static IDbCommand CreateCommand(string sqlStr, IDbConnection conn) {
            IDbCommand cmd;
            switch (Database) {
                case Databases.Access :
                case Databases.Access2007:
                    cmd = new OleDbCommand(sqlStr);
                    break;
                case Databases.MySql :
                    cmd = conn.CreateCommand();
                    break;
                case Databases.PostgreSQL:
                    cmd = conn.CreateCommand();
                    break;
                default :
                    cmd = null;
                    break;
            }
            cmd.Connection = conn;
            cmd.CommandText = sqlStr;
            log.Debug("Create Command: " + sqlStr);
            return cmd;
        }

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="pName">Name of the Parameter</param>
        /// <param name="dbType">Type of the database-datatype</param>
        /// <returns></returns>
        public static IDbDataParameter CreateParameter(string pName, DbType dbType) {
            IDbDataParameter param;
            switch (Database) {
                case Databases.Access :
                case Databases.Access2007:
                    param = new OleDbParameter(pName, dbType);
                    break;
                case Databases.MySql:
                    MySqlDbType mysqldbtype;
                    switch (dbType) {
                        case DbType.Int64 :
                            mysqldbtype = MySqlDbType.Int64;
                            break;
                        case DbType.String:
                            mysqldbtype = MySqlDbType.Text;
                            break;
                        default:
                            //ulgy!!
                            mysqldbtype = MySqlDbType.Int64;
                            break;
                    }
                    param = new MySqlParameter(pName, mysqldbtype);
                    break;
                case Databases.PostgreSQL:
                    param = new NpgsqlParameter(pName, dbType);
                    break;
                default :
                    param = null;
                    break;
            }
            log.Debug("Create Parameter " + pName);
            return param;
        }

        /// <summary>
        /// Creates the adapter.
        /// </summary>
        /// <param name="selStr">The select string</param>
        /// <param name="conn">The connection</param>
        /// <returns></returns>
        public static DbDataAdapter CreateAdapter(string selStr,
                                                  IDbConnection conn) {
            DbDataAdapter adpt = new OleDbDataAdapter();
            adpt.SelectCommand = (DbCommand)CreateCommand(selStr, conn);
            log.Debug("Create Adapter: " + selStr);
            return adpt;
        }

        /// <summary>
        /// Creates the command builder.
        /// </summary>
        /// <param name="adpt">The adapter</param>
        /// <returns></returns>
        public static DbCommandBuilder CreateCommandBuilder(
                                         DbDataAdapter adpt) {
            DbCommandBuilder cmdBuilder = new OleDbCommandBuilder();
            cmdBuilder.DataAdapter = adpt;
            log.Debug("CreateCommandBuilder");
            return cmdBuilder;
        }

        /// <summary>
        /// Returns the last generated primary Key
        /// </summary>
        /// <param name="comm">the insert command</param>
        /// <param name="lastInsertedRowCmd"> the ole specific last inserted row command</param>
        /// <param name="insertRet"> the return of insertscecure scalar</param>
        /// <returns></returns>
        public static long getGeneratedId(IDbCommand comm, IDbCommand lastInsertedRowCmd, Object insertRet) {
            switch (Database) {
                case Databases.Access:
                case Databases.Access2007:
                    if (lastInsertedRowCmd == null) {
                        lastInsertedRowCmd = DbUtil.CreateCommand(SQL_LAST_INSERTED_ROW, DbUtil.CurrentConnection);
                    }
                    return Convert.ToInt64(lastInsertedRowCmd.ExecuteScalar());
                case Databases.MySql:
                    return ((MySqlCommand)comm).LastInsertedId;
                case Databases.PostgreSQL:
                    return (long) insertRet;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// returns is Backup is supported with DB engine
        /// </summary>
        /// <returns></returns>
        public static bool SupportsBackup() {
            switch (Database) {
                case Databases.Access:
                case Databases.Access2007:
                    return true;
                case Databases.MySql:
                case Databases.PostgreSQL:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// returnind insert Appendix
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static String GetAppendix(string id) {
            switch (Database) {
                case Databases.Access:
                case Databases.Access2007:
                case Databases.MySql:
                    return String.Empty;
                case Databases.PostgreSQL:
                    return " RETURNING " + id + " ";
                default:
                    return String.Empty;
            }
        }

    }
}
