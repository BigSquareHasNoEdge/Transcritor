using Transcriptor.HanguelRomanization.Common;
using Transcriptor.Types;

namespace Transcriptor.HanguelRomanization.Types;

public static class KoreanPhrase
{
    internal static IEnumerable<PhraseType> CreateMany(string chunk) =>
        chunk.Length == 0 ? []
        : AsPronouces(chunk)
        .Select(p => p.ByCharacter ? Phrase.Create([.. p.Text.Select(KoreanSyllable.Create)])
            : Phrase.Create(Syllable.Create(chunk.ToCharArray())));

    static IEnumerable<Pronouce> AsPronouces(string phrase) =>
        SplitByHanguel(phrase)
        .Select(seg => new Pronouce(seg, seg.First().IsHanguel()));

    static IEnumerable<string> SplitByHanguel(string chuck)
    {
        if (chuck.Length == 0) yield break;

        if (chuck.Length == 1)
        {
            yield return chuck; yield break;
        }

        var first = chuck[0];
        char[] others = [.. chuck[1..]];

        var blankSeprated = others.Aggregate(
            new List<char>([first]),
            (list, next) =>
            {
                if (list.Last().IsHanguel() != next.IsHanguel())
                {
                    list.Add('\0');
                }
                list.Add(next);
                return list;                        
            },
            list => new string([.. list]));

        foreach (var seg in blankSeprated.Split('\0'))
        {
            yield return seg;
        }
    }
}
