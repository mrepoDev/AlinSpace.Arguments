using System;
using Xunit;

namespace AlinSpace.FluentArguments.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Argument"/>.
    /// </summary>
    public class ArgumentTests
    {
        [Fact]
        public void NotNull()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .NotNull();

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void NotNull2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .NotNull();
            }

            Assert.Throws<ArgumentNullException>(() => TestMethod(null));
        }


        [Fact]
        public void NotDefault()
        {
            void TestMethod(int uncheckedArgument)
            {
                int checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .NotDefault();

                Assert.Equal(5, checkedArgument);
            }

            TestMethod(5);
        }

        [Fact]
        public void NotDefault2()
        {
            void TestMethod(int uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .NotDefault();
            }

            Assert.Throws<ArgumentException>(() => TestMethod(0));
        }

        [Fact]
        public void GetOrDefault()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .GetOrDefault();

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void GetOrDefault2()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .GetOrDefault();

                Assert.Null(checkedArgument);
            }

            TestMethod(null);
        }

        [Fact]
        public void GetOrDefault3()
        {
            void TestMethod(int uncheckedArgument)
            {
                int checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .GetOrDefault();

                Assert.Equal(5, checkedArgument);
            }

            TestMethod(5);
        }

        [Fact]
        public void Evaluate()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .Evaluate(() => true);

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void Evaluate2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .Evaluate(() => false);
            }

            Assert.Throws<ArgumentException>(() => TestMethod("Test"));
        }
    }
}
