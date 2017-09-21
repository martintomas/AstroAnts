using System;

namespace astroAnts.Graphs
{
    public class GraphNode : IGraphNode
    {
        public GraphNode(int position, string valueDef, int planetRowSize)
        {
            NodeCode = position;

            var valueDefs = valueDef.Split('-');
            NodeValue = short.Parse(valueDefs[0]);
            if (valueDefs.Length > 1) NodeConnections = ComputeConnections(position, valueDefs[1], planetRowSize);
        }

        public int NodeCode { get; set; }
        public short NodeValue { get; set; }
        public int[] NodeConnections { get; set; }

        protected int[] ComputeConnections(int position, string valueDef, int planetRowSize)
        {
            int[] nodes = {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue}; // keep direction of connections
            var maxConn = valueDef.Length;
            for (short i = 0; i < maxConn; i++)
                nodes[GraphDirections.GetDirectionOrder(valueDef[i])] =
                    FindSuitableNode(position, valueDef[i], planetRowSize);
            return nodes;
        }

        protected int FindSuitableNode(int position, char direction, int planetRowSize)
        {
            if (GraphDirections.RIGHT.CharCode == direction) return ++position;
            if (GraphDirections.UP.CharCode == direction) return position - planetRowSize;
            if (GraphDirections.LEFT.CharCode == direction) return --position;
            if (GraphDirections.DOWN.CharCode == direction) return position + planetRowSize;
            throw new Exception("Unknown graph direction");
        }
    }
}