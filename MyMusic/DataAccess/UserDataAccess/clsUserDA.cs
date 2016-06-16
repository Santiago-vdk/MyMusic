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
        public void validateUser(clsInfoUser pclsInfoUser, ref clsResponse pclsResponse)
        {
            try
            {
                FanRead.validateUser(pclsInfoUser, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";                   
            }

        }
        public clsInfoUser getSaltPass(clsInfoUser pclsInfoUser, ref clsResponse pclsResponse)
        {
            try
            {
                return FanRead.getSaltPass(pclsInfoUser, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsInfoUser;
            }

        }
        public void getGenres(ref clsInfoFan pclsInfoFan, ref clsResponse pclsResponse, int pintUserCode)
        {
            FanRead.getGenres(ref pclsInfoFan, ref pclsResponse, pintUserCode);
        }
    }
}
