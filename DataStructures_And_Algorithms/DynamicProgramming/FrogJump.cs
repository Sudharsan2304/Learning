namespace DataStructures_And_Algorithms.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {

        public class FrogJumpProblem
        {
            public static int FrogJump(List<int> height)
            {
                int prev = 0;

                int prev2 = 0;

                for(int i = 1; i < height.Count; i++)
                {
                    var oneJump = prev + Math.Abs(height[i] - height[i - 1]);

                    var twoJump = int.MaxValue;  

                    if(i > 1)
                    {
                        twoJump = prev2 + Math.Abs(height[i] - height[i - 2]);
                    }

                    int cur = Math.Min(oneJump, twoJump);

                    prev2 = prev;

                    prev = cur;
                }
                return prev;
            }


        }

    }
}
