using System;
using System.Collections.Generic;

namespace AlinSpace.FluentArguments
{
    /// <summary>
    /// Extensions for <see cref="ArgumentWrapper{TArgument}"/>.
    /// </summary>
    public static partial class ArgumentWrapperExtensions
    {
        /// <summary>
        /// Check argument is not null.
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
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            if (EqualityComparer<TArgument>.Default.Equals(argument.Value, default))
            {
                throw new ArgumentException(
                    paramName: argument.Name,
                    message: message ?? $"Argument value must not be default.");
            }

            return argument;
        }

        #region IsFunc* extension methods

        /// <summary>
        /// Check if the given function returns true for the argument value.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="func">Function.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> IsFuncTrue<TArgument>(
            this ArgumentWrapper<TArgument> argument, 
            Func<TArgument, bool> func, 
            string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            if (!func(argument.Value))
            {
                throw new ArgumentException(
                    paramName: argument.Name, 
                    message: message ?? $"Function shall return true for the argument value {argument.Value}.");
            }

            return argument;
        }

        /// <summary>
        /// Check if the given function returns true for the argument value.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="func">Function.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> IsFuncTrue<TArgument>(
            this ArgumentWrapper<TArgument> argument, 
            Func<bool> func, 
            string message = null) 
            => argument.IsFuncTrue(_ => func(), message);

        /// <summary>
        /// Check if the given function returns false for the argument value.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument wrapper.</param>
        /// <param name="func">Function.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> IsFuncFalse<TArgument>(
            this ArgumentWrapper<TArgument> argument, 
            Func<TArgument, bool> func, 
            string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            if (func(argument.Value))
                throw new ArgumentException(
                    paramName: argument.Name, 
                    message: message ?? $"Function shall return false for the argument value {argument.Value}.");

            return argument;
        }

        /// <summary>
        /// Check given function returns false for the argument.
        /// </summary>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        /// <param name="argument">Argument to check.</param>
        /// <param name="func">Function.</param>
        /// <param name="message">Message.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> IsFuncFalse<TArgument>(
            this ArgumentWrapper<TArgument> argument, 
            Func<bool> func, 
            string message = null)
            => argument.IsFuncFalse(_ => func(), message);

        #endregion

        //#region IComparable

        //#region BiggerThan

        ///// <summary>
        ///// Check argument is bigger than the given value.
        ///// </summary>
        ///// <typeparam name="TArgument">Type of the argument.</typeparam>
        ///// <param name="argument">Argument to check.</param>
        ///// <param name="value">Value to compare the argument to.</param>
        ///// <param name="message">Message.</param>
        ///// <returns>Argument wrapper.</returns>
        //public static ArgumentWrapper<IComparable<TArgument>> IsBiggerThan<TArgument>(
        //    this ArgumentWrapper<IComparable<TArgument>> argument, 
        //    TArgument value, 
        //    string message = null)
        //{
        //    if (argument.Value.CompareTo(value) > 0)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            paramName: argument.Name,
        //            actualValue: argument.Value,
        //            message: message ?? $"Argument value must not be bigger than {value}.");
        //    }

        //    return argument;
        //}

        ///// <summary>
        ///// Check argument is not bigger than the given value.
        ///// </summary>
        ///// <typeparam name="TArgument">Type of the argument.</typeparam>
        ///// <param name="argument">Argument to check.</param>
        ///// <param name="value">Value to compare the argument to.</param>
        ///// <param name="message">Message.</param>
        ///// <returns>Argument wrapper.</returns>
        //public static ArgumentWrapper<IComparable<TArgument>> IsNotBiggerThan<TArgument>(
        //    this ArgumentWrapper<IComparable<TArgument>> argument,
        //    TArgument value,
        //    string message = null)
        //{
        //    if (argument.Value.CompareTo(value) > 0)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            paramName: argument.Name,
        //            actualValue: argument.Value,
        //            message: message ?? $"Argument value must not be bigger than {value}.");
        //    }

        //    return argument;
        //}

        //#endregion

        //#region SmallerThan

        ///// <summary>
        ///// Check argument is smaller than the given value.
        ///// </summary>
        ///// <typeparam name="TArgument">Type of the argument.</typeparam>
        ///// <param name="argument">Argument to check.</param>
        ///// <param name="value">Value to compare the argument to.</param>
        ///// <param name="message">Message.</param>
        ///// <returns>Argument wrapper.</returns>
        //public static ArgumentWrapper<IComparable<TArgument>> IsSmallerThan<TArgument>(
        //    this ArgumentWrapper<IComparable<TArgument>> argument,
        //    TArgument value,
        //    string message = null)
        //{
        //    if (argument.Value.CompareTo(value) < 0)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            paramName: argument.Name,
        //            actualValue: argument.Value,
        //            message: message ?? $"Argument value must be smaller than {value}.");
        //    }

        //    return argument;
        //}

        ///// <summary>
        ///// Check argument is not smaller than the given value.
        ///// </summary>
        ///// <typeparam name="TArgument">Type of the argument.</typeparam>
        ///// <param name="argument">Argument to check.</param>
        ///// <param name="value">Value to compare the argument to.</param>
        ///// <param name="message">Message.</param>
        ///// <returns>Argument wrapper.</returns>
        //public static ArgumentWrapper<IComparable<TArgument>> IsNotSmallerThan<TArgument>(
        //    this ArgumentWrapper<IComparable<TArgument>> argument,
        //    TArgument value,
        //    string message = null)
        //{
        //    if (argument.Value.CompareTo(value) < 0)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            paramName: argument.Name,
        //            actualValue: argument.Value,
        //            message: message ?? $"Argument value must not be smaller than {value}.");
        //    }

        //    return argument;
        //}

        //#endregion

        //#region IsNegative

        ///// <summary>
        ///// Check argument is not negative.
        ///// </summary>
        ///// <typeparam name="TArgument">Type of the argument.</typeparam>
        ///// <param name="argument">Argument wrapper.</param>
        ///// <param name="message">Message.</param>
        ///// <returns>Argument wrapper.</returns>
        //public static ArgumentWrapper<IComparable<TArgument>> IsNegative<TArgument>(this ArgumentWrapper<IComparable<TArgument>> argument, string message = null)
        //{
        //    if (argument.Value.CompareTo(default) < 0)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            paramName: argument.Name,
        //            actualValue: argument.Value,
        //            message: message ?? $"Argument value must be negative.");
        //    }

        //    return argument;
        //}

        ///// <summary>
        ///// Check argument is not negative.
        ///// </summary>
        ///// <typeparam name="TArgument">Type of the argument.</typeparam>
        ///// <param name="argument">Argument to check.</param>
        ///// <param name="message">Message.</param>
        ///// <returns>Argument wrapper.</returns>
        //public static ArgumentWrapper<IComparable<TArgument>> IsNotNegative<TArgument>(this ArgumentWrapper<IComparable<TArgument>> argument, string message = null)
        //{
        //    if (argument.Value.CompareTo(default) < 0)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            paramName: argument.Name,
        //            actualValue: argument.Value,
        //            message: message ?? $"Argument value must not be negative.");
        //    }

        //    return argument;
        //}

        //#endregion

        //#region IsPositive

        ///// <summary>
        ///// Check argument is not positive.
        ///// </summary>
        ///// <typeparam name="TArgument">Type of the argument.</typeparam>
        ///// <param name="argument">Argument to check.</param>
        ///// <param name="message">Message.</param>
        ///// <returns>Argument wrapper.</returns>
        //public static ArgumentWrapper<IComparable<TArgument>> IsPositive<TArgument>(this ArgumentWrapper<IComparable<TArgument>> argument, string message = null)
        //{
        //    if (argument.Value.CompareTo(default) > 0)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            argument.Name,
        //            argument.Value,
        //            message ?? "Value must not be positive.");
        //    }

        //    return argument;
        //}

        ///// <summary>
        ///// Check argument is not positive.
        ///// </summary>
        ///// <typeparam name="TArgument">Type of the argument.</typeparam>
        ///// <param name="argument">Argument to check.</param>
        ///// <param name="message">Message.</param>
        ///// <returns>Argument wrapper.</returns>
        //public static ArgumentWrapper<IComparable<TArgument>> IsNotPositive<TArgument>(this ArgumentWrapper<IComparable<TArgument>> argument, string message = null)
        //{
        //    if (argument.Value.CompareTo(default) > 0)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            argument.Name,
        //            argument.Value,
        //            message ?? "Value must not be positive.");
        //    }

        //    return argument;
        //}

        //#endregion

        //#endregion
    }
}
