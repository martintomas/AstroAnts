namespace AstroAnts.Graphs
{
    public class GraphNodeDecorator : IGraphNode
    {
        private readonly IGraphNode _graphNode;

        public GraphNodeDecorator(IGraphNode graphNode)
        {
            _graphNode = graphNode;
        }

        public int NodeCode
        {
            get => _graphNode.NodeCode;
            set => _graphNode.NodeCode = value;
        }

        public short NodeValue
        {
            get => _graphNode.NodeValue;
            set => _graphNode.NodeValue = value;
        }

        public int[] NodeConnections
        {
            get => _graphNode.NodeConnections;
            set => _graphNode.NodeConnections = value;
        }
    }
}