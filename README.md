<img src="https://github.com/onixion/FluentArguments/blob/main/Assets/Icon.png" width="200" height="200">

# FluentArguments
[![NuGet version (FluentArguments)](https://img.shields.io/nuget/v/AlinSpace.FluentArguments.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

A simple fluent library for function argument validation.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

# Examples

 ```csharp
// Check if the argument is not null.
string checkedArgument1 = Argument
    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
    .IsNotNull();
    
// Check if the argument is not null and not empty.
string checkedArgument2 = Argument
    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
    .IsNotNull()
    .IsNotEmpty();
    
// Check if the argument is not null and has the exact length of 5 characters.
string checkedArgument3 = Argument
    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
    .IsNotNull()
    .IsFuncTrue(s => s.Length == 5);
```
