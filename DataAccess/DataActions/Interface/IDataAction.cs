using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.DataActions.Interface
{
    public interface IDataAction
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employeeEntity);
        void UpdateEmployee(Employee employeeEntity);
        void DeleteEmployee(Employee employeeEntity);
    }
}