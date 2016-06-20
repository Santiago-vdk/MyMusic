using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyFan_API.ControllerCalls
{

    public class AlbumControllerCallsCreateAlbum : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;


        public AlbumControllerCallsCreateAlbum(HttpRequestMessage request, int userId)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.createDisk(_request.Content.ReadAsStringAsync().Result, _userId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class AlbumControllerCallsGetAlbum : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        int _albumId;

        public AlbumControllerCallsGetAlbum(HttpRequestMessage request, int albumId)
        {
            _request = request;
            _facade = new FacadeBL();

            _albumId = albumId;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getDiskInfo(_albumId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }




    public class AlbumControllerCallsGetReviews : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        int _albumId;

        public AlbumControllerCallsGetReviews(HttpRequestMessage request, int albumId)
        {
            _request = request;
            _facade = new FacadeBL();

            _albumId = albumId;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getDiskReviews(_albumId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class AlbumControllerCallsGetReview : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        int _albumId;

        public AlbumControllerCallsGetReview(HttpRequestMessage request, int albumId)
        {
            _request = request;
            _facade = new FacadeBL();

            _albumId = albumId;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getOwnDiskReview(_request.Content.ReadAsStringAsync().Result, _albumId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}