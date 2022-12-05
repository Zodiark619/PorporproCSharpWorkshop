using IMS.CoreBusiness;
using IMS.UseCases.GamesLibraries.Interfaces;
using IMS.UseCases.PluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.GamesLibraries
{
    public class ViewGamesLibraryByNameUseCase : IViewGamesLibraryByNameUseCase
    {
        private readonly IGamesLibraryRepository gamesLibraryRepository;

        public ViewGamesLibraryByNameUseCase(IGamesLibraryRepository gamesLibraryRepository)
        {
            this.gamesLibraryRepository = gamesLibraryRepository;
        }

        public async Task<IEnumerable<GamesLibrary>> ExecuteAsync(string name = "")
        {
            return await gamesLibraryRepository.GetGamesLibraryByNameAsync(name);
        }
    }
}
