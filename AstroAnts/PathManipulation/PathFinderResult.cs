using astroAnts.Graphs;

namespace astroAnts.PathManipulation
{
    public struct PathFinderResult
    {
        public IGraphNode[] Path { get; set; }
        public char[] PathDirections { get; set; }
        public int[] Distances { get; set; }
    }
}