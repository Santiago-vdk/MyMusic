using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class EventsController : Controller
    {
        // GET: Fans/Events
        public async Task<ActionResult> Index(int userId, int bandId, int id)
        {
            System.Diagnostics.Debug.WriteLine("Checking event from " + userId + " of " + bandId + "with" + id);

            if (Sessions.isAuthenticated(Request, Session))
            {
                int sessionRol = Int32.Parse(Session["rol"].ToString());
                if (!Sessions.isFan(sessionRol))
                {
                    return View("~/Views/Login/Index.cshtml");
                }
            }
            //[Bandas,Posts]
            // string response = await clsBandRequests.GetBandInfo(bandId);
            string response2 = await Bands.Requests.clsBandRequests.getBandAlbums(bandId);
           
            string response4 = await Bands.Requests.clsBandRequests.GetBandInfo(bandId);
            string response5 = await Bands.Requests.clsEventRequests.GetEvent(bandId, id);
            System.Diagnostics.Debug.WriteLine(response5);
            //Hubo error
            /*if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }*/

            // clsInfoBand infoBand = DataParser.parseBandInfo(response);

            FanProfileViewModel profile = new FanProfileViewModel();
            BandProfileViewModel BandProfile = new BandProfileViewModel();
            BandProfile.Id = bandId;
            profile.BandProfile = BandProfile;


            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            // profile.BandInfo = infoBand;
            profile.BandProfile.Albums = DataParser.parseAlbums(response2);
            
            profile.BandProfile.Info = DataParser.parseBandInfo(response4);
            profile.BandProfile.Event = DataParser.parseEvent(response5);

            return View(profile);
        }
    }
}