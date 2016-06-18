using ODTmyFest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessMyFest.DashboardDataAccess
{
    public class clsDashboardWrite
    {
        private SqlConnection conn = new clsConnection().getPort();

        public clsInfoDashboard IncreaseTweets(clsInfoDashboard pclsInfoDashboard, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_CrearBanda", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodeBand", System.Data.SqlDbType.Int).Value = pclsInfoDashboard.intCodeUser;                
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                conn.Open();

                cmd.ExecuteNonQuery();
                
                pclsResponse.Code = Convert.ToInt32(cod.Value.ToString());
                pclsResponse.Message = message.Value.ToString();
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
            return pclsInfoDashboard;
        }

    }
}
