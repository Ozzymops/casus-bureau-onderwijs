using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class User_UpdateUserSettings
    {
        public string UpdateVoornaamCC(string voornaam, string ingelogd)
        {
            User u = new User();
            return u.UpdateVoornaam(voornaam, ingelogd);
        }

        public string UpdateAchternaamCC(string achternaam, string ingelogd)
        {
            User u = new User();
            return u.UpdateAchternaam(achternaam, ingelogd);
        }

        public string UpdateEmailCC(string email, string ingelogd)
        {
            User u = new User();
            return u.UpdateEmail(email, ingelogd);
        }

        public string UpdatePasswordCC(string newpassword,string currentpassword, string ingelogd)
        {
            User u = new User();
            return u.UpdatePassword(newpassword,currentpassword, ingelogd);
        }

        public string LoadVnCC(string ingelogd)
        {
            User u = new User();
            return u.LoadVn(ingelogd);
        }

        public string LoadAnCC(string ingelogd)
        {
            User u = new User();
            return u.LoadAn(ingelogd);
        }

        public string LoadEmCC(string ingelogd)
        {
            User u = new User();
            return u.LoadEm(ingelogd);
        }
    }
}