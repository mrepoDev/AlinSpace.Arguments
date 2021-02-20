namespace AlinSpace.FluentArguments
{
    /// <summary>
    /// Argument.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// Wrap the argument.
        /// </summary>
        /// <typeparam name="TArgument">Type of argument.</typeparam>
        /// <param name="value">Value of the argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>Argument wrapper.</returns>
        public static ArgumentWrapper<TArgument> Wrap<TArgument>(TArgument value, string argumentName = null)
        {
            return new ArgumentWrapper<TArgument>(argumentName, value);
        }
    }
}
