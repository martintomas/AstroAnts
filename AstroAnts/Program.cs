using System;
using AstroAnts.Enumerators;

namespace AstroAnts
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SimpleFacade.runAntQuest(JsonTypes.API_QUADIENT, PathAlgorithms.ASTAR_MANHATTAN, true);

            Console.ReadLine();
        }
    }
}