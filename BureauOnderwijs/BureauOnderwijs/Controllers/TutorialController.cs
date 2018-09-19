using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet;

namespace BureauOnderwijs.Controllers
{
    public class TutorialController : Controller
    {

        // GET: /Tutorial/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Tutorial/Welcome/
        public string Welcome(string name, int numTimes = 1)
        {
            return ($"Welkom {name}, NumTimes is: {numTimes}");
        }
    }
}