using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs
{
    public partial class UserSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonUpdateFirstName_Click(object sender, EventArgs e)
        {
            string conString = "Data Source = localhost; Initial Catalog = bureauonderwijsdb ; Integrated Security = True";
            string sqlQuery = "UPDATE [user] SET FirstName = 'lekker ding' WHERE Id = 1";

            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            //Int32 count = (Int32)cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            conn.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('gijs is cool geupdate');", true);

        }
    }
}