/*Crea un programa que administre un inventario de productos.
Cada producto tiene un nombre, un precio y una cantidad en
stock. El programa debe permitir:
✓ Añadir nuevos productos al inventario.
✓ Actualizar la cantidad en stock de un producto
existente.
✓ Calcular el valor total del inventario (sumando el valor
de cada producto: precio × cantidad en stock).
Requisitos:
✓ Implementar la función agregar_producto (inventario,
nombre, precio, cantidad) para añadir productos.
✓ Implementar la función actualizar_stock (inventario,
nombre, nueva_cantidad) para modificar la cantidad de
un producto.
✓ Implementar la función calcular_valor_total (inventario)
que devuelva el valor total del inventario.*/

using System;
using System.Collections.Generic;

namespace InventarioProductos
{
    class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto(string nombre, decimal precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
    }

    class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(string nombre, decimal precio, int cantidad)
        {
            productos.Add(new Producto(nombre, precio, cantidad));
        }

        public void ActualizarStock(string nombre, int nuevaCantidad)
        {
            var producto = productos.Find(p => p.Nombre == nombre);
            if (producto != null)
            {
                producto.Cantidad = nuevaCantidad;
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = 0;
            foreach (var producto in productos)
            {
                valorTotal += producto.Precio * producto.Cantidad;
            }
            return valorTotal;
        }

        public void MostrarInventario()
        {
            Console.WriteLine("Inventario:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}, Cantidad: {producto.Cantidad}");
            }
        }
    }

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
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre del producto: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el precio del producto: ");
                        decimal precio = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Ingrese la cantidad del producto: ");
                        int cantidad = Convert.ToInt32(Console.ReadLine());
                        inventario.AgregarProducto(nombre, precio, cantidad);
                        break;
                    case 2:
                        Console.Write("Ingrese el nombre del producto: ");
                        nombre = Console.ReadLine();
                        Console.Write("Ingrese la nueva cantidad: ");
                        int nuevaCantidad = Convert.ToInt32(Console.ReadLine());
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