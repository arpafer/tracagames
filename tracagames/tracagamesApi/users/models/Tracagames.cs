namespace tracagamesApi.users.models
{
    public class Tracagames
    {
        private List<Game> games;        

        public Tracagames()
        {
            this.games = new List<Game>();            
        }

        internal void loadGames()
        {
            this.games.Add(new Game("Conecta4", "Intenta lograr una linea de 4 fichas ya sea en horizontal, diagonal o vertical"));
        }       
            
        internal List<application.dtos.Game> cloneToDto()
        {
            List<application.dtos.Game> gamesDto = new List<application.dtos.Game>();
            foreach (Game game in this.games)
            {                
                gamesDto.Add(game.cloneToDto());
            }
            return gamesDto;
        }
    }
}
