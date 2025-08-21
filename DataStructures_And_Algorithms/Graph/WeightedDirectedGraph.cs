namespace DataStructures_And_Algorithms.Graph
{
    /// <summary>
    /// Represents a weighted, directed graph using adjacency list representation.
    /// Each vertex can have outgoing edges with weights.
    /// </summary>
    /// <typeparam name="T">The type of vertices (must be non-nullable).</typeparam>
    public class WeightedDirectedGraph<T> : Graph<T, WeightedEdge<T>>
        where T : notnull
    {
        /// <summary>
        /// Adds a new vertex to the graph if it does not already exist.
        /// </summary>
        /// <param name="vertex">The vertex to add.</param>
        public override void AddVertex(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                // Initialize an empty adjacency list for the new vertex
                _adjacencyList[vertex] = [];
            }
        }

        /// <summary>
        /// Removes a vertex and all edges associated with it (both incoming and outgoing).
        /// </summary>
        /// <param name="vertex">The vertex to remove.</param>
        public override void RemoveVertex(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                return; // Nothing to remove
            }

            // Remove all edges in other vertices pointing to this vertex
            foreach (var edges in _adjacencyList.Values)
            {
                edges.RemoveAll(e => EqualityComparer<T>.Default.Equals(e.Vertex, vertex));
            }

            // Remove the vertex itself and all its outgoing edges
            _adjacencyList.Remove(vertex);
        }

        /// <summary>
        /// Adds a directed, weighted edge from a source vertex to a destination vertex.
        /// If the source or destination vertex does not exist, they are created automatically.
        /// </summary>
        /// <param name="source">The starting vertex of the edge.</param>
        /// <param name="destination">The edge (destination vertex + weight).</param>
        public override void AddEdge(T source, WeightedEdge<T> destination)
        {
            // Ensure source exists
            if (!_adjacencyList.ContainsKey(source))
            {
                AddVertex(source);
            }

            // Ensure destination vertex exists (even if it has no outgoing edges yet)
            if (!_adjacencyList.ContainsKey(destination.Vertex))
            {
                AddVertex(destination.Vertex);
            }

            // Add the edge to the adjacency list of the source
            _adjacencyList[source].Add(destination);
        }

        /// <summary>
        /// Removes a directed, weighted edge from a source to a destination vertex.
        /// </summary>
        /// <param name="source">The starting vertex of the edge.</param>
        /// <param name="destination">The edge to remove (destination vertex + weight).</param>
        public override void RemoveEdge(T source, WeightedEdge<T> destination)
        {
            if (_adjacencyList.TryGetValue(source, out var edges))
            {
                // Remove matching edge (record handles value equality)
                edges.Remove(destination);
            }
        }
    }

}
