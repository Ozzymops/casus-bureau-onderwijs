using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class PasswordRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recoveryStepOne.Visible = true;
            recoveryStepTwo.Visible = false;
            recoveryStepThree.Visible = false;
        }

        protected void RecoverySendButton_Click(object sender, EventArgs e)
        {
            Models.CC.LogIn l = new Models.CC.LogIn();
            if (l.CheckIfUserExists(UsernameTextBox.Text))
            {
                Models.RandomNumberGenerator rng = new Models.RandomNumberGenerator();
                this.Session["RecoveryCode"] = rng.GenerateNumber(1000, 9999);
                CodeLabel.Text += this.Session["RecoveryCode"].ToString();
                this.Session["Username"] = UsernameTextBox.Text;
                this.Session["RecoveryStep"] = "2";

                recoveryStepOne.Visible = false;
                recoveryStepTwo.Visible = true;
                recoveryStepThree.Visible = false;
            }
        }

        protected void RecoveryCodeButton_Click(object sender, EventArgs e)
        {
            if (RecoveryCodeTextBox.Text == this.Session["RecoveryCode"].ToString())
            {
                NewPasswordLabel.Text += this.Session["Username"];
                this.Session["RecoveryStep"] = "3";

                recoveryStepOne.Visible = false;
                recoveryStepTwo.Visible = false;
                recoveryStepThree.Visible = true;
            }
        }

        protected void NewPasswordButton_Click(object sender, EventArgs e)
        {
            string query = "UPDATE UserAccount SET Password = '" + NewPasswordTextBox.Text + "' WHERE Username = '" + this.Session["Username"] + "'";
            Models.Database db = new Models.Database();
            db.Connect();
            db.UpdatePassword(query);
            this.Session["RecoveryStep"] = "1";
            Response.Redirect("~/Views/LogIn.aspx");
        }
    }
}