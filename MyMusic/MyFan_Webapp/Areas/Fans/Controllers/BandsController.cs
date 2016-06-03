using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class BandsController : Controller
    {
        // GET: Fans/Bands
        public ActionResult Index(int userId, int bandId)
        {
            System.Diagnostics.Debug.WriteLine("Checking band from " + userId + " of " + bandId);
            return View();
        }
    }
}