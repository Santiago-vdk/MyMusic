using DTO;
using MyFan_Webapp;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Areas.Fans.Requests;
using MyFan_Webapp.Models.Views;
using MyFan_Webapp.Requests;
using MyFan_Webapp.Requests.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFest_Webapp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Genres()
        {
            string response = await clsRegisterRequests.GetRegisterBandForm();
            List<Genre> genres = new List<Genre>();
            genres = DataParser.parseBandForm(response).genres;


            System.Diagnostics.Debug.WriteLine(genres[0].Name);



            FanProfileViewModel model = new FanProfileViewModel();
            model.Genres = genres;
            
            return View(model);
        }

        public async Task<ActionResult> CreateGenres(string name)
        {

            System.Diagnostics.Debug.WriteLine(name);
            string response2 = await clsUserRequests.CreateNewGenre(name);

            return Json("");
        }

        public async Task<ActionResult> Search(string name, string country, string genre)
        {
           
            clsSearch searchParams = new clsSearch();
            searchParams.Name = name;
            searchParams.Genre = genre;
            searchParams.Country = country;

            string response2 = await clsUserRequests.Search(searchParams);

            System.Diagnostics.Debug.WriteLine("search " + response2);


            FanProfileViewModel profile = new FanProfileViewModel();

            profile.SearchResults = DataParser.parseBands(response2);
            return View(profile);
        }




        public async Task<ActionResult> Dashboard(string name, string country, string genre)
        {

            clsSearch searchParams = new clsSearch();
            searchParams.Name = name;
            searchParams.Genre = genre;
            searchParams.Country = country;

            string response2 = await clsUserRequests.Search(searchParams);

            System.Diagnostics.Debug.WriteLine("search " + response2);


            FanProfileViewModel profile = new FanProfileViewModel();

            profile.SearchResults = DataParser.parseBands(response2);
            return View(profile);
        }

    }
}