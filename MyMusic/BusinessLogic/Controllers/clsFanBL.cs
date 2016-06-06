using DataAccess;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class clsFanBL
    {

        clsFacadeDA FacadeDA = new clsFacadeDA();

        public String getForm()
        {
            clsForm form = new clsForm();
            clsResponse response = new clsResponse();
            try
            {
                form = FacadeDA.getAllGenres(form,ref response);
                form = FacadeDA.getAllGenders(form,ref response);

                response.Data =  form.toJson();
            }
            catch
            {
                response.ErrorCode = 667; //Error code
                response.ErrorState = false; // fail request
                response.ErrorMessage = "Internal Error...";
                
            }

            return response.toJson();

        }

        public void createFan()
        {
            
            
        }

     
    }
}
