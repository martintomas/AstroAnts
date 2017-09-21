using AstroAnts.Graphs;
using AstroAnts.PathManipulation.ComparerHeuristics;
using AstroAnts.Services;

namespace AstroAnts.PathManipulation
{
    public class PathFinderAStar : APathFinder
    {
        public PathFinderAStar(Graph graph, AHeuristicComparer heuristicComparer = null) : base(graph)
        {
            Distances = new int[Graph.PlanetSize];
            ArrayServices.InitializeArrayValue(Distances, int.MaxValue);

            Path = new GraphNode[Graph.PlanetSize];
            ArrayServices.InitializeArrayValue(Path, null);

            PathDirections = new char[Graph.PlanetSize];
            ArrayServices.InitializeArrayValue(PathDirections, ' ');

            ClosedSet = new bool[Graph.PlanetSize];
            ArrayServices.InitializeArrayValue(ClosedSet, false);

            if (heuristicComparer == null) HeuristicComparer = new HeuristicComparerSimple(graph);
            else HeuristicComparer = heuristicComparer;

            OpenSet = new PriorityQueue<GraphNodeHeuristic>(300, HeuristicComparer, new GraphNodeEquality());
        }

        public int[] Distances { get; set; }
        public IGraphNode[] Path { get; set; }
        public char[] PathDirections { get; set; }
        public bool[] ClosedSet { get; set; }
        public PriorityQueue<GraphNodeHeuristic> OpenSet { get; set; }
        public AHeuristicComparer HeuristicComparer { get; }

        public override PathFinderResult FindPath()
        {
            GraphNodeHeuristic tempX, tempY;
            bool updateDist;
            int i, conn, distTemp;
            var numberOfSteps = 0;

            Distances[Graph.StartNode.NodeCode] = 0; // distance in firts node is zero
            OpenSet.Add(new GraphNodeHeuristic(Graph.StartNode, 0, 0)); //O(log n)

            while (OpenSet.Count > 0) //O(1)
            {
                numberOfSteps++;
                tempX = OpenSet.ExtractMin(); // get first suitable key and remove it (O(log n))

                if (tempX.GraphNode.Equals(Graph.EndNode))
                    return new PathFinderResult
                    {
                        Path = Path,
                        PathDirections = PathDirections,
                        Distances = Distances
                    };

                ClosedSet[tempX.NodeCode] = true;
                for (i = 0; i < 4; i++) // four directions
                {
                    conn = tempX.NodeConnections[i];
                    if (conn == int.MaxValue || ClosedSet[conn]) continue; //skip value, no connections

                    distTemp = Distances[tempX.NodeCode] + Graph.GraphBody[conn].NodeValue;

                    tempY = new GraphNodeHeuristic(Graph.GraphBody[conn], distTemp,
                        HeuristicComparer.ComputeHeuristic(Graph.GraphBody[conn]));

                    if (!OpenSet.Contains(tempY)) //O(log 1)
                    {
                        OpenSet.Add(tempY); //O(log n) 
                        updateDist = true;
                    }
                    else if (distTemp < Distances[tempY.NodeCode])
                    {
                        updateDist = true;
                    }
                    else
                    {
                        updateDist = false;
                    }

                    if (updateDist)
                    {
                        OpenSet.UpdateDistance(tempY); // O(log n)

                        Path[tempY.NodeCode] = tempX.GraphNode;
                        PathDirections[tempY.NodeCode] = GraphDirections.GetDirectionCharCode((byte) i);
                        Distances[tempY.NodeCode] = distTemp;
                    }
                }
            }

            // no path found
            return new PathFinderResult
            {
                Path = null,
                PathDirections = null,
                Distances = null
            };
        }
    }
}