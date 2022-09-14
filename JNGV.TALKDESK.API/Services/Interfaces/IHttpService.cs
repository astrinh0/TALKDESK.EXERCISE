using JNGV.TALKDESK.DOMAIN.Models;

namespace JNGV.TALKDESK.API.Services
{
    public interface IHttpService
    {
        public Task<ResponseJson> RequestApi(string prefix);
    }
}
