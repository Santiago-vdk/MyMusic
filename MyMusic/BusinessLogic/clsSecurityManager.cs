using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BusinessLogic
{
    class clsSecurityManager
    {
        public void register(IUser pIUser)
        {
            string salt = clsHasher.genSalt();
            string password = clsHasher.hashPassword(pIUser.Password, salt);
        }

        public void login(IUser pIUser)
        {
            string salt = clsHasher.genSalt();
            string password1 = clsHasher.hashPassword(pIUser.Password, salt);

            string password2 = ""; //llamar a DA para password guardada

            bool match = clsHasher.compare(password1, password2);

        }
    }
}
