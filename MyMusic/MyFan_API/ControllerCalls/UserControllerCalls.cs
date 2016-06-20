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

    public class UserControllerCallsLoginUser : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        public UserControllerCallsLoginUser(HttpRequestMessage request)
        {
            _request = request;
            _facade = new FacadeBL();
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.login(_request.Content.ReadAsStringAsync().Result)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class UserControllerCallsValidateUsername : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        string _value;

        public UserControllerCallsValidateUsername(HttpRequestMessage request, string value)
        {
            _value = value;
            _request = request;
            _facade = new FacadeBL();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.checkUsername(_value)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class UserControllerCallsGetProfilePicture : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        string _value;

        public UserControllerCallsGetProfilePicture(HttpRequestMessage request, string value)
        {
            _value = value;
            _request = request;
            _facade = new FacadeBL();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getUserPicture(_value)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class UserControllerCallsGetDiskPicture : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        string _value;

        public UserControllerCallsGetDiskPicture(HttpRequestMessage request, string value)
        {
            _value = value;
            _request = request;
            _facade = new FacadeBL();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getDiskPicture(_value)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
    public class UserControllerCallsCreateGenre : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        string _value;

        public UserControllerCallsCreateGenre(HttpRequestMessage request, string value)
        {
            _value = value;
            _request = request;
            _facade = new FacadeBL();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.createGenre(_value)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
    
    public class UserControllerCallsSearch : IHttpActionResult
    {

        HttpRequestMessage _request;
        FacadeBL _facade;
        int _offset;
        int _limit;


        public UserControllerCallsSearch(HttpRequestMessage request, int offset, int limit)
        {
            _offset = offset;
            _limit = limit;
            _request = request;
            _facade = new FacadeBL();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.searchBands(_request.Content.ReadAsStringAsync().Result, _offset, _limit)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }

    }
        
}


