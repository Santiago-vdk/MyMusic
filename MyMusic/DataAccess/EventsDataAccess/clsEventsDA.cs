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
    }
}
