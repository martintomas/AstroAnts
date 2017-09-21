using System;
using System.Collections.Generic;
using astroAnts.Graphs;

namespace astroAnts.JsonServices
{
    public class AntModel
    {
        private AntModel()
        {
        }

        public string Id { get; set; }
        public long StartedTimestamp { get; set; }
        public Dictionary<string, IList<string>> Map { get; set; }
        public Dictionary<char, short> Astroants { get; set; }
        public Dictionary<char, short> Sugar { get; set; }

        public GraphNode GetStartingNode(Graph graph)
        {
            return GetGraphNodeByPosition(graph, Astroants['x'], Astroants['y']);
        }

        public GraphNode GetEndingNode(Graph graph)
        {
            return GetGraphNodeByPosition(graph, Sugar['x'], Sugar['y']);
        }

        public GraphNode GetGraphNodeByPosition(Graph graph, short x, short y)
        {
            if (graph.PlanetSize < y * graph.RowSize + x)
                throw new Exception("Impossible to obtain GraphNode at specified position!");
            return graph.GraphBody[y * graph.RowSize + x];
        }
    }
}