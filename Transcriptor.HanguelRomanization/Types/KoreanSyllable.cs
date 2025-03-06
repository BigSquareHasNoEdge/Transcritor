using System.Text;
using Transcriptor.HanguelRomanization.Common;
using static Transcriptor.HanguelRomanization.Functions.MapJamoBlocks;

namespace Transcriptor.HanguelRomanization.Types;

static class KoreanSyllable
{
    static string Trasncribe(SyllableType s) => s.Letters.Length switch
    {
        0 => string.Empty,

        1 => GetConsonantName(s.Letters[0]) ?? GetVowelName(s.Letters[0])
                ?? s.Letters[0].ToString(),

        2 => (GetChoSeongRoman(s.Letters[0]) ?? s.Letters[0].ToString()) +
                (GetVowelRoman(s.Letters[1]) ?? s.Letters[1].ToString()),

        3 => (GetChoSeongRoman(s.Letters[0]) ?? s.Letters[0].ToString()) + 
                (GetVowelRoman(s.Letters[1]) ?? s.Letters[1].ToString()) + 
                (GetJongSeongRoman(s.Letters[2]) ?? s.Letters[2].ToString()),

        _ => new (s.Letters)
    };

    public static string Trasncribe(IEnumerable<SyllableType> syllables) =>
        syllables.Aggregate(
            new StringBuilder(),
            (sb, str) => sb.Append(Trasncribe(str))
        ).ToString();

    static readonly Dictionary<char, string> vowelRomans = new()
    {
        { 'ㅏ', "a" },
        { 'ㅐ', "ae" },
        { 'ㅑ', "ya" },
        { 'ㅒ', "yae" },
        { 'ㅓ', "eo" },
        { 'ㅔ', "e" },
        { 'ㅕ', "yeo" },
        { 'ㅖ', "ye" },
        { 'ㅗ', "o" },
        { 'ㅘ', "wa" },
        { 'ㅙ', "wae" },
        { 'ㅚ', "oe" },
        { 'ㅛ', "yo" },
        { 'ㅜ', "u" },
        { 'ㅝ', "wo" },
        { 'ㅞ', "we" },
        { 'ㅟ', "wi" },
        { 'ㅠ', "yu" },
        { 'ㅡ', "eu" },
        { 'ㅢ', "ui" },
        { 'ㅣ', "i" }
    };
    static readonly Dictionary<char, string> choseongRomans = new()
    {
        { 'ㄱ', "g" },
        { 'ㄲ', "kk" },
        { 'ㄴ', "n" },
        { 'ㄷ', "d" },
        { 'ㄸ', "tt" },
        { 'ㄹ', "r" },
        { 'ㅁ', "m" },
        { 'ㅂ', "b" },
        { 'ㅃ', "pp" },
        { 'ㅅ', "s" },
        { 'ㅆ', "ss" }, 
        { 'ㅇ', "" },   
        { 'ㅈ', "j" },
        { 'ㅉ', "jj" },
        { 'ㅊ', "ch" },
        { 'ㅋ', "k" },
        { 'ㅌ', "t" },
        { 'ㅍ', "p" },
        { 'ㅎ', "h" },
    };
    static readonly Dictionary<char, string> jongseongRomans = new()
    {
        { 'ㄱ', "k" },
        { 'ㄲ', "kk" },
        { 'ㄳ', "ks" },
        { 'ㄴ', "n" },
        { 'ㄵ', "nj" },
        { 'ㄶ', "nh" },
        { 'ㄷ', "t" },
        { 'ㄹ', "l" },
        { 'ㄺ', "lk" },
        { 'ㄻ', "lm" },
        { 'ㄼ', "lb" },
        { 'ㄽ', "ls" },
        { 'ㄾ', "lt" },
        { 'ㄿ', "lp" },
        { 'ㅀ', "lh" },
        { 'ㅁ', "m" },
        { 'ㅂ', "p" },
        { 'ㅄ', "ps" },
        { 'ㅅ', "s" },
        { 'ㅆ', "ss" },
        { 'ㅇ', "ng" },
        { 'ㅈ', "j" },
        { 'ㅊ', "ch" },
        { 'ㅋ', "k" },
        { 'ㅌ', "t" },
        { 'ㅍ', "p" },
        { 'ㅎ', "h" }
    };
    static readonly Dictionary<char, string> consonantNames = new()
    {
        { 'ㄱ', "giyeok" },
        { 'ㄲ', "ssanggiyeok" },
        { 'ㄴ', "nieun" },
        { 'ㄷ', "digeut" },
        { 'ㄸ', "ssangdigeut" },
        { 'ㄹ', "rieul" },
        { 'ㅁ', "mieum" },
        { 'ㅂ', "bieup" },
        { 'ㅃ', "ssangbieup" },
        { 'ㅅ', "siot" },
        { 'ㅆ', "ssangsiot" },
        { 'ㅇ', "ieung" },
        { 'ㅈ', "jieut" },
        { 'ㅉ', "ssangjieut" },
        { 'ㅊ', "chieut" },
        { 'ㅋ', "kieuk" },
        { 'ㅌ', "tieut" },
        { 'ㅍ', "pieup" },
        { 'ㅎ', "hieut" },
        { 'ㄳ', "giyeoksiot" },
        { 'ㄵ', "nieunjieut" },
        { 'ㄶ', "nieunhieut" },
        { 'ㄺ', "rieulgiyeok" },
        { 'ㄻ', "rieulmieum" },
        { 'ㄼ', "rieulbieup" },
        { 'ㄽ', "rieulsiot" },
        { 'ㄾ', "rieultieut" },
        { 'ㄿ', "rieulpieup" },
        { 'ㅀ', "rieulhieut" },
        { 'ㅄ', "bieupsiot" },
    };

