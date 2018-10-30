using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Scheduler : User   // inherit from User.cs
    {
        public string ConflictCheck()
        {
            return "iets2";
        }

        public string UserIdToUsername(int userId)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT Username FROM UserAccount WHERE UserId = '" + userId + "'";
            return (db.UserIdToUsername(query));
        }

        public int UsernameToUserId(string username)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT UserId FROM UserAccount WHERE Username = '" + username + "'";
            return (db.UsernameToUserId(query));
        }

        public List<Models.BU.Teacher> GetTeacherList()
        {
            Models.Database db = new Models.Database();
            string query = "SELECT * FROM UserAccount WHERE Role = '3'";
            return(db.GetTeacherList(query));
        }

        public Models.BU.Teacher GetSingleTeacher(int userId)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT * FROM UserAccount WHERE Role = '3' AND UserId = '" + userId + "'";
            return (db.GetSingleTeacher(query));
        }

        public List<Models.BU.Module> GetModuleListOfTeacher(int userId)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT DISTINCT m.* FROM Module m, ModuleUser mu, UserAccount ua WHERE ua.UserId = mu.UserId AND mu.ModuleId = m.ModuleId AND ua.UserId = '" + userId + "'";
            return (db.GetModuleListOfTeacher(query));
        }

        public Models.BU.Module GetSingleModule(int moduleId)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT * FROM Module WHERE ModuleId = '" + moduleId + "'";
            return (db.GetSingleModule(query));
        }

        public List<int> GetAvailableDays(int userId, int period, int week)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT DISTINCT Day FROM Wish WHERE UserId = '" + userId + "' AND Period = '" + period + "' AND Week = '" + week + "'";
            return (db.GetAvailableDays(query));
        }
    }
}