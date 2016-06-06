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
                while (result.Read())
                {
                    values.Add(result["strDescripcion"].ToString());
                }
                pclsForm.genres = values;
                pclsForm.ErrorCode = "0";
                pclsForm.ErrorMessage = "Done";
            }
            catch (SqlException ex)
            {
                pclsForm.ErrorCode = ex.ErrorCode.ToString();
                pclsForm.ErrorMessage = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                pclsForm.ErrorCode = "s001";
                pclsForm.ErrorMessage = ex.Message.ToString();
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
