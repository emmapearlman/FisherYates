using FisherYates.Algorithm;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NUnit.Framework;
using System.Net;


namespace FisherYatesWebApp.Tests
{
    [TestFixture]
    public class ControllerTests
    {
        private Mock<IShufflerService> _mockShuffler;

        [SetUp]
        public void SetUp()
        {
            _mockShuffler = new Mock<IShufflerService>();
        }

        [Test]
        public void IndexTestReturns200WithValidInput()
        {
            //Arrange
            string input = "A-B-C-D";

            _mockShuffler.Setup(m => m.Validate(It.IsAny<string>())).Returns(true);
            _mockShuffler.Setup(m => m.Shuffle(It.IsAny<string>())).Returns(It.IsAny<string[]>());
            _mockShuffler.Setup(m => m.ConvertBackToString(It.IsAny<string[]>())).Returns(It.IsAny<string>());
            var _controller = new FisherYates(_mockShuffler.Object);

            //act
            var result = _controller.Index(input);

            //Assert
            ((IStatusCodeActionResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((ObjectResult)result).ContentTypes[0].Should().NotBeNull();
            ((ObjectResult)result).ContentTypes[0].Should().Be("text/plain; charset=utf-8");
        }

        [Test]
        public void IndexTestReturnsBadResultWithInalidInput()
        {
            //Arrange
            string input = "A-B-C-D";

            _mockShuffler.Setup(m => m.Validate(It.IsAny<string>())).Returns(false);
            var _controller = new FisherYates(_mockShuffler.Object);

            //act
            var result = _controller.Index(input);

            //Assert
            ((IStatusCodeActionResult)result).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
