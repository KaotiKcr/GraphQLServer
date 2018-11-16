using StarWars.Core.Models;
using System.Threading.Tasks;

namespace StarWars.Core.Data
{
    public interface IPlanetRepository : IBaseRepository<Planet, int> { }
}