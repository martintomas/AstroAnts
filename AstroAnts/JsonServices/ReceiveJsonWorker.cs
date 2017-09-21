using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AstroAnts.JsonServices
{
    public class ReceiveJsonWorker : IJsonWorker
    {
        public string GetJsonFile(string url)
        {
            var downloadFile = DownloadJsonFileAsync(url);

            downloadFile.Wait();
            return downloadFile.Result;
        }

        private async Task<string> DownloadJsonFileAsync(string url)
        {
            var request = WebRequest.CreateHttp(url);
            var ws = await request.GetResponseAsync();
            var receiveStream = ws.GetResponseStream();
            var readStream = new StreamReader(receiveStream);
            return readStream.ReadToEnd();
        }
    }
}