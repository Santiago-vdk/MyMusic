using DataAccess.BandDataAccess;
using DataAccess.DiskDataAccess;
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
        clsDiskDA DiskDA = new clsDiskDA();

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
        public List<clsPublication> getWall(ref clsResponse pclsResponse, int pintUserID, int pintOffset, int pintLimit)
        {
            return FanDA.getWall(ref pclsResponse, pintUserID, pintOffset, pintLimit);
        }
        public void getGenresFan(ref clsInfoFan pclsInfoFan, ref clsResponse pclsResponse, int pintUserCode)
        {
            FanDA.getGenresFan(ref pclsInfoFan, ref pclsResponse, pintUserCode);
        }
        public void getFanInfo(ref clsInfoFan pclsInfoFan, ref clsResponse pclsResponse, int pintUserID)
        {
            FanDA.getFanInfo(ref pclsInfoFan, ref pclsResponse, pintUserID);
        }
        public clsBandsBlock getBandsSearch(clsBandsBlock pclsBandsBlock, ref clsResponse pclsResponse, ref clsSearch pclsSearch, int pintOffset, int pintLimit)
        {
            return FanDA.getBandsSearch(pclsBandsBlock, ref pclsResponse, ref pclsSearch, pintOffset, pintLimit);
        }
        public void getBandInfo(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserID)
        {
            BandDA.getBandInfo(ref pclsInfoBand, ref pclsResponse, pintUserID);
        }
        public void getMembersInfo(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserID)
        {
            BandDA.getMembersInfo(ref pclsInfoBand, ref pclsResponse, pintUserID);
        }
        public void getGenresBand(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserCode)
        {
            BandDA.getGenresBand(ref pclsInfoBand, ref pclsResponse, pintUserCode);
        }
        public clsInfoBand updateBand(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {
            return BandDA.updateBand(pclsInfoBand, ref pclsResponse);
        }
        public void getAlbums(ref clsDisksBlock pclsDisksBlock, ref clsResponse pclsResponse, int pintUserCode, int pintOffset, int pintLimit)
        {
            BandDA.getAlbums(ref pclsDisksBlock, ref pclsResponse, pintUserCode, pintOffset, pintLimit);
        }
        public void getsongs(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskDA.getsongs(ref pclsDisk, ref pclsResponse, pintDiskCode);
        }
        public void getdiskinfo(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskDA.getdiskinfo(ref pclsDisk, ref pclsResponse, pintDiskCode);
        }
        public void getdiskreviews(ref List<clsReview> pclsReviews, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskDA.getdiskreviews(ref pclsReviews, ref pclsResponse, pintDiskCode);
        }








        public static void Main()
        {
            System.Diagnostics.Stopwatch sw = Stopwatch.StartNew();
            clsFacadeDA a = new clsFacadeDA();
            clsForm b = new clsForm();
            clsResponse c = new clsResponse();
            Serializer j = new Serializer();
            clsInfoBand p = new clsInfoBand();

            Console.WriteLine(j.Serialize(a.getAllGenres(a.getAllGenders(b,ref c),ref c)));
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Stop();
            Console.ReadKey();
        }
    }
}
