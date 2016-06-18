using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands.Controllers
{
    public class EventsController : Controller
    {
        // GET: Bands/Events
        public ActionResult Index()
        {
            return View();
        }

    }
}