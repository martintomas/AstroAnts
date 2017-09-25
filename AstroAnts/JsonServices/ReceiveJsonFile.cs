using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AstroAnts.JsonServices
{
    public class ReceiveJsonFile : IJsonWorker
    {
        public string GetJsonFile(string url)
        {
            return System.IO.File.ReadAllText(url);
        }

    }
}