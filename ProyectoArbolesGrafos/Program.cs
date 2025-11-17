using ProyectoArbolesGrafos.Arbol;
using ProyectoArbolesGrafos.Grafo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArbolesGrafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Árbol ===");

            var arbol = new ArbolGeneral<string>("Parque Innovatec");

            arbol.Insertar("Parque Innovatec", "Dirección");
            arbol.Insertar("Dirección", "Recursos Humanos");
            arbol.Insertar("Dirección", "Operaciones");
            arbol.Insertar("Operaciones", "Mantenimiento");
            arbol.Insertar("Operaciones", "Seguridad");

            Console.WriteLine("Recorrido preorden:");
            foreach (var n in arbol.TraversePreOrder())
                Console.WriteLine(" - " + n);

            Console.WriteLine("Total nodos: " + arbol.ContarNodos());
            Console.WriteLine("Nivel de 'Mantenimiento': " + arbol.GetLevel("Mantenimiento"));

            Console.WriteLine("\n=== GRAFO ===");

            var g = new ProyectoArbolesGrafos.Grafo.Grafo();
            g.AddEdge("Edificio A", "Edificio B", 50);
            g.AddEdge("Edificio A", "Edificio C", 120);
            g.AddEdge("Edificio B", "Edificio D", 80);
            g.AddEdge("Edificio C", "Edificio D", 60);
            g.AddEdge("Edificio D", "Cafetería", 30);

            Console.WriteLine("Adyacencias de A:");
            foreach (var e in g.GetAdjacencies("Edificio A"))
                Console.WriteLine(" - " + e.To + " (" + e.Weight + ")");

            Console.WriteLine("¿Es conexo? " + g.IsConnected());

            var result = Dijkstra.ShortestPath(g, "Edificio A", "Cafetería");

            Console.WriteLine("Ruta más corta:");
            Console.WriteLine(string.Join(" -> ", result.Item1) + " (" + result.Item2 + ")");
        }
    }
}
