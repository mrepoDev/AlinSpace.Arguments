using System;
using System.Collections.Generic;

namespace AlinSpace.FluentArguments
{
    /// <summary>
    /// Extensions for <see cref="IArgumentWrap{TArgument}"/>.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Check argument for not null.
        /// </summary>
        /// <param name="argument">Argument to check.</param>
        /// <param name="message">Message when argument is null.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> NotNull<TArgument>(this ArgumentWrapper<TArgument> argument, string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            if (argument.Value == null)
                throw new ArgumentNullException(argument.Name, message);

            return argument;
        }

        /// <summary>
        /// Check argument for not null.
        /// </summary>
        /// <param name="argument">Argument to check.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> NotDefault<TArgument>(this ArgumentWrapper<TArgument> argument, string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            if (EqualityComparer<TArgument>.Default.Equals(argument.Value, default))
                throw new ArgumentException(argument.Name, message);

            return argument;
        }

        /// <summary>
        /// Check argument for not null.
        /// </summary>
        /// <param name="argument">Argument to check.</param>
        /// <param name="defaultValue">Default value to return if argument has </param>
        /// <returns>Argument value.</returns>
        public static TArgument GetOrDefault<TArgument>(this ArgumentWrapper<TArgument> argument, TArgument defaultValue = default)
        {
            if (argument == null || EqualityComparer<TArgument>.Default.Equals(argument.Value, default))
                return defaultValue;

            return argument;
        }

        /// <summary>
        /// Check argument for not null.
        /// </summary>
        /// <param name="argument">Argument to check.</param>
        /// <param name="evaluateFunc">Evaluation function.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        /// <remarks>
        /// The evaluation function shall return true when the argument is valid; false otherwise.
        /// </remarks>
        public static ArgumentWrapper<TArgument> Evaluate<TArgument>(this ArgumentWrapper<TArgument> argument, Func<bool> evaluateFunc, string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            // If evaluation function is null, we assume it is an empty function; 
            // therefore argument shall be valid.
            var isArgumentValid = evaluateFunc?.Invoke() ?? true;

            if (!isArgumentValid)
                throw new ArgumentException(argument.Name, message);

            return argument;
        }
    }
}
