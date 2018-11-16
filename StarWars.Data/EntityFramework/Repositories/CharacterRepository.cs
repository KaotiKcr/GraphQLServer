using StarWars.Core.Data;
using StarWars.Core.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class CharacterRepository : BaseRepository<Character, int>, ICharacterRepository
    {
        public CharacterRepository() { }

        public CharacterRepository(StarWarsContext db, ILogger<DroidRepository> logger)
            : base(db, logger)
        {
            
        }

        public async Task<ICollection<Character>> GetFriends(int id)
        {
            // TODO: find better way to do this?
            var character = await Get(id, "CharacterFriends.Friend");
            return character.CharacterFriends.Select(c => c.Friend).ToList();
        }

        public async Task<ICollection<Episode>> GetEpisodes(int id)
        {
            // TODO: find better way to do this?
            var character = await Get(id, "CharacterEpisodes.Episode");
            return character.CharacterEpisodes.Select(c => c.Episode).ToList();
        }
    }
}