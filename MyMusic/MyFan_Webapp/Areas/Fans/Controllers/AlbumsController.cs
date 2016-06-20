using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Logic;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Fans/Albums
        public async System.Threading.Tasks.Task<ActionResult> Index(int userId, int bandId, int id)
        {
            System.Diagnostics.Debug.WriteLine("check band from " + userId + " of band " + bandId + " with album " + id);


            // try { } catch ()
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
            string response3 = await Bands.Requests.clsAlbumRequests.GetAlbumInfo(bandId, id);
            string response4 = await Bands.Requests.clsBandRequests.GetBandInfo(bandId);
            System.Diagnostics.Debug.WriteLine(response4);
            //Hubo error
            /* if (!ErrorParser.parse(response).Equals(""))
             {
                 ViewBag.Message = "Fuck my life...";
             }*/

            //clsInfoBand infoBand = DataParser.parseBandInfo(response);

            FanProfileViewModel profile = new FanProfileViewModel();
            BandProfileViewModel BandProfile = new BandProfileViewModel();
            BandProfile.Id = bandId;
            profile.BandProfile = BandProfile;

            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();

            profile.BandProfile.Reviews = DataParser.parseReviews(response);
            profile.BandProfile.Albums = DataParser.parseAlbums(response2);
            profile.BandProfile.Disk = DataParser.parseDisk(response3);
            profile.BandProfile.Info = DataParser.parseBandInfo(response4);
            
            return View(profile);
        }

        public async Task<ActionResult> Reviews(int fanId, int bandId, int albumId)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " getting revies from " + bandId + " of album " + albumId);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await Bands.Requests.clsAlbumRequests.GetAlbumReviews(bandId, albumId);
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



    }
}