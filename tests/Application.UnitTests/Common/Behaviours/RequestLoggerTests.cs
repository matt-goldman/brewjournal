using brewjournal.Application.Common.Behaviours;
using brewjournal.Application.Common.Interfaces;
using brewjournal.Application.Ingredients.Commands.AddIngredient;
using brewjournal.Application.Ingredients.Queries.Common;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.UnitTests.Common.Behaviours
{
    public class RequestLoggerTests
    {
        private readonly Mock<ILogger<AddIngredientCommand>> _logger;
        private readonly Mock<ICurrentUserService> _currentUserService;
        private readonly Mock<IIdentityService> _identityService;


        public RequestLoggerTests()
        {
            _logger = new Mock<ILogger<AddIngredientCommand>>();

            _currentUserService = new Mock<ICurrentUserService>();

            _identityService = new Mock<IIdentityService>();
        }

        [Test]
        public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        {
            _currentUserService.Setup(x => x.UserId).Returns("Administrator");

            var requestLogger = new RequestLogger<AddIngredientCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

            await requestLogger.Process(new AddIngredientCommand { Ingredient = new IngredientDto { Name = "Grain" } }, new CancellationToken());

            _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        {
            var requestLogger = new RequestLogger<AddIngredientCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

            await requestLogger.Process(new AddIngredientCommand { Ingredient = new IngredientDto { Name = "Grain" }  }, new CancellationToken());

            _identityService.Verify(i => i.GetUserNameAsync(null), Times.Never);
        }
    }
}
