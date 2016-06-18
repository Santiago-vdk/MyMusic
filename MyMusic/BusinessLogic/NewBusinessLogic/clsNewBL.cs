using DataAccess;
using DTO;
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

        public string getNew(int pintNewId)
        {
            clsNew New = new clsNew();
            clsResponse response = new clsResponse();

            //FacadeDA

            response.Data = serializer.Serialize(New);
            return serializer.Serialize(response);
        }


    }
}
