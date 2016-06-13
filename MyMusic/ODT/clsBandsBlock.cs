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
        public int Limit { get; set; }
        public List<string> BandsId { get; set; }
        public List<string> BandsName { get; set; }
    }
}
