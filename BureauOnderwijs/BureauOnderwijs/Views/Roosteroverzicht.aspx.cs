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
        /// - Genereer een lege table                           [X]
        /// - Een entry is een string ARRAY in een LIST         [X]
        /// - Auto-update UserList met teacher id's             [X]
        /// - Auto-update DayList met dagen                     [X]
        /// - Auto-update ModuleList met modulen                [X]
        /// - Maak entry strings en sla deze op in session      [X]
        /// - Toon entry strings in session in schedule         [X]
        /// - Maak entry strings userId gebonden                [X]
        /// - Week/periode gebonden data                        [X]
        /// - Check of entry strings al bestaan in db           [X]
        /// - Save CREATE / UPDATE entry strings naar database  [X]
        /// - Haal entries op uit database                      [ ]
        /// - Try/catch OVERAL                                  [ ]

        protected void Page_Load(object sender, EventArgs e)
        {
            // Genereer eenmalig een tabel
            if (gr_schedule.Rows.Count == 0)
            {
                CreateTable();
            }
            FillDropDownLists();
            RetrieveFromDatabase();
            ApplyFromSession();
            Session["FirstTimeSchedule"] = false;
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
            if (userList.SelectedValue != Session["CurrentUser"].ToString() || (bool)Session["FirstTimeSchedule"] == true)
            {
                moduleList.Items.Clear();
                List<int> mList = sgd.GetModuleListUserId(userList.SelectedValue);
                if (mList.Count != 0)
                {
                    foreach (int module in mList)
                    {
                        moduleList.Items.Add(sgd.GetModuleCode(module).ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Maak een entry string aan in de tijdelijke session.
        /// </summary>
        public void AddEntryString(string day, string start, string end, string module, string group, string room, string period, string week)
        {
            // Genereer string
            string entryString = day + ": " + start + " - " + end + ". " + group + " " + module + ". " + room + ".";
            // Selecteer row en cell
            int[] spot = DetermineSpot(day, start, end);
            // Opslaan naar session
            string[] sessionString = { day, start, end, module, group, room, spot[0].ToString(), spot[1].ToString(), period, week, userList.SelectedValue };
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
            else if (day == "Dinsdag" || Convert.ToInt32(day) == 2)
            {
                cell = 2;
            }
            else if (day == "Woensdag" || Convert.ToInt32(day) == 3)
            {
                cell = 3;
            }
            else if (day == "Donderdag" || Convert.ToInt32(day) == 4)
            {
                cell = 4;
            }
            else if (day == "Vrijdag" || Convert.ToInt32(day) == 5)
            {
                cell = 5;
            }
            else
            {
                int num;
                if (Int32.TryParse(day, out num))
                {
                    if (num == 1)   // Maandag
                    {
                        cell = 1;
                    }
                    if (num == 2)   // Dinsdag
                    {
                        cell = 2;
                    }
                    if (num == 3)   // Woensdag
                    {
                        cell = 3;
                    }
                    if (num == 4)   // Donderdag
                    {
                        cell = 4;
                    }
                    if (num == 5)   // Vrijdag
                    {
                        cell = 5;
                    }
                }
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
            // Database
            List<string[]> retrieveList = (List<string[]>)Session["ScheduleDatabase"];
            if (retrieveList.Count != 0)
            {
                foreach (string[] entry in retrieveList)
                {
                    if (userList.SelectedValue == entry[10] && periodList.SelectedValue == entry[8] && weekList.SelectedValue == entry[9])
                    {              
                        string row = entry[6];
                        string column = entry[7];
                        string text = entry[0] + ": " + entry[1] + " - " + entry[2] + ". " + entry[4] + " " + entry[3] + ". " + entry[5] + ".";
                        gr_schedule.Rows[Convert.ToInt32(row)].Cells[Convert.ToInt32(column)].Text = text;
                    }
                }
            }

            // Current session
            List<string[]> sessionList = (List<string[]>)Session["ScheduleChanges"];
            if (sessionList.Count != 0)
            {
                foreach (string[] entry in sessionList)
                {
                    if (userList.SelectedValue == entry[10] && periodList.SelectedValue == entry[8] && weekList.SelectedValue == entry[9])
                    {
                        string row = entry[6];
                        string column = entry[7];
                        string text = entry[0] + ": " + entry[1] + " - " + entry[2] + ". " + entry[4] + " " + entry[3] + ". " + entry[5] + ".";
                        gr_schedule.Rows[Convert.ToInt32(row)].Cells[Convert.ToInt32(column)].Text = text;
                    }
                }
            }
        }

        /// <summary>
        /// Check of een entry al bestaat in de database.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public bool CheckIfEntryExists(string[] entry)
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            if (sgd.CheckIfEntryExists(entry))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sla data op naar de database.
        /// </summary>
        public void SaveToDatabase()
        {
            List<string[]> sessionList = (List<string[]>)Session["ScheduleChanges"];
            foreach (string[] entry in sessionList)
            {
                if(CheckIfEntryExists(entry)) // already exists, overwrite
                {
                    Models.CC.Scheduler_UpdateEntry sue = new Models.CC.Scheduler_UpdateEntry();
                    sue.UpdateEntry(entry);
                }
                else // does not exist, yet
                {
                    Models.CC.Scheduler_CreateEntry sce = new Models.CC.Scheduler_CreateEntry();
                    sce.CreateEntry(entry);
                }
            }
        }

        /// <summary>
        /// Haal data op vanuit de database.
        /// </summary>
        public void RetrieveFromDatabase()
        {
            if ((bool)Session["FirstTimeSchedule"] == true)
            {
                Models.CC.Scheduler_ReadEntry sre = new Models.CC.Scheduler_ReadEntry();
                List<string[]> retrieveList = sre.ReadEntry();
                foreach (string[] entry in retrieveList)
                {
                    int[] spot = DetermineSpot(entry[0], entry[1], entry[2]);
                    entry[6] = spot[0].ToString();
                    entry[7] = spot[1].ToString();
                    if (entry[0] == "1")
                    {
                        entry[0] = "Maandag";
                    }
                    else if (entry[0] == "2")
                    {
                        entry[0] = "Dinsdag";
                    }
                    else if (entry[0] == "3")
                    {
                        entry[0] = "Woensdag";
                    }
                    else if (entry[0] == "4")
                    {
                        entry[0] = "Donderdag";
                    }
                    else if (entry[0] == "5")
                    {
                        entry[0] = "Vrijdag";
                    }
                }
                Session["ScheduleDatabase"] = retrieveList;
                ApplyFromSession();
            }
        }
        #endregion

        #region Buttons
        protected void addButton_Click(object sender, EventArgs e)
        {
            if (startTextBox.Text != "" && endTextBox.Text != "" && roomTextBox.Text != "")
            {
                AddEntryString(dayList.SelectedValue, startTextBox.Text, endTextBox.Text, moduleList.SelectedValue, groupTextBox.Text, roomTextBox.Text, periodList.SelectedValue, weekList.SelectedValue);
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

        protected void saveButton_Click(object sender, EventArgs e)
        {
            SaveToDatabase();
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
            // CheckIfEntryExists
            string[] deletable = { dayList.SelectedValue, startTextBox.Text, endTextBox.Text, moduleList.SelectedValue, groupTextBox.Text, roomTextBox.Text, "", "", periodList.SelectedValue, weekList.SelectedValue, userList.SelectedValue};
            if (CheckIfEntryExists(deletable))
            {
                Models.CC.Scheduler_DeleteEntry sde = new Models.CC.Scheduler_DeleteEntry();
                sde.DeleteEntry(deletable);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Entry verwijderd.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Entry niet gevonden. Probeer het nog een keer.');", true);
            }
        }
        #endregion
    }
}