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

        }

        public void FillTable()
        {
            if (startTextBox.Text != null && endTextBox != null)
            {
                if (startTextBox.Text == "09:30")
                {

                }
            }
        }

        public void ReloadTable()
        {
            
        }
    }
}