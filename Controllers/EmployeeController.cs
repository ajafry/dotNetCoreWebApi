using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonitorTestApi.Models;

namespace MonitorTestApi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmployeeController> _logger;
        private readonly List<Employee> testData; 

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
            testData = JsonSerializer.Deserialize<List<Employee>>(TestData.testData);
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            _logger.LogInformation("[EmployeeController] You invoked Get to receive a list of all employees");
            return testData.ToArray();
        }

        [HttpGet("{lastNameFragment}")]
        public IEnumerable<Employee> Get(string lastNameFragment)
        {
            _logger.LogInformation($"[EmployeeController] You invoked get to receive all employees who match {lastNameFragment}");
            //List<Employee> dataToReturn = new List<Employee>();
            var toRet = testData.FindAll(
                e => e.LastName.StartsWith(lastNameFragment, 
                StringComparison.InvariantCultureIgnoreCase));
            _logger.LogInformation($"[EmployeeController] Returning {toRet.Count()}");
            return toRet.ToArray();
        }
    }
}
