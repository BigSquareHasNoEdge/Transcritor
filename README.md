
> This is an experimental project to case-study funtional programming features of C# language.  
Not all functionallities are guaranteed to work correctly.

# Transcriptor
This project provides basic types(record) and functions(delegate) to solve a domain problem of transcribing one launguage into another.

# Transcriptor.HangeulRomonization

This project adds implementations for the behaviors of the types to provide capability to transcribe Hangeuls, a.k.a. Korean Alphabets, into Roman characters.  

All the added functions are merged into string exention methods for the client code:  

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
