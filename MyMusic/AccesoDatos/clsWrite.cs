using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class clsWrite
    {
        SqlConnection conn = new clsConnection().getPort();
        
        public clsInfoFan createFan(clsInfoFan pFanatico)
        {
            
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_CrearFanatico", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = pFanatico.Username;
                cmd.Parameters.Add("@strContrasena", System.Data.SqlDbType.VarChar).Value = pFanatico.Password;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pFanatico.Name;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = pFanatico.Genres.ToString();
                cmd.Parameters.Add("@dtFechaNacimiento", System.Data.SqlDbType.Date).Value = pFanatico.Birthday;
                cmd.Parameters.Add("@strEstado", System.Data.SqlDbType.VarChar).Value = pFanatico.Location;
                cmd.Parameters.Add("@strPais", System.Data.SqlDbType.VarChar).Value = pFanatico.Country;
                cmd.Parameters.Add("@intSexo", System.Data.SqlDbType.Int).Value = pFanatico.Gender;
                cmd.Parameters.Add("@strSalt", System.Data.SqlDbType.VarChar).Value = pFanatico.Salt;
                cmd.Parameters.Add("@strSaltHashedPassword", System.Data.SqlDbType.VarChar).Value = pFanatico.SaltHashed;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                pFanatico.ErrorCode = cod.Value.ToString();
                pFanatico.ErrorMessage = message.Value.ToString();
            }
            catch (SqlException ex)
            {
                pFanatico.ErrorCode = ex.ErrorCode.ToString();
                pFanatico.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                pFanatico.ErrorCode= "s001";
                pFanatico.ErrorMessage = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return pFanatico;
        }


    }


}
