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
        clsFanWrite FanWrite = new clsFanWrite();
        public clsForm getAllGenders(clsForm pclsForm,ref clsResponse pclsResponse)
        {
            try
            {
                return FanRead.getAllgenders(pclsForm,ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsForm;// cambiar x error
            }
        }

        public clsInfoFan sendForm(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {
            try
            {
                return FanWrite.crearFanatico(pclsInfoFan, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsInfoFan;// cambiar x error
            }
        }
    }
}
