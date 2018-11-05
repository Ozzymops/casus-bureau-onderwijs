using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_ExportWishlist
    {
        public int ExportWishesCC()
        {
            BU.Wish oWish = new BU.Wish();
            return oWish.ExportWishlist();
        }
    }
}