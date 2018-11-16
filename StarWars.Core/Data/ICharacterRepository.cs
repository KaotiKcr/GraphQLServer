using StarWars.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWars.Core.Data
{
    public interface ICharacterRepository : IBaseRepository<Character, int>
    {
        Task<ICollection<Character>> GetFriends(int id);
        Task<ICollection<Episode>> GetEpisodes(int id);
    }
}