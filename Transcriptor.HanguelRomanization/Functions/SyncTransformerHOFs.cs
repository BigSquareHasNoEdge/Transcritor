using Transcriptor.HanguelRomanization.Common;
using Transcriptor.HanguelRomanization.Types;

namespace Transcriptor.HanguelRomanization.Functions;

public static class SyncTransformerHOFs
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
    public static TransformPhrase Palatalization =>
        phrase => phrase;

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
            if ((t.First.Letters.Length == 0 || t.First.HasJongseong())
                && t.Second.Letters.First() == Yieung)
            {
                t.Second.Letters[0] = '\0';
            }
        })
        .Select(t => t.Second)
        .ToPhrase();

}