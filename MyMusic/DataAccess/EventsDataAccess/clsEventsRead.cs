using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EventsDataAccess
{
    public class clsEventsRead
    {
        private SqlConnection conn = new clsConnection().getPort();

        public void geteventinfo(ref clsEvent pclsEvent, ref clsResponse pclsResponse, int pintEventCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetEvent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodEvent", System.Data.SqlDbType.Int).Value = pintEventCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    pclsEvent.Title = (result["Nombre"].ToString());
                    pclsEvent.Description = (result["strDescripcion"].ToString());
                    pclsEvent.IsConcert = Convert.ToBoolean(result["Concierto"].ToString());
                    DateTime dat = Convert.ToDateTime(result["Fecha"].ToString());
                    pclsEvent.Date = dat.ToString("yyyy-MM-dd");
                    pclsEvent.Time = dat.ToString("HH:mm:ss");
                    pclsEvent.State = (result["Estado"].ToString());
                    pclsEvent.Location = (result["Ubicacion"].ToString());
                }

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


        public void geteventreviews(ref List<clsReview> pclsReviews, ref clsResponse pclsResponse, int pintEventCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetReviewsEvents", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodEvento", System.Data.SqlDbType.Int).Value = pintEventCode;
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

        public bool existreviewevent(int pintCodDisk, int pintUserCode, ref clsResponse pclsResponse)
        {
            bool tmp = false;
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_ExistReviewEvent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodEvento", System.Data.SqlDbType.Int).Value = pintCodDisk;
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

        public void getEventReviewFan(ref clsReview pclsReview, int pintCodEvent, int pintUserCode, ref clsResponse pclsResponse)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_getReviewEventUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUserCodFan", System.Data.SqlDbType.Int).Value = pintCodEvent;
                cmd.Parameters.Add("@intDisc ", System.Data.SqlDbType.Int).Value = pintUserCode;


                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    pclsReview.Comment = (result["Comentario"].ToString());
                    pclsReview.Calification = result["Calificacion"].ToString();
                }
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
