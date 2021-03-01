<img src="https://github.com/onixion/FluentArguments/blob/main/Assets/Icon.jpg" width="200" height="200">

# FluentArguments
[![NuGet version (FluentArguments)](https://img.shields.io/nuget/v/AlinSpace.FluentArguments.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

A simple fluent library for function argument validation.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentArguments/)

## Why?

If you simply want to make sure that an argument can't be null,
then the code might look like this:

```csharp
// Check if the argument is not null.
if(argument == null)
    throw new ArgumentNullException(nameof(argument));
```

The problem with this is, that it does not scale well when the validation logic gets more complex.
Moreover, it is weird to have to write *equal null* for *not null*, which might introduce bugs, 
especially when argument validation checks are performed everywhere. Also, we want to have consistent
argument exception messages that add details to the failed argument validation.

Here is a more complex argument validation:

```csharp
// Check if the argument is not null.
if(argument == null)
    throw new ArgumentNullException(nameof(argument));
    
// And check if the string is at least 5 characters long.
if (argument.Length < 5)
    throw new ArgumentException(nameof(argument), $"String can't be shorter than 5 characters.");
```

With the **FluentArguments** library the code could be rewritten to this:

```csharp
string checkedArgument = Argument
    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
    .IsNotNull()
    .Is(s => s.Length >= 5);
```

## Examples

To validate an argument with this library, the argument first has to be wrapped by an argument wrapper.
On this wrapper validation methods can be performed.

The following code snippet checks the string argument for not-null:

```csharp
// Check if the argument is not null.
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

