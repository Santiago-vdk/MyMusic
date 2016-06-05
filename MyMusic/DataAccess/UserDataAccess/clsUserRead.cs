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


        public clsForm getAllgenres(clsForm pclsForm)
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
            conn.Close();

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
