using System;
using System.Data;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerOne = new Player();
            Player.GetPlayerName(playerOne);

            //DrawGameMenu();

            var firstCard = playerOne.PlayerDrawCard();
            playerOne.AddToPlayerHand(firstCard);
            Console.WriteLine("{0} drew the card {1}.", playerOne.PlayerName, firstCard);
            Console.WriteLine("{0}'s current hand total is: {1}.", playerOne.PlayerName, playerOne.PlayerHand);
        }
    }
}
