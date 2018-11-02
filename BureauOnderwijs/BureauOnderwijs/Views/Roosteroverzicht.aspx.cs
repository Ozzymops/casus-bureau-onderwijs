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
            ChangeVisibleControlPanel();
            FillDynamicLists();
            //PasteData();
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
                sgd.GetSingleTeacher(Convert.ToInt32(UserDropdownList.SelectedValue)), sgd.GetSingleModule(Convert.ToInt32(ModuleDropdownList.SelectedValue)), ClassroomTextBox.Text, StudentGroupTextBox.Text,
                Convert.ToInt32(PeriodDropdownList.SelectedValue), Convert.ToInt32(WeekDropdownList.SelectedValue), DayStringToInt(DayDropdownList.SelectedValue), Convert.ToInt32(TimeStartHourTextBox.Text), 
                Convert.ToInt32(TimeStartMinuteTextBox.Text), Convert.ToInt32(TimeEndHourTextBox.Text), Convert.ToInt32(TimeEndMinuteTextBox.Text));
            currentChangeList.Add(newLecture);
            Session["ScheduleChangeList"] = currentChangeList;

            // Direct refreshen
            SaveData();
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
            LectureGridView.DataSource = null;
            LectureGridView.DataBind();
            GenerateTable();

            // Maak een tabel voor de LectureGridView
            DataTable dt2 = new DataTable();
            if (dt2.Columns.Count == 0)
            {
                dt2.Columns.Add("LesId", typeof(int));
                dt2.Columns.Add("DocentId", typeof(int));
                dt2.Columns.Add("Module", typeof(string));
                dt2.Columns.Add("Lokaal", typeof(string));
                dt2.Columns.Add("Groep", typeof(string));
                dt2.Columns.Add("Blok", typeof(int));
                dt2.Columns.Add("Week", typeof(int));
                dt2.Columns.Add("Dag", typeof(int));
                dt2.Columns.Add("Start [H]", typeof(int));
                dt2.Columns.Add("Start [M]", typeof(int));
                dt2.Columns.Add("Eind [H]", typeof(int));
                dt2.Columns.Add("Eind [M]", typeof(int));
            }

            int lectureId = 1;
            // Vanuit database
            List<Models.BU.Lecture> retrievedData = RetrieveData();
            if (retrievedData.Count != 0)
            {
                foreach (Models.BU.Lecture lecture in retrievedData)
                {
                    if (Convert.ToInt32(UserDropdownList.SelectedValue) == lecture.teacher.UserID && (Convert.ToInt32(PeriodDropdownList.SelectedValue) == lecture.period && Convert.ToInt32(WeekDropdownList.SelectedValue) == lecture.week))
                    {
                        int[] cell = DetermineCell(lecture.day, lecture.startHour, lecture.startMinute);
                        string entry = ConstructScheduleString(lecture.day, new int[] { lecture.startHour, lecture.startMinute }, new int[] { lecture.endHour, lecture.endMinute }, lecture.module.name, lecture.studentGroup, lecture.classroom);
                        gr_schedule.Rows[cell[0]].Cells[cell[1]].Text = entry;

                        // Vul LectureGridView
                        DataRow dr2 = dt2.NewRow();
                        dr2["LesId"] = lectureId;
                        dr2["DocentId"] = lecture.teacher.UserID;
                        dr2["Module"] = lecture.module.moduleCode;
                        dr2["Lokaal"] = lecture.classroom;
                        dr2["Groep"] = lecture.studentGroup;
                        dr2["Blok"] = lecture.period;
                        dr2["Week"] = lecture.week;
                        dr2["Dag"] = lecture.day;
                        dr2["Start [H]"] = lecture.startHour;
                        dr2["Start [M]"] = lecture.startMinute;
                        dr2["Eind [H]"] = lecture.endHour;
                        dr2["Eind [M]"] = lecture.endMinute;
                        dt2.Rows.Add(dr2);
                        lectureId++;
                    }
                }
            }

            LectureGridView.DataSource = dt2;
            LectureGridView.DataBind();
            if (LectureGridView.Rows.Count == 0)
            {
                LectureLabel.Text = "Lectures = null. Geen resultaten.";
            }
            else
            {
                LectureLabel.Text = "Lectures van " + UserIdToUsername(Convert.ToInt32(UserDropdownList.SelectedValue));
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
            List<Models.BU.Lecture> retrievedData = sgd.GetLecturesOfTeacher(Convert.ToInt32(UserDropdownList.SelectedValue));
            return retrievedData;
        }

        /// <summary>
        /// Vul DropDownLists userList, periodList en weekList. Deze zijn statisch en altijd hetzelfde.
        /// </summary>
        private void FillStaticLists()
        {
            // Vul userList
            if (UserDropdownList.Items != null)
            {
                Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
                List<Models.BU.Teacher> teacherList = sgd.GetTeacherList();
                UserDropdownList.DataSource = teacherList;
                UserDropdownList.DataValueField = "userId";
                UserDropdownList.DataTextField = "username";
                UserDropdownList.DataBind();
                Session["TempTeacherList"] = teacherList;
                Session["CurrentUser"] = teacherList[0].UserName;
                Debug.WriteLine("UserList succes.");
            }

            // Vul periodList
            for (int i = 1; i < 5; i++)
            {
                PeriodDropdownList.Items.Add(i.ToString());
            }

            // Vul weekList
            for (int i = 1; i < 11; i++)
            {
                WeekDropdownList.Items.Add(i.ToString());
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

            // Get dayList op basis van userId, wordt eenmalig opgehaald.
            if ((bool)Session["FirstTimeSchedule"] || UserDropdownList.SelectedValue != Session["CurrentUser"].ToString())
            {
                List<Models.BU.Wish> teacherWishList = sgd.GetTeacherWishes(Convert.ToInt32(UserDropdownList.SelectedValue));
                Session["TeacherWishList"] = teacherWishList;
                Debug.WriteLine("DayList filled.");
            }

            // Pas dayList aan op basis van periode / week.
            if ((bool)Session["FirstTimeSchedule"] || PeriodDropdownList.SelectedValue != Session["CurrentPeriod"].ToString() || WeekDropdownList.SelectedValue != Session["CurrentWeek"].ToString())
            {
                DayDropdownList.Items.Clear();
                List<Models.BU.Wish> teacherWishList = (List<Models.BU.Wish>)Session["TeacherWishList"];
                if (teacherWishList.Count != 0)
                {
                    foreach (Models.BU.Wish wish in teacherWishList)
                    {
                        if (wish.period == Convert.ToInt32(PeriodDropdownList.SelectedValue) && wish.week == Convert.ToInt32(WeekDropdownList.SelectedValue))
                        {
                            if (DayDropdownList.Items.FindByText(DayIntToString(wish.day)) == null)
                            {
                                DayDropdownList.Items.Add(DayIntToString(wish.day));
                                Debug.WriteLine("DayList changed.");
                            }
                        }
                    }
                }               
            }
            
            // Vul moduleList
            //if ((bool)Session["FirstTimeSchedule"] || UserDropdownList.SelectedValue != Session["CurrentUser"].ToString())
            //{
            //    ModuleDropdownList.Items.Clear();
            //    List<Models.BU.Module> modulesList = sgd.GetModuleListOfTeacher(Convert.ToInt32(UserDropdownList.SelectedValue));
            //    ModuleDropdownList.DataSource = modulesList;
            //    ModuleDropdownList.DataValueField = "ModuleId";
            //    ModuleDropdownList.DataTextField = "ModuleCode";
            //    ModuleDropdownList.DataBind();
            //    Session["TempModuleList"] = modulesList;
            //    Debug.WriteLine("ModuleList succes.");
            //}

            // Zet Session variabelen
            Session["CurrentUser"] = UserDropdownList.SelectedValue;
            Session["CurrentPeriod"] = PeriodDropdownList.SelectedValue;
            Session["CurrentWeek"] = WeekDropdownList.SelectedValue;
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

        /// <summary>
        /// Vorm een entry string voor de Schedule samen.
        /// </summary>
        public string ConstructScheduleString(int day, int[] startTime, int[] endTime, string modulename, string studentgroup, string classroom)
        {
            // [Dag: Start - Eind. Vak, Groep. Lokaal.]
            string entry = String.Format("{0}: {1} - {2}. {3}, {4}. {5}.", DayIntToString(day), TimeToString(startTime[0], startTime[1]), TimeToString(endTime[0], endTime[1]), modulename, studentgroup, classroom);
            return entry;
        }

        /// <summary>
        /// Verander de huidig zichtbare controle paneel.
        /// </summary>
        public void ChangeVisibleControlPanel()
        {
            if ((int)Session["ControlPanel"] == 0)
            {
                add_controls.Visible = true;
                edit_controls.Visible = false;
                remove_controls.Visible = false;
            }
            else if ((int)Session["ControlPanel"] == 1)
            {
                add_controls.Visible = false;
                edit_controls.Visible = true;
                remove_controls.Visible = false;
            }
            else if ((int)Session["ControlPanel"] == 2)
            {
                add_controls.Visible = false;
                edit_controls.Visible = false;
                remove_controls.Visible = true;
            }
        }
        #endregion

        #region Buttons
        protected void AddButton_Click(object sender, EventArgs e)
        {
            GenerateLecture();
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {

        }
        protected void userList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonFoutControle_Click(object sender, EventArgs e)
        {
            Models.CC.Scheduler_ShowConflicts ssc = new Models.CC.Scheduler_ShowConflicts();
            string returnvalue = ssc.Conflicts();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Aantal Lessen zonder toegewezen lokaal: '" + returnvalue +"'');", true);
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {

        }

        protected void PanelDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ControlPanel"] = Convert.ToInt32(PanelDropdownList.SelectedValue);
            ChangeVisibleControlPanel();
        }
        #endregion
    }
}