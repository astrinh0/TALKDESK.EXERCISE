using JNGV.TALKDESK.API.Repository;
using JNGV.TALKDESK.DOMAIN.Models;
using System.Text.RegularExpressions;

namespace JNGV.TALKDESK.API.Services
{
    public class ApiService : IApiService
    {
        private readonly IApiRepository _apiRepository;
        private readonly IHttpService _httpService;

        public ApiService(IApiRepository apiRepository, IHttpService httpService)
        {
            _apiRepository = apiRepository;
            _httpService = httpService;
        }



        
        public async Task<Dictionary<string, Dictionary<string, int>>> GetPrefixes(List<string> phonesNumbers)
        {
            List<string> prefixsFile = _apiRepository.ReadFile();
            Dictionary<string, Dictionary<string, int>> values = new Dictionary<string, Dictionary<string, int>>();

            foreach (var number in phonesNumbers.ToList())
            {
                var aux = Regex.Replace(number, @"^(\+|00)", "");

                var found = prefixsFile.Where(x => aux.StartsWith(x)).FirstOrDefault();

                if (!string.IsNullOrEmpty(found))
                {
                    var request = await _httpService.RequestApi(number);

                    if (request != null)
                    {
                        if (values.ContainsKey(found))
                        {
                            var x = values[found];

                            if (x.ContainsKey(request.Sector))
                            {
                                x[request.Sector]++;
                            }
                            else
                            {
                                x.Add(request.Sector, 1);
                            }
                        }
                        else
                        {
                            Dictionary<string, int> dict = new Dictionary<string, int>();
                            dict.Add(request.Sector, 1);
                            values.Add(found, dict);
                        }
                    }

                }
            }

            return values;
        }
    }
}
