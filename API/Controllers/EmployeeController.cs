using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IServices _service;

        public EmployeeController(IServices services)
        {
            _service = services;
        }

        [HttpGet("GetAllEmployees")]
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return _service.GetAllEmployees();
        }

        [HttpGet("GetEmployeeById")]
        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = _service.GetEmployeeById(id);

            return employee;
        }

        [HttpPost("AddEmployee")]
        public string AddEmployee([FromForm] EmployeeDto employeeDto, IFormFile? photo)
        {
            _service.AddEmployee(employeeDto, photo);

            return "Employee Add Successfully!";
        }

        [HttpPut("UpdateEmployee")]
        public string UpdateEmployee(EmployeeDto employeeDto)
        {
            _service.UpdateEmployee(employeeDto);

            return "Employee Data Update Successfully!";
        }

        [HttpDelete("DeleteEmployee")]
        public string DeleteEmployee(int id)
        {
            _service.DeleteEmployee(id);

            return "Employee data deleted successfully!";
        }

    }
}