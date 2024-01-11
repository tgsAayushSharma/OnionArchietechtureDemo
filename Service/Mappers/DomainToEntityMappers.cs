using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Domain;
using DataAccess.Models;
using Service.Mappers.Interface;

namespace Service.Mappers
{
    public class DomainToEntityMappers : IDomainToEntityMappers
    {
        public Employee ConvertEmployeeDomainToEntity(EmployeeDomain employee)
        {
            return new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Gender = employee.Gender,
                MaritalStatus = employee.MaritalStatus,
                BirthDate = employee.BirthDate,
                Hobbies = employee.Hobbies,
                Photo = employee.Photo,
                Salary = employee.Salary,
                Address = employee.Address,
                Country = employee.Country,
                State = employee.State,
                City = employee.City,
                ZipCode = employee.ZipCode,
                Password = employee.Password,
                Created = employee.Created
            };
        }
    }
}