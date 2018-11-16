using StarWars.Core.Data;
using System.Threading.Tasks;
using StarWars.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class PlanetRepository : BaseRepository<Planet, int>, IPlanetRepository
    {
        public PlanetRepository() { }

        public PlanetRepository(StarWarsContext db, ILogger<DroidRepository> logger)
            : base(db, logger)
        {
        }
    }
}