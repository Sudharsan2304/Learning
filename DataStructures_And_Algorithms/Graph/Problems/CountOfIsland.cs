using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static int CountOfIsland(List<List<int>> island)
        {
            int countOfIsland = 0;
            for (int i = 0; i < island.Count; i++)
            {
                for (int j = 0; j < island[i].Count; j++)
                {
                    if (island[i][j] == 1)
                    {
                        DFSIsland(island, i, j);
                        countOfIsland++;
                    }
                }
            }

            return countOfIsland;
        }

        private static void DFSIsland(List<List<int>> island, int i, int j)
        {
            island[i][j] = -1;

            List<(int row, int col)> directions =
            [
                (-1, 0), (1, 0), (0, -1), (0, 1)
            ];

            foreach (var (row, col) in directions)
            {
                int nextRow = i + row, nextCol = j + col;

                var isWithinBoundary = island.IsWithinBoundary(nextRow, nextCol);

                if (isWithinBoundary &&
                    island[nextRow][nextCol] == 1)
                {
                    DFSIsland(island, nextRow, nextCol);
                }
            }
        }


    }
}
