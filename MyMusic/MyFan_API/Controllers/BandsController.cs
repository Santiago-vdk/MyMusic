using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    public class BandsController : ApiController
    {
        [Route("api/v1/bands/")]
        [HttpPost]
        public IHttpActionResult CreateBand(object json) {
            System.Diagnostics.Debug.WriteLine("Created Band");
            System.Diagnostics.Debug.WriteLine(json);

            return Json(new { jobId = json });
        }

        [Route("api/v1/bands/{id}")]
        [HttpGet]
        public IHttpActionResult GetBand(int id)
        {
            System.Diagnostics.Debug.WriteLine("Got Band");
            System.Diagnostics.Debug.WriteLine(id);

            return Json(new { bandName = "Test M8" });
        }


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

    }
}
