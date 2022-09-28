using Conecta4Lib.models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4LibTest.models
{
    internal class CellTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_Cell_When_Call_IsBussy_Then_false()
        {
            Cell cell = new Cell(0, 0);
            Assert.IsFalse(cell.isBussy());
        }

        [Test]
        public void Given_CellWithCard_When_Call_IsBussy_Then_true()
        {
            Cell cell = new Cell(0, 0);
            cell.occupyWith(new Card(Color.RED, State.IN_BOARD));
            Assert.IsTrue(cell.isBussy());
        }

        [Test]
        public void Given_CellWithCardRed_When_Call_hasCardWithColorRed_Then_colorIsTrue()
        {
            Cell cell = new Cell(0, 0);
            cell.occupyWith(new Card(Color.RED, State.IN_BOARD));
            Assert.IsTrue(cell.hasCard(Color.RED));
        }

        [Test]
        public void Given_CellWithCardRed_When_Call_hasCardDistinctRed_Then_colorIsFalse()
        {
            Cell cell = new Cell(0, 0);
            cell.occupyWith(new Card(Color.RED, State.IN_BOARD));
            Assert.IsFalse(cell.hasCard(Color.YELLOW));
        }
    }
}
