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


        public clsForm getAllgenders(clsForm pclsForm)
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
            conn.Close();

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
