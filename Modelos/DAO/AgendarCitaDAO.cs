using Proyecto_Final.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Modelos.DAO
{
    public class AgendarCitaDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool AgendarCita(AgendarCita creacion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO AGENDAR ");
                sql.Append(" VALUES (@Servicio, @NombreCliente, @Email, @Direccion, @DescripcionCaso); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Servicio", SqlDbType.NVarChar, 50).Value = creacion.Servicio;
                comando.Parameters.Add("@NombreCliente", SqlDbType.NVarChar, 80).Value = creacion.NombreCliente;
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = creacion.Email;
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 80).Value = creacion.Direccion;
                comando.Parameters.Add("@DescripcionCaso", SqlDbType.NVarChar, 100).Value = creacion.DescripcionCaso;
                comando.ExecuteNonQuery();
                return true;
                MiConexion.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetAgendar()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM AGENDAR ");

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

        public bool EliminarUsuario(int id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM AGENDAR ");
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

        internal static bool CreacionNuevaCita(AgendarCitaView agendar)
        {
            throw new NotImplementedException();
        }
    }
}
