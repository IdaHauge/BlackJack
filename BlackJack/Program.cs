using System;
using System.Data;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var keepPlaying = true;

            while (keepPlaying)
            {
                var dealer = new Dealer();
                Console.WriteLine(dealer.DrawInitialHand(dealer));
                var playerOne = new Player();
                var initialHand = playerOne.DrawInitialHand(playerOne);
                if (initialHand.Contains("Blackjack"))
                {
                    Console.WriteLine(initialHand);
                    break;
                }
                var busted = playerOne.HitOrStay(playerOne);
                if (!busted)
                {
                    dealer.DealersTurn(dealer);
                }
            }
            

            //bool busted = playerOne.HitOrStay(playerOne);
            //if (!busted) 
            //{
            //    dealer.DealersTurn(dealer);
            //}

            //DrawGameMenu();

            //var firstCard = playerOne.DrawCard();
            //playerOne.AddToHand(firstCard);
            //Console.WriteLine("You drew the card {0}.", firstCard);
            //Console.WriteLine("{0}'s current hand total is: {1}.", playerOne.PlayerName, playerOne.PlayerHand);
        }
    }
}
