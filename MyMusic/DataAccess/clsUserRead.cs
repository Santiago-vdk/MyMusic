using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsUserRead
    {
        SqlConnection conn = new clsConnection().getPort();


        public clsForm getAllgenres(clsForm pclsForm)
        {
            SqlCommand cmd = new SqlCommand("myFan.SP_GetAllGenresAvaibles", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader result = cmd.ExecuteReader();
            List<clsDoubleValue> values = new List<clsDoubleValue>();
            while (result.Read())
            {
                clsDoubleValue tmp = new clsDoubleValue();
                tmp.intCodigo = Convert.ToInt32(result["intCodGenero"]);
                tmp.strDescripcion = result["strDescripcion"].ToString();
                values.Add(tmp);

            }
            pclsForm.genres = values;
            conn.Close();

            return pclsForm;
        }

        public static void Main()
        {
            clsUserRead a = new clsUserRead();
            Console.WriteLine(a.getAllgenres(new clsForm()).genres[1].intCodigo);
            Console.ReadKey();
        }
    }
}
