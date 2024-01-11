using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Domain;
using DataAccess.Models;

namespace Service.Mappers.Interface
{
    public interface IDomainToEntityMappers
    {
        Employee ConvertEmployeeDomainToEntity(EmployeeDomain employee);
    }
}