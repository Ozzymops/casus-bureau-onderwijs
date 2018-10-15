using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BureauOnderwijs.Models.CC
{
    public class Teacher_ReadWishes
    {
        public DataTable GetUserWishesCC(string ingelogd)
        {
            Models.BU.Wish n = new Models.BU.Wish();
            return n.GetUserWishes(ingelogd);
        }
    }
}