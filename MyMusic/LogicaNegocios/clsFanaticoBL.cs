using AccesoDatos;
using DTO;
using ODT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class clsFanaticoBL
    {


        public List<clsDoubleValue> obtenerListaSexos()
        {
            clsFanaticoDA objFanaticoDA = new clsFanaticoDA();
            return objFanaticoDA.obtenerListaSexos();
        }

        public clsInfoFan crearFanatico(clsInfoFan pFanatico)
        {
            
            return pFanatico;
        }

    }
}
