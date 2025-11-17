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

            parent.AddChild(new ArbolNodo<T>(newValue));
            return true;
        }

        public ArbolNodo<T> EncontrarNodo(T value)
        {
            return EncontrarNodoRecursivo(Root, value);
        }

        private ArbolNodo<T> EncontrarNodoRecursivo(ArbolNodo<T> nodo, T value)
        {
            if(nodo.Value.Equals(value))
                return nodo;
            foreach(var child in nodo.Children)
            {
                var encontrar = EncontrarNodoRecursivo(child, value);
                if (encontrar != null)
                    return encontrar;
            }

            return null;
        }

        public List<T> TraversePreOrder()/// Recorrer en preorden
        {
            var list = new List<T>();
            PreOrder(Root, list);
            return list;
        }

        private void PreOrder(ArbolNodo<T> nodo, List<T> list)
        {
            list.Add(nodo.Value);

            foreach (var child in nodo.Children)
            {
                PreOrder(child, list);
            }
        }

        public int ContarNodos()
        {
            return ContarNodosRecursivo(Root);
        }
        private int ContarNodosRecursivo(ArbolNodo<T> nodo)
        {
            int count = 1; // Contar el nodo actual
            foreach (var child in nodo.Children)
            {
                count += ContarNodosRecursivo(child);
            }
            return count;
        }
        public int? GetLevel(T value)
        {
            var nodo = EncontrarNodo(value);
            if (nodo == null)
                return null;

            int nivel = 0;
            while(nodo.Parent != null)
            {
                nivel++;
                nodo = nodo.Parent;
            }

            return nivel;
        }
    }
}
