using DataAccess;
using DTO;
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
           // DisksBlock = FacadeDA.getDisks(DisksBlock, ref response, pintBandId, pintOffset, pintLimit);
            response.Data = serializer.Serialize(DisksBlock);
            return serializer.Serialize(response);
        }

        public string getDiskInfo()
        {
            clsDisk Disk = new clsDisk();
            clsResponse response = new clsResponse();

            //FacadeDA.getDiskInfo(ref Disk, ref response, pintFanId);

            response.Data = serializer.Serialize(Disk);
            return serializer.Serialize(response);
        }

        public string getImage(int intDiskId)
        {
            return ArchiveManager.getDiskImage(intDiskId);
        }
    }
}
