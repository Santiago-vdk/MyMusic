
using BusinessLogic.FanBusinessLogic;
using BusinessLogic.BandBusinessLogic;
using BusinessLogic.UserBusinessLogic;
using System;
using BusinessLogic.DiskBusinessLogic;
using BusinessLogic.EventBusinessLogic;
using BusinessLogic.NewBusinessLogic;

namespace BusinessLogic
{
   public class FacadeBL
    {

        clsEventBL EventBL = new clsEventBL();
        clsFanBL FanBL = new clsFanBL();
        clsBandBL BandBL = new clsBandBL();
        clsUserBL UserBL = new clsUserBL();
        clsNewBL NewBL = new clsNewBL();
        clsDiskBL DiskBL = new clsDiskBL();

        public string getFanForm()
        {
            return FanBL.getForm();
        }
        public string getBandForm()
        {
            return BandBL.getForm();
        }

        public string getEvent(int pintEventId)
        {
            return EventBL.getEvent(pintEventId);
        }
        public string getNew(int pintNewId)
        {
            return NewBL.getNew(pintNewId);
        }

        public string getUserPicture(string pstringUserId)
        {
            return UserBL.getPicture(Int32.Parse(pstringUserId));
        }
        public string getDiskPicture(string pstringDiskId)
        {
            return DiskBL.getImage(Int32.Parse(pstringDiskId));
        }

        public string getPublications(int pintUserId, int pintOffset, int pintLimit)
        {
            return UserBL.getPublications(pintUserId, pintOffset, pintLimit);
        }
        public string getBands(int pintUserId, int pintOffset, int pintLimit)
        {
            return FanBL.getBands(pintUserId, pintOffset, pintLimit);
        }
        public string getDisks(int pintBandId, int pintOffset, int pintLimit)
        {
            return DiskBL.getDisks(pintBandId, pintOffset, pintLimit);
        }

        public string getSearchParams()
        {
            return UserBL.getSearchParams();
        }

        public string getFanInfo(int pintFanId)
        {
            return FanBL.getFanInfo(pintFanId);
        }
        public string getBandInfo(int pintBandId)
        {
            return BandBL.getBandInfo(pintBandId);
        }
        public string getDiskInfo(int pintDiskId)
        {
            return DiskBL.getDiskInfo(pintDiskId);
        }

        public string getBandReviews(int pintBandId)
        {
            return BandBL.getBandReviews(pintBandId);
        }
        public string getDiskReviews(int pintBandId)
        {
            return DiskBL.getDiskReviews(pintBandId);
        }
        public string getEventReviews(int pintEventId)
        {
            return EventBL.getEventReviews(pintEventId);
        }


        public string createFan(string pstringRequest)
        {
            return FanBL.createFan(pstringRequest);
        }
        public string createBand(string pstringRequest)
        {
            return BandBL.createBand(pstringRequest);
        }
        public string createDisk(string pstringRequest,int pintBandId)
        {
            return DiskBL.createDisk(pstringRequest,pintBandId);
        }
        public string createSong(string pstringRequest, int pintDiskId)
        {
            return DiskBL.createSong(pstringRequest, pintDiskId);
        }

        public string login(string pstringRequest)
        {
            return UserBL.login(pstringRequest);
        }

        public string checkUsername(string pstringUsername)
        {
            return UserBL.checkUsername(pstringUsername);
        }
        public string checkHashtag(string pstringHashtag)
        {
            return BandBL.checkHashtag(pstringHashtag);
        }

        public string searchBands(string pstringRequest, int pintOffset, int pintLimit)
        {
            return FanBL.searchBands(pstringRequest, pintOffset, pintLimit);
        }

        public string updateFan(string pstringRequest,int pintFanId)
        {
            return FanBL.updateFan(pstringRequest, pintFanId);
        }
        public string updateBand(string pstringRequest, int pintBandId)
        {
            return BandBL.updateBand(pstringRequest, pintBandId);
        }

        public string reviewBand(string pstringRequest, int pintBandId)
        {
            return BandBL.reviewBand(pstringRequest,pintBandId);
        }
        public string reviewDisk(string pstringRequest, int pintDiskId)
        {
            return DiskBL.reviewDisk(pstringRequest, pintDiskId);
        }
        public string reviewEvent(string pstringRequest, int pintEventId)
        {
            return EventBL.reviewEvent(pstringRequest, pintEventId);
        }



        }
}
