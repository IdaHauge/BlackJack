using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Dealer : Participant
    {
        public Card.CardValue HoleCard { get; protected set; }
        public override string DrawInitialHand(Participant participant)
        {
            var firstCard = participant.DrawCard();
            var secondCard = participant.DrawCard();
            HoleCard = secondCard;

            participant.AddToHand(firstCard, participant);
            participant.AddToHand(secondCard, participant);

            return $"The dealer's initial hand is the hidden hole card and {firstCard}.";
        }

        public void DealersTurn(Participant participant)
        {
            Console.WriteLine($"\nThe dealer's hole card is {HoleCard}. The dealer's current total is {participant.PlayerHand}.");
            while (participant.PlayerHand < 17)
            {
                var card = participant.DrawCard();
                participant.AddToHand(card, participant);
                Console.WriteLine($"The dealer drew the card {card}. The dealer's current total is {participant.PlayerHand}");
            }

            DealersTotal = participant.PlayerHand;
        }
    }
}