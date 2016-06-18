using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Bands.Requests;
using MyFan_Webapp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands.Controllers
{
    public class BandsController : Controller
    {
        // GET: Bands/Bands
        public async Task<ActionResult> Index(int userId)
        {
            if (Sessions.isAuthenticated(Request, Session))
            {
                int sessionRol = Int32.Parse(Session["rol"].ToString());
                if (!Sessions.isFan(sessionRol))
                {
                    return View("~/Views/Login/Index.cshtml");
                }
            }
            //[Bandas,Posts]
            List<string> response = await clsBandRequests.GetBandProfile(userId);

            //Hubo error
            if (!ErrorParser.parse(response[0]).Equals("") || !ErrorParser.parse(response[1]).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }

            BandProfileViewModel profile = DataParser.parseBandProfile(response);
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            
            return View(profile);
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