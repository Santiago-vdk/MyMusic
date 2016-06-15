using DataAccess.BandDataAccess;
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
        clsBandDA BandDA = new clsBandDA();

        public clsForm getAllGenres(clsForm pclsForm,ref clsResponse pclsResponse)
        {
            return UserDA.getAllGenres(pclsForm,ref pclsResponse);
        }
        public clsForm getAllLocations(clsForm pclsForm, ref clsResponse pclsResponse)
        {
            return UserDA.getAllLocations(pclsForm, ref pclsResponse);
        }
        public clsForm getAllGenders(clsForm pclsForm,ref clsResponse pclsResponse)
        {
            return FanDA.getAllGenders(pclsForm,ref pclsResponse);
        }
        public clsInfoFan createFan(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {
            return FanDA.createFan(pclsInfoFan, ref pclsResponse);
        }
        public clsInfoBand createBand(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {
            return BandDA.createBand(pclsInfoBand, ref pclsResponse);
        }
        public clsInfoFan updateFan(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {
            return FanDA.updateFan(pclsInfoFan, ref pclsResponse);
        }
        public void validateUser(clsInfoUser pclsInfoUser, ref clsResponse pclsResponse)
        {
           UserDA.validateUser(pclsInfoUser, ref pclsResponse);
        }
        public clsInfoUser getSaltPass(clsInfoUser pclsInfoUser, ref clsResponse pclsResponse)
        {
            return UserDA.getSaltPass(pclsInfoUser, ref pclsResponse);
        }
        public void validateHashTag(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {
            BandDA.validateHashTag(pclsInfoBand, ref pclsResponse);
        }
        public clsBandsBlock getBands(clsBandsBlock pclsBandsBlock, ref clsResponse pclsResponse, int pintUserID, int pintOffset, int pintLimit)
        {
            return FanDA.getBands(pclsBandsBlock, ref pclsResponse, pintUserID, pintOffset, pintLimit);
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
