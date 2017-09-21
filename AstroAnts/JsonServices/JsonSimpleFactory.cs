using System;
using astroAnts.Enumerators;
using Newtonsoft.Json;

namespace astroAnts.JsonServices
{
    internal class JsonSimpleFactory
    {
        public static AntModel GetJsonData(JsonTypes jsonType, string url = "")
        {
            switch (jsonType)
            {
                case JsonTypes.TEST:
                    return JsonConvert.DeserializeObject<AntModel>(new TestJsonWorker().GetJsonFile(url));
                case JsonTypes.API_QUADIENT:
                    url = "http://tasks-rad.quadient.com:8080/task";
                    var ant = JsonConvert.DeserializeObject<AntModel>(new ReceiveJsonWorker().GetJsonFile(url));
                    return ant;
                default:
                    throw new Exception("Unknown source of JSON file");
            }
        }

        public static string SendJsonResponse(JsonTypes jsonType, string id, string path, string url = "")
        {
            switch (jsonType)
            {
                case JsonTypes.TEST:
                    return path == "DLDRRU" ? "Test OK" : "Test Failed";
                case JsonTypes.API_QUADIENT:
                    url = string.Format("http://tasks-rad.quadient.com:8080/task/{0}", id);
                    return new SendJsonWorker().SendJsonFile(url, path);
                default:
                    throw new Exception("Unknown url for JSON reponse");
            }
        }
    }
}