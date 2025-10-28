namespace Transcriptor.HanguelRomanization.Common;
static class CharExtensions
{
    public static Hangeul GetHangeul(this char c) => (int)c switch 
    {
        >= 0x1100 and <= 0x11FF => Hangeul.JamoBasic,
        >= 0x3130 and <= 0x318F => Hangeul.JamoCom,
        >= 0xAC00 and <= 0xD7A3 => Hangeul.Syllable,
        >= 0xA960 and <= 0xA97F => Hangeul.JamoExtA,
        >= 0xD7B0 and <= 0xD7FF => Hangeul.JamoExtB,
        _ => Hangeul.None
    };

    public static bool IsHanguel(this char c) => c.GetHangeul() != Hangeul.None;
}

/// <summary>
/// represets a type of a Hangeul letter.
/// </summary>
enum Hangeul
{  
    /// <summary>
    /// Not Hangeul
    /// </summary>
    None,
    /// <summary>
    /// a unit of pronounciation composed of an opening consonant, a vowel, and, optionally, a stoping consonant.
    /// </summary>
    Syllable,
    /// <summary>
    /// Jamo's in Basic Jamo block of Unicode being used in modern Korean laguage.
    /// </summary>
    JamoBasic,
    /// <summary>
    /// Jamo's in Extended A Jamo block of Unicode used in old Hanguel.
    /// </summary>
    JamoExtA,
    /// <summary>
    /// Jamo's in Extended B Jamo block of Unicode used in older Hanguel.
    /// </summary>
    JamoExtB,
    /// <summary>
    /// Jamo's in Compatibility Jamo block of Unicode to maintain compatibility with older standards.
    /// This system works with this block.
    /// </summary>
    JamoCom,
}