using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagFootballTournamentMode
{
    public class RandomNumberGen
    {

        public static int GenerateNumber(int lowerBound, int upperBound)
        {
            Random random = new Random();
            int randGenNum = random.Next(lowerBound, upperBound + 1);
            return randGenNum;
        }
    }
}
