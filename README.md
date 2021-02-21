<img src="https://github.com/onixion/FluentArguments/blob/main/Assets/Icon.png" width="200" height="200">

# FluentArguments
[![NuGet version (FluentArguments)](https://img.shields.io/nuget/v/AlinSpace.FluentArguments.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

A simple fluent library for function argument validation.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

# Examples

 ```csharp
// Check if the argument is null.
string checkedArgument = Argument
    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
    .NotNull();
```
