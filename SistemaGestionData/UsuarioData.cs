using SistemaGestionEntities.models;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class UsuarioData
    {
        private static string connectionString;
        static UsuarioData()
        {
            UsuarioData.connectionString = "Server= localhost\\sqlexpress ; Database=coderhouseBD;Trusted_Connection=true";
        }
        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> listadoDeUsuarios = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM USUARIO";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["ID"]);
                    usuario.nombre = reader["nombre"].ToString();
                    usuario.apellido = reader["apellido"].ToString();
                    usuario.nombreusuario = reader["nombreusuario"].ToString();
                    usuario.contrasena = reader["contrasena"].ToString();
                    usuario.email = reader["email"].ToString();

                    listadoDeUsuarios.Add(usuario);
                }
            }
            return listadoDeUsuarios;
        }

        public static Usuario ObtenerUsuario(int ID)
        {
            using (SqlConnection connection = new SqlConnection(UsuarioData.connectionString))
            {
                string query = "SELECT * FROM Usuario where id = @id";
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", ID);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string email = reader.GetString(5);
                    Usuario usuario = new Usuario();
                    return usuario;
                }
                throw new Exception("Id no encontrado");

            }
        }
        public static bool CrearUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            using (SqlConnection connection = new SqlConnection(connectionString))
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
