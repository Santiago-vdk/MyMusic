using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BandDataAccess
{
    public class clsBandWrite
    {
        private SqlConnection conn = new clsConnection().getPort();

        public clsInfoBand createBand(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_CrearBanda", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Username;
                cmd.Parameters.Add("@strContrasena", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Password;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Name;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoBand.Genres);
                cmd.Parameters.Add("@strBiografia", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Biography;
                cmd.Parameters.Add("@dtAnoCreacion", System.Data.SqlDbType.Date).Value = pclsInfoBand.DateCreation;
                cmd.Parameters.Add("@strPais", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Country;
                cmd.Parameters.Add("@strIntegrantes", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoBand.Members);
                cmd.Parameters.Add("@strHashTag", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Hashtag;
                cmd.Parameters.Add("@strSalt", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Salt;
                cmd.Parameters.Add("@strSaltHashedPassword", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.SaltHashed;
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
            return pclsInfoBand;
        }

        public static void Main()
        {
            
            clsInfoBand b = new clsInfoBand();
            b.Username = "panocho3722328";
            b.Password = "panocho";
            b.Name = "panocho";
            b.Genres = new List<string>(new string[] { "Rock", "Metal" });
            b.Members = new List<string>(new string[] { "Panochon", "PAnochote" });
            b.DateCreation = "1-2-2016";
            b.Biography = "Listo";
            b.Country = "Panocho";
            b.Hashtag = "@Panochon";
            b.Salt = "dhjsdhjss37asaasr22ddsds";
            b.SaltHashed = "dsdssdsd";
            clsBandWrite d = new clsBandWrite();
            clsResponse f = new clsResponse();
            d.createBand(b, ref f);
            Console.WriteLine(f.Message);
            Console.ReadKey();
        }
    }
}
