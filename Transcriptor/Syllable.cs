namespace Transcriptor;
public record SyllableType(char[] Letters)
{
    public override string ToString() => string.Concat(Letters);
}

public static class Syllable
{
    public static SyllableType Empty => Create();
    public static SyllableType Create(params char[] letters) => new(letters);

}