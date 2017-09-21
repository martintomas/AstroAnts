using System;
using AstroAnts.JsonServices;
using AstroAnts.JsonServices.DataModels;

namespace AstroAnts.Graphs
{
    public class Graph // can be used as decorator for antmodel
    {
        public Graph(AntModel antModel)
        {
            AntModel = antModel;
            PlanetSize = AntModel.Map["areas"].Count; //shortcut
            RowSize = (int) Math.Sqrt(PlanetSize); //shortcut !!! requires squere

            GraphBody = BuildGraph(antModel, PlanetSize, RowSize);
            StartNode = AntModel.GetStartingNode(this);
            EndNode = AntModel.GetEndingNode(this);
        }

        public AntModel AntModel { get; }
        public GraphNode StartNode { get; set; }
        public GraphNode EndNode { get; set; }
        public GraphNode[] GraphBody { get; set; }
        public int RowSize { get; }
        public int PlanetSize { get; }

        public string ID => AntModel == null ? "" : AntModel.Id;

        public GraphNode[] BuildGraph(AntModel antModel, int planetSize, int planetRowSize)
        {
            var tempGraph = new GraphNode[planetSize];

            var i = 0;
            foreach (var conn in antModel.Map["areas"])
            {
                tempGraph[i] = new GraphNode(i, conn, planetRowSize);
                i++;
            }
            return tempGraph;
        }
    }
}