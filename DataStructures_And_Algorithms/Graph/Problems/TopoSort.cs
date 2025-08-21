using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static List<T> TopoSort<T>(Graph<T, T> directedGraph) where T : notnull
        {
            ArgumentNullException.ThrowIfNull(directedGraph, nameof(directedGraph));

            // Initialize indegree for all vertices and count incoming edges
            var indegreeNodeCount = new Dictionary<T, int>();

            foreach (var vertex in directedGraph.Vertices)
            {
                if (!indegreeNodeCount.ContainsKey(vertex))
                {
                    indegreeNodeCount[vertex] = 0;
                }

                foreach (var neighbor in directedGraph.GetNeighbors(vertex))
                {
                    if (!indegreeNodeCount.TryGetValue(neighbor, out int value))
                    {
                        value = 0;
                        indegreeNodeCount[neighbor] = value;
                    }

                    indegreeNodeCount[neighbor] = ++value;
                }
            }

            // Enqueue all vertices with indegree 0
            var queue = new Queue<T>();
            foreach (var kvp in indegreeNodeCount)
            {
                if (kvp.Value == 0)
                {
                    queue.Enqueue(kvp.Key);
                }
            }

            var result = new List<T>();

            while (queue.IsNotEmpty())
            {
                var current = queue.Dequeue();

                result.Add(current);

                foreach (var neighbor in directedGraph.GetNeighbors(current))
                {
                    indegreeNodeCount[neighbor]--;

                    if (indegreeNodeCount[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }


        public static List<T> TopoSortDFS<T>(Graph<T, T> directedGraph) where T : notnull
        {
            ArgumentNullException.ThrowIfNull(directedGraph, nameof(directedGraph));

            var stack = new Stack<T>();

            var visited = new HashSet<T>(); 

            foreach(var vertex in directedGraph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    TopoSortDFS(directedGraph, stack, visited, vertex);
                }
            }

            var result =  new List<T>();

            while (stack.IsNotEmpty())
            {
                result.Add(stack.Pop());
            }


            return result;
        }

        private static void TopoSortDFS<T>(Graph<T, T> directedGraph, Stack<T> stack, HashSet<T> visited, T vertex) where T : notnull
        {
            visited.Add(vertex);

            foreach(var neighbor in directedGraph.GetNeighbors(vertex))
            {
                if (!visited.Contains(neighbor))
                {
                    TopoSortDFS(directedGraph, stack, visited, neighbor);
                }
            }

            stack.Push(vertex);
        }
    }
}
