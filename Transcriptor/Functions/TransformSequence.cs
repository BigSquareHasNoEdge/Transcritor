using Transcriptor.Types;

namespace Transcriptor.Functions;

public delegate IEnumerable<SyllableType> TransformSequence(IEnumerable<SyllableType> syllables);

public static class TransformSequenceExtensions
{
    public static TransformSequence Then(this TransformSequence first, TransformSequence second) =>
        handle => second(first(handle));
}
