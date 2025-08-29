namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static Dictionary<T, double> BellmanFord<T>(
        WeightedDirectedGraph<T> graph,
        T source) where T : notnull
        {
            // Step 1: Initialize distances
            var distance = new Dictionary<T, double>();

            foreach (var vertex in graph.Vertices)
            {
                distance[vertex] = double.PositiveInfinity; // infinity
            }

            distance[source] = 0;

            int V = graph.Vertices.Count();

            // Step 2: Relax edges |V|-1 times
            for (int i = 0; i < V - 1; i++)
            {
                bool updated = false;
                foreach (var u in graph.Vertices)
                {
                    if (distance[u] == double.PositiveInfinity)
                    {
                        continue;
                    }

                    foreach (var edge in graph.GetNeighbors(u))
                    {
                        T v = edge.Vertex;
                        double weight = edge.Weight;

                        if (distance[u] + weight < distance[v])
                        {
                            distance[v] = distance[u] + weight;
                            updated = true;
                        }
                    }
                }

                // Optimization: if no update happened in this pass, break early
                if (!updated) break;
            }

            // Step 3: Detect negative cycles
            foreach (var u in graph.Vertices)
            {
                if (distance[u] == double.PositiveInfinity)
                {
                    continue;
                }

                foreach (var edge in graph.GetNeighbors(u))
                {
                    T v = edge.Vertex;
                    double weight = edge.Weight;

                    if (distance[u] + weight < distance[v])
                    {
                        throw new InvalidOperationException("Graph contains a negative weight cycle");
                    }
                }
            }

            return distance;
        }

    }
}
