using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BusinessLogic.Controllers
{
    public class clsUserBL
    {

        public void register(IUser pIUser)
        {
            string salt = clsHasher.genSalt();
            string password = clsHasher.hashPassword(pIUser.Password,salt);
        }
    }
}
