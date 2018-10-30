using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace BureauOnderwijs.Models
{
    public class Database
    {
        protected SqlConnection conn;
        /// <summary>
        /// This method is used to setup the connection string which is used to connect to the database.
        /// Initialise this after log-in.
        /// </summary>
        /// <returns>connection string</returns>
        public SqlConnection Connect()
        {
            string connString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            conn = new SqlConnection(connString);
            return conn;
        }

        #region Get
        /// <summary>
        /// Return een boolean vanuit een enkel resultaat: zoek je op usernames? Return true wanneer er 1 username bestaat.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool ReturnBoolFromSingleResult(string query)
        {
            Connect();
            bool returnValue = false;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(0) != null)
                    {
                        returnValue = true;
                    }
                }
                conn.Dispose();
            }
            catch (Exception)
            {
                return false;
            }
            return returnValue;
        }

        /// <summary>
        /// Return een username op basis van userId.
        /// </summary>
        public string UserIdToUsername(string query)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return reader["Username"].ToString();
                }
                conn.Dispose();
            }
            catch (Exception)
            {
                return "fout";
            }
            return "leeg";
        }

        /// <summary>
        /// Return een userId op basis van username.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int UsernameToUserId(string query)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return Convert.ToInt32(reader["UserId"]);
                }
                conn.Dispose();
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// Return een lijst van Teachers
        /// </summary>
        public List<Models.BU.Teacher> GetTeacherList(string query)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<Models.BU.Teacher> teacherList = new List<Models.BU.Teacher>();
                while (reader.Read())
                {
                    Models.BU.Teacher tempTeacher = new Models.BU.Teacher(Convert.ToInt32(reader["UserId"]), reader["Username"].ToString(), reader["EmailAdress"].ToString(), reader["Firstname"].ToString(), reader["Lastname"].ToString());
                    teacherList.Add(tempTeacher);
                }
                return teacherList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Return één enkele Teacher.
        /// </summary>
        public Models.BU.Teacher GetSingleTeacher(string query)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Models.BU.Teacher singleTeacher = new Models.BU.Teacher(Convert.ToInt32(reader["UserId"]), reader["Username"].ToString(), reader["EmailAdress"].ToString(), reader["Firstname"].ToString(), reader["Lastname"].ToString());
                    return singleTeacher;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public Models.BU.Examiner GetSingleExaminer(string query)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Models.BU.Examiner singleExaminer = new Models.BU.Examiner(Convert.ToInt32(reader["UserId"]), reader["Username"].ToString(), reader["EmailAdress"].ToString(), reader["Firstname"].ToString(), reader["Lastname"].ToString());
                    return singleExaminer;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Return een lijst van Modules op basis van userId.
        /// </summary>
        public List<Models.BU.Module> GetModuleListOfTeacher(string query)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<Models.BU.Module> modulesList = new List<Models.BU.Module>();
                while (reader.Read())
                {
                    Models.BU.Module tempModule = new Models.BU.Module(Convert.ToInt32(reader["ModuleId"]), reader["Name"].ToString(), reader["Code"].ToString(), Convert.ToInt32(reader["Period"]), Convert.ToInt32(reader["Year"]), reader["Faculty"].ToString(), reader["Profile"].ToString(), Convert.ToInt32(reader["Credits"]), GetSingleExaminer("SELECT * FROM UserAccount WHERE Role = '2' AND UserId = '" + reader["ExaminerId"] + "'"), reader["Description"].ToString(), (bool)reader["GeneralModule"], Convert.ToInt32(reader["LectureHours"]), Convert.ToInt32(reader["PracticalHours"]));
                    modulesList.Add(tempModule);
                }
                return modulesList;
            }
            catch (Exception)
            {
               return null;
            }
        }

        /// <summary>
        /// Return één Module.
        /// </summary>
        public Models.BU.Module GetSingleModule(string query)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Models.BU.Module singleModule = new Models.BU.Module(Convert.ToInt32(reader["ModuleId"]), reader["Name"].ToString(), reader["Code"].ToString(), Convert.ToInt32(reader["Period"]), Convert.ToInt32(reader["Year"]), reader["Faculty"].ToString(), reader["Profile"].ToString(), Convert.ToInt32(reader["Credits"]), null, reader["Description"].ToString(), (bool)reader["GeneralModule"], Convert.ToInt32(reader["LectureHours"]), Convert.ToInt32(reader["PracticalHours"]));
                    return singleModule;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Return een lijst van beschikbare werkdagen.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<int> GetAvailableDays(string query)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<int> availableDayList = new List<int>();
                while (reader.Read())
                {
                    availableDayList.Add(Convert.ToInt32(reader["Day"]));
                }
                return availableDayList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Add

        #endregion

        #region Update
        // update functies: werk table bij
        public bool UpdatePassword(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}