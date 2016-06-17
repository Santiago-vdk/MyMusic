using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

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
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Message = "Error while procesing your request.";
                pclsResponse.Success = false;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Message = "Unexpected error.";
                pclsResponse.Success = false;
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
                    values.Add(result["Country"].ToString());
                    cods.Add(Convert.ToInt32(result["Locationcode"]));
                }
                pclsForm.locations = values;
                pclsForm.codLocations = cods;
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Message = "Error while procesing your request.";
                pclsResponse.Success = false;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Message = "Unexpected error.";
                pclsResponse.Success = false;
            }
            finally
            {
                conn.Close();
            }

            return pclsForm;
        }

        public void validateUser(clsInfoUser pclsInfoUser, ref clsResponse pclsResponse)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_ExistUserName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strUserName", System.Data.SqlDbType.VarChar).Value = pclsInfoUser.Username;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                result.Read();
                if (result.HasRows == true)
                {
                    if (result["UserLogin"].ToString().Equals("True"))
                    {
                        pclsResponse.Code = 0;
                        pclsResponse.Message = "Done";
                        pclsResponse.Success = true;
                    }
                    else
                    {
                        pclsResponse.Code = 3;
                        pclsResponse.Message = "Incorrect Username";
                        pclsResponse.Success = false;
                    }

                }
                else
                {
                    pclsResponse.Code = 3;
                    pclsResponse.Message = "Incorrect Username";
                    pclsResponse.Success = false;
                }             
                
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Message = "Error while procesing your request.";
                pclsResponse.Success = false;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Message = "Unexpected error.";
                pclsResponse.Success = false;
            }
            finally
            {
                conn.Close();
            }

        }

        public clsInfoUser getSaltPass(clsInfoUser pclsInfoUser, ref clsResponse pclsResponse)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetSaltCredentials", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@User", System.Data.SqlDbType.VarChar).Value = pclsInfoUser.Username;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                result.Read();
                pclsInfoUser.SaltHashed = result["HashPassword"].ToString();
                pclsInfoUser.Salt = result["Salt"].ToString();
                pclsInfoUser.Id = Convert.ToInt32(result["UserCode"].ToString());
                pclsInfoUser.Rol = Convert.ToInt32(result["CodeRol"].ToString());
                pclsInfoUser.Name = result["Nombre"].ToString();
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Message = "Error while procesing your request.";
                pclsResponse.Success = false;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Message = "Unexpected error.";
                pclsResponse.Success = false;
            }
            finally
            {
                conn.Close();
            }

            return pclsInfoUser;
        }

        



        public static void Main()
        {
            clsUserRead a = new clsUserRead();
            clsResponse b = new clsResponse();
            clsInfoUser c = new clsInfoUser();
            Serializer d = new Serializer();
            c.Username = "mamador";

            Console.WriteLine(d.Serialize(a.getSaltPass(c,ref b)));
            Console.WriteLine(b.Message);
            Console.ReadKey();
        }
    }
}
