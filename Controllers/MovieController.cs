using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientFactoryUsingSample.Extensions;
using HttpClientFactoryUsingSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactoryUsingSample.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        HttpClient _httpClient;
        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("movie-sample-api");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movieJson = await _httpClient.GetStringAsync("movies/api/animation");
            var movies = movieJson.Deserialize<IEnumerable<Movie>>();
            return Ok(movies);
        }
    }
}
