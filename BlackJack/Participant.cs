using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public abstract class Participant
    {
        private int _playerHand;

        
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
        //The identifier doesn't really matter and is independent of any variables you create in Main, it just needs something to compare to
        //public static string GetPlayerName(Player newPlayer)
        //{
        //    Console.WriteLine("Who's playing today?");
        //    newPlayer.PlayerName = Console.ReadLine();
        //    return newPlayer.PlayerName;
        //}
        public abstract string DrawInitialHand(Participant participant);
        public Card.CardValue DrawCard()
        {
            var randomCard = new Random();
            return (Card.CardValue)randomCard.Next(1, Enum.GetNames(typeof(Card.CardValue)).Length + 1);
        }

        public virtual int AddToHand(Card.CardValue newCardValue)
        {
            return Convert.ToInt32(newCardValue);
        }
    }
}