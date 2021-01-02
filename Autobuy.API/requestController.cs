using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy
{
    public class requestController
    {
        private string APILink = "https://autobuy.io/api/";
        public string APIKey { get; set; }

        public async Task<string> RequestAsync(HttpMethod httpMethod, string LinkParam,
            Dictionary<string, string> BodyUrlEncode = null, Dictionary<string, string> Headers = null)
        {
            if (string.IsNullOrEmpty(APIKey) ||
                string.IsNullOrWhiteSpace(APIKey))
            {
                throw new Exception("You must include the APIKey!");
            }

            var handler = new HttpClientHandler()
            {
                UseCookies = false
            };

            var httpClient = new HttpClient(handler);

            httpClient.DefaultRequestHeaders.Add("APIKey", APIKey);
            httpClient.BaseAddress = new Uri(APILink);
            var request = new HttpRequestMessage(httpMethod, $"{LinkParam}");

            var bodyParams = new List<KeyValuePair<string, string>>();

            if (BodyUrlEncode != null)
            {
                foreach (var i in BodyUrlEncode)
                {
                    bodyParams.Add(new KeyValuePair<string, string>(i.Key, i.Value));
                }

                request.Content = new FormUrlEncodedContent(bodyParams);
            }

            if (Headers != null)
            {
                foreach (var i in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(i.Key, i.Value);
                }
            }

            var response = await httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
