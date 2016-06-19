using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EventsDataAccess
{
    public class clsEventsWrite
    {
        private SqlConnection conn = new clsConnection().getPort();

        public int createEvent(ref clsEvent pclsEvent, ref clsResponse pclsResponse, int pintUserCode)
        {
            int tmp = new int();
            try
            {
                TimeSpan time = TimeSpan.Parse(pclsEvent.Time);
                DateTime dat = Convert.ToDateTime(pclsEvent.Date, CultureInfo.InvariantCulture);
                SqlCommand cmd = new SqlCommand("myFan.SP_IngresarEvento", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsEvent.Title;
                cmd.Parameters.Add("@strDescripcion", System.Data.SqlDbType.VarChar).Value = pclsEvent.Description;
                cmd.Parameters.Add("@strUbicacion", System.Data.SqlDbType.VarChar).Value = pclsEvent.Location;
                cmd.Parameters.Add("@btEsConcierto", System.Data.SqlDbType.Bit).Value = pclsEvent.IsConcert;
                cmd.Parameters.Add("@strEstado", System.Data.SqlDbType.VarChar).Value = pclsEvent.State;
                cmd.Parameters.Add("@intCodUsuario", System.Data.SqlDbType.Int).Value = pintUserCode;
                cmd.Parameters.Add("@dtFechaHora", System.Data.SqlDbType.DateTime).Value = dat + time;
                SqlParameter id = cmd.Parameters.Add("@intCodEvento", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                tmp = Convert.ToInt32(id.Value);
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return tmp;
        }
        public void changeStateEvent(String State, ref clsResponse pclsResponse, int pintEventCode)
        {
            try
            {             
                SqlCommand cmd = new SqlCommand("myFan.SP_ChangeStateEvento", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strState", System.Data.SqlDbType.VarChar).Value = State;
                cmd.Parameters.Add("@intCodEvent", System.Data.SqlDbType.Int).Value = pintEventCode;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
