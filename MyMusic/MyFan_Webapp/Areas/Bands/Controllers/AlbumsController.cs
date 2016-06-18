using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Bands.Requests;
using MyFan_Webapp.Requests.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Bands/Albums
        public ActionResult Index(int userId)
        {
            System.Diagnostics.Debug.WriteLine("check band from " + userId + " with album ");
            return View();
        }

        public async Task<ActionResult> Create(int userId)
        {
            string response = await clsBandRequests.getBandAlbums(userId);
            string response2 = await clsRegisterRequests.GetRegisterBandForm();

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }

            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();


            profile.Albums = DataParser.parseAlbums(response);
            profile.EditForm = DataParser.parseBandForm(response2);
            return View(profile);
        }

        public async Task<ActionResult> NewAlbum(string AlbumName, string DateRelease, int Genre, string profilePicture)
        {
            System.Diagnostics.Debug.WriteLine(AlbumName);
            System.Diagnostics.Debug.WriteLine(DateRelease);
            System.Diagnostics.Debug.WriteLine(Genre);
            clsAlbum form = new clsAlbum();
            form.Name = AlbumName;
            form.DateCreation = DateRelease;
            form.Genre = Genre;
            form.Picture = profilePicture;

            string response = await clsAlbumRequests.PostAlbumForm(form, Int32.Parse(Session["Id"].ToString()));

            System.Diagnostics.Debug.WriteLine(response);

            return Json("");
        }


        public ActionResult NewSong(string Name, string Duration, bool Live, bool LimitedEdition, string UrlVideo)
        {
            System.Diagnostics.Debug.WriteLine(Name);
            System.Diagnostics.Debug.WriteLine(Live);
            System.Diagnostics.Debug.WriteLine(Duration);
            System.Diagnostics.Debug.WriteLine(LimitedEdition);
            System.Diagnostics.Debug.WriteLine(UrlVideo);
            return Json("");
        }
    }
}