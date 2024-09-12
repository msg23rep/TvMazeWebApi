using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TvMazeApi.Interfaces.Repositories;
using TvMazeApi.ShowsApi.Models;
using TvMazeApi.TvMazeData;
using TvMazeApi.TvMazeData.Entities;

namespace TvMazeApi.Repositories
{
    public class TvMazeRepository(TvMazeContext context, IMapper mapper) : ITvMazeRepository
    {
        private readonly TvMazeContext _context = context;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<Show> GetShows()
        {
            var shows = new List<Show>();

            shows = _context.Shows.ToList();

            return shows;
        }

        public async Task<Show> GetById(int id)
        {
            var show = await _context.Shows.FirstOrDefaultAsync(s => s.Id == id);

            return show;
        }

        public async Task<bool> InsertShow(TvMazeShow show)
        {
            try 
            {
                var newEntityShow = _mapper.Map<Show>(show);

                _context.Shows.Add(newEntityShow);

                return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex) { return false; }
        }
    }
}
