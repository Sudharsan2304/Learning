using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_And_Algorithms.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MaximumSumOfAdjacentElements(List<int> arr, int i, Dictionary<int, int> memo)
        {
            if (i < 0)
            {
                return 0;
            }

            if (i == 0)
            {
                return arr[0];
            }

            if (memo.TryGetValue(i, out int value))
            {
                return value;
            }

            int pick = arr[i] + MaximumSumOfAdjacentElements(arr, i - 2, memo);
            int notPick = MaximumSumOfAdjacentElements(arr, i - 1, memo);

            memo[i] = Math.Max(pick, notPick);
            return memo[i];
        }

        public static int MaximumSumOfAdjacentElements(List<int> arr)
        {
            int n = arr.Count;
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return arr[0];
            }

            int prev2 = arr[0];
            int prev1 = Math.Max(arr[0], arr[1]);

            for (int i = 2; i < n; i++)
            {
                int pick = arr[i] + prev2;
                int notPick = prev1;
                int curr = Math.Max(pick, notPick);

                prev2 = prev1;
                prev1 = curr;
            }

            return prev1;
        }


    }
}
