using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
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
    }
}