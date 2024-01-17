using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.DataActions.Interface
{
    public interface IRepository<T> where T : Employee
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void AddData(T employeeEntity);
        void UpdateData(T employeeEntity);
        void DeleteData(T employeeEntity);
    }
}