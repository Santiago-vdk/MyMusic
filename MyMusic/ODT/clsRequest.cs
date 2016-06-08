using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsRequest
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string Data { get; set; }

        public clsRequest(string pStringToken, int pIntId, string pStringData)
        {
            Token = pStringToken;
            Id = pIntId;
            Data = pStringData;
        }
    }
}
