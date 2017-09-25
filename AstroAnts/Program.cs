using System;
using AstroAnts.Enumerators;

namespace AstroAnts
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //SimpleFacade.RunAntQuest(JsonTypes.API_QUADIENT, PathAlgorithms.ASTAR_MANHATTAN, true);

            SimpleFacade.RunAntQuest(JsonTypes.TEST, PathAlgorithms.ASTAR_MANHATTAN, true);

            Console.ReadLine();
        }
    }
}