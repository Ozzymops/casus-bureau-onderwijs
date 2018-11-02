using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace BureauOnderwijs.Models.BU
{
    public class Wish
    {
        public int wishId;
        public int period;
        public int week;
        public int day;
        public int startHour;
        public int startMinute;
        public int endHour;
        public int endMinute;

        public int WishId
        {
            get { return this.wishId; }
            set { this.wishId = value; }
        }

        public int Day
        {
            get { return this.day; }
            set { this.day = value; }
        }

        public string DayString
        {
            get { return this.day.ToString(); }
        }

        public Wish()
        {
            // Leeg: anders verschijnen er enge rode lijntjes.
        }

        public Wish(int wishId, int period, int week, int day, int startHour, int startMinute, int endHour, int endMinute)
        {
            this.wishId = wishId;
            this.period = period;
            this.week = week;
            this.day = day;
            this.startHour = startHour;
            this.startMinute = startMinute;
            this.endHour = endHour;
            this.endMinute = endMinute;
        }

        public int CreateWish(string period, int week, int day, int startHour, int startMinute, int endHour, int endMinute, int ingelogd)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "INSERT INTO Wish (Period, Week, Day, StartHour, StartMinute, EndHour, EndMinute, UserId) VALUES ('"+ period +"', '"+ week +"', '"+ day +"', '"+ startHour +"', '" + startMinute + "', '"+ endHour +"', '" + endMinute + "', '"+ ingelogd +"')";

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 0; 
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public int UpdateWish(string period, int week, int day, int startTijdUur, int startTijdMinuut, int eindTijdUur, int EindTijdMinuut, int ingelogd, int wishId)
        {
            return 0;
        }

        public int ExportWishlist()
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = ("SELECT Wi.WishId, Wi.Period, Wi.Week, Wi.Day, Wi.StartHour, Wi.StartMinute, Wi.EndHour, Wi. EndMinute, UA.UserId, UA.Firstname, UA.Lastname, UA.Role FROM Wish Wi JOIN UserAccount UA ON UA.UserId = Wi.UserId");
            int i = 0;
            int j = 0;

            try
            {
                Excel.Application xlapp = new Excel.Application();
                xlapp.DisplayAlerts = false;

                //Checkt of excel juist is geinstalleerd
                if (xlapp == null)
                {
                    return 1;
                }

                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlapp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, con);
                DataSet ds = new DataSet();
                dscmd.Fill(ds);

                //Vult de Column-namen
                foreach (DataTable dt in ds.Tables)
                {
                    for (int i1 = 0; i1 < dt.Columns.Count; i1++)
                    {
                        xlWorkSheet.Cells[1, i1 + 1] = dt.Columns[i1].ColumnName;
                    }
                }

                //Vult de Column-data
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    int s = i + 1;
                    for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        string data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[s + 1, j + 1] = data;
                    }
                }

                try
                {
                    //Slaat de gegevens op
                    xlWorkBook.SaveAs(HttpContext.Current.Server.MapPath("~/Downloads/WensenlijstExcel.xls"), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlapp.Quit();

                    //Verwijdert de objecten
                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlapp);
                    return 0;
                }
                catch
                {
                    //Verwijdert de objecten
                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlapp);
                    return 3;
                }
                
            }

            catch(Exception)
            {
                return 2;
            }
        }

        public int DeleteWish(int wishId)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "DELETE FROM Wish WHERE WishId = '" + wishId + "'";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public DataTable GetUserWishes(string ingelogd)
        {

            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "SELECT WishId, Period, Week, Day, StartHour, StartMinute, EndHour, EndMinute FROM Wish Where UserId = '" + ingelogd + "'";


            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                /// Klonen van database zodat voor de gebruiker de dagen voluit geschreven gezien kunnen worden
                /// ipv de dagen als 1, 2, 3, 4 of 5. Dit is een stuk gebruiksvriendelijker

                DataTable dtClone = new DataTable();
                dtClone = dt.Clone();
                dtClone.Columns[3].DataType = typeof(string);
                dtClone.Columns[4].DataType = typeof(string);
                dtClone.Columns[5].DataType = typeof(string);
                dtClone.Columns[6].DataType = typeof(string);
                dtClone.Columns[7].DataType = typeof(string);

                foreach (DataRow row in dt.Rows)
                {
                    dtClone.ImportRow(row);
                }
                con.Close();
                return dtClone;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}