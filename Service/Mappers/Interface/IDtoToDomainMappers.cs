using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Domain;
using Microsoft.AspNetCore.Http;
using Service.ViewModels;

namespace Service.Mappers.Interface
{
    public interface IDtoToDomainMappers
    {
        EmployeeDomain ConvertEmployeeDtoToDomain(EmployeeDto employeeDto);
    }
}