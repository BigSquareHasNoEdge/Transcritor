using Transcriptor.HanguelRomanization.Common;
using Transcriptor.HanguelRomanization.Types;
using Transcriptor.Types;
namespace Transcriptor.HanguelRomanization;

public static class StringExtensions
{
    public static string RomanizeHangeuls(this string text, char delimiter) =>
        string.Join(delimiter, 
            text.Split().ToPhrases().ToSyllables().ApplyTransforms()
            .Select(KoreanSyllable.Romanizer.Invoke)
        );
    public static string RomanizeHangeuls(this string text) =>
        string.Concat(
            text.Chop().ToList()
            .ToPhrases().ToSyllables().ApplyTransforms()
            .Select(KoreanSyllable.Romanizer.Invoke)
            .Select(script => script.ToString())
        );

    public static IEnumerable<string> Chop(this string text)
    {
        char[] delimeters = [' ', '\t', '\n', '\r'];
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