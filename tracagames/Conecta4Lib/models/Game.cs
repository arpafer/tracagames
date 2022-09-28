namespace Conecta4Lib.models
{
    public class Game
    {
        private const int NUM_PLAYERS = 2;        
        private Turn turn;
        private Board board;              

        public Game()
        {            
            this.board = new Board();
            this.turn = new Turn(this.board);
        }

        public void setInitialPlayerGameRandom()
        {            
            this.turn.setInitialPlayerRandom();
        }

        public void setTurnPlayer(int index)
        {
            this.turn.setPlayer(index);
        }
        

        public void move(int column)
        {
            this.turn.move(column);
        }

        public bool isFullColumn(int column)
        {
            return this.board.isFullColumn(column);
        }

        public bool hasWinner()
        {
            return this.turn.hasWinner();
        }
    }
}