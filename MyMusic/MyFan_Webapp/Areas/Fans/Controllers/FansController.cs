using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Areas.Fans.Requests;
using MyFan_Webapp.Logic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class FansController : Controller
    {
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
            List<string> response = await clsFanRequests.GetFanProfile(userId);
      
            //Hubo error
            if (!ErrorParser.parse(response[0]).Equals("") || !ErrorParser.parse(response[1]).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }

            VMFanProfile profile = DataParser.parseFanProfile(response);
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            return View(profile);
        }



      /*  public async Task<ActionResult> Profiles(int Id)
        {
            System.Diagnostics.Debug.WriteLine(Id);
            string response = await clsFanRequests.GetFanBands(Id);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life2...";
            }

            VMFanProfile profile = DataParser.parseFanBands(response);

            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            return View(profile);


        }*/

        public ActionResult Edit()
        {
            System.Diagnostics.Debug.WriteLine("Edit Profile");
            return View();
        }
    }
}