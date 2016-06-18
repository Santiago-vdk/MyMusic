using DTO;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Areas.Fans.Requests;
using MyFan_Webapp.Models.Views;
using MyFan_Webapp.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFan_Webapp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public async Task<ActionResult> image(int Id)
        {
            try
            {
                //string s = "iVBORw0KGgoAAAANSUhEUgAAABgAAAASCAIAAADOjonJAAAACXBIWXMAAAsTAAALEwEAmpwYAAACcklEQVR42pVUy05UQRSs07fvvc5lGEadIQgEDD6IEDUmosQYt8pC/R39Gvf+grhzTcJ+CD7CJMDwknnc269yMfIaRKV2nfSprlOnTksgrfORAggRBEIEAsFloJTSNvgPn3/cGUtnxrKrV3SSRBBeikhE0jTVNGplbWd51b58WFucrY5WklKiI+Eg1ekjz7AAIKlDxP3DotHs7Oz3vm91lh7VJ2vZcCnSkRzfGyg+DZJKKQBaAp31nXbe68inTtHcbL9evDE3XakOxUmshOGEa5Dj90MkAWiQsI7G5S60crPSNdt7vVePx57NX69X0yzVIuFiywgISZIaALynNXCwFvvGmtx8POhubLaXno5P1EvlUhzrC50m+26KJgBrYT18ABEEbWttbpY7prl5+Ob5xNz0SLUca61Ot0hC+nJEBBqgBgkfxDr4cGxpYWSnsKvdvN3ae7tQe3K7nGmofinIE+9FIhUqwzJU0QTgHKyBC6c1B9DlJm/3dje+bKV7WUyICHnGHoGoOJ2aHHn3XhOEc7TuiIgAEvoy8+mw88I3ptgqWATx54IlFEqUUEf9qQU6L9bCs686pa2iO++bi75RD+0UJiCYC7wWjcRZEhoEnIfzsF6RJRQ1HC749Tm/UUUvpg2A/VOEjoLtrPcENAXinRgXuyJjMcnWAtduht0hFIre/SXU/XUVGB9AahBiXGI7Jde+G5oP+LUWDhMxgSz+tWsCQKkskKRmYMZ8NBzcc41bbFaQx7CeCANCzsmSfmugA0hopTE7ntw/+FmzkrEWoT8d/ucXEiVJOj4hUSTG2r31b8V2C/C4HARgQDRUv1a5OfMLsQpx+LS8fvQAAAAASUVORK5CYII=";
                //data:image/png;base64,
                string response = await clsUserRequests.GetProfilePicture(Id);

                byte[] data = Convert.FromBase64String(response);
                return File(data, "image/png");
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }


        }

        public async Task<ActionResult> imageAlbum(int Id)
        {
            try
            {
                string response = await clsUserRequests.GetDiskPicture(Id);

                byte[] data = Convert.FromBase64String(response);
                return File(data, "image/png");
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }

        }


        public async Task<ActionResult> GetSearch()
        {
            //[Bandas,Posts]
            string response = await clsUserRequests.GetSearchParams();

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }

            Form SearchParams = DataParser.parseSearchParams(response);
            return Json(JsonConvert.SerializeObject(SearchParams), JsonRequestBehavior.AllowGet);

        }


        /*[HttpPost]
        public async Task<ActionResult> MakeSearch(string name, string country, List<int> genre)
        {
            System.Diagnostics.Debug.WriteLine(name);
            System.Diagnostics.Debug.WriteLine(country);
            System.Diagnostics.Debug.WriteLine(genre[0]);

            string response = await clsFanRequests.GetFanBands(Int32.Parse(Session["Id"].ToString()));

            clsSearch searchParams = new clsSearch();
            searchParams.Name = name;
            searchParams.Genre = genre;
            searchParams.Country = country;

            string response2 = await clsUserRequests.Search(searchParams);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life2...";
            }
            FanProfileViewModel profile = DataParser.parseFanBands(response);

            profile.SearchResults = DataParser.parseBands(response2);

            System.Diagnostics.Debug.WriteLine("search " + profile.SearchResults.Count);

            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            //return View(profile);

            
            //TempData["profile"] = profile;
            //return RedirectToAction("Search", "Fans", new { area = "Fans", userId = Session["id"] });
            return View("~/Areas/Fans/Views/Fans/Search.cshtml", profile);
            //return Json(new { result = "Redirect", url = Url.Action("Search", "Fans") });
        }*/


    }


}