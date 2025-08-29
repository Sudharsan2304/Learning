namespace DataStructures_And_Algorithms.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        private readonly Dictionary<int, int> _memo = new();

        public int ClimbingStairs(int n)
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
            _memo[n] = ClimbingStairs(n - 1) + ClimbingStairs(n - 2);

            return _memo[n];
        }
    }
}
