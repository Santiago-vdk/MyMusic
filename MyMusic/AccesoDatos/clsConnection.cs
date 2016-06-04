using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AccesoDatos
{
    class clsConnection
    {
        private SqlConnection conn = null;
        private String database = "Server=tcp:mymusic.database.windows.net,1433;Data Source=mymusic.database.windows.net;Initial Catalog=myMusic;Persist Security Info=False;User ID={your_username};Password={your_password};Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public clsConnection(){
            conn = new SqlConnection(database);
            conn.Open();
        }
        protected SqlConnection getPort() {
            return conn;
        }
        
       public static void  main()
        {
            clsConnection a = new clsConnection();
            a.getPort();

           
           
           
        } 
        
    }
}
