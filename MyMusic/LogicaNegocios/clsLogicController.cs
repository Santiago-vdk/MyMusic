using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
   public class clsLogicController
    {
         clsJsonParser JsonParser { get; set; }
         clsErrorValidator ErrorValidator { get; set; }
        public clsDataController DataController { get; set; }
    }
}
