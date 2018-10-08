using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models
{
    public class Database
    {
        // Zie Wesley code

        protected SqlConnection conn;
        /// <summary>
        /// This method is used to setup the connection string which is used to connect to the database.
        /// Initialise this after log-in.
        /// </summary>
        /// <returns>connection string</returns>
        public SqlConnection Connect()
        {
            string connString = @"Data Source=moodlestudiepad.database.windows.net;" +
                                 "Initial Catalog=MoodleStudiepad;" + "User id=moodleadmin;" +
                                 "Password=#studiepad01;"; // edit to new Azure db !!!
            conn = new SqlConnection(connString);
            return conn;
        }


        #region Get
        // get functies: lees uit een table
        // create things via queries and send them back to the requester.
        #endregion

        #region Add
        // add functies: voeg toe aan een table
        #endregion

        #region Update
        // update functies: werk table bij
        #endregion

        #region Delete
        // delete functies: verwijder data uit een table
        // DROP NOOIT EEN TABLE! Hiermee verlies je ALLE data!
        #endregion
    }
}