using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataActions.Interface;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DataAccess.DataActions
{
    public class DataActionClass<T> : IDataAction<T> where T : Employee
    {
        private readonly EmployeeContext _context;
        private DbSet<T> entities;
        private readonly ILogger _logger;

        public DataActionClass(EmployeeContext context, ILogger logger)
        {
            _context = context;
            entities = context.Set<T>();
            _logger = logger;
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(int id)
        {
            return entities.FirstOrDefault(x => x.Id == id) ??
                throw new Exception("No Data found with the given id.");
        }

        public void AddData(T entity)
        {
            try
            {
                if (entity == null) throw new ArgumentException("Entity is null.");
                entity.Created = DateTime.Now;

                entities.Add(entity);
                _context.SaveChanges();
                _logger.Information("Data Added into the DataBase successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateData(T entity)
        {
            try
            {
                var existing = entities.FirstOrDefault(x => x.Id == entity.Id) ??
                    throw new Exception("No Data found with the given identifier.");

                _context.Entry(existing).State = EntityState.Modified;
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                _logger.Information("Data Updated into the DataBase successfully.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(int id)
        {
            try
            {
                var existing = entities.FirstOrDefault(x => x.Id == id) ??
                    throw new Exception("No data found with the given identifier.");

                _context.Entry(existing).State = EntityState.Deleted;
                entities.Remove(existing);
                _context.SaveChanges();
                _logger.Information("Data deleted from the DataBase successfully.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}