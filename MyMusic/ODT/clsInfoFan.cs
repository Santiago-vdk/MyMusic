using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class clsInfoFan : IUser
    {
        public String Name { get; set; }
        public String Birthday { get; set; }
        public String Gender { get; set; }
        public String Country { get; set; }
        public List<String> Genres { get; set; }

        //interface atributes
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Rol  {get;set;}
        public bool Active {get;set;}
    }
}