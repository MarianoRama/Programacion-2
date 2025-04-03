namespace LogicaNegocio
{
    public class Cliente : Usuario
    {
        // ATRIBUTO
        private decimal _saldo = 0;

        // PRPIEDAD
        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        // CONSTRUCTOR
        public Cliente() : base() { }

        // CONSTRUCTOR
        public Cliente(string unNombre, string unApellido, string email, string unaContrasenia, decimal saldo)
            : base(unNombre, unApellido, email, unaContrasenia)
        {
            this.Saldo = saldo;
        }

        //EQUALS ID
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Cliente)) return false;
            Cliente unCliente = obj as Cliente;
            return this.Id == unCliente.Id;
        }

        public void CargarSaldo(decimal unMonto)
        {
            if (unMonto > 0) this.Saldo += unMonto;
            else throw new Exception("El monto a recargar debe ser mayor a 0.");
        }

        public void RestarSaldo(decimal unPrecio)
        {
            if (this.Saldo >= unPrecio) this.Saldo -= unPrecio;
            else throw new Exception("Saldo insuficiente.");
        }
    }
}