using AstroAnts.Graphs;

namespace AstroAnts.PathManipulation
{
    public struct PathFinderResult
    {
        public IGraphNode[] Path { get; set; }
        public char[] PathDirections { get; set; }
        public int[] Distances { get; set; }
    }
}