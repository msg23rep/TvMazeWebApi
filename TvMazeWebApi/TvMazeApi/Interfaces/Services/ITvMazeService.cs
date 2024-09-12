using TvMazeApi.TvMazeData.Entities;

namespace TvMazeApi.Interfaces.Services
{
    public interface ITvMazeService
    {
        Task<bool> StoreShowsMainInfo();
        IEnumerable<Show> GetStoredShows();
    }
}
