using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp
{
    public class PostRegisterFanForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public List<string> Gender { get; set; }
        public string Country { get; set; }
        public List<string> Genres { get; set; }
        public string accept { get; set; }


        /* public PostRegisterFanForm(string pStringInputUsername, string pStringInputPassword, string pStringInputConfirmPassword,
             string pStringInputName, string pStringInputBirthday, string pStringSelectGenre, string pStringSelectCountry, 
             List<string> pStringArrSelectMusicalGenres)
         {
             Username = pStringInputUsername;
             Password = pStringInputPassword;
             ConfirmPassword = pStringInputConfirmPassword;
             Name = pStringInputName;
             Birthday = pStringInputBirthday;
             Genre = pStringSelectGenre;
             Country = pStringSelectCountry;
             MusicalGenres = pStringArrSelectMusicalGenres;
         }*/
        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}