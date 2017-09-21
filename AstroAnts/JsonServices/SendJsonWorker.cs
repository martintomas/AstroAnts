using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AstroAnts.JsonServices
{
    public class AntResponse
    {
        public AntResponse(string path)
        {
            this.path = path;
        }

        public string path { get; set; }
    }

    public class SendJsonWorker
    {
        private async Task<string> SendJsonFileAsync(string url, string jsonOutput)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json";

            var rs = await request.GetRequestStreamAsync();

            var content = Encoding.UTF8.GetBytes(jsonOutput);
            rs.Write(content, 0, content.Length);
            rs.Flush();

            var ws = await request.GetResponseAsync();
            var receiveStream = ws.GetResponseStream();
            var readStream = new StreamReader(receiveStream);

            return readStream.ReadToEnd();
        }

        public string SendJsonFile(string url, string path)
        {
            var jsonOutput = JsonConvert.SerializeObject(new AntResponse(path));

            var sendFile = SendJsonFileAsync(url, jsonOutput);

            sendFile.Wait();
            return sendFile.Result;
        }
    }
}