using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BusinessLogic.NewBusinessLogic
{
    public class clsNewBL
    {
        clsFacadeDA FacadeDA = new clsFacadeDA();
        clsDeserializeJson DeserializeJson = new clsDeserializeJson();
        Serializer serializer = new Serializer();


        public string createNew(string pstringRequest,int pintBandId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsNew New = DeserializeJson.DeserializeNew(request.Data.ToString());
            clsResponse response = new clsResponse();

            if (request.Id == pintBandId)
            {
                New.Id = FacadeDA.createnew(ref New, ref response, pintBandId);
            }

            New.BandName = null;
            New.Content = null;
            New.Date = null;
            New.Title = null;

            response.Data = serializer.Serialize(New);
            return serializer.Serialize(response);
        }
        public string getNewInfo(int pintNewId)
        {
            clsNew New = new clsNew();
            clsResponse response = new clsResponse();

            FacadeDA.getnew(ref New,ref response,pintNewId);

            New.Id = pintNewId;
            response.Data = serializer.Serialize(New);
            return serializer.Serialize(response);
        }


    }
}
