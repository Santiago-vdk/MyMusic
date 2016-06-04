using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            throw new NotImplementedException();
        }

        [Route(""), HttpGet]
        // api/v1/users/bands GET
        public IHttpActionResult GetAllBands()
        {
            //Endpoint for retrieving all bands
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
