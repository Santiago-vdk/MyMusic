using ODTmyFest;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessMyFest.DashboardDataAccess
{
    public class clsDashboardRead
    {
        private SqlConnection conn = new clsConnection().getPort();

        public void getBandInfo(ref clsInfoDashboard pclsInfoDashboard, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFest.SP_GetControlTweets", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserCode", System.Data.SqlDbType.Int).Value = pclsInfoDashboard.intCodeUser;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    pclsInfoDashboard.intCodeBand = Int32.Parse(result["NumeroTweets"].ToString());
                    pclsInfoDashboard.intCountTweet = Int32.Parse(result["NumeroTweets"].ToString());
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
