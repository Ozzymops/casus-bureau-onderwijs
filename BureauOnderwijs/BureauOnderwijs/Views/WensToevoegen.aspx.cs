using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class WensToevoegen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DropDownListBlokperiode.Items.Clear();
            DropDownListWeek.Items.Clear();
            DropDownListDag.Items.Clear();

            for (int y = 1; y < 5; y++)
            {
                DropDownListBlokperiode.Items.Add(y + "-2018/2019");
            }
            for (int i = 1; i < 11; i++)
            {
                DropDownListWeek.Items.Add(Convert.ToString(i));
            }

            DropDownListDag.Items.Add("Maandag");
            DropDownListDag.Items.Add("Dinsdag");
            DropDownListDag.Items.Add("Woensdag");
            DropDownListDag.Items.Add("Donderdag");
            DropDownListDag.Items.Add("Vrijdag");

        }
    }
}