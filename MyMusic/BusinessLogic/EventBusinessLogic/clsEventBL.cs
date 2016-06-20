using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BusinessLogic.EventBusinessLogic
{
    public class clsEventBL
    {
        clsFacadeDA FacadeDA = new clsFacadeDA();
        clsDeserializeJson DeserializeJson = new clsDeserializeJson();
        Serializer serializer = new Serializer();

        public string getEventInfo(int pintEventId)
        {
            clsEvent Event = new clsEvent();
            clsResponse response = new clsResponse();

            FacadeDA.geteventinfo(ref Event,ref response,pintEventId);

            response.Data = serializer.Serialize(Event);
            return serializer.Serialize(response);
        }

        public string getEventReviews( int pintEventId)
        {
            List<clsReview> reviews = new List<clsReview>();
            clsResponse response = new clsResponse();

            FacadeDA.geteventreviews(ref reviews, ref response, pintEventId);

            response.Data = serializer.Serialize(reviews);
            return serializer.Serialize(response);
        }

        public string getOwnEventReview(string pstringRequest, int pintEventId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsReview review = new clsReview();
            clsResponse response = new clsResponse();

            FacadeDA.getEventReviewFan(ref review, pintEventId,request.Id, ref response);

            response.Data = serializer.Serialize(review);
            return serializer.Serialize(response);
        }

        public string reviewEvent(string pstringRequest, int pintEventId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsReview review = DeserializeJson.DeserializeReview(request.Data);
            clsResponse response = new clsResponse();

            bool existReview = FacadeDA.existreviewevent(pintEventId, request.Id, ref response);
            if (!existReview && response.Success)
            {
                FacadeDA.createEventReview(ref review,ref response, request.Id, pintEventId);
            }
            //data null
            return serializer.Serialize(response);
        }

        public string createEvent(string pstringRequest, int pintBandId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsEvent Event = DeserializeJson.DeserializeEvent(request.Data.ToString());
            clsResponse response = new clsResponse();

            if (request.Id == pintBandId)
            {
                Event.Id = FacadeDA.createEvent(ref Event, ref response, pintBandId);
            }

            Event.Title = null;
            Event.Description = null;
            Event.State = null;
            Event.Location = null;
            Event.IsConcert = false;
            Event.Title = null;

            response.Data = serializer.Serialize(Event);
            return serializer.Serialize(response);
        }

        public string changeState(string pstringState,int pintEventId)
        {
            clsResponse response = new clsResponse();
            FacadeDA.changeStateEvent(pstringState,ref response,pintEventId);

            //data bull
            return serializer.Serialize(response);

        }

        public string deleteEventReview(string pstringRequest, int pintEventId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsResponse response = new clsResponse();

            FacadeDA.deleteEventReview(ref response,request.Id, pintEventId);

            return serializer.Serialize(response);
        }

    }
}
