using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class clsInfoBand : IUser
    {
        public String Name { get; set; }
        public String DateCreation { get; set; }
        public List<String> Genres { get; set; }
        public String Country { get; set; }
        public String Hashtag { get; set; }
        public List<clsMember> Members { get; set; }

        //interface atributes
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Rol { get; set; }
        public bool Active { get; set; }
    }
}