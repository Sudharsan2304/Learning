using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static Dictionary<T, int> ShortestPathOfUnweightedGraph<T>(Graph<T, T> graph, T start) where T : notnull
        {
            ArgumentNullException.ThrowIfNull(graph, nameof(graph));
            ArgumentNullException.ThrowIfNull(start, nameof(start));

            var visited = new HashSet<T>();
            var queue = new Queue<(T node, int distance)>();

            visited.Add(start);
            queue.Enqueue((start, 0));

            var result = new Dictionary<T, int>();
            while (queue.IsNotEmpty())
            {
                (T node, int distance) = queue.Dequeue();

                result.TryAdd(node, distance);

                foreach(T neighbor in graph.GetNeighbors(node))
                {
                    if (visited.Add(neighbor))
                    {
                        queue.Enqueue((neighbor, distance + 1));
                    }
                }
            }

            return result;
        }
    }
}
