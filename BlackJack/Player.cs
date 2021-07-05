using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace BlackJack
{
    public class Player : Participant
    {
         public bool HitOrStay(Participant participant)
        {
            bool keepDrawing = true;
            bool busted = false;

            while (keepDrawing)
            {
                Console.WriteLine("\nWould you like to hit or stay? h/s");
                var input = Console.ReadLine();

                if (input == "h")
                {
                    var card = participant.DrawCard();
                    participant.AddToHand(card, participant);
                    Console.WriteLine($"You drew the card {card}. Your current total is {participant.PlayerHand}");
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

            return $"Your initial hand is {firstCard} and {secondCard}. Your total is {participant.PlayerHand}.";
        }
    }
}