using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Domain;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Service.Mappers.Interface;
using Service.ViewModels;

namespace Service.Mappers
{
    public class DtoToDomainMappers : IDtoToDomainMappers
    {
        public EmployeeDomain ConvertEmployeeDtoToDomain(EmployeeDto employeeDto)
        {
            return new EmployeeDomain(employeeDto.Id, employeeDto.FirstName, employeeDto.LastName, employeeDto.Email, employeeDto.Gender, employeeDto.MaritalStatus,
                employeeDto.BirthDate, employeeDto.Hobbies, employeeDto.Photo, employeeDto.Salary, employeeDto.Address, employeeDto.Country, employeeDto.State, employeeDto.City,
                 employeeDto.ZipCode, employeeDto.Password, employeeDto.Created);

        }
    }
}