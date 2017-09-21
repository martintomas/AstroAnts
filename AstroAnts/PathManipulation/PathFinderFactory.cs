using System;
using AstroAnts.Enumerators;
using AstroAnts.Graphs;
using AstroAnts.PathManipulation.ComparerHeuristics;

namespace AstroAnts.PathManipulation
{
    public class PathFinderFactory
    {
        public static APathFinder PathFactory(Graph graph, PathAlgorithms alg)
        {
            switch (alg)
            {
                case PathAlgorithms.ASTAR_NOHEURISTIC:
                    return new PathFinderAStar(graph);
                case PathAlgorithms.ASTAR_MANHATTAN:
                    return new PathFinderAStar(graph, new HeuristicComparerManhattan(graph));
                case PathAlgorithms.ASTAR_MANHATTAN_ORIENTED:
                    return new PathFinderAStar(graph, new HeuristicComparerManhattanOriented(graph));
                default:
                    throw new Exception("Unknown pathfinding algorithm");
            }
        }
    }
}