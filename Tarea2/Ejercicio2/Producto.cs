using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2.Ejercicio2
{
    internal class Producto
    {
        private String _nombre;
        private String _tipo;
        private int _contador;

        public Producto(String nombre, String tipo) { 
            this._nombre = nombre;
            this._tipo = tipo;
            this._contador = 0;
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public int contador
        {
            get { return _contador; }
            set { _contador = value; }
        }

        public override string ToString()
        {
            return $"Nombre: {_nombre}, Tipo: {_tipo}";
        }

        public String datos() { 
            return $"Nombre: {_nombre}, Tipo: {_tipo}, Popularidad: {_contador}";
        }
    }
}
