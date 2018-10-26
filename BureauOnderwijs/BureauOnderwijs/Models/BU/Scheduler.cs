using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Scheduler : User   // inherit from User.cs
    {
        private void ShowEntry()
        {

        }

        public void AddEntry()
        {

        }

        public void EditEntry(string[] entry)
        {
            Models.Database db = new Models.Database();
            db.Connect();
            string idQuery = "SELECT UserId FROM UserAccount WHERE Username = '" + entry[9] + "'";
            int userId = db.ReturnUserIdFromUserName(idQuery);
            // Construct query
            // { day, start, end, module, room, spot[0].ToString(), spot[1].ToString(), period, week, userList.SelectedValue }
            // { 0    1      2    3       4     5                   6                   7       8     9                      }

            // Dag van string naar int omzetten want ik ben achterlijk en ik denk goed na
            int day = 0;
            if (entry[0] == "Maandag")
            {
                day = 1;
            }
            else if (entry[0] == "Dinsdag")
            {
                day = 2;
            }
            else if (entry[0] == "Woensdag")
            {
                day = 3;
            }
            else if (entry[0] == "Donderdag")
            {
                day = 4;
            }
            else if (entry[0] == "Vrijdag")
            {
                day = 5;
            }
            // get LectureId
            string lectureQuery = "SELECT LectureId FROM Lecture WHERE Classroom = '" + entry[4] +
                           "' AND Module = '" + entry[3] + "' AND StartTime = '" + entry[1] + "' AND EndTime = '" + entry[2] +
                           "' AND Day = '" + day.ToString() + "' AND Week = '" + entry[8] + "' AND Period = '" + entry[7] + "' AND Teacher = '" + userId + "'";
            db.Connect();
            int lectureId = db.GetLectureId(lectureQuery);
            // actual update
            string query = "UPDATE Lecture SET Classroom = '" + entry[4] +
                           "', Module = '" + entry[3] + "', StartTime = '" + entry[1] + "', EndTime = '" + entry[2] +
                           "', Day = '" + day.ToString() + "', Week = '" + entry[8] + "', Period = '" + entry[7] + "', Teacher = '" + userId + "' WHERE LectureId = '" + lectureId + "'";
            db.Connect();
            db.UpdateEntry(query);
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
            string idQuery = "SELECT UserId FROM UserAccount WHERE Username = '" + entry[9] + "'";
            int userId = db.ReturnUserIdFromUserName(idQuery);
            // Construct query
            // { day, start, end, module, room, spot[0].ToString(), spot[1].ToString(), period, week, userList.SelectedValue }
            // { 0    1      2    3       4     5                   6                   7       8     9                      }
            
            // Dag van string naar int omzetten want ik ben achterlijk en ik denk goed na
            int day = 0;
            if (entry[0] == "Maandag")
            {
                day = 1;
            }
            else if (entry[0] == "Dinsdag")
            {
                day = 2;
            }
            else if (entry[0] == "Woensdag")
            {
                day = 3;
            }
            else if (entry[0] == "Donderdag")
            {
                day = 4;
            }
            else if (entry[0] == "Vrijdag")
            {
                day = 5;
            }

            string query = "SELECT LectureId FROM Lecture WHERE Classroom = '" + entry[4] +  
                           "' AND Module = '" + entry[3] + "' AND StartTime = '" + entry[1] + "' AND EndTime = '" + entry[2] + 
                           "' AND Day = '" + day.ToString() + "' AND Week = '" + entry[8] + "' AND Period = '" + entry[7] + "' AND Teacher = '" + userId + "'";
            Debug.WriteLine(query);
            db.Connect();
            return (db.ReturnBoolFromInt(query));
        }
    }
}