using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArbolesGrafos.Grafo
{
    internal class Dijkstra
    {
        public static (List<string>, double) ShortestPath(Grafo g, string source, string target)
        {
            var dist = new Dictionary<string, double>();
            var prev = new Dictionary<string, string>();
            var Q = new HashSet<string>();

            foreach (var v in g.GetVertices())
            {
                dist[v] = double.PositiveInfinity;
                prev[v] = null;
                Q.Add(v);
            }

            if (!dist.ContainsKey(source))
                return (new List<string>(), double.PositiveInfinity);

            dist[source] = 0;

            while (Q.Count > 0)
            {
                var u = Q.OrderBy(x => dist[x]).First();
                Q.Remove(u);

                if (u == target)
                    break;

                foreach (var e in g.GetAdjacencies(u))
                {
                    double alt = dist[u] + e.Weight;
                    if (alt < dist[e.To])
                    {
                        dist[e.To] = alt;
                        prev[e.To] = u;
                    }
                }
            }

            var path = new List<string>();
            string cur = target;

            while (cur != null)
            {
                path.Add(cur);
                cur = prev[cur];
            }

            path.Reverse();
            return (path, dist[target]);
        }
    }
}
