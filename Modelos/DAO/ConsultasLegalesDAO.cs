using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Modelos.DAO
{
    class ConsultasLegalesDAO
    {
        SqlCommand comando = new SqlCommand();

        public bool EstadoTicket(TipoSoportes tiposoportes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TIPOSOPORTE ");
                sql.Append(" VALUES (@TipoSoportes, @Dispositivo, @Precio, @Descripcion); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@TipoSoportes", SqlDbType.NVarChar, 50).Value = tiposoportes.TipoSoporte;
                comando.Parameters.Add("@Dispositivo", SqlDbType.NVarChar, 50).Value = tiposoportes.Dispositivo;
                comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = tiposoportes.Precio;
                comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 80).Value = tiposoportes.Descripcion;
                comando.ExecuteNonQuery();
                return true;
                MiConexion.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetTipo()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM TIPOSOPORTE ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
            }
            return dt;
        }

        public bool EliminarTipo(int id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM TIPOSOPORTE ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();

            }
            catch (Exception ex)
            {
                return modifico;
            }
            return modifico;
        }
    }
}

