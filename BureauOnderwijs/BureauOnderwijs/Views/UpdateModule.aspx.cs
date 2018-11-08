using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class UpdateModule : System.Web.UI.Page
    {
        //Pagina wordt geladen 
        protected void Page_Load(object sender, EventArgs e)
        {
            //controle of de user is ingelogd
            string ingelogd = Session["UserId"].ToString();
            //lege datatable wordt aangemaakt en wordt doorgestuurd naar de Models.CC.Examiner_Readmodules laag
            //De pagina wordt geopend met alle labels en tekstboxen en er word een gridview weergegeven
            DataTable dtbl = new DataTable();
            Models.CC.Examiner_ReadModules RM = new Models.CC.Examiner_ReadModules();
            dtbl = RM.ReadModuleCC(ingelogd);
            GVUpdateModule.DataSource = dtbl;
            GVUpdateModule.DataBind();
        }

        protected void BTSend_Click(object sender, EventArgs e)
        {
            //controle of de user is ingelogd
            string ingelogd = Session["UserId"].ToString();
            DataTable dtblUpdate = new DataTable();
            //lege datatable wordt aangemaakt en wordt doorgestuurd naar de Models.CC.Examiner_Updatemodules laag
            //Er is een string aangemaakt waar alle tekstboxen worden doorgegeven.
            Models.CC.Examiner_UpdateModule m = new Models.CC.Examiner_UpdateModule();
            string name = m.UpdateModuleCC(TBName.Text, TBModuleCode.Text, Convert.ToInt32(TBPeriod.Text), Convert.ToInt32(TBYear.Text), DDFaculty.Text, DDProfile.Text, Convert.ToInt32(TBCredits.Text), CheckBoxGeneralModule.Checked, Convert.ToInt32(DDExaminer.Text), TBDescription.Text, Convert.ToInt32(TBLectureHours.Text), Convert.ToInt32(TBPracticalHours.Text), Convert.ToInt32(TBModuleId.Text) ,ingelogd);
            GVUpdateModule.DataSource = dtblUpdate;
            GVUpdateModule.DataBind();

            if (name == "1")
            //Er komt een return waarde terug voor het wijzigen van de module. wanneer dit NIET gelukt is komt er de volgende melding:
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Foutmelding! er is iets mis gegaan :(.');", true);
                
            }
            //Er komt een return waarde terug voor het wijzigen van de module. wanneer dit WEL gelukt is komt er de volgende melding:
            else if (name == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Module is aangepast!.');", true);
            }
            //In andere gevallen geef de foutmelding 'Onbekende Fout'.
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Onbekende Fout');", true);
            }
            //pagina wordt gerefreshed
            Response.Redirect("~/Views/UpdateModule.aspx");
        }

        protected void BTCancel_Click(object sender, EventArgs e)
        {

        }
    }
}