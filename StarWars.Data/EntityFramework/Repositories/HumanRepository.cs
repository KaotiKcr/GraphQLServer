using StarWars.Core.Data;
using System.Threading.Tasks;
using StarWars.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class HumanRepository : BaseRepository<Human, int>, IHumanRepository
    {
        public HumanRepository() { }

        public HumanRepository(StarWarsContext db, ILogger<DroidRepository> logger)
            : base(db, logger)
        {
        }
    }
}