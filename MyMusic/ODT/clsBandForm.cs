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
        public string Name { get; set; }
        public string DateCreation { get; set; }
        public List<string> Genres { get; set; }
        public string Country { get; set; }
        public string Hashtag { get; set; }
        public List<string> Members { get; set; }
        public string Biography { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
