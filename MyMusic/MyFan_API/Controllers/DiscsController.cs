using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1/users/bands/{bandId}/albums/{albumId}/discs")]
    public class DiscsController : ApiController
    {
        [Route("")]
        [HttpPost]
        // api/v1/users/bands/1/albums/1/discs POST
        public IHttpActionResult CreateDisc(int bandId, int albumId)
        {
            //Endpoint for creating a disc for a band
            throw new NotImplementedException();
        }

        [Route("")]
        [HttpGet]
        // api/v1/users/bands/1/albums/1/discs GET
        public IHttpActionResult GetAllDiscs(int bandId, int albumId)
        {
            //Endpoint for retrieving all discs of an album of a band
            throw new NotImplementedException();
        }

        [Route("{discId}")]
        [HttpGet]
        // api/v1/users/bands/1/albums/1/discs/1 GET
        public IHttpActionResult GetOneDisc(int bandId, int albumId, int discId)
        {
            //Endpoint for retrieving one disc of an album of a band
            throw new NotImplementedException();
        }

        [Route("{discId}")]
        [HttpPut]
        // api/v1/users/bands/1/albums/1/discs/1 PUT
        public IHttpActionResult UpdateOneDisc(int bandId, int albumId, int discId)
        {
            //Endpoint for updating one disc of an album of a band
            throw new NotImplementedException();
        }

        [Route("{discId}")]
        [HttpDelete]
        // api/v1/users/bands/1/albums/1/discs/1 PUT
        public IHttpActionResult DeleteOneDisc(int bandId, int albumId, int discId)
        {
            //Endpoint for deleting one disc of an album of a band
            throw new NotImplementedException( );
        }
    }
}
