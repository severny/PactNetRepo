using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly EmployeeRepository _employeeRepository = new EmployeeRepository();

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        [HttpPost]
        public bool Post(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _employeeRepository.Remove(id);
        }
    }
}
