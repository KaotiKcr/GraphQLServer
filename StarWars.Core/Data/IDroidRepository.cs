using StarWars.Core.Models;
using System.Threading.Tasks;

namespace StarWars.Core.Data
{
    public interface IDroidRepository : IBaseRepository<Droid, int> { }
}