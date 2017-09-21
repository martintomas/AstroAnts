using System;
using AstroAnts.Enumerators;
using AstroAnts.JsonServices.DataModels;
using Newtonsoft.Json;

namespace AstroAnts.JsonServices
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

        public static ResponseAntModel SendJsonResponse(JsonTypes jsonType, string id, string path, string url = "")
        {
            switch (jsonType)
            {
                case JsonTypes.TEST:
                    return new ResponseAntModel
                    {
                        InTime = true,
                        Valid = (path == "DLDRRU"),
                        Message = (path == "DLDRRU" ? "Test OK" : "Test Failed")
                    };
                case JsonTypes.API_QUADIENT:
                    url = string.Format("http://tasks-rad.quadient.com:8080/task/{0}", id);
                    return new SendJsonWorker().SendJsonFile(url, path);
                default:
                    throw new Exception("Unknown url for JSON reponse");
            }
        }
    }
}