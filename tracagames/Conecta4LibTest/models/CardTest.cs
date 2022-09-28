using NUnit.Framework;
using Conecta4Lib.models;

namespace Conecta4LibTest.models
{
    public class CardTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_CardInPlayer_When_call_IsInPlayer_Then_true()
        {
            Card card = new Card(Color.RED, State.IN_PLAYER);            
            Assert.IsTrue(card.isInPlayer());
        }

        [Test]
        public void Given_CardInBoard_When_call_IsInPlayer_Then_false()
        {
            Card card = new Card(Color.RED, State.IN_BOARD);
            Assert.IsFalse(card.isInPlayer());
        }

        [Test]
        public void Given_CardInPlayer_When_call_goToBoard_Then_StateIsInBoard()
        {
            Card card = new Card(Color.RED, State.IN_PLAYER);
            card.goToBoard();
            Assert.IsFalse(card.isInPlayer());
        }
    }
}