using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Scheduler : User   // inherit from User.cs
    {
        public int ConflictCheck()
        {
            ///check 1 - leraar dubbel gepland:
            ///controleert of een leraar in 2 verschillende lokalen tegelijkertijd moet zijn.
            int i = 0;
            string conStringetje = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuerytje = "SELECT  FROM Lecture WHERE Day = 1 AND Week = 1 AND Period = 1";
            SqlDataReader datareader;

            try
            {
                SqlConnection connetje = new SqlConnection(conStringetje);
                SqlCommand cmdtje = new SqlCommand(sqlQuerytje, connetje);
                connetje.Open();
                datareader = cmdtje.ExecuteReader();
                while (datareader.Read())
                {
                    
                    i = 4;

                    return i;
                }
                connetje.Close();
                i = 2;
                return i;
            }
            catch
            {
                i = 2;
                return i;
            }
            
        }

        private void ShowEntry()
        {

        }

        private void AddEntry()
        {

        }

        private void EditEntry()
        {

        }

        private void GenerateClassSchedule()
        {

        }

        private void EnterClassScheduleData()
        {

        }

        private void ProcessClassScheduleData()
        {

        }

        private void ExportClassSchedule()
        {

        }

        private void NotifyScheduleConflict()
        {

        }

        public List<string> GetUsernameListRole(int role)
        {
            Models.Database db = new Models.Database();
            db.Connect();
            string query = "SELECT Username FROM UserAccount WHERE Role = " + role;
            return(db.GetUsernameListRole(query));
        }

        public List<int> GetDayListUserId (string username, string period, string week)
        {
            Models.Database db = new Models.Database();
            db.Connect();
            string query = "SELECT DISTINCT Day FROM Wish, UserAccount WHERE Wish.UserId = UserAccount.UserId AND UserAccount.Username = '" + username + "' AND Wish.Period LIKE '%" + period + "-%' AND Wish.Week = '" + week + "'";
            return (db.GetDayListUserId(query));
        }
        public List<int> GetModuleListUserId(string username)
        {
            Models.Database db = new Models.Database();
            db.Connect();
            string query = "SELECT mu.ModuleId FROM ModuleUser mu, UserAccount ua WHERE ua.Username = '" + username + "' AND ua.UserId = mu.UserId";
            return (db.GetModuleListUserId(query));
        }
        public string GetModuleCode(int module)
        {
            Models.Database db = new Models.Database();
            db.Connect();
            string query = "SELECT ModuleCode FROM Module WHERE ModuleId = '" + module + "'";
            return (db.GetModuleCode(query));
        }

        public bool CheckIfEntryExists(string[] entry)
        {
            Models.Database db = new Models.Database();
            db.Connect();
            // Construct query
            // { day, start, end, module, room, spot[0].ToString(), spot[1].ToString(), userList.SelectedValue}
            string query = "";
            return (db.ReturnBoolFromSingleResult(query));
        }
    }
}