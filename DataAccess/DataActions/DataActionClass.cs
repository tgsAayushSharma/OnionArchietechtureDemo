using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataActions.Interface;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataActions
{
    public class DataActionClass : IDataAction
    {
        private readonly EmployeeContext _context;
        public DataActionClass(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id) ??
                throw new Exception("No Employee found with the given id.");
        }

        public void AddEmployee(Employee employeeEntity)
        {
            try
            {
                employeeEntity.Created = DateTime.Now;

                _context.Add(employeeEntity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(Employee employeeEntity)
        {
            try
            {
                var existingemployee = _context.Employees.FirstOrDefault(x => x.Id == employeeEntity.Id) ??
                    throw new Exception("No Employee found with the given identifier.");

                _context.Entry(existingemployee).State = EntityState.Modified;
                _context.Entry(existingemployee).CurrentValues.SetValues(employeeEntity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEmployee(Employee employeeEntity)
        {
            try
            {
                var existingemployee = _context.Employees.FirstOrDefault(x => x.Id == employeeEntity.Id) ??
                    throw new Exception("No Employee found with the given identifier.");

                _context.Entry(existingemployee).State = EntityState.Deleted;
                _context.Remove(existingemployee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}