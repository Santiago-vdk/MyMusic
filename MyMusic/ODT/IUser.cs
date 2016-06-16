using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
        string Salt { get; set; }
        string SaltHashed { get; set; }
        int Rol { get; set; }
        bool Active { get; set; }

        List<int> CodGenres { get; set; }
        List<string> Genres { get; set; }
    }
}