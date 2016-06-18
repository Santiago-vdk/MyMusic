using DTO;
using Newtonsoft.Json;
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
            InfoFan.Genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.Genres));
            InfoFan.Name = Convert.ToString(data.Name);
            InfoFan.Password = Convert.ToString(data.Password);
            InfoFan.Username = Convert.ToString(data.Username);
            InfoFan.Picture = Convert.ToString(data.Picture);

            return InfoFan;
        }

        public clsInfoBand DeserializeBandForm(string pstringData)
        {
            clsInfoBand InfoBand = new clsInfoBand();
            dynamic data = JObject.Parse(pstringData);
            

            InfoBand.Active = true;
            InfoBand.DateCreation = Convert.ToString(data.DateCreation);
            InfoBand.Country = Convert.ToString(data.Country);
            InfoBand.Hashtag = Convert.ToString(data.Hashtag);
            InfoBand.CodGenres = JsonConvert.DeserializeObject<List<int>>(Convert.ToString(data.Genres));
            //InfoBand.Genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.Genres));
            InfoBand.Name = Convert.ToString(data.Name);
            InfoBand.Members = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.Members));
            InfoBand.Biography = Convert.ToString(data.Biography);
            InfoBand.Password = Convert.ToString(data.Password);
            InfoBand.Username = Convert.ToString(data.Username);
            InfoBand.Picture = Convert.ToString(data.Picture);

            return InfoBand;
        }

        public clsInfoUser DeserializeInfoUser(string pstringData)
        {
            clsInfoUser InfoUser = new clsInfoUser();
            dynamic data = JObject.Parse(pstringData);

            InfoUser.Username = Convert.ToString(data.Username);
            InfoUser.Password = Convert.ToString(data.Password);
            InfoUser.ConfirmPassword = Convert.ToString(data.ConfirmPassword);
            InfoUser.Active = Convert.ToBoolean(data.Active);
            InfoUser.Id = Convert.ToInt32(data.Id);
            InfoUser.Rol = Convert.ToInt32(data.Rol);

            return InfoUser;

        }

        public clsSearch DeserializeSearch(string pstringData)
        {
            clsSearch Search = new clsSearch();
            dynamic data = JObject.Parse(pstringData);

            Search = JsonConvert.DeserializeObject<clsSearch>(Convert.ToString(data));

            return Search;
        }

        public clsDisk DeserializeDisk(string pstringData)
        {
            clsDisk Disk = new clsDisk();
            dynamic data = JObject.Parse(pstringData);

            Disk = JsonConvert.DeserializeObject<clsDisk>(Convert.ToString(data));

            return Disk;
        }



    }
}
