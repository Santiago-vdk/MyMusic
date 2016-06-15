using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();

                List<String> values = new List<String>();
                List<String> cods = new List<String>();

                pclsBandsBlock.Limit = false;
                while (result.Read())
                {
                    clsInfoBandSimple tmp = new clsInfoBandSimple();
                    tmp.Name = result["strNombre"].ToString();
                    tmp.Id = Convert.ToInt32(result["intCodBanda"].ToString());
                    tmp.DateCreation = result["dtAnoCreacion"].ToString();
                    pclsBandsBlock.Bands.Add(tmp);
                }

               
                
                if (cods.Count < pintLimit)
                {
                    pclsBandsBlock.Limit = true;
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


            return pclsBandsBlock;
        }
        public static void Main()
        {
            clsFanRead a = new clsFanRead();
            Serializer b = new Serializer();
            clsBandsBlock c = new clsBandsBlock();
            clsResponse d= new clsResponse();
            //c.FanCod = 98;
            //c.Chunks = 10;
            //c.Offset = 10;
            //Console.WriteLine(b.Serialize(a.getBands(c,ref d)));
            Console.WriteLine(d.Message);
            Console.ReadKey();
        }
    }
}
