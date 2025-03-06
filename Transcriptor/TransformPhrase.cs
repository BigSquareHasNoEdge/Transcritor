namespace Transcriptor;

public delegate PhraseType TransformPhrase(PhraseType phrase);

public static class TransformPhraseExtensions
{
    public static TransformPhrase Then(this TransformPhrase first, TransformPhrase next) =>
        phrase => next(first(phrase));
}

public delegate Task<PhraseType> TransformPhraseAsync(PhraseType phrase);

public static class TransformPhraseAsyncExtensions
{
    public static TransformPhraseAsync Then(this TransformPhraseAsync first, TransformPhraseAsync next) =>
        async phrase => await next(await first(phrase));
}