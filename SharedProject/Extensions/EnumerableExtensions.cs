namespace SharedProject.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNotEmpty<T>(this IEnumerable<T> values) => !values.Any();
    }
}
