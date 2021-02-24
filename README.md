<img src="https://github.com/onixion/FluentArguments/blob/main/Assets/Icon.png" width="200" height="200">

# FluentArguments
[![NuGet version (FluentArguments)](https://img.shields.io/nuget/v/AlinSpace.FluentArguments.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

A simple fluent library for function argument validation.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

# Examples

To validate an argument, it has to be wrapped by an argument wrapper.
On this wrapper validation methods can be performed.

The following code snippet checks the string argument for not-null:

```csharp
// Check if the argument is null.
string checkedArgument = Argument
    .Wrap(uncheckedArgument)
    .IsNotNull();
```

The fluent design allows the validation methods to be chained together easily.
	
```csharp
// Check if the argument is not null, contains at least one 'a' character
// and is at least 5 characters long.
string checkedArgument = Argument
    .Wrap(uncheckedArgument)
    .IsNotNull()
	.Is(s => s.Contains("a"))
	.IsNot(s => s.Length >= 5);
```

