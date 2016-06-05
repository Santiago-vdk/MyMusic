using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsFanDA
    {
        clsFanRead FanRead = new clsFanRead();
        public clsForm getAllGenders(clsForm pclsForm)
        {
            return FanRead.getAllgenders(pclsForm);
        }
    }
}
