using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EventsDataAccess
{
    public class clsEventsWrite
    {
        private SqlConnection conn = new clsConnection().getPort();

        public int createnew(ref clsEvent pclsNew, ref clsResponse pclsResponse, int pintUserCode)
        {
            int tmp = new int();
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_IngresarNoticia", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intTitulo", System.Data.SqlDbType.Int).Value = pclsNew.Title;
                cmd.Parameters.Add("@strComentario", System.Data.SqlDbType.VarChar).Value = "s";
                cmd.Parameters.Add("@intCodUsuario", System.Data.SqlDbType.Int).Value = pintUserCode;
                SqlParameter id = cmd.Parameters.Add("@intCodNoticia", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.Write("entre");
                tmp = Convert.ToInt32(id.Value.ToString());
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
            return tmp;
        }
    }
}
