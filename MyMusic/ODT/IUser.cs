using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public interface IUser
    {
        String Username { get; set; }
        String Password { get; set; }
        String Salt { get; set; }
        int Rol { get; set; }
        Boolean Active { get; set; }

    }
}