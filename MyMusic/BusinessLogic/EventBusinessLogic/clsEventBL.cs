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

            //FacadeDA

            response.Data = serializer.Serialize(Event);
            return serializer.Serialize(response);
        }

        public string getEventReviews(int pintEventId)
        {
            List<clsReview> reviews = new List<clsReview>();
            clsResponse response = new clsResponse();

            //FacadeDA.geteventreviews(ref reviews, ref response, pintEventId);

            response.Data = serializer.Serialize(reviews);
            return serializer.Serialize(response);
        }

        public string reviewEvent(string pstringRequest, int pintEventId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsReview review = DeserializeJson.DeserializeReview(request.Data);
            clsResponse response = new clsResponse();

            //validar si el usuario ya habia hecho review
            //FacadeDA.getbandreviews(ref reviews, ref response, pintBandId);

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
                //Event.Id = FacadeDA.createevent(ref Event, ref response, pintBandId);
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

    }
}
