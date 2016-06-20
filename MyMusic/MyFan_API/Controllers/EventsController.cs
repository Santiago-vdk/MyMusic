using MyFan_API.ControllerCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1/users/bands/{bandId}/events")]
    public class EventsController : ApiController
    {
        [Route(""), HttpPost]
        // api/v1/users/bands/1/events POST
        public IHttpActionResult CreateEvent(int bandId)
        {
            return new EventControllerCallsCreateEvent(Request, bandId);

            //Endpoint for creating an event for a band
            throw new NotImplementedException();
        }

        [Route("")]
        [HttpGet]
        // api/v1/users/bands/1/events GET
        public IHttpActionResult GetAllEvents(int bandId)
        {



            //Endpoint for retrieving all events of a band
            throw new NotImplementedException();
        }

        [Route("{eventId}"), HttpGet]
        // api/v1/users/bands/1/events/1 GET
        public IHttpActionResult GetOneEvent(int bandId, int eventId, string q = "")
        {
            if (String.Equals(q, "reviews"))
            {
                System.Diagnostics.Debug.WriteLine("En api trayendo los reviews " + Request);
                return new EventControllerCallGetEventReviews(Request, eventId);
            }


            return new EventControllerCallGetEvent(Request, eventId);

            //Endpoint for retrieving one event of a band
            throw new NotImplementedException();
        }

        [Route("{eventId}"), HttpPut]
        // api/v1/users/bands/1/events/1 PUT
        public IHttpActionResult UpdateOneEvent(int bandId, int eventId, string value = "", string q = "")
        {
            if (String.Equals(q, "state"))
            {
                return new EventControllerCallUpdateEvent(Request, eventId, value);
            }
            if (String.Equals(q, "delete"))
            {
                return new EventControllerCallDeleteEventReview(Request, eventId);
            }
            if (String.Equals(q, "review"))
            {
                System.Diagnostics.Debug.WriteLine("En api" + Request);
                return new EventControllerCallReviewEvent(Request, eventId);
            }
            return new EventControllerCallUpdateEvent(Request, eventId, value);
            //Endpoint for updating one event of a band
            throw new NotImplementedException();
        }

        [Route("{eventId}")]
        [HttpDelete]
        // api/v1/users/bands/1/events/1 DELETE
        public IHttpActionResult DeleteOneEvent(int bandId, int eventId, string value = "", string q = "")
        {
           


            //Endpoint for deleting one event of a band
            throw new NotImplementedException();
        }

    }
}
