namespace tracagamesApi.users.application
{
    public class UserGameApp
    {
        public List<dtos.Game> loadGames()
        {
            new 
            Tracagames tracagames = new Tracagames().loadGames();
            return tracagames.cloneGamesToDto();
        }
    }
}
