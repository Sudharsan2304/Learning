namespace DataStructures_And_Algorithms.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public class ClimbingStairsProblem
        {
            private readonly Dictionary<int, int> _memo = [];

            public int ClimbStair(int n)
            {
                if (_memo.TryGetValue(n, out int value))
                {
                    return value;
                }

                // ✅ Base cases
                if (n == 0 || n == 1)
                {
                    _memo[n] = 1;
                    return 1;
                }

                // ✅ Recursive relation
                _memo[n] = ClimbStair(n - 1) + ClimbStair(n - 2);

                return _memo[n];
            }
        }

        
    }
}
