using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph
{
    public partial class GraphTraversal
    {
        public static List<T> DFSIterative<T>(Graph<T, T> graph, T start) where T : notnull
        {
            var visited = new HashSet<T>();
            var result = new List<T>();
            var stack = new Stack<T>();

            stack.Push(start);

            while (stack.IsNotEmpty())
            {
                var current = stack.Pop();

                if (visited.Contains(current))
                    continue;

                visited.Add(current);
                result.Add(current);

                // Push neighbors (order matters: reverse if you want same order as recursive DFS)
                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }

            return result;
        }
        public static void DFSRecursive<T>(Graph<T, T> graph, T start, HashSet<T> visited, List<T> result) where T : notnull
        {
            if (visited.Contains(start))
            {
                return;
            }

            visited.Add(start);
            result.Add(start);

            foreach (var neighbor in graph.GetNeighbors(start))
            {
                if (!visited.Contains(neighbor))
                {
                    DFSRecursive(graph, neighbor, visited, result);
                }
            }
        }

        public static List<T> DFSAllComponents<T>(Graph<T, T> graph) where T : notnull
        {
            var visited = new HashSet<T>();
            var result = new List<T>();

            foreach (var vertex in graph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    DFSRecursive(graph, vertex, visited, result);
                }
            }

            return result;
        }

    }
}
