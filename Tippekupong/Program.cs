using System;

namespace Tippekupong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Single match (y,n)? ");
            string command = Console.ReadLine();
            if (command == "y") SingleMatch();
            if (command == "n") MultipleMatches();
        }

        private static void MultipleMatches()
        {
            Console.Write("Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nDine tips separert med komma: ");
            var bets = Console.ReadLine();
            var matches = new Matches(bets);
            Console.Write("Random results (y,n)? ");
            string randResults = Console.ReadLine();
            if (randResults == "y") matches.RandomizeMatches();
            if (randResults == "n") matches.RunMatchesConsole();
        }

        static void SingleMatch()
        {
            Console.Write("Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nHva har du tippet for denne kampen? ");
            var bet = Console.ReadLine();
            var match = new Match(bet);
            match.RunMatchConsole();
            match.ShowResultOfBet();
        }
    }
}
