﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagFootballTournamentMode
{
    class Setup
    {
        public List<Team> teamsList = new List<Team> { };
        public List<Player> playersList = new List<Player> { };

        public void Launch()
        {
            WelcomeMessage();
            GenerateTeams();
            int numberOfPLayers = GetNumberOfPlayers();
            InsertPlayers(numberOfPLayers);

        }

        private void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Bosotn Coed Flag Football: TOURNAMENT MODE!!");
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
            } while (!ValidateNumericInput(teamQuantInput, "teams"));

            int teamQuant = int.Parse(teamQuantInput);

            for (int i = 0; i < teamQuant; i++)
            {
                teamsList.Add(new Team());
            }

        }

        private bool ValidateNumericInput(string inputString, string quantType)
        {
            int quantMax = 0;
            switch (quantType)
            {
                case "teams":
                    quantMax = 8;
                    break;
                case "players":
                    quantMax = 40;
                    break;
            }
            foreach (char character in inputString)
            {
                if (character < 48 || character > 57)
                {
                    Console.Write("\nYou can only enter number characters. Enter team quantity as a number: ");
                    return false;
                }
            }
            if (int.Parse(inputString) > quantMax)
            {
                Console.Write($"\nYou can only have up to {quantMax} {quantType}. Enter a different number: ");
                return false;
            }
            return true;

        }

        private int GetNumberOfPlayers()
        {
            string playerQuantInput;
            Console.Write("Enter the current number of players(players can be added later): ");
            do
            {
                playerQuantInput = Console.ReadLine();
            } while (!ValidateNumericInput(playerQuantInput, "players"));
            int numericPlayers = int.Parse(playerQuantInput);
            return numericPlayers;

        }

        private void InsertPlayers(int numberOfPlayers)
        {
            string name;
            string proficientQBResponse;
            for (int i = 0; i < numberOfPlayers; i++){
                Console.Write($"Enter player number{i + 1}'s name(eg. John S.): ");
                do
                {
                    name = Console.ReadLine();
                } while (!ValidateName(name));
                playersList[i].idNum = i + 1;
                playersList[i].name = name;
                Console.WriteLine("Is this player a proficient QB?(y/n)");
                do
                {
                    proficientQBResponse = Console.ReadLine();
                } while (!ValidateYN(proficientQBResponse));
                SetQB(proficientQBResponse, i);
                Console.Clear();
                Console.WriteLine("\nPlayer successfully added. See updated player list:\n");
                DisplayPlayerList();
            }
            
        }

        private bool ValidateName(string name)
        {
            if (name.Length > 15)
            {
                Console.Write("\nName must be between 4 and 15 characters in length. Please re-enter name: ");
                return false;
            }
            int spaceCount = 0;

            for (int i = 0; i < name.Length - 1; i++)
            {
                if (name[i] < 65 || name[i] > 122 || (name[i] > 90 && name[i] < 97) || name[i] != 32)
                {
                    Console.Write("\nAlphabetical characters only: ");
                    return false;
                }
                if (name[i] == 32)
                {
                    spaceCount++;
                }
            }
            if (spaceCount > 1)
            {
                Console.Write("\nThere can only be one space, between first name and last initial. Please re-enter name: ");
            }
            if (name[name.Length] != '.')
            {
                Console.Write("\nAdd a '.' after initials. Please re-enter name: ");
                return false;
            }
            return true;
        }

        private bool ValidateYN(string response)
        {
            if (response != "y" || response != "no")
            {
                Console.Write("Reponse must be a 'y' or 'n' for yes or no. Please re-enter your response: ");
                return false;
            }
            return true;
        }

        private void SetQB(string response, int playerIndex)
        {
            if (response == "y")
            {
                playersList[playerIndex].proficientQB = true;
            }
            else
            {
                playersList[playerIndex].proficientQB = false;
            }
        }

        private void DisplayPlayerList()
        {
            foreach(Player player in playersList)
            {
                Console.WriteLine(player.idNum + ": " + player.name);
            }
        }
    }
}
