namespace AlinSpace.Arguments
{
    /// <summary>
    /// Argument wrapper.
    /// </summary>
    /// <typeparam name="TArgument">Type of the wrapped argument.</typeparam>
    public class ArgumentWrapper<TArgument>
    {
        /// <summary>
        /// Name of the argument.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Value of the argument.
        /// </summary>
        public TArgument Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the argument.</param>
        /// <param name="value">Value of the argument.</param>
        public ArgumentWrapper(string name = null, TArgument value = default)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Implicit cast.
        /// </summary>
        /// <param name="argument">Argument wrap.</param>
        public static implicit operator TArgument(ArgumentWrapper<TArgument> argument)
        {
            return argument.Value ?? default;
        }
    }
}
