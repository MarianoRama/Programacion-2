namespace LogicaNegocio
{
    public class Oferta : IComparable<Oferta>
    {
        // ATRIBUTO Estático
        private static int s_ultimoId = 0;

        // ATRIBUTOS
        private int _id;
        private Cliente _usuario;
        private decimal _monto;
        private DateTime _fecha;

        // PROPIEDADES
        public int Id
        {
            get { return _id; }
        }
        public Cliente Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        // CONSTRUCTOR
        public Oferta(Cliente unUsuario, decimal unMonto, DateTime unaFecha)
        {
            this._id = Oferta.s_ultimoId++;
            this._usuario = unUsuario;
            this._monto = unMonto;
            this._fecha = unaFecha;
            this.Validar();
        }
        // CONSTRUCOR SIN PARÁMETROS
        public Oferta()
        {
            this._id = Oferta.s_ultimoId++;
        }

        // VALIDACIONES
        public void Validar()
        {
            Oferta.ValidarMonto(this._monto);
        }
        private static void ValidarMonto(decimal unMonto)
        {
            if (unMonto == null || unMonto <= 0)
                throw new Exception("El monto ofertado debe ser mayor a 0.");
        }

        //Equals usuario
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Oferta)) return false;
            Oferta unaOferta = obj as Oferta;
            return this.Usuario == unaOferta.Usuario;
        }

        // Ordenar monto descendiente.
        public int CompareTo(Oferta? other)
        {
            return this.Monto.CompareTo(other.Monto) * -1;
        }
    }
}