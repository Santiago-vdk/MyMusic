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
}