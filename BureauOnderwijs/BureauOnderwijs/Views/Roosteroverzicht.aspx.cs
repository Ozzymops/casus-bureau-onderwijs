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
        /// Vul DropDownLists userList, periodList en weekList. Deze zijn statisch en altijd hetzelfde.
        /// </summary>
        private void FillStaticLists()
        {
            // Vul userList
            if (userList.Items != null)
            {
                Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
                List<Models.BU.Teacher> teacherList = sgd.GetTeacherList();
                foreach (Models.BU.Teacher teacher in teacherList)
                {
                    userList.Items.Add(teacher.username);
                }
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
        }

        /// <summary>
        /// Vul DropDownLists dayList en moduleList.
        /// </summary>
        private void FillDynamicLists()
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            
            // Vul dayList
            if ((bool)Session["FirstTimeSchedule"] || userList.SelectedValue != Session["CurrentUser"].ToString())
            {
                dayList.Items.Clear();
                List<int> availableDayList = sgd.GetAvailableDays(UsernameToUserId(userList.SelectedValue), Convert.ToInt32(periodList.SelectedValue), Convert.ToInt32(weekList.SelectedValue));

                if (availableDayList.Count != 0)
                {
                    foreach (int day in availableDayList)
                    {
                        dayList.Items.Add(DayIntToString(day));
                    }
                }
            }
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
        #endregion

        #region Buttons
        protected void addButton_Click(object sender, EventArgs e)
        {

        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {

        }
        protected void userList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonFoutControle_Click(object sender, EventArgs e)
        {
            ///gijs: in mijn lecture tabel heb ik 2 entries toegevoerd: id 4 & 5
            ///bij id 4 conflicteert het lokaal met id 1 omdat ze in het zelfde lokaal plaats vinden op overlappende tijden
            ///bij id 5 conflicteert de docent met id 1 omdat deze docent tegelijker tijd op 2 plekken moet zijn

            Models.CC.Scheduler_ShowConflicts ssc = new Models.CC.Scheduler_ShowConflicts();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Hier komt te staan of er fouten zijn aangetroffen de ja of de nee.');", true);

        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}