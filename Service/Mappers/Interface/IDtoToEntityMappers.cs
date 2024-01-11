using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Service.ViewModels;

namespace Service.Mappers.Interface
{
    public interface IDtoToEntityMappers
    {
        Employee ConvertEmployeeDtoToEntity(EmployeeDto employeeDto);
        EmployeeDto ConvertEmployeeEntityToDto(Employee employeeEntity);
        IEnumerable<EmployeeDto> ConvertEmployeesEntityToDto(IEnumerable<Employee> employees);
    }
}