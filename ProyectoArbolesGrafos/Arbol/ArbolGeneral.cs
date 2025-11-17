using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArbolesGrafos.Arbol
{
    public class ArbolGeneral<T>
    {
        public ArbolNodo<T> Root { get; set; }
        public ArbolGeneral(T rootValue)
        {
            Root = new ArbolNodo<T>(rootValue);
        }
        public bool Insertar(T parentValue, T newValue)
        {
            var parent = EncontrarNodo(parentValue);
            if (parent == null)
                return false;
        }

    }
}
