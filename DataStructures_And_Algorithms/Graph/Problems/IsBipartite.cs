using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static class GraphExtensions
        {
            /// <summary>
            /// Check if the entire graph is bipartite (handles multiple components).
            /// </summary>
            public static bool IsBipartite<T>(Graph<T, T> graph, out Dictionary<T, int> color)
                where T : notnull
            {
                color = [];

                foreach (var start in graph.Vertices)
                {
                    if (color.ContainsKey(start))
                    {
                        continue;
                    }

                    if (!CheckComponent(graph, start, color))
                    {
                        return false;
                    }
                }

                return true;
            }

            /// <summary>
            /// BFS to check if a single connected component starting at 'start' is bipartite.
            /// </summary>
            private static bool CheckComponent<T>(
                Graph<T, T> graph,
                T start,
                Dictionary<T, int> color) where T : notnull
            {
                Queue<T> queue = [];
                color[start] = 0;
                queue.Enqueue(start);

                while (queue.IsNotEmpty())
                {
                    var u = queue.Dequeue();

                    foreach (var v in graph.GetNeighbors(u))
                    {
                        if (!color.TryGetValue(v, out int value))
                        {
                            color[v] = 1 - color[u];
                            queue.Enqueue(v);
                        }
                        else if (value == color[u])
                        {
                            return false; // conflict found → not bipartite
                        }
                    }
                }

                return true;
            }
        }

    }
}
