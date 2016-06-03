using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Fans/Albums
        public ActionResult Index(int userId, int bandId, int id)
        {
            System.Diagnostics.Debug.WriteLine("check band from " + userId + " of band " + bandId + " with album " + id);
            return View();
        }
    }
}