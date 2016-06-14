using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsInfoUser : IUser
    {
        public int Id { get; set; }

        //interface atributes
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public string SaltHashed { get; set; }
        public int Rol { get; set; }
        public bool Active { get; set; }
    }
}
