using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2.Ejercicio1
{
    internal class Pelicula
    {
        private String _nombre;
        private String _genero;
        private String _formato;

        public Pelicula(String nombre, String genero, String formato) {
            this._nombre = nombre;
            this._genero = genero;
            this._formato = formato;
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string formato
        {
            get { return _formato; }
            set { _formato = value; }
        }

        public override string ToString()
        {
            return $"Nombre: {_nombre}, Genero: {_genero}, Formato: {_formato}";
        }
    }
}
