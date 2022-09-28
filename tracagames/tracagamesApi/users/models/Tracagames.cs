namespace tracagamesApi.users.models
{
    public class Tracagames
    {
        private List<Game> games;
        private List<User> users;

        public Tracagames()
        {
            this.games = new List<Game>();
            this.users = new List<User>();
        }

        internal void addGame(Game game)
        {
            this.games.Add(game);
        }
       
        internal void addPlayer(Game game, User user)
        {
            
        }

        internal void loadUser(string userName)
        {
            
        }
    }
}
