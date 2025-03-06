
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

# Remarks

## Benefits

The same problem can be solved by the traditional OOP style especially with the interface and abstract class, if you use C#.

FP style has benefits over OOP one as belows:

### 1. Simplicity

In OOP, you can represent a behavior of an object like this;

```
interface IPhraseTransformable
{
   Phrase Transform(Phrase phrase);
}
```

Then, you will need to write concrete classes implementing it, with boiler-plate codes:

```
class ConsonantAssimillation : IPhraseTransformable {  public Phrase Transform( ) { // ... } }
class NienRieulEpenthetic : IPhraseTransformable {  public Phrase Transform( ) { // ... } }
class Palatalization : IPhraseTransformable {  public Phrase Transform( ) { // ... } }
class Aspiration : IPhraseTransformable {  public Phrase Transform( ) { // ... } }
class EmptifyChosungYieung : IPhraseTransformable {  public Phrase Transform( ) { // ... } }  
```

In FP, this can be done more shortly.

```
delegate PhraseType TransformPhrase(PhraseType phrase);
```

and its implemetations:

```
TransformPhrase ConsonantAssimillation => phrase => // ...
TransformPhrase NienRieulEpenthetic => phrase => // ...
TransformPhrase Palatalization => phrase => // ...
TransformPhrase Aspiration => phrase => // ...
TransformPhrase EmptifyChosungYieung => phrase => // ...
```

In C#, delegate is a first-class member so you can store it in a variable.
Further more, there is no limitation to inject it:

```
builder.Services.AddTransient<TransformPhrase>(_ => phrase => // ...);
```

### 2. Extendability

It is quite common to add more behaviors to an object as the project grows.
When it comes to OOP, you can do it like this:

```
interface IPhraseTransformable
{
   Phrase Transform(Phrase phrase);
   Task<Phrase> TransformAsync(Phrase phase);
}
```

However, what if the old interface was contained in the assembly that we cannot modify or the original author wouldn't modify the interface for your favor?
You may have to decide to write your own version and rewrite all of old codes that was depending on the old interface.

In FP, this kind of situation is not problematic.
You can always introduce new behaviors in any place you want:

```
// some place in your project
delegate Task<PhraseType> TransformPhraseAsync(PhraseType phrase);
```

and its implementations:

```
// some place in your project
static class AsyncTransformers
{
    public static TransformPhraseAsync NounAsIs => async phrase => // ...
}
```


### Modularity

An object has behaviors and states to support them.
It is quite common that a state is shared among multple behaviors.

In OOP, the securty of the shared state can be compromised easily when you implement an interface.

```
static class SomeName
{
   internal static object Shared {get; set;}
}
```

In FP, a shared state can be placed exactly where it is consumed:

```
static class SharingBehaviors
{
   private static object shared:
   public ADelegate One => param => // ...
   public ADelegate Two => param => // ...
}
```

This difference comes from that a FP class is a module but a OOP class is a member of a module, which is an assembly in C#.
