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
            DLUpdateModule.DataSource = dtbl;
            DLUpdateModule.DataBind();
        }

        protected void DLUpdateModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ModuleId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        }

        public void BTUpdate_Click(object sender, EventArgs e)
        {
            string ingelogd = Session["UserId"].ToString();
            Models.CC.Examiner_UpdateModule Up = new Models.CC.Examiner_UpdateModule();
            string name = Up.UpdateModuleCC(TBName.Text, Convert.ToInt32(TBModuleCode.Text), Convert.ToInt32(TBPeriod.Text), Convert.ToInt32(TBYear.Text), TBFaculty.Text, TBProfile.Text, Convert.ToInt32(TBCredits.Text), CheckBoxGeneralModule.Checked, DropDownListExaminor.SelectedValue, TBDescription.Text, Convert.ToInt32(TBLectureHours.Text), Convert.ToInt32(TBPracticalHours.Text), ingelogd);
        }

        protected void BTCancel_Click(object sender, EventArgs e)
        {

        }
    }
}