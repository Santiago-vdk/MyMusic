using MyFan_API.ControllerCalls;
using System;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1/users/bands")]
    public class BandsController : ApiController
    {

        [Route(""), HttpPost]
        // api/v1/users/bands POST
        public IHttpActionResult CreateBand() {
            //Endpoint for creating a band
            return new BandControllerCallsRegisterBand(Request);
        }

        [Route(""), HttpGet]
        // api/v1/users/bands GET
        public IHttpActionResult GetAllBands(string q)
        {
            if (String.Equals(q, "form"))
            {
                return new BandControllerCallsGetForm(Request);
            }
            //Endpoint for retrieving all fans
            throw new NotImplementedException();
        }

        [Route("{bandId}"), HttpGet]
        // api/v1/users/bands/1 GET
        public IHttpActionResult GetOneBand(int bandId)
        {
            //Endpoint for retrieving one band
            throw new NotImplementedException();
        }

        [Route("{bandId}"), HttpPut]
        // api/v1/users/bands/1 PUT
        public IHttpActionResult UpdateOneBand(int bandId)
        {
            //Endpoint for updating one band
            throw new NotImplementedException();
        }

        [Route("{bandId}"), HttpDelete]
        // api/v1/users/bands/1 DELETE
        public IHttpActionResult DeleteOneBand(int bandId)
        {
            //Endpoint for deleting one band
            throw new NotImplementedException();
        }

        [Route("{bandId:int}/review"), HttpPost]
        // api/v1/users/bands/1/review POST
        public IHttpActionResult ReviewOneBand(int bandId)
        {
            //Endpoint for deleting one band
            throw new NotImplementedException();
        }

        /*
        [Route("api/v1/bands/{id}/albums")]
        [HttpGet]
        public IHttpActionResult GetAlbums(int id)
        {
            System.Diagnostics.Debug.WriteLine("Got Band");

            String r = "Showing albums from band " + id; 
            return Json(new { response = r });
        }

        [Route("api/v1/bands/{id}/albums/{albumId}")]
        [HttpGet]
        public IHttpActionResult GetAlbums(int id, int albumId)
        {
            System.Diagnostics.Debug.WriteLine("Got Band");

            String r = "Showing album " + albumId + " from band " + id;
            return Json(new { response = r });
        }
        */
    }
}
