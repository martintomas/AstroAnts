using astroAnts.Graphs;

namespace astroAnts.PathManipulation.ComparerHeuristics
{
    internal class HeuristicComparerSimple : AHeuristicComparer
    {
        public HeuristicComparerSimple(Graph graph) : base(graph)
        {
        }

        public override int ComputeHeuristic(IGraphNode graphNode)
        {
            return 0;
        }
    }
}