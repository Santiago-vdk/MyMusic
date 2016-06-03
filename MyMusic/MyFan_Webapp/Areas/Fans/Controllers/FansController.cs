﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class FansController : Controller
    {
        // GET: Fans/Fans
        public async System.Threading.Tasks.Task<ActionResult> Index(int userId)
        {
            System.Diagnostics.Debug.WriteLine(userId);
          
            await Client.RunAsync();
            return View();
        }

        public new ActionResult Profile(int userId)
        {
            System.Diagnostics.Debug.WriteLine("check profile from " + userId);
            return View();
        }

        public ActionResult Edit()
        {
            System.Diagnostics.Debug.WriteLine("Edit Profile");
            return View();
        }
    }
}