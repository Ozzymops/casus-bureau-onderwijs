using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BureauOnderwijs
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        FontInfo defaultFont;

        protected void Page_Load(object sender, EventArgs e)
        {
            GreetLabel.Text = "Greetings, visitor!";
            LabelChangingButton.Text = "Change label!";
            defaultFont = GreetLabel.Font;
        }

        protected void LabelChangingButton_Click(object sender, EventArgs e)
        {
            GreetLabel.Text = LabelChangingTextBox.Text;
        }

        protected void GreetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GreetList.SelectedIndex == 0)
            {
                GreetLabel.Font.Bold = false;
                GreetLabel.Font.Italic = false;
            }
            else if (GreetList.SelectedIndex == 1)
            {
                GreetLabel.Font.Bold = false;
                GreetLabel.Font.Italic = true;
            }
            else if (GreetList.SelectedIndex == 2)
            {
                GreetLabel.Font.Bold = true;
                GreetLabel.Font.Italic = false;
            }
        }
    }
}