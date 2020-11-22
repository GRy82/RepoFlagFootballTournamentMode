using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace FlagFootballTournamentMode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;
            List<string> optionsStrings = new List<string> {"Create tournament", "See tournament rules"};
            ConsoleOptionsInterface optionsMenu = new ConsoleOptionsInterface(optionsStrings, true, false);
            Setup setupTournament = new Setup();
            do
            {
                setupTournament.WelcomeMessage();
                int selectedOption = optionsMenu.Launch();
                if (selectedOption == 1)
                {
                    setupTournament.Launch();
                }
                else if (selectedOption == 2)
                {
                    Rules.DisplayRules();
                }
            } while (runProgram == true);
        }
    }
}
