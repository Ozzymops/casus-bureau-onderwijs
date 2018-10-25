using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Scheduler : User   // inherit from User.cs
    {
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

        public List<int> GetDayListUserId (string username)
        {
            Models.Database db = new Models.Database();
            db.Connect();
            string query = "SELECT DISTINCT Day FROM Wish, UserAccount WHERE Wish.UserId = UserAccount.UserId AND UserAccount.Username = '" + username + "'";
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
    }
}