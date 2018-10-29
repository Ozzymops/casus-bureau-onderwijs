using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BureauOnderwijs.Models.CC
{
    public class Teacher_ReadWishes
    {
        public DataTable GetUserWishesCC(string ingelogd)
        {
            Models.BU.Wish n = new Models.BU.Wish();
            return n.GetUserWishes(ingelogd);
        }
        public DataTable makeDatatableReadable(DataTable dt)
        {
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                if (Convert.ToInt32(dt.Rows[rowIndex][3]) == 1)
                {
                    dt.Rows[rowIndex][3] = "Maandag";
                }
                else if (Convert.ToInt32(dt.Rows[rowIndex][3]) == 2)
                {
                    dt.Rows[rowIndex][3] = "Dinsdag";
                }
                else if (Convert.ToInt32(dt.Rows[rowIndex][3]) == 3)
                {
                    dt.Rows[rowIndex][3] = "Woensdag";
                }
                else if (Convert.ToInt32(dt.Rows[rowIndex][3]) == 4)
                {
                    dt.Rows[rowIndex][3] = "Donderdag";
                }
                else if (Convert.ToInt32(dt.Rows[rowIndex][3]) == 5)
                {
                    dt.Rows[rowIndex][3] = "Vrijdag";
                }
            }
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                if (Convert.ToInt32(dt.Rows[rowIndex][4]) == 9)
                {
                    dt.Rows[rowIndex][4] = "09";
                }
            }
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                if (Convert.ToInt32(dt.Rows[rowIndex][5]) == 0)
                {
                    dt.Rows[rowIndex][5] = "00";
                }
            }
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                if (Convert.ToInt32(dt.Rows[rowIndex][6]) == 9)
                {
                    dt.Rows[rowIndex][6] = "09";
                }
            }
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                if (Convert.ToInt32(dt.Rows[rowIndex][7]) == 0)
                {
                    dt.Rows[rowIndex][7] = "00";
                }
            }
            return dt;
        }
    }
}