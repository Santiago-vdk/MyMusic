using DataAccess;
using DTO;
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

        public string createFan(string pstringData)
        {
            clsInfoFan InfoFan = DeserializeJson.DeserializeFanForm(pstringData);
            clsResponse response = new clsResponse();
            InfoFan = FacadeDA.sendForm(InfoFan,ref response);
            response.Data = serializer.Serialize(InfoFan);
            return serializer.Serialize(response);
        }

     
    }
}
