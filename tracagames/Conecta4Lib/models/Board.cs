namespace Conecta4Lib.models
{
    internal class Board
    {
        internal static int NUM_CARDS = 42;
        internal static  int NUM_ROWS = 6;
        internal static  int NUM_COLS = 7;
        internal static int NUM_CARDS_BY_PLAYER = 21;
        internal static int NUM_CARDS_WINNER = 4;
        private Cell[][] cells;
        private List<Card> cards;

        internal Board()
        {
            this.cards = new List<Card>(NUM_CARDS);
            this.createCards(0, Color.RED);
            this.createCards(NUM_CARDS_BY_PLAYER, Color.YELLOW);
            this.cells = new Cell[NUM_ROWS][];
            for (int i = 0; i < NUM_ROWS; i++)
            {
                this.cells[i] = new Cell[NUM_COLS];
                for (int j = 0; j < NUM_COLS; j++) {
                    this.cells[i][j] = new Cell(i, j);
                }
            }
        }

        private void createCards(int start, Color color)
        {
            for (int i = start; i < start + NUM_CARDS_BY_PLAYER; i++)
            {
                this.cards.Add(new Card(color, State.IN_BOARD));
            }
        }

        internal Cell getFirstFreeCell(int column)
        {
            for (int i = NUM_ROWS - 1; i >= 0; i--)
            {
                if (!this.cells[i][column].isBussy())
                {
                    return this.cells[i][column];
                }
            }
            return null;
        }

        internal Card getCard(int i)
        {
            return this.cards[i];
        }

        internal void setCard(int i, Color color, State state)
        {
            this.cards[i].set(color, state);
        }

        internal bool isLineDiagonal4(Color color)
        {
            List<int> positionsColor = new List<int>();
            for (int i = 0; i < NUM_ROWS; i++)
            {
                for (int j = 0; j < NUM_COLS; j++)
                {
                    if (this.getNumNeighboursDiagonal(i, j, color) >= NUM_CARDS_WINNER - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int getNumNeighboursDiagonal(int i, int j, Color color)
        {
            int numNeighboards = 0;
            bool cumple = false;
            if (i > 0 && j > 0)
            {
                int dec = 1;
                cumple = true;
                while (i - dec > 0 && j - dec > 0 && cumple)
                {
                    if (this.cells[i - dec][j - dec].hasCard(color))
                    {
                        numNeighboards++;
                    } else
                    {
                        cumple = false;                        
                    }
                    dec++;
                }
            }
            if (!cumple && i < NUM_ROWS - 1 && j < NUM_COLS - 1)
            {
                int dec = 1;
                cumple = true;
                while (i + dec < NUM_ROWS && j + dec < NUM_COLS && cumple)                    
                {
                    if (this.cells[i + dec][j + dec].hasCard(color))
                    {
                        numNeighboards++;
                    }
                    else
                    {
                        cumple = false;                        
                    }
                    dec++;
                }
            }
            return numNeighboards;
        }

        internal bool isLineVertical4(Color color)
        {
            List<int> positionsColor = new List<int>();
            for (int j = 0; j < NUM_COLS; j++)
            {
                for (int i = 0; i < NUM_ROWS; i++)
                {
                    if (this.cells[i][j].hasCard(color))
                    {
                        positionsColor.Add(i);
                    }
                }
                if (this.areConsecutivePositions(positionsColor))
                    return true;
            }
            return false;
        }

        internal bool isLineHorizontal4(Color color)
        {            
            List<int> positionsColor = new List<int>();
            for (int i = 0; i < NUM_ROWS; i++)
            {                
                for (int j = 0; j < NUM_COLS; j++)
                {
                    if (this.cells[i][j].hasCard(color))
                    {
                        positionsColor.Add(j);
                    }
                }
                if (this.areConsecutivePositions(positionsColor))
                    return true;
            }
            return false;
        }

        private bool areConsecutivePositions(List<int> positions)
        {
            int numConsecutives = 0;
            for (int i = 0; i < positions.Count - 1; i++)
            {
                if (Math.Abs(positions[i] - positions[i + 1]) > 1)
                {
                    return false;
                }
                else
                {
                    numConsecutives++;
                }
            }
            return numConsecutives == NUM_CARDS_WINNER - 1;                          
        }        

        internal bool isFullColumn(int column)
        {
            int numBusyCols = 0;
            for (int i = 0; i < NUM_ROWS; i++)
            {
                if (this.cells[i][column].isBussy())
                {
                    numBusyCols++;
                }
            }
            return numBusyCols == NUM_ROWS;
        }

        internal void distributeCardsFor(Player player)
        {
            if (player.hasColor(Color.RED))
            {
                for (int i = 0; i < NUM_CARDS_BY_PLAYER; i++)
                {
                    this.cards[i].set(player.color, State.IN_PLAYER);
                    player.addCard(this.cards[i]);
                }
            }
            else
            {
                for (int i = NUM_CARDS_BY_PLAYER; i < NUM_CARDS_BY_PLAYER * 2; i++)
                {
                    this.cards[i].set(player.color, State.IN_PLAYER);
                    player.addCard(this.cards[i]);
                }
            }            
        }
    }
}