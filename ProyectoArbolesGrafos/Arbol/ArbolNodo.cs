using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArbolesGrafos.Arbol
{
    public class ArbolNodo<T>
    {
        public T Value { get; set; }
        public ArbolNodo<T> Parent { get; set; }
        public List<ArbolNodo<T>> Children { get; set; }

        public ArbolNodo(T value)
        {
            Value = value;
            Children = new List<ArbolNodo<T>>();
        }

        public void AddChild(ArbolNodo<T> child)
        {
            child.Parent = this;
            Children.Add(child);
        }
    }
}
