using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AlinSpace.Arguments
{
    /// <summary>
    /// Extensions for <see cref="ArgumentWrapper{TArgument}"/>.
    /// </summary>
    public static partial class ArgumentWrapperExtensions
    {
        /// <summary>
        /// Get the argument value or default value.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="defaultValue">Default value to return if argument is default.</param>
        /// <returns>Argument value.</returns>
        public static TArgument GetOrDefault<TArgument>(
            this ArgumentWrapper<TArgument> argument,
            TArgument defaultValue = default)
        {
            if (argument == null || EqualityComparer<TArgument>.Default.Equals(argument.Value, default))
                return defaultValue;

            return argument;
        }

        /// <summary>
        /// Check argument is not null.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> IsNotNull<TArgument>(
            this ArgumentWrapper<TArgument> argument,
            string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            if (argument.Value == null)
            {
                throw new ArgumentNullException(
                    paramName: argument.Name,
                    message: message ?? $"Argument value shall not be null.");
            }

            return argument;
        }

        /// <summary>
        /// Check argument is not default.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> IsNotDefault<TArgument>(
            this ArgumentWrapper<TArgument> argument,
            string message = null)
        {
            if (EqualityComparer<TArgument>.Default.Equals(argument.Value, default))
            {
                throw new ArgumentException(
                    paramName: argument.Name,
                    message: message ?? $"Argument value shall not be default.");
            }

            return argument;
        }

        /// <summary>
        /// Check if the given predicate returns true for the argument value.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="predicate">Predicate.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> Is<TArgument>(
            this ArgumentWrapper<TArgument> argument, 
            Predicate<TArgument> predicate, 
            string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (!predicate(argument.Value))
            {
                throw new ArgumentException(
                    paramName: argument.Name, 
                    message: message ?? $"Predicate shall return true for the value {argument.Value}.");
            }

            return argument;
        }

        /// <summary>
        /// Check if the given predicate returns false for the argument value.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="predicate">Predicate.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> IsNot<TArgument>(
            this ArgumentWrapper<TArgument> argument,
            Predicate<TArgument> predicate,
            string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (predicate(argument.Value))
            {
                throw new ArgumentException(
                    paramName: argument.Name,
                    message: message ?? $"Predicate shall return false for the argument value {argument.Value}.");
            }

            return argument;
        }
    }
}
