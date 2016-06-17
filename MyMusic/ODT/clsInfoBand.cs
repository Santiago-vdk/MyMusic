using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DTO
{
    public class clsInfoBand : IUser
    {
        public string Name { get; set; }
        public string DateCreation { get; set; }
        public string Country { get; set; }
        public string Hashtag { get; set; }
        public List<string> Members { get; set; }
        public List<int> CodMembers { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }
        public int Id { get; set; }

        //interface atributes
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Rol { get; set; }
        public bool Active { get; set; }
        public string SaltHashed { get; set; }


        public List<int> CodGenres { get; set; }
        public List<string> Genres { get; set; }
    }
}