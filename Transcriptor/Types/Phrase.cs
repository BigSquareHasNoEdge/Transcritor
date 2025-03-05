namespace Transcriptor.Types;

public record PhraseType(SyllableType[] Syllables)
{
    public override string ToString() => string.Concat(Syllables.Select(s => s.ToString()));

}

public static class Phrase
{
    public static PhraseType Create(params SyllableType[] syllables) => new(syllables);
}
