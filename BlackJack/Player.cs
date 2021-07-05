using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace BlackJack
{
    public class Player : Participant
    {
        public bool HasBlackJack { get; private set; }
         public bool HitOrStay(Participant participant)
        {
            bool keepDrawing = true;
            bool busted = false;

            while (keepDrawing)
            {
                if (HasBlackJack)
                    break;
                Console.WriteLine("\nWould you like to hit or stay? h/s");
                var input = Console.ReadLine();

                if (input == "h")
                {
                    var card = participant.DrawCard();
                    participant.AddToHand(card, participant);
                    Console.WriteLine($"You drew the card {card}. Your current total is {participant.PlayerHand}.");
                    if (participant.PlayerHand >= 21)
                    {
                        keepDrawing = false;
                        if (participant.PlayerHand >= 22)
                        {
                            busted = true;
                        }
                    }
                } else if (input == "s")
                {
                    keepDrawing = false;
                    
                }
            }
            PlayersTotal = participant.PlayerHand;
            return busted;
        }

        public override string DrawInitialHand(Participant participant)
        {
            var firstCard = participant.DrawCard();
            var secondCard = participant.DrawCard();

            participant.AddToHand(firstCard, participant);
            participant.AddToHand(secondCard, participant);

            if (participant.PlayerHand == 21)
            {
                HasBlackJack = true;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                return $"Your initial hand is {firstCard} and {secondCard}.\nYou win! (Your total is {participant.PlayerHand}, so you have Blackjack).";
            }

            return $"Your initial hand is {firstCard} and {secondCard}. Your total is {participant.PlayerHand}.";
        }

        public void Busted()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Oof! You went over 21 and were busted. (Your total score is {PlayerHand}).");
            Console.ResetColor();
        }
    }
}