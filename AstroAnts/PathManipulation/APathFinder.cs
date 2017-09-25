using System;
using System.Text;
using AstroAnts.Graphs;

namespace AstroAnts.PathManipulation
{
    public abstract class APathFinder
    {
        protected APathFinder(Graph graph)
        {
            Graph = graph;
        }

        public Graph Graph { get; }

        public abstract PathFinderResult FindPath(); // template pattern --> behavior filled in childrens

        public string GetPathSimpleString(PathFinderResult pathResult)
        {
            IGraphNode start = Graph.EndNode;
            var sb = new StringBuilder();
            var pathValue = 0;
            var pathNum = 0;

            if (pathResult.Path != null)
                while (start != Graph.StartNode)
                {
                    pathValue += start.NodeValue;
                    pathNum++;

                    sb.Insert(0, pathResult.PathDirections[start.NodeCode]); //add at begginig
                    start = pathResult.Path[start.NodeCode];
                }

            Console.WriteLine("Path value is "+pathValue);
            Console.WriteLine("Number of steps is "+pathNum);

            return sb.ToString();
        }
    }
}