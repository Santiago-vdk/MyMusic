using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Bands/Albums
        public ActionResult Index(int userId, int albumId)
        {
            System.Diagnostics.Debug.WriteLine("a band with id " + userId + " is checking album " + albumId);
            return View();
        }
    }
}