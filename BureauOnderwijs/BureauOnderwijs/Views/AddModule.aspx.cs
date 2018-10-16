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
            string name = m.AddModuleCC(TBName.Text, Convert.ToInt32(TBModuleCode.Text), Convert.ToInt32(TBPeriod.Text), Convert.ToInt32(TBYear.Text), TBFaculty.Text, TBProfile.Text, Convert.ToInt32(TBCredits.Text), DropDownListExaminor.SelectedValue, TBDescription.Text, Convert.ToInt32(TBLectureHours.Text), Convert.ToInt32(TBPracticalHours.Text), ingelogd);

            //als de return waarde van succesvol updaten gelijk is aan de string waarde "0" geef foutmelding 'niet goed gegaan.'. 
            if (name == "2")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Niet goed gegaan.');", true);
            }
            //als de return waarde van succesvol updaten gelijk is aan de string waarde "1" geef melding 'Succes! Voornaam is geupdatet.'.
            else if (name == "1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Succes! Voornaam is geupdatet.');", true);
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

        protected void TBName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBModuleCode_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBPeriod_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBYear_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBDescription_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListExaminor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TBFaculty_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBProfile_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBCredits_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBLectureHours_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBPracticalHOurs_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBoxGeneralModule_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}