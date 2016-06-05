using ODT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


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



        public clsFanForm crearFanatico(clsFanForm pFanatico)
        {
            ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["myMusicConnection"];
            string connectionString = conSettings.ConnectionString;
            sqlConecction = new SqlConnection(connectionString);
            try
            {
                
                SqlCommand cmd = new SqlCommand("myFan.SP_CrearFanatico", sqlConecction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = pFanatico.Username;
                cmd.Parameters.Add("@strContrasena", System.Data.SqlDbType.VarChar).Value = pFanatico.Password;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pFanatico.Name;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = pFanatico.Genres.ToString();
                cmd.Parameters.Add("@dtFechaNacimiento", System.Data.SqlDbType.Date).Value = pFanatico.Birthday;
                cmd.Parameters.Add("@strEstado", System.Data.SqlDbType.VarChar).Value = pFanatico.EstadoSite;
                cmd.Parameters.Add("@strPais", System.Data.SqlDbType.VarChar).Value = pFanatico.Country;
                cmd.Parameters.Add("@intSexo", System.Data.SqlDbType.Int).Value = pFanatico.intSexo;
                cmd.Parameters.Add("@strSalt", System.Data.SqlDbType.VarChar).Value = pFanatico.strSalt;
                cmd.Parameters.Add("@strSaltHashedPassword", System.Data.SqlDbType.VarChar).Value = pFanatico.strSaltPassword;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                sqlConecction.Open();
                cmd.ExecuteNonQuery();
                pFanatico.CodigoError =cod.Value.ToString();
                pFanatico.MensageError = message.Value.ToString();
            }
            catch (SqlException ex)
            {
                pFanatico.CodigoError = ex.ErrorCode.ToString();
                pFanatico.MensageError = ex.Message;
            }
            catch (Exception ex)
            {
                pFanatico.CodigoError = "s001";
                pFanatico.MensageError = ex.Message;
            }
            finally
            {
                sqlConecction.Close(); 
            }
            return pFanatico;
        }


    }
}
