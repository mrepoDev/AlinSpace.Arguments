using System;
using Xunit;

namespace AlinSpace.Arguments.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ArgumentWrapper{TArgument}"/> with type <see cref="string"/>.
    /// </summary>
    public partial class ArgumentWrapperExtensions
    {
        [Fact]
        public void IsNotEmpty_()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotEmpty();

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void IsNotEmpty_2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotEmpty();
            }

            Assert.Throws<ArgumentException>(() => TestMethod(""));
        }

        [Fact]
        public void IsNotWhiteSpace_1()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotWhiteSpace();

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void IsNotWhiteSpace_2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotWhiteSpace();
            }

            Assert.Throws<ArgumentException>(() => TestMethod("     "));
        }
    }
}
