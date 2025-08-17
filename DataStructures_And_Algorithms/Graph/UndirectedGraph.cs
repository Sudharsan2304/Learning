namespace DataStructures_And_Algorithms.Graph
{
    /// <summary>
    /// Represents an undirected graph using an adjacency list.
    /// In an undirected graph, edges are bidirectional:
    /// an edge (A — B) means both A is connected to B and B is connected to A.
    /// </summary>
    public class UndirectedGraph<T> : Graph<T, T> where T : notnull
    {
        /// <summary>
        /// Adds a vertex to the graph.
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
        /// Removes a vertex and all edges connected to it.
        /// </summary>
        public override void RemoveVertex(T vertex)
        {
            if (_adjacencyList.Remove(vertex)) // Remove the vertex itself
            {
                // Remove it from all other adjacency lists (undirected edges)
                foreach (var neighbors in _adjacencyList.Values)
                {
                    neighbors.Remove(vertex);
                }
            }
        }

        /// <summary>
        /// Adds an undirected edge between <paramref name="source"/> and <paramref name="destination"/>.
        /// If either vertex does not exist, it will be added automatically.
        /// </summary>
        public override void AddEdge(T source, T destination)
        {
            AddVertex(source);
            AddVertex(destination);

            // Add both ways (bidirectional)
            _adjacencyList[source].Add(destination);
            _adjacencyList[destination].Add(source);
        }

        /// <summary>
        /// Removes an undirected edge between <paramref name="source"/> and <paramref name="destination"/>.
        /// If the edge does not exist, this method does nothing.
        /// </summary>
        public override void RemoveEdge(T source, T destination)
        {
            if (_adjacencyList.TryGetValue(source, out var sourceNeighbors))
            {
                sourceNeighbors.Remove(destination);
            }

            if (_adjacencyList.TryGetValue(destination, out var destNeighbors))
            {
                destNeighbors.Remove(source);
            }
        }
    }


}
