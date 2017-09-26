using System;
using System.Diagnostics;
using AstroAnts.Enumerators;
using AstroAnts.Graphs;
using AstroAnts.JsonServices;
using AstroAnts.JsonServices.DataModels;
using AstroAnts.PathManipulation;

namespace AstroAnts
{
    public static class SimpleFacade
    {
        public static void RunAntQuest(JsonTypes jsonWorker, PathAlgorithms pathAlgorithm, bool DEBUG, string url = "")
        {
 
            try
            {
                var sw = new Stopwatch();
                sw.Start();

                Console.WriteLine("Running ANT QUEST for {0} and {1}", jsonWorker, pathAlgorithm);

                AntModel antModel = JsonSimpleFactory.GetJsonData(jsonWorker, url);
                if (DEBUG) Console.WriteLine("Obtaining data took: {0} ms", sw.Elapsed.Milliseconds);

                sw.Restart();

                var antGraph = new Graph(antModel);
                if(DEBUG) Console.WriteLine("Graph preparation took: {0} ms", sw.Elapsed.Milliseconds);

                sw.Restart();

                var pathFinder = PathFinderFactory.PathFactory(antGraph, pathAlgorithm);
                var path = pathFinder.FindPath();
                var pathString = pathFinder.GetPathSimpleString(path);

                if (DEBUG) Console.WriteLine("Path finding took: {0} ms", sw.Elapsed.Milliseconds);
                if (DEBUG) Console.WriteLine("Final path is: {0}", pathString);

                sw.Restart();

                if (jsonWorker == JsonTypes.TEST || jsonWorker == JsonTypes.URL || jsonWorker == JsonTypes.API_QUADIENT)
                {
                    var serverResponse =
                        JsonSimpleFactory.SendJsonResponse(jsonWorker, antGraph.ID, pathString, url);
                    Console.WriteLine(serverResponse.Message);

                    if (serverResponse.Valid && serverResponse.InTime && DEBUG) Console.WriteLine("Test passed");
                    else if (DEBUG) Console.WriteLine("Test failed");
                }

                if (DEBUG) Console.WriteLine("Sending data took: {0} ms", sw.Elapsed.Milliseconds);

                sw.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}