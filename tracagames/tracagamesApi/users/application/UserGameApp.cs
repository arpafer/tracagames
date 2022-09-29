using tracagamesApi.users.models;

namespace tracagamesApi.users.application
{
    public class UserGameApp
    {
        public List<dtos.Game> loadGames()
        {
            Tracagames tracagames = new Tracagames();
            tracagames.loadGames();
            return tracagames.cloneToDto();            
        }
    }
}
