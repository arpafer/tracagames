namespace Conecta4Lib.models
{
    internal class Player
    {
        private string nick;
        private Board board;
        private List<Card> cards;
        private Color _color;

        internal Color color { get { return _color; } }

        internal Player(Board board, Color color, string nick)
        {
            this._color = color;
            this.board = board;
            this.cards = new List<Card>();
            this.nick = nick;
        }

        internal void move(int column)
        {
            Cell cell = this.board.getFirstFreeCell(column);
            Card card = null;
            for (int i = 0; i < this.cards.Count; i++)
            {               
                card = this.cards[i];
                if (card.isInPlayer())
                {
                    card.goToBoard();
                    cell.occupyWith(card);
                    return;
                }                
            }            
        }

        internal void distributeCards()
        {
            if (this.hasColor(Color.RED))
            {
                for (int i = 0; i < Board.NUM_CARDS_BY_PLAYER; i++)
                {
                    this.board.setCard(i, this.color, State.IN_PLAYER);                    
                    this.addCard(this.board.getCard(i));
                }
            }
            else
            {
                for (int i = Board.NUM_CARDS_BY_PLAYER; i < Board.NUM_CARDS_BY_PLAYER * 2; i++)
                {                    
                    this.board.setCard(i, this.color, State.IN_PLAYER);
                    this.addCard(this.board.getCard(i));
                }
            }
        }

        internal bool isWinner()
        {                     
            return this.board.isLineHorizontal4(this._color) || this.board.isLineVertical4(this._color) || this.board.isLineDiagonal4(this._color);            
        }
       
        internal void addCard(Card card)
        {
            this.cards.Add(card);
        }

        internal bool hasColor(Color color)
        {
            return this._color == color;
        }
    }
}