namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        //https://leetcode.com/problems/clone-graph/description/

        public static Graph<T, T> CloneGraph<T>(Graph<T, T> graph, T start) where T : notnull
        {
            ArgumentNullException.ThrowIfNull(graph, nameof(graph));

            var newGraph = new UndirectedGraph<T>();
            var visited = new HashSet<T>();
            var stack = new Stack<T>();

            stack.Push(start);
            visited.Add(start);

            // Ensure the start vertex exists in the cloned graph
            newGraph.AddVertex(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    // Add neighbor vertex if not already in new graph
                    if (!visited.Add(neighbor))
                    {
                        stack.Push(neighbor);
                        newGraph.AddVertex(neighbor);
                    }

                    // Add the edge (undirected, so add once)
                    newGraph.AddEdge(current, neighbor);
                }
            }

            return newGraph;
        }

    }
}
