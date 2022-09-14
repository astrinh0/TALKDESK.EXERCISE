using JNGV.TALKDESK.API.Services;
using JNGV.TALKDESK.DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JNGV.TALKDESK.API.Controllers
{
    [Route("")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IApiService _apiService;

        public ApiController(IApiService apiService)
        {
            _apiService = apiService;
        }
        [SwaggerOperation("Get phone information", null, Tags = new[] { "TALKDESK API" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<Prefix>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("aggregate")]
        public async Task<Dictionary<string, Dictionary<string, int>>> Aggregate(List<string> phonesNumbers)
        {
            var result = await _apiService.GetPrefixes(phonesNumbers);

            return result;
        }




    }

}
