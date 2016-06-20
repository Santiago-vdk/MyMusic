using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EventsDataAccess
{
    public class clsEventsDA
    {
        clsEventsRead EventsRead = new clsEventsRead();
        clsEventsWrite EventsWrite = new clsEventsWrite();

        public int createEvent(ref clsEvent pclsEvent, ref clsResponse pclsResponse, int pintUserCode)
        {
            return EventsWrite.createEvent(ref pclsEvent, ref pclsResponse, pintUserCode);
        }
        public void changeStateEvent(String State, ref clsResponse pclsResponse, int pintEventCode)
        {
            EventsWrite.changeStateEvent(State, ref pclsResponse, pintEventCode);
        }
        public void geteventreviews(ref List<clsReview> pclsReviews, ref clsResponse pclsResponse, int pintEventCode)
        {
            EventsRead.geteventreviews(ref pclsReviews, ref pclsResponse, pintEventCode);
        }
        public void geteventinfo(ref clsEvent pclsEvent, ref clsResponse pclsResponse, int pintEventCode)
        {
            EventsRead.geteventinfo(ref pclsEvent, ref pclsResponse, pintEventCode);
        }
        public void createEventReview(ref clsReview pclsReview, ref clsResponse pclsResponse, int pintUserCode, int pintCodeEvent)
        {
            EventsWrite.createEventReview(ref pclsReview, ref pclsResponse, pintUserCode, pintCodeEvent);
        }
        public bool existreviewevent(int pintCodDisk, int pintUserCode, ref clsResponse pclsResponse)
        {
            return EventsRead.existreviewevent(pintCodDisk, pintUserCode, ref pclsResponse);
        }
        public void getEventReviewFan(ref clsReview pclsReview, int pintCodEvent, int pintUserCode, ref clsResponse pclsResponse)
        {
            EventsRead.getEventReviewFan(ref pclsReview, pintCodEvent, pintUserCode, ref pclsResponse);
        }
        public void deleteEventReview(ref clsResponse pclsResponse, int pintUserCode, int pintCodeEvent)
        {
            EventsWrite.deleteEventReview(ref pclsResponse, pintUserCode, pintCodeEvent);
        }
    }
}
