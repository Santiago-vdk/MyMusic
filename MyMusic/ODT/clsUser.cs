using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODT
{
    public class clsUser
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Salt { get; set; }
        public int Rol { get; set; }
        public Boolean Active { get; set; }

    }
}