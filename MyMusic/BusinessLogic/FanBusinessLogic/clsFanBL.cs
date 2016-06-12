using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BusinessLogic.FanBusinessLogic
{
    public class clsFanBL
    {

        clsFacadeDA FacadeDA = new clsFacadeDA();
        clsDeserializeJson DeserializeJson = new clsDeserializeJson();
        Serializer serializer = new Serializer();

        public String getForm()
        {
            clsForm form = new clsForm();
            clsResponse response = new clsResponse();
            form = FacadeDA.getAllGenres(form,ref response);
            form = FacadeDA.getAllGenders(form,ref response);
            response.Data = serializer.Serialize(form);
            return serializer.Serialize(response);

        }

        public string createFan(string pstringRequest)
        {


            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoFan InfoFan = DeserializeJson.DeserializeFanForm(request.Data);
            clsResponse response = new clsResponse();

            InfoFan.Salt = clsHasher.genSalt();
            InfoFan.SaltHashed = clsHasher.hashPassword(InfoFan.Password, InfoFan.Salt);


            InfoFan = FacadeDA.createFan(InfoFan,ref response);
            response.Data = serializer.Serialize(InfoFan);
            return serializer.Serialize(response);
        }

     
    }
}
