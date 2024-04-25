using NUnit.Framework;
using FluentAssertions;
using NUnit.Framework.Constraints;

namespace FisherYates.Algorithm.Tests
{
    [TestFixture()]
    public class ShufflerTests
    {
        private ShufflerService? _shuffler;
        [SetUp]
        public void Setuo()
        {
            _shuffler = new ShufflerService();
        }

        [TestCase("A-B-C-D")]
        [TestCase("F-G-I-Z-k-a-W-V")]
        public void ValidateReturnsTrueWithValidInput(string inputValue)
        {
            //arrange
            var input = inputValue;


            //act
            var actual = _shuffler!.Validate(input);

            //assert
            actual.Should().BeTrue();
        }


        [TestCase("A-1-C-3")]
        [TestCase("F-G-!-Z-k-1-W-9")]
        public void ValidateReturnsFalseWithInvalidInput(string inputValue)
        {
            //arrange
            var input = inputValue;


            //act
            var actual = _shuffler!.Validate(input);

            //assert
            actual.Should().BeFalse();
        }

        [TestCase("A-B-C-D", "D-B-A-C")]
        public void ShuffleTest(string input, string expected)
        {
            //act
            var result = _shuffler!.Shuffle(input);

            //assert
            result.Should().Equal(expected);
        }

        [Test]
        public void ConvertBackToStringReturnsAString()
        {
            //arrange
            var expected = "D-C-A-B";
            string[] input = new[] { "D", "C", "A", "B" };

            //act
            var result = _shuffler!.ConvertBackToString(input);

            //assert;
            result.Should().Be(expected);
        }
    }
}