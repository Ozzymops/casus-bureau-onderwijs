using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class LogIn
    {
        public void LoginCC(string username, string password)
        {
            User u = new User();
            u.LogIn(username, password);
        }
    }
}