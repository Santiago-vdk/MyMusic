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

        public clsForm getAllGenres(clsForm pclsForm, ref clsResponse pclsResponse)
        {
            try
            {
                return FanRead.getAllgenres(pclsForm,ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsForm;//cambiar por error
            }

        }
        public clsForm getAllLocations(clsForm pclsForm, ref clsResponse pclsResponse)
        {
            try
            {
                return FanRead.getAllLocations(pclsForm, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsForm;//cambiar por error
            }

        }

    }
}
