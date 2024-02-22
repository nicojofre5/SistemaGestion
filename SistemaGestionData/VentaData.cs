using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class VentaData
    {
        private static string connectionString;
        static VentaData()
        {
            VentaData.connectionString = "Server= localhost\\sqlexpress ; Database=coderhouseBD;Trusted_Connection=true";
        }

        public static List<Venta> ListarVenta()
        {
            List<Venta> listadoDeVentas = new List<Venta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Venta";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta();
                    venta.id = Convert.ToInt32(reader["ID"]);
                    venta.comentarios = reader["comentarios"].ToString();


                    listadoDeVentas.Add(venta);
                }
            }
            return listadoDeVentas;

        }

        public static Venta ObtenerVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(VentaData.connectionString))
            {
                string query = "SELECT * FROM Venta where id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string comentarios = reader.GetString(1);
                    int idusuario = Convert.ToInt32(reader.GetString(2));
                    Venta venta = new Venta();
                    return venta;
                }
                throw new Exception("Id no encontrado");

            }
        }
        public static bool CrearVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Venta (comentarios,idusuario) VALUES (@comentarios,@idusuario)";

                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("comentarios", venta.comentarios);
                comando.Parameters.AddWithValue("idusuario", venta.idUsuario);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;

            }

        }
        public static bool ModificarVenta(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Venta SET comentarios = @comentarios,idusuario = @idusuario WHERE id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("comentarios", venta.comentarios);
                comando.Parameters.AddWithValue("idusuario", venta.idUsuario);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;

            }
        }
        public static bool EliminarVenta(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Venta WHERE id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;
            }

        }

    }
}
