using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NewsDataAccess
{
    public class clsNewsDA
    {
        clsNewsWrite NewsWrite = new clsNewsWrite();
        clsNewsRead NewsRead = new clsNewsRead();

        public int createnew(ref clsNew pclsNew, ref clsResponse pclsResponse, int pintUserCode)
        {
            return NewsWrite.createnew(ref pclsNew, ref pclsResponse, pintUserCode);
        }

        public void getnew(ref clsNew pclsNew, ref clsResponse pclsResponse, int pintCodeNew)
        {
            NewsRead.getnew(ref pclsNew, ref pclsResponse, pintCodeNew);
        }
    }
}
