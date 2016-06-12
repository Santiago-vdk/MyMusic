using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp
{
    public class GetRegisterFanForm {
        

        public List<string> genres { get; set; }
        public List<string> genders { get; set; }
        public List<int> gendersid { get; set; }

    }

    //{"genres":[{"intCodigo":1,"strDescripcion":"Rock"},{"intCodigo":2,"strDescripcion":"Pop"},{"intCodigo":3,"strDescripcion":"Metal"},{"intCodigo":4,"strDescripcion":"Salsa"}],"genders":[{"intCodigo":1,"strDescripcion":"Femenino"},{"intCodigo":2,"strDescripcion":"Masculino"}]}
}