using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
namespace AccesoDatos
{
    class clsConnection
    {
        private SqlConnection conn = null;
        private String database = "Server=tcp:mymusic.database.windows.net,1433;Data Source=mymusic.database.windows.net;Initial Catalog=myMusic;Persist Security Info=False;User ID=David;Password=x100preXD;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public clsConnection()
        {
            conn = new SqlConnection(database);
            conn.Open();
        }
        protected SqlConnection getPort()
        {
            return conn;
        }

        public static void Main()
        {
            clsConnection conn = new clsConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CrearFanatico", conn.getPort());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = "Rafa";
                cmd.Parameters.Add("@strContrasena", System.Data.SqlDbType.VarChar).Value = "soyunbanano";
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = "Rafaelo el banano";
                cmd.Parameters.Add("@strContrasena", System.Data.SqlDbType.VarChar).Value = "soyunbanano";
            }
            catch (SqlException ex)
            {
                Console.Write("You failed!" + ex.Message);
                Console.ReadKey();
            }




        }

    }
}
