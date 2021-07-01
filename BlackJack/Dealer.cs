using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Dealer : Participant
    {
        public override string DrawInitialHand(Participant participant)
        {
            var firstCard = participant.DrawCard();
            var secondCard = participant.DrawCard();

            participant.AddToHand(firstCard, participant);
            participant.AddToHand(secondCard, participant);

            return $"The dealer's initial hand is the hidden hole card and {secondCard}.";
        }
    }
}