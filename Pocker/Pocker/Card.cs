using System;

namespace Poker
{

    public class Card {

        private string suit;
        private string rank;                                

        public Card(string suit, string rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string ToString()
        {
            return $"{this.rank}{this.suit}";
        }

        public bool HasSameSuit(Card other)
        {
            return this.suit == other.suit;
        }

        public bool HasSameRank(Card other)
        {
            return this.rank == other.rank;
        }

        public bool isSequentailRank(Card other)
        {
            int first_rank = get_rank_value(this.rank);
            int second_rank = get_rank_value(other.rank);

            return Math.Abs(first_rank - second_rank) == 1;
        }

        private int get_rank_value(string rank)
        {
            switch(rank)
            {
                case "A":
                    return 1;
                default:
                    return int.Parse(rank);
            }
        }
    }
}