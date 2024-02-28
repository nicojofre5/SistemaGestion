namespace SistemaGestionEntities.models
{
    public class Usuario
    {
        private int _id;
        private string? _nombre;
        private string? _apellido;
        private string? _nombreUsuario;
        private string? _contrasena;
        private string? _email;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string nombre
        {
            get { return _nombre; } 
            set { _nombre = value; }
        }
        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string nombreusuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }
        public string contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
