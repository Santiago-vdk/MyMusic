using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                while (result.Read())
                {
                    values.Add(result["strDescripcion"].ToString());
                }
                pclsForm.genders = values;
                pclsForm.ErrorCode = "0";
                pclsForm.ErrorMessage = "Done";        
            }
            catch (SqlException ex)
            {
                pclsForm.ErrorCode= ex.ErrorCode.ToString();
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
            clsFanRead a = new clsFanRead();
            //Console.WriteLine(a.getAllgenders(new clsForm()).genres[1].strDescripcion);
            Console.ReadKey();
        }
    }
}
