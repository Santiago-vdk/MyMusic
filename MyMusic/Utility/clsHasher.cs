using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class clsHasher
    {
        public static string genSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(13);
        }

        public static string hashPassword(string pstringPassword, string pstringSalt)
        {
            return BCrypt.Net.BCrypt.HashPassword(pstringPassword, pstringSalt);
        }

        public static bool compare(string pstringPass1,string pstringPass2)
        {
            return (pstringPass1 == pstringPass2);
        }
    }
}
