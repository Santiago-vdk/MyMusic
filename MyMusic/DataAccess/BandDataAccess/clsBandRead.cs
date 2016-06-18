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

namespace DataAccess.BandDataAccess
{
    public class clsBandRead
    {
        private SqlConnection conn = new clsConnection().getPort();

        public void validateHashTag(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_ExistsHashtag", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Hashtag", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Hashtag;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                result.Read();
                Console.WriteLine("entre");
                if (result.HasRows==true) {
                    if (result["Hagstag"].ToString().Equals("True"))
                    {
                        pclsResponse.Code = 0;
                        pclsResponse.Message = "Done";
                        pclsResponse.Success = true;
                    }
                    else
                    {
                        pclsResponse.Code = 3;
                        pclsResponse.Message = "Incorrect HashTag";
                        pclsResponse.Success = false;
                    }

                }
                else
                {
                    pclsResponse.Code = 3;
                    pclsResponse.Message = "Incorrect HashTag";
                    pclsResponse.Success = false;
                }
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

        public void getBandInfo(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserID)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_GetBandProfile", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserCode", System.Data.SqlDbType.Int).Value = pintUserID;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    pclsInfoBand.Username = result["LoginName"].ToString();
                    pclsInfoBand.Name = result["NombreBanda"].ToString();
                    pclsInfoBand.Country = result["Pais"].ToString();
                    pclsInfoBand.Hashtag = result["Hashtag"].ToString();
                    pclsInfoBand.Biography = result["Biografia"].ToString();
                    DateTime dat = Convert.ToDateTime(result["AnoCreacion"].ToString(), CultureInfo.InvariantCulture);
                    pclsInfoBand.DateCreation =  dat.ToString("yyyy")+"-" + dat.ToString("MM")+'-'+ dat.ToString("dd");

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

        public void getMembersInfo(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserID)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_GetMemberBand", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodBand", System.Data.SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@intCodUser", System.Data.SqlDbType.Int).Value = pintUserID;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<String> members = new List<string>();

                while (result.Read())
                {
                    members.Add(result["Nombre"].ToString());

                }

                pclsInfoBand.Members = members;
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

        public void getGenresBand(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserCode)
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
                pclsInfoBand.Genres = tmpGenres;
                pclsInfoBand.CodGenres = tmpCodGenres;
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

        public void getAlbums(ref clsDisksBlock pclsDisksBlock, ref clsResponse pclsResponse, int pintUserCode, int pintOffset, int pintLimit)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetDiscsByBand", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodeUser", System.Data.SqlDbType.Int).Value = pintUserCode;
                cmd.Parameters.Add("@intCodeBand", System.Data.SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@intOffset", System.Data.SqlDbType.Int).Value = pintOffset;
                cmd.Parameters.Add("@intRows", System.Data.SqlDbType.Int).Value = pintLimit;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<clsSimpleInfo> disks = new List<clsSimpleInfo>();

                while (result.Read())
                {
                    clsSimpleInfo tmp = new clsSimpleInfo();
                    tmp.Name = (result["Descripcion"].ToString());
                    DateTime dat = Convert.ToDateTime(result["dtFechaPublicacion"].ToString());
                    tmp.DateCreation = dat.ToString("yyyy");
                    tmp.Id = Convert.ToInt32(result["DiscCode"].ToString());
                    disks.Add(tmp);
                }
                pclsDisksBlock.Disks = disks;

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

        public int createdisk(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintUserCode)
        {
            int tmp = new int();
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_InsertarDisco", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intGenero", System.Data.SqlDbType.Int).Value = pclsDisk.CodGenre;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsDisk.Name;
                cmd.Parameters.Add("@dtFechaPublicacion", System.Data.SqlDbType.VarChar).Value = pclsDisk.DateCreation;
                cmd.Parameters.Add("@strSelloDiscografico", System.Data.SqlDbType.VarChar).Value = pclsDisk.Label;
                cmd.Parameters.Add("@intUser", System.Data.SqlDbType.Int).Value = pintUserCode;
                SqlParameter id = cmd.Parameters.Add("@intIdDisco", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                conn.Open();             
                cmd.ExecuteNonQuery();
                Console.Write("entre");
                tmp = Convert.ToInt32(id.Value.ToString());
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






        public static void Main()
        {
            clsBandRead a = new clsBandRead();
            clsResponse b = new clsResponse();
            clsDisk d = new clsDisk();
            d.Name = "camote";
            d.Label = "Sony";
            d.DateCreation = "2000-09-09";
            d.CodGenre = 1;

            Serializer r = new Serializer();
            
            Console.WriteLine(a.createdisk(ref d, ref b, 124));
            Console.WriteLine(b.Message);
            Console.ReadKey();
        }

    }
}
