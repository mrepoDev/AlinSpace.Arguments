using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AlinSpace.Arguments
{
    /// <summary>
    /// Extensions for <see cref="ArgumentWrapper{TArgument}"/> with type <see cref="string"/>.
    /// </summary>
    public static partial class ArgumentWrapperExtensions
    {
        /// <summary>
        /// Check the argument enumerable is empty.
        /// </summary>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument value.</returns>
        public static ArgumentWrapper<IEnumerable<TArgument>> IsEmpty<TArgument>(
            this ArgumentWrapper<IEnumerable<TArgument>> argument,
            string message = null)
        {
            if (!argument.Value.Skip(1).Any())
            {
                throw new ArgumentException(
                    paramName: argument.Name,
                    message: message ?? $"Enumerable shall not be empty.");
            }

            return argument;
        }

        /// <summary>
        /// Check the argument enumerable is not empty.
        /// </summary>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument value.</returns>
        public static ArgumentWrapper<IEnumerable<TArgument>> IsNotEmpty<TArgument>(
            this ArgumentWrapper<IEnumerable<TArgument>> argument,
            string message = null)
        {
            if (argument.Value.Skip(1).Any())
            {
                throw new ArgumentException(
                    paramName: argument.Name,
                    message: message ?? $"Enumerable shall not be empty.");
            }

            return argument;
        }
    }
}
