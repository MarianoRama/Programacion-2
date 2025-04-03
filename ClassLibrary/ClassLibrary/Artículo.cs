namespace LogicaNegocio
{
    public class Articulo
    {
        // ATRIBUTO Estático
        private static int s_ultimoId = 0;
        
        // ATRIBUTOS
        private int _id { get; }
        private string _nombre;
        private Categoria _categoria;
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
        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        // CONSTRUCTOR
        public Articulo(string unNombre, Categoria unaCategoria, decimal unPrecio)
        {
            this._id = Articulo.s_ultimoId++;
            this._nombre = unNombre;
            this._categoria = unaCategoria;
            this._precio = unPrecio;
            this.Validar();
        }

        // VALIDACIONES
        public void Validar()
        {
            Articulo.ValidarNombre(this._nombre);
            Articulo.ValidarPrecio(this._precio);
        }
        public static void ValidarNombre(string unNombre)
        {
            if (unNombre == null || unNombre.Length <= 2)
                throw new Exception("El nombre debe contener más de 2 caracterees.");
        }
        public static void ValidarPrecio(decimal unPrecio)
        {
            if (unPrecio ==null || unPrecio <= 0)
                throw new Exception("El precio debe ser mayor a 0.");
        }

        // Equals ID
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Articulo)) return false;
            Articulo elArticulo = obj as Articulo;
            return this.Id == elArticulo.Id;
        }
        public override string ToString()
        {
            return " - Id: " + this.Id +
                 "\n - Nombre: " + this.Nombre +
                 "\n - Categoría: " + this.Categoria +
                 "\n - Precio: $" + this.Precio;
        }
    }
}
