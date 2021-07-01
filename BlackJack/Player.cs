using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace BlackJack
{
    public class Player : Participant
    {
        public void HitOrStay(Participant participant)
        {
            bool keepDrawing = true;

            while (keepDrawing)
            {
                Console.WriteLine("\nWould you like to hit or stay? h/s");
                if (Console.ReadLine() == "h")
                {
                    var card = participant.DrawCard();
                    participant.AddToHand(card, participant);
                    Console.WriteLine($"You drew the card {card}. Your current total is {participant.PlayerHand}");

                } else if (Console.ReadLine() == "s")
                {
                    keepDrawing = false;
                }
            }
            //unimplemented dealer's turn method
        }

        public override string DrawInitialHand(Participant participant)
        {
            var firstCard = participant.DrawCard();
            var secondCard = participant.DrawCard();

            participant.AddToHand(firstCard, participant);
            participant.AddToHand(secondCard, participant);

            return $"Your initial hand is {firstCard} and {secondCard}. Your total is {participant.PlayerHand}.";

            //var deck = new Random();
            //var drawnCard1 = (Card.CardValue)deck.Next(1, Enum.GetNames(typeof(Card.CardValue)).Length + 1);
            //var drawnCard2 = (Card.CardValue)deck.Next(1, Enum.GetNames(typeof(Card.CardValue)).Length + 1);
            //return $"Your initial hand is {drawnCard1} and {drawnCard2}. Your total is {AddToHand(drawnCard1) + AddToHand(drawnCard2)}.";
        }
    }
}