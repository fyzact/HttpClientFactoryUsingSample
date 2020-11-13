using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientFactoryUsingSample.Models
{
    public class ApiEmployeesResult
    {
        public string Status { get; set; }
        public List<Employee> Data { get; set; }
    }
}
