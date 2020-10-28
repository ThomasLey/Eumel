namespace Eumel.EmailCategorizer.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// get string from source between topicStart and topicEnd
        /// </summary>
        public static string Between(this string source, string topicStart, string topicEnd)
        {
            var start = source.IndexOf(topicStart, System.StringComparison.Ordinal);
            var end = source.IndexOf(topicEnd, start + 1, System.StringComparison.Ordinal);

            if (start < 0 || end < 0) return string.Empty;

            if (start > end) Switch(ref start, ref end);

            return source.Substring(start + 1, end - start - 1);
        }

        /// <summary>
        /// switch two values
        /// </summary>
        private static void Switch(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}