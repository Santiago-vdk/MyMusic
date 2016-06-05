using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsFanRead
    {
        SqlConnection conn = new clsConnection().getPort();


        public clsForm getAllgenres(clsForm pclsForm)
        {
            SqlCommand cmd = new SqlCommand("myFan.SP_GetAllGenresAvaibles", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                clsDoubleValue tmp = new clsDoubleValue();
                 
            }
            conn.Close();
            return pclsForm;
        }

        public static void Main()
        {
           
            Console.ReadKey();
        }
    }
    
}
