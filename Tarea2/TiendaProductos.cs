using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2.Ejercicio2;

namespace Tarea2
{
    class TiendaProductos
    {
        private List<Producto> _productos;
        private List<ContadorProductos> _contadores;
        //Constructor
        public TiendaProductos() { 
            _productos = new List<Producto>();
            _contadores = new List<ContadorProductos>();

        }

        //Muestra el menu principal
        public void showMenuPrincipal()
        {
            int opcion = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Binvenido al inventario de productos");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Listar Productos");
                Console.WriteLine("3. Borrar Producto");
                Console.WriteLine("4. Salir");
            } while (!validaMenu(4, ref opcion));
            switch (opcion)
            {
                case 1:
                    darAltaProducto();
                    break;
                case 2:
                    listarProductos();
                    break;
                case 3:
                    borrarProducto();
                    break;
                case 4:
                    break;

            }
        }

        // valida la opcion ingresada
        private bool validaMenu(int opciones, ref int opcionSeleccionada)
        {
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n <= opciones)
                {
                    opcionSeleccionada = n;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opción Invalida.");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es válido, debes ingresar un número.");
                return false;
            }
        }

        //pide un string/cadena
        private string pedirValorString(string texto)
        {
            string? valor;
            do
            {
                Console.Write($"{texto}: ");
                valor = Console.ReadLine();
                if (valor == null || valor == "")
                {
                    Console.WriteLine("Valor inválido.");
                }
            } while (valor == null || valor == "");
            return valor;
        }

        // Agrega un producto
        private void darAltaProducto() {
            String nombreProducto;
            String tipoProducto;
            int contador = 0;
            Console.WriteLine("Agregar Producto");
            nombreProducto = pedirValorString("Nombre del producto: ");
            tipoProducto = pedirValorString("Tipo de producto: ");
            Producto nuevoProducto = new Producto(nombreProducto, tipoProducto);
            if (productoExiste(nuevoProducto)){
                cambiarContadorExistente(nuevoProducto);
                Console.WriteLine("Producto agregado correctamente. Enter para continuar...");
                Console.ReadLine();
                showMenuPrincipal();

            }
            else { 
                
                contador = nuevoProducto.contador;
                contador++;
                nuevoProducto.contador = contador;
                _productos.Add(nuevoProducto);
                
                Console.WriteLine("Producto agregado correctamente. Enter para continuar...");
                Console.ReadLine();
                showMenuPrincipal();

            }
            
        }

        private void cambiarContadorExistente(Producto producto) {
            int contador = 0;
            Producto prod = _productos.FirstOrDefault(p => p.ToString() == producto.ToString());
            if (prod != null) {
                contador = prod.contador;
                contador++;
                prod.contador=contador;
            }
        }
        private Boolean productoExiste(Producto producto) {
            Producto pro = _productos.FirstOrDefault(p => p.ToString() == producto.ToString());
            if (pro == null)
            {
                return false;
            }
            else { 
                return true;
            }
        }
        //Menu que lista productos.
        private void listarProductos()
        {
            int opcion = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Listar Productos");
                Console.WriteLine("1. Listar Todos Productos");
                Console.WriteLine("2. Por Tipo");
                Console.WriteLine("3. Por popularidad");
                Console.WriteLine("4. Regresar");

            } while (!validaMenu(3, ref opcion));
            switch (opcion)
            {
                case 1:
                    listarTodosProductos();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 2:
                    listarPorTipo();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 3:
                    listarPorPopularidad();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 4:
                    showMenuPrincipal();
                    break;
            }


        }
        //Lista todos los productos
        private void listarTodosProductos()
        {
            Console.WriteLine("Lista de Productos");
            
            foreach (Producto item in _productos)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
        //Lista productos por tipo
        private void listarPorTipo() {
            Console.Clear();
            Console.WriteLine("Por Tipo");
            String? tipo = null;
            tipo = pedirValorString("Tipo de producto: ");
            foreach (Producto item in _productos)
            {
                if (tipo == item.tipo)
                {
                    Console.WriteLine(item.ToString());
                }
            }


        }

        //Lista por popularidad
        //Puse una variable con 5 nada mas para dar una idea
        private void listarPorPopularidad() {
            int popularidad = 5;
            foreach (Producto item in _productos) {
                if (item.contador >= popularidad) {
                    Console.WriteLine(item.datos());
                }
            }
        }

        //Borra un producto
        public void borrarProducto()
        {
            Console.Clear();
            listarTodosProductos();
            Console.WriteLine("\n");
            string? nombre;
            nombre = pedirValorString("Nombre del producto a quitar: ");
            Producto producto = _productos.FirstOrDefault(p => p.nombre == nombre);
            if (producto == null)
            {
                Console.WriteLine("No se encontró el producto...Enter para continuar");
            }
            else
            {
                _productos.Remove(producto);
                Console.WriteLine("El producto se eliminó correctamente...Enter para continuar");
            }
            Console.ReadLine();
            showMenuPrincipal();
        }



        public void inicializarDatos() {
            Producto p1 = new Producto("Escoba", "Limpieza");
            _productos.Add(p1);
            Producto p2 = new Producto("Trapeador", "Limpieza");
            _productos.Add(p2);
            Producto p3 = new Producto("Plato", "Cocina");
            _productos.Add(p3);
            Producto p4 = new Producto("Vaso", "Cocina");
            _productos.Add(p4);

            cambiarContadorExistente(p1);
            cambiarContadorExistente(p1);
            cambiarContadorExistente(p1);
            cambiarContadorExistente(p1);
            cambiarContadorExistente(p1);
            cambiarContadorExistente(p1);

            cambiarContadorExistente(p3);
            cambiarContadorExistente(p3);
            cambiarContadorExistente(p3);
            cambiarContadorExistente(p3);
            cambiarContadorExistente(p3);

        }




    }
}
