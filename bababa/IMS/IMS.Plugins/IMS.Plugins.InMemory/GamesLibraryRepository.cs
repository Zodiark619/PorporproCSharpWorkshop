using IMS.CoreBusiness;
using IMS.UseCases.PluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class GamesLibraryRepository:IGamesLibraryRepository
    {
        private List<GamesLibrary> _games;
        public GamesLibraryRepository()
        {
_games= new List<GamesLibrary>()
{
    new GamesLibrary()
    {
        Name="Dynasty Warrior 9 Empire",
        Price=599000,
        Genre="Hack and Slash, Strategy"
    },
    new GamesLibrary()
    {
        Name="World War Z",
        Price=599000,
        Genre="Survival Horror, Third Person Shooter"
    },
    new GamesLibrary()
    {
        Name="Mortal Kombat 11",
        Price=599000,
        Genre="Fighting"
    },
    new GamesLibrary()
    {
        Name="Persona 5 Royal",
        Price=799000,
        Genre="JRPG"
    },
    new GamesLibrary()
    {
        Name="DioField Chronicle",
        Price=599000,
        Genre="JRPG, Strategy"
    },
    new GamesLibrary()
    {
        Name="Tactics Ogre Reborn",
        Price=599000,
        Genre="JRPG, Turn-Based Strategy"
    },
};
        }

        public async Task<IEnumerable<GamesLibrary>> GetGamesLibraryByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_games);
            return _games.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)); 
        }
    }
}
