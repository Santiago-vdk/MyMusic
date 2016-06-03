using ODT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    class clsDataController
    {
        public clsRead Read { get; set; }
        public clsWrite Write { get; set; }

        public void updateFan(List<clsInfoFan> pData)
        {
            Write.updateFan(pData);
        }
        public void createUser(List<clsUser> pData)
        {
            Write.createUser(pData);
        }
        public void insertDisc(List<clsDisc> pData)
        {
            Write.insertDisc(pData);
        }
        public void updateDisc(List<clsDisc> pData)
        {
            Write.updateDisc(pData);
        }
    }
}
