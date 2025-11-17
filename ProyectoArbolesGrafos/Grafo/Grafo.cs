using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArbolesGrafos.Grafo
{
    public class Edge
    {
        public string To { get; set; }
        public double Weight { get; set; }

        public Edge(string to, double weight)
        {
            To = to;
            Weight = weight;
        }
    }

    public class  Grafo
    {
        private Dictionary<string, List<Edge>> adj; ///adjacency list
        public Grafo()
        {
            adj = new Dictionary<string, List<Edge>>();
        }
        public void AddVertex(string vertex)
        {
            if (!adj.ContainsKey(vertex))
            {
                adj[vertex] = new List<Edge>();
            }
        }
        public void AddEdge(string a, string b, double weight)
        {
            AddVertex(a);
            AddVertex(b);
            adj[a].Add(new Edge(b, weight));
            adj[b].Add(new Edge(a, weight)); /// no dirigido
        }
        public List<Edge> GetAdjacencies(string v)
        {
            if (adj.ContainsKey(v))
                return adj[v];
            return new List<Edge>();
        }

        public bool IsConnected()
        {
            if (adj.Count == 0)
                return true;

            var visited = new HashSet<string>();
            var stack = new Stack<string>();

            string start = adj.Keys.First();
            stack.Push(start);

            while (stack.Count > 0)
            {
                string cur = stack.Pop();
                if (visited.Contains(cur))
                    continue;

                visited.Add(cur);

                foreach (var edge in adj[cur])
                    if (!visited.Contains(edge.To))
                        stack.Push(edge.To);
            }

            return visited.Count == adj.Count;
        }

        public IEnumerable<string> GetVertices()
        {
            return adj.Keys;
        }
    }
}
