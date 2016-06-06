using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp
{
    public class PostRegisterFormFan
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string[] MusicalGenres { get; set; }
        public string Accept { get; set; }
    }
}