    public static bool HasJongsung(this SyllableType syllable) =>
        syllable.Letters.Length == 3 && IsConsonant(syllable.Letters[2]);

    public static string? GetChoSeongRoman(char @char) =>
        choseongRomans.TryGetValue(@char, out var roman) ? roman : null;
    
    public static string? GetVowelRoman(char @char) =>
        vowelRomans.TryGetValue(@char, out var roman) ? roman : null;

    public static string? GetJongSeongRoman(char @char) =>
        jongseongRomans.TryGetValue(@char, out var roman) ? roman : null;

    public static string? GetConsonantName(char @char) =>
        consonantNames.TryGetValue(@char, out var roman) ? roman : null;

    public static string? GetVowelName(char @char) => GetVowelRoman(@char);

    public static bool IsVowel(char letter) => vowelRomans.ContainsKey(letter);
    public static bool IsConsonant(char letter) => consonantNames.ContainsKey(letter);

    // Todo 옛한글(Jamo block Extended A, B) 지원 
    public static SyllableType Create(char @char) => @char.GetHangeul() switch 
    {
        Hangeul.Syllable => Syllable.Create(SyllableToJamos(@char)),
        Hangeul.JamoBasic => Syllable.Create(BasicToCompatible(@char)),
        _ => Syllable.Create(@char),        
    };

    static char[] SyllableToJamos(char syllable)
    {
        char[] chos = ['ㄱ', 'ㄲ', 'ㄴ', 'ㄷ', 'ㄸ', 'ㄹ', 'ㅁ', 'ㅂ', 'ㅃ', 'ㅅ', 'ㅆ', 'ㅇ', 'ㅈ', 'ㅉ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ'];
        char[] vowels = ['ㅏ', 'ㅐ', 'ㅑ', 'ㅒ', 'ㅓ', 'ㅔ', 'ㅕ', 'ㅖ', 'ㅗ', 'ㅘ', 'ㅙ', 'ㅚ', 'ㅛ', 'ㅜ', 'ㅝ', 'ㅞ', 'ㅟ', 'ㅠ', 'ㅡ', 'ㅢ', 'ㅣ'];
        char[] jongs = ['\0', 'ㄱ', 'ㄲ', 'ㄳ', 'ㄴ', 'ㄵ', 'ㄶ', 'ㄷ', 'ㄹ', 'ㄺ', 'ㄻ', 'ㄼ', 'ㄽ', 'ㄾ', 'ㄿ', 'ㅀ', 'ㅁ', 'ㅂ', 'ㅄ', 'ㅅ', 'ㅆ', 'ㅇ', 'ㅈ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ'];

        int code = syllable - 0xAC00;
        int cho = code / (21 * 28);
        int jung = code % (21 * 28) / 28;
        int jong = code % (21 * 28) % 28;

        return jong == 0 ? [chos[cho], vowels[jung]]
            : [chos[cho], vowels[jung], jongs[jong]];
    }
}