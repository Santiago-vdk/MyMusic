using DTO;
using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Areas.Fans.Requests;
using MyFan_Webapp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class BandsController : Controller
    {
        // GET: Fans/Bands
        public async Task<ActionResult> Index(int userId, int bandId)
        {
            System.Diagnostics.Debug.WriteLine("Checking band from " + userId + " of " + bandId);

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
            string response3 = await Bands.Requests.clsBandRequests.GetBandPosts(bandId);
            string response4 = await Bands.Requests.clsBandRequests.GetBandInfo(bandId);
            System.Diagnostics.Debug.WriteLine(response);
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

            profile.BandProfile.Reviews = DataParser.parseReviews(response);
            profile.BandProfile.Albums = DataParser.parseAlbums(response2);
            profile.BandProfile.Posts = DataParser.parsePosts(response3);
            profile.BandProfile.Info = DataParser.parseBandInfo(response4);

            return View(profile);


        }

        public async Task<ActionResult> PostReview(int fanId, int bandId, string rate, string comment, string fanName)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " posting review " + bandId + " on band  " + rate + " " + comment);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await Bands.Requests.clsBandRequests.PostReview(fanId, bandId, rate, comment, fanName);
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


        public async Task<ActionResult> DeleteReview(int fanId, int bandId)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " deleting review " + bandId);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await Bands.Requests.clsBandRequests.DeleteReview(fanId, bandId);
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