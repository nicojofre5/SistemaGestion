using SistemaGestionData;
using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public static class UsuarioService
    {
        public static bool CrearUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(UsuarioData.ConnectionString))
            {
                string query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@nombre,@apellido,@nombreUsuario,@password,@email)";

                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("nombre", usuario.nombre);
                comando.Parameters.AddWithValue("apellido", usuario.apellido);
                comando.Parameters.AddWithValue("nombreUsuario", usuario.nombreusuario);
                comando.Parameters.AddWithValue("password", usuario.contrasena);
                comando.Parameters.AddWithValue("email", usuario.email);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }
        public static bool ModificarUsuario(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(UsuarioData.ConnectionString))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido , NombreUsuario = @nombreUsuario , Contraseña = @password, Mail = @email WHERE id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("nombre", usuario.nombre);
                comando.Parameters.AddWithValue("apellido", usuario.apellido);
                comando.Parameters.AddWithValue("nombreUsuario", usuario.nombreusuario);
                comando.Parameters.AddWithValue("password", usuario.contrasena);
                comando.Parameters.AddWithValue("email", usuario.email);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;

            }
        }
        public static bool EliminarUsuario(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(UsuarioData.ConnectionString))
            {
                string query = "DELETE FROM Usuario WHERE id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                connection.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
