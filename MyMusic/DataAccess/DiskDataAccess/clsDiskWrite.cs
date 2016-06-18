using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DiskDataAccess
{
    public class clsDiskWrite
    {
        private SqlConnection conn = new clsConnection().getPort();

        public int createdisk(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintUserCode)
        {
            int tmp = new int();
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_InsertarDisco", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intGenero", System.Data.SqlDbType.Int).Value = pclsDisk.CodGenre;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsDisk.Name;
                cmd.Parameters.Add("@dtFechaPublicacion", System.Data.SqlDbType.VarChar).Value = pclsDisk.DateCreation;
                cmd.Parameters.Add("@strSelloDiscografico", System.Data.SqlDbType.VarChar).Value = pclsDisk.Label;
                cmd.Parameters.Add("@intUser", System.Data.SqlDbType.Int).Value = pintUserCode;
                SqlParameter id = cmd.Parameters.Add("@intIdDisco", SqlDbType.Int);
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
        public void createsong(ref clsSong pclsSong, ref clsResponse pclsResponse, int pintCodDisc)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_InsertSong", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodDisc", System.Data.SqlDbType.Int).Value = pintCodDisc;
                cmd.Parameters.Add("@tmDuration", System.Data.SqlDbType.Time).Value = pclsSong.Duration;
                cmd.Parameters.Add("@btLive", System.Data.SqlDbType.Bit).Value = pclsSong.Type;
                cmd.Parameters.Add("@btEdicionLimitada", System.Data.SqlDbType.Bit).Value = pclsSong.LimitedEdition;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsSong.Name;
                cmd.Parameters.Add("@strVideoURL", System.Data.SqlDbType.VarChar).Value = pclsSong.Link;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
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
