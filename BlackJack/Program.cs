using System;
using System.Data;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var dealer = new Dealer();
            Console.WriteLine(dealer.DrawInitialHand(dealer));
            var playerOne = new Player();
            Console.WriteLine(playerOne.DrawInitialHand(playerOne));
            

            //DrawGameMenu();

            //var firstCard = playerOne.DrawCard();
            //playerOne.AddToHand(firstCard);
            //Console.WriteLine("You drew the card {0}.", firstCard);
            //Console.WriteLine("{0}'s current hand total is: {1}.", playerOne.PlayerName, playerOne.PlayerHand);
        }
    }
}
