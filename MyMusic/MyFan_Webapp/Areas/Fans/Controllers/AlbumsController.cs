using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Logic;
using System;
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
            // string response = await Fans.Requests.clsBandRequests.GetBandInfo(bandId);
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
            // profile.BandInfo = infoBand;
            profile.BandProfile.Albums = DataParser.parseAlbums(response2);

            

            profile.BandProfile.Disk = DataParser.parseDisk(response3);
            profile.BandProfile.Info = DataParser.parseBandInfo(response4);
            return View(profile);
        }
    }
}