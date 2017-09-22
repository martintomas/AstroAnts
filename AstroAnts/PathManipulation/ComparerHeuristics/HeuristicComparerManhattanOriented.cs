using System;
using System.Linq;
using AstroAnts.Graphs;

namespace AstroAnts.PathManipulation.ComparerHeuristics
{
    public class HeuristicComparerManhattanOriented : AHeuristicComparer
    {
        public HeuristicComparerManhattanOriented(Graph graph) : base(graph)
        {
            XPosLeft =
                graph.EndNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.LEFT.CharCode)] == -1
                    ? graph.EndNode.NodeCode % graph.RowSize + 2
                    : graph.EndNode.NodeCode % graph.RowSize;

            XPosRight =
                graph.EndNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.RIGHT.CharCode)] == -1
                    ? graph.EndNode.NodeCode % graph.RowSize + 2
                    : graph.EndNode.NodeCode % graph.RowSize;

            YPosTop =
                graph.EndNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.UP.CharCode)] == -1
                    ? graph.EndNode.NodeCode / graph.RowSize + 2
                    : graph.EndNode.NodeCode / graph.RowSize;

            YPosBottom =
                graph.EndNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.DOWN.CharCode)] == -1
                    ? graph.EndNode.NodeCode / graph.RowSize + 2
                    : graph.EndNode.NodeCode / graph.RowSize;
        }

        public int XPosLeft { get; }
        public int XPosRight { get; }
        public int YPosTop { get; }
        public int YPosBottom { get; }

        public override int ComputeHeuristic(IGraphNode graphNode)
        {
            var xPos = graphNode.NodeCode % Graph.RowSize;
            var yPos = graphNode.NodeCode / Graph.RowSize;

            int[] res =
            {
                Math.Abs(XPosLeft - xPos) + Math.Abs(YPosBottom - yPos) - 1,
                Math.Abs(XPosLeft - xPos) + Math.Abs(YPosTop - yPos) - 1,
                Math.Abs(XPosRight - xPos) + Math.Abs(YPosBottom - yPos) - 1,
                Math.Abs(XPosRight - xPos) + Math.Abs(YPosTop - yPos) - 1
            };

            return res.Min();
        }
    }
}