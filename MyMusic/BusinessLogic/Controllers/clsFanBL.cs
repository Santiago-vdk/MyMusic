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

        public clsFacadeDA FacadeDA { get; set; }

        public void getForm()
        {
            clsForm Form = new clsForm();
            Form = FacadeDA.getAllGenres(Form);
            Form = FacadeDA.getAllGenders(Form);
           
        }

        public void createFan()
        {
            
            
        }

    }
}
