using MyFan_API.ControllerCalls;
using System;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1/users/bands/{bandId}/albums")]
    public class AlbumsController : ApiController
    {
        [Route("")]
        [HttpPost]
        // api/v1/users/bands/1/albums POST
        public IHttpActionResult CreateAlbum(int bandId)
        {
            
            System.Diagnostics.Debug.WriteLine("En API Albums " + Request.Content.ReadAsStringAsync().Result);
            return new AlbumControllerCallsCreateAlbum(Request, bandId);

            
            //Endpoint for creating an album for a band
            throw new NotImplementedException();
        }

        [Route("")]
        [HttpGet]
        // api/v1/users/bands/1/albums GET
        public IHttpActionResult GetAllAlbums(int bandId)
        {
            //Endpoint for retrieving all albums of a band
            throw new NotImplementedException();
        }

        [Route("{albumId}")]
        [HttpGet]
        // api/v1/users/bands/1/albums/1 GET
        public IHttpActionResult GetOneAlbum(int bandId, int albumId)
        {
            //Endpoint for retrieving one album of a band
            throw new NotImplementedException();
        }

        [Route("{albumId}")]
        [HttpPut]
        // api/v1/users/bands/1/albums/1 PUT
        public IHttpActionResult UpdateOneAlbum(int bandId, int albumId)
        {
            //Endpoint for updating one album of a band
            throw new NotImplementedException();
        }

        [Route("{albumId}")]
        [HttpDelete]
        // api/v1/users/bands/1/albums/1 DELETE
        public IHttpActionResult DeleteOneAlbum(int bandId, int albumId)
        {
            //Endpoint for deleting one album of a band
            throw new NotImplementedException();
        }

    }
}
