using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODT
{
    public class clsFanForm
    {
        public String Name { get; set; }
        public String Birthday { get; set; }
        public String Gender { get; set; }
        public String Country { get; set; }
        public List<String> Genres { get; set; }

        //interface atributes
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string MensageError { get; set; }

        public string CodigoError { get; set; }
        //public int Rol { get; set; }

        //test

        public object EstadoSite { get; set; }

        public object intSexo { get; set; }

        public object strSalt { get; set; }

        public object strSaltPassword { get; set; }
    }
}
