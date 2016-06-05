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
            form = FacadeDA.getAllGenres(form);
            form = FacadeDA.getAllGenders(form);
            return form.toJson();

        }

        public void createFan()
        {
            
            
        }

     
    }
}
