using Transcriptor.HanguelRomanization.Types;
using Transcriptor.Types;

namespace Transcriptor.HanguelRomanization.Common;

static class IEnumerableExtensions
{
    public static IEnumerable<T> Foreach<T>(this IEnumerable<T> sequence, Action<T> action)
    {
        foreach (var item in sequence) { action(item); }
        return sequence;
    }

    public static IEnumerable<SyllableType> ApplyTransforms(this IEnumerable<SyllableType> syllables) =>
        TransformSyllableSequences.ApplyAll.Invoke(syllables);

    public static IEnumerable<SyllableType> ToSyllables(this IEnumerable<PhraseType> phrases) =>
        phrases.SelectMany(p => p.Syllables);

    public static List<PhraseType> ToPhrases(this IEnumerable<string> phrases) =>
        [.. phrases.SelectMany(KoreanPhrase.CreateMany)];
}
