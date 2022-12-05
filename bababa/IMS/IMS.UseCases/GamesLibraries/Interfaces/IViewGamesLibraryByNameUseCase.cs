using IMS.CoreBusiness;

namespace IMS.UseCases.GamesLibraries.Interfaces
{
    public interface IViewGamesLibraryByNameUseCase
    {
        Task<IEnumerable<GamesLibrary>> ExecuteAsync(string name = "");
    }
}