using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        /// <summary>
        /// Computes the Minimum Spanning Tree (MST) of a weighted undirected graph
        /// using Prim's algorithm.
        /// Returns a new WeightedUndirectedGraph<T> containing the MST edges.
        /// </summary>
        public static WeightedUndirectedGraph<T> PrimMST<T>(
    WeightedUndirectedGraph<T> graph)
    where T : notnull
        {
            ArgumentNullException.ThrowIfNull(graph);

            var primGraph = new WeightedUndirectedGraph<T>();
            var visited = new HashSet<T>();
            var pq = new PriorityQueue<(T From, T To, double Weight), double>();

            // Pick any starting vertex (first in adjacency list)
            if (!graph.Vertices.Any())
            {
                return primGraph; // Empty graph -> empty MST
            }

            var start = graph.Vertices.First();
            visited.Add(start);

            foreach (var edge in graph.GetNeighbors(start))
            {
                pq.Enqueue((start, edge.Vertex, edge.Weight), edge.Weight);
            }

            while (pq.Count > 0)
            {
                var (from, to, weight) = pq.Dequeue();

                if (visited.Contains(to))
                {
                    continue;
                }

                visited.Add(to);
                primGraph.AddEdge(from, new WeightedEdge<T>(to, weight));

                foreach (var edge in graph.GetNeighbors(to))
                {
                    if (!visited.Contains(edge.Vertex))
                    {
                        pq.Enqueue((to, edge.Vertex, edge.Weight), edge.Weight);
                    }
                }
            }

            return primGraph;
        }


    }
}
