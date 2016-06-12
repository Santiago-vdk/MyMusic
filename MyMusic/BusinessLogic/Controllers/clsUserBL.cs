using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BusinessLogic.Controllers
{
    public class clsUserBL
    {

        clsFacadeDA FacadeDA = new clsFacadeDA();
        clsDeserializeJson DeserializeJson = new clsDeserializeJson();
        Serializer serializer = new Serializer();

        public string login(string pstringRequest)
        {

            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoUser InfoUser = DeserializeJson.DeserializeInfoUser(request.Data);
            clsResponse response = new clsResponse();

            FacadeDA.validateUser(InfoUser,ref response);

            if (response.Success)//validar username
            {
                InfoUser = FacadeDA.getSaltPass(InfoUser, ref response);//get salt and password from DA
                string HashedPassword = clsHasher.hashPassword(InfoUser.Password, InfoUser.Salt);// hash the incoming password with salt from DA
                if ((clsHasher.compare(HashedPassword, InfoUser.SaltHashed))) //incorrect password
                {
                    //successful login
                    response.Data = serializer.Serialize(InfoUser);
                    return serializer.Serialize(response);
                }

            }
            //error info
            response.Success = false;
            response.Message = "Incorrect Username or Password";
            response.Code = 3;

            response.Data = serializer.Serialize(InfoUser);
            return serializer.Serialize(response);

        }

        public string checkUsername(string pstringRequest)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoUser InfoUser = DeserializeJson.DeserializeInfoUser(request.Data.ToString());
            clsResponse response = new clsResponse();
            
            FacadeDA.validateUser(InfoUser,ref response);
            //Data = null
            return serializer.Serialize(response);
        }


    }
}
