using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class Connection
    {
        protected static SqlConnection conn = null;

        protected Connection()
        {
            conn = new SqlConnection(" ");
        }
        
        protected SqlConnection getConnection()
        {
            return conn;
        }

    }
}
