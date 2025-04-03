namespace LogicaNegocio
{
    public abstract class Publicacion : IComparable<Publicacion>
    {
        // ATRIBUTO Estático
        private static int s_ultimoId = 0;

        // ATRIBUTOS
        private int _id;
        private string _nombre;
        private Estado _estado;
        private DateTime _fechaPublicacion;
        private List<Articulo> _articulos = new List<Articulo>();
        private Cliente _clienteComprador; // Null mientras esté ABIERTA
        private Usuario _usuarioFinalizador; // Null mientras esté ABIERTA
        private DateTime? _fechaFinalizacion; // Null mientras esté ABIERTA
        private decimal _precio;

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
        public Estado Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public DateTime FechaPublicación
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; }
        }
        public List<Articulo> Articulos
        {
            get { return _articulos; }
        }
        public Cliente ClienteComprador
        {
            get { return _clienteComprador; }
            set { _clienteComprador = value; }
        }
        public Usuario UsuarioFinalizador
        {
            get { return _usuarioFinalizador; }
            set { _usuarioFinalizador = value; }
        }
        public DateTime? FechaFinalización
        {
            get { return _fechaFinalizacion; }
            set { _fechaFinalizacion = value; }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        // CONSTRUCTOR
        public Publicacion(string unNombre, DateTime unFechaPublicación)
        {
            int id = Publicacion.s_ultimoId++;
            this._id = id;
            this._nombre = unNombre;
            this._estado = Estado.ABIERTA;
            this._fechaPublicacion = unFechaPublicación;
            this._clienteComprador = null;
            this._usuarioFinalizador = null;
            this._fechaFinalizacion = null;
            this.Validar();
        }
        // CONSTRUCTOR SIN PARÁMETROS
        public Publicacion()
        {
            this._id = Publicacion.s_ultimoId++;
        }

        // AGREGAR A LISTA
        public void AgregarArticulo(Articulo unArticulo)
        {
            try
            {
                unArticulo.Validar();
                this._articulos.Add(unArticulo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // VALIDACIONES
        public void Validar()
        {
            Publicacion.ValidarNombre(this._nombre);
        }
        private static void ValidarNombre(string unNombre)
        {
            if (unNombre == null || unNombre.Length <= 2)
                throw new Exception("El nombre debe contener más de 2 caracteres.");
        }

        // Equals ID, Nombre y FechaPublicacion
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Publicacion)) return false;
            Publicacion unaPublicacion = obj as Publicacion;
            return this._id == unaPublicacion._id &&
                this._nombre == unaPublicacion._nombre &&
                this._fechaPublicacion == unaPublicacion._fechaPublicacion;
        }
        public override string ToString()
        {
            return " - Id: " + this.Id +
                 "\n - Nombre: " + this.Nombre +
                 "\n - Estado: " + this.Estado +
                 "\n - Fecha: " + this.FechaPublicación;
        }

        // POLIMORFIMSO
        public abstract decimal CalcularPrecioFinal();
        public abstract void FinalizarPublicacion(Usuario unUsuario);

        // Ordenar fecha descendiente.
        public int CompareTo(Publicacion? other)
        {
            return this.FechaPublicación.CompareTo(other.FechaPublicación) * -1;
        }
    }
}