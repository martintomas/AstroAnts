namespace AstroAnts.Graphs
{
    public interface IGraphNode
    {
        int NodeCode { get; set; }
        short NodeValue { get; set; }
        int[] NodeConnections { get; set; }
    }
}