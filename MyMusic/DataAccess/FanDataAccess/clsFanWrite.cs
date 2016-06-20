using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DataAccess.FanDataAccess
{
    class clsFanWrite
    {
        private SqlConnection conn = new clsConnection().getPort();


        public clsInfoFan createFan(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_CrearFanatico", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Username;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Name;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoFan.Genres);
                cmd.Parameters.Add("@dtFechaNacimiento", System.Data.SqlDbType.Date).Value = pclsInfoFan.Birthday;
                cmd.Parameters.Add("@intPais", System.Data.SqlDbType.Int).Value = pclsInfoFan.Country;
                cmd.Parameters.Add("@intSexo", System.Data.SqlDbType.Int).Value = pclsInfoFan.Gender;
                cmd.Parameters.Add("@strSalt", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Salt;
                cmd.Parameters.Add("@strSaltHashedPassword", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.SaltHashed;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                SqlParameter id = cmd.Parameters.Add("@intCodeUserReturn", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                conn.Open();

                SqlDataReader result = cmd.ExecuteReader();
                Console.WriteLine("entre");
                pclsInfoFan.Id = Convert.ToInt32(id.Value);

                pclsResponse.Code = Convert.ToInt32(cod.Value.ToString());
                pclsResponse.Message = message.Value.ToString();
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
            return pclsInfoFan;
        }

        public clsInfoFan updateFan(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_ActualizarFanatico", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodUser", System.Data.SqlDbType.Int).Value = pclsInfoFan.Id;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Name;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoFan.Genres);
                cmd.Parameters.Add("@dtFechaNacimiento", System.Data.SqlDbType.Date).Value = pclsInfoFan.Birthday;
                cmd.Parameters.Add("@intPais", System.Data.SqlDbType.Int).Value = pclsInfoFan.Country;
                cmd.Parameters.Add("@intSexo", System.Data.SqlDbType.Int).Value = pclsInfoFan.Gender;
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
            return pclsInfoFan;
        }

        public void followBand(int pintCodFanatico, int pintCodBanda, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_SeguirBanda", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodFanatico", System.Data.SqlDbType.Int).Value = pintCodFanatico;
                cmd.Parameters.Add("@intCodBanda", System.Data.SqlDbType.VarChar).Value = pintCodBanda;
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

        public void stopfollowBand(int pintCodFanatico, int pintCodBanda, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_NoSeguirBanda", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodFanatico", System.Data.SqlDbType.Int).Value = pintCodFanatico;
                cmd.Parameters.Add("@intCodBanda", System.Data.SqlDbType.Int).Value = pintCodBanda;
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

        public void createReviewBand(ref clsReview pclsReview, int pintCodFanatico, int pintCodBanda, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_IngresarResenaBanda", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodUsuarioBanda", System.Data.SqlDbType.Int).Value = pintCodBanda;
                cmd.Parameters.Add("@intCalificacion", System.Data.SqlDbType.Int).Value = pclsReview.Calification;
                cmd.Parameters.Add("@strComentario", System.Data.SqlDbType.Int).Value = pclsReview.Comment;
                cmd.Parameters.Add("@intUsuario", System.Data.SqlDbType.VarChar).Value = pintCodFanatico;
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

        public void deleteBandReview(ref clsResponse pclsResponse, int pintFanCode, int pintCodeBand)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_DeleteReviewBand", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUserCodFan", System.Data.SqlDbType.Int).Value = pintFanCode;
                cmd.Parameters.Add("@intBand", System.Data.SqlDbType.Int).Value = pintCodeBand;
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
