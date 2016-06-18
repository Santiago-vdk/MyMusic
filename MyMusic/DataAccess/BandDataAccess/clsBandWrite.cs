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
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Name;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoBand.CodGenres);
                cmd.Parameters.Add("@strBiografia", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Biography;
                cmd.Parameters.Add("@dtAnoCreacion", System.Data.SqlDbType.Date).Value = pclsInfoBand.DateCreation;
                cmd.Parameters.Add("@intPais", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Country;
                cmd.Parameters.Add("@strIntegrantes", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoBand.Members);
                cmd.Parameters.Add("@strHashTag", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Hashtag;
                cmd.Parameters.Add("@strSalt", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Salt;
                cmd.Parameters.Add("@strSaltHashedPassword", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.SaltHashed;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                SqlParameter id = cmd.Parameters.Add("@intCodUserReturn", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                conn.Open();

                cmd.ExecuteNonQuery();
                
                pclsInfoBand.Id = Convert.ToInt32(id.Value);
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

        public clsInfoBand updateBand(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_ActualizarBanda", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodUser", System.Data.SqlDbType.Int).Value = pclsInfoBand.Id;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Name;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoBand.CodGenres);
                cmd.Parameters.Add("@strIntegrantes", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoBand.Members);
                cmd.Parameters.Add("@dtAnoCreacion", System.Data.SqlDbType.Date).Value = pclsInfoBand.DateCreation;
                cmd.Parameters.Add("@intUbicacion", System.Data.SqlDbType.Int).Value = pclsInfoBand.Country;
                cmd.Parameters.Add("@strHashTag", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Hashtag;
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
            return pclsInfoBand;
        }




        public static void Main()
        {
            
            clsInfoBand b = new clsInfoBand();
            b.Username = "canesa me la besa";
            b.Name = "canesota";
            b.CodGenres = new List<int>(new int[] { 1, 2 });
            b.Members = new List<string>(new string[] { "Panochon69", "PAnochote69" });
            b.DateCreation = "1-2-2016";
            b.Biography = "Listo";
            b.Country = "9";
            b.Hashtag = "@canepicha";
            b.Id = 133;

   
            clsBandWrite d = new clsBandWrite();
            clsResponse f = new clsResponse();
            d.updateBand(b, ref f);
            Console.WriteLine(f.Message);
            Console.ReadKey();
        }
    }
}
