using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class User
    {
        private string username;
        private string password;
        private string emailAdress;
        private string firstname;
        private string lastname;
        private int twoFactorCode;
        private int recoveryCode;
        private int role;

        public void LogIn(string username, string password)
        {

        }

        public void LogOut()
        {

        }

        public void ViewSchedule()
        {

        }

        public void ResetPassword()
        {

        }

        public void UpdateData()
        {

        }
    }
}