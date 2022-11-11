using tracagamesApi.users.models;
using tracagamesApi.users.infraestructure.repositoriesMock;

namespace tracagamesApi.users.application
{
    public class UserGameApp
    {
        public List<dtos.Game> loadGames()
        {
           GamesCatalogueRepo catalogue = new GamesCatalogueRepo();
           catalogue.loadAll();
           return catalogue.cloneToDto();            
        }
    }
}
