using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities.models;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace SistemaGestionBussiness
{
    public static class ProductoService
    {
        public static List<Producto> ListarProductos()
        {
            List<Producto> listadoDeProductos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(ProductoData.ConnectionString))
            {
                string query = "SELECT * FROM Producto";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.id = Convert.ToInt32(reader["ID"]);
                    producto.descripcion = reader["descripcion"].ToString();
                    producto.precioventa = Convert.ToDecimal(reader["precioventa"]);
                    producto.stock = Convert.ToInt32(reader["stock"]);
                    producto.costo = Convert.ToInt32(reader["costo"]);


                    listadoDeProductos.Add(producto);
                }
            }
            return listadoDeProductos;
        }

        public static Producto ObtenerProductos(int id)
        {
            using (SqlConnection connection = new SqlConnection(ProductoData.ConnectionString))
            {
                string query = "SELECT * FROM Producto where id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string descripcion = reader.GetString(1);
                    decimal precioventa = Convert.ToDecimal(reader.GetString(2));
                    int stock = Convert.ToInt32(reader.GetString(3));
                    int costo = Convert.ToInt32(reader.GetString(4));
                    Producto producto = new Producto();
                    return producto;
                }
                throw new Exception("Id no encontrado");

            }
        }
    
        
    }
}
