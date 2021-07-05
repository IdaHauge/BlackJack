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
         public bool HitOrStay()
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
                    var card = DrawCard();
                    AddToHand(card);
                    Console.WriteLine($"You drew the card {card}. Your current total is {PlayerHand}.");
                    if (PlayerHand >= 21)
                    {
                        keepDrawing = false;
                        if (PlayerHand >= 22)
                        {
                            busted = true;
                        }
                    }
                } else if (input == "s")
                {
                    keepDrawing = false;
                    
                }
            }
            PlayersTotal = PlayerHand;
            return busted;
        }

        public override string DrawInitialHand()
        {
            var firstCard = DrawCard();
            var secondCard = DrawCard();

            AddToHand(firstCard);
            AddToHand(secondCard);

            if (PlayerHand == 21)
            {
                HasBlackJack = true;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                return $"Your initial hand is {firstCard} and {secondCard}.\nYou win! (Your total is {PlayerHand}, so you have Blackjack).";
            }

            return $"Your initial hand is {firstCard} and {secondCard}. Your total is {PlayerHand}.";
        }

        public void Busted()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Oof! You went over 21 and were busted. (Your total score is {PlayerHand}).");
            Console.ResetColor();
        }
    }
}