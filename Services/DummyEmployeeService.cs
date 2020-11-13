using HttpClientFactoryUsingSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientFactoryUsingSample.Extensions;

namespace HttpClientFactoryUsingSample.Services
{
    public class DummyEmployeeService 
    {
        readonly HttpClient _httpClient;
        public DummyEmployeeService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://dummy.restapiexample.com/");
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> Employees()
        {
            var jsonEmployees = await _httpClient.GetStringAsync("api/v1/employees");
            var employeApiResult = jsonEmployees.Deserialize<ApiEmployeesResult>();
            return employeApiResult.Data;
        }
    }
}
