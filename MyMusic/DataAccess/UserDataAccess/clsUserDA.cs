using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserDataAccess
{
    public class clsUserDA
    {
        clsUserRead FanRead = new clsUserRead();

        public clsForm getAllGenres(clsForm pclsForm)
        {
            return FanRead.getAllgenres(pclsForm);
        }
    }
}
