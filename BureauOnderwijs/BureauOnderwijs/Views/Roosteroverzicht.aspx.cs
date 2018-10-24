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
        protected void Page_Load(object sender, EventArgs e)
        {
            DrawTable();
            UpdateUserList();
            ReapplyChanges();
        }

        /// Te doen:
        /// - Auto-update UserList en DayList   [X]
        /// - Toon entries in het rooster zelf  [ ]
        /// - Haal entries op uit database      [ ]
        /// - Save entries naar database        [ ]


        #region Functions
        /// <summary>
        /// Bereidt table voor
        /// </summary>
        public void DrawTable()
        {
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
            
            gr_schedule.DataSource = dt;
            gr_schedule.DataBind();
        }

        /// <summary>
        /// Check de textboxes voor algemene foutjes, zoals geen cijfers zijn ingevoerd, geen data, etc.
        /// </summary>
        /// <returns></returns>
        public bool CheckGeneralErrors()
        {
            // Check of de verplichte velden niet leeg zijn
            if (startTextBox.Text == "" || endTextBox.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongeldig tijdsvak.');", true);
                return true;
            }
            if (roomTextBox.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongeldig lokaal.');", true);
                return true;
            }
            return false;
        }

        public void CheckConflicts()
        {
            // Gijsje, mijn dude
        }

        /// <summary>
        /// Vult de table met data uit de database.
        /// </summary>
        public void PopulateTable()
        {

        }
        #endregion

        /// <summary>
        /// Update de comboboxes met relevante informatie bepaald door user id
        /// </summary>
        /// <param name="userId"></param>
        public void UpdateBoxes()
        {
            UpdateUserList();
            UpdateDayList();
        }

        /// <summary>
        /// Werkt de UserList bij zodat alle beschikbare docenten in de combobox staan.
        /// </summary>
        public void UpdateUserList()
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            if (userList.Items.Count == 0)
            {
                List<string> nameList = sgd.GetUsernameListRole(3);
                foreach (string name in nameList)
                {
                    userList.Items.Add(name);
                }
            }
        }

        /// <summary>
        /// Werkt de DayList bij zodat alleen de beschikbare dagen van de gebruiker er staan.
        /// </summary>
        public void UpdateDayList()
        {
            Models.CC.Scheduler_GetData sgd = new Models.CC.Scheduler_GetData();
            dayList.Items.Clear();
            List<int> dList = sgd.GetDayListUserId(userList.SelectedValue);
            if (dList != null)
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

        /// <summary>
        /// Voegt een entry toe aan het rooster
        /// </summary>
        public void AddEntry(string day, string module, string start, string end, string room)
        {
            /// Zoek juiste tijdsvak / cel
            /// Maak een mooie string
            /// Voeg in
            string entryString = String.Format("{0}\r\n{1} - {2}\n{3}\n{4}", day, start, end, module, room);

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
            // Apply to schedule
            gr_schedule.Rows[row].Cells[cell].Text = entryString;
            // Retrieve and save list
            entryString += "@" + row.ToString() + "@" + cell.ToString();
            List<string> changeList = (List<string>)Session["ScheduleChanges"];
            changeList.Add(entryString);
            Session["ScheduleChanges"] = changeList;
        }

        /// <summary>
        /// Doet entries opnieuw toepassen in schedule indien Page_Load weer eens alles wist
        /// </summary>
        public void ReapplyChanges()
        {
            List<string> changeList = (List<string>)Session["ScheduleChanges"];
            if (changeList.Any())
            {
                foreach(string entry in changeList)
                {
                    string[] splitEntry = entry.Split('@');
                    TestLabel.Text = splitEntry[1] + " " + splitEntry[2] + " " + splitEntry[0];
                    gr_schedule.Rows[Convert.ToInt32(splitEntry[1])].Cells[Convert.ToInt32(splitEntry[2])].Text = splitEntry[0];
                }
            }
        }

        #region Buttons
        protected void addButton_Click(object sender, EventArgs e)
        {
            if (startTextBox.Text != "" && endTextBox.Text != "" && roomTextBox.Text != "")
            {
                AddEntry(dayList.SelectedValue.ToString(), moduleList.SelectedValue.ToString(),
                         startTextBox.Text, endTextBox.Text, roomTextBox.Text);
            }
        }
        #endregion

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            UpdateBoxes();
        }
    }
}