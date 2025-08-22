namespace DataStructures_And_Algorithms.Graph
{
    /// <summary>
    /// Represents a weighted, undirected graph using adjacency list representation.
    /// Each vertex can have edges with weights, and edges are stored in both directions.
    /// </summary>
    /// <typeparam name="T">The type of vertices (must be non-nullable).</typeparam>
    public class WeightedUndirectedGraph<T> : Graph<T, WeightedEdge<T>>
        where T : notnull
    {
        /// <summary>
        /// Adds a new vertex to the graph if it does not already exist.
        /// </summary>
        public override void AddVertex(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                _adjacencyList[vertex] = [];
            }
        }

        /// <summary>
        /// Removes a vertex and all edges associated with it.
        /// </summary>
        public override void RemoveVertex(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
                return;

            // Remove all edges in other vertices pointing to this vertex
            foreach (var edges in _adjacencyList.Values)
            {
                edges.RemoveAll(e => EqualityComparer<T>.Default.Equals(e.Vertex, vertex));
            }

            // Remove the vertex itself
            _adjacencyList.Remove(vertex);
        }

        /// <summary>
        /// Adds an undirected, weighted edge between two vertices.
        /// If either vertex does not exist, it is created automatically.
        /// </summary>
        public override void AddEdge(T source, WeightedEdge<T> destination)
        {
            // Ensure both vertices exist
            if (!_adjacencyList.ContainsKey(source))
            {
                AddVertex(source);
            }

            if (!_adjacencyList.ContainsKey(destination.Vertex))
            {
                AddVertex(destination.Vertex);
            }

            // Add edge source -> destination
            _adjacencyList[source].Add(destination);

            // Add reverse edge destination -> source
            _adjacencyList[destination.Vertex].Add(new WeightedEdge<T>(source, destination.Weight));
        }

        /// <summary>
        /// Removes an undirected edge between two vertices.
        /// </summary>
        public override void RemoveEdge(T source, WeightedEdge<T> destination)
        {
            if (_adjacencyList.TryGetValue(source, out var edges))
            {
                edges.RemoveAll(e => EqualityComparer<T>.Default.Equals(e.Vertex, destination.Vertex)
                                   && e.Weight.Equals(destination.Weight));
            }

            if (_adjacencyList.TryGetValue(destination.Vertex, out var reverseEdges))
            {
                reverseEdges.RemoveAll(e => EqualityComparer<T>.Default.Equals(e.Vertex, source)
                                          && e.Weight.Equals(destination.Weight));
            }
        }
    }

}
