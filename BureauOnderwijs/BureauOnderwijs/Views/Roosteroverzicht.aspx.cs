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
            InitializeTable();
        }

        #region Functions
        /// <summary>
        /// Tekent een table voor een wat meer visueel voorbeeld
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

        #region Buttons
        protected void addButton_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
    }
}