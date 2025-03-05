
namespace  Transcriptor.Types;


public record ScriptType(string[] Transripteds)
{
    public override string ToString() => string.Concat(Transripteds);
}

public static class Script
{
    public static ScriptType Empty => Create();
    public static ScriptType Create(params string[] scripts) => new(scripts);
    public static ScriptType Create(char[] scripts) => new([..scripts.Select(c => c.ToString())]);
}