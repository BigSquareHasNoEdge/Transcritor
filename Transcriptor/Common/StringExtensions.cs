namespace Transcriptor.Common;

public static class StringExtensions
{
    public static IEnumerable<string> Chop(this string text, params char[] delimeters)
    {
        if (delimeters.Length == 0) delimeters = [' '];
        var start = 0;
        int end = 0;

        while (start < text.Length)
        {
            var emptyIndex = text.IndexOfAny(delimeters, end);

            if (emptyIndex < 0)
            {
                if (start != end) yield return text[start..end];

                yield return text[end..];
                yield break;
            }

            if (emptyIndex == end)
            {
                end++;
            }
            else
            {
                if (start != end) yield return text[start..end];

                yield return text[end..emptyIndex];
                start = end = emptyIndex;
            }
        }
    }

}
