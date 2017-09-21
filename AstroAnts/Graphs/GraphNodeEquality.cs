using System.Collections.Generic;

namespace AstroAnts.Graphs
{
    public class GraphNodeEquality : IEqualityComparer<IGraphNode>
    {
        public bool Equals(IGraphNode x, IGraphNode y)
        {
            return x.NodeCode == y.NodeCode;
        }

        public int GetHashCode(IGraphNode obj)
        {
            if (obj == null) return base.GetHashCode();
            return obj.NodeCode;
        }
    }
}