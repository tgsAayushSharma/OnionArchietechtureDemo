using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Service.ViewModels;

namespace Service.Interface
{
    public interface IServices
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee, IFormFile photo);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}