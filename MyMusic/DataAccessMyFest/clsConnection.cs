using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessMyFest
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

    }
}
