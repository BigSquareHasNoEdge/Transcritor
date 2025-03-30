namespace Transcriptor.HanguelRomanization.Functions;

public static class AsyncTransformerHOFs
{
    public static TransformPhraseAsync All => NounAsIs;


    /// <summary>
    /// The exception on Korean sound transitions for composed words.
    /// </summary>
    /// <example>
    /// 집현전 => Jiphyeonjeon instead of Jipyeonjeon.
    /// </example>
    public static TransformPhraseAsync NounAsIs => phrase =>
        Task.FromResult(phrase);
}
