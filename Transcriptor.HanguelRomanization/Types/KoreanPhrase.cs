using System.Text;
using Transcriptor.HanguelRomanization.Common;

namespace Transcriptor.HanguelRomanization.Types;

public static class KoreanPhrase
{
    internal static IEnumerable<PhraseType> CreateMany(string chop) =>
         ToHangeulChecks(chop)
        .Select(t => 
            t.IsHangeul ? Phrase.Create([.. t.Text.Select(KoreanSyllable.Create)])
            : Phrase.Create(Syllable.Create(t.Text.ToCharArray())));

    static IEnumerable<(string Text, bool IsHangeul)> ToHangeulChecks(string chop) =>
        SplitByHanguel(chop)
        .Select(seg => (seg, seg.First().IsHanguel()));

    static string[] SplitByHanguel(string chop) => 
        chop.Length == 0 ? []        
        : chop.Length == 1  ? [chop]
        : chop.Skip(1).Aggregate(
            new StringBuilder(chop[..1]),
            (sb, next) => sb[^1].IsHanguel() != next.IsHanguel() 
                ? sb.Append('\0').Append(next) 
                : sb.Append(next),
            sb => sb.ToString().Split('\0'));    
}