using DataAccess;
using DTO;
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

        public string getEvent(int pintEventId)
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

    }
}
