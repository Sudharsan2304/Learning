using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static bool DetectCycle<T>(DirectedGraph<T> directedGraph) where T : notnull 
        {
            List<T> topoSort = TopoSort(directedGraph);

            if (topoSort.IsNullOrEmpty())
            {
                return false;
            }

            return topoSort.Count != directedGraph.Vertices.Count();
        }
    }
}
