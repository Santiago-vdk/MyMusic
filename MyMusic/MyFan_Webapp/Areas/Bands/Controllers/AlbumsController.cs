using DTO;
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
        public async Task<ActionResult> Index(int userId, int Id)
        {
            //System.Diagnostics.Debug.WriteLine("check band from " + userId + " with album " + Id);
            string response = await clsBandRequests.getBandAlbums(userId);
            //System.Diagnostics.Debug.WriteLine("Soy yo 1: " + response);

            string response2 = await clsAlbumRequests.GetAlbumInfo(userId, Id);
            //System.Diagnostics.Debug.WriteLine("Soy yo: " + response2);

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
            profile.Disk = DataParser.parseDisk(response2);

            return View(profile);
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

        public async Task<ActionResult> Reviews(int userId, int id)
        {
            System.Diagnostics.Debug.WriteLine(userId + " " + id);

            string response = await clsAlbumRequests.GetAlbumReviews(userId, id);
            System.Diagnostics.Debug.WriteLine(response);

            string ParsedMessage = ErrorParser.parse(response);
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = "Something went wrong";
                return Json(new { state = "False" });
            }

            return Json(DataParser.parseReviews(response));


        }

        public async Task<ActionResult> NewAlbum(string AlbumName, string Label, string DateRelease, int Genre, string profilePicture)
        {
            System.Diagnostics.Debug.WriteLine(AlbumName);
            System.Diagnostics.Debug.WriteLine(DateRelease);
            System.Diagnostics.Debug.WriteLine(Genre);
            clsAlbum form = new clsAlbum();
            form.Name = AlbumName;
            form.DateCreation = DateRelease;
            form.Genre = Genre;
            form.Picture = profilePicture;
            form.Label = Label;

            string response = await clsAlbumRequests.PostAlbumForm(form, Int32.Parse(Session["Id"].ToString()));
            
            System.Diagnostics.Debug.WriteLine(response);
            int Id = DataParser.parseAlbumForm(response);
            System.Diagnostics.Debug.WriteLine("Got id: " + Id);
            
            
            return Json(new { albumId = Id});
        }


        public async Task<ActionResult> NewSong(int albumId, string Name, string Duration, bool Live, bool LimitedEdition, string UrlVideo)
        {
           /* System.Diagnostics.Debug.WriteLine(albumId);
            System.Diagnostics.Debug.WriteLine(Name);
            System.Diagnostics.Debug.WriteLine(Live);
            System.Diagnostics.Debug.WriteLine(Duration);
            System.Diagnostics.Debug.WriteLine(LimitedEdition);
            System.Diagnostics.Debug.WriteLine(UrlVideo);*/

            clsSong form = new clsSong();
            form.Duration = Duration;
            form.Link = UrlVideo;
            form.Name = Name;
            form.LimitedEdition = LimitedEdition;
            form.Type = Live;

            string response = await clsAlbumRequests.PostSongForm(form, Int32.Parse(Session["Id"].ToString()), albumId);
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }


            return Json(form);
        }
    }
}