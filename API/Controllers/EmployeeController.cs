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

        public EmployeeController(IServices services)
        {
            _service = services;
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

            return employee;
        }

        [HttpPost("AddEmployee")]
        public string AddEmployee([FromForm] EmployeeDto employeeDto, IFormFile? photo)
        {
            var employeeData = new Employee()
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
                Country = employeeDto.Country,
                State = employeeDto.State,
                City = employeeDto.City,
                ZipCode = employeeDto.ZipCode,
                Password = employeeDto.Password,
                Created = employeeDto.Created
            };

            _service.AddEmployee(employeeData, photo);

            return "Employee Add Successfully!";
        }

        [HttpPut("UpdateEmployee")]
        public string UpdateEmployee(EmployeeDto employeeDto)
        {
            var employeeData = new Employee()
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
                Country = employeeDto.Country,
                State = employeeDto.State,
                City = employeeDto.City,
                ZipCode = employeeDto.ZipCode,
                Password = employeeDto.Password,
                Created = employeeDto.Created
            };
            _service.UpdateEmployee(employeeData);

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