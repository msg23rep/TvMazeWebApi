using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Controllers;
using TvMazeApi.Interfaces.Services;
using TvMazeApi.TvMazeData.Entities;

namespace TvMazeWebApi.Tests.Controllers
{
    public class ShowsControllerTests
    {
        private readonly ITvMazeService _tvMazeService;

        public ShowsControllerTests()
        {
            _tvMazeService = A.Fake<ITvMazeService>();
        }

        [Fact]
        public void ShowsController_GetShows_ReturnOk() 
        {
            // Arrange 
            var showsList = A.Fake<List<Show>>();

            var controller = new ShowsController(_tvMazeService);

            // Act
            var result = controller.GetShows();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<Show>>>));
        }

        [Fact]
        public void ShowsController_StoreShows_ReturnOk()
        {
            // Arrange 
            var controller = new ShowsController(_tvMazeService);
            A.CallTo(() => _tvMazeService.StoreShowsMainInfo()).Returns(true);

            // Act
            var result = controller.StoreShows();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }
    }
}
