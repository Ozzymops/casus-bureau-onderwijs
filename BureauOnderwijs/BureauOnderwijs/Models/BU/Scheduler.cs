using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BureauOnderwijs.Models.BU
{
    public class Scheduler : User   // inherit from User.cs
    {
        public int CheckScheduler(int UserID)
        //Functie die checkt of de ingelogde user een Admin is
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = ("SELECT Role FROM UserAccount WHERE UserId = " + UserID + "");

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                int UserRole = (int)cmd.ExecuteScalar();
                con.Close();

                if (UserRole == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 2;
            }
        }

        public string ConflictCheckClassroomEmpty()
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryclassroom = "SELECT COUNT (*) FROM Lecture WHERE 'Classroom' = ''";
            string rv = "";
            try
            {
                SqlConnection connetje = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQueryclassroom, connetje); 
                connetje.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rv = reader.GetInt32(0).ToString();
                }
                connetje.Close();
                return rv;
            }
            catch (Exception ex)
            {                
                return Convert.ToString(ex);
            }
        }

        public string ConflictCheckTeacherEmpty()
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryteacher = "SELECT COUNT (*) FROM Lecture WHERE 'Teacher' = ''";
            string rv = "";
            try
            {
                SqlConnection connetje = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQueryteacher, connetje);
                connetje.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rv = reader.GetInt32(0).ToString();
                }
                connetje.Close();
                return rv;
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex);
            }
        }

        public string ConflictCheckStudentgroupEmpty()
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuerystudentgroup = "SELECT COUNT (*) FROM Lecture WHERE 'Studentgroup' = ''";
            string rv = "";
            try
            {
                SqlConnection connetje = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuerystudentgroup, connetje);
                connetje.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rv = reader.GetInt32(0).ToString();
                }
                connetje.Close();
                return rv;
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex);
            }
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

        public List<Models.BU.Wish> GetTeacherWishes(int userId)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT * FROM Wish WHERE UserId = '" + userId + "'";
            return (db.GetTeacherWishes(query));
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

        public Models.BU.Module GetModuleByModuleCode(string moduleCode)
        {
            Models.Database db = new Models.Database();
            string query = "SELECT * FROM Module WHERE Code = '" + moduleCode + "'";
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