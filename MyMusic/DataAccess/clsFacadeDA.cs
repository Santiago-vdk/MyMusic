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
        clsUserDA FanDA = new clsUserDA();

        public clsForm getAllGenres(clsForm pclsForm)
        {
            return FanDA.getAllGenres(pclsForm);
        }
    }
}
