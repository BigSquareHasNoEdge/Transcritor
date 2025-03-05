using Transcriptor.HanguelRomanization.Common;
using Transcriptor.Types;

namespace Transcriptor.HanguelRomanization.Types;

public static class KoreanPhrase
{
    internal static IEnumerable<PhraseType> CreateMany(string chunk) =>
        chunk.Length == 0 ? []
        : AsPronouces(chunk)
        .Select(p => 
            p.ByCharacter ? Phrase.Create([.. p.Text.Select(KoreanSyllable.Create)])
            : Phrase.Create(Syllable.Create(p.Text.ToCharArray())));

    static IEnumerable<Pronouce> AsPronouces(string chunk) =>
        SplitByHanguel(chunk).ToList()
        .Select(seg => 
            new Pronouce(seg, seg.First().IsHanguel()));

    public static IEnumerable<string> SplitByHanguel(string chunk)
    {
        if (chunk.Length == 0) yield break;

        if (chunk.Length == 1 || chunk.Any(c => c.IsHanguel()) is false)
        {
            yield return chunk;
            yield break;
        }

        var first = chunk[0];
        char[] others = [.. chunk[1..]];

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
