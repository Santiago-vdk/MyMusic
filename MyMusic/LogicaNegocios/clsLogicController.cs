using DataAccess;
using DTO;
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
        public clsFacadeDA DataController { get; set; }
    }
}
