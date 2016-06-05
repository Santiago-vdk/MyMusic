using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;

namespace DataAccess
{
    public class clsConnection
    {
        private SqlConnection conn = null;
        //ConnectionStringSettings conSettings = null;
        //string connectionString = null;

        public clsConnection()
        {
            //conSettings = ConfigurationManager.ConnectionStrings["myMusicConnection"];
            //connectionString = conSettings.ConnectionString;
            conn = new SqlConnection("Server=tcp:mymusic.database.windows.net,1433;Data Source=mymusic.database.windows.net;Initial Catalog=myMusic;Persist Security Info=False;User ID=David;Password=x100preXD;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public SqlConnection getPort()
        {
            return conn;
        }

        public static void Main()
        {
            clsConnection conn = new clsConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_CrearFanatico", conn.getPort());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = "aasdda";
                cmd.Parameters.Add("@strContrasena", System.Data.SqlDbType.VarChar).Value = "bsdad";
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = "casdas";
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = "Rock,Metal";
                cmd.Parameters.Add("@dtFechaNacimiento", System.Data.SqlDbType.Date).Value = "6-6-2007";
                cmd.Parameters.Add("@strEstado", System.Data.SqlDbType.VarChar).Value = "ajadssa";
                cmd.Parameters.Add("@strPais", System.Data.SqlDbType.VarChar).Value = "jrasdadr";
                cmd.Parameters.Add("@intSexo", System.Data.SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@strSalt", System.Data.SqlDbType.VarChar).Value = "salsalsaasdasssaal";
                cmd.Parameters.Add("@strSaltHashedPassword", System.Data.SqlDbType.VarChar).Value = "salslasldasdaalsal";
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                String a = message.Value.ToString();
                String b = cod.Value.ToString();
                conn.getPort().Close();
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.ReadKey();
            }
            catch (SqlException ex)
            {
                Console.Write("You failed!" + ex.Message);
                Console.ReadKey();
            }




        }

    }
}
