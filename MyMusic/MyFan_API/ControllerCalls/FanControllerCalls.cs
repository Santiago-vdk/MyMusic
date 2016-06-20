using BusinessLogic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyFan_API
{
    public class FanControllerCallsGetForm : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        public FanControllerCallsGetForm(HttpRequestMessage request)
        {
            _request = request;
            _facade = new FacadeBL();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getFanForm()),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class FanControllerCallsGetSearchParams : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        public FanControllerCallsGetSearchParams(HttpRequestMessage request)
        {
            _request = request;
            _facade = new FacadeBL();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getSearchParams()),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }

    }

    public class FanControllerCallsRegisterFan : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        public FanControllerCallsRegisterFan(HttpRequestMessage request)
        {
            _request = request;
            _facade = new FacadeBL();
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.createFan(_request.Content.ReadAsStringAsync().Result)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
    public class FanControllerCallsGetPosts : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;
        int _offset;
        int _limit;

        public FanControllerCallsGetPosts(HttpRequestMessage request, int userId, int offset, int limit)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;
            _offset = offset;
            _limit = limit;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getPublications(_userId, _offset, _limit)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class FanControllerCallsGetBands : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;
        int _offset;
        int _limit;

        public FanControllerCallsGetBands(HttpRequestMessage request, int userId, int offset, int limit)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;
            _offset = offset;
            _limit = limit;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getBands(_userId, _offset, _limit)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class FanControllerCallsGetProfile : IHttpActionResult
    {

        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;


        public FanControllerCallsGetProfile(HttpRequestMessage request, int userId)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getFanInfo(_userId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }



    public class FanControllerCallsIsFollowing : IHttpActionResult
    {

        HttpRequestMessage _request;
        FacadeBL _facade;
        int _fanId;
        int _bandId;

        public FanControllerCallsIsFollowing(HttpRequestMessage request, int fanId, int bandId)
        {
            _request = request;
            _facade = new FacadeBL();
            _fanId = fanId;
            _bandId = bandId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.IsFollowed(_fanId, _bandId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class FanControllerCallsUpdateProfile : IHttpActionResult
    {

        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;


        public FanControllerCallsUpdateProfile(HttpRequestMessage request, int userId)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.updateFan(_request.Content.ReadAsStringAsync().Result, _userId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class FanControllerCallsFollowBand : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _fanId;
        int _bandId;

        public FanControllerCallsFollowBand(HttpRequestMessage request, int fanId, int bandId)
        {
            _request = request;
            _facade = new FacadeBL();
            _fanId = fanId;
            _bandId = bandId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.followBand(_fanId, _bandId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class FanControllerCallsUnFollowBand : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _fanId;
        int _bandId;

        public FanControllerCallsUnFollowBand(HttpRequestMessage request, int fanId, int bandId)
        {
            _request = request;
            _facade = new FacadeBL();
            _fanId = fanId;
            _bandId = bandId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.UnfollowBand(_fanId, _bandId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}