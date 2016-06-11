using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BandDataAccess
{
    public class clsBandDA
    {
        clsBandWrite BandWrite = new clsBandWrite();
        public clsInfoBand createBand(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {
            try
            {
                return BandWrite.createBand(pclsInfoBand, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsInfoBand;// cambiar x error
            }
        }
    }
}
