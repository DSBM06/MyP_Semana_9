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
}