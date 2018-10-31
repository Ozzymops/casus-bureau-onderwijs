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

        public void CreateEntry(Models.BU.Lecture lecture)
        {
            Models.Database db = new Models.Database();
            string query = "INSERT INTO Lecture(TeacherId, ModuleCode, Classroom, StudentGroup, Period, Week, Day, StartHour, StartMinute, EndHour, EndMinute) " +
                "VALUES ('" + lecture.teacher.UserID + "', '" + lecture.module.moduleCode + "', '" + lecture.classroom + "', '" + lecture.studentGroup + "', '" + lecture.period + "', " +
                "'" + lecture.week + "', '" + lecture.day + "', '" + lecture.startHour + "', '" + lecture.startMinute + "', '" + lecture.endHour + "', '" + lecture.endMinute + "')";
            db.CreateEntry(query);
        }

        public void UpdateEntry(Models.BU.Lecture lecture, int lectureId)
        {
            Models.Database db = new Models.Database();
            string query = "UPDATE Lecture SET ModuleCode = '" + lecture.module.moduleCode + "', Classroom = '" + lecture.classroom + "', " +
                "StudentGroup = '" + lecture.studentGroup + "' WHERE LectureId = '" + lectureId + "'";
            db.UpdateEntry(query);
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
            List<Models.BU.Teacher> teacherList = db.GetTeacherList(query);
            // Vul wishList van Teachers
            foreach (Models.BU.Teacher teacher in teacherList)
            {
                query = "SELECT DISTINCT * FROM Wish WHERE UserId = '" + teacher.UserID + "'";
                teacher.wishList = db.GetWishListOfTeacher(query);
            }
            return teacherList;
        }

        public Models.BU.Teacher GetSingleTeacher(int userId)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT * FROM UserAccount WHERE Role = '3' AND UserId = '" + userId + "'";
            return (db.GetSingleTeacher(query));
        }

        public List<Models.BU.Lecture> GetLecturesOfTeacher(int userId)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT * FROM Lecture WHERE TeacherId = '" + userId + "'";
            return (db.GetLecturesOfTeacher(query, userId));
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

        public int CheckIfLectureAlreadyExists(Models.BU.Lecture lecture)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT LectureId FROM Lecture WHERE TeacherId = '" + lecture.teacher.UserID + "' AND Period = '" + lecture.period + "' AND Week = '" + lecture.week + "'" +
                           "AND Day = '" + lecture.day + "' AND StartHour = '" + lecture.startHour + "' AND StartMinute = '" + lecture.startMinute + "'" +
                           "AND EndHour = '" + lecture.endHour + "' AND EndMinute = '" + lecture.endMinute + "'";
            return (db.CheckIfLectureAlreadyExists(query));
        }
    }
}