using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class NewsController : Controller
    {
        // GET: Fans/News
        public ActionResult Index(int userId, int bandId)
        {
            System.Diagnostics.Debug.WriteLine("Checking news from " + userId + " of " + bandId);
            return View();
        }
    }
}