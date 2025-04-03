namespace LogicaNegocio
{
    public abstract class Usuario
    {
        // ATRIBUTOS
        private static int s_ultimoId = 0;
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contrasenia;

        // PROPIEDADES
        public int Id
        {
            get { return _id; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }

        // CONSTRUCTOR
        public Usuario(string unNombre, string unApellido, string unEmail, string unaContrasenia)
        {
            this._id = Usuario.s_ultimoId++;
            this._nombre = unNombre;
            this._apellido = unApellido;
            this._email = unEmail;
            this._contrasenia = unaContrasenia;
            this.Validar();
        }
        public Usuario()
        {
            this._id = Usuario.s_ultimoId++;
        }

        // VALIDACIONES   
        public void Validar()
        {
            Usuario.ValidarNombreYApellido(this);
            Usuario.ValidarConstrasenia(this);
        }
        private static void ValidarNombreYApellido(Usuario unUsuario)
        {
            if (unUsuario == null || unUsuario.Nombre.Length <= 2)
                throw new Exception("El nombre debe contener más de 2 caracteres.");
            if (unUsuario.Apellido.Length <= 2)
                throw new Exception("El apellido debe contener más de 2 caracterees.");
        }
        private static void ValidarConstrasenia(Usuario unUsuario)
        {
            if (unUsuario.Contrasenia.Length < 8)
                throw new Exception("La constrañseña tiene que tener minimo 8 digitos, al menos un número y una letra.");

            bool SeEncontroNum = false;
            bool SeEncontroLetra = false;

            for (int i = 0; i <= unUsuario.Contrasenia.Length - 1; i++)
            {
                char caracter = unUsuario.Contrasenia[i];
                // Verificar si es un número (0-9)
                if (caracter >= '0' && caracter <= '9') SeEncontroNum = true;

                // Verificar si es una letra (a-z o A-Z)
                if ((caracter >= 'a' && caracter <= 'z') || (caracter >= 'A' && caracter <= 'Z'))
                    SeEncontroLetra = true;
            }
            if (!SeEncontroNum && !SeEncontroLetra)
                throw new Exception("La constraseña tiene que tener al menos una letra y un número.");

        }

        // OVERRIDE
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Usuario)) return false;
            Usuario unUsuario = obj as Usuario;
            return this.Email == unUsuario.Email;
        }
        public override string ToString()
        {
            return " - Id: " + this.Id +
                 "\n - Nombre: " + this.Nombre;
        }
    }
}