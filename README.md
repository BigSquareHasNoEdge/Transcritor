
> This is an experimental project to utilize funtional programming features of C# language.
Not all functionallities are guaranteed to work correctly.

# Transcriptor
This project provides basic types and functions that help to phonetically transribe one language into another, along with an abstraction to be serviced by the client code.

# Transcriptor.HangeulRomonization

This provides an actual implementatation to transcribe Hangeuls, a.k.a. Korean Alphabets, into Roman characters.

In addition to the service implementation, it also provides string extension methods.

# How-to

### string Extention
```
// program.cs
using Transcriptor.HangeulRomonization;

var text = "한글    slug 만들기 ㅈㅗㄹa 어려워 man!";
Console.WriteLine(text);

Console.WriteLine(text.RomanizeHangeuls('-'));
Console.WriteLine(text.RomanizeHangeuls());
```

Results:
```
한글    slug 만들기 ㅈㅗㄹa 어려워 man!
han-geul-slug-man-deul-gi-jieut-o-rieul-a-eo-ryeo-wo-man!
hangeul    slug mandeulgi jieutorieula eoryeowo man!
```