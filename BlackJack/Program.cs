using System;
using System.Data;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var keepPlaying = true;
            var dealer = new Dealer();
            var playerOne = new Player();

            while (keepPlaying)
            {
                RestartGame:
                Console.Clear();

                Console.WriteLine(dealer.DrawInitialHand());
                var initialHand = playerOne.DrawInitialHand();
                if (playerOne.HasBlackJack)
                {
                    Console.WriteLine(initialHand);
                    if (playerOne.WantsToKeepPlaying())
                    {
                        playerOne.ResetTotals();
                        dealer.ResetTotals();
                        goto RestartGame;
                    }
                }

                Console.WriteLine(initialHand);
                
                var playerBusted = playerOne.HitOrStay();
                if (playerBusted)
                {
                    playerOne.Busted();
                    if (playerOne.WantsToKeepPlaying())
                    {
                        playerOne.ResetTotals();
                        dealer.ResetTotals();
                        goto RestartGame;
                    }
                } 
                
                var dealerBusted = dealer.DealersTurn();
                if (dealerBusted)
                {
                    dealer.Busted();
                    if (playerOne.WantsToKeepPlaying())
                    {
                        playerOne.ResetTotals();
                        dealer.ResetTotals();
                        goto RestartGame;
                    }
                }
                Console.WriteLine(Participant.DetermineWinnerByScore(dealer, playerOne));
                Console.ResetColor();
                if (playerOne.WantsToKeepPlaying())
                {
                    playerOne.ResetTotals();
                    dealer.ResetTotals();
                    goto RestartGame;
                }
                else keepPlaying = false;
            }
        }
    }
}
