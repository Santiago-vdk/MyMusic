﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DataAccess.FanDataAccess
{
    public class clsFanRead
    {

        private SqlConnection conn = new clsConnection().getPort();


        public clsForm getAllgenders(clsForm pclsForm, ref clsResponse pclsResponse)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_ObtenerSexosHabilitados", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<String> values = new List<String>();
                List<int> cods = new List<int>();
                while (result.Read())
                {
                    values.Add(result["strDescripcion"].ToString());
                    cods.Add(Convert.ToInt32(result["intCodSexo"]));
                }
                pclsForm.genders = values;
                pclsForm.codGenders = cods;
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
           

            return pclsForm;
        }

        public clsBandsBlock getBands(clsBandsBlock pclsBandsBlock, ref clsResponse pclsResponse, int pintUserID, int pintOffset,int pintLimit )
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("myFan.SP_GetBandasPorFanatico", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intOffset", System.Data.SqlDbType.Int).Value = pintOffset;
                cmd.Parameters.Add("@intRows", System.Data.SqlDbType.Int).Value = pintLimit;
                cmd.Parameters.Add("@intCodeUser", System.Data.SqlDbType.Int).Value = pintUserID;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();

                List<String> values = new List<String>();
                List<String> cods = new List<String>();
                List<clsSimpleInfo> bands = new List<clsSimpleInfo>();
                pclsBandsBlock.Limit = false;
                while (result.Read())
                {
                    clsSimpleInfo tmp = new clsSimpleInfo();
                    tmp.Name = result["strNombre"].ToString();
                    tmp.Id = Convert.ToInt32(result["intCodBanda"].ToString());                  
                    DateTime dat = Convert.ToDateTime(result["dtAnoCreacion"].ToString());
                    tmp.DateCreation = dat.ToString("yyyy");
                    bands.Add(tmp);
                }

               
                
                if (cods.Count < pintLimit)
                {
                    pclsBandsBlock.Limit = true;
                }
                pclsBandsBlock.Bands = bands;
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


            return pclsBandsBlock;
        }

        public List<clsPublication> getWall(ref clsResponse pclsResponse, int pintUserID, int pintOffset, int pintLimit)
        {
            List<clsPublication> Wall = new List<clsPublication>();
            try
            {    
                SqlCommand cmd = new SqlCommand("myFan.SP_GetNewsEventsWall", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intOffset", System.Data.SqlDbType.Int).Value = pintOffset;
                cmd.Parameters.Add("@intRows", System.Data.SqlDbType.Int).Value = pintLimit;
                cmd.Parameters.Add("@inCodeUser", System.Data.SqlDbType.Int).Value = pintUserID;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();




                while (result.Read())
                {
                    clsPublication tmp = new clsPublication();
                    tmp.Title = result["Nombre"].ToString();
                    tmp.Content = result["Descripcion"].ToString();
                    DateTime dat = Convert.ToDateTime(result["Fecha"].ToString());
                    tmp.Date = dat.ToString("yyyy-MM-dd");
                    tmp.Type = Convert.ToInt32(result["Tipo"].ToString());
                    tmp.Id = Convert.ToInt32(result["Codigo"].ToString());
                    tmp.OwnerId = Convert.ToInt32(result["IDOwner"].ToString()); 
                    Wall.Add(tmp);
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


            return Wall;
        }

        public clsBandsBlock getBandsSearch(clsBandsBlock pclsBandsBlock, ref clsResponse pclsResponse,ref clsSearch pclsSearch, int pintOffset, int pintLimit)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_GetBandFilteredByName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intOffset", System.Data.SqlDbType.Int).Value = pintOffset;
                cmd.Parameters.Add("@intRows", System.Data.SqlDbType.Int).Value = pintLimit;
                cmd.Parameters.Add("@strPais", System.Data.SqlDbType.VarChar).Value = pclsSearch.Country;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value =  pclsSearch.Genre;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsSearch.Name;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();

                List<String> values = new List<String>();
                List<String> cods = new List<String>();
                List<clsSimpleInfo> bands = new List<clsSimpleInfo>();
                while (result.Read())
                {
                    clsSimpleInfo tmp = new clsSimpleInfo();
                    tmp.Name = result["NombreBanda"].ToString();
                    tmp.Id = Convert.ToInt32(result["UserCode"].ToString());
                    DateTime dat = Convert.ToDateTime(result["FechaCreacion"].ToString());
                    tmp.DateCreation = dat.ToString("yyyy");
                    bands.Add(tmp);
                }



                pclsBandsBlock.Bands = bands;
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
                pclsResponse.Message = "Unexpected error.";
            }
            finally
            {
                conn.Close();
            }


            return pclsBandsBlock;
        }


        public void getFanInfo(ref clsInfoFan pclsInfoFan, ref clsResponse pclsResponse, int pintUserID)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_GetFanaticProfile", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodeUser", System.Data.SqlDbType.Int).Value = pintUserID;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    pclsInfoFan.Username = result["LoginName"].ToString();
                    pclsInfoFan.Name = result["NombreFanatico"].ToString();
                    pclsInfoFan.Country = result["Pais"].ToString();
                    pclsInfoFan.Gender = result["Sexo"].ToString();
                    DateTime dat = Convert.ToDateTime(result["Fecha"].ToString(), CultureInfo.InvariantCulture);

                    pclsInfoFan.Birthday = dat.ToString("yyyy") + "-" + dat.ToString("MM") + '-' + dat.ToString("dd");


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

        public void getGenresFan(ref clsInfoFan pclsInfoFan, ref clsResponse pclsResponse, int pintUserCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetGenresByUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUserCode", System.Data.SqlDbType.Int).Value = pintUserCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<String> tmpGenres = new List<string>();
                List<int> tmpCodGenres = new List<int>();
                while (result.Read())
                {
                    tmpGenres.Add(result["DescripcionGenero"].ToString());
                    tmpCodGenres.Add(Convert.ToInt32(result["CodigoGenero"].ToString()));
                }
                pclsInfoFan.Genres = tmpGenres;
                pclsInfoFan.CodGenres = tmpCodGenres;
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

        public bool isFollowBand(int pintCodFanatico, int pintCodBanda, ref clsResponse pclsResponse)
        {
            bool tmp = false;
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_IsFollower", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodUserFanatico", System.Data.SqlDbType.Int).Value = pintCodFanatico;
                cmd.Parameters.Add("@intCodUserBand", System.Data.SqlDbType.Int).Value = pintCodBanda;
                SqlParameter cod = cmd.Parameters.Add("@btResult", SqlDbType.Bit);
                cod.Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                tmp = Convert.ToBoolean(cod.Value.ToString());
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
                pclsResponse.Message = "Unexpected error.";
            }
            finally
            {
                conn.Close();
            }
            return tmp;
        }

        public void getReviewBand(ref clsReview pclsReview, ref clsResponse pclsResponse, int pintFanCode, int pintBandCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetReviewBands", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUserFanCode", System.Data.SqlDbType.Int).Value = pintFanCode;
                cmd.Parameters.Add("@intUserBandCode", System.Data.SqlDbType.Int).Value = pintFanCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<String> tmpGenres = new List<string>();
                List<int> tmpCodGenres = new List<int>();
                while (result.Read())
                {
                    pclsReview.Comment =  (result["Comentario"].ToString());
                    pclsReview.Calification = result["CodigoGenero"].ToString();
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








        public static void Main()
        {
            clsFanRead a = new clsFanRead();
            Serializer b = new Serializer();
            clsBandsBlock h = new clsBandsBlock();
            clsResponse d= new clsResponse();
            //c.FanCod = 98;
            //c.Chunks = 10;
            //c.Offset = 10;
            clsSearch k = new clsSearch();
            k.Name = "";
            List<Int32> l = new List<int>();
            l.Add(0);
            k.Genre = "Pop";
            k.Country = "";
        
            Console.WriteLine(b.Serialize(a.getBandsSearch(h, ref d, ref k, 0, 5)));
            Console.WriteLine(d.Message);
            Console.ReadKey();
        }
    }

}
