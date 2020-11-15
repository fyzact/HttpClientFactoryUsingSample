using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HttpClientFactoryUsingSample.Models;
using Microsoft.AspNetCore.Mvc;
using HttpClientFactoryUsingSample.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HttpClientFactoryUsingSample.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
       readonly HttpClient _httpClient;
        public TodosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        // GET: api/<TodoController>
        [HttpGet]
        public async  Task<IActionResult> Get()
        {
            var url = "https://jsonplaceholder.typicode.com/todos";
            var todosJson = await _httpClient.GetStringAsync(url);
            var todos = todosJson.Deserialize<IEnumerable<Todo>>();
            return Ok(todos);
        }

    }

   
}
