using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Service.ViewModels;

namespace Service.Interface
{
    public interface IServices
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
        string AddEmployee(EmployeeDto employeeDto, IFormFile photo);
        void UpdateEmployee(EmployeeDto employeeDto);
        void DeleteEmployee(int id);
    }
}