using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        clsArchiveManager ArchiveManager = new clsArchiveManager();

        public String getForm()
        {
            clsForm form = new clsForm();
            clsResponse response = new clsResponse();
            form = FacadeDA.getAllGenres(form,ref response);
            form = FacadeDA.getAllGenders(form,ref response);
            form = FacadeDA.getAllLocations(form, ref response);
            response.Data = serializer.Serialize(form);
            return serializer.Serialize(response);

        }
        public string getBands(int pintUserId, int pintOffset, int pintLimit)
        {

            clsResponse response = new clsResponse();
            clsBandsBlock BandsBlock = new clsBandsBlock();
            BandsBlock = FacadeDA.getBands(BandsBlock, ref response, pintUserId, pintOffset, pintLimit);

            response.Data = serializer.Serialize(BandsBlock);
            return serializer.Serialize(response);
        }
        public string getFanInfo(int pintFanId)
        {
            clsInfoFan InfoFan = new clsInfoFan();
            clsResponse response = new clsResponse();

            FacadeDA.getFanInfo(ref InfoFan,ref response,pintFanId);
            FacadeDA.getGenres(ref InfoFan, ref response, pintFanId);

            response.Data = serializer.Serialize(InfoFan);
            return serializer.Serialize(response);
        }

        public string searchBands(string pstringData,int pintOffset,int pintLimit)
        {
            clsSearch search = DeserializeJson.DeserializeSearch(pstringData);
            clsResponse response = new clsResponse();
            clsBandsBlock BandsBlock = new clsBandsBlock();
            BandsBlock = FacadeDA.getBandsSearch(BandsBlock,ref response,ref search,pintOffset,pintLimit);

            response.Data = serializer.Serialize(BandsBlock);
            return serializer.Serialize(response);
        }

        public string createFan(string pstringRequest)
        {

            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoFan InfoFan = DeserializeJson.DeserializeFanForm(request.Data);
            clsResponse response = new clsResponse();
            
            clsInfoUser InfoUser = new clsInfoUser();
            InfoUser.Username = InfoFan.Username;
            FacadeDA.validateUser(InfoUser, ref response);
            if (!response.Success)//not existing username
            {
                response = new clsResponse();//clear the response
                InfoFan.Salt = clsHasher.genSalt();
                InfoFan.SaltHashed = clsHasher.hashPassword(InfoFan.Password, InfoFan.Salt);
                InfoFan = FacadeDA.createFan(InfoFan, ref response);

                //save image 
                ArchiveManager.saveUserImage(InfoFan.Id,InfoFan.Picture,ref response);

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


            response.Data = serializer.Serialize(InfoFan);
            return serializer.Serialize(response);
        }
        public string updateFan(string pstringRequest,int pintFanId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoFan InfoFan = DeserializeJson.DeserializeFanForm(request.Data);
            clsResponse response = new clsResponse();

            if (InfoFan.Id == pintFanId) {
                InfoFan = FacadeDA.updateFan(InfoFan, ref response);
                if (InfoFan.Picture != null) // change image 
                {
                    ArchiveManager.updateUserImage(InfoFan.Id, InfoFan.Picture, ref response);
                }
            }
            else
            {
                //error info
                response.Success = false;
                response.Message = "Invalid Operation";
                response.Code = 401;
            }
            //Data = null
            return serializer.Serialize(response);
        }

        






         public static void Main()
        {
            clsFanBL l = new clsFanBL();
            Console.Write(l.getForm());
            Console.ReadKey();
        }
     
    }
}
