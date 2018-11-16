using StarWars.Core.Data;
using StarWars.Core.Models;
using Microsoft.Extensions.Logging;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class DroidRepository : BaseRepository<Droid, int>, IDroidRepository
    {
        public DroidRepository() { }

        public DroidRepository(StarWarsContext db, ILogger<DroidRepository> logger)
            : base(db, logger)
        {
        }
    }
}