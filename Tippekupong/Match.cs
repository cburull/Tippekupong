using System;

namespace Tippekupong
{
    class Match
    {
        public string bet;
        private int homeGoals = 0;
        private int awayGoals = 0;
        public bool matchIsRunning = true;
        private string result;
        public bool isBetCorrect;

        public Match(string Bet) => bet = Bet;

        public void CalcResult()
        {
            result = homeGoals == awayGoals ? "U" : homeGoals > awayGoals ? "H" : "B";
        }
        public string Score()
        {
            return $"{homeGoals}-{awayGoals}";
        }
        public void ShowScore()
        {
            Console.WriteLine($"Stillingen er {Score()}.");
        }
        public void ShowFinalScore()
        {
            Console.WriteLine($"Kampen endte: {Score()}.");
        }
        public void Update(string command)
        {
            if (command == "X") EndMatch();
            else if (command == "H") homeGoals++;
            else if (command == "B") awayGoals++;
        }
        public void EndMatch()
        {
            matchIsRunning = false;
            CalcResult();
            IsBetCorrect();
        }
        private void IsBetCorrect()
        {
            isBetCorrect = bet.Contains(result);
        }
        public string BetResultText()
        {
            return isBetCorrect ? "riktig" : "feil";
        }
        public void ShowResultOfBet()
        {
            Console.WriteLine($"Du tippet {BetResultText()}");
        }
        public void RunMatchConsole()
        {
            while (matchIsRunning)
            {
                Console.Write("Kommandoer: \r\n - H = scoring hjemmelag\r\n - B = scoring bortelag\r\n - X = kampen er ferdig\r\nAngi kommando: ");
                var command = Console.ReadLine();
                Update(command);
                ShowScore();
            }
        }
        public void RunMatchRandom(bool showFinalScore = true)
        {
            while (matchIsRunning)
            {
                var rand = new Random();
                var N = rand.Next(3);
                var command = N==1? "H" : N==2? "B" : "X";
                Update(command);
            }
            if (showFinalScore) ShowFinalScore();
        }
    }
}
