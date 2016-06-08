using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FanDataAccess
{
    class clsFanWrite
    {
        private SqlConnection conn = new clsConnection().getPort();


        public clsInfoFan crearFanatico(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
         {
           
             try
             {
                 
                 SqlCommand cmd = new SqlCommand("myFan.SP_CrearFanatico", conn);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Username;
                 cmd.Parameters.Add("@strContrasena", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Password;
                 cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Name;
                 cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Genres.ToString();
                 cmd.Parameters.Add("@dtFechaNacimiento", System.Data.SqlDbType.Date).Value = pclsInfoFan.Birthday;
                 cmd.Parameters.Add("@strPais", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Country;
                    cmd.Parameters.Add("@intSexo", System.Data.SqlDbType.Int).Value = pclsInfoFan.Gender;
                 cmd.Parameters.Add("@strSalt", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Salt;
                 cmd.Parameters.Add("@strSaltHashedPassword", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.SaltHashed;
                 SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                 message.Direction = ParameterDirection.Output;
                 SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                 cod.Direction = ParameterDirection.Output;
                 conn.Open();
                 cmd.ExecuteNonQuery();
                 pclsResponse.Code = 0;
                 pclsResponse.Message = "Done";
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
             return pclsInfoFan;
         }

        public static void Main()
        {
            clsFanWrite a = new clsFanWrite();
            clsInfoFan b = new clsInfoFan();
            b.Username = "panocho3";
            b.Password = "panocho";
            b.Name = "panocho";
            b.Genres = new List<string>(new string[] { "Rock","Metal" });
            b.Birthday = "1-2-2016";
            b.Country = "Panocho";
            b.Gender = "1";
            b.Salt = "dhjsdhjssaasrddsds";
            b.SaltHashed = "dsdssdsd";
            clsFanWrite d = new clsFanWrite();
            clsResponse f = new clsResponse();
            d.crearFanatico(b,ref f);
            Console.WriteLine(f.Message.ToString());
            Console.ReadKey();
        }
    }
}
