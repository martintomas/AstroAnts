namespace astroAnts.Graphs
{
    public class GraphNodeHeuristic : GraphNodeDecorator
    {
        public GraphNodeHeuristic(IGraphNode graphNode, int distanceValue, int heuristicValue = 0) : base(graphNode)
        {
            HeuristicValue = heuristicValue;
            DistanceValue = distanceValue;
            GraphNode = graphNode;
        }

        public IGraphNode GraphNode { get; }
        public int HeuristicValue { get; set; }
        public int DistanceValue { get; set; }
    }
}