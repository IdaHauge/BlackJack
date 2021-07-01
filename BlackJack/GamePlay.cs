using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class GamePlay
    {
        private bool _playerWin;
        private bool _dealerWin;

        public void DrawGameMenu()
        {
            throw new System.NotImplementedException();
        }

        public Card.CardValue DrawCard()
        {
            var randomCard = new Random();
            return (Card.CardValue)randomCard.Next(Enum.GetNames(typeof(Card.CardValue)).Length);
        }
    }
}