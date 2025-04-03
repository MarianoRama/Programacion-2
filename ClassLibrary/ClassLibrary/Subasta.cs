namespace LogicaNegocio
{
    public class Subasta : Publicacion
    {
        // LISTA
        private List<Oferta> _ofertas = new List<Oferta>();

        // PROPIEDAD
        public List<Oferta> Ofertas { get { return _ofertas; } }

        //CONSTRUCTOR 
        public Subasta(string unNombre, DateTime unaFechaPublicación)
            : base(unNombre, unaFechaPublicación)
        {
        }

        // AGREGAR A LISTA
        public void AgregarOferta(Oferta unaOferta)
        {
            try
            {
                unaOferta.Validar();
                this._ofertas.Add(unaOferta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //POLIMORFISMO
        public override decimal CalcularPrecioFinal()
        {
            decimal precioFinal = 0;

            if (Ofertas.Count == 0) precioFinal = 0;
            else precioFinal = Ofertas[Ofertas.Count - 1].Monto;

            return precioFinal;
        }

        //Cliente realiza una oferta a una subasta
        public void Ofertar(Oferta unaOferta)
        {
            if (Ofertas.Count > 0)
            {
                if (unaOferta.Monto > Ofertas[Ofertas.Count - 1].Monto && !(Ofertas.Contains(unaOferta)))
                    this.AgregarOferta(unaOferta);
                else
                    throw new Exception("EL monto a ofertar debe ser mayor al precio de la oferta.");
            }
            else
            {
                this.AgregarOferta(unaOferta);
            }
        }

        //POLIMORFISMO
        // Administrador finaliza una Subasta
        public override void FinalizarPublicacion(Usuario unUsuario)
        {
            if (this.Estado != Estado.ABIERTA) throw new Exception("La publicación no está habilitada.");

            if (unUsuario is Administrador administrador) this.UsuarioFinalizador = administrador;
            else throw new Exception("Un cliente no puede finalizar una subasta.");

            this.ClienteComprador = MejorOferta().Usuario;
            this.FechaFinalización = DateTime.Now;
            this.Estado = Estado.CERRADA;
        }

        //Verificaoms si el mejor ofertante tiene saldo, sino pasamos al siguiente mejor ofertante.
        public Oferta MejorOferta()
        {
            if (this._ofertas.Count > 0)
            {
                foreach (Oferta oferta in _ofertas)
                {
                    try
                    {
                        oferta.Usuario.RestarSaldo(oferta.Monto);
                        this.Precio = oferta.Monto;
                        return oferta;
                    }
                    catch { }
                }
            }
            this.Estado = Estado.CANCELADA;
            throw new Exception("No existen ofertas válidas.");
        }
    }
}