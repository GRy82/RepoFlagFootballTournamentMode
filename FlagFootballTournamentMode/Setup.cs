using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagFootballTournamentMode
{
    class Setup
    {
        public List<Team> teamsList = new List<Team> { };

        public void Launch()
        {
            WelcomeMessage();
            
        }

        private void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Bosotn Coed Flag Football: TOURNAMENT MODE");
            Console.WriteLine("\nLet's make flag fooball more competitive and less fun!");
            Console.WriteLine("           -Founder, Donny Nicolosi");
            Continue();
        }

        private void Continue()
        {
            Console.WriteLine("\n\nPress 'enter' to continue");
            string emptyString = Console.ReadLine();
        }

        private void GenerateTeams()
        {
            string teamQuantInput;
            Console.Write("Enter number of teams that will be in the tournament:");
            do
            {
                teamQuantInput = Console.ReadLine();
            } while (!ValidateTeamInput(teamQuantInput));

            int teamQuant = int.Parse(teamQuantInput);
            
            for (int i = 0; i < teamQuant; i++)
            {
                teamsList.Add(new Team());
            }
            
        }

        private bool ValidateTeamInput(string inputString)
        {
            foreach(char character in inputString)
            {
                if (character < 48 || character > 57)
                {
                    Console.WriteLine("\nYou can only enter number characters. Enter team quantity as a number.");
                    return false;
                }
            }
            if (int.Parse(inputString) > 8)
            {
                Console.WriteLine("\nYou can only have up to 8 teams. Enter a different number.");
                return false;
            }
            return true;

        }

        private void DisplayPlayerList()
        {

        }
    }
}
