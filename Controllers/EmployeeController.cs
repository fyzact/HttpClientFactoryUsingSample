using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpClientFactoryUsingSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactoryUsingSample.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly DummyEmployeeService _dummyEmployeeService;
        public EmployeeController(DummyEmployeeService dummyEmployeeService)
        {
            _dummyEmployeeService = dummyEmployeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dummyEmployeeService.Employees();
            return Ok(result);
        }
    }
}
