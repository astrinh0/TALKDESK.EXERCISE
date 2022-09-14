using JNGV.TALKDESK.DOMAIN.Models;

namespace JNGV.TALKDESK.API.Services
{
    public interface IApiService
    {
        public Task<Dictionary<string, Dictionary<string, int>>> GetPrefixes(List<string> phonesNumbers);
    }
}
