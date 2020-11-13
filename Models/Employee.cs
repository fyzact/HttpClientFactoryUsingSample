using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HttpClientFactoryUsingSample.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string Employee_name { get; set; }
        public string Employee_salary { get; set; }
        public string Employee_age { get; set; }
        public string Profile_image { get; set; }
    }
}
