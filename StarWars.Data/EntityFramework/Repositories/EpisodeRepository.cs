using StarWars.Core.Data;
using StarWars.Core.Models;
using Microsoft.Extensions.Logging;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class EpisodeRepository : BaseRepository<Episode, int>, IEpisodeRepository
    {
        public EpisodeRepository() { }

        public EpisodeRepository(StarWarsContext db, ILogger<DroidRepository> logger)
            : base(db, logger)
        {
        }
    }
}