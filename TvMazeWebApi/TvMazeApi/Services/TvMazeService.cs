using TvMazeApi.Interfaces.Repositories;
using TvMazeApi.Interfaces.Services;
using TvMazeApi.ShowsApi.Models;
using TvMazeApi.TvMazeData.Entities;

namespace TvMazeApi.Services
{
    public class TvMazeService(IHttpClientFactory clientFactory, ITvMazeRepository tvMazeRepository) : ITvMazeService
    {
        private readonly ITvMazeRepository _tvMazeRepository = tvMazeRepository;
        private readonly IHttpClientFactory _clientFactory = clientFactory;

        #region Public methods

        /*
         * Get Shows stored at the database
         */
        public IEnumerable<Show> GetStoredShows()
        {
            List<Show> shows = new List<Show>();

            try {
                shows = _tvMazeRepository.GetShows().ToList();
            }
            catch (Exception) { }

            return shows;
        }

        /*
         * Retrieve Shows and detailed info from TvMazeApì and store them in our database
         */
        public async Task<bool> StoreShowsMainInfo()
        {
            var apiResultCall = await GetApiShows();

            if(apiResultCall == null || !apiResultCall.Any()) { return false; }

            bool inserted = false;

            try
            {
                foreach (var show in apiResultCall)
                {
                    var existingShow = await _tvMazeRepository.GetById(show.id);
                    if (existingShow != null) { continue; }

                    inserted = await _tvMazeRepository.InsertShow(show);
                }

                return inserted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        /*
         * Retrieve shows from external Api
         */
        private async Task<List<TvMazeShow>> GetApiShows() 
        {
            var client = _clientFactory.CreateClient("tvMazeClient");

            var content = await client.GetFromJsonAsync<IEnumerable<TvMazeShow>>("shows");

            return content.ToList();
        }

        #endregion
    }
}
