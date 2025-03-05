using Transcriptor.Types;

namespace  Transcriptor.Functions;

public delegate SyllableType Transform(SyllableType handle);

public static class TransformSyllableExtensions
{
    public static Transform Then(this Transform first, Transform second) => 
        handle => second(first(handle));
}