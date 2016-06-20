using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserDataAccess
{
    public class clsUserWrite
    {
        private SqlConnection conn = new clsConnection().getPort();

        public void createNewGenero(string strGenero, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_CreateGenero", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strGenero", System.Data.SqlDbType.VarChar).Value = strGenero;
                conn.Open();
                cmd.ExecuteNonQuery();
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
