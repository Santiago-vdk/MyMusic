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
    public class EventsController : Controller
    {
        // GET: Bands/Events
        public async Task<ActionResult> Index(int userId, int id)
        {
            System.Diagnostics.Debug.WriteLine("check band from " + userId + " with event " + id);

            string response = await clsBandRequests.getBandAlbums(userId);

            string response2 = await clsEventRequests.GetEvent(userId, id);
            System.Diagnostics.Debug.WriteLine("antes de parsear event " + response2);
            if (!ErrorParser.parse(response2).Equals(""))
            {
                ViewBag.Message = "Couldn´t get the news correctly";
            }

            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();

            profile.Albums = DataParser.parseAlbums(response);
            profile.Event = DataParser.parseEvent(response2);
            profile.Event.Id = id;
            return View(profile);
        }


        public async Task<ActionResult> Create(int userId)
        {
            string response = await clsBandRequests.getBandAlbums(userId);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Something wrong with, create event";
            }

            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();

            profile.Albums = DataParser.parseAlbums(response);

            return View(profile);
        }

        public async Task<ActionResult> Update(int userId, int id, string value)
        {

            System.Diagnostics.Debug.WriteLine("UPDATING EVENT" + userId + " " + id + " " + value);
               string response = await clsEventRequests.UpdateEvent(userId,id,value);

             

               BandProfileViewModel profile = new BandProfileViewModel();
               profile.Id = Int32.Parse(Session["Id"].ToString());
               profile.Username = Session["Username"].ToString();
               profile.Name = Session["Name"].ToString();

             

            return Json("");
        }

        public async Task<ActionResult> Delete(int userId, int id, string value)
        {

            System.Diagnostics.Debug.WriteLine("UPDATING EVENT" + userId + " " + id + " " + value);
            string response = await clsEventRequests.DeleteEvent(userId, id, value);



            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();



            return Json("");
        }

        public async Task<ActionResult> Reviews(int userId, int id)
        {
            System.Diagnostics.Debug.WriteLine(userId + " " + id);

            string response = await clsEventRequests.GetEventReviews(userId, id);
            System.Diagnostics.Debug.WriteLine(response);

            string ParsedMessage = ErrorParser.parse(response);
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = "Something went wrong";
                return Json(new { state = "False" });
            }

            return Json(DataParser.parseReviews(response));


        }


        public async Task<ActionResult> NewEvent(int userId, string EventTitle, string EventDate, string EventTime, bool EventType,
            string EventState, string EventLocation, string EventContent)
        {

            clsEvent form = new clsEvent();
            form.Date = EventDate;
            form.Description = EventContent;
            form.IsConcert = EventType;
            form.State = EventState;
            form.Location = EventLocation;
            form.Time = EventTime;
            form.Date = EventDate;
            form.Title = EventTitle;

            string response = await clsBandRequests.getBandAlbums(userId);
            string response2 = await clsEventRequests.createEvent(userId, form);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Something wrong with, create event";
            }

            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            profile.Albums = DataParser.parseAlbums(response);


            int Id = DataParser.parseEventForm(response2);
            System.Diagnostics.Debug.WriteLine("Got id: " + Id);

            return Json(new
            {
                redirectUrl = Url.Action("Index", "Events", new { userId = Int32.Parse(Session["Id"].ToString()), id = Id }),
                isRedirect = true
            });
        }

    }
}