using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EventsDataAccess
{
    public class clsEventsRead
    {
        private SqlConnection conn = new clsConnection().getPort();

        public void geteventinfo(ref clsEvent pclsEvent, ref clsResponse pclsResponse, int pintDiskCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetInfoDisc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intDisc", System.Data.SqlDbType.Int).Value = pintDiskCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                   
                }

                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = "Error while procesing your request.";
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = "Unexpected error.";
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
