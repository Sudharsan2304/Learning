namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static Dictionary<T, double> ShortestPath<T>(
            WeightedDirectedGraph<T> weightedDirectedGraph,
            T source
        ) where T : notnull
        {
            // Cast for compatibility with TopoSort
            var graph = weightedDirectedGraph as Graph<T, T>;

            // Get topological order
            var topoSort = TopoSort(graph);

            // Initialize distances
            var distance = new Dictionary<T, double>();
            foreach (var vertex in topoSort)
            {
                distance[vertex] = double.PositiveInfinity;
            }
            distance[source] = 0;

            // Relax edges in topo order
            foreach (var vertex in topoSort)
            {
                if (distance[vertex] != double.PositiveInfinity)
                {
                    foreach (var neighbor in weightedDirectedGraph.GetNeighbors(vertex))
                    {
                        double newDist = distance[vertex] + neighbor.Weight;

                        if (newDist < distance[neighbor.Vertex])
                        {
                            distance[neighbor.Vertex] = newDist;
                        }
                    }
                }
            }

            return distance;
        }

    }
}
