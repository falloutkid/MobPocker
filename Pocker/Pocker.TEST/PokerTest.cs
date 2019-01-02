using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace Poker.TEST
{
    [TestClass]
    public class PokerTest
    {
        [TestMethod]
        public void Testカードの文字列表記_スペードの3を表示()
        {
            Card spade3 = new Card("♠", "3"); 

            spade3.ToString().Is("3♠");
        }

        [TestMethod]
        public void Testカードの文字列表記_ハートのJを表示()
        {
            Card heartJ = new Card("♥", "J");

            heartJ.ToString().Is("J♥");
        }

        [TestMethod]
        public void Testスートの同一性_同一の場合()
        {
            Card spade3 = new Card("♠", "3");
            Card spadeJ = new Card("♠", "J");

            spade3.HasSameSuit(spadeJ).IsTrue();
        }

        [TestMethod]
        public void Testスートの同一性_異なる場合()
        {
            Card spade3 = new Card("♠", "3");
            Card heart3 = new Card("♥", "3");

            spade3.HasSameSuit(heart3).IsFalse();
        }

        [TestMethod]
        public void Testランクの同一性_同一の場合()
        {
            Card spade3 = new Card("♠", "3");
            Card heart3 = new Card("♥", "3");

            spade3.HasSameRank(heart3).IsTrue();
        }

        [TestMethod]
        public void Testランクの同一性_異なる場合()
        {
            Card spade3 = new Card("♠", "3");
            Card heart5 = new Card("♥", "5");

            spade3.HasSameRank(heart5).IsFalse();
        }

        [TestMethod]
        public void ペアが判定できる()
        {
            Card spade3 = new Card("♠", "3");
            Card heart3 = new Card("♥", "3");

            TwoCardsPoker cards = new TwoCardsPoker(spade3, heart3);
            Assert.IsTrue(cards.AsDynamic().isPair());
        }

        [TestMethod]
        public void フラッシュが判定できる()
        {
            Card spade3 = new Card("♠", "3");
            Card spadeJ = new Card("♠", "J");

            TwoCardsPoker cards = new TwoCardsPoker(spade3, spadeJ);

            Assert.IsTrue(cards.AsDynamic().isFlush());
        }

        [TestMethod]
        public void ハイカードが判定できる()
        {
            Card spade3 = new Card("♠", "3");
            Card heartJ = new Card("♥", "J");

            TwoCardsPoker cards = new TwoCardsPoker(spade3, heartJ);

            Assert.IsTrue(cards.AsDynamic().isHighCard());
        }

        [TestMethod]
        public void ストレートが判定できる_その1()
        {
            Card heart3 = new Card("♥", "3");
            Card spade4 = new Card("♠", "4");

            TwoCardsPoker cards = new TwoCardsPoker(heart3, spade4);

            Assert.IsTrue(cards.AsDynamic().isStraight());
        }

        [TestMethod]
        public void ストレートが判定できる_その2()
        {
            Card heart4 = new Card("♥", "4");
            Card spade5 = new Card("♠", "5");

            TwoCardsPoker cards = new TwoCardsPoker(heart4, spade5);

            Assert.IsTrue(cards.AsDynamic().isStraight());
        }

        [TestMethod]
        public void ストレートが判定できる_その3()
        {
            Card heartA = new Card("♥", "A");
            Card spade2 = new Card("♠", "2");

            TwoCardsPoker cards = new TwoCardsPoker(heartA, spade2);

            Assert.IsTrue(cards.AsDynamic().isStraight());
        }

        [TestMethod]
        public void ストレートが判定できる_その4()
        {
            Card heartA = new Card("♥", "A");
            Card spadeK = new Card("♠", "K");

            TwoCardsPoker cards = new TwoCardsPoker(heartA, spadeK);

            Assert.IsTrue(cards.AsDynamic().isStraight());
        }

        [TestMethod]
        public void HandでPairを判定できる()
        {
            Card spade3 = new Card("♠", "3");
            Card heart3 = new Card("♥", "3");

            TwoCardsPoker cards = new TwoCardsPoker(spade3, heart3);

            cards.Hand.Is(TwoCardsPoker.TwoCardsHand.Pair);
        }

        [TestMethod]
        public void HandでFlushを判定できる()
        {
            Card spade3 = new Card("♠", "3");
            Card spadeJ = new Card("♠", "J");

            TwoCardsPoker cards = new TwoCardsPoker(spade3, spadeJ);

            cards.Hand.Is(TwoCardsPoker.TwoCardsHand.Flush);
        }

        [TestMethod]
        public void HandでHighCardを判定できる()
        {
            Card spade3 = new Card("♠", "3");
            Card heartJ = new Card("♥", "J");

            TwoCardsPoker cards = new TwoCardsPoker(spade3, heartJ);

            cards.Hand.Is(TwoCardsPoker.TwoCardsHand.HighCard);
        }

        
    }
}


