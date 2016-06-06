using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FanDataAccess
{
    public class clsFanDA
    {
        clsFanRead FanRead = new clsFanRead();
        public clsForm getAllGenders(clsForm pclsForm,ref clsResponse pclsResponse)
        {
            try
            {
                return FanRead.getAllgenders(pclsForm,ref pclsResponse);
            }
            catch
            {
                pclsResponse.ErrorCode = 007;
                pclsResponse.ErrorState = false;
                pclsResponse.ErrorMessage = "Internal Error";
                return pclsForm;// cambiar x error
            }
        }
    }
}
