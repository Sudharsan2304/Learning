namespace SharedProject.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNotEmpty<T>(this IEnumerable<T> values) => !values.Any();

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> values) => values is null || !values.Any();

        public static bool IsWithinBoundary(this IEnumerable<IEnumerable<int>> island, int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextRow < island.Count() &&
                   nextCol >= 0 && nextCol < island.ElementAt(nextRow).Count();
        }
    }
}
