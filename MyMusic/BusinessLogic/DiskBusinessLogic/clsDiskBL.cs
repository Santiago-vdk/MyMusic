using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BusinessLogic.DiskBusinessLogic
{
    public class clsDiskBL
    {

        clsFacadeDA FacadeDA = new clsFacadeDA();
        clsDeserializeJson DeserializeJson = new clsDeserializeJson();
        Serializer serializer = new Serializer();
        clsArchiveManager ArchiveManager = new clsArchiveManager();

        public string getDisks(int pintBandId, int pintOffset, int pintLimit)
        {

            clsResponse response = new clsResponse();
            clsDisksBlock DisksBlock = new clsDisksBlock();
            FacadeDA.getAlbums(ref DisksBlock, ref response, pintBandId, pintOffset, pintLimit);
            response.Data = serializer.Serialize(DisksBlock);
            return serializer.Serialize(response);
        }
        public string getDiskInfo(int pintDiskId)
        {
            clsDisk Disk = new clsDisk();
            clsResponse response = new clsResponse();

            Disk.Id = pintDiskId;

            FacadeDA.getdiskinfo(ref Disk, ref response, pintDiskId);
            FacadeDA.getsongs(ref Disk, ref response, pintDiskId);


            response.Data = serializer.Serialize(Disk);
            return serializer.Serialize(response);
        }
        public string getImage(int intDiskId)
        {
            return ArchiveManager.getDiskImage(intDiskId);
        }

        public string createDisk(string pstringRequest, int pintBandId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsDisk Disk = DeserializeJson.DeserializeDisk(request.Data.ToString());
            Disk.Id = request.Id;
            clsResponse response = new clsResponse();

            if (Disk.Id == pintBandId)
            {

                Disk.Id = FacadeDA.createdisk(ref Disk, ref response, pintBandId);

                //save image here!
                ArchiveManager.saveDiskImage(Disk.Id, Disk.Picture, ref response);
            }
            else
            {
                //error info
                response.Success = false;
                response.Message = "Invalid Operation";
                response.Code = 401;
            }

            Disk.Picture = null;
            Disk.Songs = null;
            Disk.Label = null;
            Disk.DateCreation = null;
            Disk.Name = null;
            Disk.CodGenre = -1;

            response.Data = serializer.Serialize(Disk);
            return serializer.Serialize(response);
        }
        public string createSong(string pstringRequest,int pintBandId, int pintDiskId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsSong Song = DeserializeJson.DeserializeSong(request.Data.ToString());
            clsResponse response = new clsResponse();

            if (request.Id == pintBandId)
            {
                FacadeDA.createsong(ref Song, ref response, pintDiskId);
            }
            else
            {
                //error info
                response.Success = false;
                response.Message = "Invalid Operation";
                response.Code = 401;
            }
            return serializer.Serialize(response);
        }

        public string getDiskReviews( int pintDiskId)
        {
            List<clsReview> reviews = new List<clsReview>();
            clsResponse response = new clsResponse();

            FacadeDA.getdiskreviews(ref reviews,ref response, pintDiskId);

            response.Data = serializer.Serialize(reviews);
            return serializer.Serialize(response);
        }

        public string getOwnDiskReview(int pintFanId, int pintDiskId)
        {
            clsReview review = new clsReview();
            clsResponse response = new clsResponse();

            FacadeDA.getdiscReviewFan(ref review, pintDiskId, pintFanId, ref response);

            response.Data = serializer.Serialize(review);
            return serializer.Serialize(response);
        }

        public string reviewDisk(string pstringRequest, int pintDiskId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsReview review = DeserializeJson.DeserializeReview(request.Data);
            clsResponse response = new clsResponse();

            bool existDisk = FacadeDA.existreviewdisk(pintDiskId, request.Id, ref response);
            if (!existDisk && response.Success)
            {
                FacadeDA.creatediskreview(ref review, ref response, request.Id, pintDiskId);
            }

            //data null
            return serializer.Serialize(response);
        }

        public string deleteDiskReview(int pintFanId, int pintDiskId)
        {
            clsResponse response = new clsResponse();

            FacadeDA.deleteDiscReview(ref response, pintFanId, pintDiskId);

            return serializer.Serialize(response);
        }
    }
}
