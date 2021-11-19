using System;
using Xunit;

namespace AlinSpace.Arguments.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ArgumentWrapper{TArgument}"/>.
    /// </summary>
    public partial class ArgumentWrapperExtensions
    {
        [Fact]
        public void GetOrDefault_1()
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
        public void GetOrDefault_2()
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
        public void GetOrDefault_3()
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
        public void GetOrDefault_4()
        {
            void TestMethod(int uncheckedArgument)
            {
                int checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .GetOrDefault();

                Assert.Equal(0, checkedArgument);
            }

            TestMethod(0);
        }

        [Fact]
        public void GetOrDefault_5()
        {
            void TestMethod(int uncheckedArgument)
            {
                int checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .GetOrDefault(defaultValue: 5);

                Assert.Equal(5, checkedArgument);
            }

            TestMethod(0);
        }

        [Fact]
        public void GetOrDefault_6()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .GetOrDefault(defaultValue: "");

                Assert.Equal("", checkedArgument);
            }

            TestMethod(null);
        }

        [Fact]
        public void NotNull_1()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotNull();

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void NotNull_2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotNull();
            }

            Assert.Throws<ArgumentNullException>(() => TestMethod(null));
        }

        [Fact]
        public void NotDefault_1()
        {
            void TestMethod(int uncheckedArgument)
            {
                int checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotDefault();

                Assert.Equal(5, checkedArgument);
            }

            TestMethod(5);
        }

        [Fact]
        public void NotDefault_2()
        {
            void TestMethod(int uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotDefault();
            }

            Assert.Throws<ArgumentException>(() => TestMethod(0));
        }

        [Fact]
        public void Is_1()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .Is(_ => true);

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void Is_2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .Is(_ => false);
            }

            Assert.Throws<ArgumentException>(() => TestMethod("Test"));
        }

        [Fact]
        public void IsNot_1()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNot(_ => false);

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void IsNot_2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNot(_ => true);
            }

            Assert.Throws<ArgumentException>(() => TestMethod("Test"));
        }
    }
}
