using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using Utility;

namespace BusinessLogic.BandBusinessLogic
{
    public class clsBandBL
    {
        clsFacadeDA FacadeDA = new clsFacadeDA();
        clsDeserializeJson DeserializeJson = new clsDeserializeJson();
        Serializer serializer = new Serializer();

        public String getForm()
        {
            clsForm form = new clsForm();
            clsResponse response = new clsResponse();
            form = FacadeDA.getAllGenres(form, ref response);
            form = FacadeDA.getAllLocations(form, ref response);
            response.Data = serializer.Serialize(form);
            System.Diagnostics.Debug.WriteLine(serializer.Serialize(response));
            return serializer.Serialize(response);

        }

        public string createBand(string pstringRequest)
        {

            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoBand InfoBand = DeserializeJson.DeserializeBandForm(request.Data.ToString());
            clsResponse response = new clsResponse();

            InfoBand.Salt = clsHasher.genSalt();
            InfoBand.SaltHashed = clsHasher.hashPassword(InfoBand.Password, InfoBand.Salt);

            InfoBand = FacadeDA.createBand(InfoBand, ref response);
            response.Data = serializer.Serialize(InfoBand);
            return serializer.Serialize(response);
        }

        public string checkHashtag(string pstringHashtag)
        {
            clsResponse response = new clsResponse();
            //llamar a DA a validar existencia
            //response.Data = serializer.Serialize(user);
            return serializer.Serialize(response);

        }
    }
}
