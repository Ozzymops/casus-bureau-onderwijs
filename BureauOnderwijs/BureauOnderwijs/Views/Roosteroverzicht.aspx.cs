using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class Roosteroverzicht : System.Web.UI.Page
    {
        /// Te doen:
        /// - Genereer een lege table                           [X]
        /// - Een entry is een string ARRAY in een LIST         [X]
        /// - Auto-update UserList met teacher id's             [X]
        /// - Auto-update DayList met dagen                     [X]
        /// - Auto-update ModuleList met modulen                [X]
        /// - Maak entry strings en sla deze op in session      [X]
        /// - Toon entry strings in session in schedule         [X]
        /// - Maak entry strings userId gebonden                [X]
        /// - Check of entry strings al bestaan in db           [ ]
        /// - Save CREATE / UPDATE entry strings naar database  [ ]
        /// - Haal entries op uit database                      [ ]
        /// - Try/catch OVERAL                                  [ ]

        protected void Page_Load(object sender, EventArgs e)
        {
            // Genereer eenmalig een tabel
            if (gr_schedule.Rows.Count == 0)
            {
                CreateTable();
            }
            // Laad eenmalig de gebruikers in
            FillDropDownLists();
            ApplyFromSession();
        }

        /// <summary>
        /// Genereer een tabel van maandag tot vrijdag, 09:00 tot 18:00.
        /// </summary>
        #region Functions
        public void CreateTable()
        {
            // Columns
            DataTable dt = new DataTable();
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Tijd", typeof(string));
                dt.Columns.Add("Maandag", typeof(string));
                dt.Columns.Add("Dinsdag", typeof(string));
                dt.Columns.Add("Woensdag", typeof(string));
                dt.Columns.Add("Donderdag", typeof(string));
                dt.Columns.Add("Vrijdag", typeof(string));
            }

            // Rows
            int hour = 9;
            bool halfHour = false;
            for (int i = 0; i < 19; i++)
            {
                DataRow dr = dt.NewRow();
                if (hour == 9)
                {
                    if (halfHour)
                    {
                        dr["Tijd"] = "0" + hour + ":30";
                        hour++;
                    }
                    else
                    {
                        dr["Tijd"] = "0" + hour + ":00";
                    }
                }
                else
                {
                    if (halfHour)
                    {
                        dr["Tijd"] = hour + ":30";
                        hour++;
                    }
                    else
                    {
                        dr["Tijd"] = hour + ":00";
                    }
                }
                halfHour = !halfHour;
                dt.Rows.Add(dr);
            }

            // Bind
            gr_schedule.DataSource = dt;
            gr_schedule.DataBind();
        }

        /// <summary>
        /// Vul de DropDownLists - users vanuit de db en beschikbare dagen / modules via userId.
        /// </summary>
        public void FillDropDownLists()
        {
            // periodList
            if (periodList.Items.Count == 0)
            {
                for (int i = 1; i < 5; i++)
                {
                    periodList.Items.Add(i.ToString());
                }
            }

            // weekList
            if (weekList.Items.Count == 0)
            {
                for (int i = 1; i < 11; i++)
                {
                    weekList.Items.Add(i.ToString());
                }
            }

            // userList
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            if (userList.Items.Count == 0)
            {
                List<string> nameList = sgd.GetUsernameListRole(3);
                foreach (string name in nameList)
                {
                    userList.Items.Add(name);
                }
            }

            // dayList
            if (userList.SelectedValue != Session["CurrentUser"].ToString() || weekList.SelectedValue != Session["CurrentWeek"].ToString() || periodList.SelectedValue != Session["CurrentPeriod"].ToString() || (bool)Session["FirstTimeSchedule"] == true)
            {
                dayList.Items.Clear();
                Session["CurrentWeek"] = Convert.ToInt32(weekList.SelectedValue);
                Session["CurrentPeriod"] = Convert.ToInt32(periodList.SelectedValue);
                List<int> dList = sgd.GetDayListUserId(userList.SelectedValue, periodList.SelectedValue, weekList.SelectedValue);
                if (dList.Count != 0)
                {
                    foreach (int day in dList)
                    {
                        if (day == 1) // Maandag
                        {
                            dayList.Items.Add("Maandag");
                        }
                        else if (day == 2) // Dinsdag
                        {
                            dayList.Items.Add("Dinsdag");
                        }
                        else if (day == 3) // Woensdag
                        {
                            dayList.Items.Add("Woensdag");
                        }
                        else if (day == 4) // Donderdag
                        {
                            dayList.Items.Add("Donderdag");
                        }
                        else if (day == 5) // Vrijdag
                        {
                            dayList.Items.Add("Vrijdag");
                        }
                    }
                }
            }

            // moduleList
            moduleList.Items.Clear();
            List<int> mList = sgd.GetModuleListUserId(userList.SelectedValue);
            if (mList.Count != 0)
            {
                foreach (int module in mList)
                {
                    moduleList.Items.Add(sgd.GetModuleCode(module).ToString());
                }
            }
            Session["FirstTimeSchedule"] = false;
        }

        /// <summary>
        /// Maak een entry string aan in de tijdelijke session.
        /// </summary>
        public void AddEntryString(string day, string start, string end, string module, string room)
        {
            // Genereer string
            string entryString = day + ": " + start + " - " + end + ". " + module + ". " + room + ".";
            // Selecteer row en cell
            int[] spot = DetermineSpot(day, start, end);
            // Opslaan naar session
            string[] sessionString = { day, start, end, module, room, spot[0].ToString(), spot[1].ToString(), userList.SelectedValue };
            List<string[]> sessionList = (List<string[]>)Session["ScheduleChanges"];
            sessionList.Add(sessionString);
            Session["ScheduleChanges"] = sessionList;
        }

        /// <summary>
        /// Bepaal plaats van entry in tabel.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int[] DetermineSpot(string day, string start, string end)
        {
            int row = -1;
            int cell = -1;

            // Check day
            if (day == "Maandag")
            {
                cell = 1;
            }
            else if (day == "Dinsdag")
            {
                cell = 2;
            }
            else if (day == "Woensdag")
            {
                cell = 3;
            }
            else if (day == "Donderdag")
            {
                cell = 4;
            }
            else if (day == "Vrijdag")
            {
                cell = 5;
            }

            // Check time
            if (start.Contains("09:"))
            {
                row = 0;
            }
            else if (start.Contains("10:"))
            {
                row = 2;
            }
            else if (start.Contains("11:"))
            {
                row = 4;
            }
            else if (start.Contains("12:"))
            {
                row = 6;
            }
            else if (start.Contains("13:"))
            {
                row = 8;
            }
            else if (start.Contains("14:"))
            {
                row = 10;
            }
            else if (start.Contains("15:"))
            {
                row = 12;
            }
            else if (start.Contains("16:"))
            {
                row = 14;
            }
            else if (start.Contains("17:"))
            {
                row = 16;
            }
            else if (start.Contains("18:"))
            {
                row = 18;
            }
            if (start.Contains(":30") && !start.Contains("18:"))
            {
                row += 1;
            }
            return new int[] { row, cell };
        }

        /// <summary>
        /// Past sessionList toe aan tabel.
        /// </summary>
        public void ApplyFromSession()
        {
            gr_schedule.DataSource = null;
            gr_schedule.DataBind();
            CreateTable();
            List<string[]> sessionList = (List<string[]>)Session["ScheduleChanges"];
            if (sessionList.Count != 0)
            {
                foreach (string[] entry in sessionList)
                {
                    if (userList.SelectedValue == entry[7])
                    {
                        string row = entry[5];
                        string column = entry[6];
                        string text = entry[0] + ": " + entry[1] + " - " + entry[2] + ". " + entry[3] + ". " + entry[4] + ".";
                        gr_schedule.Rows[Convert.ToInt32(row)].Cells[Convert.ToInt32(column)].Text = text;
                    }
                }
            }
        }

        public bool CheckIfEntryExists(string[] entry)
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            if (CheckIfEntryExists(entry))
            {

            }
            return false;
        }
        #endregion

        #region Buttons
        protected void addButton_Click(object sender, EventArgs e)
        {
            if (startTextBox.Text != "" && endTextBox.Text != "" && roomTextBox.Text != "")
            {
                AddEntryString(dayList.SelectedValue, startTextBox.Text, endTextBox.Text, moduleList.SelectedValue, roomTextBox.Text);
                ApplyFromSession();
            }
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            //UpdateBoxes();
        }
        protected void userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillDropDownLists();
            Session["CurrentUser"] = userList.SelectedValue;
        }
        #endregion

        protected void ButtonFoutControle_Click(object sender, EventArgs e)
        {
            ///gijs: in mijn lecture tabel heb ik 2 entries toegevoerd: id 4 & 5
            ///bij id 4 conflicteert het lokaal met id 1 omdat ze in het zelfde lokaal plaats vinden op overlappende tijden
            ///bij id 5 conflicteert de docent met id 1 omdat deze docent tegelijker tijd op 2 plekken moet zijn

            Models.CC.Scheduler_ShowConflicts ssc = new Models.CC.Scheduler_ShowConflicts();


            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Hier komt te staan of er fouten zijn aangetroffen de ja of de nee.');", true);

        }
    }
}