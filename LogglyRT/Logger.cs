using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using LogglyRT.Interface;

namespace LogglyRT
{
    /// <summary>
    /// Simple Loggly.com helper logger class for WinRT (Windows 8 App Store apps).
    /// Created by Kory Becker
    /// http://www.primaryobjects.com
    /// </summary>
    public class Logger : ILogger
    {
        private readonly string _inputKey;
        private string _url = "https://logs.loggly.com/inputs/";
        private readonly string _contentType = "text/plain";

        /// <summary>
        /// Constructs a WinRT Loggly logger.
        /// </summary>
        /// <param name="inputKey">Loggly API key</param>
        /// <param name="logglyUrl">Url to Loggly service</param>
        /// <param name="contentType">HTTP Content-Type: text/plain, application/json, etc</param>
        public Logger(string inputKey, string logglyUrl = "https://logs.loggly.com/inputs/", string contentType = "text/plain")
        {
            _inputKey = inputKey;
            _url = logglyUrl;
            _contentType = contentType;
        }

        /// <summary>
        /// Log a message to the Loggly API.
        /// </summary>
        /// <param name="message">string</param>
        public async Task<HttpResponseMessage> Log(string message)
        {
            HttpResponseMessage result = null;
            string url = _url + _inputKey;

            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler) { BaseAddress = new Uri(url) })
                {
                    StringContent content = new StringContent(message, Encoding.UTF8, _contentType);

                    result = await client.PostAsync(client.BaseAddress, content);
                }
            }

            return result;
        }
    }
}
