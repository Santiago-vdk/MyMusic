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

        public async Task<ActionResult> NewEvent(int userId, string EventTitle, string EventDate, string EventTime, bool EventType, 
            string EventState, string EventLocation, string EventContent)
        {

            System.Diagnostics.Debug.WriteLine(userId);
            System.Diagnostics.Debug.WriteLine(EventTitle);
            System.Diagnostics.Debug.WriteLine(EventDate);
            System.Diagnostics.Debug.WriteLine(EventTime);
            System.Diagnostics.Debug.WriteLine(EventType);
            System.Diagnostics.Debug.WriteLine(EventState);
            System.Diagnostics.Debug.WriteLine(EventLocation);
            System.Diagnostics.Debug.WriteLine(EventContent);

            clsEvent form = new clsEvent();
            form.Date = EventDate;
            form.Description = EventContent;
            form.IsConcert = EventType;
            form.State = EventState;
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