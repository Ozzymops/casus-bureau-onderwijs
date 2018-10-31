using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace BureauOnderwijs.Views
{
    public partial class Roosteroverzicht : System.Web.UI.Page
    {
        /// Te doen:
        /// - Leg verantwoordelijkheden correct vast:           [ ]
        ///   Dit betekent: alles wat met Teacher heeft te maken
        ///   gaat in Teacher.cs staan.
        /// - Maak van herhalende stukken code methoden.        [ ]
        /// - Geef logische namen aan variabelen/methoden.      [ ]
        /// - Try/catch overal wanneer toepasbaar               [ ]
        /// - Maak de code schoon                               [ ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (gr_schedule.Rows.Count == 0)
            {
                GenerateTable();
                FillStaticLists();
            }
            FillDynamicLists();
            PasteData();
            Session["FirstTimeSchedule"] = false;
        }

        #region Functions
        /// <summary>
        /// Genereert een tabel in de gridview.
        /// </summary>
        private void GenerateTable()
        {
            // Maak nieuwe datatable voor tijdelijke opslag van columns / rows
            DataTable dt = new DataTable();

            // Plaats columns (als deze nog niet bestaan)
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Tijd", typeof(string));
                dt.Columns.Add("Maandag", typeof(string));
                dt.Columns.Add("Dinsdag", typeof(string));
                dt.Columns.Add("Woensdag", typeof(string));
                dt.Columns.Add("Donderdag", typeof(string));
                dt.Columns.Add("Vrijdag", typeof(string));
            }

            // Plaats rows via een for loop
            int hour = 9;
            bool halfHour = false;
            for (int i = 0; i < 19; i++)
            {
                DataRow dr = dt.NewRow();
                if (hour == 9) // eenmalig voor invoeging 09
                {
                    if (halfHour)
                    {
                        dr["Tijd"] = "09:30";
                        hour++;
                    }
                    else
                    {
                        dr["Tijd"] = "09:00";
                    }
                }
                else
                {
                    if (halfHour) // :30
                    {
                        dr["Tijd"] = string.Format("{0}:30", hour);
                        hour++;
                    }
                    else          // :00
                    {
                        dr["Tijd"] = string.Format("{0}:00", hour);
                    }
                }
                halfHour = !halfHour;
                dt.Rows.Add(dr);
            }

            // Bind nieuwe data aan gridview
            gr_schedule.DataSource = dt;
            gr_schedule.DataBind();
        }

        /// <summary>
        /// Genereer een Lecture voor gebruik in de tabel en om op te slaan naar de database.
        /// </summary>
        private void GenerateLecture()
        {
            List<Models.BU.Lecture> currentChangeList = (List<Models.BU.Lecture>)Session["ScheduleChangeList"];
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            Models.BU.Lecture newLecture = new Models.BU.Lecture(
                sgd.GetSingleTeacher(Convert.ToInt32(userList.SelectedValue)), sgd.GetSingleModule(Convert.ToInt32(moduleList.SelectedValue)), roomTextBox.Text, groupTextBox.Text,
                Convert.ToInt32(periodList.SelectedValue), Convert.ToInt32(weekList.SelectedValue), DayStringToInt(dayList.SelectedValue), 9, 0, 10, 0);
            currentChangeList.Add(newLecture);
            Session["ScheduleChangeList"] = currentChangeList;

            // Direct refreshen
            PasteData();
        }

        /// <summary>
        /// Plak data vanuit de huidige sessie en de database in de tabel.
        /// </summary>
        private void PasteData()
        {
            // Reset tabel
            gr_schedule.DataSource = null;
            gr_schedule.DataBind();
            GenerateTable();

            // Vanuit database
            List<Models.BU.Lecture> retrievedData = RetrieveData();
            if (retrievedData.Count != 0)
            {
                foreach (Models.BU.Lecture lecture in retrievedData)
                {
                    if (Convert.ToInt32(userList.SelectedValue) == lecture.teacher.userId && (Convert.ToInt32(periodList.SelectedValue) == lecture.period && Convert.ToInt32(weekList.SelectedValue) == lecture.week))
                    {
                        int[] cell = DetermineCell(lecture.day, lecture.startHour, lecture.startMinute);
                        // string: Dag: Start - Eind. Vak, Groep. Lokaal.
                        string entry = String.Format("{0}: {1} - {2}. {3}, {4}. {5}.", DayIntToString(lecture.day), TimeToString(lecture.startHour, lecture.startMinute), TimeToString(lecture.endHour, lecture.endMinute), lecture.module.name, lecture.studentGroup, lecture.classroom);
                        gr_schedule.Rows[cell[0]].Cells[cell[1]].Text = entry;
                    }
                }
            }

            // Vanuit Session
            List<Models.BU.Lecture> currentChangeList = (List<Models.BU.Lecture>)Session["ScheduleChangeList"];
            if (currentChangeList.Count != 0)
            {
                foreach (Models.BU.Lecture lecture in currentChangeList)
                {
                    if (Convert.ToInt32(userList.SelectedValue) == lecture.teacher.userId && (Convert.ToInt32(periodList.SelectedValue) == lecture.period && Convert.ToInt32(weekList.SelectedValue) == lecture.week))
                    {
                        int[] cell = DetermineCell(lecture.day, lecture.startHour, lecture.startMinute);
                        // string: Dag: Start - Eind. Vak, Groep. Lokaal.
                        string entry = String.Format("{0}: {1} - {2}. {3}, {4}. {5}.", DayIntToString(lecture.day), TimeToString(lecture.startHour, lecture.startMinute), TimeToString(lecture.endHour, lecture.endMinute), lecture.module.name, lecture.studentGroup, lecture.classroom);
                        gr_schedule.Rows[cell[0]].Cells[cell[1]].Text = entry;
                    }
                }
            }
        }

        /// <summary>
        /// Sla data op naar de database.
        /// </summary>
        private void SaveData()
        {
            List<Models.BU.Lecture> currentChangeList = (List<Models.BU.Lecture>)Session["ScheduleChangeList"];
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            Models.CC.Scheduler_UpdateEntry sue = new Models.CC.Scheduler_UpdateEntry();
            Models.CC.Scheduler_CreateEntry sce = new Models.CC.Scheduler_CreateEntry();
            foreach (Models.BU.Lecture lecture in currentChangeList)
            {
                int lectureId = sgd.CheckIfLectureAlreadyExists(lecture);
                if (lectureId != -1) // update
                {
                    sue.UpdateEntry(lecture, lectureId);
                }
                else                 // create
                {
                    sce.CreateEntry(lecture);
                }
            }
            
            // Reset changelist            
            currentChangeList.Clear();
            Session["ScheduleChangeList"] = currentChangeList;

            // Direct refreshen
            PasteData();
        }

        /// <summary>
        /// Haal data op vanuit de database.
        /// </summary>
        private List<Models.BU.Lecture> RetrieveData()
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            List<Models.BU.Lecture> retrievedData = sgd.GetLecturesOfTeacher(Convert.ToInt32(userList.SelectedValue));
            return retrievedData;
        }

        /// <summary>
        /// Vul DropDownLists userList, periodList en weekList. Deze zijn statisch en altijd hetzelfde.
        /// </summary>
        private void FillStaticLists()
        {
            // Vul userList
            if (userList.Items != null)
            {
                Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
                List<Models.BU.Teacher> teacherList = sgd.GetTeacherList();
                userList.DataSource = teacherList;
                userList.DataValueField = "userId";
                userList.DataTextField = "username";
                userList.DataBind();
                Session["TempTeacherList"] = teacherList;
                Session["CurrentUser"] = teacherList[0].username;
            }

            // Vul periodList
            for (int i = 1; i < 5; i++)
            {
                periodList.Items.Add(i.ToString());
            }

            // Vul weekList
            for (int i = 1; i < 11; i++)
            {
                weekList.Items.Add(i.ToString());
            }

            Session["CurrentPeriod"] = "1";
            Session["CurrentWeek"] = "1";
        }

        /// <summary>
        /// Vul DropDownLists dayList en moduleList.
        /// </summary>
        private void FillDynamicLists()
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();

            // Vul dayList
            if ((bool)Session["FirstTimeSchedule"] || userList.SelectedValue != Session["CurrentUser"].ToString() || periodList.SelectedValue != Session["CurrentPeriod"].ToString() || weekList.SelectedValue != Session["CurrentWeek"].ToString())
            {
                dayList.Items.Clear();
                List<int> availableDayList = sgd.GetAvailableDays(Convert.ToInt32(userList.SelectedValue), Convert.ToInt32(periodList.SelectedValue), Convert.ToInt32(weekList.SelectedValue));
                if (availableDayList.Count != 0)
                {
                    foreach (int day in availableDayList)
                    {
                        dayList.Items.Add(DayIntToString(day));
                    }
                }
            }

            // Vul moduleList
            if ((bool)Session["FirstTimeSchedule"] || userList.SelectedValue != Session["CurrentUser"].ToString())
            {
                moduleList.Items.Clear();
                List<Models.BU.Module> modulesList = sgd.GetModuleListOfTeacher(Convert.ToInt32(userList.SelectedValue));
                moduleList.DataSource = modulesList;
                moduleList.DataValueField = "ModuleId";
                moduleList.DataTextField = "ModuleCode";
                moduleList.DataBind();
                Session["TempModuleList"] = modulesList;
            }

            // Vul wishList

            // Zet Session variabelen
            Session["CurrentUser"] = userList.SelectedValue;
            Session["CurrentPeriod"] = periodList.SelectedValue;
            Session["CurrentWeek"] = weekList.SelectedValue;
        }

        /// <summary>
        /// Converteer een tijdstip / dag om naar bruikbare column / row combinatie.
        /// </summary>
        private int[] DetermineCell(int day, int startHour, int startMinute)
        {
            int row = -1;
            int col = day;

            // Bepaal row
            switch (startHour)
            {
                case 9:
                    row = 0;
                    break;
                case 10:
                    row = 2;
                    break;
                case 11:
                    row = 4;
                    break;
                case 12:
                    row = 6;
                    break;
                case 13:
                    row = 8;
                    break;
                case 14:
                    row = 10;
                    break;
                case 15:
                    row = 12;
                    break;
                case 16:
                    row = 14;
                    break;
                case 17:
                    row = 16;
                    break;
                case 18:
                    row = 18;
                    break;
            }

            if (startMinute == 30 && startHour != 18)
            {
                row += 1;
            }
            return new int[] { row, col };
        }

        /// <summary>
        /// Converteer een dag (string) naar int.
        /// </summary>
        public int DayStringToInt(string day)
        {
            if (day == "Maandag")
            {
                return 1;
            }
            else if (day == "Dinsdag")
            {
                return 2;
            }
            else if (day == "Woensdag")
            {
                return 3;
            }
            else if (day == "Donderdag")
            {
                return 4;
            }
            else if (day == "Vrijdag")
            {
                return 5;
            }
            return 0;
        }

        /// <summary>
        /// Converteer een dag (int) naar string.
        /// </summary>
        public string DayIntToString(int day)
        {
            if (day == 1)
            {
                return "Maandag";
            }
            else if (day == 2)
            {
                return "Dinsdag";
            }
            else if (day == 3)
            {
                return "Woensdag";
            }
            else if (day == 4)
            {
                return "Donderdag";
            }
            else if (day == 5)
            {
                return "Vrijdag";
            }
            return "leeg";
        }

        /// <summary>
        /// Converteer een userId naar username.
        /// </summary>
        public string UserIdToUsername(int userId)
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            return(sgd.UserIdToUsername(userId));
        }

        /// <summary>
        /// Converteer een username naar userId.
        /// </summary>
        public int UsernameToUserId(string username)
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            return (sgd.UsernameToUserId(username));
        }

        /// <summary>
        /// Converteer een uur en minuut waarde naar één string.
        /// </summary>
        public string TimeToString(int hour, int minute)
        {
            if (hour == 9)
            {
                if (minute == 0)
                {
                    return (String.Format("0{0}:{1}0", hour, minute));
                }
                else
                {
                    return (String.Format("0{0}:{1}", hour, minute));
                }

            }
            else
            {
                if (minute == 0)
                {
                    return (String.Format("{0}:{1}0", hour, minute));
                }
                else
                {
                    return (String.Format("{0}:{1}", hour, minute));
                }         
            }
        }
        #endregion

        #region Buttons
        protected void addButton_Click(object sender, EventArgs e)
        {
            GenerateLecture();
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {

        }
        protected void userList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void ButtonFoutControle_Click(object sender, EventArgs e)
        {
            Models.CC.Scheduler_ShowConflicts ssc = new Models.CC.Scheduler_ShowConflicts();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Hier komt te staan of er fouten zijn aangetroffen de ja of de nee.');", true);
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}