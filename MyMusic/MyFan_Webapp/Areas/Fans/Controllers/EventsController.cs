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
            string response = await Bands.Requests.clsBandRequests.GetBandReviews(bandId);
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
            profile.BandProfile.Reviews = DataParser.parseReviews(response);
            profile.BandProfile.Info = DataParser.parseBandInfo(response4);
            profile.BandProfile.Event = DataParser.parseEvent(response5);
            profile.BandProfile.Event.Id = id;

            return View(profile);
        }

        public async Task<ActionResult> Reviews(int fanId, int bandId, int eventId)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " getting all revies from " + bandId + " of event " + eventId);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await Bands.Requests.clsEventRequests.GetAllEventReviews(bandId, eventId);
                System.Diagnostics.Debug.WriteLine(response);

                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = "Something went wrong";
                    return Json(new { state = "False" });
                }

                return Json(DataParser.parseReviews(response));
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }
        }


        public async Task<ActionResult> Review(int fanId, int bandId, int eventId)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " getting one review from " + bandId + " of event " + eventId);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await Bands.Requests.clsEventRequests.GetEventReview(fanId, bandId, eventId);
                System.Diagnostics.Debug.WriteLine(response);

                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = "Something went wrong";
                    return Json(new { state = "False" });
                }

                return Json(DataParser.parseReviews(response));
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }
        }

        public async Task<ActionResult> PostReview(int fanId, int bandId, int eventId, string rate, string comment, string fanName)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " posting review " + bandId + " on band  " + rate + " " + comment);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await Bands.Requests.clsEventRequests.PostReview(fanId, bandId, eventId, rate, comment, fanName);
                System.Diagnostics.Debug.WriteLine(response);

                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = "Something went wrong";
                    return Json(new { state = "False" });
                }

                return Json("", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }
        }
    }
}