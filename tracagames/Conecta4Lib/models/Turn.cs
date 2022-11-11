namespace Conecta4Lib.models
{
    internal class Turn
    {
        private const int NUM_PLAYERS = 2;
        private List<Player> players;
        private int playerIndex;

        public Turn(Board board)
        {
            this.players = new List<Player>();
            this.playerIndex = 0;
            for (int i = 0; i < NUM_PLAYERS; i++)
            {
                this.players.Add(new Player(board, (Color)i, ""));
                this.players[i].distributeCards();                
            }
        }
                      
        internal void setInitialPlayerRandom()
        {
            this.playerIndex = new Random().Next(0, NUM_PLAYERS);
        }

        internal void setPlayer(int index)
        {
            this.playerIndex = index;
        }

        internal void change()
        {

        }

        internal void move(int column)
        {
            this.players[this.playerIndex].move(column);
        }

        internal bool hasWinner()
        {
            return this.players[this.playerIndex].isWinner();
        }
    }
}