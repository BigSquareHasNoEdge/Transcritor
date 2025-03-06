using System.Text;
using Transcriptor.HanguelRomanization.Common;
using Transcriptor.HanguelRomanization.Types;

namespace Transcriptor.HanguelRomanization.Types;

public static class KoreanPhrase
{
    public static TranscribePhrase Romanize => phrase =>
        KoreanSyllable.Trasncribe(phrase.Syllables);

    public static TransformPhrase AllTransforms => phrase =>
    ConsonantAssimillation
    .Then(NienRieulEpenthetic)
    .Then(Palatalization)
    .Then(Aspiration)
    .Then(EmptifyChosungYieung)
    .Invoke(phrase);
    /// <summary>
    /// 자음 동화
    /// ㄱㅁ => ㅇㅁ
    /// ㄴㄹ => ㄴㄴ
    /// ㅇㄹ => ㅇㄴ
    /// ㅂㄹ => ㅁㄴ
    /// ㄹㄹ => ㄹㄴ
    /// ㄴㄹ => ㄹㄹ
    /// </summary>
    public static TransformPhrase ConsonantAssimillation => phrase => phrase;

    /// <summary>
    /// ㄴ, ㄹ 덧소리
    /// </summary>
    public static TransformPhrase NienRieulEpenthetic => phrase => phrase;

    /// <summary>
    /// 구개음화
    /// </summary>
    public static TransformPhrase Palatalization => phrase => phrase;

    /// <summary>
    /// 탁음화(거센 소리)
    /// </summary>
    public static TransformPhrase Aspiration => phrase => phrase;


    const char Yieung = 'ㅇ';
    /// <summary>
    /// 모음 뒤 ㅇ 생략
    /// </summary>
    public static TransformPhrase EmptifyChosungYieung => phrase =>
        phrase.Syllables.Prepend(Syllable.Empty).Zip(phrase.Syllables)
        .Foreach(t =>
        {
            if ((t.First.Letters.Length == 0 || t.First.HasJongsung())
                && t.Second.Letters.First() == Yieung)
            {
                t.Second.Letters[0] = '\0';
            }
        }).Select(t => t.Second)
    .ToPhrase();

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