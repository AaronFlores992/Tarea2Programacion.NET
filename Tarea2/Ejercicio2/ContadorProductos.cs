using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2.Ejercicio2
{
    internal class ContadorProductos
    {
        private int _contador;
        private Producto _producto;

        public ContadorProductos(Producto producto) {
            this._producto = producto;
            this._contador = 0;
        }

        public Producto producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
        public int contador
        {
            get { return _contador; }
            set { _contador = value; }
        }


        public override string ToString()
        {
            return $"Producto: {_producto}, Contador: {_contador}";
        }
    }
}
