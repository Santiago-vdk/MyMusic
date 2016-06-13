using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsBandsBlock
    {
        public int Offset { get; set; }
        public int Chunks { get; set; }
        public int FanCod { get; set; }
        public List<string> BandsId { get; set; }
        public List<string> BandsName { get; set; }
        public Boolean Limit { get; set; }
    }
}
