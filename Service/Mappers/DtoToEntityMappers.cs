using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Service.Mappers.Interface;
using Service.ViewModels;

namespace Service.Mappers
{
    public class DtoToEntityMappers : IDtoToEntityMappers
    {
        public Employee ConvertEmployeeDtoToEntity(EmployeeDto employeeDto)
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
                Country = employeeDto.Country,
                State = employeeDto.State,
                City = employeeDto.City,
                ZipCode = employeeDto.ZipCode,
                Password = employeeDto.Password,
                Created = employeeDto.Created
            };
        }

        public EmployeeDto ConvertEmployeeEntityToDto(Employee employee)
        {
            return new EmployeeDto(employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.Gender, employee.MaritalStatus,
                 employee.BirthDate, employee.Hobbies, employee.Photo, employee.Salary, employee.Address, employee.Country, employee.State, employee.City, employee.ZipCode,
                 employee.Password, employee.Created);
        }

        public IEnumerable<EmployeeDto> ConvertEmployeesEntityToDto(IEnumerable<Employee> employees)
        {
            var employeedto = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                employeedto.Add(new EmployeeDto(employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.Gender, employee.MaritalStatus,
                 employee.BirthDate, employee.Hobbies, employee.Photo, employee.Salary, employee.Address, employee.Country, employee.State, employee.City, employee.ZipCode,
                 employee.Password, employee.Created));
            }
            return employeedto;
        }
    }
}