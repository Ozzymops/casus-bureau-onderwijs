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
        private string period;
        private int week;
        private string day;
        private DateTime startTime;
        private DateTime endTime;

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

        public void UpdateWish()
        {

        }

        public int ExportWishlist()
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = ("SELECT Wi.WishId, Wi.Period, Wi.Week, Wi.Day, Wi.StartTime, Wi.EndTime, UA.UserId, UA.Firstname, UA.Lastname, UA.Role FROM Wish Wi JOIN UserAccount UA ON UA.UserId = Wi.UserId");
            int i = 0;
            int j = 0;

            try
            {
                Excel.Application xlapp = new Excel.Application();

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

                //Slaat de gegevens op
                xlWorkBook.SaveAs("c:\\Test\\WensenlijstExcel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlapp.Quit();

                //Verwijdert de objecten
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlapp);

                return 0; 
            }

            catch(Exception)
            {
                return 2;
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