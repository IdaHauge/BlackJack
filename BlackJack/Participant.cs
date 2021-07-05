﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public abstract class Participant
    {
        private int _playerHand;

        public int DealersTotal { get; protected set; }
        public int PlayersTotal { get; protected set; }

        public int PlayerHand
        {
            get => _playerHand;
            set
            {
                if (value != 0)
                {
                    _playerHand = value;
                }
            }
        }
        
        public abstract string DrawInitialHand();

        public Card.CardValue DrawCard()
        {
            var randomCard = new Random();
            var addedCard = (Card.CardValue)randomCard.Next((int)Card.CardValue.Two, (int)Card.CardValue.Ace + 1);
            return addedCard;
        }

        public virtual void AddToHand(Card.CardValue drawnCard)
        {
            var cardToAdd = (int)drawnCard;
            PlayerHand += cardToAdd;
            if (drawnCard == Card.CardValue.Ace && PlayerHand > 21)
                PlayerHand -= 10;
        }

        public bool WantsToKeepPlaying()
        {
            Console.WriteLine("\nWould you like to play again?");
            var keepPlaying = Console.ReadKey().KeyChar;
            if (keepPlaying == 'y')
            {
                return true;
            }
            else
                return false;
        }

        public static string DetermineWinnerByScore(Participant dealer, Participant player)
        {
            int dealerscore = dealer.DealersTotal;
            int playerscore = player.PlayersTotal;

            if (dealerscore < playerscore)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                return $"You win! Your score was {playerscore}, and the dealer's score is {dealerscore}.";
            } else if (dealerscore > playerscore)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                return $"You lose :( The dealer's score is {dealerscore}, your score is {playerscore}.";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                return $"So close! But since you both have the same score of {playerscore}, the dealer takes this one.";
            }
        }

        public void ResetTotals()
        {
            PlayersTotal = 0;
            DealersTotal = 0;
            _playerHand = 0;
        }
    }
}