using System.Globalization;

namespace  Transcriptor;

public interface ITranscriptor
{
    TranscriptorContext Context { get; }

    string Transcribe(string text);
}

public record TranscriptorContext(CultureInfo Source, CultureInfo Target);
