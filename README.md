# ![Icon](Assets/IconSmall.png)
# FluentArguments
[![NuGet version (FluentArguments)](https://img.shields.io/nuget/v/AlinSpace.FluentArguments.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

A simple fluent library for function argument validation.

# Examples

 ```csharp
// Check if the argument is null.
string checkedArgument = Argument
    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
    .NotNull();
```
