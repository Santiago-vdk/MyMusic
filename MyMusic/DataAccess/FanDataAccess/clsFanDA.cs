using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FanDataAccess
{
    public class clsFanDA
    {
        clsFanRead FanRead = new clsFanRead();
        clsFanWrite FanWrite = new clsFanWrite();


        public clsForm getAllGenders(clsForm pclsForm, ref clsResponse pclsResponse)
        {
            try
            {
                return FanRead.getAllgenders(pclsForm, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsForm;// cambiar x error
            }
        }

        public clsInfoFan createFan(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {
            try
            {
                return FanWrite.createFan(pclsInfoFan, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsInfoFan;// cambiar x error
            }
        }

        public clsInfoFan updateFan(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {
            try
            {
                return FanWrite.updateFan(pclsInfoFan, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsInfoFan;// cambiar x error
            }
        }

        public clsBandsBlock getBands(clsBandsBlock pclsBandsBlock, ref clsResponse pclsResponse, int pintUserID, int pintOffset, int pintLimit)
        {
            return FanRead.getBands(pclsBandsBlock, ref pclsResponse, pintUserID, pintOffset, pintLimit);
        }

        public List<clsPublication> getWall(ref clsResponse pclsResponse, int pintUserID, int pintOffset, int pintLimit)
        {
            return FanRead.getWall(ref pclsResponse, pintUserID, pintOffset, pintLimit);
        }

        public void getFanInfo(ref clsInfoFan pclsInfoFan, ref clsResponse pclsResponse, int pintUserID)
        {
            FanRead.getFanInfo(ref pclsInfoFan, ref pclsResponse, pintUserID);
        }

        public clsBandsBlock getBandsSearch(clsBandsBlock pclsBandsBlock, ref clsResponse pclsResponse, ref clsSearch pclsSearch, int pintOffset, int pintLimit)
        {
            return FanRead.getBandsSearch(pclsBandsBlock, ref pclsResponse, ref pclsSearch, pintOffset, pintLimit);
        }

        public void getGenresFan(ref clsInfoFan pclsInfoFan, ref clsResponse pclsResponse, int pintUserCode)
        {
            FanRead.getGenresFan(ref pclsInfoFan, ref pclsResponse, pintUserCode);
        }

        public void followBand(int pintCodFanatico, int pintCodBanda, ref clsResponse pclsResponse)
        {
            FanWrite.followBand(pintCodFanatico, pintCodBanda, ref pclsResponse);
        }

        public bool isFollowBand(int pintCodFanatico, int pintCodBanda, ref clsResponse pclsResponse)
        {
            return FanRead.isFollowBand(pintCodFanatico, pintCodBanda, ref pclsResponse);
        }

        public void stopfollowBand(int pintCodFanatico, int pintCodBanda, ref clsResponse pclsResponse)
        {
            FanWrite.stopfollowBand(pintCodFanatico, pintCodBanda, ref pclsResponse);
        }

        public void createReviewBand(ref clsReview pclsReview, int pintCodFanatico, int pintCodBanda, ref clsResponse pclsResponse)
        {
            FanWrite.createReviewBand(ref pclsReview, pintCodFanatico, pintCodBanda, ref pclsResponse);
        }

        public void getReviewBandUser(ref clsReview pclsReview, ref clsResponse pclsResponse, int pintFanCode, int pintBandCode)
        {
            FanRead.getReviewBandUser(ref pclsReview, ref pclsResponse, pintFanCode, pintBandCode);
        }

        public void deleteBandReview(ref clsResponse pclsResponse, int pintFanCode, int pintCodeBand)
        {
            FanWrite.deleteBandReview(ref pclsResponse, pintFanCode, pintCodeBand);
        }

    }
}
