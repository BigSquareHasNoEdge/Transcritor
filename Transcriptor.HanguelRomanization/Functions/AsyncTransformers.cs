namespace Transcriptor.HanguelRomanization.Functions;

public class AsyncTransformers
{
    public static TransformPhraseAsync All => NounAsIs;


    /// <summary>
    /// 특정 명사는 음운 법칙을 생략하고, 첫 글자를 대문자로.
    /// 집현전 => Jiphyeonjeon
    /// 먼저 변환하므로, 동기 Transform 보다 먼저 실행되어야 함.
    /// </summary>
    public static TransformPhraseAsync NounAsIs => phrase =>
        Task.FromResult(phrase);
}
