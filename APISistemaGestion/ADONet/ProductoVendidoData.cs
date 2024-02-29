using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class ProductoVendidoData
    {
        private static string connectionString;

        static ProductoVendidoData()
        {
            ProductoVendidoData.connectionString = "Server= localhost\\sqlexpress ; Database=coderhouseBD;Trusted_Connection=true";
        }
        public static List<ProductoVendido> ListarProdVendido()
        {
            List<ProductoVendido> listadoDeProductosVend = new List<ProductoVendido>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    ProductoVendido productoVend = new ProductoVendido();
                    productoVend.Id = Convert.ToInt32(reader["ID"]);
                    productoVend.idventa = Convert.ToInt32(reader["idventa"]);
                    productoVend.stock = Convert.ToInt32(reader["stock"]);
                    productoVend.idproducto = Convert.ToInt32(reader["idproducto"]);


                    listadoDeProductosVend.Add(productoVend);
                }
            }
            return listadoDeProductosVend;
        }

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(ProductoVendidoData.connectionString))
            {
                string query = "SELECT * FROM ProductoVendido where id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    int idVenta = Convert.ToInt32(reader.GetString(2));
                    int stock = Convert.ToInt32(reader.GetString(3));
                    int idProducto = Convert.ToInt32(reader.GetString(4));
                    ProductoVendido productoVendido = new ProductoVendido();
                    return productoVendido;
                }
                throw new Exception("Id no encontrado");

            }
        }
        public static bool CrearProductoVendido(ProductoVendido productovendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductoVendido (idVenta,stock,idProducto) VALUES (@idVenta,@stock,@idProducto)";

                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("idVenta", productovendido.idventa);
                comando.Parameters.AddWithValue("stock", productovendido.stock);
                comando.Parameters.AddWithValue("idProducto", productovendido.idproducto);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;

            }
        }
        public static bool ModificarProductoVendido(int id, ProductoVendido productovendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductoVendido SET idVenta = @idVenta, stock = @stock, idProducto = @idProducto WHERE id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("idVenta", productovendido.idventa);
                comando.Parameters.AddWithValue("stock", productovendido.stock);
                comando.Parameters.AddWithValue("idProducto", productovendido.idproducto);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;

            }

        }
        public static bool EliminarProductoVendido(int id, ProductoVendido productovendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductoVendido WHERE id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;
            }

        }

    }
}
