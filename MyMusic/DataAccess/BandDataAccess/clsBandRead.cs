using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
