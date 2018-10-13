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
    }
}