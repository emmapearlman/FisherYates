using NUnit.Framework;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;

namespace FisherYates.Algorithm.Tests
{
    [TestFixture()]
    public class ShufflerTests
    {
        private ShufflerService? _shuffler;
        private readonly Mock<ILogger> _logger = new Mock<ILogger>();
      

        [TestCase("A-B-C-D")]
        [TestCase("F-G-I-Z-k-a-W-V")]
        public void ValidateReturnsTrueWithValidInput(string inputValue)
        {
            //arrange
            var input = inputValue;
            var _shuffler =  new ShufflerService(_logger.Object);

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
            var _shuffler = new ShufflerService(_logger.Object);

            //act
            var actual = _shuffler!.Validate(input);

            //assert
            actual.Should().BeFalse();
        }

        [TestCase("A-B-C-D", "D-B-C-A")]
        public void ShuffleTest(string input, string output)
        {
            //arrange
            var _shuffler = new ShufflerService(_logger.Object);
            var expected = output.Split('-');

            //act
            var result = _shuffler!.Shuffle(input);

            //assert
            result.Should().NotBeNull();
            result.Should().Contain(expected[0]).And.Contain(expected[1]).And.Contain(expected[2]).And.Contain(expected[3]);
        }

        [Test]
        public void ConvertBackToStringReturnsAString()
        {
            //arrange
            var _shuffler = new ShufflerService(_logger.Object);
            var expected = "D-C-A-B";
            string[] input = new[] { "D", "C", "A", "B" };

            //act
            var result = _shuffler!.ConvertBackToString(input);

            //assert;
            result.Should().Be(expected);
        }
    }
}