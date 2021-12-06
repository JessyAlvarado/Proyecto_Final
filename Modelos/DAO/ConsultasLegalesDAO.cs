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
    public class ConsultasLegalesDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool ConsultasLegales(ConsultasLegales consultas)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO CONSULTA ");
                sql.Append(" VALUES (@Servicios, @Nombre, @NumeroIde, @Descripcion); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Servicios", SqlDbType.NVarChar, 50).Value = consultas.Servicios;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = consultas.Nombre;
                comando.Parameters.Add("@NumeroIde", SqlDbType.Decimal).Value = consultas.NumeroID;
                comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 80).Value = consultas.Descripcion;
                comando.ExecuteNonQuery();
                return true;
                MiConexion.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetConsultas()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM CONSULTA ");

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

        public bool EliminarConsulta(int id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM CONSULTA ");
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

        internal static bool CreacionNuevaConsulta(ConsultasLegales consultas)
        {
            throw new NotImplementedException();
        }
    }
}

