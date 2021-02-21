using System;

namespace AlinSpace.FluentArguments
{
    /// <summary>
    /// Extensions for <see cref="ArgumentWrapper{TArgument}"/> with type <see cref="string"/>.
    /// </summary>
    public static partial class ArgumentWrapperExtensions
    {
        /// <summary>
        /// Check string is not empty.
        /// </summary>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<string> IsNotEmpty(this ArgumentWrapper<string> argument, string message = null)
        {
            if (argument.Value.Length == 0)
            {
                throw new ArgumentException(
                    paramName: argument.Name,
                    message: message ?? $"Argument value shall not be an empty string.");
            }

            return argument;
        }

        /// <summary>
        /// Check argument is not null.
        /// </summary>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="defaultValue">Default value to return if argument is default.</param>
        /// <returns>Argument value.</returns>
        public static ArgumentWrapper<string> IsNotWhiteSpace(this ArgumentWrapper<string> argument, string message = null)
        {
            if (argument.Value.Trim().Length == 0)
            {
                throw new ArgumentException(
                    paramName: argument.Name,
                    message: message ?? $"Argument value shall not only consists of white-space characters.");
            }

            return argument;
        }
    }
}
