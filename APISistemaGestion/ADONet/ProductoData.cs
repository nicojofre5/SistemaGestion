using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class ProductoData
    {
        private static string connectionString;
        static ProductoData()
        {
            ProductoData.connectionString = "Server= localhost\\sqlexpress ; Database = coderhouse; Trusted_Connection = True ; Integrated Security= True";
        }
        
        public static string ConnectionString
        {
            get { return connectionString; }
        }

        public static bool CrearProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ProductoData.ConnectionString))
            {
                string query = "INSERT INTO Producto (descripcion,precioventa,stock,costo) VALUES (@descripcion,@precioventa,@stock,@costo)";

                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("descripcion", producto.descripcion);
                comando.Parameters.AddWithValue("precioventa", producto.precioventa);
                comando.Parameters.AddWithValue("stock", producto.stock);
                comando.Parameters.AddWithValue("costo", producto.costo);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;

            }
        }
        public static bool ModificarProducto(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ProductoData.ConnectionString))
            {
                string query = "UPDATE Producto SET descripcion = @descripcion,precioventa = @precioventa,stock = @stock,costo = @costo WHERE id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("descripcion", producto.descripcion);
                comando.Parameters.AddWithValue("precioventa", producto.precioventa);
                comando.Parameters.AddWithValue("stock", producto.stock);
                comando.Parameters.AddWithValue("costo", producto.costo);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;

            }
        }
        public static bool EliminarProducto(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ProductoData.ConnectionString))
            {
                string query = "DELETE FROM Producto WHERE id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }


        }
    }
