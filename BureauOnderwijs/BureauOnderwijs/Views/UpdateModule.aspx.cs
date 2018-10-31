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
        protected void Page_Load(object sender, EventArgs e)
        {
            string ingelogd = Session["UserId"].ToString();
            DataTable dtbl = new DataTable();
            Models.CC.Examiner_ReadModules RM = new Models.CC.Examiner_ReadModules();
            dtbl = RM.ReadModuleCC(ingelogd);
            GVUpdateModule.DataSource = dtbl;
            GVUpdateModule.DataBind();
        }

        public void BTUpdate_Click(object sender, EventArgs e)
        {
            string ingelogd = Session["UserId"].ToString();
            int ModuleId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Models.CC.Examiner_UpdateModule Up = new Models.CC.Examiner_UpdateModule();
            string name = Up.UpdateModuleCC(TBNameU.Text, Convert.ToInt32(TBModuleCodeU.Text), Convert.ToInt32(TBPeriodU.Text), Convert.ToInt32(TBYearU.Text), TBFacultyU.Text, TBProfileU.Text, Convert.ToInt32(TBCreditsU.Text), CheckBoxGeneralModuleU.Checked, Convert.ToInt32(DropDownListExaminorU.Text), TBDescriptionU.Text, Convert.ToInt32(TBLectureHoursU.Text), Convert.ToInt32(TBPracticalHoursU.Text), ingelogd, ModuleId);
            
            //Er komt een return waarde terug voor het aanpassen van de module. wanneer dit NIET gelukt is komt er de volgende melding: 
            if (name == "2")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Foutmelding! er is iets mis gegaan :(.');", true);
            }
            //Er komt een return waarde terug voor het aanpassen van de module. wanneer dit WEL gelukt is komt er de volgende melding:
            else if (name == "1")
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

        protected void GVUpdateModule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een gebruikersnaam en wachtwoord in.');", true);
            if (e.CommandName == "Update")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gr = GVUpdateModule.Rows[index];
                TBNameU.Text = gr.Cells[1].Text;
                TBModuleCodeU.Text = gr.Cells[2].Text;
                TBPeriodU.Text = gr.Cells[3].Text;
                TBYearU.Text = gr.Cells[4].Text;
                TBFacultyU.Text = gr.Cells[5].Text;
                TBProfileU.Text = gr.Cells[6].Text;
                TBCreditsU.Text = gr.Cells[7].Text;
                DropDownListExaminorU.Text = gr.Cells[8].Text;
                TBDescriptionU.Text = gr.Cells[9].Text;
                CheckBoxGeneralModuleU.Text = gr.Cells[10].Text;
                TBLectureHoursU.Text = gr.Cells[11].Text;
                TBPracticalHoursU.Text = gr.Cells[12].Text;

            }
        }
    }
}