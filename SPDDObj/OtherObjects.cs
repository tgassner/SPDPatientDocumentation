using System;
using System.Collections.Generic;
using System.Text;
using SPD.DAL;

namespace SPD.OtherObjects {

    /// <summary>
    /// ServiceType local or Remote
    /// </summary>
    public enum ServiceType {
        /// <summary>
        /// Local Servicetype
        /// </summary>
        local,
        /// <summary>
        /// Remote WCF Servicetype
        /// </summary>
        WCF
    }

    /// <summary>
    /// Protokolls http, tcp, or namedPipe
    /// </summary>
    public enum WCFProtocol {
        /// <summary>
        /// http transmission
        /// </summary>
        http,
        /// <summary>
        /// tcp transmission
        /// </summary>
        tcp,
        /// <summary>
        /// namedPipe transmission
        /// </summary>
        namedPipe
    }

    /// <summary>
    /// encapsulates the Endpoint Data
    /// </summary>
    public struct EndpointData {

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointData"/> struct.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="protocol">The protocol.</param>
        public EndpointData(string host, uint port, WCFProtocol protocol) {
            this.Host = host;
            this.port = port;
            this.Protocol = protocol;
        }

        /// <summary>
        /// Endpoint host
        /// </summary>
        public string Host;
        /// <summary>
        /// Endpoint port
        /// </summary>
        public uint port;
        /// <summary>
        /// Endpoint protocol
        /// </summary>
        public WCFProtocol Protocol;
        
    }

    /// <summary>
    /// Database Settings Object
    /// </summary>
    public class DatabaseSettings {
        private Databases database;
        private String mySQLServer;
        private String mySQLDatabase;
        private String mySQLUser;
        private String mySQLPassword;
        private String mySQLPort;
        private String postgreSQLServer;
        private String postgreSQLPort;
        private String postgreSQLUser;
        private String postgreSQLPassword;
        private String postgreSQLDatabase;
        private String accessFile;
        private String access2007File;

        /// <summary>
        /// Database
        /// </summary>
        public Databases Database {
            get { return this.database; }
            set { this.database = value; }
        }

        /// <summary>
        /// MysqlServer
        /// </summary>
        public string MySQLServer {
            get { return this.mySQLServer; }
            set { this.mySQLServer = value; }
        }

        /// <summary>
        /// MySQL Database
        /// </summary>
        public string MySQLDatabase {
            get { return this.mySQLDatabase; }
            set { this.mySQLDatabase = value; }
        }

        /// <summary>
        /// MySql User
        /// </summary>
        public string MySQLUser {
            get { return this.mySQLUser; }
            set { this.mySQLUser = value; }
        }

        /// <summary>
        /// MySqL password
        /// </summary>
        public string MySQLPassword {
            get { return this.mySQLPassword; }
            set { this.mySQLPassword = value; }
        }

        /// <summary>
        /// MySQL Port
        /// </summary>
        public string MySQLPort {
            get { return this.mySQLPort; }
            set { this.mySQLPort = value; }
        }

        /// <summary>
        /// PostgreSQL Server
        /// </summary>
        public string PostgreSQLServer {
            get { return this.postgreSQLServer; }
            set { this.postgreSQLServer = value; }
        }

        /// <summary>
        /// PostgreSQL Port
        /// </summary>
        public string PostgreSQLPort {
            get { return this.postgreSQLPort; }
            set { this.postgreSQLPort = value; }
        }

        /// <summary>
        /// User
        /// </summary>
        public string PostgreSQLUser {
            get { return this.postgreSQLUser; }
            set { this.postgreSQLUser = value; }
        }

        /// <summary>
        /// PostgreSQL Password
        /// </summary>
        public string PostgreSQLPassword {
            get { return this.postgreSQLPassword; }
            set { this.postgreSQLPassword = value; }
        }

        /// <summary>
        /// PostgreSQL Database
        /// </summary>
        public string PostgreSQLDatabase {
            get { return this.postgreSQLDatabase; }
            set { this.postgreSQLDatabase = value; }
        }

        /// <summary>
        /// AccessFile
        /// </summary>
        public string AccessFile {
            get { return this.accessFile; }
            set { this.accessFile = value; }
        }

        /// <summary>
        /// Access 2007 File
        /// </summary>
        public string Access2007File {
            get { return this.access2007File; }
            set { this.access2007File = value; }
        }

    }
}
