using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsFacadeDA
    {
        clsUserDA UserDA = new clsUserDA();
        clsFanDA FanDA = new clsFanDA();

        public clsForm getAllGenres(clsForm pclsForm)
        {
            return UserDA.getAllGenres(pclsForm);
        }

        public clsForm getAllGenders(clsForm pclsForm)
        {
            return FanDA.getAllGenders(pclsForm);
        }
    }
}
