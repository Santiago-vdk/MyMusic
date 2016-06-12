using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserDataAccess
{
    public class clsUserRead
    {
        private SqlConnection conn = new clsConnection().getPort();


        public clsForm getAllgenres(clsForm pclsForm, ref clsResponse pclsResponse)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetAllGenresAvaibles", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<String> values = new List<String>();
                List<int> cods = new List<int>();
                while (result.Read())
                {
                    values.Add(result["strDescripcion"].ToString());
                    cods.Add(Convert.ToInt32(result["intCodGenero"]));
                }
                pclsForm.genres = values;
                pclsForm.codGenres = cods;
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Message = "Error while procesing your request.";
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Message = "Unexpected error.";
            }
            finally
            {
                conn.Close();
            }

            return pclsForm;
        }

        public clsForm getAllLocations(clsForm pclsForm, ref clsResponse pclsResponse)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetAllLocations", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<String> values = new List<String>();
                List<int> cods = new List<int>();
                while (result.Read())
                {
                    values.Add(result["strDescripcion"].ToString());
                    cods.Add(Convert.ToInt32(result["intCodGenero"]));
                }
                pclsForm.locations = values;
                pclsForm.codLocations = cods;
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Message = "Error while procesing your request.";
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Message = "Unexpected error.";
            }
            finally
            {
                conn.Close();
            }

            return pclsForm;
        }



        public static void Main()
        {
            clsUserRead a = new clsUserRead();
            //Console.WriteLine(a.getAllgenres(new clsForm()).genres[1].intCodigo);
            Console.ReadKey();
        }
    }
}
