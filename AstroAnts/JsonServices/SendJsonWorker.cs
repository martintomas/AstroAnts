using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AstroAnts.JsonServices.DataModels;
using Newtonsoft.Json;

namespace AstroAnts.JsonServices
{

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

        public ResponseAntModel SendJsonFile(string url, string path)
        {
            var jsonOutput = JsonConvert.SerializeObject(new RequestAntModel(path));

            var sendFile = SendJsonFileAsync(url, jsonOutput);

            sendFile.Wait();
            return JsonConvert.DeserializeObject<ResponseAntModel>(sendFile.Result);
        }
    }
}