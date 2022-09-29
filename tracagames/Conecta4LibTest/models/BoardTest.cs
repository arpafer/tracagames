using Conecta4Lib.models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4LibTest.models
{
    internal class BoardTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_BoardEmpty_When_requestFirstFreeCellInColumn0_Then_cellIsFree()
        {
            Board board = new Board();
            Cell cell = board.getFirstFreeCell(0);
            Assert.IsTrue(cell.isPosition(5, 0));
            Assert.IsFalse(cell.isBussy());
        }

        [Test]
        public void Given_BoardEmpty_When_callIsFullColumn0_Then_False()
        {
            Board board = new Board();            
            Assert.IsFalse(board.isFullColumn(0));
        }

        [Test]
        public void Given_BoardEmpty_When_playerRedMovetoFirstColumn_Then_firstFreeCellIsCorrect()
        {
            Board board = new Board();            
            Player player = new Player(board, Color.RED, "Jugador");
            player.distributeCards();
            player.move(0);
            Cell cell = board.getFirstFreeCell(0);
            Assert.IsTrue(cell.isPosition(Board.NUM_ROWS - 2, 0));
        }

        [Test]
        public void Given_BoardEmpty_When_playerRedMovetoLastColumn_Then_firstFreeCellIsCorrect()
        {
            Board board = new Board();
            Player player = new Player(board, Color.RED, "Jugador");
            player.distributeCards();
            player.move(Board.NUM_COLS - 1);
            Cell cell = board.getFirstFreeCell(Board.NUM_COLS - 1);
            Assert.IsTrue(cell.isPosition(Board.NUM_ROWS - 2, Board.NUM_COLS - 1));
        }

        [Test]
        public void Given_BoardEmpty_When_playerYellowMovetoFirstColumn_Then_firstFreeCellIsCorrect()
        {
            Board board = new Board();
            Player player = new Player(board, Color.YELLOW, "Jugador");
            player.distributeCards();
            player.move(0);
            Cell cell = board.getFirstFreeCell(0);
            Assert.IsTrue(cell.isPosition(Board.NUM_ROWS - 2, 0));
        }

        [Test]
        public void Given_BoardEmpty_When_playerYellowMovetoLastColumn_Then_firstFreeCellIsCorrect()
        {
            Board board = new Board();
            Player player = new Player(board, Color.YELLOW, "Jugador");
            player.distributeCards();
            player.move(Board.NUM_COLS - 1);
            Cell cell = board.getFirstFreeCell(Board.NUM_COLS - 1);
            Assert.IsTrue(cell.isPosition(Board.NUM_ROWS - 2, Board.NUM_COLS - 1));
        }
             
        [Test]
        public void Given_Board_When_PlayerPushCardVerticalsInColumn_Then_IsVertical4()
        {
            Board board = new Board();
            Player player = new Player(board, Color.RED, "Jugador");
            player.distributeCards();
            for (int i = 0; i < Board.NUM_CARDS_WINNER; i++)
            {
                player.move(0);
            }
            Assert.IsTrue( board.isLineVertical4(Color.RED) );
        }

        [Test]
        public void Given_Board_When_PlayerPushCardInColumnHorizontals_Then_IsHorizontal4()
        {
            Board board = new Board();
            Player player = new Player(board, Color.RED, "Jugador");
            player.distributeCards();
            for (int i = 0; i < Board.NUM_CARDS_WINNER; i++)
            {
                player.move(i);
            }
            Assert.IsTrue(board.isLineHorizontal4(Color.RED));
        }

        [Test]
        public void Given_Board_When_PlayerPushCardInDiagonalColumns_Then_IsDiagonal4()
        {
            Board board = new Board();
            Player playerRed = new Player(board, Color.RED, "Jugador1");
            Player playerYellow = new Player(board, Color.YELLOW, "Jugador2");
            playerRed.distributeCards();
            playerYellow.distributeCards();
            playerRed.move(0);
            playerYellow.move(0);
            playerRed.move(0);
            playerYellow.move(1);
            playerRed.move(1);
            playerYellow.move(2);
            playerRed.move(0);
            playerRed.move(1);
            playerRed.move(2);
            playerRed.move(3);
            Assert.IsTrue(board.isLineDiagonal4(Color.RED));
        }
    }
}
