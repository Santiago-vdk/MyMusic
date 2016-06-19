using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NewsDataAccess
{
    public class clsNewsRead
    {
        private SqlConnection conn = new clsConnection().getPort();

        public void getnew(ref clsNew pclsNew, ref clsResponse pclsResponse, int pintCodeNew)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetNew", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodNew", System.Data.SqlDbType.Int).Value = pintCodeNew;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    pclsNew.BandName  = result["Banda"].ToString();
                    pclsNew.Content = result["Contenido"].ToString();
                    pclsNew.Title = result["Encabezado"].ToString();
                    DateTime dat = Convert.ToDateTime(result["Fecha"].ToString(), CultureInfo.InvariantCulture);               
                    pclsNew.Date = dat.ToString("yyyy") + "-" + dat.ToString("MM") + '-' + dat.ToString("dd");
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
    }
}
