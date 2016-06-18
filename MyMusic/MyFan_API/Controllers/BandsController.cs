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
            System.Diagnostics.Debug.WriteLine(Request.Content.ReadAsStringAsync().Result);
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
        public IHttpActionResult GetOneBand(int bandId, string q, int offset = 0, int limit = 5)
        {
            if (String.Equals(q, "albums"))
            {
                return new BandControllerCallsGetAlbums(Request, bandId, offset, limit);
            }
            if (String.Equals(q, "posts"))
            {
                return new BandControllerCallsGetPosts(Request, bandId, offset, limit);
            }
            if (String.Equals(q, "all"))
            {
                System.Diagnostics.Debug.WriteLine("Getting all info for band " + bandId);
                return new BandControllerCallsGetProfile(Request, bandId);
            }
            //Endpoint for retrieving one band
            throw new NotImplementedException();
        }

        [Route("{bandId}"), HttpPut]
        // api/v1/users/bands/1 PUT
        public IHttpActionResult UpdateOneBand(int bandId)
        {
            System.Diagnostics.Debug.WriteLine("Updating fan with id " + bandId);
            System.Diagnostics.Debug.WriteLine("with data " + Request.Content.ReadAsStringAsync().Result);

            return new BandControllerCallsUpdateProfile(Request, bandId);

            //Endpoint for updating one fan
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
        public IHttpActionResult ReviewOneBand(int bandId, string q)
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
