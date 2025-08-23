using SharedProject.Extensions;

namespace DataStructures_And_Algorithms.Graph.Problems
{
    public partial class GraphProblems
    {
        public static int MatrixInfection(List<List<int>> matrix)
        {
            var queue = new Queue<(int row, int col)>();
            var directions = new (int dr, int dc)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            int noOfUnInfectedPerson = 0;

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        noOfUnInfectedPerson++;
                    }
                    else if (matrix[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                }
            }

            // If there are no uninfected people, time is zero.
            if (noOfUnInfectedPerson == 0) return 0;

            int totalSeconds = 0;

            while (queue.IsNotEmpty())
            {
                int levelCount = queue.Count;
                bool infectedThisRound = false;

                for (int i = 0; i < levelCount; i++)
                {
                    var (r, c) = queue.Dequeue();

                    foreach (var (dr, dc) in directions)
                    {
                        int nr = r + dr;
                        int nc = c + dc;

                        if (IsWithinBoundary(matrix, nr, nc) && matrix[nr][nc] == 1)
                        {
                            matrix[nr][nc] = 2;
                            queue.Enqueue((nr, nc));
                            noOfUnInfectedPerson--;
                            infectedThisRound = true;
                        }
                    }
                }

                if (infectedThisRound) totalSeconds++;
            }

            return noOfUnInfectedPerson == 0 ? totalSeconds : -1;
        }
    }
}
