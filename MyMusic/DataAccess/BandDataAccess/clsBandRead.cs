using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                List<int> codmembers = new List<int>();
                while (result.Read())
                {
                    members.Add(result["LoginName"].ToString());
                    codmembers.Add(Convert.ToInt32(result["Integrante"].ToString()));
                }
                pclsInfoBand.CodMembers = codmembers;
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


        public static void Main()
        {
            clsBandRead a = new clsBandRead();
            clsResponse b = new clsResponse();
            clsInfoBand d = new clsInfoBand();
            d.Hashtag = "@pene";
            a.validateHashTag(d, ref b);
            Console.WriteLine(b.Message);
            Console.ReadKey();
        }

    }
}
