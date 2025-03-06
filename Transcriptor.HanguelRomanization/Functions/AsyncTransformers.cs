namespace Transcriptor.HanguelRomanization.Functions;

public class AsyncTransformers
{
    public static TransformPhraseAsync All => NounAsIs;


    /// <summary>
    /// 특정 명사는 음운 법칙을 생략하고, 첫 글자를 대문자로.
    /// 집현전 => Jiphyeonjeon
    /// </summary>
    public static TransformPhraseAsync NounAsIs => phrase =>
        Task.FromResult(phrase);
}
