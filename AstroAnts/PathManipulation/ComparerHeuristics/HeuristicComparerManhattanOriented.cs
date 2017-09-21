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
                    : graph.EndNode.NodeCode % graph.RowSize;

            YPosBottom =
                graph.EndNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.DOWN.CharCode)] == -1
                    ? graph.EndNode.NodeCode / graph.RowSize + 2
                    : graph.EndNode.NodeCode % graph.RowSize;
        }

        public int XPosLeft { get; }
        public int XPosRight { get; }
        public int YPosTop { get; }
        public int YPosBottom { get; }

        public override int ComputeHeuristic(IGraphNode graphNode)
        {
            var xPosLeft =
                graphNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.LEFT.CharCode)] == -1
                    ? graphNode.NodeCode % Graph.RowSize + 2
                    : graphNode.NodeCode % Graph.RowSize;

            var xPosRight =
                graphNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.RIGHT.CharCode)] == -1
                    ? graphNode.NodeCode % Graph.RowSize + 2
                    : graphNode.NodeCode % Graph.RowSize;

            var yPosTop =
                graphNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.UP.CharCode)] == -1
                    ? graphNode.NodeCode / Graph.RowSize + 2
                    : graphNode.NodeCode % Graph.RowSize;

            var yPosBottom =
                graphNode.NodeConnections[GraphDirections.GetDirectionOrder(GraphDirections.DOWN.CharCode)] == -1
                    ? graphNode.NodeCode / Graph.RowSize + 2
                    : graphNode.NodeCode % Graph.RowSize;


            int[] res =
            {
                Math.Abs(XPosLeft - xPosLeft) + Math.Abs(YPosBottom - yPosBottom) - 1,
                Math.Abs(XPosLeft - xPosLeft) + Math.Abs(YPosTop - yPosTop) - 1,
                Math.Abs(XPosRight - xPosRight) + Math.Abs(YPosBottom - yPosBottom) - 1,
                Math.Abs(XPosRight - xPosRight) + Math.Abs(YPosTop - yPosTop) - 1
            };

            return res.Min();
        }
    }
}