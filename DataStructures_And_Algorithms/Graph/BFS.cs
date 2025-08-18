using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph
{
    public partial class GraphTraversal
    {
        public static List<T> BFS<T>(Graph<T, T> graph, T start, HashSet<T> visited) where T : notnull
        {
            ArgumentNullException.ThrowIfNull(graph, nameof(graph));
            ArgumentNullException.ThrowIfNull(start, nameof(start));

            var queue = new Queue<T>();

            visited.Add(start);
            queue.Enqueue(start);

            var result = new List<T>();

            while (queue.IsNotEmpty())
            {
                var current = queue.Dequeue();

                result.Add(current);

                foreach (var item in graph.GetNeighbors(current))
                {
                    if (visited.Add(item))
                    {
                        queue.Enqueue(item);
                    }
                }
            }

            return result;
        }

        public static List<T> BFSAllComponents<T>(Graph<T, T> graph) where T : notnull
        {
            var visited = new HashSet<T>();
            var result = new List<T>();

            foreach(var item in graph.Vertices)
            {
                if (visited.Contains(item))
                {
                    continue;
                }

                result.AddRange(BFS(graph, item, visited));
            }

            return result;

        }

    }
}
