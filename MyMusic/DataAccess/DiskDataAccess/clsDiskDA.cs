using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DiskDataAccess
{
    public class clsDiskDA
    {
        clsDiskRead DiskRead = new clsDiskRead();
        clsDiskWrite DiskWrite = new clsDiskWrite();

        public void getsongs(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskRead.getsongs(ref pclsDisk, ref pclsResponse, pintDiskCode);
        }
        public void getdiskinfo(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskRead.getdiskinfo(ref pclsDisk, ref pclsResponse, pintDiskCode);
        }
        public void getdiskreviews(ref List<clsReview> pclsReviews, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskRead.getdiskreviews(ref pclsReviews, ref pclsResponse, pintDiskCode);
        }
        public int createdisk(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintUserCode)
        {
            return DiskWrite.createdisk(ref pclsDisk, ref pclsResponse, pintUserCode);
        }
        public bool existreviewdisk(int pintCodDisk, int pintUserCode, ref clsResponse pclsResponse)
        {
            return DiskRead.existreviewdisk(pintCodDisk, pintUserCode, ref pclsResponse);
        }
        public void createsong(ref clsSong pclsSong, ref clsResponse pclsResponse, int pintCodDisc)
        {
            DiskWrite.createsong(ref pclsSong, ref pclsResponse, pintCodDisc);
        }
        public void creatediskreview(ref clsReview pclsReview, ref clsResponse pclsResponse, int pintCodDisc, int pintUserCode)
        {
            DiskWrite.creatediskreview(ref pclsReview, ref pclsResponse, pintCodDisc, pintUserCode);
        }
    }
}
