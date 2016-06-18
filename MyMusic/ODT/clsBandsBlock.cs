using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsBandsBlock
    {
        public List<clsSimpleInfo> Bands { get; set; }
        public Boolean Limit { get; set; }

        public static implicit operator clsBandsBlock(clsInfoFan v)
        {
            throw new NotImplementedException();
        }
    }
}
