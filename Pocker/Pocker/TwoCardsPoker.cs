namespace Poker
{
    public class TwoCardsPoker
    {
        private Card first;
        private Card second;

        public enum TwoCardsHand : int
        {
            HighCard = 0,
            Pair,
            Flush
        }

        public TwoCardsHand Hand {get;private set;}

        public TwoCardsPoker(Card first, Card second)
        {
            this.first = first;
            this.second = second;

            this.Hand = judgeHand();
        }

        private TwoCardsHand judgeHand()
        {
            if (isPair())
            {
                return TwoCardsHand.Pair;
            }

            if (isFlush())
            {
                return TwoCardsHand.Flush;
            }
            
            return TwoCardsHand.HighCard;
        }

        private bool isPair()
        {
            return this.first.HasSameRank(this.second);
        }

        private bool isStraight()
        {
            return first.isSequentailRank(second);
        }

        public bool isFlush()
        {
            return this.first.HasSameSuit(this.second);
        }

        public bool isHighCard()
        {
            return !(isPair() || isFlush());
        }
    }
}