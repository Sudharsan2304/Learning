namespace DataStructures_And_Algorithms.Graph
{
    public abstract class Graph<TVertex, TNeighbor> where TVertex : notnull where TNeighbor : notnull
    {
        // Adjacency list representation
        protected readonly Dictionary<TVertex, List<TNeighbor>> _adjacencyList
            = [];

        /// <summary>
        /// Add a vertex to the graph.
        /// </summary>
        public abstract void AddVertex(TVertex vertex);

        /// <summary>
        /// Remove a vertex and all its edges.
        /// </summary>
        public abstract void RemoveVertex(TVertex vertex);

        /// <summary>
        /// Add an edge between two vertices.
        /// For directed graphs, edge goes only from source → destination.
        /// </summary>
        public abstract void AddEdge(TVertex source, TNeighbor destination);

        /// <summary>
        /// Remove an edge between two vertices.
        /// </summary>
        public abstract void RemoveEdge(TVertex source, TNeighbor destination);

        /// <summary>
        /// Get neighbors of a given vertex.
        /// </summary>
        public virtual IEnumerable<TNeighbor> GetNeighbors(TVertex vertex)
        {
            return _adjacencyList.TryGetValue(vertex, out List<TNeighbor>? value) ? value : [];
        }

        /// <summary>
        /// Check if the graph contains a vertex.
        /// </summary>
        public virtual bool ContainsVertex(TVertex vertex) => _adjacencyList.ContainsKey(vertex);

        /// <summary>
        /// Check if the graph contains an edge.
        /// </summary>
        public virtual bool ContainsEdge(TVertex source, TNeighbor destination)
        {
            return _adjacencyList.ContainsKey(source) &&
                   _adjacencyList[source].Contains(destination);
        }

        /// <summary>
        /// Returns all vertices in the graph.
        /// </summary>
        public virtual IEnumerable<TVertex> Vertices => _adjacencyList.Keys;
    }
}
