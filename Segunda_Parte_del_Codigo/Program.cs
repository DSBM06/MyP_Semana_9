class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();
        int opcion;

        do
        {
            Console.WriteLine("Menu de opciones:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Actualizar stock");
            Console.WriteLine("3. Calcular valor total");
            Console.WriteLine("4. Mostrar inventario");
            Console.WriteLine("5. Salir");

            Console.Write("Ingrese su opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el precio del producto: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    Console.Write("Ingrese la cantidad del producto: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    inventario.AgregarProducto(nombre, precio, cantidad);
                    break;
                case 2:
                    Console.Write("Ingrese el nombre del producto: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese la nueva cantidad: ");
                    int nuevaCantidad = int.Parse(Console.ReadLine());
                    inventario.ActualizarStock(nombre, nuevaCantidad);
                    break;
                case 3:
                    decimal valorTotal = inventario.CalcularValorTotal();
                    Console.WriteLine($"Valor total del inventario: {valorTotal}");
                    break;
                case 4:
                    inventario.MostrarInventario();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, inténtelo de nuevo.");
                    break;
            }
        } while (opcion != 5);
    }
}
}