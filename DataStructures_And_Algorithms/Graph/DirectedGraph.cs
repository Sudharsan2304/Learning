namespace DataStructures_And_Algorithms.Graph
{
    /// <summary>
    /// Represents a directed graph using an adjacency list.
    /// In a directed graph, edges have a direction: source → destination.
    /// </summary>
    public class DirectedGraph<T> : Graph<T, T> where T : notnull
    {
        /// <summary>
        /// Adds a vertex to the directed graph.
        /// If the vertex already exists, nothing happens.
        /// </summary>
        public override void AddVertex(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                _adjacencyList[vertex] = [];
            }
        }

        /// <summary>
        /// Removes a vertex and all its edges (incoming and outgoing).
        /// </summary>
        public override void RemoveVertex(T vertex)
        {
            if (_adjacencyList.Remove(vertex)) // Remove the vertex and all outgoing edges
            {
                // Remove incoming edges (anywhere vertex appears as a neighbor)
                foreach (var neighbors in _adjacencyList.Values)
                {
                    neighbors.Remove(vertex);
                }
            }
        }

        /// <summary>
        /// Adds a directed edge from <paramref name="source"/> to <paramref name="destination"/>.
        /// If either vertex does not exist, it will be added automatically.
        /// </summary>
        public override void AddEdge(T source, T destination)
        {
            // Ensure both vertices exist
            AddVertex(source);
            AddVertex(destination);

            // Add destination as a neighbor of source (one-way)
            _adjacencyList[source].Add(destination);
        }

        /// <summary>
        /// Removes a directed edge from <paramref name="source"/> to <paramref name="destination"/>.
        /// If the edge does not exist, this method does nothing.
        /// </summary>
        public override void RemoveEdge(T source, T destination)
        {
            if (_adjacencyList.TryGetValue(source, out var neighbors))
            {
                neighbors.Remove(destination);
            }
        }
    }



}
