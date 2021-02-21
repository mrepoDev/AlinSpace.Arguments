using System;
using Xunit;

namespace AlinSpace.FluentArguments.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ArgumentWrapper{TArgument}"/>.
    /// </summary>
    public partial class ArgumentWrapperExtensions
    {
        #region GetOrDefault

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
        public void GetOrDefault4()
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
        public void GetOrDefault5()
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
        public void GetOrDefault6()
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

        #endregion

        #region NotNull

        [Fact]
        public void NotNull()
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
        public void NotNull2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotNull();
            }

            Assert.Throws<ArgumentNullException>(() => TestMethod(null));
        }

        #endregion

        #region NotDefault

        [Fact]
        public void NotDefault()
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
        public void NotDefault2()
        {
            void TestMethod(int uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsNotDefault();
            }

            Assert.Throws<ArgumentException>(() => TestMethod(0));
        }

        #endregion

        #region IsFunc*

        #region IsFuncTrue

        [Fact]
        public void IsFuncTrue()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsFuncTrue(() => true);

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void IsFuncTrue2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsFuncTrue(() => false);
            }

            Assert.Throws<ArgumentException>(() => TestMethod("Test"));
        }

        #endregion

        #region IsFuncFalse

        [Fact]
        public void IsFuncFalse()
        {
            void TestMethod(string uncheckedArgument)
            {
                string checkedArgument = Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsFuncFalse(() => false);

                Assert.Equal("Test", checkedArgument);
            }

            TestMethod("Test");
        }

        [Fact]
        public void IsFuncFalse2()
        {
            void TestMethod(string uncheckedArgument)
            {
                Argument
                    .Wrap(uncheckedArgument, nameof(uncheckedArgument))
                    .IsFuncFalse(() => true);
            }

            Assert.Throws<ArgumentException>(() => TestMethod("Test"));
        }

        #endregion

        #endregion
    }
}
