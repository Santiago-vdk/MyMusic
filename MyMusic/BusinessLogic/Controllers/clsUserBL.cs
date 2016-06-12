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

            IUser user = new clsInfoUser();
            //llenar el objeto llamando al DA con el username de pIUser
            if (false)//validar username
            {
                string password1 = clsHasher.hashPassword(InfoUser.Password, user.Salt);


                if(clsHasher.compare(password1, user.SaltHashed))
                {
                    
                }

            }

            response.Data = serializer.Serialize(user);
            return serializer.Serialize(response);

            

        }

        public string checkUsername(string pstringUsername)
        {
            clsResponse response = new clsResponse();
            //llamar a DA a validar existencia
            //response.Data = serializer.Serialize(user);
            return serializer.Serialize(response);
        }


    }
}
