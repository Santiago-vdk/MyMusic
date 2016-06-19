using DTO;
using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Bands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands.Controllers
{
    public class NewsController : Controller
    {
        // GET: Bands/News
        public async Task<ActionResult> Index(int userId, int id)
        {
            System.Diagnostics.Debug.WriteLine("check band from " + userId + " with new " + id);

            string response = await clsBandRequests.getBandAlbums(userId);
            string response2 = await clsNewRequests.GetNew(userId, id);
            System.Diagnostics.Debug.WriteLine("antes de parsear " + response2);
            if (!ErrorParser.parse(response2).Equals(""))
            {
                ViewBag.Message = "Couldn´t get the news correctly";
            }

            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
           
            profile.Albums = DataParser.parseAlbums(response);
            profile.New = DataParser.parseNew(response2);

            return View(profile);
        


        }

        public async Task<ActionResult> NewNoticia(string NewTitle, string inputContent)
        {
            System.Diagnostics.Debug.WriteLine(NewTitle);
            System.Diagnostics.Debug.WriteLine(inputContent);
            clsNew form = new clsNew();
            form.Title = NewTitle;
            form.Content = inputContent;

            string response = await clsNewRequests.PostNewForm(form, Int32.Parse(Session["Id"].ToString()));
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Couldn´t get the news correctly";
            }
            System.Diagnostics.Debug.WriteLine(response);
            int Id = DataParser.parseNewForm(response);
            System.Diagnostics.Debug.WriteLine("Got id: " + Id);



          


            return Json(new
            {
                redirectUrl = Url.Action("Index", "News", new { userId = Int32.Parse(Session["Id"].ToString()), id = Id }),
                isRedirect = true
            });
        }

        public async Task<ActionResult> Create(int userId)
        {
            string response = await clsBandRequests.getBandAlbums(userId);
       

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
           
            return View(profile);
        }
    }
}