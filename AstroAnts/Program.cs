using System;
using AstroAnts.Enumerators;

namespace AstroAnts
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //SimpleFacade.RunAntQuest(JsonTypes.API_QUADIENT, PathAlgorithms.ASTAR_MANHATTAN, true);

            SimpleFacade.RunAntQuest(JsonTypes.FILE, PathAlgorithms.ASTAR_MANHATTAN, true, @"U:\z.obst\apiary\task1000.json");

            Console.ReadLine();
        }
    }
}