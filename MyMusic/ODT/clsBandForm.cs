using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class clsBandForm
    {
        public String Name { get; set; }
        public String DateCreation { get; set; }
        public List<String> Genres { get; set; }
        public String Country { get; set; }
        public String Hashtag { get; set; }
        public List<clsMember> Members { get; set; }

        public string Biography { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
