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
    public class BandControllerCallsGetForm : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        public BandControllerCallsGetForm(HttpRequestMessage request)
        {
            _request = request;
            _facade = new FacadeBL();
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {

                Content = new StringContent(_facade.getBandForm()),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class BandControllerCallsGetAlbums : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;

        public BandControllerCallsGetAlbums(HttpRequestMessage request, int userId)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getBandInfo(_userId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class BandControllerCallsGetPosts : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;

        public BandControllerCallsGetPosts(HttpRequestMessage request, int userId)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getBandInfo(_userId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class BandControllerCallsRegisterBand : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        public BandControllerCallsRegisterBand(HttpRequestMessage request)
        {
            _request = request;
            _facade = new FacadeBL();
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.createBand(_request.Content.ReadAsStringAsync().Result)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}