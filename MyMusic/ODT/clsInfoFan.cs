using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DTO
{
    public class clsInfoFan : IUser
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public List<string> Genres { get; set; }

        //interface atributes
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public string SaltHashed { get; set; }
        public int Rol  {get;set;}
        public bool Active {get;set;}
    }
}