using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.Interface;
using Service.ViewModels;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IServices _service;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IServices services, ILogger<EmployeeController> logger)
        {
            _service = services;
            this._logger = logger;
        }

        [HttpGet("GetAllEmployees")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _service.GetAllEmployees();
        }

        [HttpGet("GetEmployeeById")]
        public Employee GetEmployeeById(int id)
        {
            var employee = _service.GetEmployeeById(id);
            _logger.LogInformation(employee.ToString());

            return employee;
        }

        [HttpPost("AddEmployee")]
        public string AddEmployee([FromForm] EmployeeDto employeeDto, IFormFile? photo)
        {
            var employeeData = ConvertEmployeeDtoToEmployee(employeeDto);

            _service.AddEmployee(employeeData, photo);

            return "Employee Add Successfully!";
        }

        [HttpPut("UpdateEmployee")]
        public string UpdateEmployee([FromForm] EmployeeDto employeeDto, IFormFile? photo)
        {
            var employeeData = ConvertEmployeeDtoToEmployee(employeeDto);

            _service.UpdateEmployee(employeeData, photo);

            return "Employee Data Update Successfully!";
        }

        [HttpDelete("DeleteEmployee")]
        public string DeleteEmployee(EmployeeDto employeeDto)
        {
            var employeeData = ConvertEmployeeDtoToEmployee(employeeDto);

            _service.DeleteEmployee(employeeData);

            return "Employee data deleted successfully!";
        }

        [NonAction]
        private Employee ConvertEmployeeDtoToEmployee(EmployeeDto employeeDto)
        {
            return new Employee()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Gender = employeeDto.Gender,
                MaritalStatus = employeeDto.MaritalStatus,
                BirthDate = employeeDto.BirthDate,
                Hobbies = employeeDto.Hobbies,
                Photo = employeeDto.Photo,
                Salary = employeeDto.Salary,
                Address = employeeDto.Address,
                CountryId = employeeDto.Country,
                StateId = employeeDto.State,
                CityId = employeeDto.City,
                ZipCode = employeeDto.ZipCode,
                Password = employeeDto.Password,
                Created = employeeDto.Created
            };
        }
    }
}