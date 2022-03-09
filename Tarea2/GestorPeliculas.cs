using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2.Ejercicio1;
namespace Tarea2
{
    class GestorPeliculas
    {
        private List<Pelicula> _peliculas;

        public GestorPeliculas() { 
            _peliculas = new List<Pelicula>();
        }

        public void showMenuPrincipal() { 
            int opcion = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Binvenido al gestor de películas");
                Console.WriteLine("1. Dar alta pelicula");
                Console.WriteLine("2. Listar peliculas");
                Console.WriteLine("3. Borrar pelicula");
                Console.WriteLine("4. Salir");
            } while (!validaMenu(4, ref opcion));
            switch (opcion) {
                case 1:
                    darAltaPelicula();
                    break;
                case 2:
                    listarPeliculas();
                    break;
                case 3:
                    borrarPelicula();
                    break;
                case 4:
                    break;

            }
        }

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

        private void darAltaPelicula() {
            String nombrePelicula;
            String genero;
            String formato;
            Console.WriteLine("Alta Pelicula");
            nombrePelicula = pedirValorString("Nombre pelicula: ");
            genero = pedirValorString("Genero: ");
            formato = pedirValorString("Formato: ");
            Pelicula nuevaPelicula = new Pelicula(nombrePelicula,genero,formato);
            _peliculas.Add(nuevaPelicula);
            Console.WriteLine("Pelicula agregada correctamente. Presione Enter para continuar...");
            Console.ReadLine();
            showMenuPrincipal();
        }

        private void listarPeliculas() {
            int opcion = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Listar Peliculas");
                Console.WriteLine("1. Listar Todas");
                Console.WriteLine("2. Por Categoria");
                Console.WriteLine("3. Regresar");
                
            } while (!validaMenu(3, ref opcion));
            switch (opcion)
            {
                case 1:
                    listarTodasPeliculas();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 2:
                    listarPeliculasPorCategoria();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 3:
                    showMenuPrincipal();
                    break;
            }

            
        }

        private void listarTodasPeliculas() {
            Console.WriteLine("Lista de Peliculas");
            foreach (Pelicula item in _peliculas)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void listarPeliculasPorCategoria() {
            int opcion = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Por Categoria");
                Console.WriteLine("1. Formato");
                Console.WriteLine("2. Genero");
                Console.WriteLine("3. Regresar");

            } while (!validaMenu(3, ref opcion));
            switch (opcion)
            {
                case 1:
                    listarPorCategoria(1);
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 2:
                    listarPorCategoria(2);
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 3:
                    listarPeliculas();
                    break;
            }
        }

        private void listarPorCategoria(int opcion) {
            Console.Clear();
            if (opcion == 1)
            {
                Console.WriteLine("Por formato");
                String? formato = null;
                formato = pedirValorString("Formato: ");
                foreach (Pelicula item in _peliculas)
                {
                    if (formato == item.formato)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            else {
                Console.WriteLine("Por genero");
                String? formato = null;
                formato = pedirValorString("Genero: ");
                foreach (Pelicula item in _peliculas)
                {
                    if (formato == item.genero)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
        }

        public void borrarPelicula() {
            Console.Clear();
            listarTodasPeliculas();
            Console.WriteLine("\n");
            string? nombre;
            nombre = pedirValorString("Nombre de la pelicula a borrar: ");
            Pelicula pelicula = _peliculas.FirstOrDefault(p => p.nombre == nombre);
            if (pelicula == null)
            {
                Console.WriteLine("No se encontró la pelicula...Enter para continuar");
            }
            else {
                _peliculas.Remove(pelicula);
                Console.WriteLine("La pelicula se eliminó correctamente...Enter para continuar");
            }
            Console.ReadLine();
            showMenuPrincipal();
        }
        public void inicializarDatos() {
            Pelicula pelicula1 = new Pelicula("Xmen", "Accion", "BluRay");
            _peliculas.Add (pelicula1);
            Pelicula pelicula2 = new Pelicula("Avengers 1", "Accion", "BluRay");
            _peliculas.Add(pelicula2);
            Pelicula pelicula3 = new Pelicula("It", "Terror", "VHS");
            _peliculas.Add(pelicula3);
            Pelicula pelicula4 = new Pelicula("Harry Potter 1", "Fantasia", "DVD");
            _peliculas.Add(pelicula4);
            Pelicula pelicula5 = new Pelicula("Piratas Del Caribe", "Fantasia", "DVD");
            _peliculas.Add(pelicula5);
            Pelicula pelicula6 = new Pelicula("El Exorcismo", "Terror", "VHS");
            _peliculas.Add(pelicula6);

        }
    }
}
