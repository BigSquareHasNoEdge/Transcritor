namespace Transcriptor;

public delegate PhraseType TransformPhrase(PhraseType phrase);

public static class TransformPhraseExtensions
{
    public static TransformPhrase Then(this TransformPhrase first, TransformPhrase next) =>
        phrase => next(first(phrase));
}
