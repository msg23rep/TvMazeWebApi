using TvMazeApi.ShowsApi.Models;
using TvMazeApi.TvMazeData.Entities;

namespace TvMazeApi.Interfaces.Repositories
{
    public interface ITvMazeRepository
    {
        IEnumerable<Show> GetShows();
        Task<Show> GetById(int id);
        Task<bool> InsertShow(TvMazeShow show);
    }
}
