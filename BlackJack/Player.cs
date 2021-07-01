using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Player : Participant
    {

        public override string DrawInitialHand(Participant participant)
        {
            var randomCard1 = new Random();
            var randomCard2 = new Random();
            var drawnCard1 = (Card.CardValue) randomCard1.Next(1, Enum.GetNames(typeof(Card.CardValue)).Length + 1);
            var drawnCard2 = (Card.CardValue)randomCard2.Next(1, Enum.GetNames(typeof(Card.CardValue)).Length + 1);
            return $"Your initial hand is {drawnCard1} and {drawnCard2}. Your total is {participant.AddToHand(drawnCard1) + participant.AddToHand(drawnCard2)}.";
        }
    }
}