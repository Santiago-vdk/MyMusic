using ODT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;


namespace AccesoDatos
{
    public class clsFanaticoDA
    {

        private SqlConnection sqlConecction;
        private SqlDataReader dr;
        private SqlCommand sqlCommand;

        public List<clsDoubleValue> obtenerListaSexos()
        {
            List<clsDoubleValue> lstSexos = new List<clsDoubleValue>();
            ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["myMusicConnection"];
            string connectionString = conSettings.ConnectionString;

            try
            {
                sqlConecction = new SqlConnection(connectionString);
                sqlConecction.Open();
                sqlCommand = new SqlCommand(" SELECT intCodSexo, strDescripcion FROM myFan.VW_ObtenerSexosHabilitados ",sqlConecction);
                dr = sqlCommand.ExecuteReader();

                while (dr.Read())
                {
                    clsDoubleValue objSexo = new clsDoubleValue();
                    objSexo.intCodigo = Int32.Parse(dr["intCodSexo"].ToString());
                    objSexo.strDescripcion = dr["strDescripcion"].ToString();
                    lstSexos.Add(objSexo);
                }

            }
            catch (SqlException error)
            {
                clsDoubleValue objSexo = new clsDoubleValue();
                objSexo.intCodigo = error.ErrorCode;
                objSexo.strDescripcion = error.Message;
                lstSexos.Add(objSexo);
            }
            catch (Exception error)
            {
                clsDoubleValue objSexo = new clsDoubleValue();
                objSexo.intCodigo = 0;
                objSexo.strDescripcion = error.Message;
                lstSexos.Add(objSexo);
            }
            finally
            {
                sqlConecction.Close();               
            }
            return lstSexos;
        }

    }
}
