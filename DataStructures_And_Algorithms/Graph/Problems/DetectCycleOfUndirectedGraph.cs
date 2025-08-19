namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {

        public static bool DetectCycle<T>(UndirectedGraph<T> graph) where T : notnull
        {
            var visited = new HashSet<T>();

            foreach (var vertex in graph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    if (DetectCycle(graph, vertex, visited, default, hasParent: false))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool DetectCycle<T>(
            UndirectedGraph<T> graph,
            T vertex,
            HashSet<T> visited,
            T? parent,
            bool hasParent) where T : notnull
        {
            visited.Add(vertex);

            foreach (var neighbor in graph.GetNeighbors(vertex))
            {
                if (!visited.Contains(neighbor))
                {
                    if (DetectCycle(graph, neighbor, visited, vertex, hasParent: true))
                    {
                        return true;
                    }
                }
                else
                {
                    if (!(hasParent && EqualityComparer<T>.Default.Equals(neighbor, parent)))
                    {
                        // visited neighbor that is not the parent → cycle found
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
