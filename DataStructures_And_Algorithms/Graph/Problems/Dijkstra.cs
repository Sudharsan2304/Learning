using SharedProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static Dictionary<TVertex, double> ShortestPath<TVertex>(
        WeightedUndirectedGraph<TVertex> graph,
        TVertex source)
        where TVertex : notnull
        {
            Dictionary<TVertex, double> dist = [];
            PriorityQueue<TVertex, double> pq = new();

            foreach (var v in graph.Vertices)
            {
                dist[v] = double.PositiveInfinity;
            }

            dist[source] = 0;
            pq.Enqueue(source, 0);

            while (pq.IsNotEmpty())
            {
                var u = pq.Dequeue();

                double currentWeight = dist[u];

                foreach (var neighbor in graph.GetNeighbors(u))
                {
                    double newDist = currentWeight + neighbor.Weight;
                    if (newDist < dist[neighbor.Vertex])
                    {
                        dist[neighbor.Vertex] = newDist;
                        pq.Enqueue(neighbor.Vertex, newDist);
                    }
                }
            }

            return dist;
        }
    }
}
