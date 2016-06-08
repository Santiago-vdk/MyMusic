using DataAccess.FanDataAccess;
using DataAccess.UserDataAccess;
using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DataAccess
{
    public class clsFacadeDA
    {
        clsUserDA UserDA = new clsUserDA();
        clsFanDA FanDA = new clsFanDA();

        public clsForm getAllGenres(clsForm pclsForm,ref clsResponse pclsResponse)
        {
            return UserDA.getAllGenres(pclsForm,ref pclsResponse);
        }

        public clsForm getAllGenders(clsForm pclsForm,ref clsResponse pclsResponse)
        {
            return FanDA.getAllGenders(pclsForm,ref pclsResponse);
        }

        public clsInfoFan sendForm(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {
            return FanDA.sendForm(pclsInfoFan, ref pclsResponse);
        }



        public static void Main()
        {
            System.Diagnostics.Stopwatch sw = Stopwatch.StartNew();
            clsFacadeDA a = new clsFacadeDA();
            clsForm b = new clsForm();
            clsResponse c = new clsResponse();
            Serializer j = new Serializer();
            
            
            Console.WriteLine(j.Serialize(a.getAllGenres(a.getAllGenders(b,ref c),ref c)));
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Stop();
            Console.ReadKey();
        }
    }
}
