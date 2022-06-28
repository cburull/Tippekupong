using System;
using System.Collections.Generic;

namespace Tippekupong
{
    internal class Matches
    {
        public Match[] list;
        public int correctGuesses = 0;

        public Matches(string Bets)
        {
            var bets = Bets.Split(",");
            var ListOfMatches = new List<Match>();
            foreach (var bet in bets) ListOfMatches.Add(new Match(bet));
            list = ListOfMatches.ToArray();
        }
        public void RandomizeMatches()
        {
            Console.WriteLine();
            for (var i = 0; i<list.Length; i++)
            {
                var match = list[i];
                match.RunMatchRandom(false);
                Console.WriteLine($"Kamp #{i+1} endte {match.Score()}. Du tippet {match.BetResultText()}.");
                if (match.isBetCorrect) correctGuesses++;
            }
            Console.WriteLine($"\nDu tippet {correctGuesses} av {list.Length} riktig.");
        }
        public void RunMatchesConsole()
        {
            while (true)
            {
                Console.Write($"Skriv kampnr. 1-{list.Length} for scoring eller X for alle kampene er ferdige\r\nAngi kommando: ");
                var command = Console.ReadLine().ToUpper();
                if (command == "X") break;
                var matchNo = Convert.ToInt32(command);
                Console.Write($"Scoring i kamp #{matchNo}. \r\nSkriv H for hjemmelag eller B for bortelag: ");
                var team = Console.ReadLine();
                var match = list[matchNo - 1];
                match.Update(team);

                Console.Clear();
                for (var i = 0; i < list.Length; i++) Console.WriteLine($"Kamp #{i+1}: {list[i].Score()}");
            }
            Console.Clear();
            for (var i = 0; i < list.Length; i++)
            {
                var match = list[i];
                match.EndMatch();
                if (match.isBetCorrect) correctGuesses++;
                Console.WriteLine($"Kamp #{i + 1} endte {match.Score()}. Du tippet {match.BetResultText()}.");
            }
            Console.WriteLine($"\nDu tippet {correctGuesses} av {list.Length} riktig.");
        }
    }
}