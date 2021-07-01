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
            var addedCard = (Card.CardValue)randomCard.Next((int)Card.CardValue.Two, (int)Card.CardValue.Ace + 1);
            return addedCard;
        }

        public virtual void AddToHand(Card.CardValue drawnCard, Participant participant)
        {
            var cardToAdd = (int)drawnCard;
            participant.PlayerHand += cardToAdd;
        }
    }
}