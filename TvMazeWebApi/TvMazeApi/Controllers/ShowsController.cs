using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Attributes;
using TvMazeApi.Interfaces.Services;
using TvMazeApi.TvMazeData.Entities;

namespace TvMazeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController(ITvMazeService tvMazeService) : ControllerBase
    {
        private readonly ITvMazeService _tvMazeService = tvMazeService;

        [HttpGet]
        [ApiKey]
        public async Task<ActionResult<List<Show>>> GetShows() 
        {
            var shows = new List<Show>();

            shows = _tvMazeService.GetStoredShows().ToList();
            
            return Ok(shows);
        }

        [HttpGet]
        [Route("/StoreShows")]
        public async Task<ActionResult> StoreShows() 
        {
            try
            {
                await _tvMazeService.StoreShowsMainInfo();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
