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
Argument
    .Wrap(argument, nameof(argument))
    .IsNotNull()
    .Is(s => s.Length >= 5, message: $"String can't be shorter than 5 characters.");
```

It is much more compact, easier to read and understand, flexible, and more consistent. 
Custom validation constraints can be added in form of extension methods or as a predicate functions. 
It is also possible to retrieve the checked argument after validation, like this:

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

## Custom validation rules

There are two ways to add custom validation rules. 

### Predicate Function

The trivial way is to simply pass a predicate function:

```csharp
bool MyPredicateFunction<TArgument>(TArgument argument)
{
    // Validate the given argument, return true on successful validation; false otherwise.
}

Argument
    .Wrap(uncheckedArgument)
    .Is(MyPredicateFunction);
```

### Extension method

If you have an argument validation rule that you would like to define in a class and use throughout your codebase,
than custom extension methods might be a better way of doing it:

```csharp
public static class MyArgumentWrapperExtensions
{
    public static ArgumentWrapper<TArgument> MyCustomRule(ArgumentWrapper<TArgument> argument)
    {
        // Validate the given argument here and throw an exception when the rule is violated.
	
	return argument;
    }
}

Argument
    .Wrap(uncheckedArgument)
    .MyArgumentWrapperExtensions();
```
