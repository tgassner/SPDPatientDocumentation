using System;
using System.Collections.Generic;
using System.Text;

namespace SPD.DAL {

    /// <summary>
    /// Enumeration for supported Databases
    /// </summary>
    public enum Databases {
        /// <summary>
        /// MS-Access (used as Database ;-)
        /// </summary>
        Access,
        /// <summary>
        /// MS-Access 2007
        /// </summary>
        Access2007,
        /// <summary>
        /// MySql Database
        /// </summary>
        MySql,
        /// <summary>
        /// PostgreSQL
        /// </summary>
        PostgreSQL,
        ///// <summary>
        ///// MS SQL Server
        ///// </summary>
        ////MsSQL,
        ///// <summary>
        ///// Oracle DB
        ///// </summary>
        ////Oracle,
        ///// <summary>
        ///// SQLite
        ///// </summary>
        ////SQLite,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    }
}
