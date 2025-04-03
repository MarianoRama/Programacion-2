using LogicaNegocio;
Sistema sistema = Sistema.Instancia;

string nroOperacion = "";

while (nroOperacion != "0")
{
    Console.Clear();
    Console.WriteLine("Menú:");
    Console.WriteLine("Ingresa el número de la operación (0 para salir).");
    Console.WriteLine(" 1 - Listar clientes." +
                    "\n 2 - Buscar artículo por categoría." +
                    "\n 3 - Alta de artículo." +
                    "\n 4 - Buscar publicación por fecha." +
                    "\n 0 - Salir.");
    nroOperacion = Console.ReadLine();

    switch (nroOperacion)
    {
        case "0":
            Console.Clear();
            Console.WriteLine("Muchas gracias por tu timpo ¡Hasta luego!");
            break;
        case "1":
            Console.Clear();
            try
            {
                foreach (Cliente elCliente in sistema.ListarClientes())
                {
                    Console.WriteLine($"  {elCliente.Id + 1} - {elCliente.Nombre}");
                }
                Console.WriteLine("Presiona enter para continuar.");
                Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            break;
        case "2":
            Console.Clear();
            try
            {
                Console.WriteLine("Selecciona la categroría.");
                MostrarCategorias();
                int seleccion = (SolicitarInt(1, Enum.GetNames(typeof(Categoria)).Length, ""));
                Categoria categoria = (Categoria)seleccion - 1;

                foreach (Articulo unArticulo in sistema.FiltrarArticuloPorCategoria(categoria))
                {
                    Console.WriteLine($" - ID: {unArticulo.Id}" +
                                    $"\n - Nombre: {unArticulo.Nombre}" +
                                    $"\n - Documento: {unArticulo.Precio}" +
                                    $"\n ------------------------------------");
                }
            }
            catch (Exception excpetion)
            {
                Console.WriteLine(excpetion.Message);
            }
            Console.WriteLine("Presiona enter para continuar.");
            Console.ReadLine();
            break;
        case "3":
            Console.Clear();
            bool ingresoArticulo = false;
            while (!ingresoArticulo)
            {
                try
                {
                    //SOLICITAMOS NOMBRE
                    Console.WriteLine("Ingresa el nombre del artículo:");
                    string unNombre = Console.ReadLine();
                    Articulo.ValidarNombre(unNombre);

                    //SOLICITAMOS CATEGORÍA
                    Console.WriteLine("Seleccione la categoría:");
                    MostrarCategorias();
                    // Solicitar selección de categoría
                    int seleccion3 = SolicitarInt(1, Enum.GetNames(typeof(Categoria)).Length, "Selecciona una opción válida:");
                    Categoria unaCategoria = (Categoria)(seleccion3 - 1);

                    //OTRA FUNCION
                    int unPrecio = SolicitarInt(1, int.MaxValue, "Ingresa el precio del artículo: ");
                    Articulo.ValidarPrecio(unPrecio);

                    Articulo nuevoArticulo = new Articulo(unNombre, unaCategoria, unPrecio);
                    sistema.AgregarCatalogo(nuevoArticulo);
                    ingresoArticulo = true;

                    Console.WriteLine("El articulo se ingresó correctamente. :D");
                    Console.WriteLine("Presiona enter para continuar.");
                    Console.ReadLine();
                }
                catch (Exception excpetion)
                {
                    Console.WriteLine(excpetion.Message);
                    ingresoArticulo = false;
                }
            }
            break;
        case "4":
            try
            {
                Console.Clear();
                Console.WriteLine("Ingresa la fecha inicial (formato: YYYY-MM-DD): ");
                DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa la fecha final (formato: YYYY-MM-DD): ");
                DateTime fechaFin = DateTime.Parse(Console.ReadLine());

                foreach (Publicacion unaPublicacion in sistema.FiltrarPublicacionesPorFecha(fechaInicio, fechaFin))
                {
                    Console.WriteLine(unaPublicacion);
                    Console.WriteLine("----------------------------");
                }
            }
            catch (Exception excpetion)
            {
                Console.WriteLine(excpetion.Message);
            }
            Console.WriteLine("Presiona enter para continuar.");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("Opción no disponible \n Presiona enter para continuar.");
            Console.ReadLine();
            break;
    }

    //MÉTODOS
    static void MostrarCategorias()
    {
        int opcion = 0;
        foreach (string laCategoria in Enum.GetNames(typeof(Categoria)))
        {
            opcion++;
            Console.WriteLine($"{opcion} - {laCategoria}");
        }
    }
    static int SolicitarInt(int min, int max, string mensaje)
    {
        bool esCorrecto = false;
        while (!esCorrecto)
        {
            try
            {
                Console.WriteLine(mensaje);
                int seleccion = int.Parse(Console.ReadLine());
                if (seleccion >= min && seleccion <= max)
                {
                    return seleccion;
                }
                Console.WriteLine($"El número debe ser menor que {max} y mayor que {min}.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Solo se aceptan números.");
            }
        }
        return 0;
    }
}