using System;
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
            //Add method to check if addedCard = Ace, and if adding the Ace would put the player hand over 21 (possibly an abstract in Participant)
            //Might fit better to call it inside the AddToHand method.
            return addedCard;
        }

        public virtual void AddToHand(Card.CardValue drawnCard, Participant participant)
        {
            var cardToAdd = (int)drawnCard;
            participant.PlayerHand += cardToAdd;
            if (drawnCard == Card.CardValue.Ace && participant.PlayerHand > 21)
                participant.PlayerHand -= 10;
        }

        public virtual void Busted(Participant participant)
        {
        }

        public static string DetermineWinnerByScore(Participant dealer, Participant player)
        {
            int dealerscore = dealer.DealersTotal;
            int playerscore = player.PlayersTotal;

            if (dealerscore < playerscore)
            {
                return $"You win! Your score was {playerscore}, and the dealer's score is {dealerscore}.";
            } else if (dealerscore > playerscore)
            {
                return $"You lose :( The dealer's score is {dealerscore}, your score is {playerscore}.";
            }
            else
            {
                return $"So close! But since you both have the same score of {playerscore}, the dealer takes this one.";
            }
        }
    }
}