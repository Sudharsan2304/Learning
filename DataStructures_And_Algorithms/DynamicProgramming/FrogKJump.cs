namespace DataStructures_And_Algorithms.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public class FrogKJumpProblem
        {
            public static int FrogKJump(List<int> height, int k)
            {
                int n = height.Count;
                Dictionary<int, int> dp = new()
                {
                    [0] = 0 
                };

                for (int i = 1; i < n; i++)
                {
                    int minCost = int.MaxValue;

                    for (int j = 1; j <= k && i - j >= 0; j++)
                    {
                        int prevCost = dp[i - j]; // safe since we always fill before
                        int cost = prevCost + Math.Abs(height[i] - height[i - j]);
                        minCost = Math.Min(minCost, cost);
                    }

                    dp[i] = minCost;
                }

                return dp[n - 1]; // answer is min cost to reach last stone
            }
        }
    }
}
