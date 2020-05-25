

using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


//Open connection with local sqlite database
namespace Assets.Scripts.ScriptsMenu.Persist
{
    class DBConnector
    {

        private SqliteConnection connect;

        /// <summary>
        /// Open connection with local database
        /// </summary>
        /// <returns>connection to the database</returns>
        public SqliteConnection OpenConnection()
        {
            connect = new SqliteConnection("URI=file:" + Application.dataPath + "/Resources/DB/InnocenceLocal.db");
            return connect;
        }

    }
}
