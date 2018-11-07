using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class AddModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BTSend_Click(object sender, EventArgs e)
        {
            //sessie id wordt opgehaald om te controleren of er daadwerkelijke een examinator is ingelogd
            string ingelogd = Session["UserId"].ToString();
            Models.CC.Examiner_CreateModule m = new Models.CC.Examiner_CreateModule();
            string name = m.AddModuleCC(TBName.Text, TBModuleCode.Text, Convert.ToInt32(TBPeriod.Text), Convert.ToInt32(TBYear.Text), DDFaculty.Text, DDProfile.Text, Convert.ToInt32(TBCredits.Text), CheckBoxGeneralModule.Checked ,Convert.ToInt32(DDExaminer.Text), TBDescription.Text, Convert.ToInt32(TBLectureHours.Text), Convert.ToInt32(TBPracticalHours.Text), Convert.ToInt32(TBDocent.Text), ingelogd);

            //Er komt een return waarde terug voor het toevoegen van de nieuwe module. wanneer dit NIET gelukt is komt er de volgende melding: 
            if (name == "1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Foutmelding! er is iets mis gegaan :(.');", true);
            }
            //Er komt een return waarde terug voor het toevoegen van de nieuwe module. wanneer dit WEL gelukt is komt er de volgende melding:
            else if (name == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nieuwe module is toegevoegd!.');", true);
            }
            //In andere gevallen geef de foutmelding 'Onbekende Fout'.
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Onbekende Fout');", true);
            }
        }

        protected void BTCancel_Click(object sender, EventArgs e)
        {

        }
    }
}