using Transcriptor.HanguelRomanization.Types;

namespace Transcriptor.HanguelRomanization.Common;

static class IEnumerableExtensions
{
    public static IEnumerable<T> Foreach<T>(this IEnumerable<T> sequence, Action<T> action)
    {
        foreach (var item in sequence) { action(item); }
        return sequence;
    }

    public static List<PhraseType> ToPhrases(this IEnumerable<string> chops) =>
        [.. chops.SelectMany(KoreanPhrase.CreateMany)];

    public static PhraseType ToPhrase(this IEnumerable<SyllableType> syllables) =>
        Phrase.Create(syllables);
}
