
using AccesoDatos;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class clsAlbumBL
    {
         clsJsonParser JsonParser { get; set; }

         clsErrorValidator ErrorValidator { get; set; }
        public clsFacadeDA DataController { get; set; }
    }
}
