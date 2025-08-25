using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static int Kosaraju<T>(DirectedGraph<T> graph) where T : notnull
        {
            ArgumentNullException.ThrowIfNull(graph, nameof(graph));

            HashSet<T> visited = [];
            Stack<T> finishStack = [];

            // Step 1: Fill stack with vertices in finishing order
            void Dfs1(T v)
            {
                visited.Add(v);

                foreach (var neighbor in graph.GetNeighbors(v))
                {
                    if (!visited.Contains(neighbor))
                    {
                        Dfs1(neighbor);
                    }
                }

                // Push after visiting all neighbors (post-order)
                finishStack.Push(v);
            }

            foreach (var vertex in graph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    Dfs1(vertex);
                }
            }

            // Step 2: Build reversed graph
            var reversed = new DirectedGraph<T>();
            foreach (var vertex in graph.Vertices)
            {
                reversed.AddVertex(vertex);
            }

            foreach (var vertex in graph.Vertices)
            {
                foreach (var neighbor in graph.GetNeighbors(vertex))
                {
                    reversed.AddEdge(neighbor, vertex); // reverse direction
                }
            }

            // Step 3: Process in finishing order, count SCCs
            visited.Clear();
            int sccCount = 0;

            void Dfs2(T v)
            {
                visited.Add(v);

                foreach (var neighbor in reversed.GetNeighbors(v))
                {
                    if (!visited.Contains(neighbor))
                    {
                        Dfs2(neighbor);
                    }
                }
            }

            while (finishStack.IsNotEmpty())
            {
                var v = finishStack.Pop();
                if (!visited.Contains(v))
                {
                    Dfs2(v);
                    sccCount++; // Each DFS = 1 SCC
                }
            }

            return sccCount;
        }

    }
}
