using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Player
    {
        private string _playerName;
        private int _playerHand;

        public string PlayerName
        {
            get => _playerName;
            set
            {
                if (value != null)
                {
                    _playerName = value;
                }
            }
        }
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
        public static string GetPlayerName(Player newPlayer)
        {
            Console.WriteLine("Who's playing today?");
            newPlayer.PlayerName = Console.ReadLine();
            return newPlayer.PlayerName;
        }
        public Card.CardValue PlayerDrawCard()
        {
            var randomCard = new Random();
            return (Card.CardValue)randomCard.Next(Enum.GetNames(typeof(Card.CardValue)).Length);
        }

        public void AddToPlayerHand(Card.CardValue firstCardValue)
        {
            PlayerHand = Convert.ToInt32(firstCardValue);
        }
    }
}