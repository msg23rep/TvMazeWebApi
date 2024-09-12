using TvMazeApi.TvMazeData.Entities;
using Microsoft.EntityFrameworkCore;

namespace TvMazeApi.TvMazeData
{
    public class TvMazeContext : DbContext
    {
        public TvMazeContext(DbContextOptions<TvMazeContext> options) : base(options)
        {
            
        }

        public DbSet<Show> Shows { get; set; }
    }
}
