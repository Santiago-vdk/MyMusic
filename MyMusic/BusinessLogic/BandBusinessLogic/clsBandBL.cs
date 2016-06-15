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
        clsArchiveManager ArchiveManager = new clsArchiveManager();

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
            

            clsInfoUser InfoUser = new clsInfoUser();
            InfoUser.Username = InfoBand.Username;
            FacadeDA.validateUser(InfoUser, ref response);
            if (!response.Success)//not existing username
            {
                response = new clsResponse();//clear the response
                InfoBand.Salt = clsHasher.genSalt();
                InfoBand.SaltHashed = clsHasher.hashPassword(InfoBand.Password, InfoBand.Salt);
                InfoBand = FacadeDA.createBand(InfoBand, ref response);

                //save image here!
                ArchiveManager.saveUserImage(InfoBand.Id, InfoBand.Picture, ref response);
                InfoUser.Salt = null; // clear the object before sending
                InfoUser.SaltHashed = null; // clear the object before sending

            }
            else
            {
                //error info
                response.Success = false;
                response.Message = "Existing Username";
                response.Code = 3;
            }

            response.Data = serializer.Serialize(InfoBand);
            return serializer.Serialize(response);
        }

        public string checkHashtag(string pstringHashtag)
        {
            clsInfoBand InfoBand = new clsInfoBand();
            InfoBand.Hashtag = pstringHashtag;
            clsResponse response = new clsResponse();

            FacadeDA.validateHashTag(InfoBand, ref response);
            //Data = null
            return serializer.Serialize(response);

        }
    }
}
