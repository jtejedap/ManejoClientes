using ManejoClientes;
// See https://aka.ms/new-console-template for more information
List<Cliente> clientes = new List<Cliente>();
mainMenu();

    void mainMenu()
    { 
        Console.WriteLine("=============MANEJO DE CLIENTES========================");
        Console.WriteLine("====SELECCIONA OPCION DE MENU QUE DESEES===============");
        Console.WriteLine("1-Crear Cliente");
        Console.WriteLine("2-Buscar Cliente");
        Console.WriteLine("3-Actualizar Cliente");
        Console.WriteLine("4-Borrar Cliente");
        Console.WriteLine("5-Salir");

    int opc = Int32.Parse(Console.ReadLine());

    switch (opc)
    {

        case 1:
            Console.WriteLine("\r\nNombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine();
            Console.WriteLine("Teléfono:");
            string telefono = Console.ReadLine();
            Console.WriteLine("Correo:");
            string correo = Console.ReadLine();
            Console.WriteLine("Empresa:");
            string empresa = Console.ReadLine();
            Console.WriteLine("Favor introducir el numero de direcciones que tiene el cliente:");
            int numdirecciones = Int32.Parse(Console.ReadLine());
            
            List<Direccion> direcciones = new List<Direccion>();
            for (int i = 0; i < numdirecciones; i++)
            {

                Console.WriteLine($"\r\n=========DIRECCION {i + 1}=========");
                Console.WriteLine("\r\nCalle:");
                string calle = Console.ReadLine();
                Console.WriteLine("Numero:");
                int numero = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Sector:");
                string sector = Console.ReadLine();
                Console.WriteLine("Ciudad:");
                string ciudad = Console.ReadLine();
                Console.WriteLine("Codigo Postal:");
                string codigopostal = Console.ReadLine();
                Console.WriteLine("País:");
                string pais = Console.ReadLine();
                direcciones.Add(new Direccion() { Calle = calle, Numero = numero, Sector = sector, Ciudad=ciudad, CodigoPostal = codigopostal, Pais = pais });
            }
            
            var objcliente = new Cliente() { Nombre = nombre, Apellido = apellido, Telefono = telefono, Correo = correo, Empresa = empresa, Direccion = direcciones };
            clientes.Add(objcliente);
            
            //ManejoClientes.BL.ClientManagement objcli = new ManejoClientes.BL.ClientManagement();   //Persistencia en BD a través de capa de negocio
            //objcli.AgregarCliente(objcliente);
            Console.WriteLine("\r\nCliente creado exitosamente, presionar ENTER para volver al menu principal!");
            Console.ReadLine();
            Console.Clear();
            mainMenu();
            break;
        case 2:
            Console.WriteLine("\r\nIntroducir nombre o apellido de cliente");
            string scliente = Console.ReadLine();
            var lstclientes = clientes.ToList();
            var srchcliente = lstclientes.Where(x => x.Nombre == scliente || x.Apellido==scliente).ToList();
            //ManejoClientes.BL.ClientManagement objsrch = new ManejoClientes.BL.ClientManagement();
            //var srchcliente = objsrch.BuscarCliente(scliente);                                     //Busqueda a través de capa de negocio
            foreach (var cliente in srchcliente)
            {
                Console.WriteLine($"Nombre:{cliente.Nombre}");
                Console.WriteLine($"Apellido:{cliente.Apellido}");
                Console.WriteLine($"Telefono:{cliente.Telefono}");
                Console.WriteLine($"Correo:{cliente.Correo}");
                Console.WriteLine($"Empresa:{cliente.Empresa}");
                foreach(var addr in cliente.Direccion)
                {
                    Console.WriteLine($"Direccion:Calle {addr.Calle} No.{addr.Numero},{addr.Sector},{addr.Ciudad} {addr.CodigoPostal},{addr.Pais}");
                }
            }
            if (srchcliente.Count() == 0)
            {
                Console.WriteLine("Cliente no encontrado!");
            }
            Console.ReadLine();
            Console.Clear();
            mainMenu();
            break;
        case 3:
            Console.WriteLine("Opción no implementada.");
            Console.ReadLine();
            Console.Clear();
            mainMenu();
            break;
        case 4:
            Console.WriteLine("Opción no implementada.");
            Console.ReadLine();
            Console.Clear();
            mainMenu();
            break;
        case 5:
            System.Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opción pulsada no disponible.");
            break;

    }
    //Console.ReadKey();

}