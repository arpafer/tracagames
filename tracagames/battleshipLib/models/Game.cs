namespace battleshipLib.models
{
    public class Game
    {
        private Turn turn;
        private Board board;
        private Rules rules;

        public Game()
        {
            this.board = new Board();
            this.rules = new Rules();
            this.turn = new Turn(board);
        }
    }
}