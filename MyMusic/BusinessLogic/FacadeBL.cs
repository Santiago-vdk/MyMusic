
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
        public string getBandPublications(int pintUserId, int pintOffset, int pintLimit)
        {
            return BandBL.getBandPublications(pintUserId, pintOffset, pintLimit);
        }
        public string getBands(int pintUserId, int pintOffset, int pintLimit)
        {
            return FanBL.getBands(pintUserId, pintOffset, pintLimit);
        }
        public string getDisks(int pintBandId, int pintOffset, int pintLimit)
        {
            return DiskBL.getDisks(pintBandId, pintOffset, pintLimit);
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
        public string getEventInfo(int pintEventId)
        {
            return EventBL.getEventInfo(pintEventId);
        }
        public string getNewInfo(int pintNewId)
        {
            return NewBL.getNewInfo(pintNewId);
        }

        public string getBandReviews(int pintBandId)
        {
            return BandBL.getBandReviews(pintBandId);
        }
        public string getDiskReviews(int pintDiskId)
        {
            return DiskBL.getDiskReviews(pintDiskId);
        }
        public string getEventReviews( int pintEventId)
        {
            return EventBL.getEventReviews( pintEventId);
        }

        public string getOwnBandReview(string pstringRequest, int pintBandId)
        {
            return BandBL.getOwnBandReview(pstringRequest, pintBandId);
        }
        public string getOwnDiskReview(string pstringRequest, int pintBandId)
        {
            return DiskBL.getOwnDiskReview(pstringRequest, pintBandId);
        }
        public string getOwnEventReview(string pstringRequest, int pintEventId)
        {
            return EventBL.getOwnEventReview(pstringRequest, pintEventId);
        }

        public string getBandStats(int pintBandId)
        {
            return BandBL.getBandStats(pintBandId);
        }

        public string Dashboard(pintBandId)
        {
            return BandBL.Dashboard(pintBandId);
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
        public string createSong(string pstringRequest, int pintBandId, int pintDiskId)
        {
            return DiskBL.createSong(pstringRequest,pintBandId, pintDiskId);
        }
        public string createNew(string pstringRequest, int pintBandId)
        {
            return NewBL.createNew(pstringRequest, pintBandId);
        }
        public string createEvent(string pstringRequest, int pintBandId)
        {
            return EventBL.createEvent(pstringRequest, pintBandId);
        }
        public string createGenre(string pstringGenre)
        {
            return BandBL.createGenre(pstringGenre);
        }


        public string checkUsername(string pstringUsername)
        {
            return UserBL.checkUsername(pstringUsername);
        }
        public string checkHashtag(string pstringHashtag)
        {
            return BandBL.checkHashtag(pstringHashtag);
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

        public string deleteBandReview(string pstringRequest, int pintBandId)
        {
            return BandBL.deleteBandReview(pstringRequest, pintBandId);
        }
        public string deleteDiskReview(string pstringRequest, int pintDiskId)
        {
            return DiskBL.deleteDiskReview(pstringRequest, pintDiskId);
        }
        public string deleteEventReview(string pstringRequest, int pintEventId)
        {
            return EventBL.deleteEventReview(pstringRequest, pintEventId);
        }

        public string login(string pstringRequest)
        {
            return UserBL.login(pstringRequest);
        }

        public string searchBands(string pstringRequest, int pintOffset, int pintLimit)
        {
            return FanBL.searchBands(pstringRequest, pintOffset, pintLimit);
        }
        public string getSearchParams()
        {
            return UserBL.getSearchParams();
        }

        public string changeEventState(string pstringState, int pintEventId)
        {
            return EventBL.changeState(pstringState,pintEventId);
        }

        public string followBand(int pintFanId, int pintBandId)
        {
            return FanBL.followBand(pintFanId,pintBandId);
        }
        public string IsFollowed(int pintFanId, int pintBandId)
        {
            return FanBL.IsFollowed(pintFanId, pintBandId);
        }
        public string UnfollowBand(int pintFanId, int pintBandId)
        {
            return FanBL.UnfollowBand(pintFanId, pintBandId);
        }
    }
}
