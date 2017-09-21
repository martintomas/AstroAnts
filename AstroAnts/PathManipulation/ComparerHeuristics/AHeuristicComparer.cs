using System.Collections.Generic;
using astroAnts.Graphs;

namespace astroAnts.PathManipulation.ComparerHeuristics
{
    public abstract class AHeuristicComparer : IComparer<GraphNodeHeuristic>
    {
        protected AHeuristicComparer(Graph graph)
        {
            Graph = graph;
        }

        public Graph Graph { get; }

        public int Compare(GraphNodeHeuristic x, GraphNodeHeuristic y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.DistanceValue + x.HeuristicValue > y.DistanceValue + y.HeuristicValue
                ? 1
                : x.DistanceValue + x.HeuristicValue < y.DistanceValue + y.HeuristicValue
                    ? -1
                    : 0;
        }

        public abstract int ComputeHeuristic(IGraphNode graphNode);
    }
}