﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BureauOnderwijs
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["RecoveryStep"] = "1";
            Session["Database_FirstTime"] = true;

            // TO DELETE
            // Roosteroverzicht.aspx.cs
            Session["ScheduleChangeList"] = new List<Models.BU.Lecture>();
            Session["ScheduleDatabaseList"] = new List<Models.BU.Lecture>();
            //Session["CurrentUser"] = "Roy"; // los dit op!
            //Session["ControlPanel"] = 0;
            Session["Database_FirstTime"] = true;
        }
    }
}