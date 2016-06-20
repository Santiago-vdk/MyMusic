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
    public class EventControllerCallsCreateEvent : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;


        public EventControllerCallsCreateEvent(HttpRequestMessage request, int userId)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.createEvent(_request.Content.ReadAsStringAsync().Result, _userId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class EventControllerCallGetEvent : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _eventId;


        public EventControllerCallGetEvent(HttpRequestMessage request, int eventId)
        {
            _request = request;
            _facade = new FacadeBL();
            _eventId = eventId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getEventInfo( _eventId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class EventControllerCallUpdateEvent : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _eventId;
        string _value;

        public EventControllerCallUpdateEvent(HttpRequestMessage request, int eventId, string value)
        {
            _request = request;
            _facade = new FacadeBL();
            _eventId = eventId;
            _value = value;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.changeEventState(_value,_eventId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }


    public class EventControllerCallDeleteEventReview : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        int _eventId;

        public EventControllerCallDeleteEventReview(HttpRequestMessage request, int eventId)
        {
            _request = request;
            _facade = new FacadeBL();


        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.deleteEventReview(_request.Content.ReadAsStringAsync().Result, _eventId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
    




   public class EventControllerCallGetEventReviews : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _eventId;


        public EventControllerCallGetEventReviews(HttpRequestMessage request, int eventId)
        {
            _request = request;
            _facade = new FacadeBL();
            _eventId = eventId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getEventReviews(_eventId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class EventControllerCallGetEventReview : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _eventId;


        public EventControllerCallGetEventReview(HttpRequestMessage request, int eventId)
        {
            _request = request;
            _facade = new FacadeBL();
            _eventId = eventId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getOwnEventReview(_request.Content.ReadAsStringAsync().Result,_eventId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

}