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
            clsResponse response = new clsResponse();


            //FacadeDA.validateDisk(Disk.Id,pintBandId, ref response);

            if (!response.Success)//not existing disk
            {
                //llamado a FacadeDA

                //save image here!
                ArchiveManager.saveDiskImage(Disk.Id, Disk.Picture, ref response);
            }
            else
            {
                //error info
                response.Success = false;
                response.Message = "Existing Username";
                response.Code = 3;
            }

            //Data = null
            return serializer.Serialize(response);
        }

        public string getDiskReviews(int pintBandId)
        {
            List<clsReview> reviews = new List<clsReview>();
            clsResponse response = new clsResponse();

            FacadeDA.getdiskreviews(ref reviews,ref response, pintBandId);

            response.Data = serializer.Serialize(reviews);
            return serializer.Serialize(response);
        }
    }
}
