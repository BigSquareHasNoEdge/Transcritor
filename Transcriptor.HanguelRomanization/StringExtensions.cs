using Transcriptor.HanguelRomanization.Common;
using Transcriptor.HanguelRomanization.Types;
namespace Transcriptor.HanguelRomanization;

public static class StringExtensions
{
    public static string RomanizeHangeuls(this string text, char delimiter) =>
        RomanizeHangeuls(text, delimiter, KoreanPhrase.AllTransforms);

    public static string RomanizeHangeuls(this string text, char delimiter, 
        TransformPhrase trasforms) =>
        RomanizeHangeuls(text, delimiter, trasforms, KoreanPhrase.Romanize);

    public static string RomanizeHangeuls(this string text, char delimiter, 
        TransformPhrase transforms, TranscribePhrase transcribes) =>
        string.Join(delimiter,
            text.Split().ToPhrases().Select(transforms.Invoke)
                .Select(transcribes.Invoke));

    public static string RomanizeHangeuls(this string text) =>
        text.RomanizeHangeuls(KoreanPhrase.AllTransforms);    

    public static string RomanizeHangeuls(this string text, TransformPhrase transforms) =>
        text.RomanizeHangeuls(transforms, KoreanPhrase.Romanize);

    public static string RomanizeHangeuls(this string text, 
        TransformPhrase transforms, TranscribePhrase transcribes) =>
        string.Concat(text.Chop().ToPhrases()
            .Select(transforms.Invoke).Select(transcribes.Invoke));

    public static IEnumerable<string> Chop(this string text)
    {
        char[] delimeters = [' ', '\t', '\n', '\r'];
        var start = 0;
        var end = 0;

        while (start < text.Length)
        {
            var emptyIndex = text.IndexOfAny(delimeters, end);

            if (emptyIndex == end)
            {
                end++;
                continue;
            }

            if (start != end) yield return text[start..end];

            if (emptyIndex < 0)
            {
                yield return text[end..];  yield break;
            }

            yield return text[end..emptyIndex];
            start = end = emptyIndex;
        }
    }
}