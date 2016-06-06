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
                pclsResponse.ErrorCode = 007;
                pclsResponse.ErrorState = false;
                pclsResponse.ErrorMessage = "Internal Error";
                return pclsForm;//cambiar por error
            }

        }
    }
}
