using System;
using astroAnts.Graphs;

namespace astroAnts.PathManipulation.ComparerHeuristics
{
    public class HeuristicComparerManhattan : AHeuristicComparer
    {
        public HeuristicComparerManhattan(Graph graph) : base(graph)
        {
            XPosEnd = graph.EndNode.NodeCode % graph.RowSize;
            YPosEnd = graph.EndNode.NodeCode / graph.RowSize;
        }

        public int XPosEnd { get; }
        public int YPosEnd { get; }

        public override int ComputeHeuristic(IGraphNode graphNode)
        {
            var xPos = graphNode.NodeCode % Graph.RowSize;
            var yPos = graphNode.NodeCode / Graph.RowSize;

            return Math.Abs(XPosEnd - xPos) + Math.Abs(YPosEnd - yPos) - 1;
        }
    }
}