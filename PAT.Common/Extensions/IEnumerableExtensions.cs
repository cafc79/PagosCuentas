namespace PAT.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string ToString(this IEnumerable<string> records, string separator)
            => string.Join(separator, records);
    }
}
