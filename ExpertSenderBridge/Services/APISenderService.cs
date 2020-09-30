using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSenderBridge.Services
{
    internal class APISenderService
    {
        private static HttpClient _httpClient = new HttpClient();
        private const int _maxNumOfRequestAttempts = 3;
        private const string _timeoutMsg = "Request timed out";
        private const string _httpRequestErrorMsg = "HttpRequestException was thrown. Unable to get a response from the ExpertSender service.";
        private const string _failedMsg = "Operation failed";

        public static async Task<HttpResponseMessage> SendPostAPIAsync(string url, string apiRequestContent)
        {
            int cnt = 0;
            do
            {
                //if (cnt > 0) logger.Error("Retry " + cnt + "...");
                try
                {
                    var httpContent = new StringContent(apiRequestContent, Encoding.UTF8, "application/xml");
                    var response = await _httpClient.PostAsync(url, httpContent);

                    return response;
                }
                catch (TaskCanceledException taskException)
                {
                    //if (!taskException.CancellationToken.IsCancellationRequested) logger.Error(_timeoutMsg);
                }
                catch (HttpRequestException)
                { 
                    //logger.Error(_httpRequestErrorMsg); 
                }
                catch (Exception e)
                {
                    //logger.Error(e.Message);
                    Console.WriteLine(e);
                }
                cnt++;
            } while (cnt < _maxNumOfRequestAttempts);
            throw new Exception(_failedMsg);
        }
    }

    
}
