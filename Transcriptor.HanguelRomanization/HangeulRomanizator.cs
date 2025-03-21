using System.Globalization;

namespace Transcriptor.HanguelRomanization;

class HangeulRomanizator : ITranscriptor
{
    public TranscriptorContext Context { get; } = new(new("ko-Kr"), CultureInfo.InvariantCulture);
    public string Transcribe(string text) => text.RomanizeHangeuls();
}