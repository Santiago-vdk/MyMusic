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
        SqlConnection conn = null;
        private String database = " ";

        public clsConnection(){
            conn = new SqlConnection(database);
        }
        protected String SqlConnection { get; }// cambiar a tipo Port
        
       
        
    }
}
