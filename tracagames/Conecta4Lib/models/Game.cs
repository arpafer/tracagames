namespace Conecta4Lib.models
{
    internal class Game
    {
        private const int NUM_PLAYERS = 2;        
        private Turn turn;
        private Board board;

        internal Game()
        {            
            this.board = new Board();
            this.turn = new Turn(this.board);
        }

        internal void setInitialPlayerGameRandom()
        {            
            this.turn.setInitialPlayerRandom();
        }

        internal void setTurnPlayer(int index)
        {
            this.turn.setPlayer(index);
        }


        internal void move(int column)
        {
            this.turn.move(column);
        }

        internal bool isFullColumn(int column)
        {
            return this.board.isFullColumn(column);
        }

        internal bool hasWinner()
        {
            return this.turn.hasWinner();
        }

        internal Player getCurrentPlayer()
        {
            return this.turn.getCurrentPlayer();
        }
    }
}