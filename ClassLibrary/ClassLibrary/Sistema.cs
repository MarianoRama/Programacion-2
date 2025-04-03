namespace LogicaNegocio
{
    public class Sistema
    {
        // SINGLETON
        private static Sistema s_instancia;

        // LISTAS
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Articulo> _catalogo = new List<Articulo>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();

        // SINGLETON 
        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }

        //PRPIEDADES
        public List<Usuario> Usuarios { get { return _usuarios; } }
        public List<Articulo> Catalogo { get { return _catalogo; } }
        public List<Publicacion> Publicaciones { get { return _publicaciones; } }

        //AGREGAR A LISTAS
        public void AgregarCatalogo(Articulo unArtilculo)
        {
            try
            {
                if (this._catalogo.Contains(unArtilculo))
                    throw new Exception("Ya existe este catálogo.");
                unArtilculo.Validar();
                this._catalogo.Add(unArtilculo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void AgregarPublicacion(Publicacion unaPublicacion)
        {
            try
            {
                if (this._publicaciones.Contains(unaPublicacion))
                    throw new Exception("Ya existe esa publicación.");
                unaPublicacion.Validar();
                this._publicaciones.Add(unaPublicacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void AgregarUsuario(Usuario unUsuario)
        {
            try
            {
                if (this._usuarios.Contains(unUsuario))
                    throw new Exception("Ya existe este usuario.");
                unUsuario.Validar();
                this._usuarios.Add(unUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //CONSTRUCTOR
        private Sistema()
        {
            this.PrecargaDatos();
        }

        //PRECARGA de DATOS
        private void PrecargaDatos()
        {
            this.PrecargarUsuario();
            this.PrecargarCatalogo();
            this.PrecargarVentas();
            this.PrecargarSubastas();
        }

        private void PrecargarUsuario()
        {
            // Precargar 10 clientes
            Cliente cliente1 = new Cliente("Juan", "Pérez", "a@gmail.com", "aasdasdasd1", 300);
            Cliente cliente2 = new Cliente("Ana", "García", "ana.garcia@email.com", "passAna456", 250);
            Cliente cliente3 = new Cliente("Luis", "Martínez", "luis.martinez@email.com", "luisPass789", 320);
            Cliente cliente4 = new Cliente("María", "López", "maria.lopez@email.com", "mariaPass321", 500);
            Cliente cliente5 = new Cliente("Carlos", "González", "carlos.gonzalez@email.com", "carlos987", 150);
            Cliente cliente6 = new Cliente("Lucía", "Rodríguez", "lucia.rodriguez@email.com", "lucia321", 400);
            Cliente cliente7 = new Cliente("Pedro", "Hernández", "pedro.hernandez@email.com", "pedro555", 270);
            Cliente cliente8 = new Cliente("Sofía", "Fernández", "sofia.fernandez@email.com", "sofiaPass222", 310);
            Cliente cliente9 = new Cliente("Andrés", "Sánchez", "andres.sanchez@email.com", "andres444", 380);
            Cliente cliente10 = new Cliente("Felipe", "Castro", "felipe.castro@email.com", "felipePass777", 200);

            // Agregamos los clientes al sistema
            this.AgregarUsuario(cliente1);
            this.AgregarUsuario(cliente2);
            this.AgregarUsuario(cliente3);
            this.AgregarUsuario(cliente4);
            this.AgregarUsuario(cliente5);
            this.AgregarUsuario(cliente6);
            this.AgregarUsuario(cliente7);
            this.AgregarUsuario(cliente8);
            this.AgregarUsuario(cliente9);
            this.AgregarUsuario(cliente10);

            // Crear 2 administradores
            Administrador admin1 = new Administrador("Valentina", "Taparí", "valen.tapari@email.com", "adminpass1");
            Administrador admin2 = new Administrador("Mariano", "Rama", "m@gmail.com", "mariano1111");

            // Agregar administradores a la lista de usuarios
            this.AgregarUsuario(admin1);
            this.AgregarUsuario(admin2);
        }
        private void PrecargarCatalogo()
        {
            // Artículos en la categoría: Deporte
            Articulo artc1 = new Articulo("Bicicleta", Categoria.Deporte, 150);
            Articulo artc2 = new Articulo("Camiseta de fútbol", Categoria.Deporte, 30);
            Articulo artc3 = new Articulo("Patines", Categoria.Deporte, 80);
            Articulo artc4 = new Articulo("Patineta", Categoria.Deporte, 120);
            Articulo artc5 = new Articulo("Pelota de básquet", Categoria.Deporte, 30);
            Articulo artc6 = new Articulo("Pelota de fútbol", Categoria.Deporte, 20);
            Articulo artc7 = new Articulo("Pesas", Categoria.Deporte, 90);
            Articulo artc8 = new Articulo("Raqueta de tenis", Categoria.Deporte, 75);
            Articulo artc9 = new Articulo("Zapatillas de running", Categoria.Deporte, 140);
            Articulo artc10 = new Articulo("Zapatillas deportivas", Categoria.Deporte, 120);

            // Artículos en la categoría: Electrónica
            Articulo artc11 = new Articulo("Auriculares", Categoria.Electronica, 70);
            Articulo artc12 = new Articulo("Cámara fotográfica", Categoria.Electronica, 400);
            Articulo artc13 = new Articulo("Celular", Categoria.Electronica, 500);
            Articulo artc14 = new Articulo("Disco duro externo", Categoria.Electronica, 100);
            Articulo artc15 = new Articulo("Dron", Categoria.Electronica, 350);
            Articulo artc16 = new Articulo("Equipo de sonido", Categoria.Electronica, 300);
            Articulo artc17 = new Articulo("Laptop", Categoria.Electronica, 800);
            Articulo artc18 = new Articulo("Monitor", Categoria.Electronica, 200);
            Articulo artc19 = new Articulo("Parlante bluetooth", Categoria.Electronica, 120);
            Articulo artc20 = new Articulo("Reloj inteligente", Categoria.Electronica, 180);
            Articulo artc21 = new Articulo("Tableta gráfica", Categoria.Electronica, 200);
            Articulo artc22 = new Articulo("Televisor", Categoria.Electronica, 600);

            // Artículos en la categoría: Entretenimiento
            Articulo artc23 = new Articulo("Guitarra", Categoria.Entretenimiento, 300);
            Articulo artc24 = new Articulo("Guitarra eléctrica", Categoria.Entretenimiento, 350);
            Articulo artc25 = new Articulo("Juego de ajedrez", Categoria.Entretenimiento, 40);
            Articulo artc26 = new Articulo("Juguetes para niños", Categoria.Entretenimiento, 50);
            Articulo artc27 = new Articulo("Libro de aventura", Categoria.Entretenimiento, 15);
            Articulo artc28 = new Articulo("Set de películas", Categoria.Entretenimiento, 50);

            // Artículos en la categoría: Hogar
            Articulo artc29 = new Articulo("Cafetera", Categoria.Hogar, 80);
            Articulo artc30 = new Articulo("Colchón", Categoria.Hogar, 250);
            Articulo artc31 = new Articulo("Cortina", Categoria.Hogar, 30);
            Articulo artc32 = new Articulo("Valija", Categoria.Hogar, 100);
            Articulo artc33 = new Articulo("Espejo", Categoria.Hogar, 60);
            Articulo artc34 = new Articulo("Estante", Categoria.Hogar, 80);
            Articulo artc35 = new Articulo("Heladera", Categoria.Hogar, 900);
            Articulo artc36 = new Articulo("Lámpara de escritorio", Categoria.Hogar, 25);
            Articulo artc37 = new Articulo("Lavadora", Categoria.Hogar, 300);
            Articulo artc38 = new Articulo("Microondas", Categoria.Hogar, 120);
            Articulo artc39 = new Articulo("Mochila", Categoria.Hogar, 80);
            Articulo artc40 = new Articulo("Plancha", Categoria.Hogar, 100);
            Articulo artc41 = new Articulo("Silla", Categoria.Hogar, 50);
            Articulo artc42 = new Articulo("Sofá", Categoria.Hogar, 400);
            Articulo artc43 = new Articulo("Termo", Categoria.Hogar, 40);
            Articulo artc44 = new Articulo("Ventilador", Categoria.Hogar, 50);

            // Artículos en la categoría: Ropa
            Articulo artc45 = new Articulo("Camisa", Categoria.Ropa, 35);
            Articulo artc46 = new Articulo("Campera de abrigo", Categoria.Ropa, 150);
            Articulo artc47 = new Articulo("Corbata", Categoria.Ropa, 25);
            Articulo artc48 = new Articulo("Pantalones deportivos", Categoria.Ropa, 40);
            Articulo artc49 = new Articulo("Remera deportiva", Categoria.Ropa, 25);
            Articulo artc50 = new Articulo("Sombrero", Categoria.Ropa, 20);


            // Agregamos los artículos al catálogo
            this.AgregarCatalogo(artc1);
            this.AgregarCatalogo(artc2);
            this.AgregarCatalogo(artc3);
            this.AgregarCatalogo(artc4);
            this.AgregarCatalogo(artc5);
            this.AgregarCatalogo(artc6);
            this.AgregarCatalogo(artc7);
            this.AgregarCatalogo(artc8);
            this.AgregarCatalogo(artc9);
            this.AgregarCatalogo(artc10);
            this.AgregarCatalogo(artc11);
            this.AgregarCatalogo(artc12);
            this.AgregarCatalogo(artc13);
            this.AgregarCatalogo(artc14);
            this.AgregarCatalogo(artc15);
            this.AgregarCatalogo(artc16);
            this.AgregarCatalogo(artc17);
            this.AgregarCatalogo(artc18);
            this.AgregarCatalogo(artc19);
            this.AgregarCatalogo(artc20);
            this.AgregarCatalogo(artc21);
            this.AgregarCatalogo(artc22);
            this.AgregarCatalogo(artc23);
            this.AgregarCatalogo(artc24);
            this.AgregarCatalogo(artc25);
            this.AgregarCatalogo(artc26);
            this.AgregarCatalogo(artc27);
            this.AgregarCatalogo(artc28);
            this.AgregarCatalogo(artc29);
            this.AgregarCatalogo(artc30);
            this.AgregarCatalogo(artc31);
            this.AgregarCatalogo(artc32);
            this.AgregarCatalogo(artc33);
            this.AgregarCatalogo(artc34);
            this.AgregarCatalogo(artc35);
            this.AgregarCatalogo(artc36);
            this.AgregarCatalogo(artc37);
            this.AgregarCatalogo(artc38);
            this.AgregarCatalogo(artc39);
            this.AgregarCatalogo(artc40);
            this.AgregarCatalogo(artc41);
            this.AgregarCatalogo(artc42);
            this.AgregarCatalogo(artc43);
            this.AgregarCatalogo(artc44);
            this.AgregarCatalogo(artc45);
            this.AgregarCatalogo(artc46);
            this.AgregarCatalogo(artc47);
            this.AgregarCatalogo(artc48);
            this.AgregarCatalogo(artc49);
            this.AgregarCatalogo(artc50);
        }
        private void PrecargarVentas()
        {
            // Precargamos 10 ventas
            Venta venta1 = new Venta("Publicación de Verano", new DateTime(2022, 10, 04), true);
            Venta venta2 = new Venta("Publicación de Electrónica", new DateTime(2014, 06, 15), false);
            Venta venta3 = new Venta("Publicación de Ropa", new DateTime(2010, 08, 10), true);
            Venta venta4 = new Venta("Publicación de Deportes", new DateTime(2012, 09, 25), false);
            Venta venta5 = new Venta("Publicación de Hogar", new DateTime(2022, 12, 20), true);
            Venta venta6 = new Venta("Publicación de Entretenimiento", new DateTime(2022, 11, 05), false);
            Venta venta7 = new Venta("Publicación de Navidad", new DateTime(2018, 12, 15), true);
            Venta venta8 = new Venta("Publicación de Electrónica II", new DateTime(2024, 01, 10), false);
            Venta venta9 = new Venta("Publicación de Verano II", new DateTime(2023, 02, 15), true);
            Venta venta10 = new Venta("Publicación de Deportes II", new DateTime(2020, 04, 22), false);

            // Agregamos artículos a cada publicación, todos de la misma categoría
            venta1.AgregarArticulo(Catalogo[29]); // Hogar
            venta1.AgregarArticulo(Catalogo[30]);

            venta2.AgregarArticulo(Catalogo[11]); // Electrónica
            venta2.AgregarArticulo(Catalogo[12]);

            venta3.AgregarArticulo(Catalogo[45]); // Ropa
            venta3.AgregarArticulo(Catalogo[46]);

            venta4.AgregarArticulo(Catalogo[0]); // Deportes
            venta4.AgregarArticulo(Catalogo[1]);

            venta5.AgregarArticulo(Catalogo[31]); // Hogar
            venta5.AgregarArticulo(Catalogo[32]);

            venta6.AgregarArticulo(Catalogo[23]); // Entretenimiento
            venta6.AgregarArticulo(Catalogo[24]);

            venta7.AgregarArticulo(Catalogo[33]); // Hogar
            venta7.AgregarArticulo(Catalogo[34]);

            venta8.AgregarArticulo(Catalogo[13]); // Electrónica
            venta8.AgregarArticulo(Catalogo[14]);

            venta9.AgregarArticulo(Catalogo[2]); // Deportes
            venta9.AgregarArticulo(Catalogo[3]);

            venta10.AgregarArticulo(Catalogo[4]); // Deportes
            venta10.AgregarArticulo(Catalogo[5]);

            // Agregamos las publicaciones al sistema
            this.AgregarPublicacion(venta1);
            this.AgregarPublicacion(venta2);
            this.AgregarPublicacion(venta3);
            this.AgregarPublicacion(venta4);
            this.AgregarPublicacion(venta5);
            this.AgregarPublicacion(venta6);
            this.AgregarPublicacion(venta7);
            this.AgregarPublicacion(venta8);
            this.AgregarPublicacion(venta9);
            this.AgregarPublicacion(venta10);
        }
        private void PrecargarSubastas()
        {
            // Precargamos 10 subastas
            Subasta subasta1 = new Subasta("Subasta de Verano", new DateTime(2023, 05, 10));
            Subasta subasta2 = new Subasta("Subasta de Electrónica", new DateTime(2023, 07, 15));
            Subasta subasta3 = new Subasta("Subasta de Ropa", new DateTime(2023, 06, 12));
            Subasta subasta4 = new Subasta("Subasta de Deportes", new DateTime(2023, 09, 22));
            Subasta subasta5 = new Subasta("Subasta de Hogar", new DateTime(2023, 11, 30));
            Subasta subasta6 = new Subasta("Subasta de Entretenimiento", new DateTime(2023, 04, 18));
            Subasta subasta7 = new Subasta("Subasta de Navidad", new DateTime(2023, 12, 20));
            Subasta subasta8 = new Subasta("Subasta de Electrónica II", new DateTime(2024, 01, 14));
            Subasta subasta9 = new Subasta("Subasta de Invierno", new DateTime(2023, 02, 10));
            Subasta subasta10 = new Subasta("Subasta de Deportes II", new DateTime(2024, 03, 25));

            // Agregamos artículos a las subastas, agrupados por categoría
            subasta1.AgregarArticulo(Catalogo[0]);  // Hogar
            subasta1.AgregarArticulo(Catalogo[1]);

            subasta2.AgregarArticulo(Catalogo[2]);  // Electrónica
            subasta2.AgregarArticulo(Catalogo[3]);

            subasta3.AgregarArticulo(Catalogo[23]); // Ropa
            subasta3.AgregarArticulo(Catalogo[24]);

            subasta4.AgregarArticulo(Catalogo[5]);  // Deportes
            subasta4.AgregarArticulo(Catalogo[7]);

            subasta5.AgregarArticulo(Catalogo[9]);  // Hogar
            subasta5.AgregarArticulo(Catalogo[14]);

            subasta6.AgregarArticulo(Catalogo[18]); // Entretenimiento
            subasta6.AgregarArticulo(Catalogo[19]);

            subasta7.AgregarArticulo(Catalogo[34]); // Hogar
            subasta7.AgregarArticulo(Catalogo[35]);

            subasta8.AgregarArticulo(Catalogo[11]); // Electrónica
            subasta8.AgregarArticulo(Catalogo[12]);

            subasta9.AgregarArticulo(Catalogo[26]); // Deportes
            subasta9.AgregarArticulo(Catalogo[28]);

            subasta10.AgregarArticulo(Catalogo[41]); // Deportes
            subasta10.AgregarArticulo(Catalogo[42]);

            // Agregamos las subastas al sistema
            this.AgregarPublicacion(subasta1);
            this.AgregarPublicacion(subasta2);
            this.AgregarPublicacion(subasta3);
            this.AgregarPublicacion(subasta4);
            this.AgregarPublicacion(subasta5);
            this.AgregarPublicacion(subasta6);
            this.AgregarPublicacion(subasta7);
            this.AgregarPublicacion(subasta8);
            this.AgregarPublicacion(subasta9);
            this.AgregarPublicacion(subasta10);

            // Creando ofertas para la subasta 1
            Oferta oferta1 = new Oferta((Cliente)Usuarios[1], 150, new DateTime(2023, 07, 16));  // Cliente 1 hace una oferta
            Oferta oferta2 = new Oferta((Cliente)Usuarios[3], 200, new DateTime(2023, 07, 17));  // Cliente 4 hace una oferta

            // Creando ofertas para la subasta 2
            Oferta oferta3 = new Oferta((Cliente)Usuarios[5], 300, new DateTime(2023, 04, 19));  // Cliente 6 hace una oferta
            Oferta oferta4 = new Oferta((Cliente)Usuarios[8], 350, new DateTime(2023, 04, 20));  // Cliente 8 hace una oferta

            subasta1.AgregarOferta(oferta1);
            subasta1.AgregarOferta(oferta2);
            subasta2.AgregarOferta(oferta3);
            subasta2.AgregarOferta(oferta4);
        }

        // FUNCIONES
        // Listar Artículos por Categoría
        public List<Articulo> FiltrarArticuloPorCategoria(Categoria unaCategoria)
        {
            List<Articulo> articulosFiltrados = new List<Articulo>();

            foreach (Articulo unArticulo in Catalogo)
            {
                if (unArticulo.Categoria == unaCategoria)
                    articulosFiltrados.Add(unArticulo);
            }
            if (articulosFiltrados.Count == 0) throw new Exception("No existen artículos con esa categoría. :(");
            return articulosFiltrados;
        }

        // Listar Publicaciones por Fecha
        public List<Publicacion> FiltrarPublicacionesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                DateTime temp = fechaInicio;
                fechaInicio = fechaFin;
                fechaFin = temp;
            }

            List<Publicacion> publicacionesFiltradas = new List<Publicacion>();
            foreach (Publicacion unaPublicacion in _publicaciones)
            {
                if (unaPublicacion.FechaPublicación >= fechaInicio && unaPublicacion.FechaPublicación <= fechaFin)
                    publicacionesFiltradas.Add(unaPublicacion);
            }
            if (publicacionesFiltradas.Count == 0) throw new Exception("No existen publicaciones entre esas fechas. :(");
            return publicacionesFiltradas;
        }
        public List<Cliente> ListarClientes()
        {
            List<Cliente> aRetornar = new List<Cliente>();

            foreach (Usuario elUsuario in this._usuarios)
            {
                // Verificamos si el usuario es un Cliente
                if (elUsuario is Cliente) aRetornar.Add((Cliente)elUsuario);
            }
            if (aRetornar.Count == 0) throw new Exception("No hay clientes registrados.");
            return aRetornar;
        }

        // Usado para el Login
        public Usuario AutenticarUsuario(string unEmail, string unaPassword)
        {
            foreach (Usuario unUsuario in Usuarios)
            {
                if (unUsuario.Email == unEmail)
                {
                    if (unUsuario.Contrasenia != unaPassword)
                        throw new Exception("Datos incorrectos.");
                    else return unUsuario;
                }
            }
            throw new Exception("Datos incorrectos.");
        }

        //Obtener Cliente logeado con su Email
        public Cliente BuscarClientePorEmail(string unEmail)
        {
            foreach (Usuario elUsuario in Usuarios)
            {
                if (elUsuario.Email == unEmail && elUsuario is Cliente)
                    return (Cliente)elUsuario;
            }
            throw new Exception("Error.");
        }
        //Obtener Administrador logeado con su Email
        public Administrador BuscarAdministradorPorEmail(string unEmail)
        {
            foreach (Usuario unAdministrador in Usuarios)
            {
                if (unAdministrador.Email == unEmail && unAdministrador is Administrador)
                    return (Administrador)unAdministrador;
            }
            throw new Exception("Error.");
        }

        //Búsquedas
        public Subasta BuscarSubastaPorId(int unId)
        {
            foreach (Publicacion unaPublicacion in Publicaciones)
            {
                if (unaPublicacion.Id == unId && unaPublicacion is Subasta)
                    return (Subasta)unaPublicacion;
            }
            throw new Exception("No existe la publicación con ese id.");
        }
        public Venta BuscarVentaPorId(int unId)
        {
            foreach (Publicacion unaPublicacion in Publicaciones)
            {
                if (unaPublicacion.Id == unId && unaPublicacion is Venta)
                    return (Venta)unaPublicacion;
            }
            throw new Exception("No existe la publicación con ese id.");
        }

        public void OrdendarPublicaciones()
        {
            this.Publicaciones.Sort();
        }
    }
}