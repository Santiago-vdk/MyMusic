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
        clsUserRead UserRead = new clsUserRead();
        clsUserWrite UserWrite = new clsUserWrite();

        public clsForm getAllGenres(clsForm pclsForm, ref clsResponse pclsResponse)
        {
            try
            {
                return UserRead.getAllgenres(pclsForm, ref pclsResponse);
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
                return UserRead.getAllLocations(pclsForm, ref pclsResponse);
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
                UserRead.validateUser(pclsInfoUser, ref pclsResponse);
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
                return UserRead.getSaltPass(pclsInfoUser, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsInfoUser;
            }

        }
        public void createNewGenero(string strGenero, ref clsResponse pclsResponse)
        {
            UserWrite.createNewGenero(strGenero, ref pclsResponse);
        }
    }
}
