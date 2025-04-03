namespace LogicaNegocio
{
    public class Venta : Publicacion
    {
        // ATRIBUTO
        private bool _ofertaRelampago;

        // PROPIEDAD
        public bool OfertaRelampago
        {
            get { return _ofertaRelampago; }
            set { _ofertaRelampago = value; }
        }

        // CONSTRUCTOR
        public Venta(string unNombre, DateTime unaFechaPublicación, bool unaOfertaRelampago)
            : base(unNombre, unaFechaPublicación)
        {
            this.OfertaRelampago = unaOfertaRelampago;
        }

        // POLIMORFISMO
        public override decimal CalcularPrecioFinal()
        {
            decimal precioFinal = 0;
            foreach (Articulo unArticulo in this.Articulos)
            {
                precioFinal += unArticulo.Precio;
            }
            if (this.OfertaRelampago) precioFinal -= (precioFinal * 20) / 100;
            return precioFinal;
        }

        // Realizar la ccompra de una Venta
        public void ComprarVenta(Cliente unCliente)
        {
            if (this.Estado != Estado.ABIERTA)
                throw new Exception("La publicación no está habilitada.");
            unCliente.RestarSaldo(this.CalcularPrecioFinal());
            FinalizarPublicacion(unCliente);
        }

        // POLIMORFISMO
        public override void FinalizarPublicacion(Usuario unUsuario)
        {
            if (unUsuario is Cliente cliente) this.ClienteComprador = cliente;
            else throw new Exception("Solo los cliente pueden comprar.");
            
            this.UsuarioFinalizador = unUsuario;
            this.FechaFinalización = DateTime.Now;
            this.Estado = Estado.CERRADA;
        }
    }
}