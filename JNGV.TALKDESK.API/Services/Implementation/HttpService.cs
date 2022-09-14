using JNGV.TALKDESK.DOMAIN.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace JNGV.TALKDESK.API.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _client;
        private readonly IConfiguration _configuration;

        public HttpService(IHttpClientFactory client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }


        public async Task<ResponseJson> RequestApi(string prefix)
        {
            var url =
            $"{_configuration.GetValue<string>("TalkdeskApi")}{prefix}";

            var client = _client.CreateClient();

            var response = await client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ResponseJson>(await response.Content.ReadAsStringAsync());

            return null;
        }
    }
}
