using tracagamesApi.users.models;

namespace tracagamesApi.users.infraestructure.repositoriesMock
{
    public class UserGameRepo
    {        

        internal UserGameRepo()
        {
     
        }

        internal List<Game> loadAll()
        {
            List<Game> games = new List<Game>();
            games.Add(new Game("Conecta4", "Intenta hacer una linea de 4 fichas horizontal, vertical o diagonal"));
            return games;
        }
    }
}
