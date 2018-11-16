using StarWars.Core.Models;
using System.Threading.Tasks;

namespace StarWars.Core.Data
{
    public interface IHumanRepository : IBaseRepository<Human, int> { }
}