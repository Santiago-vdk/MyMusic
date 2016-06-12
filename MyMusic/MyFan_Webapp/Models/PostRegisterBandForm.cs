using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Models
{
    public class PostRegisterBandForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Hashtag { get; set; }
        public string DateCreation { get; set; }
        public int Country { get; set; }
        public List<int> Genres { get; set; }
        public string Biography { get; set; }
        public string accept { get; set; }
    }
}