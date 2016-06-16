using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BusinessLogic.UserBusinessLogic
{
    public class clsUserBL
    {

        clsFacadeDA FacadeDA = new clsFacadeDA();
        clsDeserializeJson DeserializeJson = new clsDeserializeJson();
        Serializer serializer = new Serializer();
        clsArchiveManager ArchiveManager = new clsArchiveManager();

        public string login(string pstringRequest)
        {

            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoUser InfoUser = DeserializeJson.DeserializeInfoUser(request.Data);
            clsResponse response = new clsResponse();

            FacadeDA.validateUser(InfoUser,ref response);
            if (response.Success)//existing username
            {
                InfoUser = FacadeDA.getSaltPass(InfoUser, ref response);//get salt and password from DA
                string HashedPassword = clsHasher.hashPassword(InfoUser.Password, InfoUser.Salt);// hash the incoming password with salt from DA
                if (!(clsHasher.compare(HashedPassword, InfoUser.SaltHashed))) //compare hashed passwords
                {
                    //not match

                    //error info
                    response.Success = false;
                    response.Message = "Incorrect Username or Password";
                    response.Code = 3;
                }

                InfoUser.Password = null;
                InfoUser.Salt = null; // clear the object before sending
                InfoUser.SaltHashed = null; // clear the object before sending

            }
            

            response.Data = serializer.Serialize(InfoUser);
            return serializer.Serialize(response);

        }

        public string checkUsername(string pstringUsername)
        {

            clsInfoUser InfoUser = new clsInfoUser();
            InfoUser.Username = pstringUsername;
            clsResponse response = new clsResponse();
            
            FacadeDA.validateUser(InfoUser,ref response);
            //Data = null
            return serializer.Serialize(response);
        }

        public string getPicture(int pintUserId)
        {
            return ArchiveManager.getUserImage(pintUserId);
            
        }
        public string getPublications(int pintUserId, int pintOffset,int pintLimit)
        {
            clsResponse response = new clsResponse();
            List<clsPublication> publications = FacadeDA.getWall(ref response,pintUserId,pintOffset,pintLimit);

            

            response.Data = serializer.Serialize(publications);
            return serializer.Serialize(response);
        }
        public string getSearchParams()
        {
            clsForm form = new clsForm();
            clsResponse response = new clsResponse();
            form = FacadeDA.getAllGenres(form,ref response);
            form = FacadeDA.getAllLocations(form, ref response);

            response.Data = serializer.Serialize(form);
            return serializer.Serialize(response);
        }
    }
}
