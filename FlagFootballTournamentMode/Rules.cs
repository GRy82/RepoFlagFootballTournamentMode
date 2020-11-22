using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagFootballTournamentMode
{
    public static class Rules
    {
        public static void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("Before the tournament starts, if teams seem unfair, trades can be made, but both teams MUST agree to it." +
                "\nA team that wants to trade for a player can make their deal more enticing by trading something additional." +
                "\nThey can trade one of their timeouts, they can give up starting possession, they can have a second taken" +
                "\naway from their QB count, etc. It's all in the art of the deal, really ;)" +
                "\n\nTeams are decided randomly, but takes into account QB proficiency, so that no team is left wihtout a QB."+
                "\nIf players arrive after randomization of teams, they are first added to any team that is short-handed."+
                "\nIf teams are even at that time, players are distributed first to team1, then team2, etc."+
                "\n\nTournaments are double elimination."+
                "\n\nDefense counts to 15 Mississippi once they are set, each play. During this time, offenses may huddle."+
                "\n\nEach team, by default, has 2 60-sec timeouts per game."+
                "\n\nIn the future, players will be stored in database, with their W/L record kept so it can be factored into" +
                "\nthe randomization of teams, providing a more balanced result.");
            Continue();
        }

        private static void Continue(){
            Console.WriteLine("\n\nPress 'enter' to continue");
            string something = Console.ReadLine();
        }
    }
}
