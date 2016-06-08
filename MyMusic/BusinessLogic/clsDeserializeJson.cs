using DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class clsDeserializeJson
    {
        public clsInfoFan DeserializeFanForm(string pstringData)
        {
            clsInfoFan InfoFan = new clsInfoFan();
            dynamic data = JObject.Parse(pstringData);

            InfoFan.Active = true;
            InfoFan.Birthday = Convert.ToString(data.Birthday);
            InfoFan.Country = Convert.ToString(data.Country);
            InfoFan.Gender = Convert.ToString(data.Gender);
            InfoFan.Genres = Convert.ToString(data.Genres);
            InfoFan.Name = Convert.ToString(data.Name);
            InfoFan.Password = Convert.ToString(data.Password);
            InfoFan.Username = Convert.ToString(data.Username);

            return InfoFan;
        }
    }
}
