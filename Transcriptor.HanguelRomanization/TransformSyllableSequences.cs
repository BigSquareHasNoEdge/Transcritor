using Transcriptor.Functions;
using Transcriptor.HanguelRomanization.Common;
using Transcriptor.HanguelRomanization.Types;
using Transcriptor.Types;

namespace Transcriptor.HanguelRomanization;

static class TransformSyllableSequences
{
    public static TransformSequence ApplyAll => syllables =>
        ConsonantAssimillation
        .Then(NienRieulEpenthetic)
        .Then(Palatalization)
        .Then(Aspiration)
        .Then(EmptifyChosungYieung)
        .Invoke(syllables);
    /// <summary>
    /// 자음 동화
    /// ㄱㅁ => ㅇㅁ
    /// ㄴㄹ => ㄴㄴ
    /// ㅇㄹ => ㅇㄴ
    /// ㅂㄹ => ㅁㄴ
    /// ㄹㄹ => ㄹㄴ
    /// ㄴㄹ => ㄹㄹ
    /// </summary>
    public static TransformSequence ConsonantAssimillation => syllables => syllables;

    /// <summary>
    /// ㄴ, ㄹ 덧소리
    /// </summary>
    public static TransformSequence NienRieulEpenthetic => syllables => syllables;

    /// <summary>
    /// 구개음화
    /// </summary>
    public static TransformSequence Palatalization => syllables => syllables;

    /// <summary>
    /// 탁음화(거센 소리)
    /// </summary>
    public static TransformSequence Aspiration => syllables => syllables;


    const char Yieung = 'ㅇ';
    /// <summary>
    /// 모음 뒤 ㅇ 생략
    /// </summary>
    public static TransformSequence EmptifyChosungYieung => syllables =>
        syllables.Prepend(Syllable.Empty).Zip(syllables).Foreach(t =>
        {
            if ((t.First.Letters.Length == 0 ||  t.First.HasJongsung()) 
                && t.Second.Letters.First() == Yieung )
            {
                t.Second.Letters[0] = '\0';
            }
        }).Select(t => t.Second);

}