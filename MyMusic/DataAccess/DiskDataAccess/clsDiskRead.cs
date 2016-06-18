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
    public class clsDiskRead
    {
        private SqlConnection conn = new clsConnection().getPort();

        

        public void getsongs(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintDiskCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetSongsByDisc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodeDisc", System.Data.SqlDbType.Int).Value = pintDiskCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<clsSong> songs = new List<clsSong>();

                while (result.Read())
                {
                    clsSong tmp = new clsSong();
                    tmp.Name = (result["Nombre"].ToString());
                    tmp.Link = (result["Video"].ToString());
                    DateTime dat = Convert.ToDateTime(result["Duracion"].ToString());
                    tmp.Duration = dat.ToString("hh:mm tt");
                    tmp.Type = Convert.ToBoolean(result["EnVivo"].ToString());
                    tmp.LimitedEdition = Convert.ToBoolean(result["EdicionLimitada"].ToString());
                    songs.Add(tmp);
                }
                pclsDisk.Songs = songs;

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

        public void getdiskinfo(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintDiskCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetInfoDisc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intDisc", System.Data.SqlDbType.Int).Value = pintDiskCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    pclsDisk.Name = (result["Nombre"].ToString());
                    DateTime dat = Convert.ToDateTime(result["Fecha"].ToString());
                    pclsDisk.DateCreation = dat.ToString("yyyy");
                    pclsDisk.Genre = (result["Genero"].ToString());
                    pclsDisk.Label = (result["SelloDiscografico"].ToString());

                }

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

        public void getdiskreviews(ref List<clsReview> pclsReviews, ref clsResponse pclsResponse, int pintDiskCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetReviewDiscs", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intDisc", System.Data.SqlDbType.Int).Value = pintDiskCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();

                List<clsReview> reviews = new List<clsReview>();
                while (result.Read())
                {
                    clsReview tmp = new clsReview();
                    tmp.Author = (result["strNombre"].ToString());
                    tmp.Calification = (result["intClasificacion"].ToString());
                    tmp.Comment = (result["strComentario"].ToString());
                    reviews.Add(tmp);

                }
                pclsReviews = reviews;
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

        public bool existreviewdisk(int pintCodDisk, int pintUserCode, ref clsResponse pclsResponse)
        {
            bool tmp = false;
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_ExistReviewDisc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodDisco", System.Data.SqlDbType.Int).Value = pintCodDisk;
                cmd.Parameters.Add("@intCodUser", System.Data.SqlDbType.Int).Value = pintUserCode;
                SqlParameter response = cmd.Parameters.Add("@btRespuesta", SqlDbType.Bit);
                response.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                tmp = Convert.ToBoolean(response.Value.ToString());
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
