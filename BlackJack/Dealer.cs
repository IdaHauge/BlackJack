using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Dealer : Participant
    {
        public Card.CardValue HoleCard { get; protected set; }
        public override string DrawInitialHand()
        {
            var firstCard = DrawCard();
            var secondCard = DrawCard();
            HoleCard = secondCard;

            AddToHand(firstCard);
            AddToHand(secondCard);

            return $"The dealer's initial hand is the hidden hole card and {firstCard}.";
        }

        public bool DealersTurn()
        {
            var busted = false;
            Console.WriteLine($"\nThe dealer's hole card is {HoleCard}. The dealer's current total is {PlayersTotal}.");
            while (PlayersTotal < 17)
            {
                var card = DrawCard();
                AddToHand(card);
                Console.WriteLine($"The dealer drew the card {card}. The dealer's current total is {PlayersTotal}.");
                if (PlayersTotal > 21)
                {
                    busted = true;
                }
            }
            return busted;
        }

        public void Busted()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Yay! The dealer busted out with a score of {PlayersTotal}, and you win!");
            Console.ResetColor();
        }
    }
}